using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace day1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*// отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
            // кому отправляем
            MailAddress to = new MailAddress("somemail@yandex.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            smtp.Send(m);*/
            
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            tex1.Text = "";
            tex2.Text = "";
            tex3.Text = "";
        }

        private void tex1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tex1.Text == "")
            {
                commit.IsEnabled = true;
            }
            else
            {
                commit.IsEnabled = false;
            }
            if (tex1.Text == "")
            {
                MessageBox.Show("EMPTY");
            }
            string num = tex1.Text;
            SqlConnection con = new SqlConnection(@"Data Source=PC310-15\SQLEXPRESS;Initial Catalog=iof;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from tof where номер="+num+"",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
                MessageBox.Show("READY");
            }           
            else
            {
                MessageBox.Show("Такого номера сотрудника не существует");
            }
        }
        private void tex2_KeyUp(object sender, KeyEventArgs e)
        {
            string num = tex1.Text;
           /* Regex code = new Regex(@"^[a-zA-Z0-9]{1,8}$");
            Regex passs = new Regex(@"^[0-9]{1,4}$");
            MatchCollection matches = passs.Matches(tex2.Text);*/
            if (e.Key == Key.Enter & tex2.Text.Length != 0 /*& tex2.Text == matches.ToString()*/)
            {
                PassWindow passwordWindow = new PassWindow();

                if (passwordWindow.ShowDialog() == true)
                {
                    if (passwordWindow.Password == "c8DzJeTC9t" || passwordWindow.Password == "rvbrYASYyh" || passwordWindow.Password == "SUTniBMrme"
                        || passwordWindow.Password == "uTZgVwuoHs" || passwordWindow.Password == "v7eerXyUru" || passwordWindow.Password == "YGDS3ds" ||
                        passwordWindow.Password == "Hfd221da")
                    {
                        MessageBox.Show("Авторизация пройдена");
                        tex3.Text = info.io;
                    }                 
                    else
                        MessageBox.Show("Неверный пароль");
                }
                else
                {
                    MessageBox.Show("Авторизация не пройдена");
                }
            }
            else
            {
                MessageBox.Show("неверно");
            }
        }
    }
}
