using System;


namespace Acr.MvvmCross.Plugins.SignaturePad {
   
    public class DrawPoint {

        public bool IsEmpty { get; private set; }
        public float X { get; private set; }
        public float Y { get; private set; }


        public DrawPoint(float x, float y, bool empty) {
            this.X = x;
            this.Y = y;
            this.IsEmpty = empty;
        }
    }
}
