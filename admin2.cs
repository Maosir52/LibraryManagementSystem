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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }

        #region admin2启动时默认运行方法
        private void admin2_Load(object sender, EventArgs e)
        {
            Table();    //跳转到Table()方法
            #region 获取书号
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            #endregion
        }
        #endregion

        #region Table()方法 - 查询数据库中的数据显示在dataGridView中
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from T_book";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        #endregion

        #region 按照书号来显示数据代码
        public void TableID()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from T_book where id='{textBox1.Text}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        #endregion

        #region 按照书名来显示数据代码
        public void TableName()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from T_book where name like '%{textBox2.Text}%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        #endregion

        #region 添加图书事件
        private void button1_Click(object sender, EventArgs e)
        {

            admin2_1 admin2 = new admin2_1();
            admin2.ShowDialog();
            Table();
        }
        #endregion

        #region 删除图书事件
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();    //获取书号
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from T_book where id ='{id}'";
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

        #region 将所选中的图书信息显示在Label中
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();    //获取书号
        }
        #endregion

        #region 修改图书事件
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                #region 封装数据
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string press = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string blevel = dataGridView1.SelectedRows[0].Cells[5].Value.ToString(); 
                #endregion
                admin2_2 admin = new admin2_2(id, name, author, press, number, blevel);
                admin.ShowDialog();
                Table();//刷新数据
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        #endregion

        #region 清空文本框
        private void button4_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        #endregion

        #region 执行按照书号查询事件
        private void button5_Click(object sender, EventArgs e)
        {
            TableID();
        }
        #endregion

        #region 执行按照书名查询事件
        private void button6_Click(object sender, EventArgs e)
        {
            TableName();
        } 
        #endregion
    }
}
