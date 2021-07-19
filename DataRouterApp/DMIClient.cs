using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataRouterApp
{
    public class DMIClient
    {
        
        private const String URL = "https://dmigw.govcloud.dk/metObs/v1/observation?latest=&parameterId=temp_mean_past1h&stationId=06184";
        private const String key = "&api-key=fd9d512a-4e3f-40ca-94eb-ec05d9325829";
        private String data;
        private float temp;
        public async Task<(float, bool)> start()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(URL + key);
                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(data);
                    Console.WriteLine(data.Length);
                    data = data.Substring(data.Length - 5, 3);
                    temp = float.Parse(data);
                    Console.WriteLine(temp);
                    return (temp, true);
                }
                else
                {
                    Console.WriteLine("No DATA");
                    return (0, false);
                }
            }
            
        }
    }
}
