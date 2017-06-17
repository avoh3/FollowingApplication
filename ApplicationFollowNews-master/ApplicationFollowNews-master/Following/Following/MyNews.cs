using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace Following
{
    public class MyNews
    {
        public string AgencyName { get; set; }
        List<NewsProp> newslist = new List<NewsProp>();
        public string language { get; set; }


        public MyNews(string name, string language = "arm")
        {
            AgencyName = name;
            this.language = language;
        }

        void NewsListCreator()
        {
            //string s3 = "<li><a href=\"(.*?)\" class=\"db fs16 arian-b\">(.*?)</a><span class=\"fs14\">(.*?)</span></li>";

            //string s = Server.SendGetRequest("http://www.armsport.am/hy");
            //List<string> list = new List<string>();

            //MatchCollection viewes = Regex.Matches(s, s1, RegexOptions.Singleline);
            //foreach (Match x in viewes)
            //{
            //    GroupCollection Group = x.Groups;
            //    var m = new NewsProp { Views = int.Parse(Group[1].Value.Trim()) };
            //    newslist.Add(m);
            //}

            
            //int i = 0;
            //MatchCollection titleslinks = Regex.Matches(s, s3, RegexOptions.Singleline);
            //foreach (Match x in titleslinks)
            //{
            //    if (i < newslist.Count)
            //    {
            //        GroupCollection Group = x.Groups;
            //        newslist[i].Link = "http://blognews.am" + Group[1].Value.Trim();
            //        newslist[i].Title = Group[2].Value.Trim();
            //        i++;
            //    }
            //    else
            //        break;
            //}

            string s3 = "<li><a href=\"(.*?)\" class=\"db fs16 arian-b\">(.*?)</a><span class=\"fs14\">(.*?)</span></li>";


            string s = Server.SendGetRequest("http://www.armsport.am/hy");
            
            int i = 0;
            MatchCollection titleslinks = Regex.Matches(s, s3, RegexOptions.Singleline);
            foreach (Match x in titleslinks)
            {
                if (i < 20)
                {
                    GroupCollection Group = x.Groups;
                    //url
                    string ss1 = Group[1].Value.Trim();
                    //content
                    string ss2 = Group[2].Value.Trim();
                    //date time
                    string ss3 = Group[3].Value.Trim();

                    NewsProp np = new NewsProp();
                    np.Link = ss1;
                    np.Title = ss2;
                    np.Date = ss3;
                    newslist.Add(np);
                }
                else
                    break;
                i++;
            }
            newslist.Remove(newslist[0]);
            newslist.Remove(newslist[1]);

        }




        public void BroadcastNews(string path)
        {
            NewsListCreator();
            using (StreamWriter r = new StreamWriter(path, true))
            {
                r.WriteLine($"<html>{Environment.NewLine}<head>{Environment.NewLine}<title>{Environment.NewLine}News{Environment.NewLine}</title>{Environment.NewLine}<head>{Environment.NewLine}<body>{Environment.NewLine}<h2>Sport news</h2>{Environment.NewLine}<hr></br>");

                foreach (var item in newslist)
                {
                    r.WriteLine(item.ToString());
                }
                r.WriteLine($"{Environment.NewLine}</body>{Environment.NewLine}</html>");
            }

        }

    }
}
