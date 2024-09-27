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
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
        }

        #region 跳转至图书查看与借阅窗口
        private void 图书查看和借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user2 user1 = new user2();
            user1.ShowDialog();
        }
        #endregion

        #region 查看当前借出图书和归还图书
        private void 当前借出图书和归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user3 user1 = new user3();
            user1.ShowDialog();
        }
        #endregion

        #region 帮助
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HELP");
        }
        #endregion

        #region 退出
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 跳转至修改密码窗口
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userpassword user = new userpassword();
            user.ShowDialog();
            this.Close();
        } 
        #endregion

    }
}
