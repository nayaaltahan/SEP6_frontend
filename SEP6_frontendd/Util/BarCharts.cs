using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Helpers;
using ChartJSCore.Models;

namespace SEP6_frontendd.Util
{
    public class BarCharts
    {
        public static Chart BuildColorfulBarChart(List<string> labels, List<int> data)
        {
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Bar;

            ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();
            data.Labels = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            BarDataset dataset = new BarDataset()
            {
                Label = "My First dataset",
                Data = new List<double?> { 65, 59, 80, 81, 56, 55, 40, 30, 11, 50, 64, 71 },
                BackgroundColor = new List<ChartColor> { Colors.GetRed(), Colors.GetOrange(), Colors.GetYellow(), Colors.GetGreen(), Colors.GetBlue(), Colors.GetPurple(), Colors.GetRed(), Colors.GetOrange(), Colors.GetYellow(), Colors.GetGreen(), Colors.GetBlue(), Colors.GetPurple() },
                BorderColor = new List<ChartColor> { Colors.GetRedBorder(), Colors.GetOrangeBorder(), Colors.GetYellowBorder(), Colors.GetGreenBorder(), Colors.GetBlueBorder(), Colors.GetPurpleBorder(), Colors.GetRedBorder(), Colors.GetOrangeBorder(), Colors.GetYellowBorder(), Colors.GetGreenBorder(), Colors.GetBlueBorder(), Colors.GetPurpleBorder() },
                BorderWidth = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            return chart;
        }
    }
}
