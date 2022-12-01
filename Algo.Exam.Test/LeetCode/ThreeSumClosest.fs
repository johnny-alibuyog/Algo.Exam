namespace Algo.Exam.Test.LeetCode

module ThreeSumCloses =
    let evaluate l target =
        l
        |> List.map (fun x ->
            l
            |> List.map (fun y -> l |> List.map (fun z -> x, y, z)))
        |> List.concat
        |> List.concat
        |> List.map (fun (x, y, z) -> (x + y + z))
        |> List.sortBy (fun x -> uint (target - x))
        |> List.last

module ThreeSumClosesTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData([ -1; 2; 1; -4 ], 1, 2)
          TestCaseData([ 0; 0; 0 ], 2, 0) ]

    [<TestCaseSource("testCaseData")>]
    let ``ThreeSum.evaluate should get unique triples`` input target expected =
        let actual = ThreeSumCloses.evaluate input target
        should equal expected actual
