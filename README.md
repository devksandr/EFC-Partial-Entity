# Description
In `Entity Framework Core` we can store `DB` data **not completely**, but only **part**

## Problem
In `DB` we have `Person` table with `6` fields and **MANY** rows <br>
Our app only uses `3` fields from this table. But unused data takes up **extra space** <br>
`DB` is used by many apps - we can't just delete unused data in our app from `DB` <br>

## Solution
We replace `Person Entity` with another one (`PersonFull` -> `PersonPartial`) <br>

### Replace entity way
Just update entity type in `DbContext` for table `Person`: <br>

```csharp
// Before
public DbSet<PersonFull> People { get; set; } = null!;

// After
public DbSet<PersonPartial> People { get; set; } = null!;
```

After that `DbContext.People` will store only required data (`3` fields instead of `6`)

### Multiple contexts way
We use multiple `DbContext`: one has full `Person` data, another has part of it

- Creation `DbContext`: To avoid exception by multiple contexts we need to type `DbContextOptions` by `DbContext` class
  ```csharp
  // DataContextFull
  public class DataContextFull : DbContext
  {
      public DbSet<PersonFull> People { get; set; } = null!;
      public DataContextFull(DbContextOptions<DataContextFull> options) : base(options)
        => Database.EnsureCreated();
  }

  // DataContextPartial
  public class DataContextPartial : DbContext
  {
      public DbSet<PersonPartial> People { get; set; } = null!;
      public DataContextFull(DbContextOptions<DataContextPartial> options) : base(options)
        => Database.EnsureCreated();
  }
  ```

- Registration `DbContext`: As usual (We use `SQLite` -> `.UseSqlite(connectionString)`)
  ```csharp
  builder.Services.AddDbContext<DataContextFull>(options => options.UseSqlite(connectionString));
  builder.Services.AddDbContext<DataContextPartial>(options => options.UseSqlite(connectionString));
  ```
- Usage: Just pass required `DbContext` through `DI` (For example - `Minimal API`):
  ```csharp
  app.MapGet("/db/full", (DataContextFull db) => string.Join("\n", db.People));
  app.MapGet("/db/partial", (DataContextPartial db) => string.Join("\n", db.People));
  ```

After that we can:
- Use `DataContextFull` to get access to full `People` data (`6` fields)
- Use `DataContextPartial` to get access to partial `People` data (`3` fields)

Also we can use only `DataContextFull`, only `DataContextPartial` or both of them
