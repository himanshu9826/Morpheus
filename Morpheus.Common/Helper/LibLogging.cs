using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpheusCommon.Helper
{
    public class LibLogging
    {
        #region Declaration of variables



        #endregion
        public static void WriteErrorToDB(string Source, string Code, Exception ex = null)
        {
            string ErrorFolder = ConfigurationManager.AppSettings["LogPath"].ToString();
            if (!Directory.Exists(ErrorFolder))
            {
                Directory.CreateDirectory(ErrorFolder);
            }
            string filePath = @"\" + Convert.ToString(DateTime.Now.Date.Year) + "_" + Convert.ToString(DateTime.Now.Date.Month) + "_" + Convert.ToString(DateTime.Now.Date.Day) + ".txt";
            filePath = ErrorFolder + filePath;
            if (!File.Exists(filePath))
            {
                FileStream fs1 = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                fs1.Close();
            }

            try
            {
                int addLog = Convert.ToInt32(ConfigurationManager.AppSettings["AddLog"]);
                //int addLog = 1;
                if (addLog == 1)
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        string message = ex != null ? ex.Message : string.Empty;
                        string stackTrace = ex != null ? ex.StackTrace : string.Empty;
                        writer.WriteLine("Methodl: " + Code + " | Source: " + Source + " | Message :" + message + "<br/>" + Environment.NewLine + "StackTrace :" + stackTrace +
                           "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
                }

            }
            catch (Exception ex1)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Methodl: WriteErrorToDB | Source: LibLogging | Message :" + ex1.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex1.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// Method to add success log
        /// </summary>
        /// <param name="AssociationName"></param>
        /// <param name="Fileid"></param>
        /// <param name="SuccessLogPath"></param>
        public static void WriteSuccsss(int count, string AssociationName, string Fileid, string SuccessLogPath)
        {
            if (!Directory.Exists(SuccessLogPath))
            {
                Directory.CreateDirectory(SuccessLogPath);
            }
            string filePath = @"\Succsss_" + Convert.ToString(DateTime.Now.Date.Year) + "_" + Convert.ToString(DateTime.Now.Date.Month) + "_" + Convert.ToString(DateTime.Now.Date.Day) + ".txt";
            filePath = SuccessLogPath + filePath;
            if (!File.Exists(filePath))
            {
                FileStream fs1 = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                fs1.Close();
            }

            try
            {

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(count.ToString() + " AssociationName: " + AssociationName + " | Fileid: " + Fileid);
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                WriteErrorToDB("LibLogging", "WriteSuccsss", ex);
            }
        }

        /// <summary>
        /// Method to add missed file log
        /// </summary>
        /// <param name="AssociationName"></param>
        /// <param name="Fileid"></param>
        /// <param name="FailureLogPath"></param>
        public static void WriteFailure(int count, string AssociationName, string Fileid, string FailureLogPath)
        {
            if (!Directory.Exists(FailureLogPath))
            {
                Directory.CreateDirectory(FailureLogPath);
            }
            string filePath = @"\Failure_" + Convert.ToString(DateTime.Now.Date.Year) + "_" + Convert.ToString(DateTime.Now.Date.Month) + "_" + Convert.ToString(DateTime.Now.Date.Day) + ".txt";
            filePath = FailureLogPath + filePath;
            if (!File.Exists(filePath))
            {
                FileStream fs1 = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                fs1.Close();
            }

            try
            {

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(count.ToString() + " Fileid: " + Fileid + " | AssociationName: " + AssociationName);
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                WriteErrorToDB("LibLogging", "WriteFailure", ex);
            }
        }

    }
}
