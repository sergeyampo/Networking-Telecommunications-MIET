using System;
using System.IO;
using System.Net;

namespace FTP
{
    class Program
    {
        static void Main(string[] args)
        {
           // Создаем объект FtpWebRequest
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/test.txt");
            // устанавливаем метод на загрузку файлов
            request.Method = WebRequestMethods.Ftp.DownloadFile;
 
            // если требуется логин и пароль, устанавливаем их
            //request.Credentials = new NetworkCredential("login", "password");
            //request.EnableSsl = true; // если используется ssl
 
            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
 
            // получаем поток ответа
            Stream responseStream = response.GetResponseStream();
            // сохраняем файл в дисковой системе
            // создаем поток для сохранения файла
            FileStream fs = new FileStream("newTest.txt",FileMode.Create);
 
            //Буфер для считываемых данных
            byte[] buffer = new byte[64];
            int size = 0;
 
            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);
 
            }
            fs.Close();
            response.Close();
             
            Console.WriteLine("Загрузка и сохранение файла завершены");
            Console.Read();
        }
    }
}
