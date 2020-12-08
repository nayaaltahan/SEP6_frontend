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
                Data = counts,
                BackgroundColor = new List<ChartColor> { Colors.GetRed(), Colors.GetOrange(), Colors.GetYellow(), Colors.GetGreen(), Colors.GetBlue(), Colors.GetPurple(), Colors.GetRed(), Colors.GetOrange(), Colors.GetYellow(), Colors.GetGreen(), Colors.GetBlue(), Colors.GetPurple() },
                BorderColor = new List<ChartColor> { Colors.GetRedBorder(), Colors.GetOrangeBorder(), Colors.GetYellowBorder(), Colors.GetGreenBorder(), Colors.GetBlueBorder(), Colors.GetPurpleBorder(), Colors.GetRedBorder(), Colors.GetOrangeBorder(), Colors.GetYellowBorder(), Colors.GetGreenBorder(), Colors.GetBlueBorder(), Colors.GetPurpleBorder() },
                BorderWidth = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            chart.Options = BeginsAtZeroOptions();

            DisableLabel(chart.Options);

            return chart;
        }

        public static Chart BuildColorfulBarChartWithManyDatasets(List<string> labels, List<List<double?>> counts, List<string> datasetLabels)
        {
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Bar;

            ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();
            data.Labels = labels;

            data.Datasets = new List<Dataset>();

            var backgroundColors = new List<ChartColor>{Colors.GetRed(), Colors.GetBlue(), Colors.GetGreen() };

            var borderColors = new List<ChartColor> { Colors.GetRedBorder(), Colors.GetBlueBorder(), Colors.GetGreenBorder() };

            for (int i = 0 ; i < counts.Count; i++)
            {
                BarDataset dataset = new BarDataset()
                {
                    Label = datasetLabels[i],
                    Data = counts[i],
                    BackgroundColor = new List<ChartColor>{backgroundColors[i]},
                    BorderColor = new List<ChartColor> { borderColors[i] },
                    BorderWidth = new List<int> { 1 },
                };

                data.Datasets.Add(dataset);
            }

            chart.Options = BeginsAtZeroOptions();

            chart.Data = data;

            return chart;
        }

        public static Chart GetStackedBarChart(List<string> labels, List<List<double?>> counts,
            List<string> datasetLabels)
        {
            Chart chart = BuildColorfulBarChartWithManyDatasets(labels, counts, datasetLabels);
            StackedOptions(chart.Options);
            return chart;
        }

        public static Chart GetPercentageChart(List<string> labels, List<List<double?>> counts,
            List<string> datasetLabels)
        {
            Chart chart = BuildColorfulBarChartWithManyDatasets(labels, counts, datasetLabels);
            PercentageOptions(chart.Options);
            return chart;
        }

        public static Options BeginsAtZeroOptions()
        {
            var options = new Options
            {
                Scales = new Scales()
            };

            var scales = new Scales
            {
                YAxes = new List<Scale>
                {
                    new CartesianScale
                    {
                        Ticks = new CartesianLinearTick
                        {
                            BeginAtZero = true
                        }
                    }
                }
            };

            options.Scales = scales;

            return options;
        }

        public static void DisableLabel(Options options)
        {
            var legend = new Legend()
            {
                Display = false
            };

            options.Legend = legend;
        }

        public static void StackedOptions(Options options)
        {
            var scales = new Scales
            {
                YAxes = new List<Scale>
                {
                    new BarScale()
                    {
                        Stacked = true
                    }
                },
                XAxes = new List<Scale>
                {
                    new BarScale()
                    {
                        Stacked = true
                    }
                }

            };

            options.Scales = scales;
        }

        public static void PercentageOptions(Options options)
        {
            var scales = new Scales
            {
                YAxes = new List<Scale>
                {
                    new CartesianScale
                    {
                        Stacked = true,
                        Ticks = new CartesianLinearTick
                        {
                            Min = 0,
                            Max = 100,
                            Callback = "function(value){return value+ \"%\"}"
                        }
                    }
                },
                XAxes = new List<Scale>
                {
                    new BarScale()
                    {
                        Stacked = true,
                    }
                }
            };

            options.Scales = scales;
        }
    }
}
