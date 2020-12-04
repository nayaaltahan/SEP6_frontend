using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Helpers;

namespace SEP6_frontendd.Util
{
    public class Colors
    {
        public static ChartColor GetRed()
        {
            return ChartColor.FromRgba(255, 99, 132, 0.2);
        }

        public static ChartColor GetOrange()
        {
            return ChartColor.FromRgba(255, 159, 64, 0.2);
        }

        public static ChartColor GetYellow()
        {
            return ChartColor.FromRgba(255, 205, 86, 0.2);
        }

        public static ChartColor GetGreen()
        {
            return ChartColor.FromRgba(75, 192, 192, 0.2);
        }

        public static ChartColor GetBlue()
        {
            return ChartColor.FromRgba(54, 162, 235, 0.2);
        }

        public static ChartColor GetPurple()
        {
            return ChartColor.FromRgba(153, 102,255, 0.2);
        }

        public static ChartColor GetGrey()
        {
            return ChartColor.FromRgba(201, 203, 207, 0.2);
        }

        public static ChartColor GetRedBorder()
        {
            return ChartColor.FromRgb(255, 99, 132);
        }

        public static ChartColor GetOrangeBorder()
        {
            return ChartColor.FromRgb(255, 159, 64);
        }

        public static ChartColor GetYellowBorder()
        {
            return ChartColor.FromRgb(255, 205, 86);
        }

        public static ChartColor GetGreenBorder()
        {
            return ChartColor.FromRgb(75, 192, 192);
        }

        public static ChartColor GetBlueBorder()
        {
            return ChartColor.FromRgb(54, 162, 235);
        }

        public static ChartColor GetPurpleBorder()
        {
            return ChartColor.FromRgb(153, 102, 255);
        }

        public static ChartColor GetGreyBorder()
        {
            return ChartColor.FromRgb(201, 203, 207);
        }

    }
}
