using Android.App;
using Android.OS;
using Android.Util;
using NUnit.Framework;
using NUnit.Runner.Services;
using xamarin.unit.tests;

namespace xamarin.nunit.test
{
    [Activity(Label = "xamarin.nunit.test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Android.Util.Log.WriteLine(LogPriority.Debug, "", $"OnCreate(savedInstanceState={savedInstanceState}) <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<"); //!!!

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // This will load all tests within the current project
            var nunit = new NUnit.Runner.App();

            //// If you want to add tests in another assembly
            nunit.AddTestAssembly(typeof(SampleUnitTest).Assembly);

            // Do you want to automatically run tests when the app starts?
            nunit.Options = new TestOptions();
#if !DEBUG
            nunit.Options = new TestOptions { AutoRun = true, TcpWriterParamaters = new TcpWriterInfo("10.0.2.2", 13000) };
#endif
            LoadApplication(nunit);

            var context = TestContext.CurrentContext;
        }
    }
}

