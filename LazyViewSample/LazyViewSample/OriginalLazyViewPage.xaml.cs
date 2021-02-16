﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LazyViewSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OriginalLazyViewPage : ContentPage
	{
		public OriginalLazyViewPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			lazyView.LoadViewAsync();
		}
	}
}