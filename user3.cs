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
    public partial class user3 : Form
    {
        public user3()
        {
            InitializeComponent();
            Table();
        }

        #region 将数据库读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();            
            Dao dao = new Dao();                   
            string sql = $"select [no],[bid],[datetime] from T_lend where [uid]='{data.UID}'";   
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        } 
        #endregion

        private void user3_Load(object sender, EventArgs e)
        {

        }

        #region 归还图书事件
        private void button1_Click(object sender, EventArgs e)
        {
            #region 封装数据
            string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            #endregion
            string sql = $"delete from T_lend where [no]={no};update T_book set number = number + 1 where id='{id}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 1)
            {
                MessageBox.Show("归还成功");
                Table();
            }
        } 
        #endregion
    }
}
