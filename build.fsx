#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

open System
open System.IO
open Fake.Core
open Fake.Api
open Fake.DotNet

Target.create "Default" (fun _ ->
    let env = Environment.GetEnvironmentVariable "GITHUB_TOKEN"

    let cfg = File.ReadAllText("nuget.config").Replace("GITHUB_TOKEN", env)
    File.WriteAllText("nuget.config", cfg)


    Trace.traceImportantfn "TOKEN: %A %A" env.Length env
    let pkg = "Aardvark.Base.Essentials.5.0.3.nupkg"

    pkg |> DotNet.nugetPush (fun p ->
        { p with
            PushParams = 
                { p.PushParams with
                    Source = Some "github"
                }
        }
    )

)


Target.runOrDefault "Default" 