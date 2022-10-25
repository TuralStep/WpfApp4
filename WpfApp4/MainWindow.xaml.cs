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

namespace WpfApp4
{
    public partial class MainWindow : Window
    {

        public List<Message> Messages { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            //Messages = new List<Message>()
            //{
            //    new Message("Yoxlama",DateTime.Now),
            //    new Message("Yoxlama 2",DateTime.Now),
            //    new Message("Yoxlama 3",DateTime.Now),
            //    new Message("Yoxlama 4",DateTime.Now)
            //};

            Messages = new List<Message>(1);
        }

        private void send_btn_Click(object sender, RoutedEventArgs e)
        {
            string msg = fixMessage(msg_txt.Text);

            if (string.IsNullOrEmpty(msg))
                return;

            messages_lb.ItemsSource = null;
            Messages.Add(new Message(msg, DateTime.Now));

            if (Messages.Count > 10)
                Messages.RemoveAt(0);

            msg_txt.Text = "";
            messages_lb.ItemsSource = Messages;

            if (msg
                .ToLower()
                .Equals("salam"))
                Messages.Add(new Message("Bot:       Salam", DateTime.Now));
            else if (msg
                        .ToLower()
                        .Equals("necesen") ||
                     msg
                        .ToLower()
                        .Equals("necesen?") ||
                     msg
                        .ToLower()
                        .Equals("necesen ?"))
                Messages.Add(new Message("Bot:       Yaxsiyam. Sen necesen ?", DateTime.Now));

            messages_lb.ItemsSource = null;
            messages_lb.ItemsSource = Messages;
        }

        private void msg_txtKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                send_btn_Click(sender, e);
        }

        private string fixMessage(string message)
        {
            StringBuilder sb = new(message);

            if (sb.Length > 40)
            {
                for (int i = 0; i < sb.Length; i += 40)
                {
                    sb.Insert(i, '\n');
                }
            }
            sb.Remove(0, 1);

            return sb.ToString();
        }
    }
}
