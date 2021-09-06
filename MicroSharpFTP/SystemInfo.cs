using Microsoft.Win32;
using System;
using System.Management;

namespace MicroSharpFTP
{
    internal class SystemInfo
    {
        public  static string GetOperatingSystemInfo() 
        {
            //Create an object of ManagementObjectSearcher class and pass query as parameter.
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            string ret = null;
            foreach (ManagementObject managementObject in mos.Get())
            {
                
                if (managementObject["Caption"] != null)
                {
                    ret+= "Running on: " + managementObject["Caption"].ToString();   //Display operating system caption
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    ret += ", Architecture: " + managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
                }
                if (managementObject["CSDVersion"] != null)
                {
                    ret+= ", Operating System Service Pack: " + managementObject["CSDVersion"].ToString();     //Display operating system version.
                }
                string Query = "SELECT Capacity FROM Win32_PhysicalMemory";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);

                UInt64 Capacity = 0;
                foreach (ManagementObject WniPART in searcher.Get())
                {
                    Capacity += Convert.ToUInt64(WniPART.Properties["Capacity"].Value);
                }

                ret += ", RAM: " + ftp.BytesToString((long)Capacity);
                RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    ret += ", Processor: " + (string)processor_name.GetValue("ProcessorNameString");   //Display processor ingo.
                }
                
            }
            
            return ret;
        }

        
    }
}
