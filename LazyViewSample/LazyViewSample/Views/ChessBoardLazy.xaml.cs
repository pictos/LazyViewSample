
using Xamarin.Forms;

namespace LazyViewSample.Views
{
	public partial class ChessBoardLazy : ContentView
	{
		public ChessBoardLazy()
		{
			InitializeComponent();
			Build();
			NormalTestViewModel.Current.LoadedViews += "LazyView loaded \n";
		}

		void Build()
		{
			for (var i = 0; i < 117; i++)
			{
				var box = new BoxView
				{
					BackgroundColor = i % 2 == 0 ? Color.White : Color.Black
				};

				uniformGrid.Children.Add(box);
			}
		}
	}
}