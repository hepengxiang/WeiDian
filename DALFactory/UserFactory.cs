using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeiDian.DALFactory
{
    public class UserFactory
    {

        public static WeiDian.IDAL.IDALUser Create()
        {
            /// Look up the DAL implementation we should be using
            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["WebDAL"];
            string className = path + ".DALUser";

            // Using the evidence given in the config file load the appropriate assembly and class
            return (WeiDian.IDAL.IDALUser)Assembly.Load( path ).CreateInstance( className );
        }
    }
}
