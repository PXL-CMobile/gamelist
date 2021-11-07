using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace VideoGameListApp.Converters
{
    public class RatingToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rating = (int)value;
            /*
             Rating
            0 - 20: Red
            20- 40: Orange
            40 - 60: Light Green
            60- 100: Green
            */
            if (rating < 20)
            {
                return Color.Red;
            } 
            else if (rating < 40)
            {
                return Color.Orange;
            }
            else if (rating < 60)
            {
                return Color.LightGreen;
            } 
            else
            {
                return Color.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
