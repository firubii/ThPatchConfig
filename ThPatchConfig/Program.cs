using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ThPatchConfig
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Make this entire process better it's a little ugh but it works for now

            string workingDir;
            if (File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\workingdir.txt"))
            {
                workingDir = File.ReadAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\workingdir.txt");
                Console.WriteLine("Reading workingdir.txt");
            }
            else
                workingDir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            Console.WriteLine("Current working directory: " + workingDir);

            workingDir = DetectThCrap(workingDir);

            if (File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\workingdir.txt"))
            {
                if (workingDir != File.ReadAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\workingdir.txt"))
                {
                    File.WriteAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\workingdir.txt", workingDir);
                }
            }
            else File.WriteAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\workingdir.txt", workingDir);

            Console.WriteLine("Launching with working directory: " + workingDir);
            Application.Run(new MainForm(workingDir));
        }

        static string DetectThCrap(string dir)
        {
            string d = dir;
            if (!File.Exists(dir + "\\bin\\thcrap_loader.exe"))
            {
                if (MessageBox.Show("Could not detect thcrap in this directory." +
                                 "\nWould you like to select a different directory?" +
                               "\n\nThis folder would be the root folder, where the folders \"bin\", \"config\", and \"repos\" are.",
                                    "ThPatch Config", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FolderBrowserDialog open = new FolderBrowserDialog();
                    open.SelectedPath = dir;
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        d = DetectThCrap(open.SelectedPath);
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                }
                else
                {
                    Environment.Exit(1);
                }
            }
            return d;
        }
    }
}
