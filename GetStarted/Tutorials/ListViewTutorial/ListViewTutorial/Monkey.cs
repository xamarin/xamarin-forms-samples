namespace ListViewTutorial
{
    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
