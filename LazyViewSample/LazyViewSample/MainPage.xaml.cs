using Xamarin.Forms;

namespace LazyViewSample
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainViewModel();
		}
	}



	class MainViewModel
	{
		public Command<string> NavigateCommand { get; }

		public string Text => "RootPage";

		public MainViewModel()
		{
			NavigateCommand = new Command<string>(NavigateCommandExecute);
		}

		void NavigateCommandExecute(string arg)
		{
			var id = int.Parse(arg);
			Page page = id switch
			{
				1 => new RootTabView(),
				2 => new ActivationPage(),
				3 => new ImagePage(),
				4 => new OriginalLazyViewPage(),
				_ => null
			};

			App.Current.MainPage.Navigation.PushAsync(page);
		}
	}
}
