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
        private const string URL = "https://iuzqr8b31g.execute-api.eu-west-1.amazonaws.com/Prod/";
        
            
        public ApiCalls()
        {

        }

        public static List<MonthlyFlights> GetMonthlyFlights()
        {
            var client = CreateHttpClient();

            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/frequency/monthly")
                        .Result; 
                if (response.IsSuccessStatusCode)
                {
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

        private static HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static List<MonthlyFlightsOrigin> GetMonthlyFlightsOrigin()
        {
            var client = CreateHttpClient();

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
            var client = CreateHttpClient();

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
            var client = CreateHttpClient();

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
            var client = CreateHttpClient();

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

        public static List<Weather> GetWeathersByOrigin()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/weather/origin")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var weathers =
                        response.Content.ReadAsAsync<List<Weather>>().Result;
                    return weathers;
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

        public static List<TemperatureOrigin> GetTemperatureAttributes()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/weather/temperatureAtt")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var temperatures =
                        response.Content.ReadAsAsync<List<TemperatureOrigin>>().Result;
                    return temperatures;
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

        public static List<Temperature> GetTemperaturesJfk()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/weather/temperature")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var temperatures =
                        response.Content.ReadAsAsync<List<Temperature>>().Result;
                    return temperatures;
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

        public static List<Temperature> GetMeanTemperaturesJfk()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/weather/meanTemperature")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var temperatures =
                        response.Content.ReadAsAsync<List<Temperature>>().Result;
                    return temperatures;
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

        public static List<TemperatureOrigin> GetMeanTemperaturesOrigin()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/weather/meanTemperatureOrigin")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var temperatures =
                        response.Content.ReadAsAsync<List<TemperatureOrigin>>().Result;
                    return temperatures;
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

        public static List<Manufacturer> GetManufacturers200()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/planes/200")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var manufacturers =
                        response.Content.ReadAsAsync<List<Manufacturer>>().Result;
                    return manufacturers;
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

        public static List<Manufacturer> GetManufacturersFlights()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/planes/flights")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var manufacturers =
                        response.Content.ReadAsAsync<List<Manufacturer>>().Result;
                    return manufacturers;
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

        public static List<Airbus> GetAirbuses()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/planes/airbuses")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var airbuses =
                        response.Content.ReadAsAsync<List<Airbus>>().Result;
                    return airbuses;
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

        public static List<DestinationOrigin> GetDestinationOrigins()
        {
            var client = CreateHttpClient();

            // List data response.
            try
            {
                HttpResponseMessage
                    response = client.GetAsync("v1/destination/top10Origin")
                        .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var flightsOrigins =
                        response.Content.ReadAsAsync<List<DestinationOrigin>>().Result;
                    return flightsOrigins;
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
