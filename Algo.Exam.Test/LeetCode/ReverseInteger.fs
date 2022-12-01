namespace Algo.Exam.Test.LeetCode

module ReverseInteger =

    let reverse (number: int32) =
        number
        |> string
        |> Seq.rev
        |> Seq.map string
        |> String.concat ""
        |> fun x ->
            match System.Int32.TryParse x with
            | true, v -> v
            | false, _ -> 0

module ReverseIntegerTest =
    open NUnit.Framework
    open FsUnit

    let testCaseData =
        [ TestCaseData(123, 321)
          TestCaseData(5678, 8765)
          TestCaseData(1147483648, 0) ]

    [<TestCaseSource("testCaseData")>]
    let ``ReverseInteger.reverse should reverse int32`` (input: int32) (expected: int32) =
        let actual = ReverseInteger.reverse input
        should equal expected actual
