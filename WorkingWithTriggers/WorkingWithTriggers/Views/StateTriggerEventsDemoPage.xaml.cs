using System;
using Xamarin.Forms;

namespace WorkingWithTriggers
{
    public partial class StateTriggerEventsDemoPage : ContentPage
    {
        public StateTriggerEventsDemoPage()
        {
            InitializeComponent();
        }

        void OnCheckedStateIsActiveChanged(object sender, EventArgs e)
        {
            StateTriggerBase stateTrigger = sender as StateTriggerBase;
            Console.WriteLine($"Is Checked state active: {stateTrigger.IsActive}");
        }

        void OnUncheckedStateIsActiveChanged(object sender, EventArgs e)
        {
            StateTriggerBase stateTrigger = sender as StateTriggerBase;
            Console.WriteLine($"Is Unchecked state active: {stateTrigger.IsActive}");
        }
    }
}
