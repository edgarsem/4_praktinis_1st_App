using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_praktinis_1st_App
{
    public partial class Form1 : Form
    {
        private String privKey = "";

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CrptEngine.CheckStringFormat(privKey) && CrptEngine.CheckStringFormat(PubKeyBox.Text))
            {
                string[] splitInput = privKey.Split(',');
                resultBox.Text = CrptEngine.signingEngine(textBox.Text, BigInteger.Parse(splitInput[0]), BigInteger.Parse(splitInput[1]));
            }
            else
                System.Windows.Forms.MessageBox.Show("Wrong key format!");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            System.Windows.Forms.MessageBox.Show("Wrong private key format");
        }

        private void keyBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            PubKeyBox.Text = "";
            textBox.Text = "";
            resultBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (CrptEngine.CheckStringFormat(privKey) && CrptEngine.CheckStringFormat(PubKeyBox.Text))
            {
                System.Windows.Forms.MessageBox.Show(Client.sendMessageToServer(PubKeyBox.Text + '|' + textBox.Text + '|' + resultBox.Text));
            }
            else
                System.Windows.Forms.MessageBox.Show("Wrong key format!");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void keyWarningLabel_Click(object sender, EventArgs e)
        {

        }

        private void encryptionModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void PubKeyGenButton_Click(object sender, EventArgs e)
        {
            string[] splitInput = CrptEngine.keyGen().Split('|');
            PubKeyBox.Text = splitInput[0];
            privKey = splitInput[1];
        }


        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }
    }

}

