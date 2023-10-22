using AutoMapper;
using Mopups.Interfaces;
using Mopups.Services;
using Scheduler.Data;
using Scheduler.Data.Config;
using Scheduler.Model.Enum;
using Scheduler.Model.Mapper;
using SQLite;

namespace Scheduler;

public partial class App : Application
{
    #region Fields
    private readonly SQLiteAsyncConnection _dbConnection; 

    public static IPopupNavigation PopupNavigation { get; private set; }
    public static ScheduleDB ScheduleDB { get; private set; }
    public static RoutineDB RoutineDB { get; private set; }
    public static Mapper MyMapper { get; private set; }
    #endregion


    public App()
	{
		InitializeComponent();

        _dbConnection = new SQLiteAsyncConnection(MyDataBase.DatabasePath, MyDataBase.Flags);

        PopupNavigation = new PopupNavigation();
        RoutineDB = new RoutineDB(_dbConnection);
        ScheduleDB = new ScheduleDB(_dbConnection);

        MainPage = new AppShell();

        Task.Run(async () =>
        {
            var routineList = Enum.GetValues(typeof(Routine)).Cast<Routine>();

            foreach (Routine routine in routineList)
                await RoutineDB.SaveItemAsync(new Routine_Table((int)routine, $"{routine}"));

        }).Wait();
        
        MyMapper = MapperConfig.InitializeMapper();
    }
}