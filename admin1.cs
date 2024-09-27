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
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        #region 图书管理跳转事件
        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin2 admin = new admin2();
            admin.ShowDialog();
        } 
        #endregion

        private void admin1_Load(object sender, EventArgs e)
        {

        }

        #region 退出窗体
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 读者管理
        private void 读者管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin3 admin = new admin3();
            admin.ShowDialog();
        } 
        #endregion

        #region 借阅查询
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin4_1 admin = new admin4_1();
            admin.ShowDialog();
        }
        #endregion

        #region 密码修改
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminpassword admin = new adminpassword();
            admin.ShowDialog();
            this.Close();
        } 
        #endregion
    }
}
