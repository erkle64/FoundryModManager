using System.ComponentModel;
using System.Runtime.CompilerServices;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string? caller = null)
    {
        var handler = PropertyChanged;
        if (handler != null && caller != null)
        {
            handler(this, new PropertyChangedEventArgs(caller));
        }
    }
}
