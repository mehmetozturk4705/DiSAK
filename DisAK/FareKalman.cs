using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Features2D;
using Emgu.CV.ML;
using System.Collections;
using System.Diagnostics;
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;


namespace DisAK
{
    class FareKalman
    {
        public Stopwatch timer = new Stopwatch();
        public KalmanFilter kf = new KalmanFilter(6, 4, 0);
        public Mat state = new Mat(6, 1, DepthType.Cv32F, 1);
        public Mat meas = new Mat(4, 1, DepthType.Cv32F, 1);
        bool found = false;
        
        double dT;
        double prev;
        double now=0d;
        int notfoundcount = 0;


        Rectangle sonuc = new Rectangle();
        public double yuzhizi
        {
            get
            {
               return Math.Sqrt(Math.Pow(at(state, 2), 2) + Math.Pow(at(state, 3), 2));
            }

        }
        
        public FareKalman(){


            CvInvoke.SetIdentity(kf.TransitionMatrix, new MCvScalar(1.0f));
            at(kf.MeasurementMatrix, 0, 1.0f);
            at(kf.MeasurementMatrix, 7, 1.0f);
            at(kf.MeasurementMatrix, 16, 1.0f);
            at(kf.MeasurementMatrix, 23, 1.0f);

            at(kf.ProcessNoiseCov, 0, 1e-2f);
            at(kf.ProcessNoiseCov, 7, 1e-2f);
            at(kf.ProcessNoiseCov, 14, 2.0f);
            at(kf.ProcessNoiseCov, 21, 1.0f);
            at(kf.ProcessNoiseCov, 28, 1e-2f);
            at(kf.ProcessNoiseCov, 35, 1e-2f);

            CvInvoke.SetIdentity(kf.MeasurementNoiseCov, new MCvScalar(1e-1f));


        
        }
        public void step(Rectangle[] yuzler)
        {
            prev = now;
            now = timer.ElapsedMilliseconds;
            dT = (now - prev) / 400;
            if (found)
            {
                at(kf.TransitionMatrix, 2, (float)dT);
                at(kf.TransitionMatrix, 9, (float)dT);

                state = kf.Predict();

                sonuc.Width = (int)at(state, 4);
                sonuc.Height = (int)at(state, 5);
                sonuc.X = (int)at(state, 0) - sonuc.Width / 2;
                sonuc.Y = (int)at(state, 1) - sonuc.Height / 2;

            }

            if (yuzler.Length == 0)
            {
                notfoundcount++;
                if (notfoundcount >= 25)
                {
                    found = false;
                }
                else
                    for (int i = 0; i < 6; i++)
                        at(kf.StatePost, i, at(state, i));
            }
            else
            {
                notfoundcount = 0;

                at(meas, 0, yuzler[0].X + yuzler[0].Width / 2);
                at(meas, 1, yuzler[0].Y + yuzler[0].Height / 2);
                at(meas, 2, (float)yuzler[0].Width);
                at(meas, 3, (float)yuzler[0].Width);

                if (!found)///ilk tanıma olayı
                {
                    at(kf.ErrorCovPre, 0, 1f);
                    at(kf.ErrorCovPre, 7, 1f);
                    at(kf.ErrorCovPre, 14, 1f);
                    at(kf.ErrorCovPre, 21, 1f);
                    at(kf.ErrorCovPre, 28, 1f);
                    at(kf.ErrorCovPre, 35, 1f);

                    at(state, 0, at(meas, 0));
                    at(state, 1, at(meas, 1));
                    at(state, 2, 0);
                    at(state, 3, 0);
                    at(state, 4, at(meas, 2));
                    at(state, 5, at(meas, 3));

                    found = true;

                }
                else
                    kf.Correct(meas);



            }



        }

        public bool bulundu
        {
            get
            {
                return found;
            }
        }
       public Rectangle[] al()
        {
            Rectangle[] sonuclar;
           if(found){
               sonuclar = new Rectangle[1];
               sonuclar[0] = sonuc;
           }
           else
           {
               sonuclar = new Rectangle[0];
           }
           return sonuclar;

        }

        


        private  float GetValue(Mat mat, int row, int col)
        {
            float[] value = new float[1];
            Marshal.Copy(mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, value, 0, 1);
            return value[0];
        }

        private  void SetValue( Mat mat, int row, int col, float value)
        {
            float[] target = new float[1];
            target[0] = value;
            Marshal.Copy(target, 0, mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, 1);
        }
        public Matrix<float> toMatrix(Mat mat)
        {
            return new Matrix<float>(mat.Height, mat.Width, mat.DataPointer);
        }

        private void at(Mat mat, int at, float value)
        {
            float[] target = new float[1];
            target[0] = value;
            Marshal.Copy(target, 0, mat.DataPointer + at * mat.ElementSize, 1);
        }
        private float at(Mat mat, int at)
        {
            float[] value = new float[1];
            Marshal.Copy(mat.DataPointer + at * mat.ElementSize, value, 0, 1);
            return value[0];
        }
       


    }
}
