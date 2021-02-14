
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LazyViewSample
{
	public partial class ImagePage : ContentPage
	{
		public ImagePage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			await Task.Delay(2000);
			await lazyView.LoadViewAsync();
		}
	}
}