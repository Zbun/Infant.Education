using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Common
{
    public class Logger
    {
        private static ILog log = LogManager.GetLogger("GlobalErrorAppender");

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="info"></param>
        public static void Debug(string msg)
        {
            log.Debug(msg);
        }

        /// <summary>
        /// 记录一般日志
        /// </summary>
        /// <param name="info"></param>
        public static void Info(string msg)
        {
            log.Info(msg);
        }

        /// <summary>
        /// 记录可预料的异常日志
        /// </summary>
        public static void Warn(string msg, Exception ex)
        {
            log.Warn(msg, ex);
        }
        /// <summary>
        /// 记录可预料的异常日志
        /// </summary>
        public static void Warn(Exception ex)
        {
            log.Warn("系统警告", ex);
        }
        /// <summary>
        /// 记录可预料的异常日志
        /// </summary>
        public static void Warn(string msg)
        {
            log.Warn(msg);
        }


        /// <summary>
        /// 记录可预料的异常日志
        /// </summary>
        /// <param name="info"></param>
        public static void Error(string msg, Exception ex)
        {
            log.Error(msg, ex);
        }
        /// <summary>
        /// 记录可预料的异常日志
        /// </summary>
        /// <param name="info"></param>
        public static void Error(Exception ex)
        {
            log.Error("程序异常", ex);
        }
        /// <summary>
        /// 记录可预料的异常日志
        /// </summary>
        /// <param name="info"></param>
        public static void Error(string msg)
        {
            log.Error(msg);
        }

        /// <summary>
        /// 记录不可预料系统异常日志
        /// </summary>
        /// <param name="info"></param>
        public static void Fatal(Exception ex)
        {
            log.Fatal("系统异常", ex);
        }
    }
}
