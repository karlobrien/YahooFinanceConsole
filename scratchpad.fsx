#load "CommonLibrary.fs"
#load "AsyncDownloader.fs"

open Library.CommonLibrary
open Library.Downloader

let name = "ebay"
let ebayUrl = "http://ichart.finance.yahoo.com/table.csv?s=EBAY&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"

let urlList = [name, ebayUrl]

let prices = urlList |> Seq.map fetchWithAsync
            |> Async.Parallel
            |> Async.RunSynchronously
            |> Seq.collect htmlToMarketData

//let maxClose2 = prices |> Seq.maxBy (fun m -> m.Close)
//printfn "%f" maxClose2.Close 
let result = prices |> Seq.maxBy (fun c -> c.Close)
printfn "%f" result.Close