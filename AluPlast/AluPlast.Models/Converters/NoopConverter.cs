﻿using System;
using Windows.UI.Xaml.Data;

namespace AluPlast.Models.Converters
{
    public class NoopConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
