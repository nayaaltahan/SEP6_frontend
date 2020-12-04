using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using SEP6_frontendd.ApiModels;

namespace SEP6_frontendd
{
    public class ApiCalls
    {
        private const string URL = "https://localhost:44314/";
        
            
        public ApiCalls()
        {

        }

        public static List<MonthlyFlights> GetMonthlyFlights()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/frequency/monthly")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var monthlyFlights =
                        response.Content.ReadAsAsync<List<MonthlyFlights>>().Result;
                    return monthlyFlights;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                client.Dispose();
            }
            
        }

        public static List<MonthlyFlightsOrigin> GetMonthlyFlightsOrigin()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/frequency/origin")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var monthlyFlightsOrigins =
                        response.Content.ReadAsAsync<List<MonthlyFlightsOrigin>>().Result;
                    return monthlyFlightsOrigins;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                client.Dispose();
            }

        }

        public static List<DestinationFlights> GetDestinationFlights()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/destination/top10")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var destinationFlights =
                        response.Content.ReadAsAsync<List<DestinationFlights>>().Result;
                    return destinationFlights;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                client.Dispose();
            }

        }

        public static List<Airtime> GetMeanAirtime()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/tracker/airtime")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var meanAirtimes =
                        response.Content.ReadAsAsync<List<Airtime>>().Result;
                    return meanAirtimes;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        public static List<Delay> GetMeanDelay()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/tracker/delay")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var meanDelays =
                        response.Content.ReadAsAsync<List<Delay>>().Result;
                    return meanDelays;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
