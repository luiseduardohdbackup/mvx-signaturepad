﻿using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.UIKit;
using SignaturePad;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Color.Touch;
using MonoTouch.Foundation;


namespace Acr.MvvmCross.Plugins.SignaturePad.Touch {

    public class MvxSignatureController : UIViewController {

        private MvxSignatureView view;

        private IEnumerable<DrawPoint> points;
        private Action<SignatureResult> onResult;
        private readonly SignaturePadConfiguration config;


        public MvxSignatureController(SignaturePadConfiguration config, Action<SignatureResult> onResult) {
            this.config = config;
            this.onResult = onResult;
        }


        public MvxSignatureController(SignaturePadConfiguration config, IEnumerable<DrawPoint> points) {
            this.config = config;
            this.points = points;
        }


        public override void LoadView() {
            base.LoadView();

            this.view = new MvxSignatureView();
            this.View = this.view;
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            this.view.BackgroundColor = this.config.BackgroundColor.ToNativeColor();
            this.view.Signature.BackgroundColor = this.config.SignatureBackgroundColor.ToNativeColor();
            this.view.Signature.Caption.TextColor = this.config.CaptionTextColor.ToNativeColor();
            this.view.Signature.Caption.Text = this.config.CaptionText;
            this.view.Signature.ClearLabel.SetTitle(this.config.ClearText, UIControlState.Normal);
            this.view.Signature.ClearLabel.SetTitleColor(this.config.ClearTextColor.ToNativeColor(), UIControlState.Normal);
            this.view.Signature.SignatureLineColor = this.config.SignatureLineColor.ToNativeColor();
            this.view.Signature.SignaturePrompt.Text = this.config.PromptText;
            this.view.Signature.SignaturePrompt.TextColor = this.config.PromptTextColor.ToNativeColor();
            this.view.Signature.StrokeColor = this.config.StrokeColor.ToNativeColor();
            this.view.Signature.StrokeWidth = this.config.StrokeWidth;
            this.view.Signature.Layer.ShadowOffset = new SizeF(0, 0);
            this.view.Signature.Layer.ShadowOpacity = 1f;

            if (this.onResult == null) {
                this.view.CancelButton.Hidden = true;
                this.view.SaveButton.Hidden = true;
                this.view.Signature.ClearLabel.Hidden = true;
                this.view.Signature.LoadPoints(this.points.Select(x => new PointF { X = x.X, Y = x.Y }).ToArray());
            }
            else {
                this.view.SaveButton.SetTitle(this.config.SaveText, UIControlState.Normal);
                this.view.SaveButton.TouchUpInside += (sender, args) => {
                    if (this.view.Signature.IsBlank)
                        return;

                    var points = this.view
                        .Signature
                        .Points
                        .Select(x => new DrawPoint(x.X, x.Y));

                    using (var image = this.view.Signature.GetImage()) {
                        using (var stream = GetImageStream(image, this.config.ImageType)) {
                            this.DismissViewController(true, null);
                            this.onResult(new SignatureResult(false, stream, points));
                        }
                    }
                };

                this.view.CancelButton.SetTitle(this.config.CancelText, UIControlState.Normal);
                this.view.CancelButton.TouchUpInside += (sender, args) => {
                    this.DismissViewController(true, null);
                    this.onResult(new SignatureResult(true, null, null));
                };
            }
        }


        public void LoadSignature(params PointF[] points) {
            this.view.Signature.LoadPoints(points);
        }


//        public override void TouchesBegan(NSSet touches, UIEvent evt) {
//            base.TouchesBegan(touches, evt);
//            if (this.onResult == null)
//                this.DismissViewController(true, null);
//        }


        private static Stream GetImageStream(UIImage image, ImageFormatType formatType) {
            if (formatType == ImageFormatType.Jpg)
                return image.AsJPEG().AsStream();

            return image.AsPNG().AsStream();
        }
    }
}


//            FROM XAMARIN SAMPLES
//            this.view.Signature.Caption.Font = UIFont.FromName ("Marker Felt", 16f);
//            this.view.Signature.SignaturePrompt.Font = UIFont.FromName ("Helvetica", 32f);
//            this.view.Signature.BackgroundColor = UIColor.FromRGB (255, 255, 200); // a light yellow.
//            this.view.Signature.BackgroundImageView.Image = UIImage.FromBundle ("logo-galaxy-black-64.png");
//            this.view.Signature.BackgroundImageView.Alpha = 0.0625f;
//            this.view.Signature.BackgroundImageView.ContentMode = UIViewContentMode.ScaleToFill;
//            this.view.Signature.BackgroundImageView.Frame = new System.Drawing.RectangleF(20, 20, 256, 256);