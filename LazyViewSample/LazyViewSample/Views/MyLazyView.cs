using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace LazyViewSample.Views
{
	public class MyLazyView : LazyView<LazyViewSample.Views.LazyImageView>
	{
		public override async ValueTask LoadViewAsync()
		{
			await base.LoadViewAsync();
			await Application.Current.MainPage.DisplayAlert("I'm alive!", "You just loaded a new view!", "ok");
		}
	}
}
