using System.Diagnostics;
using System.Text;

namespace getSystemDeviceData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var commands = new string[]
            {
                "Get-WmiObject Win32_BaseBoard | Select-Object Manufacturer, Product | Format-List",
                "Get-WmiObject Win32_Processor | Select-Object Name | Format-List",
                "Get-WmiObject Win32_VideoController | Select-Object Name | Format-List",
                "Get-WmiObject win32_diskdrive | Select-Object Model, Caption, Size | Format-List",
                "Get-WmiObject Win32_PhysicalMemory | Select-Object PartNumber, Capacity,Speed | Format-List"
            };
            var psiArray = new ProcessStartInfo[5].Select((x, i) => x = new ProcessStartInfo("powershell", commands[i])
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }).ToArray();

            var outputData = "";

            foreach (var psi in psiArray)
            {
                var process = Process.Start(psi);
                var caption = psi.Arguments.Split(" ")[1].Remove(0, 6);
                var data = process.StandardOutput.ReadToEnd().Trim();

                var stringData = $"{caption}\n{new String('=', 45)}\n{data}\n{new String('=', 45)}\n";

                outputData += stringData;

                Console.WriteLine(stringData);
                process.WaitForExit();
            }

            using (FileStream fstream = new FileStream($"{Directory.GetCurrentDirectory()}\\PCConfiguration.txt", FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(outputData);
                await fstream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}
