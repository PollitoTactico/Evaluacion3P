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
        public string StatusMessage { get; set; }
        private readonly SQLiteAsyncConnection _database;

        public DatabasePais(string dbPath)
        {

            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<Paises>().Wait();

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to initialize database. Error: {0}", ex.Message);

            }
           
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
