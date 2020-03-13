#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

open System
open Fake.Core
open Fake.Api
open Fake.DotNet

Target.create "Default" (fun _ ->
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