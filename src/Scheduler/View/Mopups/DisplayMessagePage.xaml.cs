using Mopups.Pages;
using Scheduler.Model.Enum;
using Scheduler.ViewModel.Mopups;

namespace Scheduler.View.Mopups;

public partial class DisplayMessagePage : PopupPage
{
    private readonly DisplayMessageViewModel vm;

	public DisplayMessagePage(ItemOperation operation, bool isSuccess, string customMessage = "")
	{
        vm = new DisplayMessageViewModel(operation, isSuccess, customMessage);
		InitializeComponent();
        BindingContext = vm;
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();

        lbl_MessageSuccess.Text = vm.GetMessage();

        var palette = vm.GetColorPalette();
        bd_Mopup.BackgroundColor = palette.ColorPrimary;
        bd_Mopup.Stroke = palette.ColorAccent;
        lbl_MessageSuccess.TextColor = palette.TextColorPrimary;
    }
}