namespace FSharpLearn

//https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html



//let x = [ 1..20 ] |> Set.ofList
//printfn $"%A{[ 1; 2; 3; 4 ] @ [ 2; 4; 6; 7 ]}"

//let x: int option list = [ None; None; Some 1 ]
//x |> List.choose id |> printfn "%A"

//let f x y z =
//    x, y, z

//let xs = [1; 2; 3]
//let ys = [1; 2; 3]
//let zs = [1; 2; 3]
//(xs, ys, zs)
//|||> f |> printf "%A"

//let dd = [(0, "a"); (1, "b"); (2, "c")] |> dict
//dd.TryGetValue(0) |> printfn "%A"

//let ddd = [(0, "a"); (1, "b"); (2, "c")] |> Map.ofList
//ddd.TryGetValue 0 |> printfn "%A"

//ddd |> Map.tryFindKey 0


//type Transaction =
//    | Credit of int
//    | Debit of int

//type Statement = Statement of transaction: Transaction * balance: int

//let inputs = [ Credit 5; Debit 2; Credit 3 ]

//let newCharges, balance =
//    (0, inputs)
//    ||> List.mapFold (fun acc charge ->
//        match charge with
//        | Credit i -> Statement(Credit(i), acc + i), acc + i
//        | Debit o -> Statement(Debit(o), acc - o), acc - o)

//printf $"Charges: %A{newCharges} Balance: {balance}"