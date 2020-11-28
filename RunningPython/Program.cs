using System;
using System.Diagnostics;
using System.Linq;

//import sys
//import time

//print(sys.argv)
//time.sleep(5)
//print("Hi Sergio")
//raise ZeroDivisionError()

namespace RunningPython
{
    class Program
    {
        static void Main(string[] args)
        {
            RunPython(@"C:\Users\sergio.leon\PycharmProjects\Project1\main.py");
            RunPython(@"C:\Users\sergio.leon\PycharmProjects\Project1\main.py",
                new[] { "Sergio", "Carmen", "Jimena" });
        }

        static void RunPython(string path, string[] args = default)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = @"C:\Windows\py.exe",
                Arguments = $"\"{path}\" {(args != null ? string.Join(" ", args.Select(a => $"\"{a}\"")) : string.Empty)}",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            using var process = Process.Start(processStartInfo);
            var stderr = process.StandardError.ReadToEnd();
            var stdout = process.StandardOutput.ReadToEnd();
            Console.WriteLine($"stdout {stdout}");
            Console.WriteLine($"stderr {stderr}");
            Console.WriteLine($"ExitCode {process.ExitCode}");
        }
    }
}