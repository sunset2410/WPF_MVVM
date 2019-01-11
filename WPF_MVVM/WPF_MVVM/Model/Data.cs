using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM.Model
{
    public class Student : INotifyPropertyChanged
    {
        private string _id = string.Empty;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }


        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public bool Show { get; set; }

        public Dictionary<string,string> Detail { get; set; }

        public Student(string Id, string Name, bool Show, Dictionary<string, string> Detail)
        {
            this.Id = Id;
            this.Name = Name;
            this.Show = Show;
            this.Detail = Detail;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
