using System;
using MonoTouch.UIKit;
using SignaturePad;
using Cirrious.CrossCore;


namespace Acr.MvvmCross.Plugins.SignaturePad.Touch {

    public class SignatureViewController : UIViewController {
        private readonly PadConfiguration config;


        public SignatureViewController(PadConfiguration config) {
            this.config = config;
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();
            //Frame = UIScreen.MainScreen.ApplicationFrame;

            var btnSave = UIButton.FromType(UIButtonType.RoundedRect);
            btnSave.SetTitle(this.config.SaveText, UIControlState.Normal);
            btnSave.TouchUpInside += (sender, args) => {
            };

            var btnCancel = UIButton.FromType(UIButtonType.RoundedRect);
            btnCancel.SetTitle(this.config.CancelText, UIControlState.Normal);
            btnCancel.TouchUpInside += (sender, args) => {
//                if (points != null)
//                    Signature.LoadPoints (points);
            };
 
            var signature = new SignaturePadView {
//                BackgroundColor = this.config.BackgroundColor
//                SignatureLineColor = this.config.SignatureLineColor
//                StrokeColor = this.config.StrokeColor,
                StrokeWidth = this.config.StrokeWidth.Value
            };

            signature.Caption.Text = this.config.CaptionText;
            //            signature.Caption.TextColor = this.config.CaptionTextColor.ToIosColor();

            signature.SignaturePrompt.Text = this.config.PromptText;
            //            signature.SignaturePrompt.TextColor = this.config.PromptColor.

            this.Add(btnCancel);
            this.Add(btnSave);
            this.Add(signature);
//            if (new Version (MonoTouch.Constants.Version) >= new Version (7, 0)) {
//                UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
//            }

//                view.Signature.BackgroundImageView.ContentMode = UIViewContentMode.ScaleToFill;
//                view.Signature.BackgroundImageView.Frame = new System.Drawing.RectangleF (20, 20, 256, 256);
//                view.Signature.Layer.ShadowOffset = new System.Drawing.SizeF (0, 0);
//                view.Signature.Layer.ShadowOpacity = 1f;
        }
    }
}

/*
        public SignaturePadView Signature { get; set; }
        UIImageView imageView;
        UIButton btnSave, btnLoad;
        PointF [] points;

        public SignatureView()
        {


            //Create the save button




            Signature = new SignaturePadView ();
            //Using different layouts for the iPhone and iPad, so setup device specific requirements here.
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {

                //iPhone version simply saves the vector of points in an instance variable.
                btnSave.TouchUpInside += (sender, e) => {
                    if (Signature.IsBlank)
                        new UIAlertView ("", "No signature to save.", null, "Okay", null).Show ();
                    else {
                        points = Signature.Points;
                        new UIAlertView ("", "Vector Saved.", null, "Okay", null).Show ();
                    }
                };
            } else {

                //iPad version saves the vector of points as well as retrieving the UIImage to display
                //in a UIImageView.
                btnSave.TouchUpInside += (sender, e) => {
                    //if (signature.IsBlank)
                    //  new UIAlertView ("", "No signature to save.", null, "Okay", null).Show ();
                    imageView.Image = Signature.GetImage ();
                    points = Signature.Points;
                };

                //Create the UIImageView to display a saved signature.
                imageView = new UIImageView();
                AddSubview(imageView);
            }
            TranslatesAutoresizingMaskIntoConstraints = false;

            //Add the subviews.
            AddSubview (Signature);
            AddSubview (btnSave);
            AddSubview (btnLoad);
        }

        public override void LayoutSubviews ()
        {
            if (new Version(MonoTouch.Constants.Version) >= new Version (7, 0))
            {
                var frame = Frame;

                var width = UIApplication.SharedApplication.StatusBarOrientation.HasFlag(UIDeviceOrientation.Portrait)
                    ? frame.Size.Width
                    : frame.Size.Width - UIApplication.SharedApplication.StatusBarFrame.Width ;

                var height = UIApplication.SharedApplication.StatusBarOrientation.HasFlag (UIDeviceOrientation.Portrait)
                    ? frame.Size.Height - UIApplication.SharedApplication.StatusBarFrame.Height 
                    : frame.Size.Height;

                var x = UIApplication.SharedApplication.StatusBarOrientation.HasFlag (UIDeviceOrientation.Portrait)
                    ? 0
                    : frame.Location.X + UIApplication.SharedApplication.StatusBarFrame.Width;

                var y = UIApplication.SharedApplication.StatusBarOrientation.HasFlag (UIDeviceOrientation.Portrait)
                    ? frame.Location.Y + UIApplication.SharedApplication.StatusBarFrame.Height
                    : 0;

                Frame = new RectangleF (x, y, width, height);
            }

            ///Using different layouts for the iPhone and iPad, so setup device specific requirements here.
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
                Signature.Frame = new RectangleF (10, 10, Bounds.Width - 20, Bounds.Height - 60);
            else {
                Signature.Frame = new RectangleF (84, 84, Bounds.Width - 168, Bounds.Width / 2);
                imageView.Frame = new RectangleF (84, Signature.Frame.Height + 168,
                    Frame.Width - 168, Frame.Width / 2);
            }

            //Button locations are based on the Frame, so must have their own frames set after the view's
            //Frame has been set.
            btnSave.Frame = new RectangleF (10, Bounds.Height - 40, 120, 37);
            btnLoad.Frame = new RectangleF (Bounds.Width - 130, Bounds.Height - 40, 120, 37);
        }*/