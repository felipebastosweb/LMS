using System.Linq.Expressions;
using CasaDaAprendizagemApp.Data.Models;

using SQLite;

namespace CasaDaAprendizagemApp.Data.Repositories
{
    public class SQLiteRepository<T>
    {
        public const string DatabaseFilename = "Database.db3";
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLiteOpenFlags.SharedCache;

        protected static SQLiteAsyncConnection Connection;

        public static async Task InitAsync()
        {
            if (Connection != null)
            {
                return;
            }

            Connection = new SQLiteAsyncConnection(DatabasePath, Flags);
            await Connection.CreateTableAsync<User>();
            await Connection.CreateTableAsync<Course>();
            await Connection.CreateTableAsync<Studant>();
            await Connection.CreateTableAsync<Enrollment>();
            await Connection.CreateTableAsync<Person>();
            await Connection.CreateTableAsync<Teacher>();
            //
        }

        public async Task<T> InsertAsync(T item)
        {
            await InitAsync();
            await Connection.InsertAsync(item);
            return item;
        }

        public async Task<T2> FindAsync<T2>(int id)
            where T2 : class, IBaseModel, new()
        {
            await InitAsync();
            return await Connection.Table<T2>().FirstAsync(t => t.Id == id);
        }

        public List<T2> ListAsync<T2>(
            List<Expression<Func<T2, bool>>> filters = null,
            Expression<Func<T2, T2>> orderFunc = null
            ) where T2 : class, IBaseModel, new()
        {
            // corre o InitAsync de forma assíncrona
            Task.Run(async () =>
            {
                await InitAsync();
            }).Wait();

            var query = Connection.Table<T2>();
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            if (orderFunc != null)
            {
                query = query.OrderBy(orderFunc);
            }

            // variável auxiliar para o resultado pois o tipo é diferente do tipo de query
            List<T2> result = new List<T2>();

            // corre o ToListAsync de forma assíncrona
            Task.Run(async () =>
            {
                var listItems = await query.ToListAsync();
                result = listItems;
            }).Wait();

            return result;
        }

        public async Task<T> UpdateAsync(T item)
        {
            await InitAsync();
            await Connection.UpdateAsync(item);
            return item;
        }
        public async Task<bool> DeleteAsync(T item)
        {
            await InitAsync();
            return await Connection.DeleteAsync(item) > 0;
        }
    }

}