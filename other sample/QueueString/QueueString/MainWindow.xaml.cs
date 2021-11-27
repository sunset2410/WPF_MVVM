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

namespace QueueString
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queue queue = new Queue();
        public MainWindow()
        {
            InitializeComponent();

            queue.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            queue.insertPIN("a1");
            queue.insertPIN("a2");
            queue.insertPIN("a3");
            queue.insertPIN("a4");
            queue.insertPIN("a5");
            queue.insertPIN("a6");
            queue.insertPIN("a7");

            bool check = queue.ContainsPIN("a6");
            check = queue.ContainsPIN("a20");
            check = queue.ContainsPBA("a2");


        }
    }
}
