
using Android.Content;
using Android.Views;
using ExpenseApplication.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace ExpenseApplication.Droid.CustomRenderers
{
    class CustomTextCellRenderer: TextCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);

            switch (item.StyleId)
            {
                case "none":
                    cell.SetBackgroundColor(Android.Graphics.Color.AliceBlue);
                    break;
                case "checkmark":
                    cell.SetBackgroundColor(Android.Graphics.Color.Aqua);
                    break;
                case "detail-button":
                    cell.SetBackgroundColor(Android.Graphics.Color.Azure);
                    break;
                case "detail-disclouse-button":
                    cell.SetBackgroundColor(Android.Graphics.Color.Bisque);
                    break;
                case "dislosure":
                default:
                    cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    break;
            }

            return cell;
        }

    }
}