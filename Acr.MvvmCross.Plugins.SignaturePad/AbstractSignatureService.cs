using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cirrious.CrossCore.UI;


namespace Acr.MvvmCross.Plugins.SignaturePad {

    public abstract class AbstractSignatureService : ISignatureService {

        protected AbstractSignatureService() {
            this.DefaultConfiguration = new SignaturePadConfiguration {
                ImageType = ImageFormatType.Png,
                BackgroundColor = MvxColors.GhostWhite,
                CaptionTextColor = MvxColors.Black,
                ClearTextColor = MvxColors.Black,
                PromptColor = MvxColors.White,
                StrokeColor = MvxColors.Black,
                StrokeWidth = 2f,
                SignatureLineColor = MvxColors.Black,

                SaveText = "Save",
                CancelText = "Cancel",
                ClearText = "Clear",
                PromptText = "",
                CaptionText = "Please Sign Here"
            };
        }


        protected abstract void GetSignature(Action<SignatureResult> onResult, SignaturePadConfiguration cfg);
        protected abstract void Load(IEnumerable<DrawPoint> points, SignaturePadConfiguration cfg);

        protected virtual void SetConfiguratuion(SignaturePadConfiguration cfg) {
            if (cfg == null)
                cfg = this.DefaultConfiguration;
            else {
                cfg.BackgroundColor = cfg.BackgroundColor ?? this.DefaultConfiguration.BackgroundColor;
                cfg.CancelText = cfg.CancelText ?? this.DefaultConfiguration.CancelText;
                cfg.CaptionText = cfg.CaptionText ?? this.DefaultConfiguration.CaptionText;
                cfg.CaptionTextColor = cfg.CaptionTextColor ?? this.DefaultConfiguration.CaptionTextColor;
                cfg.ClearText = cfg.ClearText ?? this.DefaultConfiguration.ClearText;
                cfg.ClearTextColor = cfg.ClearTextColor ?? this.DefaultConfiguration.ClearTextColor;
                cfg.PromptColor = cfg.PromptColor ?? this.DefaultConfiguration.PromptColor;
                cfg.PromptText = cfg.PromptText ?? this.DefaultConfiguration.PromptText;
                cfg.SaveText = cfg.SaveText ?? this.DefaultConfiguration.SaveText;
                cfg.SignatureLineColor = cfg.SignatureLineColor ?? this.DefaultConfiguration.SignatureLineColor;
                cfg.StrokeColor = cfg.StrokeColor ?? this.DefaultConfiguration.StrokeColor;
                cfg.StrokeWidth = cfg.StrokeWidth ?? this.DefaultConfiguration.StrokeWidth;
            }        
        }


        public virtual void LoadSignature(IEnumerable<DrawPoint> points, SignaturePadConfiguration cfg) {
            this.SetConfiguratuion(cfg);
            this.Load(points, cfg);
        }


        public virtual Task<SignatureResult> RequestSignatureAsync(SignaturePadConfiguration cfg) {
            var tcs = new TaskCompletionSource<SignatureResult>();
            this.RequestSignature(x => tcs.SetResult(x), cfg);
            return tcs.Task;
        }


        public virtual void RequestSignature(Action<SignatureResult> onResult, SignaturePadConfiguration cfg) {
            this.SetConfiguratuion(cfg);
            this.GetSignature(onResult, cfg);
        }
        
        
        public SignaturePadConfiguration DefaultConfiguration { get; private set; }
    }
}

