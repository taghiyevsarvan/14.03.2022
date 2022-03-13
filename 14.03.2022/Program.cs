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

            #region CaseRegion

            Console.WriteLine("Davam etmek ucun secim edin:");
            Console.WriteLine("*****************************");
            Console.WriteLine("1. Kitablari qiymete gore filterle");
            Console.WriteLine("2. Kitablar icinde axtaris");
            Console.WriteLine("3.Butun kitablari goster");
            Console.WriteLine("0. Proqrami bagla");


            

            string chose;
            chose=Console.ReadLine();
            switch(chose)
            {
                case "1":
                    Console.WriteLine("Minimum ve Maximum deyerleri daxil edin;");
                    double min = GetInputDouble("Minimum qiymet: ", int.MaxValue, 0);
                    double max = GetInputDouble("Maximum qiymet: ", int.MaxValue, 0);
                    foreach (var item in Filter(products,min,max))
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    break;

                case "2":
                    Console.Write("Axtarilacaq kitabin adini daxil edin: ");
                    string searchName = Console.ReadLine();
                    foreach (var item in Search(products, searchName))
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    break;
                
                case"3":
                    Console.WriteLine("Butun kitablar:");
                    for (int i = 0; i < products.Length; i++)
                    {
                        Console.WriteLine("===================");
                        Console.WriteLine($"{i + 1}.ci kitab: ");
                        Console.WriteLine(products[i].GetInfo());
                    }
                    break;
                
                case "4":
                    break;
            }

            #endregion
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

        static Book[] Filter(Book[] products, double min, double max)
        {
            int total = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Price >= min && products[i].Price <= max)
                    total++;
            }
            Book[] productsNew = new Book[total];
            int a = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Price >= min && products[i].Price <= max)
                {
                    productsNew[a] = products[i];
                    a++;
                }
            }
            products = productsNew;
            return products;
        }

        static Book[] Search(Book[] products, string searchName)
        {
            int total = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Name==searchName)
                {
                    total++;
                }
            }
            Book[] productsNew = new Book[total];
            int a = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Name==searchName)
                {
                    products[a] = products[i];
                    a++;
                }
            }
            products=productsNew;
            return products;
        }
    }
}
