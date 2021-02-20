using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Develop\Test\WindowsFormsApp1\WindowsFormsApp1\Pic\5.JPG";
            Bitmap image = new Bitmap(fileName) ;
            //此处为 image 变量赋值，就是要解析的二维码图片。可以从本地取、可以上传、也可以使用HttpWebRequest从网络获取
            
            QRCodeDecoder decoder = new QRCodeDecoder();
            string decodedString = decoder.decode(new QRCodeBitmapImage(image));
            txtResult.Text = decodedString;
        }

        /// <summary>
        /// 返回二维码定义的字符串
        /// </summary>
        public static string Decode(Bitmap image)
        {
            QRCodeBitmapImage qrCodeBitmapImage = new QRCodeBitmapImage(image);
            QRCodeDecoder qrCodeDecoder = new QRCodeDecoder();
            return qrCodeDecoder.decode(qrCodeBitmapImage); 
        }

        /// <summary>
        /// 返回二维码定义的字符串
        /// </summary>
        public static string Decode(string path) => Decode(new Bitmap(path));
    }
}
