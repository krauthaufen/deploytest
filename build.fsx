#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

open System
open Fake.Core
open Fake.Api
open Fake.DotNet

Target.create "Default" (fun _ ->
    let env = Environment.GetEnvironmentVariable "GITHUB_PACKAGE_TOKEN"

    
    let env = 
        if String.IsNullOrWhiteSpace env then Environment.GetEnvironmentVariable "GITHUB_TOKEN"
        else env

    Trace.traceImportantfn "TOKEN: %A %A" env.Length env
    let pkg = "Aardvark.Base.Essentials.5.0.3.nupkg"

    pkg |> DotNet.nugetPush (fun p ->
        { p with
            PushParams = 
                { p.PushParams with
                    Source = Some "https://nuget.pkg.github.com/krauthaufen/index.json"
                    ApiKey = Some env
                }
        }
    )

)


Target.runOrDefault "Default" 