namespace Algo.Exam.PepCoding
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
        | Envelop of height: int * width: int * content: Envelop
        | Empty

    module Envelop =
        let private content env =
            match env with
            | Envelop (_, _, content) -> content
            | Empty -> Empty

        let private height env =
            match env with
            | Envelop (h, _, _) -> Some h
            | Empty -> None

        let private width env =
            match env with
            | Envelop (_, w, _) -> Some w
            | Empty -> None

        let private insertTo env1 env2 =
            match env1 with
            | Envelop (h, w, _) -> Envelop(h, w, env2)
            | Empty -> env2

        let rec private count env =
            match env with
            | Envelop (_, _, _) -> count (content env) + 1
            | Empty -> 0

        let private fitsIn env1 env2 =
            optional {
                let! h1 = height env1
                let! w1 = width env1
                let! h2 = height env2
                let! w2 = width env2
                return (h1 > h2 && w1 > w2)
            }

        let private accumulate acc cur =
            match (acc |> fitsIn cur) with
            | Some fits when fits -> acc |> insertTo cur
            | _ -> acc

        let arrange list =
                list
                |> List.sortBy height
                |> List.sortBy width
                |> List.reduce accumulate
                |> count

        // give me 
        

[<NUnit.Framework.TestFixture>]
module RussianDollEnvelopesTest =
    open FsUnit
    open NUnit.Framework
    open RussianDollEnvelopes

    let testCaseData =
        [ TestCaseData(
              [ (*Envelop(1, 1, Empty)*)
                Envelop(17, 5, Empty)
                Envelop(26, 18, Empty)
                Envelop(25, 34, Empty)
                Envelop(48, 84, Empty)
                Envelop(63, 72, Empty)
                Envelop(42, 86, Empty)
                Envelop(9, 55, Empty)
                Envelop(4, 70, Empty)
                Envelop(21, 45, Empty)
                Envelop(68, 76, Empty)
                Envelop(58, 51, Empty) ],
              5
          ) ]

    [<TestCaseSource("testCaseData")>]
    let ``Arrange folder`` input expected =
        let actual = Envelop.arrange input
        actual |> should equal expected
