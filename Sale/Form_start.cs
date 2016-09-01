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
    public partial class Form_start : Form
    {
        MySqlConnection conn;
        MySqlCommand comm;
        
        public Form_start()
        {
            InitializeComponent();
        }

        private void Form_start_Load(object sender, EventArgs e)
        {
            conn = Form_main.Connection;
            comm = Form_main.Command;
            comm.CommandText = "select bh,xm,mm from worker";
            MySqlDataReader dr = comm.ExecuteReader();
            while(dr.Read())
            {
                Worker w = new Worker();
                w.bh = dr.GetString(0);
                w.xm = dr.GetString(1);
                w.mm = dr.GetString(2);
                this.comboBox1.Items.Add(w);
            }
            dr.Close();
            if (this.comboBox1.Items.Count > 0)
                this.comboBox1.SelectedIndex = 0;
            this.textBox1.Select();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Return:
                    if (true/*this.textBox1.TextLength == 6*/)
                    {
                        if (comboBox1.SelectedIndex < 0)
                        {
                            MessageBox.Show("帐号选择错误！");
                            return;
                        }
                        Worker w = comboBox1.SelectedItem as Worker;
                        if(true/*w.mm == textBox1.Text*/)
                        {
                            Form_main f = this.Owner as Form_main;
                            f.worker = w;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    break;
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                    break;

                default:
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Select();
        }
    }
}
