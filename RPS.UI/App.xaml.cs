﻿using RPS.UI.ViewModels.Backlog;
using RPS.UI.Views;
using RPS.UI.Views.Backlog;
using RPS.UI.Views.Dashboard;

namespace RPS.UI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Application.Current.UserAppTheme = AppTheme.Light;
    }

	protected override Window CreateWindow(IActivationState activationState)
	{
		return new Window(new RPSFlyoutPage());

        // dev-time code use this to bypass having to navigate to individual pages via UI
        // make sure to inject the needed page into App() - either DashboardPage or BacklogPage

        // var vm = Handler.MauiContext.Services.GetService(typeof(BacklogViewModel));
        // var newPage = (Page)Activator.CreateInstance(typeof(BacklogPage), vm);

		// return new Window(new NavigationPage(newPage));
	}
}