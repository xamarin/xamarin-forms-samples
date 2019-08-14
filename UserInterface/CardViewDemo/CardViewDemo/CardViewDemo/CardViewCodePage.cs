using CardViewDemo.Controls;
using CardViewDemo.Services;
using CardViewDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace CardViewDemo
{
    public class CardViewCodePage : ContentPage
    {
        public CardViewCodePage()
        {
            Title = "CardView Code Demo";
            Padding = 10;

            StackLayout layout = new StackLayout();

            PersonCollectionViewModel personCollection = DataService.GetPersonCollection();
            foreach(var person in personCollection.Items)
            {
                CardView card = new CardView
                {
                    BorderColor = Color.DarkGray,
                    CardTitle = person.Name,
                    CardDescription = person.Bio,
                    IconBackgroundColor = Color.SlateGray,
                    IconImageSource = ImageSource.FromFile(person.Photo)
                };
                layout.Children.Add(card);
            }

            Content = layout;
        }
    }
}