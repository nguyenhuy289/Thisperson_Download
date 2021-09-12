using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Download
{
    public partial class Form1 : Form
    {
        string time = "";
        int i = 0, t = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            i = 0;
            t = Convert.ToInt32(numericUpDown1.Value);
            timer1.Start();
            btn_Download.Enabled = false;
            label4.Text = "Bắt đầu download";            
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            label3.Text = "Đã download " + i + " ảnh !";
            label4.Text = "Bạn đã dừng download !";
            timer1.Stop();
            btn_Download.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(i < t)
            {
                
                string url_image = "https://thispersondoesnotexist.com/image";
                WebClient webClient = new WebClient();
                byte[] dataArr = webClient.DownloadData(url_image);
                time = DateTime.Now.ToString("ddMMyyyyhhMMss");
                File.WriteAllBytes(time + ".jpg", dataArr);
                i++;
                label3.Text = "Đã download " + i + " ảnh !";
                label4.Text = "Đang download ...";
                
            }
            else
            {
                i = 0;
                label4.Text = "Đã download xong " + t.ToString() + " ảnh";
                timer1.Stop();
            }
            
        }
    }
}
