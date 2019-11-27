using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Advent2019
{
    public class MainView : INotifyPropertyChanged
    {
        private string _OutText;
        public string OutText
        {
            get
            {
                return _OutText;
            }
            set
            {
                if (value == _OutText)
                    return;
                _OutText = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}