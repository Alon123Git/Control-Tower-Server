using Airplane_Project_2023;
using Data.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Numerics;
using System.Text.Json;
using JsonContent = PlanesSimulator.JsonContent;

HttpClient client = new() { BaseAddress = new Uri("https://localhost:7068/control-tower") };

Random rnd = new();

System.Timers.Timer timer = new System.Timers.Timer(rnd.Next(1000, 5000));
timer.Elapsed += (s, e) => PostPlane();
timer.Start();
//PostPlane();

Console.ReadLine();


async void PostPlane()
{
    Random rnd = new();

    // plane object from Flight model:
    var plane = new Flight
    {
        FlId = Guid.NewGuid().GetHashCode(),
        //Brand = (BrandTypeDto)rnd.Next(0, 3),
        Number = Guid.NewGuid().GetHashCode(),
        SerialNumber = "1",
        IsLanding = true,
        Ter = null,
        IsDeparture = true,
    };


    if (plane.FlId <= 0 || plane.Number <= 0)
    {
        Console.WriteLine("Id or Number less or equal to zero - ERROR");
    }
    else
    {
        // JSON cast: 
        using (var content = new JsonContent(plane))
        {
            var a = await client.PostAsync("flight", content);
        }

        // Print:30
        Console.WriteLine($"{DateTime.Now.ToString("mm:ss")} {plane.FlId} - {plane.PassengersCount} - {plane.Number} - {plane.SerialNumber} - {plane.IsLanding} - {plane.Ter} - {plane.IsDeparture}");

        // Print plane between 1 to 5 seconds: 
        timer.Interval = rnd.Next(1000, 5000);
    }
}