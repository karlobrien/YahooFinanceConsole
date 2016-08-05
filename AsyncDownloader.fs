namespace Library

open System
open System.Net
open CommonLibrary

module Downloader =

    let fetchWithAsync(name, url:string) = 
        async {
            try 
                let uri = new System.Uri(url)
                let webClient = new WebClient()
                let! html = webClient.AsyncDownloadString(uri)
                return (name,html.ToString())
            with error -> return (name, "Error")
        } 