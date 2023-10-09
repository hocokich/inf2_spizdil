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

namespace inf2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string num1;
        public string num2;
        public MainWindow()
        {
            InitializeComponent();
        }
        private static int[] binaryAdd(int[] a, int[] b) //сложение двух массивов
        {
            for (int i = 7; i >= 0; i--)
            {
                if (b[i] == 1)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (a[j] == 1)
                            a[j] = 0;
                        else
                        {
                            a[j] = 1;
                            break;
                        }
                    }
                }
            }
            return a;
        }

        private static int[] binarySub(int[] a, int[] b) //вычитание массива b из a
        {
            int[] c = { 0, 0, 0, 0, 0, 0, 0, 0 };

            c = Invert((int[])b.Clone());

            a = binaryAdd(a, c);

            return a;
        }

        private static int[] binaryMul(int[] a, int[] b) //умножение двух массивов
        {
            int[] c = { 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 7; i >= 0; i--)
            {
                if (b[i] == 1) c = binaryAdd(c, a);
                a = MoveArr(a, 1);
            }

            return c;
        }
        private static int[] binaryDiv(int[] a, int[] b) //деление двух массивов
        {
            int[] d = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] temp_a = (int[])a.Clone();
            int[] r = new int[8];
            //r[7] = a[0];
            //r - b
            //r << 1
            //r[7] = a[1]

            for (int i = 0; i <= 7; i++)
            {
                MoveArr(r, 1);
                r[7] = a[i];
                temp_a = (int[])r.Clone();
                binarySub(temp_a, b);
                if (temp_a[0] == 0)
                {
                    r = (int[])temp_a.Clone();
                    d[i] = 1;
                }
                else d[i] = 0;


                //for (int j = 0; j < 7 - i; j++) MoveArr(temp_a, 2);

                //binarySub(temp_a, b);

                //if (temp_a[0] == 1)
                //{
                //    temp_a = (int[])a.Clone();

                //    d[i] = 0;
                //}
                //else
                //{
                //    int[] temp_b = (int[])b.Clone();

                //    for (int j = 0; j < 7 - i; j++) MoveArr(temp_b, 1);

                //    binarySub(a, temp_b);

                //    d[i] = 1;
                //}
            }

            return d;
        }

        private static int[] MoveArr(int[] a, int b) // сдвиг влево, если 1 и 2 - вправо
        {
            if (b == 1)
            {
                for (int i = 0; i < 7; i++) a[i] = a[i + 1];
                a[7] = 0;
            }
            if (b == 2)
            {
                for (int i = 7; i >= 1; i--) a[i] = a[i - 1];
                a[0] = 0;
            }

            return a;
        }
        private static int[] Invert(int[] a)
        {
            for (int i = 7; i >= 0; i--)
            {
                if (a[i] == 1) a[i] = 0; else a[i] = 1;
            }

            int[] b = { 0, 0, 0, 0, 0, 0, 0, 1 };

            binaryAdd(a, b);

            return a;
        }
        static int[] StrToBin(string n)//преобразовываем строку в массив
        {
            int[] bin = new int[8];
            for (int i = 0; i < 8; i++)
            {
                bin[i] = int.Parse(Char.ToString(n[i]));
            }
            return bin;
        }
        static string BinToStr(int[] n) //преобразуем массив в строку
        {
            string str = String.Join("", n); //https://learn.microsoft.com/ru-ru/dotnet/api/system.string.join?view=net-7.0
            return str;
        }
        private void plus_Click(object sender, RoutedEventArgs e)//кнопка сложения
        {
            num1 = A.Text;
            num2 = B.Text;
            result.Text = BinToStr(binaryAdd(StrToBin(num1), StrToBin(num2)));
        }
        private void minus_Click(object sender, RoutedEventArgs e)//кнопка вычитания
        {
            num1 = A.Text;
            num2 = B.Text;
            result.Text = BinToStr(binarySub(StrToBin(num1), StrToBin(num2)));
        }
        private void multi_Click(object sender, RoutedEventArgs e)//конпка умножения
        {
            num1 = A.Text;
            num2 = B.Text;
            result.Text = BinToStr(binaryMul(StrToBin(num1), StrToBin(num2)));
        }
        private void division_Click(object sender, RoutedEventArgs e)//кнопка деления
        {
            num1 = A.Text;
            num2 = B.Text;
            result.Text = BinToStr(binaryDiv(StrToBin(num1), StrToBin(num2)));
        }
        private void A_TextChanged(object sender, TextChangedEventArgs e)//тексбокс для 1 числа
        {

        }
        private void B_TextChanged(object sender, TextChangedEventArgs e)//текстбокс для 2 числа
        {

        }
        private void result_TextChanged(object sender, TextChangedEventArgs e)//ответ в текстбоксе
        {

        }
    }
/*
    int[] chastnoe = new int[8];
    int nomer_elementa_delimovo = 0;//5
            for (int i = 7; i >= 0; i--)
            {
                if (Perevorot(delimoe)[i] == 1)
                {
                    nomer_elementa_delimovo = i + 1;
                    break;
                }
            }
            int nomer_elementa_delitela = 0;//2
for (int i = 7; i >= 0; i--)
{
    if (Perevorot(delitel)[i] == 1)
    {
        nomer_elementa_delitela = i + 1;
        break;
    }
}

for (int i = nomer_elementa_delimovo - nomer_elementa_delitela; i >= 1; i--)//3 раза сдвигаем влево делитель
{
    delitel = Sdvig(delitel, 1); // привели крайнюю левую 1 делителя к делимому
}*/

    /*static string BinaryDivision(int[] n1, int[] n2)// деление
    {
        string chastnoe = ""; //результат
        int[] delimoe = n2; //делитель
        for (int i = 7; i >= 0; i--)
        {
            if (n1[i] == 1)
            {
                while (i + 1 > 0)
                {
                    if (delimoe[0] >= n2[0])
                    {
                        chastnoe += "1";
                        delimoe = BinarySub(delimoe, n2);
                    }
                    else
                    {
                        chastnoe += "0";
                    }
                    delimoe = SdvigLevo(delimoe);
                    i--;
                }
                break;
            }
        }
        return chastnoe;// возращаемое значение
    }*/

    /*static string BinaryDivision(string numerator, string denominator)// деление
    {
        int resultLength = numerator.Length;
        string result = ""; //результат
        string numeratorCopy = numerator; //числитель

        while (resultLength > 0)
        {
            if (numeratorCopy[0] >= denominator[0])
            {
                result += "1";
                numeratorCopy = BinarySub(numeratorCopy, denominator);
            }
            else
            {
                result += "0";
            }

            numeratorCopy = numeratorCopy.Substring(1) + "0";
            resultLength--;
        }
        return result;// возращаемое значение
    }*/

    /*if (BinToInt(BinarySub(delimoe, delitel)) > 0)
                {
                    SdvigLevo(delitel);
                    chastnoe[i] = 0;
                    break;
                }
                if (BinToInt(BinarySub(delimoe, delitel)) == 0)
                {
                    delimoe = BinarySub(delimoe, delitel);
                    chastnoe[i] = 1;
                }
                else
                {
                    SdvigPravo(delitel);
                    delimoe = BinarySub(delimoe, delitel);
                    chastnoe[i] = 1;
                    break;
                }*/

    /*static int[] DivideBinary(int[] dividend, int[] divisor)
    {
        if (divisor == "0")
        {
            throw new DivideByZeroException("Деление на ноль невозможно.");
        }

        string quotient = "";
        string remainder = dividend;

        for (int i = 0; i < dividend.Length; i++)
        {
            // Сдвигаем остаток на один бит влево и добавляем следующий бит из делимого числа
            remainder += dividend[i].ToString();

            // Если остаток больше или равен делителю, добавляем 1 в частное и вычитаем делитель
            if (IsGreaterOrEqual(remainder, divisor))
            {
                quotient += "1";
                remainder = SubtractBinary(remainder, divisor);
            }
            else
            {
                quotient += "0";
            }
        }

        return (quotient, remainder);
    }

    static bool IsGreaterOrEqual(string binaryA, string binaryB)
    {
        int lengthA = binaryA.Length;
        int lengthB = binaryB.Length;

        if (lengthA > lengthB)
        {
            return true;
        }
        else if (lengthA < lengthB)
        {
            return false;
        }
        else
        {
            return binaryA.CompareTo(binaryB) >= 0;
        }
    }*/
}