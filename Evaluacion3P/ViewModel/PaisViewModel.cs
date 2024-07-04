using Evaluacion3P.Models;
using Evaluacion3P.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Evaluacion3P.ViewModel
{
    public class PaisViewModel : BaseViewModel
    {

        private readonly PaisService _paisService;
        private readonly DatabasePais _database;

        public ObservableCollection<Paises> Paises { get; }
        public ICommand LoadPaisesCommand { get; }
        public ICommand AddPaisCommand { get; }
        public ICommand UpdatePaisCommand { get; }
        public ICommand DeletePaisCommand { get; }

        public PaisViewModel(PaisService paisService, DatabasePais database)
        {
            _paisService = paisService;
            _database = database;

            Paises = new ObservableCollection<Paises>();
            LoadPaisesCommand = new Command(async () => await LoadPaises());
            AddPaisCommand = new Command<Paises>(async (pais) => await AddPais(pais));
            UpdatePaisCommand = new Command<Paises>(async (pais) => await UpdatePais(pais));
            DeletePaisCommand = new Command<Paises>(async (pais) => await DeletePais(pais));
        }

        private async Task LoadPaises()
        {
            Paises.Clear();
            var paises = await _database.GetPaisesAsync();
            foreach (var pais in paises)
            {
                Paises.Add(pais);
            }
        }

        private async Task AddPais(Paises pais)
        {
            await _database.SavePaisAsync(pais);
            Paises.Add(pais);
        }

        private async Task UpdatePais(Paises pais)
        {
            await _database.UpdatePaisAsync(pais);
            await LoadPaises();
        }

        private async Task DeletePais(Paises pais)
        {
            await _database.DeletePaisAsync(pais);
            Paises.Remove(pais);
        }
    }
}
