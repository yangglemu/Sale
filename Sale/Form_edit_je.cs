using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sale
{
    public partial class Form_edit_je : Form
    {
        private float _yje;
        private float _xje;

        public float xje
        {
            get { return _xje; }
            set { _xje = value; }
        }

        public float yje
        {
            get { return _yje; }
            set { _yje = value; }
        }
        public Form_edit_je()
        {
            InitializeComponent();
        }

        private void Form_edit_je_Load(object sender, EventArgs e)
        {
            this.textBox_yje.Text = this.yje.ToString("0.00");
            this.textBox_xje.Select();
            this.xje = 0.0f;
        }

        private void textBox_xje_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.Return:
                    if (textBox_xje.TextLength < 1)
                        break;
                    try
                    {
                        this.xje = float.Parse(this.textBox_xje.Text);
                        if (this.xje > 0.0f)
                            this.DialogResult = DialogResult.OK;
                    }
                    catch
                    {
                        MessageBox.Show("输入的金额格式不对！");
                        this.textBox_xje.SelectAll();
                        break;
                    }
                    if (this.Text == "修改金额")
                    {
                        if (xje / yje < 0.5f)
                        {
                            DialogResult dr = MessageBox.Show("按当前指定金额，折扣率过大，确定？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dr == DialogResult.No)
                            {
                                this.textBox_xje.SelectAll();
                                break;
                            }
                        }
                    }
                    else if (this.Text == "修改折扣")
                    {
                        if (xje < 0.5f)
                        {
                            DialogResult dr = MessageBox.Show("按当前指定金额，折扣率过大，确定？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dr == DialogResult.No)
                            {
                                this.textBox_xje.SelectAll();
                                break;
                            }
                        }
                    }
                    this.Close();
                    break;
            }
        }
    }
}
