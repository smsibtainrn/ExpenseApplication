using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApplication.Views
{
    [ContentProperty("Text")]
    class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci = null;
        public string Text { get; set; }
        static readonly Lazy<ResourceManager> resourceManager = new Lazy<ResourceManager>(() => new ResourceManager("ExpenseApplication.Resources.AppResources", IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        public TranslateExtension()
        {
            ci = CultureInfo.CurrentCulture;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Text)) return string.Empty;

            var translation = resourceManager.Value.GetString(Text, ci);

            if (translation == null) return string.Empty;

            return translation;
        }
    }
}
