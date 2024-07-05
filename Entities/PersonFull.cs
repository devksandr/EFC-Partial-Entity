namespace EFC_Partial_Entity.Entities
{
    public class PersonFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool Married { get; set; }
        public string City { get; set; }

        public override string ToString()
            => $"Id = {Id}, Name = {Name}, Surname = {Surname}, Age = {Age}, Married = {Married}, City = {City}";
    }
}
