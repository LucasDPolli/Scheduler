namespace Scheduler.Model;

public class Schedule
{
    public Schedule(int routineId, string title, string description, DateTime dateTime_Start, DateTime dateTime_End, bool isEnable, DateTime dta_Create, DateTime dta_Alter)
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


    public int Id { get; set; }
    public int RoutineId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateTime_Start { get; set; }
    public DateTime DateTime_End { get; set; }
    public bool IsEnable { get; set; }
    public DateTime Dta_Create { get; set; }
    public DateTime Dta_Alter { get; set; }

    public string DateTime_Start_Text => DateTime_Start.ToString("dd/MM/yyyy HH:mm");
    public string DateTime_End_Text => DateTime_End.ToString("dd/MM/yyyy HH:mm"); 
}