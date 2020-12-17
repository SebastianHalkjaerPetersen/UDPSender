using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TestExam2;

namespace UDPSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();
            Measurement measurement = new Measurement();
            measurement.Humidity = randomizer.Next(0, 210);
            measurement.Pressure = randomizer.Next(0, 8);
            measurement.Temperature = randomizer.Next(-120, 120);
            string sendstring = $"Pressure: {measurement.Pressure}, \nHumidity: {measurement.Humidity}, \nTemperature: {measurement.Temperature}";
            
            
            UdpClient client = new UdpClient();
            client.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 7777);
            while (true)
            {
                byte[] sendbytes = Encoding.ASCII.GetBytes(sendstring);
                client.Send(sendbytes, sendbytes.Length, endPoint);
                Thread.Sleep(5000);
            }
            
            
        }
    }
}
