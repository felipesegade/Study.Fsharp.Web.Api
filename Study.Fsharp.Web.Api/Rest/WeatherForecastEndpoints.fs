namespace Study.Fsharp.Web.Api.Rest

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Study.Fsharp.Web.Api

module Extensions =

    type WebApplication with

        member webApplication.MapWeatherForecast() =
            let summaries =
                [|
                    "Freezing"
                    "Bracing"
                    "Chilly"
                    "Cool"
                    "Mild"
                    "Warm"
                    "Balmy"
                    "Hot"
                    "Sweltering"
                    "Scorching"
                |]

            webApplication
                .MapGroup("api/weather-forecast")
                .WithTags("Weather Forecast")
                .MapGet(
                    "",
                    Func<WeatherForecast array>(fun () ->
                        let rng = Random()

                        [|
                            for index in 0..4 ->
                                {
                                    Date = DateTime.Now.AddDays(float index)
                                    TemperatureC = rng.Next(-20, 55)
                                    Summary = summaries[rng.Next(summaries.Length)]
                                }
                        |])
                )
