
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.IO;
using System.Text;

namespace OEWebApplicationApp
{
    /// <summary>
    /// containes methods and functions: code is layed out as such
    /// GST=5
    /// CONFIG LOCATION = C:/Users/edoucett/Desktop/ConfigOEWebApp.txt
    /// </summary>
    public class ClassConfig
    {

        private readonly string configAddress = "C:/Users/edoucett/Desktop/ConfigOEWebApp.txt";
        /// <summary>
        /// pulls the current user name
        /// </summary>
        /// <returns>user name </returns>
        public string username()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Trim();
            string name = userName.Remove(0, 14);
            name = "cpitre";
            return name;
        }//username

        // TODO: gnicholls name error
        // TODO: cpitre / yclement
        /*=======================================================================================================================================*/
        /// <summary>
        /// pulls the current user address
        /// </summary>
        /// <returns>user address</returns>
        public string Address()
        {
            string Address = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return Address;
        }//Address
        /*=======================================================================================================================================*/
        /// <summary>
        /// To parse the txt Config file 
        /// </summary>
        /// <returns>Line 1 </returns>
        public string ConfigGST()
        {
            string GST = "GST";
            StringBuilder sbText = new StringBuilder();
            using (var reader = new System.IO.StreamReader(configAddress))
            {
                foreach (string line in File.ReadLines(configAddress))
                {
                    if (line.Contains(GST))
                    {
                        sbText.Append(line);
                    }
                }//foreach
            }//using
            return Convert.ToString(sbText).Remove(0, 4);
        }//ConfigGST
        /*=======================================================================================================================================*/
        /// <summary>
        /// To parse the txt Config File
        /// </summary>
        /// <returns>Line 2 </returns>
        public string ConfigLocation()
        {
            string ConfigLocation = "CONFIG LOCATION";
            StringBuilder sbText = new StringBuilder();
            using (var reader = new System.IO.StreamReader(configAddress))
            {
                foreach (string line in File.ReadLines(configAddress))
                {
                    if (line.Contains(ConfigLocation))
                    {
                        sbText.Append(line);
                    }
                }//foreach
            }//using
            return Convert.ToString(sbText).Remove(0, 18);
        }//ConfigLocation
        /*=======================================================================================================================================*/
        /// <summary>
        /// To parse the txt Config File
        /// </summary>
        /// <returns>Line 3 </returns>
        public string ExportLocation()
        {
            string ConfigLocation = "FILE EXPORT LOCATION=";
            StringBuilder sbText = new StringBuilder();
            using (var reader = new System.IO.StreamReader(configAddress))
            {
                foreach (string line in File.ReadLines(configAddress))
                {
                    if (line.Contains(ConfigLocation))
                    {
                        sbText.Append(line);
                    }
                }//foreach
            }//using
            return Convert.ToString(sbText).Remove(0, 21);
        }//ExportLocation
        /*SQL STRING CONNECTIONS====================================================================================================================*/

        public string MorSQLConnections()
        {
            string value = MorSQLConnection();
            return value;
        }
        public string MorSQLConnection()
        {
            string value = "MORSQL CONNECTION STRING";
            StringBuilder sbText = new StringBuilder();
            using (var reader = new System.IO.StreamReader(configAddress))
            {
                foreach (string line in File.ReadLines(configAddress))
                {
                    if (line.Contains(value))
                    {
                        sbText.Append(line);
                    }
                }//foreach
            }//using
            return Convert.ToString(sbText).Remove(0, 25);
        }//MorSQLConnection
        public string vMortlSQLConnections()
        {
            string value = vMortlSQLConnection();
            return value;
        }
        private string vMortlSQLConnection()
        {
            string value = "VMORTL CONNECTION STRING";
            StringBuilder sbText = new StringBuilder();
            using (var reader = new System.IO.StreamReader(configAddress))
            {
                foreach (string line in File.ReadLines(configAddress))
                {
                    if (line.Contains(value))
                    {
                        sbText.Append(line);
                    }
                }//foreach
            }//using
            return Convert.ToString(sbText).Remove(0, 25);
        }//vMortlSQLConnection
        /*EMAIL STRING CONNECTIONS===================================================================================================================*/
        public string EmailSMTP()
        {
            string value = "EMAIL SMTP";
            StringBuilder sbText = new StringBuilder();
            using (var reader = new System.IO.StreamReader(configAddress))
            {
                foreach (string line in File.ReadLines(configAddress))
                {
                    if (line.Contains(value))
                    {
                        sbText.Append(line);
                    }
                }//foreach
            }//using
            return Convert.ToString(sbText).Remove(0, 11);
        }//EmailSMTP
        public string EmailPort()
        {
            string value = "EMAIL PORT";
            StringBuilder sbText = new StringBuilder();
            using (var reader = new System.IO.StreamReader(configAddress))
            {
                foreach (string line in File.ReadLines(configAddress))
                {
                    if (line.Contains(value))
                    {
                        sbText.Append(line);
                    }
                }//foreach
            }//using
            return Convert.ToString(sbText).Remove(0, 11);
        }//EmailPort
        public string EmailFrom()
        {
            string value = "EMAIL FROM";
            StringBuilder sbText = new StringBuilder();
            using (var reader = new System.IO.StreamReader(configAddress))
            {
                foreach (string line in File.ReadLines(configAddress))
                {
                    if (line.Contains(value))
                    {
                        sbText.Append(line);
                    }
                }//foreach
            }//using
            return Convert.ToString(sbText).Remove(0, 11);
        }//EmailPort

    }//ConfigClass
}//namespace
