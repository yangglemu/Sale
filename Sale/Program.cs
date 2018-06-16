using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Xml;
using System.Drawing.Printing;

namespace Sale
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\yuan.xml");
            XmlNode root = doc.SelectSingleNode("config");
            string s = string.Format("data source={0};user id={1};password={2};database={3}",
                root.SelectSingleNode("ip").InnerText,
                root.SelectSingleNode("user").InnerText,
                root.SelectSingleNode("password").InnerText,
                root.SelectSingleNode("database").InnerText);
            try
            {
                Form_main.Connection = new MySqlConnection(s);
                Form_main.Connection.Open();
                Form_main.Command = new MySqlCommand();
                Form_main.Command.Connection = Form_main.Connection;
                //Form_main.Command.CommandText = "set names utf8";
                //Form_main.Command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("连接到门店电脑数据库时错误！\r\n网络是否正常？", "连接错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            XmlNode temp = root.SelectSingleNode("/config/font/title");
            Form_main.title = new Font(temp.InnerText, float.Parse(temp.Attributes["size"].Value));
            temp = root.SelectSingleNode("/config/font/font");
            Form_main.font = new Font(temp.InnerText, float.Parse(temp.Attributes["size"].Value));
            temp = root.SelectSingleNode("/config/font/height");
            Form_main.fontHeight = float.Parse(temp.InnerText);
            temp = root.SelectSingleNode("/config/position/x1");
            Form_main.x1 = float.Parse(temp.InnerText);
            temp = root.SelectSingleNode("/config/position/x2");
            Form_main.x2 = float.Parse(temp.InnerText);
            temp = root.SelectSingleNode("/config/position/x3");
            Form_main.x3 = float.Parse(temp.InnerText);
            var mf = new Form_main();
            mf.windowtitle = root.SelectSingleNode("/config/name").InnerText;
            mf.address = root.SelectSingleNode("/config/address").InnerText;
            var name = root.SelectSingleNode("/config/printer").InnerText;
            if (name != null)
            {
                foreach (string n in PrinterSettings.InstalledPrinters)
                {
                    if (name == n)
                    {
                        Form_main.printerName = name;
                        break;
                    }
                }
            }
            Application.Run(mf);
        }
    }
}
