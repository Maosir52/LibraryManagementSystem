using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Dao
    {
        SqlConnection sc;
        #region 数据库的连接字符串和开启数据库连接
        public SqlConnection connect()
        {
            string str = @"Data Source=DESKTOP-DB9N8TQ;Initial Catalog=MyDataBase;Integrated Security=True";    //数据库连接字符串
            sc = new SqlConnection(str); //创建数据库连接对象
            sc.Open();  //打开数据库
            return sc;  //返回数据库连接对象
        } 
        #endregion

        #region 数据库的存储操作-Command
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        } 
        #endregion

        #region 数据库的更新操作-Execute
        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        } 
        #endregion

        #region 数据库的读取操作-IDataReader
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        } 
        #endregion

        #region 关闭数据库连接
        public void DaoClose()
        {
            sc.Close();
        } 
        #endregion
    }
}
