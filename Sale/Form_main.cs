﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;

namespace Sale
{
    public partial class Form_main : Form
    {
        public PrintDocument printer;
        private bool isHuiYuan;               //当前客户是否会员
        public bool isPrint;                 //是否打印小票
        private string hyxm;                   //会员姓名
        private int hyjf;                     //会员积分
        private string zqfs;
        private string hybh;
        private string _djh;
        public float _ss;
        public float _zl;
        private Worker _worker;                 //员工
        private string not_hy = "当前顾客是否会员【否】";
        public static MySqlConnection Connection;
        public static MySqlCommand Command;
        public static Font title;
        public static Font font;
        public static float fontHeight;
        public static float x1;
        public static float x2;
        public static float x3;
        private const string windowtitle = "阳光服饰收银系统";
        public Worker worker
        {
            get { return _worker; }
            set { _worker = value; this.Text = windowtitle + "-[" + value.xm + "]"; }
        }

        public Form_main()
        {
            InitializeComponent();

            isHuiYuan = false;
            this.hybh = "no";
            this.zqfs = "折扣";
            this.isPrint = true;

            printer = new PrintDocument();
            printer.PrintController = new StandardPrintController();
            printer.DocumentName = "收银小票";
            printer.PrintPage += printer_PrintPage;
        }

        public void DrawLine(Graphics g, float x, float y)
        {
            g.DrawString("---------------------------", Form_main.font, Brushes.Black, x, y);
        }
        void printer_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (dataGridView.RowCount < 1)
                return;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Pen p = new Pen(Brushes.Black, 0.5f);
            p.DashStyle = DashStyle.Dash;
            //Font font_title = new Font("宋体", 14.0f);//标题
            //Font font = new Font("宋体", 9.0f);//内容    
            float width = 56.0f;        //纸张宽度mm
            float rh = 4.5f;            //行距
            float x, y;                 //绘制时的起始坐标
            y = 0.0f;

            string title = "阳光服饰";
            x = e.Graphics.MeasureString(title, Form_main.title).Width;
            x = (width - x) / 2f - 2f;
            e.Graphics.DrawString(title, Form_main.title, Brushes.Black, x, y);
            //拉高字体
            //e.Graphics.ScaleTransform(1f, Form_main.fontHeight);

            x = 0.0f;
            y += rh + 0.5f;
            string dj = "单号: " + this._djh;
            e.Graphics.DrawString(dj, Form_main.font, Brushes.Black, x, y);//单据号

            y += rh;
            e.Graphics.DrawLine(p, x, y, width - x, y);//划线
            //this.DrawLine(e.Graphics, x, y);
            for (int i = 0; i < this.dataGridView.RowCount; i++)
            {
                //y += 0.5f;
                DataGridViewRow r = this.dataGridView.Rows[i];
                //单行绘制品名
                e.Graphics.DrawString((i + 1).ToString() + "." +
                    r.Cells[1].Value.ToString(),
                    Form_main.font, Brushes.Black, x, y);
                float addx = 24f;
                //if (r.Cells[1].Value.ToString().Length > 6)
                //    addx = 26f;
                e.Graphics.DrawString(r.Cells[0].Value.ToString(),
                    Form_main.font, Brushes.Black, x + addx, y);

                y += 4.0f;
                e.Graphics.DrawString("单价", font, Brushes.Black, x, y);
                e.Graphics.DrawString("折扣", font, Brushes.Black, x + x1, y);
                e.Graphics.DrawString("数量", font, Brushes.Black, x + x2, y);
                e.Graphics.DrawString("金额", font, Brushes.Black, x + x3, y);

                y += 4.0f;
                //sj
                e.Graphics.DrawString(this.dataGridView.Rows[i].Cells[2].Value.ToString(), font, Brushes.Black, x, y);
                //zq
                e.Graphics.DrawString(this.dataGridView.Rows[i].Cells[3].Value.ToString(), font, Brushes.Black, x + x1, y);
                //sl
                e.Graphics.DrawString(this.dataGridView.Rows[i].Cells[4].Value.ToString(), font, Brushes.Black, x + x2 + 2.5f, y);
                //je
                e.Graphics.DrawString(this.dataGridView.Rows[i].Cells[5].Value.ToString(), font, Brushes.Black, x + x3 - 0.8f, y);
                if (i != this.dataGridView.RowCount - 1)
                {
                    y += rh;
                    e.Graphics.DrawLine(p, x, y, width - x, y);
                }
            }
            y += rh;
            e.Graphics.DrawLine(p, x, y, width - x, y);//划线
            if (this.isHuiYuan)
            {
                e.Graphics.DrawString("会员：" + this.hyxm, font, Brushes.Black, x, y);
                e.Graphics.DrawString("积分：" + this.hyjf.ToString(), font, Brushes.Black, x + 24.0f, y);
                y += 4.0f;
            }
            float yszl = x + x2;
            //if (this.textBox_je.TextLength > 3)
            //    yszl = x + x2;
            e.Graphics.DrawString("合计：" + this.textBox_js.Text + "件", font, Brushes.Black, x, y);
            e.Graphics.DrawString("应收：" + this.textBox_je.Text, font, Brushes.Black, yszl, y);

            y += 4.0f;
            e.Graphics.DrawString("实收：" + this._ss.ToString("0.00"), font, Brushes.Black, x, y);
            e.Graphics.DrawString("找零：" + this._zl.ToString("0.00"), font, Brushes.Black, yszl, y);

            y += 4.0f;
            e.Graphics.DrawString("收银：" + this.worker.bh, font, Brushes.Black, x, y);//收银员

            e.Graphics.DrawString("地址：天门多宝", font, Brushes.Black, yszl, y);

            y += rh;
            title = "---凭此小票退换货---";
            x = e.Graphics.MeasureString(title, font).Width;
            x = (width - x) / 2f - 2f;
            e.Graphics.DrawString(title, font, Brushes.Black, x, y);
        }

        private void textBox_tm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //回车键
                case Keys.Enter:
                    this.KeyEnter();
                    break;
                //删除表格中最后一行，如果表格为空，则清空会员信息
                case Keys.Delete:
                    if (this.textBox_tm.TextLength == 0)
                    {
                        if (this.dataGridView.RowCount > 0)
                        {
                            this.dataGridView.Rows.RemoveAt(this.dataGridView.RowCount - 1);
                            this.Add();
                        }
                        else
                        {
                            if (this.isHuiYuan)
                            {
                                this.ClearPeople();
                            }
                        }
                    }
                    break;
                //F12 是否打印切换
                case Keys.F12:
                    isPrint = !isPrint;
                    if (isPrint)
                        this.toolStripStatusLabel2.Text = "是否打印小票【是】";
                    else
                        this.toolStripStatusLabel2.Text = "是否打印小票【否】";
                    break;

                //F10 更换收银员，此一功能针对一单笔中的一种商品而使用
                case Keys.F10:
                    Form_start f = new Form_start();
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        this.toolStripStatusLabel1.Text = string.Format("当前收银员【{0}】", worker.xm);
                    }
                    break;

                //删除表格中的指定行    
                case Keys.F11:
                    if (this.dataGridView.RowCount > 0)
                    {
                        this.dataGridView.Select();
                        this.dataGridView.CurrentCell = this.dataGridView.Rows[0].Cells[0];
                    }
                    break;
                // 退货操作
                case Keys.T:
                    TuiHuo(e);
                    break;
                //增加商品数量
                case Keys.J:
                    EditDataGridViewCurrentCroSL(e);
                    break;
                //编号商品金额
                case Keys.E:
                    EditJE(e);
                    break;

                case Keys.Z:
                    EditGoodsZQ(e);
                    break;

                case Keys.H:
                    if (e.Control)
                    {
                        Form_find_people people = new Form_find_people();
                        if (people.ShowDialog(this) == DialogResult.OK)
                        {
                            this.hybh = people.p.bh;
                            this.hyxm = people.p.xm;
                            this.hyjf = people.p.jf;
                            this.isHuiYuan = true;
                            this.zqfs = "会员";
                            this.statusLabel_huiyuan.Text = "当前顾客是否会员【是】,姓名【" + hyxm + "】,积分【" + hyjf.ToString() + "】";
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void EditGoodsZQ(KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.dataGridView.CurrentRow != null)
                {

                    Form_edit_je f = new Form_edit_je();
                    f.Text = "修改折扣";
                    DataGridViewRow row = this.dataGridView.CurrentRow;
                    f.yje = float.Parse(row.Cells[3].Value.ToString());

                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        float sj = float.Parse(row.Cells[2].Value.ToString());
                        int sl = int.Parse(row.Cells[4].Value.ToString());
                        float je = sj * sl * f.xje;
                        je = (float)Math.Round(je, 0, MidpointRounding.AwayFromZero);
                        row.Cells[3].Value = f.xje.ToString("0.00");// 新折扣
                        row.Cells[5].Value = je.ToString("0.00");//更新金额
                        this.Add();
                    }
                }
            }
        }

        private void EditJE(KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.dataGridView.CurrentRow != null)
                {

                    Form_edit_je f = new Form_edit_je();
                    DataGridViewRow row = this.dataGridView.CurrentRow;
                    //原金額 
                    f.yje = float.Parse(row.Cells[5].Value.ToString());

                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        int sl = int.Parse(row.Cells[4].Value.ToString());
                        float sj = float.Parse(row.Cells[2].Value.ToString());
                        float je = f.xje / sl;
                        float zq = je / sj;
                        row.Cells[3].Value = zq.ToString("0.00");
                        //現金額
                        row.Cells[5].Value = Math.Round(f.xje, 0, MidpointRounding.AwayFromZero).ToString("0.00");
                        this.Add();
                    }
                }
            }
        }

        private void EditDataGridViewCurrentCroSL(KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.dataGridView.CurrentRow != null)
                {
                    DataGridViewRow row = this.dataGridView.CurrentRow;
                    if (row == null)
                        return;
                    int sl = int.Parse(row.Cells[4].Value.ToString());
                    if (sl > 0)
                    {
                        ++sl;
                        float je;
                        float sj = float.Parse(row.Cells[2].Value.ToString());
                        float zq = float.Parse(row.Cells[3].Value.ToString());
                        je = sl * sj * zq;
                        je = (float)Math.Round(je, 0, MidpointRounding.AwayFromZero);
                        row.Cells[4].Value = sl;
                        row.Cells[5].Value = je.ToString("0.00");
                        this.Add();
                    }
                }
            }
        }

        private void TuiHuo(KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.dataGridView.CurrentRow != null)
                {
                    DataGridViewRow row = this.dataGridView.CurrentRow;
                    int sl = int.Parse(row.Cells[4].Value.ToString());
                    if (sl > 0)
                    {
                        sl = -sl;
                        float je;
                        float sj = float.Parse(row.Cells[2].Value.ToString());
                        float zq = float.Parse(row.Cells[3].Value.ToString());
                        je = sl * sj * zq;
                        je = (float)Math.Round(je, 0, MidpointRounding.AwayFromZero);
                        row.Cells[4].Value = sl;
                        row.Cells[5].Value = je.ToString("0.00");
                        this.Add();
                    }
                }
            }
        }
        public bool IsTmInTable(string tm)
        {
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                //tm
                string s = row.Cells[0].Value.ToString();
                if (s == tm)
                {
                    //sl
                    int sl = int.Parse(row.Cells[4].Value.ToString());
                    if (sl > 0)
                    {
                        ++sl;
                        //sj
                        float sj = float.Parse(row.Cells[2].Value.ToString());
                        //zq
                        float zq = float.Parse(row.Cells[3].Value.ToString());
                        float je = sj * zq * sl;
                        je = (float)Math.Round(je, 0, MidpointRounding.AwayFromZero);
                        row.Cells[4].Value = sl.ToString();
                        //je
                        row.Cells[5].Value = je.ToString("0.00");
                        this.Add();
                        this.textBox_tm.Clear();
                        return true;
                    }
                }
            }
            return false;
        }
        private void KeyEnter()
        {

            if (this.textBox_tm.TextLength == 0 && this.dataGridView.RowCount > 0)
            {
                ShouYing();
                return;
            }
            switch (textBox_tm.TextLength)
            {
                //会员卡条码，如果是会员，则填充会员信息(会员折扣/积分/姓名/编号)
                case 7:
                case 8:
                    Form_main.Command.CommandText = "select ifnull(count(*),0) from people where bh='" + this.textBox_tm.Text + "'";
                    int count = int.Parse(Form_main.Command.ExecuteScalar().ToString());
                    if (count == 1)
                    {
                        this.isHuiYuan = true;
                        this.zqfs = "会员";
                        this.hybh = this.textBox_tm.Text;
                        Form_main.Command.CommandText = "select xm,jf from people where bh='" + this.hybh + "'";
                        MySqlDataReader dr = Form_main.Command.ExecuteReader();
                        dr.Read();
                        this.hyxm = dr.GetString(0);
                        this.hyjf = dr.GetInt32(1);
                        this.statusLabel_huiyuan.Text = "当前顾客是否会员【是】,姓名【" + hyxm + "】,积分【" + hyjf.ToString() + "】";
                        this.textBox_tm.Clear();
                        dr.Close();

                        foreach (DataGridViewRow row in this.dataGridView.Rows)
                        {
                            Form_main.Command.CommandText = "select hyzq from goods where tm='" + row.Cells[0].Value.ToString() + "'";
                            float hyzq = float.Parse(Form_main.Command.ExecuteScalar().ToString());
                            row.Cells[3].Value = hyzq.ToString("0.00");//hyzq
                            row.Cells[5].Value = (float.Parse(row.Cells[2].Value.ToString()) * (float.Parse(row.Cells[4].Value.ToString())) * hyzq).ToString("0.00");//je折后价 sj*sl*hyzq            
                        }
                        this.Add();
                    }
                    else
                    {
                        MessageBox.Show("无此会员！");
                        textBox_tm.SelectAll();
                    }
                    break;
                //如果是商品条码，则向表格中添加销售数据行
                case 1:
                case 2:
                case 3:
                case 9:
                case 13:
                    if (this.IsTmInTable(this.textBox_tm.Text))
                        break;
                    if (this.isHuiYuan)
                        Form_main.Command.CommandText = "select tm,pm,sj,hyzq from goods where tm=";
                    else
                        Form_main.Command.CommandText = "select tm,pm,sj,zq from goods where tm=";
                    Form_main.Command.CommandText += "'" + this.textBox_tm.Text + "'";

                    MySqlDataReader reader = Form_main.Command.ExecuteReader();
                    if (reader.Read())
                    {
                        int index = this.dataGridView.Rows.Add();
                        DataGridViewRow row = this.dataGridView.Rows[index];
                        row.Cells[0].Value = reader.GetString(0);//tm
                        row.Cells[1].Value = reader.GetString(1);//pm
                        row.Cells[2].Value = reader.GetFloat(2).ToString("0.00");//sj
                        row.Cells[3].Value = reader.GetFloat(3).ToString("0.00");//zq/hyzq
                        row.Cells[4].Value = 1;//sl
                        row.Cells[5].Value = (reader.GetFloat(2) * reader.GetFloat(3)).ToString("0.00");//je折后价
                        row.Cells[6].Value = worker.bh;//收银员
                        this.dataGridView.CurrentCell = this.dataGridView.Rows[this.dataGridView.RowCount - 1].Cells[0];
                        this.textBox_tm.Clear();
                        this.Add();
                    }
                    else
                    {
                        MessageBox.Show("无此商品！", "友情提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.textBox_tm.SelectAll();
                    }
                    reader.Close();
                    break;
                default:
                    this.textBox_tm.SelectAll();
                    break;
            }
        }


        public void Print()
        {

            //PrintPreviewDialog f = new PrintPreviewDialog();
            //f.Document = printer;
            // f.TopMost = true;
            //  f.ShowDialog(this);

            printer.Print();
        }
        /// <summary>
        /// 打开收银窗口
        /// </summary>
        private void ShouYing()
        {
            //收银窗口
            Form_shouying sy = new Form_shouying();
            sy.js = int.Parse(this.textBox_js.Text);//总件数
            sy.ys = float.Parse(this.textBox_je.Text);//应收金额
            sy.ShowDialog(this);
        }

        /// <summary>
        /// 插入数据库
        /// </summary>
        public void InsertIntoDatabase()
        {
            MySqlTransaction transaction = Form_main.Connection.BeginTransaction();

            string djh;//编号max
            int bh;
            try
            {
                Form_main.Command.CommandText = "select ifnull(max(bh),0)+1 from sale_db where(date(rq)='" + DateTime.Today.ToShortDateString() + "')";
                djh = Form_main.Command.ExecuteScalar().ToString();
                bh = int.Parse(djh);
                //尾数编号为三位数
                djh = bh.ToString("000");
                this._djh = djh = DateTime.Now.ToString("yyyyMMddHHmmss") + djh;

                //插入sale_db销售单笔表
                Form_main.Command.CommandText = "insert into sale_db(djh,sl,je,ss,zl,bh,hy,rq,syy) values(";
                Form_main.Command.CommandText += "'" + djh + "',";
                Form_main.Command.CommandText += this.textBox_js.Text + ",";
                Form_main.Command.CommandText += this.textBox_je.Text + ",";
                Form_main.Command.CommandText += this._ss.ToString("0.00") + ",";
                Form_main.Command.CommandText += this._zl.ToString("0.00") + ",";
                Form_main.Command.CommandText += bh.ToString() + ",";
                Form_main.Command.CommandText += "'" + this.hybh + "',";
                Form_main.Command.CommandText += "'" + DateTime.Now.ToString() + "',";
                Form_main.Command.CommandText += "'" + this.worker.bh + "')";
                Form_main.Command.ExecuteNonQuery();

                //插入sale_mx销售明细表                   
                foreach (DataGridViewRow row in this.dataGridView.Rows)
                {
                    Form_main.Command.CommandText = "insert into sale_mx(djh,tm,sl,sj,je,zq,zqfs,syy) values(";
                    Form_main.Command.CommandText += "'" + djh + "',";//djh
                    Form_main.Command.CommandText += "'" + row.Cells[0].Value.ToString() + "',";//tm
                    Form_main.Command.CommandText += row.Cells[4].Value.ToString() + ",";//sl
                    Form_main.Command.CommandText += row.Cells[2].Value.ToString() + ",";//sj
                    Form_main.Command.CommandText += row.Cells[5].Value.ToString() + ",";//je
                    Form_main.Command.CommandText += row.Cells[3].Value.ToString() + ",";//zq
                    Form_main.Command.CommandText += "'" + this.zqfs + "',";//zqfs
                    Form_main.Command.CommandText += "'" + row.Cells[6].Value.ToString() + "')";//syy

                    Form_main.Command.ExecuteNonQuery();
                    //减库存
                    Form_main.Command.CommandText = string.Format("update goods set kc=kc-{0} where tm='{1}'",
                        row.Cells[4].Value.ToString(), row.Cells[0].Value.ToString());

                    Form_main.Command.ExecuteNonQuery();
                }

                //插入huiyuan会员表（积分）
                if (this.isHuiYuan)
                {
                    this.hyjf += (int)float.Parse(this.textBox_je.Text);
                    Form_main.Command.CommandText = "update people set jf=" + this.hyjf.ToString() + ", ";
                    Form_main.Command.CommandText += "ljxf=ljxf+" + this.textBox_je.Text + " ";
                    Form_main.Command.CommandText += "where bh='" + this.hybh + "'";
                    Form_main.Command.ExecuteNonQuery();
                }
            }
            catch (Exception se)
            {
                transaction.Rollback();
                MessageBox.Show(se.Message, "提交数据库时出错");
                return;
            }
            //提交事务
            transaction.Commit();
        }

        public void ResetData()
        {
            //清理环境
            this.dataGridView.Rows.Clear();
            this.textBox_js.Text = "";
            this.textBox_je.Text = "";
            this.zqfs = "折扣";
            this.statusLabel_huiyuan.Text = this.not_hy;

        }
        public void ClearPeople()
        {
            this.isHuiYuan = false;
            this.hyjf = 0;
            this.hybh = "no";
            this.hyxm = "";
            this.zqfs = "折扣";
            this.statusLabel_huiyuan.Text = this.not_hy;
        }
        //对表格进行累计
        private void Add()
        {
            int js = 0;
            float je = 0.0f;
            for (int i = 0; i < this.dataGridView.RowCount; i++)
            {
                js += int.Parse(this.dataGridView.Rows[i].Cells[4].Value.ToString());
                je += float.Parse(this.dataGridView.Rows[i].Cells[5].Value.ToString());
            }
            //四舍五入
            je = (float)Math.Round(je, 0, MidpointRounding.AwayFromZero);
            this.textBox_js.Text = js.ToString();
            this.textBox_je.Text = je.ToString("0.00");
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            this.statusLabel_huiyuan.Text = this.not_hy;
            this.toolStripStatusLabel1.Text = "当前收银员【未登录】";
            this.toolStripStatusLabel2.Text = "是否打印小票【";
            if (isPrint)
                this.toolStripStatusLabel2.Text += "是】";
            else
                this.toolStripStatusLabel2.Text += "否】";
        }

        private void Form_main_Shown(object sender, EventArgs e)
        {

            Form_start f = new Form_start();
            if (f.ShowDialog(this) != DialogResult.OK)
                this.Close();

            this.toolStripStatusLabel1.Text = string.Format("当前收银员【{0}", worker.xm + "】");
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                case Keys.Return:
                    if (this.dataGridView.RowCount > 0)
                    {
                        this.dataGridView.CurrentCell = this.dataGridView.Rows[this.dataGridView.RowCount - 1].Cells[0];
                    }
                    this.textBox_tm.Select();
                    e.Handled = true;
                    break;

                //删除当前行
                case Keys.Delete:
                    if (this.dataGridView.RowCount > 0)
                    {
                        DataGridViewRow currentRow = this.dataGridView.CurrentRow;
                        if (currentRow != null)
                        {
                            this.dataGridView.Rows.Remove(currentRow);
                            this.Add();
                        }
                    }
                    else
                    {
                        this.statusLabel_huiyuan.Text = this.not_hy;
                        this.isHuiYuan = false;
                        this.hyjf = 0;
                        this.hybh = "";
                        this.hyxm = "";
                        this.textBox_tm.Select();
                    }
                    break;

                case Keys.T:
                    this.TuiHuo(e);
                    break;

                case Keys.J:
                    this.EditDataGridViewCurrentCroSL(e);
                    break;

                case Keys.E:
                    this.EditJE(e);
                    break;

                case Keys.Z:
                    this.EditGoodsZQ(e);
                    break;

                default:
                    break;
            }
        }

        private void AddRowHeaderValue()
        {
            for (int i = 0; i < this.dataGridView.RowCount; i++)
            {
                this.dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.AddRowHeaderValue();
        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.AddRowHeaderValue();
        }

        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_main.Connection.Close();
        }
    }
}