#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

open System
open Fake.Core

Target.create "Default" (fun _ ->
    let all = Environment.GetEnvironmentVariables()
    for e in all do
        let e = unbox<System.Collections.DictionaryEntry> e
        let k = e.Key |> unbox<string>
        let v = e.Value |> unbox<string>

        Trace.tracefn "%s: %s" k v
)


Target.runOrDefault "Default" 