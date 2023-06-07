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

namespace KokorinExam.ViewModels
{
    public class SignInPageVM: BaseVM
    {
        public string Login { get; set; }  

        public string Password { get; set; } 
        public User User { get; set; }
        public Command SignIn { get; set; }
        public SignInPageVM(MainWindowVM mainVM)
        {

            SignIn = new Command(() =>
            {
                if(!string.IsNullOrEmpty(Login) || !string.IsNullOrEmpty(Password))
                {
                    User = examKokorinContext.GetInstance().Users.FirstOrDefault(s => s.Login == Login && s.Password == Password);
                    if(User != null)
                    {
                        mainVM.CurrentPage = new Views.InfoPage(User);
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            });
        }

    }
}
