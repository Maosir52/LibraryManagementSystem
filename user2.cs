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
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
            Table();
        }

        #region 在user2窗体运行时执行从数据库中获取读者权限等级显示在Label中
        private void user2_Load(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql1 = $"select level from T_user where id = '{data.UID}'";
            IDataReader dc = dao.read(sql1);
            if (dc.Read())
            {
                string cx = dc["level"].ToString();
                label4.Text = cx;
            }
            else
            {
                MessageBox.Show("cw");
            }
        } 
        #endregion

        #region 在Label中显示被选中的图书
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();    //获取书号
        } 
        #endregion

        #region 将数据库读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select level from T_user where id = '{data.UID}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                string cx = dc["level"].ToString();
                int i = Convert.ToInt32(cx);
                #region 根据读者权限等级显示筛选图书
                switch (i)
                {
                    case 1:
                        string sql2 = $"select * from T_book where blevel = 1";
                        IDataReader bk = dao.read(sql2);
                        while (bk.Read())
                        {
                            dataGridView1.Rows.Add(bk["id"].ToString(), bk["name"].ToString(), bk["author"].ToString(), bk["press"].ToString(), bk["number"].ToString(), bk["blevel"].ToString());
                        }
                        break;
                    case 2:
                        string sql3 = $"select * from T_book where blevel = 1 or blevel = 2";
                        IDataReader bk2 = dao.read(sql3);
                        while (bk2.Read())
                        {
                            dataGridView1.Rows.Add(bk2[0].ToString(), bk2[1].ToString(), bk2[2].ToString(), bk2[3].ToString(), bk2[4].ToString(), bk2["blevel"].ToString());
                        }
                        break;
                    case 3:
                        string sql4 = $"select * from T_book";
                        IDataReader bk3 = dao.read(sql4);
                        while (bk3.Read())
                        {
                            dataGridView1.Rows.Add(bk3[0].ToString(), bk3[1].ToString(), bk3[2].ToString(), bk3[3].ToString(), bk3[4].ToString(), bk3["blevel"].ToString());
                        }
                        break;
                    default:
                        MessageBox.Show("无法访问");
                        break;
                }
                #endregion
            }
            dc.Close();
            dao.DaoClose();
        } 
        #endregion

        #region 借阅图书事件
        private void button1_Click(object sender, EventArgs e)
        {
            #region 封装数据
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());    //库存 
            #endregion
            if (number < 1)
            {
                MessageBox.Show("库存不足，请联系管理员购入");
            }
            else
            {
                string sql = $"insert into T_lend ([uid],bid,[datetime]) values('{data.UID}','{id}',getdate());update T_book set number = number-1 where id='{id}'";
                Dao dao = new Dao();
                if (dao.Execute(sql) > 1)   //执行两条sql,大于1才是都成功
                {
                    MessageBox.Show($"用户:{data.UName}借出了图书{id}{name}!");
                    Table();
                }
            }
        } 
        #endregion

        #region 书号查询事件
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

        #region 书名查询事件
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

        #region 按照书号来查询
        private void button2_Click(object sender, EventArgs e)
        {
            TableID();
        } 
        #endregion

        #region 按照书名来查询
        private void button3_Click(object sender, EventArgs e)
        {
            TableName();
        } 
        #endregion

        #region 刷新
        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        } 
        #endregion
    }
}
