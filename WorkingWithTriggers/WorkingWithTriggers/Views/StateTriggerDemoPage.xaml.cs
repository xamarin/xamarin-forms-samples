using System;
using Xamarin.Forms;

namespace WorkingWithTriggers
{
    public partial class StateTriggerDemoPage : ContentPage
    {
        public StateTriggerDemoPage()
        {
            InitializeComponent();
        }

        void OnCheckedStateIsActiveChanged(object sender, EventArgs e)
        {
            StateTriggerBase stateTrigger = sender as StateTriggerBase;
            Console.WriteLine($"Checked state active: {stateTrigger.IsActive}");
        }

        void OnUncheckedStateIsActiveChanged(object sender, EventArgs e)
        {
            StateTriggerBase stateTrigger = sender as StateTriggerBase;
            Console.WriteLine($"Unchecked state active: {stateTrigger.IsActive}");
        }
    }
}
