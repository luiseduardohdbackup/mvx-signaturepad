using System;
using System.IO;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using Cirrious.MvvmCross.Plugins.Color.Droid;
using SignaturePad;


namespace Acr.MvvmCross.Plugins.SignaturePad.Droid {
    
    public class DroidSignatureService : ISignatureService {
        public PadConfiguration DefaultConfiguration { get; set; }



        public void RequestSignature(Action<Stream> onSigned, Action cancelAction, PadConfiguration configuration = null) {
            var cfg = (configuration ?? this.DefaultConfiguration);

            var globals = Mvx.Resolve<IMvxAndroidGlobals>();
            var signature = new SignaturePadView(globals.ApplicationContext); // TODO: activity context

            // TODO: use defaults for unset passed config
            if (cfg.BackgroundColor != null)
                signature.BackgroundColor = cfg.BackgroundColor.ToAndroidColor();

            if (cfg.SignatureLineColor != null)
                signature.SignatureLineColor = cfg.SignatureLineColor.ToAndroidColor();

            if (cfg.StrokeColor != null)
                signature.StrokeColor = cfg.StrokeColor.ToAndroidColor();

            if (cfg.CaptionTextColor != null)
                signature.Caption.SetTextColor(cfg.CaptionTextColor.ToAndroidColor());

            if (cfg.StrokeWidth != null)
                signature.StrokeWidth = cfg.StrokeWidth.Value;

            if (cfg.PromptColor != null)
                signature.SignaturePrompt.SetTextColor(cfg.PromptColor.ToAndroidColor());

            if (!String.IsNullOrWhiteSpace(cfg.CaptionText))
                signature.Caption.Text = cfg.CaptionText;

            if (!String.IsNullOrWhiteSpace(cfg.PromptText))
                signature.SignaturePrompt.Text = cfg.PromptText;

            // save text
            // cancel text (if available)
            using (var image = signature.GetImage()) {
                // TODO: to stream
            }
        }
    }
}