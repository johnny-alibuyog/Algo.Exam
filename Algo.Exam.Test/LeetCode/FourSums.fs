namespace Algo.Exam.Test.LeetCode

module FourSums =
    let evaluate (nums: int array) (target: int) =
        let allowedLength =
            nums
            |> Array.groupBy id
            |> Array.map (fun (k, v) -> k, v.Length)
            |> Map.ofArray

        nums
        |> Array.sort
        |> Array.map (fun i ->
            nums
            |> Array.map (fun j ->
                nums
                |> Array.map (fun k ->
                    nums
                    |> Array.map (fun l ->
                        let entry = [| i; j; k; l |] |> Array.sort
                        let sumIsTarget = entry |> Array.sum |> (=) target

                        let isDistinct =
                            entry
                            |> Array.groupBy id
                            |> Array.forall (fun (k, v) -> allowedLength[k] = v.Length)

                        if sumIsTarget && isDistinct then
                            entry
                        else
                            Array.empty))))
        |> Array.concat
        |> Array.concat
        |> Array.concat
        |> Array.filter (fun x -> x <> Array.empty)
        |> Array.distinct

module FourSumsTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData(
              [| 1; 0; -1; 0; -2; 2 |],
              0,
              [| [| -2; -1; 1; 2 |]
                 [| -2; 0; 0; 2 |]
                 [| -1; 0; 0; 1 |] |]
          )
          TestCaseData([| 0; 0; 0; 0 |], 0, [| [| 0; 0; 0; 0 |] |]) ]

    [<TestCaseSource("testCaseData")>]
    let ``FourSums.evaluate should get unique quadruples``
        (input: int array)
        (target: int)
        (expected: int array array)
        =
        let actual = FourSums.evaluate input target
        should equal expected actual
