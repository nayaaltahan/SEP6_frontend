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
        public static Chart BuildColorfulBarChart(List<string> labels, List<double?> counts )
        {
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Bar;

            ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();
            data.Labels = labels;

            BarDataset dataset = new BarDataset()
            {
                Label = "My First dataset",
                Data = counts,
                BackgroundColor = new List<ChartColor> { Colors.GetRed(), Colors.GetOrange(), Colors.GetYellow(), Colors.GetGreen(), Colors.GetBlue(), Colors.GetPurple(), Colors.GetRed(), Colors.GetOrange(), Colors.GetYellow(), Colors.GetGreen(), Colors.GetBlue(), Colors.GetPurple() },
                BorderColor = new List<ChartColor> { Colors.GetRedBorder(), Colors.GetOrangeBorder(), Colors.GetYellowBorder(), Colors.GetGreenBorder(), Colors.GetBlueBorder(), Colors.GetPurpleBorder(), Colors.GetRedBorder(), Colors.GetOrangeBorder(), Colors.GetYellowBorder(), Colors.GetGreenBorder(), Colors.GetBlueBorder(), Colors.GetPurpleBorder() },
                BorderWidth = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            return chart;
        }

        public static Chart BuildColorfulBarChartWithManyDatasets(List<string> labels, List<List<double?>> counts, List<string> datasetLabels)
        {
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Bar;

            ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();
            data.Labels = labels;

            data.Datasets = new List<Dataset>();

            foreach (var count in counts)
            {
                BarDataset dataset = new BarDataset()
                {
                    Label = "My First dataset",
                    Data = count,
                    BackgroundColor = new List<ChartColor> { Colors.GetRed(), Colors.GetOrange(), Colors.GetYellow(), Colors.GetGreen(), Colors.GetBlue(), Colors.GetPurple(), Colors.GetRed(), Colors.GetOrange(), Colors.GetYellow(), Colors.GetGreen(), Colors.GetBlue(), Colors.GetPurple() },
                    BorderColor = new List<ChartColor> { Colors.GetRedBorder(), Colors.GetOrangeBorder(), Colors.GetYellowBorder(), Colors.GetGreenBorder(), Colors.GetBlueBorder(), Colors.GetPurpleBorder(), Colors.GetRedBorder(), Colors.GetOrangeBorder(), Colors.GetYellowBorder(), Colors.GetGreenBorder(), Colors.GetBlueBorder(), Colors.GetPurpleBorder() },
                    BorderWidth = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                };

                data.Datasets.Add(dataset);
            }
            
            chart.Data = data;

            return chart;
        }
    }
}
