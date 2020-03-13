#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

open System
open Fake.Core
open Fake.Api
open Fake.DotNet

Target.create "Default" (fun _ ->
    let pkg = "Aardvark.Base.Essentials.5.0.3.nupkg"
    let token = Environment.GetEnvironmentVariable "GITHUB_TOKEN"
    if not (String.IsNullOrWhiteSpace token) then
        pkg |> DotNet.nugetPush (fun p ->   
            { p with
                PushParams = 
                    { p.PushParams with
                        ApiKey = Some token
                        Source = Some "https://nuget.pkg.github.com/krauthaufen"
                    }
            }
        )
    else
        Trace.traceImportant "NO TOKEN"

)


Target.runOrDefault "Default" 