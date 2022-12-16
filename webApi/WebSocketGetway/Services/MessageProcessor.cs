using System;
using System.Diagnostics.Metrics;
using Model;
using WebAPI.WebSocketGetway.Model;

namespace WebAPI.Gateway.Service
{
    public class MessageProcessor
    {
        
        
        public Measurement CreateMeasurement(IOTMessage message)
        {
            var measurement = new Measurement();
            measurement.Temperature = (decimal)GetDecimal(message.data, 0);
            measurement.Humidity = (decimal)GetDecimal(message.data, 4);
            measurement.Co2Level= (decimal)GetDecimal(message.data, 8);
            measurement.LightLevel = (decimal)GetDecimal(message.data, 12);
            measurement.Timestamp = DateTime.Now;
            Console.WriteLine(measurement.ToString());
            return measurement;
        }

        public decimal? GetDecimal(string numberInHex, int charStartingPoint)
        {
            String hexString = numberInHex;


            int number = int.Parse(hexString.Substring(charStartingPoint, 4),
                System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine($"Number: {number}");
            return number;
        }


        public decimal? CreateTemperature(string numberInHex, int charStartingPoint)
        {
            String hexString = numberInHex;

            int dec = int.Parse(hexString.Substring(charStartingPoint, 2), System.Globalization.NumberStyles.HexNumber);


            int point = int.Parse(hexString.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);


            decimal number = (decimal)(dec + (point / 100.0));

            return number;
        }
    }
}