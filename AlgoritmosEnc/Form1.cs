using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosEnc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string entrada;

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName))
                {
                    entrada = sr.ReadToEnd();
                    sr.Close();
                }
                Shannon sh = new Shannon(entrada);
                ClassHuffman h = new ClassHuffman(entrada);
                List<Caracter> codish = sh.codificar();
                List<Caracter> codhuff = h.Codificado();
                dataGridView1.DataSource = codish;
                dataGridView1.Refresh();

                dataGridView2.DataSource = codhuff;
                dataGridView2.Refresh();
                textBox1.Text = entrada;
                bool x = true;
                for (int i = 0; i < codish.Count; i++)
                {
                    if (x == true)
                    {
                        AnexarTexto(this.richTextBox1, Color.Green, codish[i].Codigo.ToString());
                        x = false;
                    }
                    else
                    {
                        AnexarTexto(this.richTextBox1, Color.Blue, codish[i].Codigo.ToString());
                        x = true;
                    }
                }
            }
        }

        private void Colores()
        {
            
        }
        void AnexarTexto(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;
            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
