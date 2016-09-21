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
    public partial class Form_shouying : Form
    {
        private int _js;
        private float _ys;
        private float _ss;
        private float _zl;
        private bool isSK;
        private bool isInserted;
        public int js
        {
            get { return _js; }
            set { _js = value; }
        }
        public float ys
        {
            get { return _ys; }
            set { _ys = value; }
        }
        public float ss
        {
            get { return _ss; }
            set { _ss = value; }
        }
        public float zl
        {
            get { return _zl; }
            set { _zl = value; }
        }

        public Form_shouying()
        {
            InitializeComponent();
            js = 0;
            ys = 0.0f;
            ss = 0.0f;
            zl = 0.0f;
            isSK = false;
            isInserted = false;
        }

        private void textBox_ss_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //刷卡
                case Keys.K:
                    if (e.Control)
                    {
                        var s = "当前应收金额 " + this.textBox_ys.Text + " , 确定刷卡收银？";
                        var ret = MessageBox.Show(s, "刷卡操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                        if (ret != DialogResult.Yes)
                        {
                            this.isSK = false;
                            return;
                        }
                        this.textBox_ss.Text = ys.ToString("0");
                        this.textBox_ss.SelectionStart = this.textBox_ss.TextLength;
                        this.isSK = true;
                    }
                    break;

                //退出
                case Keys.Escape:
                    this.DialogResult = DialogResult.Ignore;
                    this.Close();
                    break;

                case Keys.Return:
                    DoWork();
                    break;

                default:
                    break;
            }
        }

        private void DoWork()
        {
            if (this.textBox_ss.TextLength > 0)
            {
                try
                {
                    ss = float.Parse(this.textBox_ss.Text);
                }
                catch
                {
                    MessageBox.Show("请输入正确数字");
                    this.textBox_ss.SelectAll();
                    ss = 0.0f;
                    return;
                }
                //检查实收金额，小于应收款则出错
                zl = ss - ys;
                if (zl < 0.0f)//找零数小于零的情况下
                {
                    MessageBox.Show("找零为负数，实收现金不足！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.textBox_ss.SelectAll();
                    return;
                }
                else if (zl > 99.99f && js > 0)
                {
                    MessageBox.Show("找零数过大，实收是否输入正确？");
                    this.textBox_ss.SelectAll();
                    return;
                }

                if (ys < 0)//件数为负，表示退货，找零可以为负数
                {
                    if (textBox_ss.Text != "0")
                    {
                        MessageBox.Show("退货时的实收金额只能为0");
                        this.textBox_ss.SelectAll();
                        return;
                    }
                }
                this.SetData();
                //与主窗体间传值
                Form_main f = this.Owner as Form_main;
                f._ss = this.ss;
                f._zl = this.zl;
                return;
            }//if (this.textBox_ss.TextLength > 0)

                    //找零款正确,进行打印
            else if (textBox_ss.TextLength == 0 && textBox_ss2.TextLength > 0)
            {
                if (this.isInserted)
                {
                    this.Close();
                    return;
                }

                Form_main mf = this.Owner as Form_main;
                mf.InsertIntoDatabase(isSK);
                this.isInserted = true;
                if (mf.isPrint)
                {
                    mf.Print();
                }
            }
        }
        private void Form_shouying_Shown(object sender, EventArgs e)
        {
            this.textBox_js.Text = js.ToString();
            this.textBox_ys.Text = this.textBox_ys2.Text = ys.ToString("0.00");
            zl = -ys;
            this.SetData();
            this.textBox_ss2.Clear();
        }

        /// <summary>
        /// 设置两个找零文本框内容
        /// </summary>
        private void SetData()
        {
            this.textBox_ss2.Text = ss.ToString("0.00");
            this.textBox_zl.Text = this.textBox_zl2.Text = zl.ToString("0.00");
            this.textBox_ss.Clear();
        }

        private void Form_shouying_FormClosed(object sender, FormClosedEventArgs e)
        {
            //如果成功收银，恢复环境
            if (this.isInserted)
            {
                Form_main fm = this.Owner as Form_main;
                fm.ResetData();
                fm.ClearPeople();
            }
        }
    }
}
