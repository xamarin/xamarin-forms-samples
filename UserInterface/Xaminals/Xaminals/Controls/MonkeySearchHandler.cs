using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xaminals.Data;
using Xaminals.Models;

namespace Xaminals.Controls
{
    public class MonkeySearchHandler : SearchHandler
    {
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = MonkeyData.Monkeys
                    .Where(monkey => monkey.Name.ToLower().Contains(newValue.ToLower()))
                    .ToList<Animal>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await Task.Delay(1000);
            // Note: strings will be URL encoded for navigation (e.g. "Blue Monkey" becomes "Blue%20Monkey"). Therefore, decode at the receiver.
            await Shell.Current.GoToAsync($"app://xamarin.com/xaminals/animals/monkeys/monkeydetails?name={((Animal)item).Name}");
        }
    }
}
