using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e1
{
    class WebSpider
    {
        //获取网页html
        string GetContent(string url)
        {
            string html = "";
            // 发送查询请求
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
                // 获得流
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                html = sr.ReadToEnd();
                response.Close();
            }
            catch (Exception ex)
            {
                // 本机没有联网
                if (ex.GetType().ToString().Equals("System.Net.WebException"))
                {
                    MessageBox.Show("请检查你的计算机是否已连接上互联网。\n" + url, "提示");
                }
            }
            return html;
        }

        /// <summary>
        /// get all id and company id needed 
        /// </summary>
        public void getIdAndCompanyTd(string[] address,List<int> ID, List<int> ComID)
        {


            //网页头
            string a = "\"msg\":\"OK\",\"code\":0,\"data\":{ \"totalCnt\":1,\"totalPage\":1,\"pageSize\":10,\"jobList\":[]}}:";


            //遍历每个城市
            for (int i = 0; i < address.Length; i++)
            {
                string url_get_1 = " https://www.nowcoder.com/recommend-intern/list?page=1&address=" + address[i];
                string TolCatalog = GetContent(url_get_1);

                //判断网页是否有具体信息
                //目前不具有实际作用，因为目前page1必不为空
                if (TolCatalog.Length <= a.Length)
                {
                    break;
                }

                //获取总页数
                TolCatalog = TolCatalog.Substring(TolCatalog.IndexOf("totalPage") + 11);
                int pageNum = int.Parse(TolCatalog.Substring(0, TolCatalog.IndexOf(",")));

                //遍历每一页
                for (int j = 1; j <= pageNum; j++)
                {
                    string url_get_2 = " https://www.nowcoder.com/recommend-intern/list?page=" + j + "&address=" + address[i];
                    string catalog = GetContent(url_get_2);



                    //正则表达式，提取id
                    Regex re1 = new Regex("(?<=\"id\":).*?(?=,)", RegexOptions.None);
                    //用正则表达式提取内容
                    MatchCollection mc1 = re1.Matches(catalog);
                    foreach (Match found in mc1)
                    {
                        ID.Add(int.Parse(found.Value));

                    }

                    //正则表达式，提取companyid
                    Regex re2 = new Regex("(?<=\"internCompanyId\":).*?(?=,)", RegexOptions.None);
                    //用正则表达式提取内容
                    MatchCollection mc2 = re2.Matches(catalog);
                    foreach (Match found in mc2)
                    {
                        ComID.Add(int.Parse(found.Value));

                    }
                    
                }
            }

        }
       
        //防止网页中某项为空导致储存混乱
       private string Insurance(string s)
        {
            if (s == "")
            {
                s = "----";
            }
            return s;
        }
        
        /// <summary>
        /// return List<practiceInfo>to store all information
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="ComID"></param>
        /// <returns></returns>
        public List<PracticeInfo>  getPracticeInfo(List<int> ID, List<int> ComID)
        {
            List<PracticeInfo> practiceInfo = new List<PracticeInfo>();
             for(int i = 0; i < ID.Count; i++)
            {
                PracticeInfo tempInfo = new PracticeInfo();

                string url = "https://www.nowcoder.com/recommend-intern/" + ComID[i] + "?jobId=" + ID[i];
                string content = GetContent(url);
                //清楚html占位符
                content = content.Replace("&nbsp", " ");

                //获取岗位名称
                content = content.Substring(content.IndexOf("rec-job") + 14);
                tempInfo.name = Insurance(content.Substring(0, content.IndexOf("<")));

                //获取岗位职责
                content = content.Substring(content.IndexOf("岗位职责"));
                string dutycontent = content.Substring(0, content.IndexOf("</dl>")+5);
                //清除换行符对正则的影响
                dutycontent = dutycontent.Replace("\n", "");
                //清楚制表符对输出时切分的影响
                dutycontent = dutycontent.Replace("\t", "");
                //正则提取>和<之间的内容
                Regex re = new Regex("(?<=>).*?(?=<)", RegexOptions.None);
                MatchCollection mc1 = re.Matches(dutycontent);
                string dutycontentr = "";
                foreach (Match found in mc1)
                {
                    dutycontentr+= found;
                }
                tempInfo.duty = Insurance(dutycontentr);

                //获取岗位要求
                content = content.Substring(content.IndexOf("岗位要求"));
                string reqcontent = content.Substring(0, content.IndexOf("</dl>")+6);
                //清除换行符对正则的影响
                reqcontent = reqcontent.Replace("\n", "");
                //清楚制表符对输出时切分的影响
                reqcontent = reqcontent.Replace("\t", "");
                MatchCollection mc2 = re.Matches(reqcontent);
                string reqcontentr = "";
                foreach (Match found in mc2)
                {
                    reqcontentr += found;
                }
                tempInfo.request = Insurance(reqcontentr);


                //获取公司名称
                content = content.Substring(content.IndexOf("teacher-name")+14);
                tempInfo.compname = Insurance(content.Substring(0, content.IndexOf("<")));

                //获取地址
                content = content.Substring(content.IndexOf("com-lbs") + 9);
                tempInfo.location = Insurance(content.Substring(0, content.IndexOf("<")));

                //获取公司简介
                content = content.Substring(content.IndexOf("com-detail")-12 );
                string detailcontent = content.Substring(0, content.IndexOf("</p>")+4);
                //清除换行符对正则的影响
                detailcontent = detailcontent.Replace("\n", "");
                //清楚制表符对输出时切分的影响
                detailcontent = detailcontent.Replace("\t", "");
                MatchCollection mc3 = re.Matches(detailcontent);
                string detailcontentr = "";
                foreach (Match found in mc3)
                {
                    detailcontentr += found;
                }
                tempInfo.compinfo = Insurance(detailcontentr);


                //获取公司网址
                content = content.Substring(content.IndexOf("http"));
                tempInfo.compweb =Insurance( content.Substring(0, content.IndexOf("\"")));

                practiceInfo.Add(tempInfo);
            }
            return practiceInfo;
        }

    }
}

