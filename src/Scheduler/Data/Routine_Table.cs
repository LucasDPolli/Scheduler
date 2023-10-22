using SQLite;

namespace Scheduler.Data;

[Table("Routine")]
public class Routine_Table
{
    public Routine_Table()
    {
    }

    public Routine_Table(int id, string name)
    {
        Id = id;
        Name = name;
    }

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Unique]
    public string Name { get; set; }
}