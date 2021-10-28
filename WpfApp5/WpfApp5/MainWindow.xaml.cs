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
using System.IO;
using Microsoft.Win32;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] mas;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Расчет
            for (int i = 0; i < mas.Length; i++)
            {
                if(mas[i] < 0)
                {
                    int g;
                    g = mas[i] * mas[i];
                    TB3.Items.Add(g);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Выход
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Отчистка массива
            DG.ItemsSource = null;
            mas = null;
            TB3.Items.Clear();
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            //Создать ячейки для массива
            int Count = Convert.ToInt32(TB1.Text);
            mas = new int[Count];
            DG.ItemsSource = Class1.ToDataTable(mas).DefaultView;
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            //Заполнить массив
            int randMax = Convert.ToInt32(TB2.Text);
            int Count = Convert.ToInt32(TB1.Text);
            mas = new int[Count];
            Random Rand = new Random();
            for (int i = 0; i < mas.Length; i++) mas[i] = Rand.Next(randMax);
            DG.ItemsSource = Class1.ToDataTable(mas).DefaultView;
        }

        private void DG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //DataGrid
            int indexColumn = e.Column.DisplayIndex;
            int indexRow = e.Row.GetIndex();
            mas[indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //О Программе
            MessageBox.Show("ПР 21 1 часть, И.И Бобров ИСП-22, Ввести n целых чисел. Вычислить для чисел < 0 функцию x^2 Результат обработки каждого числа вывести на экран.");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            //save.FileName = 
            if (save.ShowDialog() == true)
            {
            StreamWriter file = new StreamWriter(save.FileName);

            file.WriteLine(mas.Length);

            for (int i = 0; i < mas.Length; i++)
            {
              file.WriteLine(mas[i]);
            }
            file.Close();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
            StreamReader file = new StreamReader(open.FileName);

            int len = Convert.ToInt32(file.ReadLine());

            mas = new int[len];

            for (int i = 0; i < mas.Length; i++)
            {
            mas[i] = Convert.ToInt32(file.ReadLine());
            }
            DG.ItemsSource = Class1.ToDataTable(mas).DefaultView;
            }
        }
    }
}
