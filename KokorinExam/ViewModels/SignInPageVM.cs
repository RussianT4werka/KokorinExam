using KokorinExam.DB;
using KokorinExam.Models;
using KokorinExam.Tools;
using KokorinExam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KokorinExam.ViewModels
{
    public class SignInPageVM: BaseVM
    {
        private readonly Canvas capchaCanvas;
        string capchaValue;
        private Visibility capchaVisible = Visibility.Collapsed;
        private MainWindowVM mainVM;
        public string CapchaText { get; set; }
        public string Login { get; set; }  
        public string Password { get; set; } 
        public User User { get; set; }
        public Command SignIn { get; set; }

        public Visibility CapchaVisible
        {
            get => capchaVisible;
            set
            {
                capchaVisible = value;
                SignalChanged();
            }
        }
        public SignInPageVM(MainWindowVM mainVM, System.Windows.Controls.Canvas capchaCanvas)
        {
            this.capchaCanvas = capchaCanvas;
            this.mainVM = mainVM;
            SignIn = new Command(() =>
            {
                if (CapchaVisible == Visibility.Collapsed)
                {
                    SignInM();
                }
                else
                {
                    if (capchaValue == CapchaText)
                    {
                        SignInM();
                    }
                    else
                    {
                        MessageBox.Show("Ты робот!");
                        GenerateCapcha();
                    }
                }
            });
        }

        private void SignInM()
        {
            if (!string.IsNullOrEmpty(Login) || !string.IsNullOrEmpty(Password))
            {
                User = examKokorinContext.GetInstance().Users.FirstOrDefault(s => s.Login == Login && s.Password == Password);
                if (User != null)
                {
                    mainVM.CurrentPage = new Views.InfoPage(User, mainVM);
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                    CapchaVisible = Visibility.Visible;
                    GenerateCapcha();
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        

        private void GenerateCapcha()
        {
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green,
                     Brushes.Orange,
                     Brushes.Gray,
                     Brushes.Brown};

            int[] num = { 4, 5, 6 };

            capchaCanvas.Children.Clear();
            Random rnd = new Random();
            string value = "";
            string temp;
            char f = (char)rnd.Next(65, 91);
            for (int i = 0; i < num[rnd.Next(0, num.Length)]; i++)
            {
                if (rnd.NextDouble() > 0.3)
                {
                    temp = ((char)rnd.Next(65, 91)).ToString();
                    if (rnd.NextDouble() > 0.5)
                        temp = temp.ToLower();
                }
                else
                    temp = ((char)rnd.Next(48, 58)).ToString();
                TextBlock text = new TextBlock();
                text.Text = temp;
                text.FontSize = 35;
                text.Foreground = colors[rnd.Next(0, colors.Length)];
                capchaCanvas.Children.Add(text);
                Canvas.SetLeft(text, i * 10 + 5);
                Canvas.SetTop(text, 5 + rnd.Next(-5, 5));
                value += temp;
            }
            capchaValue = value;
        }
    }
}
