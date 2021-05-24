using Core.Model;
using Core.Model.Dao;
using Core.Model.Dao.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Core.Utilities
{
    public class SearchFlight
    {
        private static string url = "http://testapi.vivaair.com/otatest/api/";

        public static List<Flight> GetFlights(FlightFilter filter)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                var departure = DaoCity.GetById(filter.DepartureStationId);
                var arrival = DaoCity.GetById(filter.ArrivalStationId);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"Origin\":" + departure.IATACode + "," +
                                  "\"Destination\":" + arrival.IATACode + "," +
                                  "\"From\":" + filter.DepartureDate.ToString("yyyy-MM-dd") + " }";

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                List<Flight> flights = new List<Flight>();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    flights = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Flight>>(result);
                }

                return flights;

            }
            catch(Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                throw ex;
            }

        }

    }

}
