using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace DisAK
{
    public partial class FareMenu : Form
    {
        public float mouseVelocity = 0;
        int _activeMenu = -1;
        int HoverIndex = -1;
        bool mouseMoving = false;
        Stopwatch sw = new Stopwatch();
        Thread th;





        public int tickIndex = 1;

        Color standardPassive = Color.DarkGray;
        Color standardActive = Color.White;
        Color standardHover = Color.LightBlue;
        Color[] backgroundColors = new Color[]
        {
            Color.DarkGray,
            Color.DarkGray,
            Color.DarkGray,
            Color.DarkGray
        };

        PictureBox[] buttons = new PictureBox[4];
        int ActiveMenu
        {
            get
            {
                return this._activeMenu;
            }
            set
            {
                this._activeMenu = value;

                foreach (PictureBox box in buttons)
                    box.BackColor = this.standardPassive;
                for(int i = 0; i < 4; i++)
                {
                    backgroundColors[i] = this.standardPassive;
                }

                if (value < 4 && value >= 0) {
                    buttons[value].BackColor = this.standardActive;
                    backgroundColors[value] = this.standardActive;
                }



            }
        }
        public FareMenu()
        {
            InitializeComponent();
            buttons[0] = leftClickBox;
            buttons[1] = rightClickBox;
            buttons[2] = doubleClickBox;
            buttons[3] = mouseMoveBox;
            clickTimer.Enabled = true;
            foreach (PictureBox box in buttons)
                box.BackColor = this.standardPassive;

            th = new Thread(new ThreadStart(Run));
            th.Start();
            
        }
        private void Run()
        {
            sw.Start();
            while (true)
            {
                if (mouseVelocity > 220)
                {
                    sw.Restart();
                }
              
                if (sw.ElapsedMilliseconds>1250)
                {
                    sw.Restart();
                    if (HoverIndex >= 0)
                    {
                        ActiveMenu = (ActiveMenu == HoverIndex) ? -1 : HoverIndex;
                    }
                    else
                    {
                        switch (ActiveMenu)
                        {
                            case 0:
                                Fare.SolBas();
                                Fare.SolCek();

                                break;
                            case 1:
                                Fare.SagBas();
                                Fare.SagCek();
                                ActiveMenu = 0;
                                break;
                            case 2:
                                Fare.SolBas();
                                Fare.SolCek();
                                Fare.SolBas();
                                Fare.SolCek();
                                ActiveMenu = 0;
                                break;
                            case 3:
                                if (mouseMoving)
                                {
                                    Fare.SolCek();
                                    ActiveMenu = 0;
                                }
                                else
                                {
                                    Fare.SolBas();
                                    mouseMoving = true;
                                }

                                break;
                        }
                    }
                }

                
            }
        }
        private void clickTimer_Tick(object sender, EventArgs e)
        {
            
    
        }

        private void doubleClickBox_Click(object sender, EventArgs e)
        {

        }

        private void leftClickBox_Click(object sender, EventArgs e)
        {

        }

        private void rightClickBox_Click(object sender, EventArgs e)
        {

        }

        private void ButtonsMouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = this.standardHover;
            switch (((PictureBox)sender).Name)
            {
                case "leftClickBox":
                    this.HoverIndex = 0;
                    break;
                case "rightClickBox":
                    this.HoverIndex = 1;
                    break;
                case "doubleClickBox":
                    this.HoverIndex = 2;
                    break;
                case "mouseMoveBox":
                    this.HoverIndex = 3;
                    break;
                default:
                    break;
            }

        }

        private void ButtonsMouseLeave(object sender, EventArgs e)
        {
            switch (((PictureBox)sender).Name)
            {
                case "leftClickBox":
                    ((PictureBox)sender).BackColor = backgroundColors[0];
                    break;
                case "rightClickBox":
                    ((PictureBox)sender).BackColor = backgroundColors[1];
                    break;
                case "doubleClickBox":
                    ((PictureBox)sender).BackColor = backgroundColors[2];
                    break;
                case "mouseMoveBox":
                    ((PictureBox)sender).BackColor = backgroundColors[3];
                    break;
                default:
                    break;
            }
            HoverIndex = -1;
        }

        private void FareMenu_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void FareMenu_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
        }

        private void FareMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (th != null)
                th.Abort();
        }
    }
}
