using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace AnimationSampler
{
    class HomePage : ContentPage
    {
        public HomePage()
        {
            Command<Type> navigateCommands = new Command<Type>(
                (Type pageType) =>
                {
                    IEnumerable<ConstructorInfo> constructors = 
                            pageType.GetTypeInfo().DeclaredConstructors;

                    foreach (ConstructorInfo constructor in constructors)
                    {
                        if (constructor.GetParameters().Length == 0)
                        {
                            Page page = (Page)constructor.Invoke(null);
                            this.Navigation.PushAsync(page);
                            break;
                        }
                    }
                });

            this.Content = new TableView
                {
                    Intent = TableIntent.Menu,
                    Root = new TableRoot
                    {
                        new TableSection("Animation Demos")
                        {
                            new TextCell
                            {
                                Text = "Spinning Text",
                                Command = navigateCommands,
                                CommandParameter = typeof(SpinningTextAnimationPage)
                            },

                            new TextCell
                            {
                                Text = "Fading Text",
                                Command = navigateCommands,
                                CommandParameter = typeof(FadingTextAnimationPage)
                            },

                            new TextCell
                            {
                                Text = "Palindrome",
                                Command = navigateCommands,
                                CommandParameter = typeof(PalindromeAnimationPage)
                            },

                            new TextCell
                            {
                                Text = "Rainbow",
                                Command = navigateCommands,
                                CommandParameter = typeof(RainbowAnimationPage)
                            },
                        }
                    }
                };
        }
    }
}
