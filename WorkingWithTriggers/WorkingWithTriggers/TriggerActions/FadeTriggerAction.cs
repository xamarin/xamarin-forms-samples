using Xamarin.Forms;

namespace WorkingWithTriggers
{
    public class FadeTriggerAction : TriggerAction<VisualElement>
    {
        public int StartsFrom { set; get; }

        protected override void Invoke(VisualElement sender)
        {
            sender.Animate("FadeTriggerAction", new Animation((d) =>
            {
                var val = StartsFrom == 1 ? d : 1 - d;
                // so i was aiming for a different color, but then i liked the pink :)
                sender.BackgroundColor = Color.FromRgb(1, val, 1);
            }),
            length: 1000, // milliseconds
            easing: Easing.Linear);
        }
    }
}