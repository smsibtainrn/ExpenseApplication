﻿using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using ExpenseApplication.Droid.CustomRenderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace ExpenseApplication.Droid.CustomRenderers
{
    class CustomViewCellRenderer: ViewCellRenderer
    {
        private Android.Views.View _cell;
        private bool _isSelected;
        private Drawable _defaultBackground;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);
            _isSelected = false;
            _defaultBackground = _cell.Background;
            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName == "IsSelected") {
                _isSelected = !_isSelected;

                if (_isSelected)
                {
                    _cell.SetBackgroundColor(Color.FromHex("#E6E6E6").ToAndroid());
                }
                else {
                    _cell.Background = _defaultBackground;
                }
            }
        }
    }
}