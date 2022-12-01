namespace Algo.Exam.Test.LeetCode

module StringToInteger =
    let convert (str: string) =
        let numbersOrSigns x =
            System.Char.IsDigit(x)
            || x = char "-"
            || x = char "+"

        str 
        |> Seq.filter numbersOrSigns
        |> Seq.map string
        |> String.concat ""
        |> fun x -> 
            match System.Int32.TryParse x with
            | true, v -> v
            | false, _ -> 0

module StringToIntegerTest =
    open NUnit.Framework
    open FsUnit

    let testCaseData =
        [ TestCaseData("42", 42)
          TestCaseData("   -42", -42)
          TestCaseData("4193 with words", 4193) ]

    [<TestCaseSource("testCaseData")>]
    let ``StringToInteger.convert should convert string to int32`` (input: string) (expected: int32) =
        let actual = StringToInteger.convert input
        should equal expected actual
