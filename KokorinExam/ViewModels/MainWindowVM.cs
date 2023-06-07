﻿using KokorinExam.Tools;
using KokorinExam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KokorinExam.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        private Page currentPage;

        public Page CurrentPage 
        {
            get => currentPage;
            set
            {
                currentPage = value;
                SignalChanged();
            }
        }

        public MainWindowVM()
        {
            CurrentPage = new SignInPage(this);
        }
    }
}
