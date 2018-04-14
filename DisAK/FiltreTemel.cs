using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Drawing;

namespace DisAK
{
    
    class FiltreTemel
    {
        Stopwatch timer=new Stopwatch();
        Rectangle element;
        
        
        
        public FiltreTemel(){}
        public void besle(Rectangle giris,double fps)
        {

            if (element == null)
            {
                element = giris;
            }
            else
            {
                int factor = (int)(fps*0.5);
                element.X += (giris.X - element.X) / factor;
                element.Y += (giris.Y - element.Y) / factor;
                element.Width += (giris.Width - element.Width) / factor;
                element.Height += (giris.Height - element.Height) / factor;

            }
            
        }
        public Rectangle al(int Width,int Height)
        {
            element.X = Math.Max(1, element.X);
            element.Y = Math.Max(1, element.Y);
            element.Width = Math.Min(Width - element.X - 1, element.Width);
            element.Height = Math.Min(Height - element.Y - 1, element.Height);


            return this.element;
        }
        
    }
}
