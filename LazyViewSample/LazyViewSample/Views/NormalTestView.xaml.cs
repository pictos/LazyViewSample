
using Xamarin.Forms;

namespace LazyViewSample.Views
{
	public partial class NormalTestView : ContentView
	{
		public NormalTestView()
		{
			InitializeComponent();
			BindingContext = NormalTestViewModel.Current;
			NormalTestViewModel.Current.LoadedViews += "NormalView loaded \n";
		}
	}


	sealed class NormalTestViewModel : BindableObject
	{
		public static NormalTestViewModel Current { get; } = new NormalTestViewModel();

		string loadedViews;

		public string LoadedViews
		{
			get => loadedViews;
			set
			{
				if (loadedViews == value)
					return;

				loadedViews = value;
				OnPropertyChanged();
			}
				

		}

		NormalTestViewModel()
		{
		}
	}
}