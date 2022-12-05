﻿using System;
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
            measurement.Temperature = CreateTemperature(message).TemperatureInDegrees;
            measurement.Humidity = CreateHumidity(message).RelativeHumidity;
            measurement.CO2 = CreateCo2(message).CO2Level;
            measurement.Light = CreateLight(message).LightLevel;
            measurement.TimeStamp = DateTimeOffset.FromUnixTimeMilliseconds(message.ts).DateTime;
            return measurement;
        }
        
        public Temperature CreateTemperature(IOTMessage message)
        {
            String hexString = message.data;
            
            //Byte[0]
            int dec = int.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            
            //Byte[1]
            int point = int.Parse(hexString.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
            
            Console.WriteLine($"Decimal: {dec} Point: {point}");
            decimal number = (decimal) (dec + (point / 100.0));
            Console.WriteLine($"NUMBAAAAAAA: {number}");
            
            return new()
            {
                TemperatureInDegrees = number,
                TimeStamp = DateTimeOffset.FromUnixTimeMilliseconds(message.ts).DateTime,
                EUI = message.EUI
            }; 
        }

        public Humidity CreateHumidity(IOTMessage message)
        {
            String hexString = message.data;
            //Byte[2]
            int humidity = int.Parse(hexString.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
            return new Humidity()
            {
                EUI = message.EUI,
                TimeStamp = DateTimeOffset.FromUnixTimeMilliseconds(message.ts).DateTime,
                RelativeHumidity = humidity
            };
        }

        public COTwo CreateCo2(IOTMessage message)
        {
            String hexString = message.data;
            int co2Level = int.Parse(hexString.Substring(6,4), System.Globalization.NumberStyles.HexNumber);
            
            return new()
            {
                EUI = message.EUI,
                TimeStamp = DateTimeOffset.FromUnixTimeMilliseconds(message.ts).DateTime,
                CO2Level = co2Level
            };
        }

        public Light CreateLight(IOTMessage message)
        {
            String hexString = message.data;
            
            //Byte[5]&[6] which is the integer part
            int numbaaa = int.Parse(hexString.Substring(10), System.Globalization.NumberStyles.HexNumber);
            
            Console.WriteLine($"NUMBAAAAAAA: {numbaaa}");

            return new Light()
            {
                EUI = message.EUI,
                TimeStamp = DateTimeOffset.FromUnixTimeMilliseconds(message.ts).DateTime,
                LightLevel = numbaaa
            };
        }
        
    }
}