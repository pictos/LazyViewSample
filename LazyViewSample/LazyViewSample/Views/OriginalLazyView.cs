using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace LazyViewSample.Views
{
	public abstract class OriginalLazyView : BaseLazyView
	{
		public static readonly BindableProperty AccentColorProperty = BindableProperty.Create(
			nameof(AccentColor),
			typeof(Color),
			typeof(OriginalLazyView),
			Color.Accent,
			propertyChanged: AccentColorChanged);

		public static readonly BindableProperty UseActivityIndicatorProperty = BindableProperty.Create(
			nameof(UseActivityIndicator),
			typeof(bool),
			typeof(OriginalLazyView),
			false,
			propertyChanged: UseActivityIndicatorChanged);

		public static readonly BindableProperty AnimateProperty = BindableProperty.Create(
			nameof(Animate),
			typeof(bool),
			typeof(OriginalLazyView),
			false);

		public Color AccentColor
		{
			get => (Color)GetValue(AccentColorProperty);
			set => SetValue(AccentColorProperty, value);
		}

		public bool UseActivityIndicator
		{
			get => (bool)GetValue(UseActivityIndicatorProperty);
			set => SetValue(UseActivityIndicatorProperty, value);
		}

		public bool Animate
		{
			get => (bool)GetValue(AnimateProperty);
			set => SetValue(AnimateProperty, value);
		}


		protected override void OnBindingContextChanged()
		{
			if (Content != null && !(Content is ActivityIndicator))
			{
				Content.BindingContext = BindingContext;
			}
		}

		private static void AccentColorChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
			var lazyView = (OriginalLazyView)bindable;
			if (lazyView.Content is ActivityIndicator activityIndicator)
			{
				activityIndicator.Color = (Color)newvalue;
			}
		}

		private static void UseActivityIndicatorChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
			var lazyView = (OriginalLazyView)bindable;
			bool useActivityIndicator = (bool)newvalue;

			if (useActivityIndicator)
			{
				lazyView.Content = new ActivityIndicator
				{
					Color = lazyView.AccentColor,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					IsRunning = true,
				};
			}
		}
	}

	public class OriginalLazyViewImpl<TView> : OriginalLazyView
		where TView : View, new()
	{
		public override async ValueTask LoadViewAsync()
		{

			await Task.Delay(3000);

			SetIsLoaded(true);

			View view = new TView { BindingContext = BindingContext };

			Content = view;

		}
	}
}
