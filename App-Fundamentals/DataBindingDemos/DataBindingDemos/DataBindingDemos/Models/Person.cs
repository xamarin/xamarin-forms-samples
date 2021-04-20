namespace DataBindingDemos
{
    public class Person
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Fullname => $"{Forename} {Surname}";
    }
}
