using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluacion3P.Models;
using SQLite;
    
namespace Evaluacion3P;

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

    public async Task<List<Paises>> GetPaisesAsync()
    {
        try
        {
            return await _database.Table<Paises>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. Error: {0}", ex.Message);
            return new List<Paises>();
        }
    }

    public async Task<int> SavePaisAsync(Paises pais)
    {
        try
        {
            if (pais.Id != 0)
            {
                return await _database.UpdateAsync(pais);
            }
            else
            {
                return await _database.InsertAsync(pais);
            }
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to save data. Error: {0}", ex.Message);
            return 0;
        }
    }

    public async Task<int> UpdatePaisAsync(Paises pais)
    {
        try
        {
            return await _database.UpdateAsync(pais);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to update data. Error: {0}", ex.Message);
            return 0;
        }
    }

    public async Task<int> DeletePaisAsync(Paises pais)
    {
        try
        {
            return await _database.DeleteAsync(pais);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to delete data. Error: {0}", ex.Message);
            return 0;
        }
    }
}
