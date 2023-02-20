using System.Diagnostics;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage(BluetoothScanner scanner)
	{
		InitializeComponent();

		BindingContext= scanner;
	}

    private async Task<bool> CheckBluetoothStatus()
    {
        try
        {
            var requestStatus = await new BluetoothPermissions().CheckStatusAsync();
            Debug.WriteLine("||||||CheckBluetoothStatus - return " + requestStatus.ToString());
            return requestStatus == PermissionStatus.Granted;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("||||||CheckBluetoothStatus - return FALLLSE");
            // logger.LogError(ex);
            return false;
        }
    }

    public async Task<bool> RequestBluetoothAccess()
    {
        try
        {

            var requestStatus = await new BluetoothPermissions().RequestAsync();

            Debug.WriteLine("||||||RequestBluetoothAccess - return " + requestStatus.ToString());
            return requestStatus == PermissionStatus.Granted;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("||||||RequestBluetoothAccess - return FALSSSE");
            // logger.LogError(ex);
            return false;
        }
    }

    public async Task CheckAndRequestBluetoothPermission()
    {
        Debug.WriteLine("||||||||CheckAndREquestBLEPermission");
        if (!await CheckBluetoothStatus())
        {
            await RequestBluetoothAccess();
        }
        await RequestBluetoothAccess();
    }

    protected async override void OnAppearing()
    {
        Console.WriteLine("Trying to enable bluetooth.");
        Debug.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||");
        await CheckAndRequestBluetoothPermission();
    }

}

