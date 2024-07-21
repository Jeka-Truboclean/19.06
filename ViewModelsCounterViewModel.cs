// ViewModels/CounterViewModel.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SimpleCounterApp.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private int _counter;
        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                OnPropertyChanged();
            }
        }

        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }

        public CounterViewModel()
        {
            IncrementCommand = new RelayCommand(Increment);
            DecrementCommand = new RelayCommand(Decrement);
        }

        private void Increment(object parameter)
        {
            Counter++;
        }

        private void Decrement(object parameter)
        {
            Counter--;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
