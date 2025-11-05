namespace Study.Fsharp.Web.Api.Integration.Tests

open Microsoft.AspNetCore.Mvc.Testing
open Study.Fsharp.Web.Api
open Xunit

type WebApplicationFixture = WebApplicationFactory<Program>

[<CollectionDefinition(nameof WebApplicationCollection)>]
type WebApplicationCollection =
    inherit ICollectionFixture<WebApplicationFixture>
