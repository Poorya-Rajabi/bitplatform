﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Bit.Droid;
using Bit.ViewModel.Implementations;

namespace Bit.CSharpClientSample.Droid
{
    [Activity(Label = "Bit.CSharpClientSample", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : BitFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            SQLitePCL.Batteries.Init();

            base.OnCreate(bundle);

            UseDefaultConfiguration(bundle);

            LoadApplication(new App(new SampleAppDroidInitializer(this)));
        }
    }

    public class SampleAppDroidInitializer : BitPlatformInitializer
    {
        public SampleAppDroidInitializer(Activity activity)
            : base(activity)
        {
        }
    }

    [Activity(Label = nameof(SampleAppSSOUrlRedirectParserActivity), NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataSchemes = new[] { "test" },
    DataPath = "test://oauth2redirect")]
    public class SampleAppSSOUrlRedirectParserActivity : BitSSOUrlRedirectParserActivity
    {
    }
}
