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
    public partial class login : Form
    {
        #region 窗体创建时的初始化过程
        public login()
        {
            InitializeComponent();
        } 
        #endregion

        #region 判断文本框是否带有空项
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();    //转到下面的Login方法下
            }
            else
            {
                MessageBox.Show("输入有空项,请重新输入");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
        #endregion

        #region 登录方法
        public void Login()
        {

            #region 用户登录部分
            if (radioButtonUser.Checked == true)
            {
                Dao dao = new Dao();

                try
                {
                    Convert.ToInt32(textBox1.Text);
                    string sql = $"select * from T_user where id='{textBox1.Text}' and psw='{textBox2.Text}'";

                    IDataReader dc = dao.read(sql);     //IDataReader是一个通用的接口 
                    if (dc.Read())
                    {
                        data.UID = dc["id"].ToString();
                        data.UName = dc["name"].ToString();

                        MessageBox.Show("登陆成功");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        user1 user = new user1();//实例化窗体（打开user1窗口） 实现页面跳转
                        this.Hide();//隐藏掉登陆窗体
                        user.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误，请重试！");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    dao.DaoClose();
                }
                catch { 
                    string sql = $"select * from T_user where name='{textBox1.Text}' and psw='{textBox2.Text}'";

                    IDataReader dc = dao.read(sql);     //IDataReader是一个通用的接口 
                    if (dc.Read())
                    {
                        data.UID = dc["id"].ToString();
                        data.UName = dc["name"].ToString();

                        MessageBox.Show("登陆成功");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        user1 user = new user1();//实例化窗体（打开user1窗口） 实现页面跳转
                        this.Hide();//隐藏掉登陆窗体
                        user.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误，请重试！");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    dao.DaoClose();
                }
            }
            #endregion
            
            #region 管理员登录部分
            if (radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from T_admin where id='{textBox1.Text}' and psw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    data.AID = dc["id"].ToString();

                    MessageBox.Show("登陆成功");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    admin1 a = new admin1();
                    this.Hide();
                    a.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重试！");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                dao.DaoClose();
            } 
            //MessageBox.Show("单选框请先选中"); 
        }
        #endregion

        #endregion

        #region 跳转注册页面
        private void button2_Click(object sender, EventArgs e)
        {
            zhuce login = new zhuce();
            login.ShowDialog();
        }
        #endregion

        #region 键盘按下事件

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        } 
        #endregion
    }
}
