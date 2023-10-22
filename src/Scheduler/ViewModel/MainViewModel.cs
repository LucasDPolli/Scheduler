using System.Windows.Input;
using Scheduler.View;
using Scheduler.View.Mopups;

namespace Scheduler.ViewModel;

public class MainViewModel
{
    #region Fields
    public ICommand AddScheduleCommand { get; set; }
    public ICommand ViewSchedulesCommand { get; set; }
    #endregion


    public MainViewModel()
    {
        AddScheduleCommand = new Command(async () =>
        {
            try
            {
                await App.PopupNavigation.PushAsync(new NewSchedulePage(), true);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error PopupNavigation", ex.Message, "ok");
            }
        });

        ViewSchedulesCommand = new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PushAsync(new ListSchedulesPage(), true);
        });
    }
}
