using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF_MVVM.Model;

namespace WPF_MVVM.ViewModel
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
        public ObservableCollection<Student> AllItems { get; set; }

        private IList _selectedStudents;
        public IList SelectedStudents
        {
            get { return _selectedStudents; }
            set
            {
                _selectedStudents = value;
                RaisePropertyChanged("SelectedStudents");
            }
        }
        public MainViewModel()
        {
            AllItems = new ObservableCollection<Student>();
            CreateData();
        }

        public void CreateData()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Class", "9A");
            dict.Add("Group", "8");
            dict.Add("School", "HOANG MAI");
            AllItems.Add(new Student("1", "TRAN ANH", true, dict));
            AllItems.Add(new Student("2", "TRAN B", true, dict));
            AllItems.Add(new Student("3", "TRAN C", true, dict));
            AllItems.Add(new Student("4", "TRAN D", true, dict));
            AllItems.Add(new Student("5", "TRAN E", true, dict));
            AllItems.Add(new Student("6", "TRAN F", true, dict));
        }



        private RelayCommand _clickEdit = null;
        public RelayCommand ClickEdit
        {
            get
            {
                if (_clickEdit == null)
                {
                    _clickEdit = new RelayCommand(() =>
                    {
                        int count = SelectedStudents.Count;


                    });
                }
                return _clickEdit;
            }
        }

    }
}