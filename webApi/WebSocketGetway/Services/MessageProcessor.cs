using System;
using System.Diagnostics.Metrics;
using Model;
using WebAPI.WebSocketGetway.Model;

namespace WebAPI.Gateway.Service
{
    public class MessageProcessor
    {

        public Measurements CreateMeasurement(IOTMessage message)
        {
            var measurement = new Measurements();
            measurement.Temperature = (decimal)GetDecimal(message.data,0);
            measurement.Humidity = (decimal)GetDecimal(message.data,4);
            measurement.Co2Level = (decimal)GetDecimal(message.data,8);
            measurement.LightLevel = (decimal)GetDecimal(message.data,12);
            measurement.Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(message.ts).DateTime;
            Console.WriteLine(measurement.ToString());
            return measurement;
        }

        public decimal? GetDecimal(string numberInHex, int charStartingPoint)
        {
            String hexString = numberInHex;

            // simplified conversion, without considering a floating point
            int number = int.Parse(hexString.Substring(charStartingPoint, 4), System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine($"number : {number}");
            return number;
        }

        public decimal? CreateHumidity(IOTMessage message)
        {
            String hexString = message.data;
            
           
           int number = int.Parse(hexString.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
           Console.WriteLine($"NUMBAAAAAAA: {number}");
           return number;

         

        }

        public decimal? CreateTemperature(IOTMessage message){
            String hexString = message.data;
            
            return null;
        }

        public decimal? CreateCo2(IOTMessage message)
        {
            String hexString = message.data;

            return null;

        }

        public decimal? Light(IOTMessage message)
        {
            String hexString = message.data;
            
            //Byte[0]
            int dec = int.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            
            //Byte[1]
            int point = int.Parse(hexString.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
            
            Console.WriteLine($"Decimal: {dec} Point: {point}");
            decimal number = (decimal) (dec + (point / 100.0));
            Console.WriteLine($"NUMBER: {number}");

            return number;
        }
        
    }
}