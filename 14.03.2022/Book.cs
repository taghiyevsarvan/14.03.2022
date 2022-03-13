using System;
using System.Collections.Generic;
using System.Text;

namespace _14._03._2022
{
    internal class Book:Product
    {
        public Book(int no, string name, double price, string genre) :base(no,name,price)
        {
            this.Genre = genre;
        }
        public string Genre;
        
        public string GetInfo()
        {
            return $"No: {this.No} - Adi: {this.Name} - Janri {this.Genre} \nQiymeti: {this.Price} - Sayi: {this.Count}";
        }

        
    }
}
