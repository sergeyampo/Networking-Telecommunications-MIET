using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;


namespace Http
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

        public async void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tb_adress.Text == "")
                    throw new Exception("Enter adress");
                using var client = new HttpClient();
                var content = await client.GetStringAsync(tb_adress.Text);
                tb_content.Text = "";
                tb_content.Text = content;
                l_erorr.Content = "";
                
            }
            catch (Exception ex)
            {
                l_erorr.Content = ex.Message;
            }
        }

    }
}
