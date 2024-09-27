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
    public partial class admin2_1 : Form
    {
        public admin2_1()
        {
            InitializeComponent();
        }

        #region 新增图书事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-DB9N8TQ;Initial Catalog=MyDataBase;Integrated Security=True");
                Dao dao = new Dao();
                sqlConn.Open();
                string sqlcx = $"select * from T_book where id='{textBox1.Text}'";
                SqlCommand sqlCmd = new SqlCommand(sqlcx, sqlConn);
                Object o = sqlCmd.ExecuteScalar();
                if (o == null)
                {
                    string sql = $"insert into T_book values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')";
                    int n = dao.Execute(sql);
                    if (n > 0)
                    {
                        MessageBox.Show("添加成功");
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
                else
                {
                    MessageBox.Show("此id已存在");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
                sqlConn.Close();
                return;
            }
            else
            {
                MessageBox.Show("输入不允许有空项");
            }
        } 
        #endregion

        #region 清空所有文本框
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        } 
        #endregion

        private void admin2_1_Load(object sender, EventArgs e)
        {

        }
    }
}
