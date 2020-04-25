using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace SimpleCrawler
{
    class Urls
    {
        public string Url { get; set; }
        public bool Pro { get; set; }
        public string Html { get; set; }

    }

    class Crawler
    {
        public event Action<Crawler, Urls> PageDownloaded;
        public ConcurrentBag<Urls> MyUrls = new ConcurrentBag<Urls>();
        public int Num = 0;
        public static string StartUrl = "";
        public static string StartWith = "";

        public void Crawl()
        {
            Urls surl = new Urls() { Url = StartUrl, Pro = false, Html = "" };
            MyUrls.Add(surl);
            string str = @"(www\.){0,1}.*?\..*?/";
            Regex r = new Regex(str);
            Match m = r.Match(StartUrl);
            StartWith = m.Value;
            while (true)
            {
                Urls Now = null;
                foreach (Urls url in MyUrls)
                {
                    if (url.Pro) continue;
                    Now = url;
                    if (Num > 20)
                        break;
                    if (Now == null)
                        continue;
                    Now.Pro = true;
                    var t = new Thread(() => Process(Now));
                    t.Start();
                    Num++;
                }
            }
        }

        public bool UrlExists(string url)
        {

            foreach (Urls Tmp in MyUrls)
            {
                if (Tmp.Url == url)
                    return true;
            }
            return false;
        }

        public void Process(Urls url)
        {
            try
            {
                
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url.Url);
                string fileName = Num.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                url.Html = html;
                PageDownloaded(this, url);
                Parse(html, url.Url);//解析,并加入新的链接
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ;
            }
        }

        private void Parse(string html, string oldUrl)
        {

            //匹配不含相对路径且包含html的网址
            string strRef = @"(href|HREF)[ ]*=[ ]*[""'](http|https)[^""'#>]+..html.*?[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (strRef.Length == 0)
                    continue;
                //仅包含起始网站上的网页
                if (strRef.Contains(StartWith))
                {
                    if (!UrlExists(strRef))
                    {
                        MyUrls.Add(new Urls() { Url = strRef, Pro = false, Html = "" });
                    }

                }
            }

            //匹配相对路径且包含html的网址
            strRef = @"(href|HREF)[ ]*=[ ]*[""'][^(http|https)][^""'#>]+..html.*?[""']";
            matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                //仅包含起始网站上的网页
                if (strRef.Contains(StartWith))
                {
                    if (!UrlExists(strRef))
                    {
                        MyUrls.Add(new Urls() { Url = strRef, Pro = false, Html = "" });
                    }
                }
            }
        }
    }
}
