namespace Library

open System
open System.Net
open CommonLibrary

module Downloader =

    let convertToMd(name: string, item:string[]) =
        let t = { Name = name; Dt = item.[0]; Open = float item.[1]; High = float item.[2]; Low = float item.[3]; Close = float item.[4]; Volume = float item.[5]; AdjClose = float item.[6] }
        t
    
    let htmlToMarketData(name:string, html: string) =
        let row = html.Split('\n') |> Seq.skip 1 |> Seq.map (fun i -> i.Split(','))
        row |> Seq.toList
            |> List.filter (fun lst -> lst.Length > 6)
            |> Seq.map (fun c -> convertToMd (name, c))

    let fetchWithAsync(name, url:string) = 
        async {
            try 
                let uri = new System.Uri(url)
                let webClient = new WebClient()
                let! html = webClient.AsyncDownloadString(uri)
                return (name,html.ToString())
            with error -> return (name, "Error")
        } 