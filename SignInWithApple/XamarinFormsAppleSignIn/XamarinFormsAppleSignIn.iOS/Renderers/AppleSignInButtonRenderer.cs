using System;
using AuthenticationServices;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(XamarinFormsAppleSignIn.AppleSignInButton), typeof(XamarinFormsAppleSignIn.iOS.Renderers.AppleSignInButtonRenderer))]

namespace XamarinFormsAppleSignIn.iOS.Renderers
{
    public class AppleSignInButtonRenderer : ViewRenderer<AppleSignInButton, UIView>
    {
        public static ASAuthorizationAppleIdButtonType ButtonType { get; set; } = ASAuthorizationAppleIdButtonType.Default;

        bool Is13 => UIDevice.CurrentDevice.CheckSystemVersion(13, 0);

        ASAuthorizationAppleIdButton button;
        UIButton oldButton;

        protected override void OnElementChanged(ElementChangedEventArgs<AppleSignInButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Cleanup
                if (Is13)
                {
                    if (button != null)
                        button.TouchUpInside -= Button_TouchUpInside;
                }
                else
                {
                    if (oldButton != null)
                        oldButton.TouchUpInside -= Button_TouchUpInside;
                }
            }

            if (e.NewElement != null)
            {
                // Create
                if (Is13)
                {
                    if (button == null)
                    {
                        button = (ASAuthorizationAppleIdButton)CreateNativeControl();
                        button.TouchUpInside += Button_TouchUpInside;

                        SetNativeControl(button);
                    }
                }
                else
                {
                    if (oldButton == null)
                    {
                        oldButton = (UIButton)CreateNativeControl();
                        oldButton.TouchUpInside += Button_TouchUpInside;
                        oldButton.Layer.CornerRadius = 4;
                        oldButton.Layer.BorderWidth = 1;
                        oldButton.ClipsToBounds = true;
                        oldButton.SetTitle(" " + Element.Text, UIControlState.Normal);

                        switch (Element.ButtonStyle)
                        {
                            case AppleSignInButtonStyle.Black:
                                oldButton.BackgroundColor = UIColor.Black;
                                oldButton.SetTitleColor(UIColor.White, UIControlState.Normal);
                                oldButton.Layer.BorderColor = UIColor.Black.CGColor;
                                break;
                            case AppleSignInButtonStyle.White:
                                oldButton.BackgroundColor = UIColor.White;
                                oldButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
                                oldButton.Layer.BorderColor = UIColor.White.CGColor;
                                break;
                            case AppleSignInButtonStyle.WhiteOutline:
                                oldButton.BackgroundColor = UIColor.White;
                                oldButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
                                oldButton.Layer.BorderColor = UIColor.Black.CGColor;
                                break;
                        }

                        SetNativeControl(oldButton);
                    }
                }
            }
        }

        protected override UIView CreateNativeControl()
        {
            if (!Is13)
                return new UIButton(UIButtonType.Plain);
            else
                return new ASAuthorizationAppleIdButton(ButtonType, GetButtonStyle());
        }

        ASAuthorizationAppleIdButtonStyle GetButtonStyle()
        {
            switch (Element.ButtonStyle)
            {
                case AppleSignInButtonStyle.Black:
                    return ASAuthorizationAppleIdButtonStyle.Black;
                case AppleSignInButtonStyle.White:
                    return ASAuthorizationAppleIdButtonStyle.White;
                case AppleSignInButtonStyle.WhiteOutline:
                    return ASAuthorizationAppleIdButtonStyle.WhiteOutline;
            }

            return ASAuthorizationAppleIdButtonStyle.Black;
        }

        void Button_TouchUpInside(object sender, EventArgs e)
            => Element.InvokeSignInEvent(sender, e);
    }
}
