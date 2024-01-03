using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponenteRep
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            angle = seconds * 6;
            Refresh();

            lblTime.Text = String.Format("{0,2:00}:{1,2:00}", minutes, seconds);
            btnPlay.BackgroundImage = ComponenteRep.Properties.Resources.play;
            btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private bool play = false;
        private int seconds = 0;
        private int minutes = 0;
        private int angle = 0;

        /// <summary>
        /// This methot change the image of the button depending on the value of play.
        /// </summary>
        /// <param name="sender">the component created</param>
        /// <param name="e">the button has been clicked</param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (play)
            {
                btnPlay.BackgroundImage = ComponenteRep.Properties.Resources.play;
                btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
                play = false;
            }
            else
            {
                btnPlay.BackgroundImage = ComponenteRep.Properties.Resources.pause;
                btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
                play = true;
            }

            OnPlayClick(EventArgs.Empty);
        }

        /// <summary>
        /// This event capture the click on the button.
        /// </summary>
        [Category("Exercise")]
        [Description("Clicking the play button activates the event")]
        public event EventHandler PlayClick;

        protected virtual void OnPlayClick(EventArgs e)
        {
            if (PlayClick != null)
            {
                PlayClick(this, e);
            }
        }

        /// <summary>
        /// This value of the component establishes the seconds, check if the value is minor of 59 to reset it and gives the label of the frame the seconds of the counter.
        /// </summary>
        [Category("Exercise")]
        [Description("Player seconds")]
        public int SS
        {
            set
            {
                if (value >= 0)
                {
                    if (value > 59)
                    {
                        OnTimeOverflow(EventArgs.Empty);
                        seconds = value % 60;
                    }
                    else
                    {
                        seconds = value;

                    }
                    angle = seconds * 6;
                    Refresh();


                    lblTime.Text = String.Format("{0,2:00}:{1,2:00}", minutes, seconds);
                }
                else
                {
                    throw new ArgumentException();
                }

            }
            get
            {
                return seconds;
            }
        }

        /// <summary>
        /// This value of the component establishes the seconds, check if the value is minor of 59 to reset it and gives the label of the frame the seconds of the counter.
        /// </summary>
        [Category("Exercise")]
        [Description("Player minutes")]
        public int MM
        {
            set
            {
                if (value >= 0)
                {
                    if (value > 59)
                    {
                        minutes = 0;
                    }
                    else
                    {
                        minutes = value;
                    }


                    lblTime.Text = String.Format("{0,2:00}:{1,2:00}", minutes, seconds);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            get
            {
                return minutes;
            }
        }



        /// <summary>
        /// This event capture the values of the minutes and seconds and reset them when passes 59.
        /// </summary>
        [Category("Exercise")]
        [Description("Event executed when one minute is completed")]
        public event EventHandler TimeOverflow;

        protected virtual void OnTimeOverflow(EventArgs e)
        {
            if (TimeOverflow != null)
            {
                TimeOverflow(this, e);
            }
        }

        /// <summary>
        /// This event paint on the frame the circle that marcs the pass of the counter.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int grosor = 5;
            Brush br = new SolidBrush(Color.Turquoise);

            g.FillPie(br, 10, 100, 50, 50, 270, angle);
        }


    }
}
