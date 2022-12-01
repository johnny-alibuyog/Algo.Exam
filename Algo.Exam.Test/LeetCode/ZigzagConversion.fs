namespace Algo.Exam.Test.LeetCode

module ZigzagConversion =

    let convert (str: string) (rowCount: int) =

        (*
        - define a list of rows
        - iterate each char from the string
        -   if (currCol = 0 || currCol = rows - 1)

                 0 1 2 1 2 1 2
            0    P   A   H   N
            1    A P L S I I G
            2    Y   I   R


                 0 1 2 3 1 2 3
            0    P     I     N
            1    A   L S   I G
            2    Y A   H R
            3    P     I

        *)

        let rec accumulate (acc: char list list) (charList: char list) (counter: int) =
            match charList with
            | [] -> acc
            | xs ->
                let first = counter = 0
                let last = counter = rowCount - 1


                if (first || last) then
                    accumulate (acc @ [ xs[0 .. (rowCount - 1)] ]) xs[rowCount..] 1
                else
                    let whiteSpace x = String.replicate x " " |> Seq.toList
                    let before = whiteSpace (rowCount - (counter + 1))
                    let after = whiteSpace (rowCount - (rowCount - counter))
                    accumulate (acc @ [ before @ [ xs[0] ] @ after ]) xs[1..] (counter + 1)

        let acc = accumulate [] (str |> Seq.toList) 0

        let takeRow i =
            acc
            |> List.filter (fun x -> i < x.Length && x[i] <> char " ")
            |> List.map (fun x -> string x[i])

        [ 0 .. (rowCount - 1) ]
        |> List.map takeRow
        |> List.concat
        |> String.concat ""

module ZigzagConversionTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")
          TestCaseData("PAYPALISHIRING", 4, "PINALSIGYAHRPI") ]

    [<TestCaseSource("testCaseData")>]
    let ``when given a string, should convert to zigzag format`` (input: string) (rows: int) (expected: string) =
        ZigzagConversion.convert input rows
        |> should equal expected
