using Xamarin.Forms;

namespace RelativeLayoutDemos.Views
{
    public class RelativePositioningAndSizingDemoPageCS : ContentPage
    {
        public RelativePositioningAndSizingDemoPageCS()
        {
            RelativeLayout relativeLayout = new RelativeLayout();

            // Four BoxView's
            relativeLayout.Children.Add(
                new BoxView { Color = Color.Red },
                Constraint.Constant(0),
                Constraint.Constant(0));

            relativeLayout.Children.Add(
                new BoxView { Color = Color.Green },
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width - 40;
                }), Constraint.Constant(0));

            relativeLayout.Children.Add(
                new BoxView { Color = Color.Blue },
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height - 40;
                }));

            relativeLayout.Children.Add(
                new BoxView { Color = Color.Yellow },
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width - 40;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height - 40;
                }));

            // Centered and 1/3 width and height of parent
            BoxView silverBoxView = new BoxView { Color = Color.Silver };
            relativeLayout.Children.Add(
                silverBoxView,
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * 0.33;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * 0.33;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * 0.33;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * 0.33;
                }));

            // 1/3 width and height of previous
            relativeLayout.Children.Add(
                new BoxView { Color = Color.Black },
                Constraint.RelativeToView(silverBoxView, (parent, sibling) =>
                {
                    return sibling.X;
                }),
                Constraint.RelativeToView(silverBoxView, (parent, sibling) =>
                {
                    return sibling.Y;
                }),
                Constraint.RelativeToView(silverBoxView, (parent, sibling) =>
                {
                    return sibling.Width * 0.33;
                }),
                Constraint.RelativeToView(silverBoxView, (parent, sibling) =>
                {
                    return sibling.Height * 0.33;
                }));

            Title = "RelativeLayout demo";
            Content = relativeLayout;
        }
    }
}
