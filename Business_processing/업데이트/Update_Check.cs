using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_processing
{
    class Update_Check
    {
        //static string zdiver_path = @"Z:\HDD1\_기타\프로그램\업데이트파일\";
        public Update_Check()
        {
            
        }
        
        public bool Check_Version()
        {
            var filename = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var version = System.Diagnostics.FileVersionInfo.GetVersionInfo(filename).FileVersion;

            server _s = new server();
            string DB_version = _s.Read_Data_Version("SELECT * FROM PROCESS_VERSION");
            if (version != DB_version)
            {
                Update();
                return true;
            }
            
            return false;
        }
        private static void Update()
        {
            var filename = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string filepath = filename.Substring(0, filename.Length - 24);
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = filepath + "\\UpdateLoder.exe";
            psi.Arguments = filepath;
            Process.Start(psi);
            Environment.Exit(0);
            /*
            MessageBox.Show("프로그램 재시작해주세요...");
            var filename = System.Reflection.Assembly.GetExecutingAssembly().Location;
            
            Process.Start("powershell.exe", "-COMMAND Copy " + zdiver_path + "* " + filepath);
            
            */

        }
    }
}
