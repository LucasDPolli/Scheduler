using SQLite;

namespace Scheduler.Data.Config;

public class RoutineDB
{
    private SQLiteAsyncConnection _db;

    public RoutineDB(SQLiteAsyncConnection db)
    {
        if (_db is not null)
            return;

        _db = db;

        Task.Run(async () =>
        {
            var result = await _db.CreateTableAsync<Routine_Table>();
        }).Wait();
    }


    public async Task<List<Routine_Table>> GetItemsAsync()
    {
        return await _db.Table<Routine_Table>().ToListAsync();
    }

    public async Task<Routine_Table> GetItemAsync(int id)
    {
        return await _db.Table<Routine_Table>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(Routine_Table item)
    {
        if (item.Id != 0)
            return await _db.UpdateAsync(item);
        else
            return await _db.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(Routine_Table item)
    {
        return await _db.DeleteAsync(item);
    }
}