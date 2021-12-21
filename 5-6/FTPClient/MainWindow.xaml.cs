using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FTPClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tb_adress.Text == "")
                    throw new Exception("Enter adress");
                // Создаем объект FtpWebRequest
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tb_adress.Text);
                // устанавливаем метод на загрузку файлов
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // получаем ответ от сервера в виде объекта FtpWebResponse
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                // получаем поток ответа
                Stream responseStream = response.GetResponseStream();
                // сохраняем файл в дисковой системе
                // создаем поток для сохранения файла
                FileStream fs = new FileStream(new Guid().ToString(), FileMode.Create);

                //Буфер для считываемых данных
                byte[] buffer = new byte[1024];
                int size = 0;

                while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, size);

                }
                fs.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                l_erorr.Content = ex.Message;
            }
        }
    }
}
