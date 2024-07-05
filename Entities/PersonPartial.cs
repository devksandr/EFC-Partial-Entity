namespace EFC_Partial_Entity.Entities
{
    public class PersonPartial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
            => $"Id = {Id}, Name = {Name}, Age = {Age}";
    }
}
