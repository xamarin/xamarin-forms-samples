using CardViewDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardViewDemo.Services
{
    public static class DataService
    {
        static List<PersonViewModel> people = new List<PersonViewModel>
        {
            new PersonViewModel() {
                Name = "Slavko Vlasic",
                Photo = "user.png",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla elit dolor, convallis non interdum vitae, sagittis at eros. Nullam egestas pulvinar pharetra."
            },
            new PersonViewModel() {
                Name = "Carolina Pena",
                Photo = "user.png",
                Bio = "Phasellus eu convallis mi. In tempus augue eu dignissim fermentum. Morbi ut lacus vitae eros lacinia pharetra. Donec fringilla mi vel sapien scelerisque scelerisque."
            },
            new PersonViewModel() {
                Name = "Wade Blanks",
                Photo = "user.png",
                Bio = "Aliquam sagittis, odio lacinia fermentum dictum, mi erat scelerisque erat, quis aliquet arcu lectus nec ex. Sed interdum sodales arcu laoreet blandit."
            },
            new PersonViewModel() {
                Name = "Colette Quint",
                Photo = "user.png",
                Bio = "In pellentesque odio eget augue elementum lobortis. Sed augue massa, rhoncus eu nisi vitae, egestas lacinia libero. Vivamus finibus metus vel nibh sollicitudin ultrices."
            }
        };

        public static PersonCollectionViewModel GetPersonCollection()
        {
            return new PersonCollectionViewModel
            {
                Items = people
            };
        }
    }
}
