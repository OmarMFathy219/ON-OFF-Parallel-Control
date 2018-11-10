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

namespace ON_OFF_Parallel_Control
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        class PortInterop
        {
            [DllImport("inpout32.dll", EntryPoint = "out32")]
            public static extern void Output(int address, int value);

            [DllImport("inpout32.dll", EntryPoint = "Inp32")]
            public static extern int Input(int address);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int input;
            input = PortInterop.Input(889);
            if (input == 225)
            {
                Button1.Text = "ON";
            }
            else
            { 
                Button1.Text = "OFF";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(Button1.Text=="OFF")
            {
                //Turn The Circuit ON
                PortInterop.Output(888, 255);
                Button1.Text = "ON";
            }
            else
            {
                //Turn The Circuit OFF
                PortInterop.Output(888, 0);
                Button1.Text = "OFF";
            }
        }
    }
}
