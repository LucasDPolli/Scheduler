using Mopups.Pages;
using Scheduler.ViewModel.Mopups;

namespace Scheduler.View.Mopups;

public partial class NewSchedulePage : PopupPage
{
    private readonly NewScheduleViewModel vm;


	public NewSchedulePage()
	{
        vm = new NewScheduleViewModel();
        InitializeComponent();
        BindingContext = vm;
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();
        var displayInfo = DeviceDisplay.MainDisplayInfo;

        this.bd_Mopup.WidthRequest = displayInfo.Width / 3.2;
    }
}