using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTL
{
    class Program
    {
        public static string SourcePath = "";
        public static List<String> Lines = new List<String>();

        static void Main(string[] args)
        {
            string msg1,msg2,msg3;
            msg1 = "Tabbed Directory Tree Lister\r\nversion: 1.0.0.0\r\ncontact developer at: kursatturkay@gmail.com";
            msg2 = "To Generate a tabbed list of a Directory, drop only a directory via Windows Explorer to this Executable.\r\nDropping a directory immidiately generates a hierarchical tabbed list right into root of same directory.\r\n";
            msg3 = "Press any key to close this console window.";

            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(msg1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(msg2);
            }
            else
            {
                if (Directory.Exists(args[0]))
                {
                    SourcePath = args[0];
                    GenerateListAndSave();
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg3);

            Console.ReadLine();
        }

        private static void DirSearch(string dir, int indent)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    var f_ = Path.GetFileName(f);
                    Lines.Add(new String('\t', indent) + f_);
                }

                foreach (string d in Directory.GetDirectories(dir))
                {
                    var pathremoved = d.Replace($"{Path.GetDirectoryName(d)}\\", string.Empty);

                    Lines.Add(new String('\t', indent) + pathremoved);
                    DirSearch(d, indent + 1);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void GenerateListAndSave()
        {
            Lines.Clear();

            var lastdirname = SourcePath.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last();
            Lines.Add(lastdirname);

            DirSearch(SourcePath, 1);
            //listBox1_.DataSource = null;
            //listBox1_.DataSource = Lines;

            saveToTxt(SourcePath);
            Console.WriteLine($"List generated at {SourcePath}\\List.txt");
        }

        private static void saveToTxt(string dir)
        {
            TextWriter tw = new StreamWriter($"{dir}\\List.txt");
            Lines.ForEach(x => { tw.WriteLine(x); });
            tw.Close();
        }
    }
}
