using Scheduler.Data;
using Scheduler.Model;
using Scheduler.Model.Enum;
using Scheduler.View.Mopups;
using System.Windows.Input;

namespace Scheduler.ViewModel.Mopups;

public class NewScheduleViewModel
{
    #region Fields
    public string TitleView { get; set; }
    public string DescriptionView { get; set; }

    public List<Routine> RoutinesView { get => Enum.GetValues(typeof(Routine)).Cast<Routine>().ToList(); }
    public Routine RoutineSelected { get; set; }

    public TimeSpan Time_Start { get; set; } = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    public DateTime Date_Start { get; set; } = DateTime.Now;

    public TimeSpan Time_End { get; set; } = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    public DateTime Date_End { get; set; } = DateTime.Now;

    public ICommand Cancel_NewSchedule_Command { get; set; }
    public ICommand Add_NewSchedule_Command { get; set; }
    #endregion


    public NewScheduleViewModel()
    {
        RoutineSelected = Routine.None;

        Cancel_NewSchedule_Command = new Command(async () =>
        {
            await App.PopupNavigation.PopAsync(true);
        });

        Add_NewSchedule_Command = new Command(async () =>
        {
            var schedule = new Schedule(routineId: (int)RoutineSelected,
                                        title: TitleView,
                                        description: DescriptionView,
                                        dateTime_Start: Date_Start + Time_Start,
                                        dateTime_End: Date_End + Time_End,
                                        isEnable: true,
                                        dta_Create: DateTime.Now,
                                        dta_Alter: DateTime.Now);

            try
            {
                //Schedule
                var schedule_itemTable = App.MyMapper.Map<Schedule, Schedule_Table>(schedule);
                await App.ScheduleDB.SaveItemAsync(schedule_itemTable);

                //continar vendo isso aqui
                await App.PopupNavigation.PushAsync(new DisplayMessagePage(ItemOperation.Salved, true), true);
                await App.PopupNavigation.PopAsync(true);
               
                await App.PopupNavigation.PopAsync(true);
            }
            catch (Exception ex)
            {
                await App.PopupNavigation.PushAsync(new DisplayMessagePage(ItemOperation.Salved, false, ex.Message), true);
                await App.PopupNavigation.PopAsync(true);
            }
        });
    }
}
