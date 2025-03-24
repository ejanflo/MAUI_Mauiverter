using Mauiverter.MVVM.Models;
using Mauiverter.MVVM.ViewModels;

namespace Mauiverter.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		var elemnt = (Grid)sender;

		var option = ((Label)elemnt.Children.Last()).Text;

		//DisplayAlert("Title", option, "Okay");

		var converterView = new ConverterView
		{
			BindingContext = new ConverterViewModel(option)
		};

		Navigation.PushAsync(converterView);
    }
}