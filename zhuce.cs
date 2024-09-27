using Microsoft.TeamFoundation.Build.WebApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class zhuce : Form
    {
        public zhuce()
        {
            InitializeComponent();
        }

        #region 注册事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-DB9N8TQ;Initial Catalog=MyDataBase;Integrated Security=True");
                Dao dao = new Dao();
                sqlConn.Open();

                string sql = $"insert into T_user values(((select max(id)as maxid from T_user)+1),'{textBox2.Text}','{textBox3.Text}','{textBox4.Text}',1)";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                sqlConn.Close();
                return;
            }
            else
            {
                MessageBox.Show("输入不允许有空项");
            }
        } 
        #endregion

    }
}
