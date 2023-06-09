using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PuppeteerSharp;
using System.IO;

namespace Coffee_to_go
{
    internal class GoogleAuth
    {
        public void getUser()
        {
            string url = "http://127.0.0.1:5000";

            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = $"/C start {url}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();

            var pathInf = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var absolutePath = Path.Combine(pathInf.Parent.Parent.Parent.ToString(), "Authentication/current_user/current_user.json");
            MessageBox.Show(absolutePath);
            while (!File.Exists(absolutePath))
            { System.Threading.Thread.Sleep(500); }
            MessageBox.Show("done");

            process.WaitForExit();
        }
    }
}
