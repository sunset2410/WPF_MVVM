using System.ComponentModel;
using System.Windows;

namespace SwitchTypeToggleButtonSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _isCheck;

        public bool IsCheck
        {
            get { return _isCheck; }
            set
            {
                _isCheck = value;
                OnPropertyChanged("IsCheck");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            IsCheck = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheck = !IsCheck;
        }
    }
}
