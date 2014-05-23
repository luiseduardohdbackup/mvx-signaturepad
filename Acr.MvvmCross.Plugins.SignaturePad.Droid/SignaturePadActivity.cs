using System;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Plugins.Color.Droid;
using SignaturePad;
using System.IO;


namespace Acr.MvvmCross.Plugins.SignaturePad.Droid {

    [Activity]
    public class SignaturePadActivity : Activity {
        private SignaturePadView signatureView;
        private Button btnSave;
        private Button btnCancel;


        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.SignaturePad);

            this.signatureView = this.FindViewById<SignaturePadView>(Resource.Id.signatureView);
            this.btnSave = this.FindViewById<Button>(Resource.Id.btnSave);
            this.btnCancel = this.FindViewById<Button>(Resource.Id.btnCancel);

            var cfg = DroidSignatureService.CurrentConfig;
            this.signatureView.BackgroundColor = cfg.BackgroundColor.ToAndroidColor();
            this.signatureView.SignatureLineColor = cfg.SignatureLineColor.ToAndroidColor();
            this.signatureView.StrokeColor = cfg.StrokeColor.ToAndroidColor();
            this.signatureView.StrokeWidth = cfg.StrokeWidth.Value;
            this.signatureView.SignaturePrompt.Text = cfg.PromptText;
            this.signatureView.SignaturePrompt.SetTextColor(cfg.PromptColor.ToAndroidColor());
            this.signatureView.Caption.Text = cfg.CaptionText;
            this.signatureView.Caption.SetTextColor(cfg.CaptionTextColor.ToAndroidColor());

            this.btnSave.Text = cfg.SaveText;
            this.btnCancel.Text = cfg.CancelText;
        }


        protected override void OnResume() {
            base.OnResume();
            this.btnSave.Click += this.OnSave;
            this.btnCancel.Click += this.OnCancel;
        }


        protected override void OnPause() {
            base.OnPause();
            this.btnSave.Click -= this.OnSave;
            this.btnCancel.Click -= this.OnCancel;
        }


        private void OnSave(object sender, EventArgs args) {
            if (this.signatureView.IsBlank)
                return;

            using (var image = this.signatureView.GetImage()) {
                var points = this.signatureView
                    .Points
                    .Select(x => new DrawPoint(x.X, x.Y, x.IsEmpty));

                using (var stream = new MemoryStream()) {
                    image.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);
                    DroidSignatureService.OnSave(new SignatureResult(stream, points));
                    this.Finish();
                }
            }
        }


        private void OnCancel(object sender, EventArgs args) {
            DroidSignatureService.OnCancel();
        }
    }
}

