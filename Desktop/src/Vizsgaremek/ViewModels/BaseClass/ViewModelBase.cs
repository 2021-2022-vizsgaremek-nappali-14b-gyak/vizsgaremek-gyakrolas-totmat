using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Vizsgaremek.ViewModels.BaseClass
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose() { }

        /*protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
                return false;
            else
            {
                storage = value;
                this.OnPropertyChanged(propertyName);
                return true;
            }
        }*/
    }
}
