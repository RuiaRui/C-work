using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e1
{
    public partial class displayForm : Form
    {

        PracticeInfo pracInfo = new PracticeInfo();
        List<PracticeInfo> practiceInformation = new List<PracticeInfo>();
        public displayForm()
        {
            InitializeComponent();

        }


        public void getInformationDisplay(string s)
        {
            practiceInformation = pracInfo.getPracticeInfoFromFile(s);

            for (int i = 0; i < practiceInformation.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(row);
                dataGridView1.Rows[i].Cells[0].Value = practiceInformation[i].name;
                dataGridView1.Rows[i].Cells[1].Value = practiceInformation[i].duty;
                dataGridView1.Rows[i].Cells[2].Value = practiceInformation[i].request;
                dataGridView1.Rows[i].Cells[3].Value = practiceInformation[i].location;
                dataGridView1.Rows[i].Cells[4].Value = practiceInformation[i].compname;
                dataGridView1.Rows[i].Cells[5].Value = practiceInformation[i].compinfo;
                dataGridView1.Rows[i].Cells[6].Value = practiceInformation[i].compweb;


            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox1.AppendText(filepath);
                getInformationDisplay(filepath);
            }
        }
    }
}
