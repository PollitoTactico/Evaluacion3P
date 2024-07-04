using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluacion3P.Models;
using SQLite;

namespace Evaluacion3P
{
    public class DatabasePais
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabasePais(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Paises>().Wait();
        }

        public Task<List<Paises>> GetPaisesAsync()
        {
            return _database.Table<Paises>().ToListAsync();
        }


        public Task<int> SavePaisAsync(Paises pais)
        {
            if (pais.Id != 0)
            {
                return _database.UpdateAsync(pais);
            }
            else
            {
                return _database.InsertAsync(pais);
            }
        }

        public Task<int> UpdatePaisAsync(Paises pais)
        {
            return _database.UpdateAsync(pais);
        }

        public Task<int> DeletePaisAsync(Paises pais)
        {
            return _database.DeleteAsync(pais);
        }
    }
}
