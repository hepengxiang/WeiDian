using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeiDian.WinfromTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Model.User user = new Model.User();
            user.UserName = "admin";
            user.PassWord = "123456";
            user.Name = "管理员";
            user.Sex = 0;
            user.Birthday = System.DateTime.Now;
            user.Address = "佛山市禅城区";
            user.StaffID = "421223199212141039";
            user.PhoneNum = "13554560405";
            user.JoinTime = System.DateTime.Now;

            BLL.BLLUser bLLUser = new BLL.BLLUser();
            long resultID = 0;
            string errorMsg = "";
            bool result = bLLUser.Insert( user, out resultID, out errorMsg );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            BLL.BLLUser bLLUser = new BLL.BLLUser();
            long resultID = 0;
            string errorMsg = "";
            bool result = bLLUser.Delete( 1, out errorMsg );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            Model.User user = new Model.User();
            user.UserID = 1;
            user.UserName = "admin";
            user.PassWord = "123456";
            user.Name = "管理员";
            user.Sex = 0;
            user.Birthday = System.DateTime.Now;
            user.Address = "佛山市禅城区1";
            user.StaffID = "421223199212141039";
            user.PhoneNum = "13554560405";
            user.JoinTime = System.DateTime.Now;

            BLL.BLLUser bLLUser = new BLL.BLLUser();
            long resultID = 0;
            string errorMsg = "";
            bool result = bLLUser.Update( user, out errorMsg );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            BLL.BLLUser bLLUser = new BLL.BLLUser();
            List<Model.User> userList = new List<Model.User>();
            long resultID = 0;
            string errorMsg = "";
            bool result = bLLUser.GetUser(1, out userList, out errorMsg );
        }
    }
}
