using System.ComponentModel;
using PropertyChanged;

namespace WpfBasic
{
    [AddINotifyPropertyChangedInterface]
    class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };
        public string Test { get; set; }



    }
}
