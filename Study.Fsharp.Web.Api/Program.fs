namespace Study.Fsharp.Web.Api

#nowarn "20"

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Scalar.AspNetCore
open Serilog

type Program = class end

module Program =

    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllers()

        builder.Services.AddOpenApi()

        builder.Services.AddSerilog(fun loggerConfiguration ->
            loggerConfiguration.ReadFrom.Configuration(builder.Configuration) |> ignore)

        let app = builder.Build()

        app.UseHttpsRedirection()

        app.UseAuthorization()
        app.MapControllers()

        app.MapOpenApi()
        app.MapScalarApiReference()

        app.UseSerilogRequestLogging(fun configureOptions ->
            configureOptions.IncludeQueryInRequestPath = true |> ignore)

        app.Run()

        exitCode
