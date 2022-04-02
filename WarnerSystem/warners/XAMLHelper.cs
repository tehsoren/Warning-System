using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace WarnerSystem.warners
{
    public static class XAMLHelper
    {

        public static Binding CreateNewBinding(Object sourceObject,string property,BindingMode bindingMode,
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


    }
}
