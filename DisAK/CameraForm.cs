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
using SharpGL;
using AForge;
using System.Drawing.Imaging;

//Operator: Mehmet ÖZTÜRK
namespace DisAK
{
    public partial class CameraForm : Form
    {
        
        
        private Capture capt;
        private CascadeClassifier sinif = new CascadeClassifier("haar\\haaronyuzalt3.xml");
        private CascadeClassifier gozler = new CascadeClassifier("haar\\eyes2.xml");
        private CascadeClassifier agiz = new CascadeClassifier("haar\\haarcascade_mcs_mouth.xml");
        private Mat kare = new Mat();
        private Stopwatch modtimer = new Stopwatch();
        private Emgu.CV.Features2D.GFTTDetector gftt = new GFTTDetector(2000, 0.01, 10, 3, false);
        private Stopwatch fpstimer = new Stopwatch();
        private Pozlama pozlama;
        private double fps = 0;
       

        
        
        Image<Gray, Byte> eskikare { get; set; }
        Image<Bgr, Byte> karer { get; set; }
        Image<Bgr, Byte> karei { get; set; }
        
        Image<Gray, Byte> faceg { get; set; }
        Image<Bgr, Byte> faceim { get; set; }
        Image<Gray, Byte> kareg { get; set; }
        Rectangle[] veriler;
        Rectangle[] processedveri;
        Imlec imlec = new Imlec();
        PointF[][] noktalarf = new PointF[1][];
        PointF[] eskiftr;
        OpenGL openglwrap = new OpenGL();
        List<Bgr> renkler;
        FiltreTemel filtre = new FiltreTemel();

        bool mousecontrol = false;
       

        
        
        
        
        
        private yuztakip takip = new yuztakip();
        
        
        
        private enum mod : byte
        {
            Tanıma,
            Takip,
            İlkkare

        };

        mod program = mod.Tanıma;   

        private int[] initial = new int[2] { 0, 0 };
        public CameraForm()
        {
            
          
            
            InitializeComponent();
            CvInvoke.UseOpenCL = true;
            CvInvoke.UseOptimized = true;
            
        }

        private void mouse_click_button(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Application.AddMessageFilter(new Keyboard());

            dur.Enabled = false;
         
            

        }
        private void goruntual(object sender, EventArgs e)
        {





            try { capt.Retrieve(kare); }
            catch (Exception exc)
            {


                console1.Invoke((Action)delegate { console1.AppendText("CaptureError:" + exc.Message + "\n"); });


            }
                           
                

                karei = kare.ToImage<Bgr, Byte>();
               // karei.Flip(FlipType.Horizontal);
                //karei.Rotate(60,new PointF(320,24),Inter.Area,new Bgr(0,0,0),true);
                
                
                
                
                karei._GammaCorrect(1);
                
                
                

                
                
                kareg = karei.Convert<Gray, Byte>();//siyah beyaza çevrim
                
                veriler = sinif.DetectMultiScale(kareg, 1.1, 4,new Size(80,80));//tanıma
                
                if(veriler.Length!=0)
                for (int i = 1; i < veriler.Length; i++)
                {
                    if ((veriler[i].Width * veriler[i].Height) > (veriler[0].Width * veriler[0].Height))
                        veriler[0] = veriler[i];
                }

                    // en büyüğüne 0 indisine alma





                try
                {
                    takip.step(veriler);

                    processedveri = takip.al();
                    #region yuz ve göz işleme

                    if (processedveri.Length > 0 && takip.bulundu)
                    {

                        karei.ROI = processedveri[0];
                        faceim = karei.Copy();
                        faceg = faceim.Convert<Gray, Byte>();
                        Rectangle[] gozrect = gozler.DetectMultiScale(faceg, 1.1, 4, new Size(20, 20));//tanıma


                        if (gozrect.Length > 0)
                        {
                            for (int i = 0; i < gozrect.Length; i++)
                            {
                                if ((gozrect[i].Width * gozrect[i].Height) > (gozrect[0].Width * gozrect[0].Height))
                                    gozrect[0] = gozrect[i];
                            }//en büyüğü alma
                            gozrect[0].Y -= 30;
                            gozrect[0].Height += 40;
                            gozrect[0].X -= 5;
                            gozrect[0].Width += 10;
                        }
                        
                        if (gozrect.Length > 0)
                        {
                            filtre.besle(gozrect[0],fps);
                            Rectangle EyeRect = filtre.al(faceim.Width, faceim.Height);
                            faceim.ROI = EyeRect;
                            Image<Bgr, Byte> Gozim = faceim.Copy();
                            
                            Image<Hsv,Byte> GozimHSV=Gozim.Convert<Hsv,Byte>();

                            Image<Gray, Byte> RangeMask = GozimHSV.InRange(new Hsv(13, 10, 58), new Hsv(19, 40, 180));

                            faceim.ROI = new Rectangle();

                            eyebox.Image = Gozim;
                            faceim.Draw(EyeRect, new Bgr(0, 0, 255), 2);
                        }


                        facebox.Image = faceim;
                        karei.ROI = new Rectangle();
                        faceg = null;

                    }
                }
                catch (Exception exc)
                {


                    console1.Invoke((Action)delegate { console1.AppendText("Gozrect:"+exc.Message + "\n"); });


                }
                #endregion

                try
                {
                    if (takip.bulundu)
                    {


                        if (program == mod.Tanıma) karefactor(ref processedveri[0], 0.5f);





                        kareg.ROI = processedveri[0];


                        faceg = kareg.Copy();
                        kareg.ROI = new Rectangle();


                        if (program == mod.Tanıma && !modtimer.IsRunning)
                            modtimer.Start();

                        foreach (Rectangle veri in processedveri)
                            karei.Draw(veri, new Bgr(255, 0, 0));// kalmandan gelen verileri ekrana çizme ekrana çizme
                        if (program == mod.Tanıma)
                        {
                            #region tanıma


                            MKeyPoint[] noktalar = gftt.Detect(faceg);



                            noktalarf[0] = new PointF[noktalar.Length];

                            for (int i = 0; i < noktalar.Length; i++)
                            {
                                noktalarf[0][i].X = noktalar[i].Point.X;
                                noktalarf[0][i].Y = noktalar[i].Point.Y;
                            }

                            faceg.FindCornerSubPix(noktalarf, new Size(5, 5), new Size(-1, -1), new MCvTermCriteria(60, .05d));

                            for (int i = 0; i < noktalarf[0].Length; i++)//koordinasyon
                            {
                                noktalarf[0][i].X += processedveri[0].X;
                                noktalarf[0][i].Y += processedveri[0].Y;



                            }
                            // }
                            ///Deneme başlangıç yeri
                            ///
                            /*noktalarf[0] = new PointF[]{
                                 new PointF(processedveri[0].X+processedveri[0].Width/2,processedveri[0].Top),
                                 new PointF(processedveri[0].Left,processedveri[0].Y+processedveri[0].Height/2),
                                 new PointF(processedveri[0].Right,processedveri[0].Y+processedveri[0].Height/2),
                                 new PointF(processedveri[0].X+processedveri[0].Width/2,processedveri[0].Bottom),
                             };*/

                            ///Bitiş yeri
                            ///

                            if (takip.yuzhizi >= 32.0)
                                modtimer.Reset();

                            if (modtimer.ElapsedMilliseconds >= 2200)
                            {
                                program = mod.Takip;
                                eskiftr = noktalarf[0];
                                renkler = new List<Bgr>(new Bgr[noktalarf[0].Length]);
                                for (int i = 0; i < renkler.Count; i++)
                                    renkler[i] = new Bgr(255, 255, 255);

                                //pozlama açılıyor

                                pozlama = new Pozlama(noktalarf[0], processedveri[0], new Size(640, 480));

                            }
                            Bgr noktarengi = new Bgr(255, 0, 0);

                            foreach (PointF aa in noktalarf[0])
                                karei.Draw(new CircleF(new PointF(aa.X, aa.Y), 2), noktarengi, 1);


                            #endregion
                        }




                    }

                    else
                    {
                        modtimer.Stop();
                        modtimer.Reset();

                    }
                }
                catch (Exception exc)
                {


                    console1.Invoke((Action)delegate { console1.AppendText(""+exc.Message + "\n"); });


                }

                    if (program == mod.Takip)
                    {
                        float[] trackError;
                        byte[] status;
                        PointF[] noktayeni = new PointF[eskiftr.Length];


                        #region opticalFlow algoritması
                        modtimer.Stop();
                        modtimer.Reset();
                        Image<Gray, Byte>[] pyramid = eskikare.BuildPyramid(0);
                        //pyramid oluşturuldu

                        CvInvoke.CalcOpticalFlowPyrLK(pyramid[0], kareg, eskiftr, new Size(60, 60), 15, new MCvTermCriteria(150, 1d), out noktayeni, out status, out trackError);





                        #endregion


                        List<PointF> liste = new List<PointF>(noktayeni);
                        if (takip.bulundu)
                        {
                            for (int j = 0; j < liste.Count; j++)
                            {

                                if (!(

                                    liste[j].X >= processedveri[0].Left
                                    &&
                                    liste[j].Y >= processedveri[0].Top
                                    &&
                                    liste[j].X <= processedveri[0].Right
                                    &&
                                    liste[j].Y <= processedveri[0].Bottom


                                    ))
                                {
                                    int azalim = 28;

                                    var renk = renkler[j];
                                    renk.Blue -= azalim;
                                    renk.Green -= azalim;

                                    renkler[j] = renk;


                                }
                                else
                                {
                                    renkler[j] = new Bgr(255, 255, 255);
                                }
                                if (renkler[j].Blue <= 30)
                                {
                                    renkler.RemoveAt(j);
                                    liste.RemoveAt(j);
                                    pozlama.NoktaSil(j);
                                    program = mod.Tanıma;

                                }


                            }




                        }
                        else
                        {
                            for (int i = 0; i < renkler.Count; i++)
                                renkler[i] = new Bgr(255, 255, 255);
                        }


                        noktayeni = liste.ToArray();


                        //ypr değerlerini yazdırma
                        int index = 0;
                        foreach (PointF aa in noktayeni)
                        {


                            karei.Draw(new CircleF(new PointF(aa.X, aa.Y), 2), renkler[index], 3);
                            index++;

                        }




                        eskiftr = noktayeni;
                        float[] rotasyon = pozlama.rotasyon(eskiftr, processedveri[0]);
                        imlec.feed(rotasyon[0], rotasyon[1], (float)fps);

                        /*yprgosterge.Invoke((Action)delegate
                        {
                            yprgosterge.Text = "Yaw:" + Math.Round(rotasyon[0], 2, MidpointRounding.AwayFromZero) + "Pitch:" + Math.Round(rotasyon[1], 2, MidpointRounding.AwayFromZero) + "Roll:" + Math.Round(rotasyon[2], 2, MidpointRounding.ToEven);
                        });*/

                    }

                    eskikare = kareg;
                    karei.ROI = new Rectangle();
                    goruntu.Image = karei;
                    if (!fpstimer.IsRunning)
                    {
                        fpstimer.Start();
                    }
                    else
                    {
                        fps = 1000.0 / fpstimer.ElapsedMilliseconds;
                        fps = Math.Round(fps, 3);
                        fpstimer.Reset();
                        fpstimer.Start();
                        karei.Draw("FPS:" + fps, new System.Drawing.Point(30, 48), FontFace.HersheyComplex, 0.5, new Bgr(0, 0, 0), 1);
                    }

                
  

                GC.Collect();

          
            
           /* catch (Exception exc)
            {
                

                console1.Invoke((Action)delegate { console1.AppendText(exc.Message + "\n"); });
                

            }*/
            

        }
        private Seri[] kopyala<Seri>(Seri[] dizi)
        {
            Seri[] sonuc = new Seri[dizi.Length];
            for (int i = 0; i < dizi.Length; i++)
            {
                sonuc[i] = dizi[i];
            }
            return sonuc;
        }
        private void karefactor(ref Rectangle kare, float factor)
        {
            kare.X += (int)((kare.Width - kare.Width * factor) / 2);
            kare.Y += (int)((kare.Height - kare.Height * factor) / 2);
            kare.Width = (int)(factor * kare.Width);
            kare.Height = (int)(factor * kare.Height);
            

        }

        private PointF FindCentroid(PointF[] Hull)
        {
            
            int num_points = Hull.Length;
            PointF[] pts = new PointF[num_points + 1];
            Hull.CopyTo(pts, 0);
            pts[num_points] = Hull[0];

          
            float X = 0;
            float Y = 0;
            float second_factor;
            for (int i = 0; i < num_points; i++)
            {
                second_factor = pts[i].X * pts[i + 1].Y - pts[i + 1].X * pts[i].Y;
                X += (pts[i].X + pts[i + 1].X) * second_factor;
                Y += (pts[i].Y + pts[i + 1].Y) * second_factor;
            }
            
            float polygon_area = Math.Abs(SignedPolygonArea(Hull));
            X /= (6 * polygon_area);
            Y /= (6 * polygon_area);

            
            if (X < 0)
            {
                X = -X;
                Y = -Y;
            }
            return new PointF(X, Y);
        }
        private float SignedPolygonArea(PointF[] Hull)
        {
            int num_points = Hull.Length;
            // Get the areas.
            float area = 0;
            for (int i = 0; i < num_points; i++)
            {
                area +=
                    (Hull[(i + 1) % num_points].X - Hull[i].X) *
                    (Hull[(i + 1) % num_points].Y + Hull[i].Y) / 2;
            }
            // Return the result.
            return area;
        }

        private void butonmouseenter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = (Image)Properties.Resources.butonhover;
        }

        private void butonmouseleave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = null;
        }

        private void butonmousedown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = (Image)Properties.Resources.butonclick;
        }

        private void butonmouseup(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = null;
        }

        private void close_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "DisAK", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            }
            else { 
                this.Hide();
                e.Cancel = true;
                notifyIcon.ShowBalloonTip(3000);
            }

           
        }

        private void fullscreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;

        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void captionmove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                this.Location = new System.Drawing.Point(Cursor.Position.X - initial[0] - ((Control)sender).Location.X, Cursor.Position.Y - initial[1] - ((Control)sender).Location.Y);

            }
        }

        private void captionmousedown(object sender, MouseEventArgs e)
        {
            initial[0] = e.X;
            initial[1] = e.Y;
        }

        private void Caption_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void minimizepaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.DrawImage((Image)Properties.Resources.mini, 8, 12, 10, 12);
        }

        private void closepaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawImage((Image)Properties.Resources.close, 8, 8, 10, 10);
        }

        private void maximizepaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if(this.WindowState==FormWindowState.Maximized)
                e.Graphics.DrawImage((Image)Properties.Resources.normal, 8, 8, 10, 10);
            else
                e.Graphics.DrawImage((Image)Properties.Resources.max, 7, 8, 12, 10);
        }

        private void logopaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.DrawImage((Image)Properties.Resources.pngupt, 0, 0, ((PictureBox)sender).Width, ((PictureBox)sender).Height);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mousetimer.Start();

            takip.timer.Start();
            
            try
            {
                capt = new Capture();
                capt.SetCaptureProperty(CapProp.FrameWidth, 640.0);
                capt.SetCaptureProperty(CapProp.FrameHeight, 480.0);
                capt.Start();
                capt.ImageGrabbed += goruntual;
                ((Button)sender).Enabled = false;
                dur.Enabled = true;
                goruntu.Visible = true;
                facebox.Visible = true;
               
            }
            catch (Exception)
            {
                capt.Stop();
                capt.ImageGrabbed -= goruntual;
                ((Button)sender).Enabled = true;
                dur.Enabled = false;
                MessageBox.Show("Unresolved error while trying to open camera!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           

           
           
                
               
              

            
           
           
  
            

        }

        private void dur_Click(object sender, EventArgs e)
        {
            facebox.Visible = false;
            program = mod.Tanıma;
            dur.Enabled = false;
            basla.Enabled = true;
            capt.ImageGrabbed -= goruntual;
            capt.Stop();
            capt.Dispose();
            takip.timer.Stop();
            takip.timer.Reset();
            
            goruntu.Visible = false;
            mousetimer.Stop();
            
            
        }

        private void gösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void MouseControl_tick(object sender, EventArgs e)
        {
            if (program == mod.Takip)
            {
                imlec.calistir(true);

            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
