using System;
using Cirrious.CrossCore.UI;
using System.Threading.Tasks;


namespace Acr.MvvmCross.Plugins.SignaturePad {

    public abstract class AbstractSignatureService : ISignatureService {

        protected AbstractSignatureService() {
            this.DefaultConfiguration = new PadConfiguration {
                BackgroundColor = MvxColors.Black,
                CaptionTextColor = MvxColors.Black,
                PromptColor = MvxColors.White,
                StrokeColor = MvxColors.White,
                StrokeWidth = 2f,
                SignatureLineColor = MvxColors.Black,

                SaveText = "Save",
                CancelText = "Cancel",
                CaptionText = "Please Sign Here"
            };
        }


        protected abstract void GetSignature(Action<SignatureResult> onResult, PadConfiguration cfg);
//        public abstract void LoadSignature(params DrawPoint[] points);


        public virtual Task<SignatureResult> RequestSignatureAsync(PadConfiguration cfg) {
            var tcs = new TaskCompletionSource<SignatureResult>();
            this.RequestSignature(x => tcs.SetResult(x), cfg);
            return tcs.Task;
        }


        public virtual void RequestSignature(Action<SignatureResult> onResult, PadConfiguration cfg) {
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
            this.GetSignature(onResult, cfg);
        }


        public PadConfiguration DefaultConfiguration { get; private set; }
    }
}

