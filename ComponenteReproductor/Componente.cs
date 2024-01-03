using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponenteReproductor
{
    public partial class Componente : UserControl
    {
        public Componente()
        {
            InitializeComponent();
        }

        static bool play = false;
        static int segundos = 0;
        static int minutos = 0;

        protected virtual void PlayClick(object sender, EventArgs e)
        {
            if (play)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;

            if (segundos > 59)
            {
                minutos++;
                segundos = 0;
            }

            if(minutos > 59)
            {
                minutos = 0;
            }

            lblTime.Text = String.Format("{0,2}:{1,2}", minutos, segundos);
        }
    }
}
