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
    public partial class adminpassword : Form
    {
        public adminpassword()
        {
            InitializeComponent();
        }

        #region 修改密码
        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = $"update T_admin set psw = '{textBox1.Text}' where id = 'admin'";
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show(data.AID + "密码修改成功");
                this.Close();
            }
        }
        #endregion

        #region 按下Enter键触发事件
        private void adminpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        } 
        #endregion
    }
}
