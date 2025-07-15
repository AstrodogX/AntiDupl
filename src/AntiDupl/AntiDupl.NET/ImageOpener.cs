using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace AntiDupl.NET
{
    static public class ImageOpener
    {
        /// <summary>
        /// Opens the specified file using its default application.
        /// </summary>
        static public void OpenFile(string filePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.FileName = filePath;
            try
            {
                var process = Process.Start(startInfo);
                Thread.Sleep(System.TimeSpan.FromMilliseconds(100));
            }
            catch (System.Exception exeption)
            {
                MessageBox.Show(exeption.Message);
            }
        }

    public static void OpenDiff(string filepath1, string filepath2)
    {
			ProcessStartInfo startInfo = new("c:\\Program Files\\Beyond Compare 4\\BCompare.exe") {
				UseShellExecute = false,
        ArgumentList = { filepath1, filepath2	}
			};
			try {
        var process = Process.Start(startInfo);
        Thread.Sleep(System.TimeSpan.FromMilliseconds(100));
      } catch (System.Exception exeption) {
        MessageBox.Show(exeption.Message);
      }
		}

    }
}
