using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace DisAK
{
    class Imlec
    {
        Rectangle bounds = Screen.PrimaryScreen.Bounds;
      
        
        bool ilk = false;
        bool aktif = false;
        float yaw=0,pitch=0;
        PointF point = new PointF(0, 0);//
        Point delta = new Point(0, 0);
        Point position = new Point(32767, 32767);
        Point positionex = new Point(32767, 32767);
        FiltreTemel filtre = new FiltreTemel();
        int hiz = 0;
        float fps = 0.1f;
        float _hiz = 0;
        public Imlec() { 
        
        }
        public float Hiz
        {
            set
            {
                this._hiz = value;
            }
            get
            {
                return this._hiz;
            }
        }





        public void feed(float yaw,float pitch,float fps){
            this.yaw = yaw;
            this.pitch = pitch;
            this.fps = fps;

        }
        public void calistir(bool control)
        {
            point.X = Math.Max(Math.Min (50+ (-yaw * 1.3333333f),100.0f),0);
            point.Y = Math.Max(Math.Min(50+(pitch * 2.66666666f), 100.0f), 0);

            kontrol((int)((point.X/100.0f)*65535), (int)((point.Y/100.0f)*65535));
            

        }
        private void kontrol(int X,int Y)
        {
            Fare.GitEx(position.X, position.Y);

            /*if (X > position.X)
            {
                position.X += (int)Math.Pow(Math.E, Math.Abs(X - position.X)*3000);
            }
            else
            {
                position.X -= (int)Math.Pow(Math.E, Math.Abs(X - position.X)*3000);
            }
            if (Y > position.Y)
            {
                position.Y += (int)Math.Pow(Math.E, Math.Abs(Y - position.Y)*3000);
                
            }
            else
            {
                position.Y -= (int)Math.Pow(Math.E, Math.Abs(Y - position.Y)*3000);
            }
            */
            double xcomp = fps*0.8f;
            double ycomp = fps*0.8f;

            int deltaX = (int)((X - position.X) / xcomp);
            int deltaY = (int)((Y - position.Y) / ycomp);
            Hiz = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            

            position.X += deltaX;
            position.Y += deltaY;

        }
       
    }
}
