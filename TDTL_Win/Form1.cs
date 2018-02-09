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
        public Form1()
        {
            InitializeComponent();
        }

        public List<String> Lines = new List<String>();

        private void DirSearch(string dir, int indent)
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

        private void GenerateListAndSave()
        {
            Lines.Clear();

            var lastdirname = SourcePath.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last();
            Lines.Add(lastdirname);

            DirSearch(SourcePath, 1);
            listBox1_.DataSource = null;
            listBox1_.DataSource = Lines;

            saveToTxt(SourcePath);
            this.Text = $"List.txt generated into {SourcePath}";
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



        private void saveToTxt(string dir)
        {
            TextWriter tw = new StreamWriter($"{dir}\\List.txt");
            Lines.ForEach(x => { tw.WriteLine(x); });
            tw.Close();
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop)) ? DragDropEffects.Copy : DragDropEffects.None;
        }


    }
}
