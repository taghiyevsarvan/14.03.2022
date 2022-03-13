using System;

namespace _14._03._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Mehsul sayini daxil edin: ");
            //int arrLength= int.Parse(Console.ReadLine());
            //new Product = new Product[arrLength];
            string lengthStr;
            int length;
            do
            {
                Console.Write("Yaddasda tutulacaq kitab sayini daxil edin: ");
                lengthStr = Console.ReadLine();
                length = Convert.ToInt32(lengthStr);
            } while (length < 0);

            Book[] products = new Book[length];
            for (int i = 0; i < length; i++)
            {
                int no = GetInputInt($"{i + 1}. kitabin No-su: ",int.MaxValue,0);

                int count = GetInputInt($"{i+1}. kitabin sayi: ",int.MaxValue,0);

                string name = GetInputStr($"{i + 1 }. kitabin adi: ",30,3);

                string genre = GetInputStr($"{i + 1 }. kitabin janri: ",30,3);

                double price = GetInputDouble($"{i + 1}. kitabin qiymeti: ",250,0.5);

                products[i] = new Book(no, name, price,genre)
                {
                    Count = count
                };
            }

            Console.WriteLine("\n**********************");

            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine($"{i+1}.ci kitab: ");
                Console.WriteLine(products[i].GetInfo());
            }

            
        }

        static string GetInputStr(string name, int max,int min)
        {
            string input;
            do
            {
                Console.WriteLine(name);
                input = Console.ReadLine();

            } while (input.Length<min || input.Length>max);
            return input;
        }

        static int GetInputInt(string name, int max, int min)
        {
            int input;
            string inputStr;
            do
            {
                Console.WriteLine(name);
                inputStr = Console.ReadLine();
                input = Convert.ToInt32(inputStr);
            } while (input<min || input>max);

            return input;
        }

        static double GetInputDouble(string name, double max, double min)
        {
            double input;
            string inputStr;
            do
            {
                Console.WriteLine(name);
                inputStr = Console.ReadLine();
                input = Convert.ToDouble(inputStr);
            } while (input < min || input > max);

            return input;
        }
    }
}
