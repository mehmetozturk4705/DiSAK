using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;
using System.Drawing;
using AForge.Math;
using AForge.Math.Geometry;

namespace DisAK
{

    class Pozlama
    {
        public  enum Bolge:int
        {
            Üst,
            Sol,
            Sağ,
            Alt
        }
        
        int sayac1 = 0;
        List<Bolge> bolgeler;
        List<AForge.Math.Vector3> modelNoktalari;
        List<AForge.Point> YuzNoktalari;
        Matrix3x3 Rotation;
        Vector3 Translation;
        Size boyut;
        int[] noktasayilari;
        int[] currentnokta;

        Posit posit;

        Vector3[] axesmodel = new Vector3[]
            {
                 new Vector3( 0, 0, 0 ),
                 new Vector3( 1, 0, 0 ),
                 new Vector3( 0, 1, 0 ),
                 new Vector3( 0, 0, 1 ),
            };
        

       

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

        private List<AForge.Point> ortalamaAl(PointF[] giris)
        {   
            PointF[] ortalama={new PointF(),new PointF(),new PointF(),new PointF()};
            int[] sayac = { 0, 0, 0, 0 };
            for(int i=0;i<giris.Length;i++){
                if (bolgeler[i] == Bolge.Üst)
                {
                    sayac[0]++;
                    ortalama[0].X += giris[i].X;
                    ortalama[0].Y += giris[i].Y;
                }
                else if (bolgeler[i] == Bolge.Sol)
                {
                    sayac[1]++;
                    ortalama[1].X += giris[i].X;
                    ortalama[1].Y += giris[i].Y;
                }
                else if (bolgeler[i] == Bolge.Sağ)
                {
                    sayac[2]++;
                    ortalama[2].X += giris[i].X;
                    ortalama[2].Y += giris[i].Y;
                }
                else if (bolgeler[i] == Bolge.Alt)
                {
                    sayac[3]++;
                    ortalama[3].X += giris[i].X;
                    ortalama[3].Y += giris[i].Y;
                }

            }
            for (int i = 0; i < 4; i++)
            {
                ortalama[i].X /= sayac[i];
                ortalama[i].Y /= sayac[i];
            }

            if (noktasayilari == null)
            {
                noktasayilari = (int[])sayac.Clone();
                currentnokta = (int[])sayac.Clone();
            }
            else
                currentnokta = (int[])sayac.Clone();

            List<AForge.Point> sonuc = new List<AForge.Point>();
            sonuc.Add(new AForge.Point(ortalama[0].X, ortalama[0].Y));
            sonuc.Add(new AForge.Point(ortalama[1].X, ortalama[1].Y));
            sonuc.Add(new AForge.Point(ortalama[2].X, ortalama[2].Y));
            sonuc.Add(new AForge.Point(ortalama[3].X, ortalama[3].Y));



                return sonuc;

        }
        public PointF[] kartezyen(PointF[] giris)
        {
            PointF[] sonuc = new PointF[giris.Length];

            float CX=this.boyut.Width/2.0f, CY=this.boyut.Height/2.0f;


            for (int i = 0; i < giris.Length; i++)
            {
                sonuc[i].X = giris[i].X - CX;
                sonuc[i].Y = -(giris[i].Y - CY);

            }
            return sonuc;
        }
        List<AForge.Point> donustur(PointF[] giris)
        {
            List<AForge.Point> cikis = new List<AForge.Point>();

            for (int i = 0; i < giris.Length; i++)
                cikis.Add(new AForge.Point(giris[i].X, giris[i].Y));

            return cikis;
        }
        PointF[] donustur(List<AForge.Point> giris)
        {
            PointF[] cikis = new PointF[giris.Count];

            for (int i = 0; i < giris.Count; i++)
            {
                cikis[i].X = giris[i].X;
                cikis[i].Y = giris[i].Y;
            }


            return cikis;
        }

        public float[] rotasyon(PointF[] giris,Rectangle YuzR)
        {
            int CX = boyut.Width / 2;
            int CY = boyut.Height / 2;
            
            

            PointF[] giris2 = (PointF[])giris.Clone();
           if (sayac1 < 10)
            {
                PointF[] islenmis = KartezyenDuzlemRef(giris2, YuzR);
                isaretle(islenmis);
                modelOlustur(ortalamaAl(islenmis));
                posit = new Posit(modelNoktalari.ToArray(), 640.0f);
                sayac1++;
            }



            List<AForge.Point> ara = ortalamaAl(kartezyen(giris2));


            float[] sonuc = new float[3];
            posit.EstimatePose(ara.ToArray(), out this.Rotation, out this.Translation);
            this.Rotation.ExtractYawPitchRoll(out sonuc[0], out sonuc[1], out sonuc[2]);
            
            for (int i = 0; i < sonuc.Length; i++)
                sonuc[i] *= (float)(180 / Math.PI);

            sonuc[0] = sonuc[0]/1.5f;
            sonuc[1] += 0;

                return sonuc;

        }
        private void isaretle(PointF[] giris)
        {
            bolgeler = new List<Bolge>();
            for (int i = 0; i < giris.Length; i++)
            {
                if (giris[i].Y >= -giris[i].X && giris[i].Y >= giris[i].X)
                    bolgeler.Add(Bolge.Üst);
                if (giris[i].Y <= -giris[i].X && giris[i].Y >= giris[i].X)
                    bolgeler.Add(Bolge.Sol);
                if (giris[i].Y <= -giris[i].X && giris[i].Y <= giris[i].X)
                    bolgeler.Add(Bolge.Alt);
                if (giris[i].Y >= -giris[i].X && giris[i].Y <= giris[i].X)
                    bolgeler.Add(Bolge.Sağ);
            }

        }
        public Pozlama(PointF[] raw,Rectangle YuzR,Size Boyut)
        {
            this.boyut = Boyut;
            PointF[] giris = KartezyenDuzlemRef(raw, YuzR);
            this.sayac1 = 0;
           
            
            isaretle(giris);
            modelOlustur(ortalamaAl(giris));
            posit = new Posit(modelNoktalari.ToArray(), 640.0f);

            

           
        }
        public void NoktaSil(int index)
        {
            
            
            bolgeler.RemoveAt(index);
            
            


        }
        private void modelOlustur(List<AForge.Point> poz)
        {
            modelNoktalari = new List<Vector3>();
            

            for (int i = 0; i < poz.Count; i++)
            {
                

                float eksenZ=(float)Math.Sqrt(200*200-poz[i].X*poz[i].X);

                modelNoktalari.Add(new Vector3(poz[i].X, poz[i].Y, eksenZ));
            }



            
        } 
        public AForge.Point[] Projeksiyon( int viewSize)
        {

            Matrix4x4 transformationMatrix = Matrix4x4.CreateTranslation(this.Translation) *        // 3: translate
            Matrix4x4.CreateFromRotation(this.Rotation) *          // 2: rotate
            Matrix4x4.CreateDiagonal(new Vector4(56, 56, 56, 1));

            

            AForge.Point[] projectedPoints = new AForge.Point[axesmodel.Length];

            for (int i = 0; i < axesmodel.Length; i++)
            {
                Vector3 scenePoint = (transformationMatrix *
                    axesmodel[i].ToVector4()).ToVector3();

                projectedPoints[i] = new AForge.Point(
                    (int)(scenePoint.X / scenePoint.Z * viewSize),
                    (int)(scenePoint.Y / scenePoint.Z * viewSize));
            }

            return projectedPoints;
        }
    }
}
