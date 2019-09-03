using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstaBulochka
{
    public partial class TrialEndWindow : Form
    {
        
        
        public TrialEndWindow()
        {
            

            InitializeComponent();
           



        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/club75514519");
          
            
            Application.Exit();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void TrialEndWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TrialEndWindow_Shown(object sender, EventArgs e)
        {
            Form1.MyGlavForm.Hide();
        }

        private void TrialEndWindow_Load(object sender, EventArgs e)
        {
            // this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
    }
}
