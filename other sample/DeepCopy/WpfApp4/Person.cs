using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{

    public class Book
    {
        public int id;
        public string name;

        public Book(int id,string name)
        {
            this.id = id;
            this.name = name;
        }

        public Book Clone()
        {
            return (Book)this.MemberwiseClone();
        }

    }

    public class Person
    {
        public int age;
        public string name;
        public Book[] list;

        public Person DeepCopy()
        {
            Person temp = (Person)this.MemberwiseClone();
            temp.list = new Book[this.list.Length];
            for (int i=0; i< this.list.Length; i++)
            {
                temp.list[i] = this.list[i].Clone();
            }
            return temp;
        }

        public Person shadowCopy()
        {
            Person temp = (Person)this.MemberwiseClone();
            return temp;
        }
    }
}
