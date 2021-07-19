using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace DataRouterApp
{
    public class DataRouter
    {
        public float Start()
        {
            Console.WriteLine("Listening on local...");
            UdpClient client = new UdpClient(10394);

            int hour = DateTime.Now.Hour;
            byte[] buffer;
            float temperature, totalTemp= 0;
            int count = 0;

            for (; ; )
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Broadcast, 0);
                buffer = client.Receive(ref remoteEP);

                Console.WriteLine($"Package from: IP {remoteEP.Address}, Port {remoteEP.Port}");
                String str = Encoding.UTF8.GetString(buffer);

                if (float.TryParse(str, out temperature))
                {
                    Console.WriteLine($"New temperature meassured: {temperature}");
                    totalTemp += temperature;
                    count++;
                }

                if (hour != DateTime.Now.Hour)
                {
                    if (count == 0 || totalTemp == 0)
                    {
                        client.Close();
                        return 0;
                    }
                    Console.WriteLine($"Local temp average: {totalTemp / (float)count}");
                    client.Close();
                    return totalTemp / (float)count;
                }

            }
        }
    }
}
