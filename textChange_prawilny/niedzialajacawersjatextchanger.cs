using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace textChange_prawilny
{
    public partial class Form1 : Form
    {
        Changer change = new Changer();
        

        public Form1()
        {
            InitializeComponent();
            change.name = "";
                       
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|" + "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            
            
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                change.name = openFileDialog1.FileName;
                       
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            change.textSearchFor = textBox1.Text;
            change.textChangeWith = textBox2.Text;


            try
            {
                var directoryToTraverse = @"C:\Users\User";

                // what files to open

                var fileTypeToOpen = "*.*";
                // what to look for

                //var regExp = new Regex(change.name);

                //  var regExp = new Regex(patternToMatch);

                // the new content
                //  var patternToReplace = @"<OutputPath>;C:\bin\$(Configuration)\</OutputPath>";

                foreach (var file in Directory.GetFiles(directoryToTraverse, fileTypeToOpen, SearchOption.AllDirectories))
                {

                    // open, replace, overwrite

                    var content = File.ReadAllText(file);
                    content = Regex.Replace(content, change.textSearchFor, change.textChangeWith);
                    //var newContent = regExp.Replace(contents, patternToReplace);
                    //var newContent = Regex.Replace(content, change.textSearchFor, change.textChangeWith);

                   

                    File.WriteAllText(file, content);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception ex is handled"+ ex);
            }
          
                                         
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           
        }

    }
}
 