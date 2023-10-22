using Scheduler.Data;
using Scheduler.Model;
using System.Collections.ObjectModel;

namespace Scheduler.ViewModel;

public class ListSchedulesViewModel
{
    #region Fields
    public ObservableCollection<Schedule> ScheduledListView { get; set; } = new ObservableCollection<Schedule>();
    #endregion


    public ListSchedulesViewModel()
    {
        RefleshSchedulesView();
    }


    public void RefleshSchedulesView()
    {
        try
        {
            Task.Run(async () =>
            {
                var items = await App.ScheduleDB.GetItemsAsync();
                ScheduledListView.Clear();

                foreach (var item in items)
                {
                    var schedule = App.MyMapper.Map<Schedule_Table, Schedule>(item);
                    ScheduledListView.Add(schedule);
                }

            }).Wait();
        }
        catch (Exception ex)
        {
            App.Current.MainPage.DisplayAlert("Erro", $"Não foi possivel obter os agendamento\n{ex.Message}", "Ok");
        }
    }
}