module YahooFinanceConsole

open Library.CommonLibrary
open Library.Downloader
open Library.PriceGenerator

[<EntryPoint>]
let main argv =
    printfn "%A" argv
    let stock = argv.[0]
    let value = argv.[1]



    let result = calculateRequest(stock, value, prices)
    printfn "Name: %s \nClose: %f \nHigh: %f \nLow: %f \nVolume: %f \nAdjClose: %f" result.Name result.Close result.High result.Low result.Volume result.AdjClose
    0 // return an integer exit code
