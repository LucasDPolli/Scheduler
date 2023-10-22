using Scheduler.Resources.Idiom;
using Scheduler.ViewModel;

namespace Scheduler.View;

public partial class ListSchedulesPage : ContentPage
{
    ListSchedulesViewModel vm;


	public ListSchedulesPage()
	{
        vm = new ListSchedulesViewModel();
		InitializeComponent();
        BindingContext = vm;
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();

        btn_search.Text = $"{Lang.schedule} {Lang.schedule}";
    }

    private void ListView_Refreshing(object sender, EventArgs e)
    {
        vm.RefleshSchedulesView();
        listView_Schedules.IsRefreshing = false;
    }
}