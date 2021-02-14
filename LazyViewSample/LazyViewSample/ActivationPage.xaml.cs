using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LazyViewSample
{
	public partial class ActivationPage : ContentPage
	{
		public ActivationPage()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			lazyView.LoadViewAsync();
		}
	}
}