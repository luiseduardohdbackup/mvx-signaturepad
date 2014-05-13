using System;
using System.IO;
using SignaturePad;


namespace Acr.MvvmCross.Plugins.SignaturePad.Touch {
    
    public class TouchSignatureService : ISignatureService {

        public PadConfiguration DefaultConfiguration { get; set; }

        public void RequestSignature(Action<Stream> onSigned, Action cancelAction = null, PadConfiguration configuration = null) {
            var signature = new SignaturePadView();
                //StrokeColor = Co
                //SignatureLineColor = 
            //signature.SignatureLineColor = Color
            //signature.BackgroundColor
            //signature.StrokeColor
            //signature.StrokeWidth
            //signature.Caption.Text
            //signature.Caption.CurrentTextColor
            //signature.SignaturePrompt.Text
            //signature.SignaturePrompt.CurrentTextColor

            // save text
            // cancel text (if available)
            using (var image = signature.GetImage()) {
                // TODO: to stream
            }
        }
    }
}