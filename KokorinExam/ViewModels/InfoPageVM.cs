using KokorinExam.DB;
using KokorinExam.Models;
using KokorinExam.Tools;
using KokorinExam.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokorinExam.ViewModels
{
    public class InfoPageVM: BaseVM
    {
        public User User { get; set; }
        public Command SignOut { get; set; }
        public Command Del { get; set; }

        public InfoPageVM(Models.User user, MainWindowVM mainVM)
        {
            User = user;
            if (User.Photo == null)
            {
                User.Photo = File.ReadAllBytes(@"Photo\User.png");
            }
            SignOut = new Command(() =>
            {
                mainVM.CurrentPage = new SignInPage(mainVM);
            });

            Del = new Command(() =>
            {
                User.Photo = null;
                examKokorinContext.GetInstance().Update(User);
                examKokorinContext.GetInstance().SaveChanges();
            });


        }
    }
}
