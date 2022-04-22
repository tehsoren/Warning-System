using System;
using System.Drawing;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace WarnerSystem.warners
{
    public static class XAMLHelper
    {

        public static Binding CreateNewBinding(Object sourceObject, string property, BindingMode bindingMode,
                                                System.Windows.DependencyObject targetObject,
                                                System.Windows.DependencyProperty targetProperty)
        {
            Binding newBinding = new Binding(property)
            {
                Source = sourceObject,
                Mode = bindingMode,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(targetObject, targetProperty, newBinding);

            return newBinding;
        }

        public static BitmapSource BitmapToSource(Bitmap bmp)
        {
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(),
                                                IntPtr.Zero,
                                                Int32Rect.Empty,
                                                BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
        }

    }
}
