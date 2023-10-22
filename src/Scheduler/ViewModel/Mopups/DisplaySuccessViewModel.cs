using Scheduler.Model;
using Scheduler.Model.Enum;
using Scheduler.Resources.Idiom;

namespace Scheduler.ViewModel.Mopups;

public class DisplayMessageViewModel
{
    private readonly ItemOperation _operation;
    private readonly bool _isSuccess;
    private readonly string _customMessage;


    public DisplayMessageViewModel(ItemOperation operation, bool isSuccess, string customMessage = "")
    {
        _operation = operation;
        _isSuccess = isSuccess;
        _customMessage = customMessage;
    }

    public string GetMessage()
    {
        var message = string.Empty;
        var resulOperation = _isSuccess ? Lang.Successfully : Lang.Unsuccessfully;

        switch (_operation)
        {
            case ItemOperation.Salved:
                message = $"{Lang.Saved} {resulOperation}";
                break;
            case ItemOperation.Edited:
                message = $"{Lang.Edited} {resulOperation}";
                break;
            case ItemOperation.Deleted:
                message = $"{Lang.Deleted} {resulOperation}";
                break;
            default:
                message = "";
                break;
        }

        if (!string.IsNullOrEmpty(_customMessage))
            message += $" => {_customMessage}";

        return message.Trim();
    }

    public ColorPalette GetColorPalette()
    {
        var colorPalette = new ColorPalette();

        if (_isSuccess)
        {
            switch (_operation)
            {
                case ItemOperation.Salved:
                    colorPalette.ColorPrimary = Colors.DarkGreen;
                    colorPalette.ColorAccent = Colors.LightGreen;
                    colorPalette.TextColorPrimary = Colors.WhiteSmoke;
                    break;
                case ItemOperation.Edited:
                case ItemOperation.Deleted:
                    colorPalette.ColorPrimary = Colors.DarkBlue;
                    colorPalette.ColorAccent = Colors.LightBlue;
                    colorPalette.TextColorPrimary = Colors.WhiteSmoke;
                    break;
                default:
                    colorPalette.ColorPrimary = Colors.DarkGray;
                    colorPalette.ColorAccent = Colors.LightGray;
                    colorPalette.TextColorPrimary = Colors.WhiteSmoke;
                    break;
            }
        }
        else
        {
            colorPalette.ColorPrimary = Colors.DarkRed;
            colorPalette.ColorAccent = Colors.LightPink;
            colorPalette.TextColorPrimary = Colors.WhiteSmoke;
        }

        return colorPalette;
    }
}