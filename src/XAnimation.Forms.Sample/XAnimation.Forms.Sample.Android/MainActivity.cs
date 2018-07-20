using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace XAnimation.Forms.Sample.Droid
{
    [Activity(
        Label                = "XAnimation",
        Icon                 = "@mipmap/icon",
        Theme                = "@style/Theme.Splash",
        MainLauncher         = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // Changing to App's theme since we are OnCreate and we are ready to 
            // "hide" the splash
            Window.RequestFeature(WindowFeatures.ActionBar);
            SetTheme(Resource.Style.AppTheme);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource   = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        /// <inheritdoc />
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            MessagingCenter.Send(this, CommonMessaging.ConfigurationChanged);
        }
    }
}
