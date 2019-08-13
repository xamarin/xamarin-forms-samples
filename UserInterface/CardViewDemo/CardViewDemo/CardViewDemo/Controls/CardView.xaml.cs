using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CardViewDemo.Controls
{
    public partial class CardView : ContentView
    {
        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create("CardTitle", typeof(string), typeof(CardView), string.Empty);

        public string CardTitle
        {
            get => (string)GetValue(CardView.CardTitleProperty);
            set => SetValue(CardView.CardTitleProperty, value);
        }

        public CardView()
        {
            InitializeComponent();
        }
    }
}