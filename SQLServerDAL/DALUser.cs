using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiDian.IDAL;
using WeiDian.Model;

namespace WeiDian.SQLServerDAL
{
    public class DALUser: IDALUser
    {
        public long Insert( User user )
        {
            string SQLString =
 @"
insert into [dbo].[t_User] 
([UserName], [PassWord], [Name], [Sex], [Birthday], [Address], [StaffID], [PhoneNum], [JoinTime])
Values
(@UserName, @PassWord, @Name, @Sex, @Birthday, @Address, @StaffID, @PhoneNum, @JoinTime)
select @@Identity
";
            ;
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@PassWord",user.PassWord),
                new SqlParameter("@Name",user.Name),
                new SqlParameter("@Sex",user.Sex),
                new SqlParameter("@Birthday",user.Birthday),
                new SqlParameter("@Address",user.Address),
                new SqlParameter("@StaffID",user.StaffID),
                new SqlParameter("@PhoneNum",user.PhoneNum),
                new SqlParameter("@JoinTime",user.JoinTime)
           };
            return SqlHelper.ExecuteInsert( SQLString, paras );
        }

        public int Delete( long userID )
        {
            string SQLString =
@"
delete [dbo].[t_User]
where [UserID] = @UserID
";
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@UserID",userID)
           };
            return SqlHelper.ExecuteUpdate( SQLString, paras );
        }

        public int Update( User user )
        {
            string SQLString =
@"
update [dbo].[t_User] set
[UserName] = @UserName,
[PassWord] = @PassWord,
[Name] = @Name,
[Sex] = @Sex,
[Birthday] = @Birthday,
[Address] = @Address,
[StaffID] = @StaffID,
[PhoneNum] = @PhoneNum,
[JoinTime] = @JoinTime
where [UserID] = @UserID
select @@Identity
";
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@UserID",user.UserID),
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@PassWord",user.PassWord),
                new SqlParameter("@Name",user.Name),
                new SqlParameter("@Sex",user.Sex),
                new SqlParameter("@Birthday",user.Birthday),
                new SqlParameter("@Address",user.Address),
                new SqlParameter("@StaffID",user.StaffID),
                new SqlParameter("@PhoneNum",user.PhoneNum),
                new SqlParameter("@JoinTime",user.JoinTime)
           };
            return SqlHelper.ExecuteUpdate( SQLString, paras );
        }
        
        public List<User> GetUser( long userID )
        {
            string SQLString =
@"
select 
[UserID], [UserName], [PassWord], [Name], [Sex], [Birthday], [Address], [StaffID], [PhoneNum], [JoinTime]
from [dbo].[t_User]
where [UserID] = @UserID
";
            SqlParameter[] paras = new SqlParameter[]
           {
                new SqlParameter("@UserID",userID)
           };
            DataTable dt = SqlHelper.ExecuteSelect( SQLString, paras );
            List<User> userList = new List<User>();
            foreach (DataRow dRow in dt.Rows)
            {
                User user = new User();
                if (dt.Columns.Contains( "UserID" ))
                {
                    user.UserID = ToolsCommon.ConvertCommon.ToLong( dRow["UserID"] );
                }
                if (dt.Columns.Contains( "UserName" ))
                {
                    user.UserName = ToolsCommon.ConvertCommon.ToString( dRow["UserName"] );
                }
                if (dt.Columns.Contains( "PassWord" ))
                {
                    user.PassWord = ToolsCommon.ConvertCommon.ToString( dRow["PassWord"] );
                }
                if (dt.Columns.Contains( "Name" ))
                {
                    user.Name = ToolsCommon.ConvertCommon.ToString( dRow["Name"] );
                }
                if (dt.Columns.Contains( "Sex" ))
                {
                    user.Sex = ToolsCommon.ConvertCommon.ToInt( dRow["Sex"] );
                }
                if (dt.Columns.Contains( "Birthday" ))
                {
                    user.Birthday = ToolsCommon.ConvertCommon.ToDateTime( dRow["UserID"] );
                }
                if (dt.Columns.Contains( "Address" ))
                {
                    user.Address = ToolsCommon.ConvertCommon.ToString( dRow["Address"] );
                }
                if (dt.Columns.Contains( "StaffID" ))
                {
                    user.StaffID = ToolsCommon.ConvertCommon.ToString( dRow["StaffID"] );
                }
                if (dt.Columns.Contains( "PhoneNum" ))
                {
                    user.PhoneNum = ToolsCommon.ConvertCommon.ToString( dRow["PhoneNum"] );
                }
                if (dt.Columns.Contains( "JoinTime" ))
                {
                    user.JoinTime = ToolsCommon.ConvertCommon.ToDateTime( dRow["JoinTime"] );
                }
                userList.Add( user );
            }
            return userList;
        }

    }
}
