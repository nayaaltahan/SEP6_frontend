using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using SEP6_backendd.Models;
using System.Net.Http.Formatting;

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
                    Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                    response = client.GetAsync("/monthly")
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
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                client.Dispose();
            }

        }
    }
}
