namespace Library

open CommonLibrary
open Downloader

module PriceGenerator = 
    let prices = urlList |> Seq.map fetchWithAsync 
                |> Async.Parallel
                |> Async.RunSynchronously
                |> Seq.collect htmlToMarketData

