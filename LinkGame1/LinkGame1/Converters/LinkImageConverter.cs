namespace LinkGame1.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    using LinkGame1.Entities;

    public class LinkImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as LinkItem;

            if (item != null)
            {
                switch (item.Value)
                {
                    case 0:
                        return @"D:\2.Picture\LinkGame\1.JPG";
                    case 1:
                        return @"D:\2.Picture\LinkGame\2.JPG";
                    case 2:
                        return @"D:\2.Picture\LinkGame\3.JPG";
                    case 3:
                        return @"D:\2.Picture\LinkGame\4.JPG";
                    case 4:
                        return @"D:\2.Picture\LinkGame\5.JPG";
                    case 5:
                        return @"D:\2.Picture\LinkGame\6.JPG";
                    case 6:
                        return @"D:\2.Picture\LinkGame\7.JPG";
                    case 7:
                        return @"D:\2.Picture\LinkGame\8.JPG";
                    case 8:
                        return @"D:\2.Picture\LinkGame\9.JPG";
                    case 9:
                        return @"D:\2.Picture\LinkGame\10.JPG";
                    case 10:
                        return @"D:\2.Picture\LinkGame\11.JPG";
                    case 11:
                        return @"D:\2.Picture\LinkGame\12.JPG";
                    case 12:
                        return @"D:\2.Picture\LinkGame\13.JPG";
                    case 13:
                        return @"D:\2.Picture\LinkGame\14.JPG";
                    case 14:
                        return @"D:\2.Picture\LinkGame\15.JPG";
                    case 15:
                        return @"D:\2.Picture\LinkGame\16.JPG";
                    case 16:
                        return @"D:\2.Picture\LinkGame\17.JPG";
                    case 17:
                        return @"D:\2.Picture\LinkGame\18.JPG";
                    case 18:
                        return @"D:\2.Picture\LinkGame\19.JPG";
                    case 19:
                        return @"D:\2.Picture\LinkGame\20.JPG";
                    default:
                        return Brushes.SkyBlue;
                }

                /*switch (item.Value)
                {
                    case 0:
                        return Brushes.Red;
                    case 1:
                        return Brushes.Orange;
                    case 2:
                        return Brushes.Yellow;
                    case 3:
                        return Brushes.Green;
                    case 4:
                        return Brushes.SkyBlue;
                    case 5:
                        return Brushes.Blue;
                    case 6:
                        return Brushes.DarkGoldenrod;
                    case 7:
                        return Brushes.Brown;
                    case 8:
                        return Brushes.BurlyWood;
                    case 9:
                        return Brushes.DarkRed;
                    case 10:
                        return Brushes.RoyalBlue;
                    case 11:
                        return Brushes.OrangeRed;
                    case 12:
                        return Brushes.Navy;
                    case 13:
                        return Brushes.HotPink;
                    case 14:
                        return Brushes.Purple;
                    case 15:
                        return Brushes.Plum;
                    default:
                        return Brushes.SkyBlue;
                }*/
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
