﻿
using ExpenseApplication.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(TextCell),typeof(CustomTextCellRenderer))]
namespace ExpenseApplication.iOS.CustomRenderers
{
    class CustomTextCellRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            switch (item.StyleId) {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;
                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;
                case "detail-disclouse-button":
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    break;
                case "dislosure":
                default:
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;
            }

            return cell;
        }
    }
}