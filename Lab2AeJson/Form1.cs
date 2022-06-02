using labparser;

namespace Lab2AeJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var input = textBoxInput.Text;
            if (!string.IsNullOrEmpty(input) && Directory.Exists(textBoxDirectory.Text))
            {
                var result = await Task.Run(() => LabParser.GenerateAeJson(new DirectoryInfo(textBoxDirectory.Text), input));
                if (!string.IsNullOrEmpty(result))
                {
                    textBoxConverted.Text = result;
                }
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}