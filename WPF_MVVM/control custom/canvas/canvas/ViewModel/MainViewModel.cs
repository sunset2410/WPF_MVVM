using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace canvas.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<RectItem> RectItems { get; set; }
        public MainViewModel()
        {
            RectItems = new ObservableCollection<RectItem>();
            RectItems.Add(new RectItem(100, 200, 80, 40));
            RectItems.Add(new RectItem(10, 250, 90, 40));
            RectItems.Add(new RectItem(150, 100, 80, 40));
            RectItems.Add(new RectItem(300, 500, 80, 40));
            RectItems.Add(new RectItem(350, 700, 80, 40));
        }
    }
}