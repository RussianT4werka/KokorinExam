using KokorinExam.DB;
using KokorinExam.Models;
using KokorinExam.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace KokorinExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
            //    string file = @"C:\Users\Student\Desktop\examKokorin\20.csv";
            //    string dirImage = @"C:\Users\Student\Desktop\examKokorin\Images\";
            //    string[] rows = File.ReadAllLines(file).Skip(1).ToArray();
            //    var spl = new char[] { ';' };

            //    foreach (var row in rows)
            //    {
            //        var cols = row.Split(spl, StringSplitOptions.RemoveEmptyEntries);
            //        if (cols.Length == 8)
            //        {
            //            User user = examKokorinContext.GetInstance().Users.FirstOrDefault(s => s.Surname == "Дмитриева");
            //            user.Photo = File.ReadAllBytes(dirImage + cols[7]);
            //        }
            //    }
            //    examKokorinContext.GetInstance().SaveChanges();
            //}
        }

    }
}
