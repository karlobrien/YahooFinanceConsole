module YahooFinanceConsole

open Library.CommonLibrary
open Library.Downloader
open Library.PriceGenerator

[<EntryPoint>]
let main argv =
    printfn "%A" argv
    let result = prices |> Seq.maxBy (fun c -> c.Close)
    printfn "%s %f" result.Name result.Close
    0 // return an integer exit code
