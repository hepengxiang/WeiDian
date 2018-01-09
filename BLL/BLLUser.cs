using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiDian.IDAL;
using WeiDian.Model;

namespace WeiDian.BLL
{
    public class BLLUser
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <param name="resultID"></param>
        /// <returns></returns>
        public bool Insert( User user, out long resultID, out string errorMsg )
        {
            resultID = 0;
            errorMsg = "";
            try
            {
                if (user == null)
                {
                    return false;
                }

                IDALUser userDal = WeiDian.DALFactory.UserFactory.Create();

                resultID = userDal.Insert( user );

                if (resultID <= 0)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public bool Delete( long userID, out string errorMsg )
        {
            errorMsg = "";
            try
            {
                if (userID == 0)
                {
                    return false;
                }

                IDALUser userDal = WeiDian.DALFactory.UserFactory.Create();

                int effectRows = userDal.Delete( userID );

                if (effectRows <= 0)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public bool Update( User user, out string errorMsg )
        {
            errorMsg = "";
            try
            {
                if (user == null)
                {
                    return false;
                }

                IDALUser userDal = WeiDian.DALFactory.UserFactory.Create();

                int effectRows = userDal.Update( user );

                if (effectRows <= 0)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userList"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public bool GetUser( long userID, out List<User> userList, out string errorMsg )
        {
            userList = new List<User>();
            errorMsg = "";
            try
            {
                if (userID == 0)
                {
                    return false;
                }

                IDALUser userDal = WeiDian.DALFactory.UserFactory.Create();

                userList = userDal.GetUser( userID );
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }
    }
}
