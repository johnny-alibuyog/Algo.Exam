module Program =

    let rec distribute e = function
        | [] -> [[e]]
        | x::xs' as xs -> (e::xs)::[for xs in distribute e xs' -> x::xs]

    let rec permute = function
        | [] -> [[]]
        | e::xs -> List.collect (distribute e) (permute xs)


    [<EntryPoint>]
    let main _ =
        ["c"; "b"; "a"; "c"; "a"; "a"; "a"; "b"; "c"]
        |> permute
        |> printf "%A"

        0