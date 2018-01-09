using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiDian.ToolsCommon
{
    /// <summary>
    /// 包含类型转换相关的方法。
    /// </summary>
    public static class ConvertCommon
    {
        public static string ToString( object value )
        {
            if (value == null)
                return "";
            return System.Convert.ToString( value );
        }
        
        public static float ToFloat( object value )
        {
            string strInput = ToString( value );
            float v;
            return float.TryParse( strInput, out v ) ? v : 0;
        }

        public static decimal ToDecimal( object value )
        {
            string strInput = ToString( value );
            decimal v;
            return decimal.TryParse( strInput, out v ) ? v : 0;
        }
        
        public static double ToDouble( object value )
        {
            string strInput = ToString( value );
            double v;
            return double.TryParse( strInput, out v ) ? v : 0;
        }

        public static int ToInt( object value )
        {
            string strInput = ToString( value );
            int v;
            return int.TryParse( strInput, out v ) ? v : 0;
        }
        
        public static long ToLong( object value )
        {
            string strInput = ToString( value );
            long v;
            return long.TryParse( strInput, out v ) ? v : 0;
        }

        public static bool ToBool( object value )
        {
            string strInput = ToString( value );
            bool v;
            return bool.TryParse( strInput, out v ) ? v : false;
        }

        public static string IntToSex( object value )
        {
            string valueStr = ToString( value );
            if (valueStr == "0")
            {
                return "男";
            }
            else if (valueStr == "1")
            {
                return "女";
            }
            else
            {
                return "未知";
            }
        }

        public static int SexToInt( object value )
        {
            string valueStr = ToString( value );
            if (valueStr == "男")
            {
                return 0;
            }
            else if (valueStr == "女")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public static DateTime ToDateTime( object value )
        {
            string strInput = ToString( value );
            DateTime v;
            return DateTime.TryParse( strInput, out v ) ? v : DateTime.Parse( "1900-1-1" );
        }

        /// <summary>
        /// 获取当前时间戳 11位
        /// </summary>
        /// <returns></returns>
        private static long NowTimeToInt()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime( new System.DateTime( 1970, 1, 1, 0, 0, 0, 0 ) );
            long t = (System.DateTime.Now.Ticks - startTime.Ticks);  
            return t;
        }

        /// <summary>
        /// 获取指定时间戳 11位
        /// </summary>
        /// <returns></returns>
        private static long DateTimeToInt( System.DateTime time )
        {
            if (time == null)
                return 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime( new System.DateTime( 1970, 1, 1, 0, 0, 0, 0 ) );
            long t = (time.Ticks - startTime.Ticks); 
            return t;
        }

        /// <summary>
        /// 获取当前时间戳 13位
        /// </summary>
        /// <returns></returns>
        private static long NowTimeToLong()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime( new System.DateTime( 1970, 1, 1, 0, 0, 0, 0 ) );
            long t = (System.DateTime.Now.Ticks - startTime.Ticks) / 10000;     
            return t;
        }

        /// <summary>
        /// 获取指定时间戳 13位
        /// </summary>
        /// <returns></returns>
        private static long NowTimeToLong( System.DateTime time )
        {
            if (time == null)
                return 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime( new System.DateTime( 1970, 1, 1, 0, 0, 0, 0 ) );
            long t = (time.Ticks - startTime.Ticks) / 10000;   
            return t;
        }
    }
}
