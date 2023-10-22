using Scheduler.Resources.Idiom;
using Scheduler.ViewModel;

namespace Scheduler.View;

public partial class MainPage : ContentPage
{
    MainViewModel vm;


    public MainPage()
	{
        vm = new MainViewModel();
        InitializeComponent();
        BindingContext = vm;
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();

        Title = Lang.mainPage;
        lbl_title.Text = Lang.welcome;
        btn_addSchedule.Text = $"{Lang.add} {Lang.schedule}";
        btn_viewSchedules.Text = $"{Lang.visualize} {Lang.schedule}";
    }
}