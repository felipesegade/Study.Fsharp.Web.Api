namespace Study.Fsharp.Web.Api.Integration.Tests

open Study.Fsharp.Web.Api.Integration.Tests
open Xunit

[<Collection(nameof WebApplicationCollection)>]
type WeatherForecastTests(fixture: WebApplicationFixture) =

    [<Fact>]
    let ``Should get returns a 200 code`` () =
        task {
            let client = fixture.CreateClient()

            let! response = client.GetAsync("api/weather-forecast")

            Assert.True(response.IsSuccessStatusCode)
        }
