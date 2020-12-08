using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Helpers;
using ChartJSCore.Models;
using SEP6_frontendd.ApiModels;

namespace SEP6_frontendd.Util
{
    public class BubbleCharts 
    {
        public static Chart BuildTemperatureBubbleChart(List<Temperature> temperatures)
        {
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Bubble;

            var data = new Data();

            var bubbleDataList = new List<BubbleData>();

            foreach (var temp in temperatures)
            {
                TimeSpan t = (temp.Time - new DateTime(1970,1,1) );
                var bubbleData = new BubbleData
                {
                    X = (int)t.TotalSeconds,
                    Y = temp.Temp,
                    R = 5
                };
                bubbleDataList.Add(bubbleData);
            }

            var dataset = new BubbleDataset()
            {
                Data = bubbleDataList,
            };

            data.Datasets = new List<Dataset> {dataset};

            DisableLabel(chart.Options);

            FixTimeLabels(chart.Options);

            chart.Data = data;

            return chart;
        }

        public static Chart BuildTemperatureAttributesBubbleChart(TemperatureOrigin temperatureOrigins, ChartColor color1, ChartColor color2)
        {
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Bubble;

            var data = new Data();

            List<Dataset> datasets = new List<Dataset>();

            ChartColor[] colors = {Colors.GetRed(), Colors.GetRedBorder(), Colors.GetBlue(), Colors.GetBlueBorder(), Colors.GetGreen(), Colors.GetGreenBorder() };

            int j = 0;

            
                var dataset = new BubbleDataset();
                var bubbleDataList = new List<BubbleData>();
                foreach (var temp in temperatureOrigins.TemperatureAtts)
                {
                    TimeSpan t = (temp.Time - new DateTime(1970, 1, 1));
                    var bubbleData = new BubbleData
                    {
                        X = (int)t.TotalSeconds,
                        Y = temp.Temp,
                        R = 5
                    };
                    bubbleDataList.Add(bubbleData);
                }
                dataset.Data = bubbleDataList;
                dataset.BorderColor = new List<ChartColor>{color1};
                dataset.BackgroundColor = new List<ChartColor>{ChartColor.FromRgba(255,255,255,0.2)};
                dataset.Label = "TEMP";
                datasets.Add(dataset);

                var dewpDataset = new BubbleDataset();
                var bubbleDataList2 = new List<BubbleData>();
                foreach (var temp in temperatureOrigins.TemperatureAtts)
                {
                    TimeSpan t = (temp.Time - new DateTime(1970, 1, 1));
                    var bubbleData = new BubbleData
                    {
                        X = (int)t.TotalSeconds,
                        Y = temp.Dewp,
                        R = 5
                    };
                    bubbleDataList2.Add(bubbleData);
                }
                dewpDataset.Data = bubbleDataList2;
                dewpDataset.Label = "DEWP";
                dewpDataset.BorderColor = new List<ChartColor> { color2 };
                dewpDataset.BackgroundColor = new List<ChartColor> { ChartColor.FromRgba(255, 255, 255, 0.2) };
                datasets.Add(dewpDataset);
            

            data.Datasets = new List<Dataset>{dataset, dewpDataset};

            FixTimeLabels(chart.Options);

            chart.Data = data;

            return chart;
        }

        public static Chart BuildTemperatureAttributesBubbleChart1(List<TemperatureOrigin> temperatureOrigins)
        {
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Bubble;

            var data = new Data();

            List<Dataset> datasets = new List<Dataset>();

            ChartColor[] colors = { Colors.GetRedBorder(), Colors.GetBlueBorder(), Colors.GetGreenBorder() };

            int j = 0;

            for (int i = 0; i < temperatureOrigins.Count; i++)
            {
                var dataset = new BubbleDataset();
                var bubbleDataList = new List<BubbleData>();
                foreach (var temp in temperatureOrigins[i].TemperatureAtts)
                {
                    TimeSpan t = (temp.Time - new DateTime(1970, 1, 1));
                    var bubbleData = new BubbleData
                    {
                        X = (int)t.TotalSeconds,
                        Y = temp.Temp,
                        R = 5
                    };
                    bubbleDataList.Add(bubbleData);
                }
                dataset.Data = bubbleDataList;
                dataset.BorderColor = new List<ChartColor> { colors[j++] };
                dataset.BackgroundColor = new List<ChartColor> { ChartColor.FromRgba(255, 255, 255, 0.2) };
                dataset.Label = temperatureOrigins[i].Origin;
                datasets.Add(dataset);
            }

            data.Datasets = datasets;

            FixTimeLabels(chart.Options);

            chart.Data = data;

            return chart;
        }

        public static void DisableLabel(Options options)
        {
            var legend = new Legend()
            {
                Display = false
            };

            options.Legend = legend;
        }

        public static void FixTimeLabels(Options options)
        {
            var scales = new Scales
            {
                XAxes = new List<Scale>
                {
                    new CartesianScale
                    {
                        Ticks = new CartesianLinearTick
                        {
                            Callback = "function(value, index, values) { var date1 = new Date(value * 1000);var monthname = date1.toLocaleString('default', { month: 'short' }); return monthname + \" \" + date1.getFullYear(); }"
                        }
                    }
                }
            };

            var tooltip = new ToolTip
            {
                Callbacks = new Callback
                {
                    Label = "function(tooltipItem, data) { var label = data.datasets[tooltipItem.datasetIndex].label || ''; " +
                            "if (label) { var date1 = new Date(label * 1000); label = date1.toString(); }; return label; "
                }
            };

            options.Scales = scales;
        }
    }
}
