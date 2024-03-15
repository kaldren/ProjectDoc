using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace ProjectDoc.UI.ViewModels;

class GpViewModel
{
    public ICommand OpenGpMenuCommand { get; set; }

    public GpViewModel()
    {
        OpenGpMenuCommand = new AsyncRelayCommand(OpenGpMenu);
    }

    async Task OpenGpMenu() => await Shell.Current.GoToAsync("//main/docs?type=gp");
}
