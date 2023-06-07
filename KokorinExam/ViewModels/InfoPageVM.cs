using KokorinExam.Models;
using KokorinExam.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokorinExam.ViewModels
{
    public class InfoPageVM: BaseVM
    {
        public User User { get; set; }

        public InfoPageVM(Models.User user)
        {
            User = user;
        }
    }
}
