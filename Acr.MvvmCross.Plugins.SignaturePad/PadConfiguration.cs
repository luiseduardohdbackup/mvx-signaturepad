using System;
using Cirrious.CrossCore.UI;


namespace Acr.MvvmCross.Plugins.SignaturePad {
    
    public class PadConfiguration {

        public string SaveText { get; set; }
        public string CancelText { get; set; }

        public MvxColor BackgroundColor { get; set; }
        public MvxColor SignatureLineColor { get; set; }
        
        public string CaptionText { get; set; }
        public MvxColor CaptionTextColor { get; set; }

        public string PromptText { get; set; }
        public MvxColor PromptColor { get; set; }

        public float? StrokeWidth { get; set; }
        public MvxColor StrokeColor { get; set; }


        public PadConfiguration() {
            this.SaveText = "Save";
            this.CancelText = "Cancel";
            this.CaptionText = "Please Sign Here";
        }
    }
}
