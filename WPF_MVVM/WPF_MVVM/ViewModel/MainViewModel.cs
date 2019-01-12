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
            AllItems.Add(new Student("2", "TRAN B", false, dict));
            AllItems.Add(new Student("3", "TRAN C", true, dict));
            AllItems.Add(new Student("4", "TRAN D", false, dict));
            AllItems.Add(new Student("5", "TRAN E", false, dict));
            AllItems.Add(new Student("6", "TRAN F", true, dict));
        }


        //edit
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


        //enable
        private RelayCommand _clickEnable = null;
        public RelayCommand ClickEnable
        {
            get
            {
                if (_clickEnable == null)
                {
                    _clickEnable = new RelayCommand(() =>
                    {
                        int count = SelectedStudents.Count;
                        foreach(var student in SelectedStudents)
                        {
                            Student temp = student as Student;
                            foreach( var val in AllItems)
                            {
                                if (val.Id.Equals(temp.Id)) val.ShowView = true;
                            }
                        }

                    });
                }
                return _clickEnable;
            }
        }

        //disable
        private RelayCommand _clickDisable = null;
        public RelayCommand ClickDisable
        {
            get
            {
                if (_clickDisable == null)
                {
                    _clickDisable = new RelayCommand(() =>
                    {
                        int count = SelectedStudents.Count;
                        foreach (var student in SelectedStudents)
                        {
                            Student temp = student as Student;
                            foreach (var val in AllItems)
                            {
                                if (val.Id.Equals(temp.Id)) val.ShowView = false;
                            }
                        }


                    });
                }
                return _clickDisable;
            }
        }


        //show
        private RelayCommand _clickShow = null;
        public RelayCommand ClickShow
        {
            get
            {
                if (_clickShow == null)
                {
                    _clickShow = new RelayCommand(() =>
                    {
                        int count = SelectedStudents.Count;


                    });
                }
                return _clickShow;
            }
        }

    }
}