using System;
using System.Collections.Generic;
using System.IO;


namespace Acr.MvvmCross.Plugins.SignaturePad {
    
    public class SignatureResult {

        public bool Cancelled { get; private set; }
        public Stream Stream { get; private set; }
        public IEnumerable<DrawPoint> Points { get; private set; }
        //public bool IsBlank


        public SignatureResult(bool cancelled, Stream stream, IEnumerable<DrawPoint> points) {
            this.Cancelled = true;
            this.Stream = stream;
            this.Points = points;
        }
    }
}
