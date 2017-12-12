using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e1
{
    public partial class RenewForm : Form
    {
        Thread td;
        PracticeInfo pracInfoimp = new PracticeInfo();
        List<PracticeInfo> practiceInfo = new List<PracticeInfo>();
        WebSpider whimp = new WebSpider();
        List<int> ID = new List<int>();
        List<int> companyID = new List<int>();
        string[] address2 = { "北京","上海","杭州","成都","深圳",
                                "西安","苏州","广州","南京","青岛","大连","武汉","百度" };

        public RenewForm()
        {
            InitializeComponent();
            ThreadStart ts = new ThreadStart(getPracticeandDispaly);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();

        }
        void getPracticeandDispaly()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            whimp.getIdAndCompanyTd(address2, ID, companyID);
            practiceInfo = whimp.getPracticeInfo(ID, companyID);
            getInformationDisplay();
        }

        public void getInformationDisplay()
        {

            for (int i = 0; i < practiceInfo.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(row);
                dataGridView1.Rows[i].Cells[0].Value = practiceInfo[i].name;
                dataGridView1.Rows[i].Cells[1].Value = practiceInfo[i].duty;
                dataGridView1.Rows[i].Cells[2].Value = practiceInfo[i].request;
                dataGridView1.Rows[i].Cells[3].Value = practiceInfo[i].location;
                dataGridView1.Rows[i].Cells[4].Value = practiceInfo[i].compname;
                dataGridView1.Rows[i].Cells[5].Value = practiceInfo[i].compinfo;
                dataGridView1.Rows[i].Cells[6].Value = practiceInfo[i].compweb;


            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
