using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1
{
    class PracticeInfo
    {

        public string name { get; set; }
        public string duty { get; set; }
        public string request { get; set; }
        public string location { get; set; }
        public string compname { get; set; }
        public string compinfo { get; set; }
        public string compweb { get; set; }

        //default print
        public override string ToString()
        {
            string s = name + "\t" + request + "\t" + duty +
                  "\t" + location + "\t" + compname + "\t" +
                  compinfo + "\t" + compweb + "\t";
            return s;

        }

        //读取
        public List<PracticeInfo> getPracticeInfoFromFile(string file)
        {

            StreamReader sr = new StreamReader(file, Encoding.UTF8);
            String data = sr.ReadToEnd();
            //用于存储读取的每一行数据
            List<String> li = new List<String>();                  
            List<PracticeInfo> list = new List<PracticeInfo>();

            //按行切分，存入li
            string[] m = data.Split(new char[] { '\n' });
            for(int k=0; k < m.Length; k++)
            {
                li.Add(m[k]);
            }
            sr.Close();

            //每行切分，存入具体的pracinfo
            for (int i = 0; i < li.Count-1; i++)
            {
                PracticeInfo tempPrac = new PracticeInfo();
                string tempLi = li[i];
                string[] n = tempLi.Split(new char[] { '\t' });
                SetPracticeInfoByString(tempPrac, n);
                list.Add(tempPrac);
            }

            return list;
        }

        //写入
        public void setPracticeInfoToFile(String filepath, List<PracticeInfo> practices)
        {
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //按行写入
            foreach (PracticeInfo practice in practices)
            {
                sw.WriteLine(practice.ToString());
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

        
        public void SetPracticeInfoByString(PracticeInfo prf, String[] contentlist)
        {
            prf.name = contentlist[0];
            prf.request = contentlist[1];
            prf.duty = contentlist[2];
            prf.location = contentlist[3];
            prf.compname = contentlist[4];
            prf.compinfo = contentlist[5];
            prf.compweb = contentlist[6];

        }
       
    }
}
    

    

    

   
