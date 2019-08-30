using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sfBugs.ProgressBar
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage( new MainPage());		//DD 30/08/2019 15:46:53	deve esse in un navPage
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
