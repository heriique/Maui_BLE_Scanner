using Android.App;
using Android.Content.PM;
using Android.OS;

[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnPostResume()
    {
        base.OnPostResume();

        // get permission for android >=12
        //RequestPermissions(Permission)

        //fast way to ensure we have location privileges
        Geolocation.GetLastKnownLocationAsync();
    }
}
