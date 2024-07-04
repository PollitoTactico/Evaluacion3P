using Evaluacion3P.Services;
using Evaluacion3P.ViewModel;

namespace Evaluacion3P.Views;

public partial class PaisPage : ContentPage
{
	public PaisPage()
	{
		InitializeComponent();
        BindingContext = new PaisViewModel(new PaisSer(), new DatabasePais(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Paises.db3")));
    }
}