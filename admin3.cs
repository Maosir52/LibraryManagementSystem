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
    public partial class admin3 : Form
    {
        public admin3()
        {
            InitializeComponent();
            Table();
        }

        #region Table()方法 - 将数据库中的数据显示在dataGridView中
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from T_User";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        #endregion

        #region admin3窗体运行时默认执行的操作
        private void admin3_Load(object sender, EventArgs e)
        {
            Table();
        }
        #endregion

        #region 新增读者事件
        private void button1_Click(object sender, EventArgs e)
        {
            admin3_1 admin = new admin3_1();
            admin.ShowDialog();
        }
        #endregion

        #region 修改读者事件
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                #region 封装数据
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string gender = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string psw = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string level = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                #endregion
                admin3_2 admin = new admin3_2(id, name, gender, psw, level);
                admin.ShowDialog();
                Table();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }
        #endregion

        #region 删除读者事件
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();    //获取书号
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from T_User where id ='{id}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }
                }
            }
            catch
            {
                MessageBox.Show("请先在表格中选中要删除的图书记录！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 查询读者事件
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from T_User";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        #endregion

        #region 点击dataGridView时将被选中的读者显示在label中
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        } 
        #endregion
    }
}
