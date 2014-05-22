using System;

namespace XamlScaleAndRotate
{
    public partial class RotationDemoPage
    {
        public RotationDemoPage()
        {
            InitializeComponent();

            // Set BindingContext properties "manually."
            rotationSliderValue.BindingContext = rotationSlider;
            rotationSlider.BindingContext = label;

            anchorxStepperValue.BindingContext = anchorxStepper;
            anchorxStepper.BindingContext = label;

            anchoryStepperValue.BindingContext = anchoryStepper;
            anchoryStepper.BindingContext = label;
        }
    }
}
