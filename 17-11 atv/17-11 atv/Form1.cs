using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17_11_atv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox4.Text = "0";
        }
        
        class conta
        {
            public string Titular { get; set; }
            public int Agencia { get; set; }
            public int Numero { get; set; }
            public int Tipo { get; set; }

            private double saldo = 0;
            public double Saldo {
                get { return this.saldo; }
                set { this.saldo = value; }  
            }
            public virtual void sacar(double valor)
            {
                this.saldo -= valor;
            }
            public void Depositar(double valor)
            {
                this.saldo += valor;
            }

        }
        class ContaPoupanca : conta //Herança
        {
            public override void sacar(double valor)
            {
                this.Saldo -= valor + 0.10;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContaPoupanca p = new ContaPoupanca();
            p.Depositar(Convert.ToDouble(textBox5.Text));
            textBox4.Text = Convert.ToString(p.Saldo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ContaCorrente")
            {
                conta c = new conta();
                c.Saldo = Convert.ToDouble(textBox4.Text);
                c.sacar(Convert.ToDouble(textBox5.Text));
                textBox4.Text = Convert.ToString(c.Saldo);
                
            }
            if (comboBox1.Text == "ContaPoupanca")
            {
                ContaPoupanca p = new ContaPoupanca();
                p.Saldo = Convert.ToDouble(textBox4.Text);
                p.sacar(Convert.ToDouble(textBox5.Text));
                textBox4.Text = Convert.ToString(p.Saldo);
                
            }
        }
    }
}
