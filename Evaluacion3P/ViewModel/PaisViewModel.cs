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

        private readonly PaisSer _paisService;
        private readonly DatabasePais _database;

        public ObservableCollection<Paises> Paises { get; }

        public ICommand LoadPaisesCommand { get; }
        public ICommand UpdatePaisCommand { get; }
        public ICommand DeletePaisCommand { get; }

        public PaisViewModel(PaisSer paisService, DatabasePais database)
        {
            _paisService = paisService;
            _database = database;
            Paises = new ObservableCollection<Paises>();

            LoadPaisesCommand = new Command(async () => await ExecuteLoadPaisesCommand());
            UpdatePaisCommand = new Command<Paises>(async (pais) => await ExecuteUpdatePaisCommand(pais));
            DeletePaisCommand = new Command<Paises>(async (pais) => await ExecuteDeletePaisCommand(pais));
        }

        private async Task ExecuteLoadPaisesCommand()
        {
            Paises.Clear();
            var paises = await _paisService.Obtener();
            foreach (var pais in paises)
            {
                var codigo = $"{pais.Name.Substring(0, 1)}{new Random().Next(1000, 2000)}";
                pais.JoseSanchez = codigo;
                await _database.SavePaisAsync(pais);
                Paises.Add(pais);
            }
        }

        private async Task ExecuteUpdatePaisCommand(Paises pais)
        {
            await _database.UpdatePaisAsync(pais);
        }

        private async Task ExecuteDeletePaisCommand(Paises pais)
        {
            await _database.DeletePaisAsync(pais);
            Paises.Remove(pais);
        }
    }
}
