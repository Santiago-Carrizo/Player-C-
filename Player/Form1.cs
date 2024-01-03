using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class Form1 : Form
    {
        private bool play = false;

        public Form1()
        {
            InitializeComponent();
            for (int i = 100; i <= 10000; i = i + 100)
            {
                comboBox1.Items.Add(i);
            }

            comboBox1.SelectedIndex = 0;

        }

        /// <summary>
        /// When the item selected in the combox is changed the timer interval change to the number in the item.
        /// </summary>
        /// <param name="sender">the combox changed</param>
        /// <param name="e">the change event</param>
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt16(comboBox1.SelectedItem.ToString());
            userControl11.Refresh();
        }


        /// <summary>
        /// When the timer add one unit passed the interval asigned add one unit to the seconds variable.
        /// </summary>
        /// <param name="sender">the timer</param>
        /// <param name="e">is executed when the interval passed</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            userControl11.SS++;
        }

        /// <summary>
        /// This methot change the variable play to true/false depending on the last state when the button in the component is clicked.
        /// </summary>
        /// <param name="sender">the component created</param>
        /// <param name="e">click in the button</param>
        private void userControl11_PlayClick(object sender, EventArgs e)
        {
            if (play)
            {
                timer1.Stop();
                play = false;
            }
            else
            {
                timer1.Start();
                play = true;
            }
        }

        /// <summary>
        /// This methot add one unit to the minutes variable when the seconds surpasses the 59 seconds and refresh the component.
        /// </summary>
        /// <param name="sender">the component created</param>
        /// <param name="e">the event created and specified</param>
        private void userControl11_TimeOverflow(object sender, EventArgs e)
        {
            userControl11.MM++;
            userControl11.Refresh();
        }
    }
}
