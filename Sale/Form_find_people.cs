using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sale
{
    public partial class Form_find_people : Form
    {
        People _p;
        internal People p
        {
            get { return _p; }
            set { _p = value; }
        }
        public Form_find_people()
        {
            InitializeComponent();
            _p = new People();
        }

        private void textBox__xm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    if (this.textBox_xm.TextLength < 1)
                        return;

                    string s = string.Format("select bh,jf from people where xm='{0}'", this.textBox_xm.Text);
                    Form_main.Command.CommandText = s;
                    MySqlDataAdapter a = new MySqlDataAdapter(Form_main.Command);
                    DataTable dt = new DataTable();
                    a.Fill(dt);
                    if(dt.Rows.Count == 1)
                    {
                        this.DialogResult = DialogResult.OK;
                        p.bh = dt.Rows[0][0].ToString();
                        p.xm = this.textBox_xm.Text;
                        p.jf = int.Parse(dt.Rows[0][1].ToString());
                        this.Close();
                    }
                     else if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("无此会员！");
                        this.textBox_xm.SelectAll();
                    } 
                    else if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("两个以上会员同名！");
                        this.textBox_xm.SelectAll();
                    }                              
                    break;

                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        private void textBox_dh_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    if (this.textBox_dh.TextLength != 11)
                    {
                        MessageBox.Show("手机号码为11位！");
                        this.textBox_dh.SelectAll();
                        return;
                    }

                    string s = string.Format("select bh,xm,jf from people where dh='{0}'", this.textBox_dh.Text);
                    Form_main.Command.CommandText = s;
                    MySqlDataAdapter a = new MySqlDataAdapter(Form_main.Command);
                    DataTable dt = new DataTable();
                    a.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        this.DialogResult = DialogResult.OK;
                        p.bh = dt.Rows[0][0].ToString();
                        p.xm = dt.Rows[0][1].ToString();
                        p.jf = int.Parse(dt.Rows[0][2].ToString());
                        this.Close();
                    }
                    else if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("据此手机号找不到会员！");
                        this.textBox_xm.SelectAll();
                    }                    
                    break;

                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_main main = this.Owner as Form_main;
            
        }
    }
}
