using System;
using System.Collections.Generic;
using System.IO;


namespace Acr.MvvmCross.Plugins.SignaturePad {
    
    public class SignatureResult {

        public Stream Stream { get; private set; }
        public IEnumerable<DrawPoint> Points { get; private set; }
        //public bool IsBlank


        public SignatureResult(Stream stream, IEnumerable<DrawPoint> points) {
            this.Stream = stream;
            this.Points = points;
        }
    }
}
