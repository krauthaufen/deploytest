#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

open System
open Fake.Core
open Fake.Api
open Fake.DotNet

Target.create "Default" (fun _ ->
    let env = Environment.GetEnvironmentVariable "GITHUB_PACKAGE_TOKEN"

    Trace.traceImportantfn "TOKEN: %A %A" env.Length env
    let pkg = "Aardvark.Base.Essentials.5.0.3.nupkg"

    pkg |> DotNet.nugetPush (fun p ->
        { p with
            PushParams = 
                { p.PushParams with
                    Source = Some "https://vrvis.myget.org/F/testfeed/api/v3/index.json"
                    ApiKey = Some env
                }
        }
    )

)


Target.runOrDefault "Default" 