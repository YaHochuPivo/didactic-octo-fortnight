using System;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Крестики_нолики
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string vivod;
        public int i, ini, f;
        public Button[] buttons = new Button[9];
        public MainWindow()
        {
            InitializeComponent();
            buttons[0] = Bt1_1;
            buttons[1] = Bt1_2;
            buttons[2] = Bt1_3;
            buttons[3] = Bt2_1;
            buttons[4] = Bt2_2;
            buttons[5] = Bt2_3;
            buttons[6] = Bt3_1;
            buttons[7] = Bt3_2;
            buttons[8] = Bt3_3;

            Block();  // блокировка всех кнопок для того чтобы игру нельзя было начать до нажатия кнопки старт
        }

        private void Butt_Click(object sender, RoutedEventArgs e)      // метод нажатия на кнопку : сначала ходим мы и кнопка на которую мы походили блокируется
        {
            (sender as Button).Content = "x";
            //блокировка кнопки после её нажатия
            (sender as Button).IsEnabled = false;

            Pl1();   // проверка на победу крестиков
            Pl3();

            if (CheckIfEverythingIsBlocked() != 9)  // условиепродолжения проверки победы которое продолжается если все 9 кнопок не заблокированы
            {
                Random(); // рандомайзер с постановкой и блокировкой кнопки

                Pl2(); // проверка на победу ноликов 

                Pl3(); // проверка на нечью
            }

        }

        private void Start_Game(object sender, RoutedEventArgs e)       // стартовая кнопка которая заблокирует все кнопки, очищает их текст и прводит все счётчики в стартовое состояние
        {
            // то что происходит в цикле

            //Bt1_1.IsEnabled = true;
            //Bt1_1.Content = "";
            //Bt1_2.IsEnabled = true;
            //Bt1_2.Content = "";
            //Bt1_3.IsEnabled = true;
            //Bt1_3.Content = "";
            //Bt2_1.IsEnabled = true;
            //Bt2_1.Content = "";
            //Bt2_2.IsEnabled = true;
            //Bt2_2.Content = "";
            //Bt2_3.IsEnabled = true;
            //Bt2_3.Content = "";
            //Bt3_1.IsEnabled = true;
            //Bt3_1.Content = "";
            //Bt3_2.IsEnabled = true;
            //Bt3_2.Content = "";
            //Bt3_3.IsEnabled = true;
            //Bt3_3.Content = i;
            i++;
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
            Winn.Text = "";
            ini = 0;
            f = 0;

            Btgm.Content = i;
        }

        public void Pl1()             // проверка на победу крестиков
        {
            if (Bt1_1.Content == "x") // проверка от первой кнопки в низ и в право
            {
                if (Bt1_2.Content == "x" & Bt1_3.Content == "x")
                {
                    Winn.Text = "Выйграл крестик";
                    Block();
                }
                else if (Bt2_1.Content == "x" & Bt3_1.Content == "x")
                {
                    Winn.Text = "Выйграл крестик";
                    Block();
                }
            }

            if (Bt2_2.Content == "x") // проверка от центральной кнопки по прямым и крест накрест
            {
                if (Bt1_2.Content == "x" & Bt3_2.Content == "x")
                {
                    Winn.Text = "Выйграл крестик";
                    Block();
                }
                else if (Bt2_1.Content == "x" & Bt2_3.Content == "x")
                {
                    Winn.Text = "Выйграл крестик";
                    Block();
                }
                else if (Bt1_1.Content == "x" & Bt3_3.Content == "x")
                {
                    Winn.Text = "Выйграл крестик";
                    Block();
                }
                else if (Bt1_3.Content == "x" & Bt3_1.Content == "x")
                {
                    Winn.Text = "Выйграл крестик";
                    Block();
                }
            }

            if (Bt3_3.Content == "x") // проверка от последней кнопки в верх и в лево
            {
                if (Bt2_3.Content == "x" & Bt1_3.Content == "x")
                {
                    Winn.Text = "Выйграл крестик";
                    Block();
                }
                else if (Bt3_2.Content == "x" & Bt3_1.Content == "x")
                {
                    Winn.Text = "Выйграл крестик";
                    Block();
                }
            }
        }

        public void Pl2()                 // проверка на победу ноликов
        {
            if (Bt1_1.Content == "o") // проверка от первой кнопки в низ и в право
            {
                if (Bt1_2.Content == "o" & Bt1_3.Content == "o")
                {
                    Winn.Text = "Выйграл нолик";
                    Block();
                }
                if (Bt2_1.Content == "o" & Bt3_1.Content == "o")
                {
                    Winn.Text = "Выйграл нолик";
                    Block();
                }
            }

            if (Bt2_2.Content == "o") // проверка от центральной кнопки по прямым и крест накрест
            {
                if (Bt1_2.Content == "o" & Bt3_2.Content == "o")
                {
                    Winn.Text = "Выйграл нолик";
                    Block();
                }
                else if (Bt2_1.Content == "o" & Bt2_3.Content == "o")
                {
                    Winn.Text = "Выйграл нолик";
                    Block();
                }
                else if (Bt1_1.Content == "o" & Bt3_3.Content == "o")
                {
                    Winn.Text = "Выйграл нолик";
                    Block();
                }
                else if (Bt1_3.Content == "o" & Bt3_1.Content == "o")
                {
                    Winn.Text = "Выйграл нолик";
                    Block();
                }
            }

            if (Bt3_3.Content == "o") // проверка от последней кнопки в верх и в лево
            {
                if (Bt2_3.Content == "o" & Bt1_3.Content == "o")
                {
                    Winn.Text = "Выйграл нолик";
                    Block();
                }
                else if (Bt3_2.Content == "o" & Bt3_1.Content == "o")
                {
                    Winn.Text = "Выйграл нолик";
                    Block();
                }
            }
        }

        private int CheckIfEverythingIsBlocked()     // подсчёт заблоченых кнопок
        {
            f = 0;
            foreach (Button button in buttons)
            {
                if (button.IsEnabled == false)
                {
                    f++;
                }
            }
            return f;
        }

        public void Pl3()
        {

            if (CheckIfEverythingIsBlocked() == 9 && Winn.Text != "Выйграл нолик" && Winn.Text != "Выйграл крестик")  // проверка ничьей через метод который считает заблокированные кнопки
            {
                Winn.Text = "Ничья";
                Block();
            }
        }

        public void Random()
        {
            Random random = new Random();
            while (true)
            {
                int value = random.Next(0, 9);          // Генерация случайного числа от 0 до 8
                if (buttons[value].IsEnabled == true)
                {
                    buttons[value].Content = "o";
                    buttons[value].IsEnabled = false;
                    ini++;
                    return;
                }
                else if (ini == 4)
                {
                    break;
                }
            }
        }

        public void Block()                         // блок блокировки всех кнопок
        {
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }
    }
}