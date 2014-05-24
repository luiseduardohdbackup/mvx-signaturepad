using System;
using System.Linq;
using System.Drawing;
using MonoTouch.UIKit;
using SignaturePad;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Color.Touch;




namespace Acr.MvvmCross.Plugins.SignaturePad.Touch {

    public class MvxSignatureController : UIViewController {

        private MvxSignatureView view;

        private readonly Action<SignatureResult> onResult;
        private readonly PadConfiguration config;


        public MvxSignatureController(PadConfiguration config, Action<SignatureResult> onResult) {
            this.config = config;
            this.onResult = onResult;
        }


        public override void LoadView() {
            base.LoadView();

            this.view = new MvxSignatureView();
            this.View = this.view;
        }


        public void LoadSignature(params PointF[] points) {
            this.view.Signature.LoadPoints(points);
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();

//            if (new Version (MonoTouch.Constants.Version) >= new Version (7, 0)) 
//                UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

            this.view.Signature.BackgroundColor = this.config.BackgroundColor.ToNativeColor();
            this.view.Signature.SignatureLineColor = this.config.SignatureLineColor.ToNativeColor();
            this.view.Signature.StrokeColor = this.config.StrokeColor.ToNativeColor();
            this.view.Signature.StrokeWidth = this.config.StrokeWidth.Value;
            this.view.Signature.Caption.TextColor = this.config.CaptionTextColor.ToNativeColor();
            this.view.Signature.Caption.Text = this.config.CaptionText;
            this.view.Signature.SignaturePrompt.Text = this.config.PromptText;
            this.view.Signature.SignaturePrompt.TextColor = this.config.PromptColor.ToNativeColor();

            // set the buttons
            this.view.SaveButton.SetTitle(this.config.SaveText, UIControlState.Normal);
            this.view.CancelButton.SetTitle(this.config.CancelText, UIControlState.Normal);

            this.view.SaveButton.TouchUpInside += (sender, args) => {
                if (this.view.Signature.IsBlank)
                    return;

                var points = this.view
                    .Signature
                    .Points
                    .Select(x => new DrawPoint(x.X, x.Y, x.IsEmpty));

                using (var image = this.view.Signature.GetImage()) {
                    using (var stream = image.AsJPEG().AsStream()) {
                        this.DismissViewController(true, null);
                        this.onResult(new SignatureResult(false, stream, points));
                    }
                }
            };

            this.view.CancelButton.TouchUpInside += (sender, args) => {
                this.DismissViewController(true, null);
                this.onResult(new SignatureResult(true, null, null));
            };
            //            FROM XAMARIN SAMPLES
//            this.view.Signature.Caption.Font = UIFont.FromName ("Marker Felt", 16f);
//            this.view.Signature.SignaturePrompt.Font = UIFont.FromName ("Helvetica", 32f);
//            this.view.Signature.BackgroundColor = UIColor.FromRGB (255, 255, 200); // a light yellow.
//            this.view.Signature.BackgroundImageView.Image = UIImage.FromBundle ("logo-galaxy-black-64.png");
//            this.view.Signature.BackgroundImageView.Alpha = 0.0625f;
//            this.view.Signature.BackgroundImageView.ContentMode = UIViewContentMode.ScaleToFill;
//            this.view.Signature.BackgroundImageView.Frame = new System.Drawing.RectangleF(20, 20, 256, 256);

            this.view.Signature.Layer.ShadowOffset = new System.Drawing.SizeF (0, 0);
            this.view.Signature.Layer.ShadowOpacity = 1f;
        }
    }
}


