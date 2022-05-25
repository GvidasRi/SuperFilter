using System;
using System.IO;
using System.Text;

namespace SuperFilter
{
    public partial class Form1 : Form
    {
        
        string FilePath = "";
        string indicator1 = "";
        string[] originalContent = new string[0];
        string[] FileContent = new string[0];
        string trimmer = "";
        string[] undo = new string[0];
        string[] arraycopy = new string[0];
        string[] temparray = new string[0];
        string[] c = new string[0];
        string[] txtboxarray = new string[0];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Green;
            button7.ForeColor = Color.Red;
            button8.ForeColor = Color.Red;
            button9.ForeColor = Color.Green;
            button10.ForeColor = Color.Red;
            button11.ForeColor = Color.Red;
            comboBox1.SelectedIndex = 0;
            button5.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;
           // label1.Text = "sv";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            openFileDialog1.InitialDirectory = "c:\\users\\Gvidas\\Desktop";
            openFileDialog1.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FilePath = openFileDialog1.FileName; //get file name
                    label1.Text = FilePath;
                    FileContent = File.ReadAllLines(FilePath);
                    originalContent = File.ReadAllLines(FilePath);
                    arraycopy = File.ReadAllLines(FilePath);
                    for (int i = 0; i < FileContent.Length; i++)
                    {
                        richTextBox1.Text = richTextBox1.Text + FileContent[i] + "\n";
                        richTextBox2.Text = richTextBox2.Text + FileContent[i] + "\n";
                    }
                    openFileDialog1.Dispose();
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button5.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            indicator1 = textBox1.Text;
            Array.Resize(ref undo, originalContent.Length);
            Array.Resize(ref arraycopy, originalContent.Length);
            Array.Copy(originalContent, arraycopy, originalContent.Length);
            for (int i = 0; i < originalContent.Length; i++)
            {
                undo[i] = originalContent[i];
            }
            try
            {
                for (int i = 0; i < originalContent.Length; i++)
                {
                    if (indicator1 != "" && checkBox1.Checked == false)
                    {
                        trimmer = originalContent[i];
                        originalContent[i] = trimmer.Replace(indicator1, string.Empty);
                    }
                    else if (indicator1 != "" && checkBox1.Checked == true)
                    {
                        trimmer = originalContent[i];
                        originalContent[i] = trimmer.Replace(indicator1, "\n"); //or System.Environment.NewLine
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            for (int i = 0; i < originalContent.Length; i++)
            {
                richTextBox2.Text = richTextBox2.Text + originalContent[i] + "\n";
            }
            button4.Enabled = true;
            MessageBox.Show("Success!", "Message");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                Array.Resize(ref txtboxarray, originalContent.Length);
                for (int i = 0; i < originalContent.Length; i++)
                {
                    txtboxarray[i] = originalContent[i];
                }
            }
            else
            {
                txtboxarray = richTextBox2.Text.Split(' ');
            }
          //  txtboxarray = richTextBox2.Text.Split(' ');
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.InitialDirectory = "c:\\users\\Gvidas\\Desktop";
            saveFileDialog1.RestoreDirectory = true;
            string path;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                        path = saveFileDialog1.FileName;
                        File.WriteAllLines(path, txtboxarray, Encoding.UTF8);
                        MessageBox.Show("Failas išsaugotas","Pranešimas");
                }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            Array.Resize(ref originalContent, undo.Length);
            for (int i = 0; i < undo.Length; i++)
            {
                originalContent[i] = undo[i];
                richTextBox2.Text = richTextBox2.Text + originalContent[i] + "\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Array.Resize(ref undo, originalContent.Length);
            for (int i = 0; i < originalContent.Length; i++)
            {
                undo[i] = originalContent[i];
            }
            var result = MessageBox.Show("Are you sure?", "Remove empty lines",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
            }
            else
            {
                txtboxarray = richTextBox2.Text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            }
            richTextBox2.Clear();
            for (int i = 0; i < txtboxarray.Length; i++)
            {
                richTextBox2.Text = richTextBox2.Text + txtboxarray[i] + "\n";
            }
            button4.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Red;
            button7.ForeColor = Color.Green;
            button8.ForeColor = Color.Red;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Red;
            button7.ForeColor = Color.Red;
            button8.ForeColor = Color.Green;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.ForeColor = Color.Green;
            button10.ForeColor = Color.Red;
            button11.ForeColor = Color.Red;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button9.ForeColor = Color.Red;
            button10.ForeColor = Color.Green;
            button11.ForeColor = Color.Red;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button9.ForeColor = Color.Red;
            button10.ForeColor = Color.Red;
            button11.ForeColor = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Green;
            button7.ForeColor = Color.Red;
            button8.ForeColor = Color.Red;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                richTextBox2.Clear();
                c = Array.FindAll(originalContent, element => element.Contains(textBox3.Text));
                for (int i = 0; i < c.Length; i++)
                {
                    richTextBox2.Text = richTextBox2.Text + c[i] + "\n";
                }
            }
            else
            {
                richTextBox2.Clear();
                Array.Copy(arraycopy, originalContent, arraycopy.Length);
                for (int i = 0; i < originalContent.Length; i++)
                {
                    richTextBox2.Text = richTextBox2.Text + originalContent[i] + "\n";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {

            }
            else
            {
                richTextBox2.Clear();//isvalau teksta
                /* if (comboBox1.SelectedIndex == 0)
                 {
                     c = Array.FindAll(originalContent, element => element.Contains(textBox2.Text));//surandu "haha" ir idedu i c masyv
                 }
                 else if (comboBox1.SelectedIndex == 1)
                 {
                     c = Array.FindAll(originalContent, element => element.StartsWith(textBox2.Text));//surandu "haha" ir idedu i c masyv
                 }
                 else if (comboBox1.SelectedIndex == 2)
                 {
                     c = Array.FindAll(originalContent, element => element.EndsWith(textBox2.Text));//surandu "haha" ir idedu i c masyv
                 }*/
                c = Array.FindAll(originalContent, element => element.Contains(textBox2.Text));//surandu "haha" ir idedu 
                Array.Resize(ref c, originalContent.Length);//sulyginu masyvus
                Array.Resize(ref temparray, originalContent.Length);//sulyginu masyvus
                for (int i = 0; i < originalContent.Length; i++)
                {
                    if (c[0] == originalContent[i]) //jei masyvo vietoj atitinka nieko nedarau
                    {
                        originalContent = originalContent.Where((source, index) => index != i).ToArray();
                    }
                    else //visi kiti turi i text langa is masyvo nueit
                    {
                        richTextBox2.Text = richTextBox2.Text + originalContent[i] + "\n";
                        temparray[i] = originalContent[i];
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Array.Copy(arraycopy, originalContent, arraycopy.Length);
            richTextBox2.Clear();
            for (int i = 0; i < originalContent.Length; i++)
            {
                richTextBox2.Text = richTextBox2.Text + originalContent[i] + "\n";
            }
        }
    }
}