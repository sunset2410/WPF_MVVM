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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Person p1 = new Person();
            p1.name = "Hassan";
            p1.age = 22;
            p1.list = new Book[4];
            p1.list[0] = new Book(1, "a1");
            p1.list[1] = new Book(2, "a2");
            p1.list[2] = new Book(3, "a3");
            p1.list[3] = new Book(4, "a4");

            // Calling DeepCopy() method					 
            Person p2 = p1.DeepCopy();

            System.Console.WriteLine("Before Changing: ");

            // Value of attributes of c1 and c2 before changing
            // the values 
            System.Console.WriteLine("p1 instance values: ");

            System.Console.WriteLine("     Name: {0:s},   Age: {1:d}", p1.name, p1.age);
            System.Console.WriteLine("     Value: {0:d}", p1.list[0].name);

            System.Console.WriteLine("p2 instance values:");

            System.Console.WriteLine("     Name: {0:s},   Age: {1:d}", p2.name, p2.age);
            System.Console.WriteLine("     Value: {0:d}", p2.list[0].name);


            // Modifying attributes of p1
            p1.name = "Hamza";
            p1.age = 20;
            p1.list[0].name = "tes0t";
            p1.list[1].name = "tes1t";
            p1.list[2].name = "test2";
            p1.list[3].name = "test3";

            System.Console.WriteLine("\nAfter Changing attributes of p1: ");

            // Value of attributes of c1 and c2 after changing
            // the values 
            System.Console.WriteLine("p1 instance values: ");

            System.Console.WriteLine("     Name: {0:s},   Age: {1:d}", p1.name, p1.age);
            System.Console.WriteLine("     Value: {0:d}", p1.list[0].name);

            System.Console.WriteLine("p2 instance values:");

            System.Console.WriteLine("     Name: {0:s},   Age: {1:d}", p2.name, p2.age);
            System.Console.WriteLine("     Value: {0:d}", p2.list[0].name);




        }
    }
}
