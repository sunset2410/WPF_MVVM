using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
   public class RectItem: INotifyPropertyChanged
    {
        public RectItem(double x, double y, double with, double height)
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = with;
        }

        private double _x;
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
         
        }

        private double _y;
        public double Y
        {
            get { return _y; }
            set
            {
                _y= value;
                OnPropertyChanged("Y");
            }

        }

        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged("Width");
            }

        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }

        }
     
        public event PropertyChangedEventHandler PropertyChanged;
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
