using SQLite;

namespace Scheduler.Data.Config
{
    public class ScheduleDB 
    {
        private SQLiteAsyncConnection _db;

        public ScheduleDB(SQLiteAsyncConnection db)
        {
            if (_db is not null)
                return;

            _db = db;

            Task.Run(async () => 
            { 
                var result = await _db.CreateTableAsync<Schedule_Table>();
            }).Wait();
        }

        public async Task<List<Schedule_Table>> GetItemsAsync()
        {
            return await _db.Table<Schedule_Table>().ToListAsync();
        }

        public async Task<List<Schedule_Table>> GetItemsEnableAsync()
        {
            return await _db.Table<Schedule_Table>().Where(t => t.IsEnable).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<ScheduleData>("SELECT * FROM [ScheduleData] WHERE [Done] = 0");
        }

        public async Task<Schedule_Table> GetItemAsync(int id)
        {
            return await _db.Table<Schedule_Table>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Schedule_Table item)
        {
            if (item.Id != 0)
            {
                item.Dta_Alter = DateTime.Now;
                return await _db.UpdateAsync(item);
            }
            else
                return await _db.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(Schedule_Table item)
        {
            return await _db.DeleteAsync(item);
        }
    }
}
