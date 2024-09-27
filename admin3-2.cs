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
    public partial class admin3_2 : Form
    {
        string ID = "";
        public admin3_2()
        {
            InitializeComponent();
        }

        #region 封装数据
        public admin3_2(string id, string name, string gender, string psw, string level)
        {
            InitializeComponent();
            ID = textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = gender;
            textBox4.Text = psw;
            textBox5.Text = level;
        }
        #endregion

        #region 修改读者信息
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update T_User set id = '{textBox1.Text}',[name]='{textBox2.Text}',gender='{textBox3.Text}',psw='{textBox4.Text}',level='{textBox5.Text}' where id = '{ID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        } 
        #endregion

        private void admin3_2_Load(object sender, EventArgs e)
        {

        }
    }
}
