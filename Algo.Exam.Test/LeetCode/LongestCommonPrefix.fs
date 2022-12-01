namespace Algo.Exam.Test.LeetCode

module LongestCommonPrefix =

    let evaluate (list: string list) =
        let head = list |> List.head

        head
        |> Seq.map string
        |> Seq.fold
            (fun prevPrefix curr ->
                let currPerfix = $"{prevPrefix}{curr}"
                let withPrefix (value: string) = value.StartsWith currPerfix

                list
                |> List.forall withPrefix
                |> function
                    | true -> currPerfix
                    | false -> prevPrefix)
            ""

module LongestCommonPrefixTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData([ "flower"; "flow"; "flight" ], "fl")
          TestCaseData([ "dog"; "racecar"; "car" ], "") ]

    [<TestCaseSource("testCaseData")>]
    let ``evaluate should take the longest prefix`` input expected =
        let actual = LongestCommonPrefix.evaluate input
        should equal expected actual
