using Evaluacion3P.ViewModel;
namespace Evaluacion3P.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
        BindingContext = new AboutViewModel();
    }
}