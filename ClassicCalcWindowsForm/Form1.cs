using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCalcWindowsForm
{
    public partial class Form1 : Form
    {
        DispManager dispManager;
        InputManager inputManager;
        CalcManager calcManager;

        public Form1()
        {
            InitializeComponent();
            Clear();
        }
        
        void Clear()
        {
            dispManager = new DispManager(textBox1);
            inputManager = new InputManager();
            calcManager = new CalcManager();

            inputManager.Subscribe(dispManager);
            inputManager.Subscribe(calcManager);
            calcManager.Subscribe(dispManager);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("1");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inputManager.InputOpp(Event.InputOperation.Add);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inputManager.InputOpp(Event.InputOperation.Equal);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("3");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("4");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("5");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("6");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("7");
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("8");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            inputManager.InputNum("9");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            inputManager.InputOpp(Event.InputOperation.Sub);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            inputManager.InputOpp(Event.InputOperation.Mult);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            inputManager.InputOpp(Event.InputOperation.Div);
        }
    }
}
