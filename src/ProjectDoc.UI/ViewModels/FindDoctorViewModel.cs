using ProjectDoc.UI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProjectDoc.UI.ViewModels;

class FindDoctorViewModel : IQueryAttributable, INotifyPropertyChanged
{
    public ObservableCollection<DoctorBasicProfile> Doctors { get; } = new ObservableCollection<DoctorBasicProfile>();

    public string Type { get; set; }

    public FindDoctorViewModel()
    {
        DoctorApi d = new();
        foreach (var doc in d.Doctors)
        {
            Doctors.Add(doc);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Type = query["type"] as string ?? "Default";
        OnPropertyChanged(nameof(Type));
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

class DoctorApi
{
    public List<DoctorBasicProfile> Doctors { get; } = new List<DoctorBasicProfile>()
    {
        new DoctorBasicProfile { Name = "John"},
        new DoctorBasicProfile { Name = "Jack"},
        new DoctorBasicProfile { Name = "Bill"},
    };
}
