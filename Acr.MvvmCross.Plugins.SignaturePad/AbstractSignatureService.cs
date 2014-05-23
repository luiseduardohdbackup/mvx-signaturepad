using System;
using System.IO;
using Cirrious.CrossCore.UI;


namespace Acr.MvvmCross.Plugins.SignaturePad {

    public abstract class AbstractSignatureService : ISignatureService {

        protected AbstractSignatureService() {
            this.DefaultConfiguration = new PadConfiguration {
                BackgroundColor = MvxColors.White,
                SaveText = "Save",
                CancelText = "Cancel",
                CaptionText = "Please Sign Here"
            };
        }


        protected abstract void GetSignature(Action<Stream> onSave, Action onCancel, PadConfiguration cfg);


        public void RequestSignature(Action<Stream> onSave, Action onCancel, PadConfiguration cfg) {
            if (cfg == null)
                cfg = this.DefaultConfiguration;
            else {
                cfg.BackgroundColor = cfg.BackgroundColor ?? this.DefaultConfiguration.BackgroundColor;
                cfg.CancelText = cfg.CancelText ?? this.DefaultConfiguration.CancelText;
                cfg.CaptionText = cfg.CaptionText ?? this.DefaultConfiguration.CaptionText;
                cfg.CaptionTextColor = cfg.CaptionTextColor ?? this.DefaultConfiguration.CaptionTextColor;
                cfg.PromptColor = cfg.PromptColor ?? this.DefaultConfiguration.PromptColor;
                cfg.PromptText = cfg.PromptText ?? this.DefaultConfiguration.PromptText;
                cfg.SaveText = cfg.SaveText ?? this.DefaultConfiguration.SaveText;
                cfg.SignatureLineColor = cfg.SignatureLineColor ?? this.DefaultConfiguration.SignatureLineColor;
                cfg.StrokeColor = cfg.StrokeColor ?? this.DefaultConfiguration.StrokeColor;
                cfg.StrokeWidth = cfg.StrokeWidth ?? this.DefaultConfiguration.StrokeWidth;
            }
            this.RequestSignature(onSave, onCancel, cfg);
        }


        public PadConfiguration DefaultConfiguration { get; private set; }
    }
}

