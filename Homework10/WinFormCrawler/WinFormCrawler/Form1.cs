using SimpleCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Concurrent;

namespace WinFormCrawler
{
    public partial class Form1 : Form
    {
        BindingSource ResultBindingSource = new BindingSource();
        Crawler Crawler = new Crawler();
        Thread thread = null;

        public Form1()
        {
            InitializeComponent();
            ResultGridView.DataSource = ResultBindingSource;
            Crawler.PageDownloaded += PageDownloaded;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            ResultBindingSource.Clear();
            Crawler.MyUrls=new ConcurrentBag<Urls>();
            Crawler.Num = 0;
            Crawler.StartUrl = TestUrl.Text;
            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(Crawler.Crawl);
            thread.Start();
        }

        private void PageDownloaded(Crawler crawler, Urls url)
        {
            lock(ResultBindingSource) 
            {
                var pageInfo = new { Index = ResultBindingSource.Count + 1, URL = url.Url };
                Action action = () => { ResultBindingSource.Add(pageInfo); };
                if (this.InvokeRequired)
                {
                    this.Invoke(action);
                }
                else
                {
                    action();
                }
            }        
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (thread != null)
                thread.Abort();
        }
    }
}
