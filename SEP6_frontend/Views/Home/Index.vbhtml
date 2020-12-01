﻿@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>ASP.NET</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Getting started</h2>
        <p>
            ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
            enables a clean separation of concerns and gives you full control over markup
            for enjoyable, agile development.
        </p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301865">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301867">Learn more &raquo;</a></p>
    </div>
</div>

@{
      var barChart = new BarChart();
      barChart.ComplexData.Labels.AddRange(new []{ "January", "February",  "March", "April", "May", "June", "July"});
      barChart.ComplexData.Datasets.AddRange(new List<ComplexDataset>
    {
    new ComplexDataset
    {
    Data = new List<double>
        { 65, 59, 80, 81, 56, 55, 40 },
        Label = "My First dataset",
        FillColor = "rgba(220,220,220,0.2)",
        StrokeColor = "rgba(220,220,220,1)",
        PointColor = "rgba(220,220,220,1)",
        PointStrokeColor = "#fff",
        PointHighlightFill = "#fff",
        PointHighlightStroke = "rgba(220,220,220,1)",
        },
        new ComplexDataset
        {
        Data = new List<double>
            { 28, 48, 40, 19, 86, 27, 90 },
            Label = "My Second dataset",
            FillColor = "rgba(151,187,205,0.2)",
            StrokeColor = "rgba(151,187,205,1)",
            PointColor = "rgba(151,187,205,1)",
            PointStrokeColor = "#fff",
            PointHighlightFill = "#fff",
            PointHighlightStroke = "rgba(151,187,205,1)",
            }
            });
            }

            <canvas id="myCanvas" width="400" height="400"></canvas>
            @Html.CreateChart("myCanvas", barChart)
