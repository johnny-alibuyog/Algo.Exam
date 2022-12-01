namespace Algo.Exam.Test.LeetCode

module ThreeSum =

    let evaluate ls =
        let minus1 x = x - 1
        let l = ls |> List.length |> minus1
        let mutable result = Set.empty

        for i in [ 0..l ] do
            for j in [ 0..l ] do
                for k in [ 0..l ] do
                    let differentIndex = i <> j && i <> k && j <> k
                    let sumIsZero = ls[i] + ls[j] + ls[k] = 0

                    if differentIndex && sumIsZero then
                        let value = [ ls[i]; ls[j]; ls[k] ] |> List.sort
                        result <- result |> Set.add value

        result |> Set.toList

    let evaluate2 (ls: int list) =
        let differentIndexes ((i, _), (j, _), (k, _)) = (i <> j && i <> k && j <> k)

        let sumIsZero ((_, x), (_, y), (_, z)) = (x + y + z = 0)

        let criteria x = differentIndexes x && sumIsZero x

        let mapInOrder ((_, x), (_, y), (_, z)) = [ x; y; z ] |> List.sort

        ls
        |> List.mapi (fun i x ->
            ls
            |> List.mapi (fun j y ->
                ls
                |> List.mapi (fun k z -> ((i, x), (j, y), (k, z)))))
        |> List.concat
        |> List.concat
        |> List.filter criteria
        |> List.map mapInOrder
        |> List.distinct
        |> List.sort


module ThreeSumTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData([ -1; 0; 1; 2; -1; -4 ], [ [ -1; -1; 2 ]; [ -1; 0; 1 ] ])
          TestCaseData([ 0; 1; 1 ], [] :> int list list) ]

    [<TestCaseSource("testCaseData")>]
    let ``ThreeSum.evaluate should get unique triples`` (input: int list) (expected: int list list) =
        let actual = ThreeSum.evaluate2 input
        should equal expected actual
