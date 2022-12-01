namespace Algo.Exam

// https://www.pepcoding.com/resources/data-structures-and-algorithms-in-java-levelup/dynamic-programming/russian-doll-envelopes-official/ojquestion
module RussianDollEnvelopes =
    [<Struct>]
    type OptionalBuilder =
        member __.Bind(opt, binder) =
            match opt with
            | Some value -> binder value
            | None -> None

        member __.Return(value) = Some value

    let optional = OptionalBuilder()

    type Envelop =
        | Envelop of height: int * width: int * evelop: Envelop
        | Empty

    //[<Struct>]
    //type EnvelopDimentionBuilder =
    //    member __.Bind(opt, binder) =
    //        match opt with
    //        | Envelop (h, w, e) -> binder (h, w, e)
    //        | Empty -> Empty

    //    member __.Return((h, w, e)) = Envelop(h, w, e)

    //let envelop = EnvelopDimentionBuilder()

    module Envelop =
        let height env =
            match env with
            | Envelop (h, _, _) -> Some h
            | Empty -> None

        let width env =
            match env with
            | Envelop (_, w, _) -> Some w
            | Empty -> None

        let insertTo env1 env2 =
            match env1 with
            | Envelop (h, w, _) -> Envelop(h, w, env2)
            | Empty -> env2

        let fitsIn env1 env2 =
            optional {
                let! h1 = height env1
                let! w1 = width env1
                let! h2 = height env2
                let! w2 = width env2
                return (h1 > h2 && w1 > w2)
            }

        let accumulate acc cur =
            match (acc |> fitsIn cur) with
            | Some fits when fits -> acc |> insertTo cur
            | _ -> acc

    module Test =
        // desc sort by heigth then width
        // get the head
        // iterate through each of remaining items
        //   - if envelop can fit, insert otherwise move to next iter

        let run () =
            let assemble1 list =
                list
                |> List.map (fun (h, w) -> Envelop(h, w, Empty))
                |> List.sortBy Envelop.height
                |> List.sortBy Envelop.width
                |> List.reduce Envelop.accumulate

            let assemble2 list =
                list
                |> List.map (fun (h, w) -> Envelop(h, w, Empty))
                |> List.sortBy Envelop.width
                |> List.sortBy Envelop.height
                |> List.reduce Envelop.accumulate

            let data =
                [ (17, 5)
                  (26, 18)
                  (25, 34)
                  (48, 84)
                  (63, 72)
                  (42, 86)
                  (9, 55)
                  (4, 70)
                  (21, 45)
                  (68, 76)
                  (58, 51) ]

            data |> assemble1 |> printfn "%A"
            data |> assemble2 |> printfn "%A"

            ()


(*
                
const data: [number, number][] = [ 
    [17, 5],
    [26, 18],
    [25, 34],
    [48, 84],
    [63, 72],
    [42, 86],
    [9, 55],
    [4, 70],
    [21, 45],
    [68, 76],
    [58, 51]
];

type Envelop = {
    height: number,
    width: number,
    evenlop?: Envelop
}

namespace Envelop {
    export const byHeight = (x: Envelop, y: Envelop) => x.height - y.height;

    export const byWidth = (x: Envelop, y: Envelop) => x.width - y.width;

    export const accumulate = (acc: Envelop, cur: Envelop) => 
        (acc.width < cur.width && acc.height < cur.height)
            ? { height: cur.height, width: cur.width, evelop: acc }
            : acc;
}

const x = data
    .map<Envelop>(([height, width]) => ({ height, width }))
    .sort(Envelop.byHeight)
    .sort(Envelop.byWidth)
    .reduce(Envelop.accumulate);

console.log(x);
// desc sort by heigth then width
// get the head
// iterate through each of remaining items


*)