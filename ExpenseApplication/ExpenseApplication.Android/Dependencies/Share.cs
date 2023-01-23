using Android.Content;
using AndroidX.Core.Content;
using ExpenseApplication.Droid.Dependencies;
using ExpenseApplication.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpenseApplication.Droid.Dependencies
{
    class Share : IShare
    {
        [System.Obsolete]
        public Task Show(string title, string message, string filePath)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var documentUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.companyname.expenseapplication.provider", new Java.IO.File(filePath));
            intent.PutExtra(Intent.ExtraStream,documentUri);
            intent.PutExtra(Intent.ExtraSubject, message);

            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
            chooserIntent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(chooserIntent);

            return Task.FromResult(true);
        }
    }
}