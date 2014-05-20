using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleAndRotate
{
    public partial class ScaleDemoPage
    {
        public ScaleDemoPage()
        {
            InitializeComponent();

            // Set BindingContext properties manually.
            scaleSliderValue.BindingContext = scaleSlider;
            scaleSlider.BindingContext = label;

            anchorxStepperValue.BindingContext = anchorxStepper;
            anchorxStepper.BindingContext = label;

            anchoryStepperValue.BindingContext = anchoryStepper;
            anchoryStepper.BindingContext = label;
        }
    }
}
