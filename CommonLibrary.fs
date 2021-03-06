namespace Library
open System
module CommonLibrary =
    type MarketData = {Name:string; Dt:string; Open:float; High:float; Low:float; Close:float; Volume:float; AdjClose:float}
    
    let urlList = [ 
        "MSFT", "http://ichart.finance.yahoo.com/table.csv?s=MSFT&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"
        "GOOG", "http://ichart.finance.yahoo.com/table.csv?s=GOOG&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv" 
        "EBAY", "http://ichart.finance.yahoo.com/table.csv?s=EBAY&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"
        "AAPL", "http://ichart.finance.yahoo.com/table.csv?s=AAPL&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"
        "ADBE", "http://ichart.finance.yahoo.com/table.csv?s=ADBE&d=6&e=6&f=2013&g=d&a=1&b=1&c=2010&ignore=.csv"
    ]

    let convertToMd(name: string, item:string[]) =
        let t = { Name = name; Dt = item.[0]; Open = float item.[1]; High = float item.[2]; Low = float item.[3]; Close = float item.[4]; Volume = float item.[5]; AdjClose = float item.[6] }
        t
    
    let htmlToMarketData(name:string, html: string) =
        let row = html.Split('\n') |> Seq.skip 1 |> Seq.map (fun i -> i.Split(','))
        row |> Seq.toList
            |> List.filter (fun lst -> lst.Length > 6)
            |> Seq.map (fun c -> convertToMd (name, c))
    
    let calculateRequest(name: string, field: string, data: seq<MarketData>) =
        let values = data |> Seq.where (fun c -> c.Name = name)
        match field with
        | "Close" -> values |> Seq.maxBy (fun c -> c.Close)
        | "AdjClose" -> values |> Seq.maxBy (fun c -> c.AdjClose)
        | "Open" -> values |> Seq.maxBy (fun c -> c.Open)
        | "High" -> values |> Seq.maxBy (fun c -> c.High)
        | "Low" -> values |> Seq.maxBy (fun c -> c.Low)
        | "Volume" -> values |> Seq.maxBy (fun c -> c.Volume)
        | _ -> { Name = name; Dt = ""; Open = 0.0; High = 0.0; Low = 0.0; Close = 0.0; AdjClose = 0.0; Volume = 0.0}
