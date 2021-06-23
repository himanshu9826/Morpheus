using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpheusCommon.Helper
{
    public class ProcessLogs
    {
        /// <summary>
        /// Method to write account details in log
        /// </summary>
        /// <param name="Id">Account Id</param>
        /// <param name="accountName">Account Name</param>
        /// <param name="associationCode">Association Code</param>
        /// <param name="OwnerId">Owner Id</param>
        /// <param name="ActionName">Action Name</param>
        public static void WriteAccountToDB(string Id, string accountName, string associationCode, string OwnerId,string ActionName )
        {
            string LogFolder = ConfigurationManager.AppSettings["ProcessAccountLogPath"].ToString();
            if (!Directory.Exists(LogFolder))
            {
                Directory.CreateDirectory(LogFolder);
            }
            string filePath = @"\" + Convert.ToString(DateTime.Now.Date.Year) + "_" + Convert.ToString(DateTime.Now.Date.Month) + "_" + Convert.ToString(DateTime.Now.Date.Day) + ".txt";
            filePath = LogFolder + filePath;
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
                        writer.WriteLine("Date :" + DateTime.Now.ToString() + Environment.NewLine +  "Id: " + Id + " | AccountName: " + accountName + " | AssociationCode :" + associationCode  + " | OwnerId :" + OwnerId + " | ActionName :" + ActionName  );
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
        /// Method to write contact details in log
        /// </summary>
        /// <param name="Id">Account Id</param>
        /// <param name="accountNumber">Account Number</param>
        /// <param name="contactName">Contact Name</param>
        /// <param name="OwnerId">Owner Id</param>
        /// <param name="ActionName">Action Name</param>
        public static void WriteContactToDB(string Id, string accountNumber, string contactName, string OwnerId, string ActionName)
        {
            string LogFolder = ConfigurationManager.AppSettings["ProcessContactLogPath"].ToString();
            if (!Directory.Exists(LogFolder))
            {
                Directory.CreateDirectory(LogFolder);
            }
            string filePath = @"\" + Convert.ToString(DateTime.Now.Date.Year) + "_" + Convert.ToString(DateTime.Now.Date.Month) + "_" + Convert.ToString(DateTime.Now.Date.Day) + ".txt";
            filePath = LogFolder + filePath;
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
                        writer.WriteLine("Date :" + DateTime.Now.ToString() + Environment.NewLine + "Id: " + Id + " | AccountNumber: " + accountNumber + " | ContactName :" + contactName + " | OwnerId :" + OwnerId + " | ActionName :" + ActionName);
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
        /// Method to write contact details in log
        /// </summary>
        /// <param name="Id">Account Id</param>
        /// <param name="accountNumber">Account Number</param>
        /// <param name="contactName">Contact Name</param>
        /// <param name="OwnerId">Owner Id</param>
        /// <param name="ActionName">Action Name</param>
        public static void WriteExecutionSeqToDB(string SeqName,string Message)
        {
            string LogFolder = ConfigurationManager.AppSettings["ExecutionLog"].ToString();
            if (!Directory.Exists(LogFolder))
            {
                Directory.CreateDirectory(LogFolder);
            }
            string filePath = @"\" + Convert.ToString(DateTime.Now.Date.Year) + "_" + Convert.ToString(DateTime.Now.Date.Month) + "_" + Convert.ToString(DateTime.Now.Date.Day) + ".txt";
            filePath = LogFolder + filePath;
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
                        writer.WriteLine("SeqName :" + SeqName +  " Message: " + Message);
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

    }
}
