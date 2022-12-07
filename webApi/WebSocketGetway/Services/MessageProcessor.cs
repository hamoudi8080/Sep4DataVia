using System;
using Entities;

using WebAPI.Models;
using WebAPI.WebSocketGetway.Model;

namespace WebAPI.Gateway.Service
{
    public class MessageProcessor
    {

        public Measurement CreateMeasurement(IOTMessage message)
        {
            var measurement = new Measurement();
            measurement.Temperature = (decimal)GetDecimal(message.data,0);
            measurement.Humidity = (decimal)GetDecimal(message.data,4);
            measurement.CO2 = (decimal)GetDecimal(message.data,8);
            measurement.Light = (decimal)GetDecimal(message.data,12);
            measurement.TimeStamp = DateTimeOffset.FromUnixTimeMilliseconds(message.ts).DateTime;
            Console.WriteLine(measurement.ToString());
            return measurement;
        }

        public decimal? GetDecimal(string numberInHex, int charStartingPoint)
        {
            String hexString = numberInHex;

            // simplified conversion, without considering a floating point
            int number = int.Parse(hexString.Substring(charStartingPoint, 4), System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine($"NUMBAAAAAAA: {number}");
            return number;
        }

        public decimal? CreateHumidity(IOTMessage message)
        {
            String hexString = message.data;
            
           // simplified conversion, without considering a floating point
           //Byte[0]
           int number = int.Parse(hexString.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
           Console.WriteLine($"NUMBAAAAAAA: {number}");
           return number;

           /* it is parsing the bytes into int and resulting in a floating number, like f.x. 45.5 of humidity
           //Byte[0]
           int dec = int.Parse(hexString.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
          
           //Byte[1]
           int point = int.Parse(hexString.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
           
           Console.WriteLine($"Decimal: {dec} Point: {point}");
           decimal number = (decimal) (dec + (point / 100.0));
           
           return number;
           */

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
            Console.WriteLine($"NUMBAAAAAAA: {number}");

            return number;
        }
        
    }
}