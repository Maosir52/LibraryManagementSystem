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
    public partial class userpassword : Form
    {
        public userpassword()
        {
            InitializeComponent();
        }

        #region 修改密码事件
        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = $"update T_User set psw = '{textBox1.Text}' where id = '{data.UID}'";
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show(data.UID + data.UName + "修改密码成功");
                this.Close();
            }
        } 
        #endregion

        #region 键盘按下事件
        private void userpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        } 
        #endregion
    }
}
