using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlTemplateDemos
{
    public class PeopleViewModel
    {
        public ObservableCollection<Person> People { get; set; }

        public ICommand DeletePersonCommand { get; private set; }

        public PeopleViewModel()
        {
            DeletePersonCommand = new Command((name) =>
            {
                People.Remove(People.FirstOrDefault(p => p.Name.Equals(name)));
            });

            People = new ObservableCollection<Person>
            {
                new Person
                {
                    Name = "John Doe",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla elit dolor, convallis non interdum."
                },
                new Person
                {
                    Name = "Jane Doe",
                    Description = "Phasellus eu convallis mi. In tempus augue eu dignissim fermentum. Morbi ut lacus vitae eros lacinia."
                },
                new Person
                {
                    Name = "Xamarin Monkey",
                    Description = "Aliquam sagittis, odio lacinia fermentum dictum, mi erat scelerisque erat, quis aliquet arcu."
                }
            };
        }
    }
}
