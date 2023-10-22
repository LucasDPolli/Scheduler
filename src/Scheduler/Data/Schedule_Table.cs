using SQLite;

namespace Scheduler.Data;

[SQLite.Table("Schedule")]
public class Schedule_Table
{
    public Schedule_Table()
    {
    }

    public Schedule_Table(int routineId, string title, string description, DateTime dateTime_Start, DateTime dateTime_End, bool isEnable, DateTime dta_Create, DateTime dta_Alter)
    {
        RoutineId = routineId;
        Title = title;
        Description = description;
        DateTime_Start = dateTime_Start;
        DateTime_End = dateTime_End;
        IsEnable = isEnable;
        Dta_Create = dta_Create;
        Dta_Alter = dta_Alter;
    }

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int RoutineId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateTime_Start { get; set; }
    public DateTime DateTime_End { get; set; }
    public bool IsEnable { get; set; }
    public DateTime Dta_Create { get; set; }
    public DateTime Dta_Alter { get; set; }
}