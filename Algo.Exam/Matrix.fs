namespace Algo.Exam

type Node = { value: int; col: int; row: int }


module Matrix =

    let create value col row = { value = value; col = col; row = row }

    let intersects this other =
        (this.col = (other.col + 1)
         && this.row = (other.row))
        || (this.col = (other.col - 1)
            && this.row = (other.row))
        || (this.col = (other.col)
            && this.row = (other.row - 1))
        || (this.col = (other.col)
            && this.row = (other.row + 1))

    let isTrue x = x.value = 1

    let col x = x.col

    let row x = x.row

    let findIntersection other list =
        list
        |> List.exists (fun this -> intersects other this)


module MatrixTest =
    let data =
        [ [ 1; 0; 0; 1; 0 ]
          [ 1; 0; 1; 0; 0 ]
          [ 0; 0; 1; 0; 1 ]
          [ 1; 0; 1; 0; 1 ]
          [ 1; 0; 1; 1; 0 ] ]

    let log x =
        printf $"%A{x}"
        x

    let nodes =
        seq {
            for row = 0 to data.Length - 1 do
                for col = 0 to data[row].Length - 1 do
                    yield Matrix.create (data[row][col]) col row
        }
        |> Seq.filter Matrix.isTrue
        |> Seq.sortBy Matrix.row
        |> Seq.sortBy Matrix.col
        |> List.ofSeq

    let run () =
        nodes
        |> List.fold
            (fun acc cur ->
                let valueOption = acc |> List.tryFind (Matrix.findIntersection cur)

                match valueOption with
                | Some value ->
                    acc
                    |> List.map (fun item ->
                        if item = value then
                            item @ [ cur ]
                        else
                            item)

                | None -> [ cur ] :: acc)

            []
        |> List.map List.length
        |> List.filter (fun x -> x > 1)
        |> printfn "%A"
