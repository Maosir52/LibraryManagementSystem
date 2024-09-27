using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class admin2_2 : Form
    {
        string ID = "";
        public admin2_2()
        {
            InitializeComponent();
        }

        #region 封装数据
        public admin2_2(string id, string name, string author, string press, string number, string blevel)
        {
            InitializeComponent();
            ID = textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = author;
            textBox4.Text = press;
            textBox5.Text = number;
            textBox6.Text = blevel;
        } 
        #endregion

        #region 修改部分
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update T_book set id = '{textBox1.Text}',[name]='{textBox2.Text}',author='{textBox3.Text}',press='{textBox4.Text}',number={textBox5.Text},blevel={textBox6.Text} where id = '{ID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        } 
        #endregion

        private void admin2_2_Load(object sender, EventArgs e)
        {

        }
    }
}
