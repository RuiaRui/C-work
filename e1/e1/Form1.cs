using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace e1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        WebSpider imp = new WebSpider();
        PracticeInfo pracInfo = new PracticeInfo();
        List<int> id = new List<int>();
        List<int> companyId = new List<int>();
        List<PracticeInfo> info = new List<PracticeInfo>();

        string[] address = { "北京","上海","杭州","成都","深圳",
                                "西安","苏州","广州","南京","青岛","大连","武汉","百度" };


        private void button_download_Click(object sender, EventArgs e)
        {
            imp.getIdAndCompanyTd(address, id, companyId);
            info =imp.getPracticeInfo(id, companyId);
            pracInfo.setPracticeInfoToFile("..//..//..//data.txt", info);
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_display_Click(object sender, EventArgs e)
        {
            displayForm form3 = new displayForm();
            form3.Show();

        }
        private void button_renew_Click(object sender, EventArgs e)
        {
            RenewForm form4 = new RenewForm();
            form4.Show();

        }


    }
}
