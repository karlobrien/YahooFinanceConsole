#load "CommonLibrary.fs"
#load "AsyncDownloader.fs"
#load "PriceGenerator.fs"

open Library.CommonLibrary
open Library.Downloader
open Library.PriceGenerator

let result = prices |> Seq.maxBy (fun c -> c.Close)
printfn "%f" result.Close

let input = prices |> Seq.cache
let test = calculateRequest("GOOG", "Close", input)
