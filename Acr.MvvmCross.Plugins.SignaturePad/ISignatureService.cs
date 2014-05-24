using System;
using System.IO;
using System.Threading.Tasks;


namespace Acr.MvvmCross.Plugins.SignaturePad {
    
    public interface ISignatureService {

        PadConfiguration DefaultConfiguration { get; }
        Task<SignatureResult> RequestSignatureAsync(PadConfiguration cfg = null);
        void RequestSignature(Action<SignatureResult> onAction, PadConfiguration cfg = null);
//        void LoadSignature(params DrawPoint[] points);
    }
}
