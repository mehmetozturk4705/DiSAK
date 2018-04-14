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
using AForge;

namespace DisAK
{
    class PnpClass
    {
        public Mat camera = new Mat(3, 3, DepthType.Cv32F, 1);
        public Mat cov = new Mat(5, 1, DepthType.Cv32F, 1);
        public Mat raux = new Mat(), taux = new Mat();
        Size size=new Size(640,480);

        List<MCvPoint3D32f> model;

        public PnpClass(PointF[] initial,Rectangle YuzR )
        {
            /*camera.SetTo(new float[][]{
                new float[]{524,0,320},
                new float[]{0,524,240},
                new float[]{0,0,1}
            });*/
            SetValue(camera, 0, 0, 524);
            SetValue(camera, 0, 2, 320);
            SetValue(camera, 1, 1, 524);
            SetValue(camera, 1, 2, 240);
            SetValue(camera, 2, 2, 1);
            SetValue(camera, 0, 1, 0);
            SetValue(camera, 1, 0, 0);
            SetValue(camera, 2, 0, 0);
            SetValue(camera, 2, 1, 0);


            /*cov.SetTo(new float[]{7.3253671786835686e-002f,-8.6143199924308911e-002f,
-2.0800255026966759e-002f, -6.8004894417795971e-004f,
-1.7750733073535208e-001f});*/
            SetValue(cov, 0, 0, 0/*7.3253671786835686e-002f*/);
            SetValue(cov, 1, 0, 0/*-8.6143199924308911e-002f*/);
            SetValue(cov, 2, 0, 0/*-2.0800255026966759e-002f*/);
            SetValue(cov, 3, 0, 0/*-6.8004894417795971e-004f*/);
            SetValue(cov, 4, 0, 0/*-1.7750733073535208e-001f*/);
            PointF[] refer = KartezyenDuzlemRef(initial, YuzR);
            modelOlustur(refer);
        }
        
        
        public float[,] rotasyonAl(PointF[] noktalar)
        {
            float[,] sonuc = new float[3,3];
            
            CvInvoke.SolvePnP(model.ToArray(), noktalar, camera, cov, raux, taux);

            Mat rvec = new Mat();
            CvInvoke.Rodrigues(raux, rvec);
            for (int i = 0; i < raux.Cols; i++)
                for (int j = 0; j < raux.Rows; j++)
                    sonuc[j, i] = GetValue(rvec, j, i);


                    return sonuc;
                
        }
        private PointF[] kartezyen(PointF[] noktalar)
        {
            PointF[] sonuc = new PointF[noktalar.Length];
            for (int i = 0; i < noktalar.Length; i++)
            {
                sonuc[i]=new PointF(noktalar[i].X-size.Width/2,-(noktalar[i].Y-size.Height/2));

            }
            return sonuc;
        }
        private void modelOlustur(PointF[] noktalar)
        {
         
            model = new List<MCvPoint3D32f>();
            

            for (int i = 0; i < noktalar.Length; i++)
            {
                

                float eksenZ=(float)Math.Sqrt(150*150-noktalar[i].X*noktalar[i].X);

                this.model.Add(new MCvPoint3D32f(noktalar[i].X,noktalar[i].Y,eksenZ));
            }



            
        
        }
        public void NoktaSil(int index)
        {
            model.RemoveAt(index);
        }
        private PointF[] KartezyenDuzlemRef(PointF[] giris, Rectangle yuzR)
        {

            float size = 200.0f;
            int CX = yuzR.X + (yuzR.Width / 2);
            int CY = yuzR.Y + (yuzR.Height / 2);
            float oran = size / yuzR.Width;


            PointF[] sonuc = new PointF[giris.Length];
            for (int i = 0; i < giris.Length; i++)
            {
                sonuc[i].X = giris[i].X - CX;
                sonuc[i].Y = -(giris[i].Y - CY);
                sonuc[i].X *= oran;
                sonuc[i].Y *= oran;

            }
            return sonuc;


        }

        private float GetValue(Mat mat, int row, int col)
        {
            float[] value = new float[1];
            Marshal.Copy(mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, value, 0, 1);
            return value[0];
        }

        private void SetValue(Mat mat, int row, int col, float value)
        {
            float[] target = new float[1];
            target[0] = value;
            Marshal.Copy(target, 0, mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, 1);
        }

    }
}
