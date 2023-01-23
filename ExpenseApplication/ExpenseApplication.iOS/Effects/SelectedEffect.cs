﻿using ExpenseApplication.Effects;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("LPA")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpenseApplication.iOS.Effects
{
    class SelectedEffect : PlatformEffect
    {
        UIColor selectedColor;

        protected override void OnAttached()
        {
            selectedColor = new UIColor(176 / 255, 152 / 255, 164 / 255, 0 / 255);

        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "IsFocused"){
                if (Control.BackgroundColor!= selectedColor)
                {
                    Control.BackgroundColor = selectedColor;
                }
                else
                {
                    Control.BackgroundColor = UIColor.White;
                }
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}