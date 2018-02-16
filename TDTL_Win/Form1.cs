using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string SourcePath = "";

        public Dictionary<string, string> knownextensions = new Dictionary<string, string>()
        {
            { "Movies",".mp4;.wmv;.3gp;.m4v;.flv;.mov;.avi" },
            { "All Files","*.*" },

        };


        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = new BindingSource(knownextensions, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

        }

        public string[] GetSelectedExtensionArray()
        {
            var s = (string)comboBox1.SelectedValue;

            string[] ret = s.Split(';');

            return ret;
        }
        public List<String> Lines = new List<String>();

        private void DirSearch(string dir, int indent)
        {
            try
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    var files = Directory.GetFiles(dir);
                    foreach (var x in files)
                    {
                        var f_ =(!checkBoxHideExtensions.Checked) ?Path.GetFileName(x):Path.GetFileNameWithoutExtension(x);
                        Lines.Add(new String('\t', indent) + f_);
                    }
                }
                else
                {
                    var exts = GetSelectedExtensionArray();
                    var files = new DirectoryInfo(dir).GetFilesByExtensions(exts);

                    foreach (var x in files)
                    {
                        var f_ = (!checkBoxHideExtensions.Checked) ? Path.GetFileName(x.Name) :
                                  Path.GetFileNameWithoutExtension(x.Name);

                        //var f_ = Path.GetFileName(f);

                        Lines.Add(new String('\t', indent) + f_);
                    }
                }



                //foreach (string f in Directory.GetFiles(dir))
                //{
                //    var f_ = Path.GetFileName(f);
                //    Lines.Add(new String('\t', indent) + f_);
                //}

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

        private void GenerateListAndSave()
        {
            Lines.Clear();

            var lastdirname = SourcePath.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last();
            Lines.Add(lastdirname);

            DirSearch(SourcePath, 1);
            listBox1_.DataSource = null;
            listBox1_.DataSource = Lines;

            saveToTxt(SourcePath, lastdirname);
            this.Text = $"List generated at {SourcePath}\\{lastdirname}.txt";
        }
        private void txtFolderPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (Directory.Exists(files[0]))
                {
                    SourcePath = files[0];
                    GenerateListAndSave();
                }
            }
        }



        private void saveToTxt(string dir, string filenameonly)
        {
            TextWriter tw = new StreamWriter($"{dir}\\{filenameonly}.txt");
            Lines.ForEach(x => { tw.WriteLine(x); });
            tw.Close();
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop)) ? DragDropEffects.Copy : DragDropEffects.None;
        }


        /*
          private static void GenerateListAndSave()
        {
            Lines.Clear();

            var lastdirname = SourcePath.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last();
            Lines.Add(lastdirname);

            DirSearch(SourcePath, 1);

            saveToTxt(SourcePath,lastdirname);
            Console.WriteLine($"List generated at {SourcePath}\\{lastdirname}.txt");
        }

        private static void saveToTxt(string dir,string filenameonly)
        {
            TextWriter tw = new StreamWriter($"{dir}\\{filenameonly}.txt");
            Lines.ForEach(x => { tw.WriteLine(x); });
            tw.Close();
        }
         */

    }
}
