using CardViewDemo.ViewModels;
using System.Collections.Generic;

namespace CardViewDemo.Services
{
    public static class DataService
    {
        static List<PersonViewModel> people = new List<PersonViewModel>
        {
            new PersonViewModel
            {
                Name = "Slavko Vlasic",
                Photo = "user.png",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla elit dolor, convallis non interdum."
            },
            new PersonViewModel
            {
                Name = "Carolina Pena",
                Photo = "user.png",
                Bio = "Phasellus eu convallis mi. In tempus augue eu dignissim fermentum. Morbi ut lacus vitae eros lacinia."
            },
            new PersonViewModel
            {
                Name = "Wade Blanks",
                Photo = "user.png",
                Bio = "Aliquam sagittis, odio lacinia fermentum dictum, mi erat scelerisque erat, quis aliquet arcu."
            },
            new PersonViewModel
            {
                Name = "Colette Quint",
                Photo = "user.png",
                Bio = "In pellentesque odio eget augue elementum lobortis. Sed augue massa, rhoncus eu nisi vitae, egestas."
            }
        };

        public static List<PersonViewModel> People
        {
            get
            {
                return people;
            }
        }
    }
}
