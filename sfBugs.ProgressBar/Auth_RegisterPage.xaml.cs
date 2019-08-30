using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sfBugs.ProgressBar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Auth_RegisterPage : ContentPage
	{
		public Auth_RegisterPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);

			btnCancel.Clicked += async (s, e) =>
			{
				await Navigation.PopAsync(false);
			};
			this.BindingContext = this;
		}
		public bool _UseAsync = false;

		public bool UseAsync { get => _UseAsync; set { if (value != _UseAsync) { _UseAsync = value; OnPropertyChanged(); } } }

		public int StepActive = 1;
		public int StepMax = 3;
		private void BtnStepBack_Clicked(object sender, EventArgs e)
		{
			if(StepActive>1) StepActive--;
			if (UseAsync)
				ShowStepActiveAsync();
			else
				ShowStepActive();
		}

		private void BtnStepForward_Clicked(object sender, EventArgs e)
		{
			if (StepActive < StepMax) StepActive++;
			if (UseAsync)
				ShowStepActiveAsync();
			else
				ShowStepActive();
		}

		private void ShowStepActiveAsync()
		{
			Device.BeginInvokeOnMainThread(new Action(ShowStepActive));
		}

		private void ShowStepActive()
		{
			for (int i = 1; i <= StepMax; i++)
			{
				var stackLayoutArea = this.FindByName($"step{i}") as StackLayout;
				var stepView = stepProgressBar.Children[i - 1] as Syncfusion.XForms.ProgressBar.StepView;

				if (i == StepActive)
				{
					stackLayoutArea.IsVisible = true;
					stepView.Status = Syncfusion.XForms.ProgressBar.StepStatus.InProgress;
				}
				else
				{
					stackLayoutArea.IsVisible = false;
					if (i > StepActive)
						stepView.Status = Syncfusion.XForms.ProgressBar.StepStatus.NotStarted;
					else
						stepView.Status = Syncfusion.XForms.ProgressBar.StepStatus.Completed;
				}
				stepView.SecondaryText = stepView.Status.ToString();
			}
		}
	}
}