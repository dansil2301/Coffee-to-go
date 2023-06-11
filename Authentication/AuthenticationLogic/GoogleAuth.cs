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
using System.Threading;

namespace Coffee_to_go
{
    internal class GoogleAuth
    {
        private string repositoryPath;
        Task pythonTask;
        private Process pythonProcess = new Process();

        public GoogleAuth()
        {
            var pathInf = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            repositoryPath = pathInf.Parent.Parent.Parent.ToString();
        }

        public void getUser()
        {
            startLocalFlaskServer();
            System.Threading.Thread.Sleep(500);

            string url = "http://127.0.0.1:5000";

            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = $"/C start {url}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();

            var absolutePath = Path.Combine(repositoryPath, "Authentication/current_user/current_user.json");

            while (!File.Exists(absolutePath))
            { System.Threading.Thread.Sleep(500); }

            process.WaitForExit();

            System.Threading.Thread.Sleep(4000);
            stopFlaskServer();
        }

        private void startLocalFlaskServer()
        {
            string flaskDirectory = Path.Combine(repositoryPath, "Authentication/googleAuth");
            string pythonInterpreter = Path.Combine(repositoryPath, "Authentication/googleAuth/venv/Scripts/python.exe");
            string pythonScript = Path.Combine(repositoryPath, "Authentication/googleAuth/googleOauth.py");

            Directory.SetCurrentDirectory(flaskDirectory);

            pythonProcess.StartInfo.FileName = pythonInterpreter;
            pythonProcess.StartInfo.Arguments = pythonScript;
            pythonProcess.StartInfo.UseShellExecute = false;
            pythonProcess.StartInfo.CreateNoWindow = true;

            pythonTask = Task.Run(() =>
            {
                pythonProcess.Start();
                pythonProcess.WaitForExit();
            });
        }

        private void stopFlaskServer()
        {
            string serverUrl = "http://localhost:5000";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.PostAsync($"{serverUrl}/shutdown", null).GetAwaiter().GetResult();
                }
                catch (Exception ex) { /* do nothing */ }
            }
        }
    }
}
