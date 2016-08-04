#load "CommonLibrary.fs"
#load "AsyncDownloader.fs"

open Library.CommonLibrary
open Library.Downloader

/// Stock symbol and URL to Yahoo finance
let urlList = [ 
    "MSFT", "http://ichart.finance.yahoo.com/table.csv?s=MSFT&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"
    "GOOG", "http://ichart.finance.yahoo.com/table.csv?s=GOOG&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv" 
    "EBAY", "http://ichart.finance.yahoo.com/table.csv?s=EBAY&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"
    "AAPL", "http://ichart.finance.yahoo.com/table.csv?s=AAPL&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"
    "ADBE", "http://ichart.finance.yahoo.com/table.csv?s=ADBE&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"
]

let prices = urlList |> Seq.map fetchWithAsync
            |> Async.Parallel
            |> Async.RunSynchronously
            |> Seq.collect htmlToMarketData

//let maxClose2 = prices |> Seq.maxBy (fun m -> m.Close)
//printfn "%f" maxClose2.Close 
let result = prices |> Seq.maxBy (fun c -> c.Close)
printfn "%f" result.Close