namespace Algo.Exam.Test.LeetCode

module IntegerToRomanNumerals =

    type Symbol =
        | I = 1
        | V = 5
        | X = 10
        | L = 50
        | C = 100
        | D = 500
        | M = 1000

    let symbolRange =
        [ (Symbol.I, Symbol.V, Symbol.X)
          (Symbol.X, Symbol.L, Symbol.C)
          (Symbol.C, Symbol.D, Symbol.M) ]

    let convert number =
        (*
            - convert number to string and reverse
            - iterate through each string
                convert to roman numerals and accumulate
                if (number is upper - lower )
                    $"{lower}{upper}" // 4 = (V)5 - (I)1 -> IV
                else
                    Replicate roman value with number
        *)

        //String.concat ""


        let toPlaceValue place value =
            string value :: List.replicate place "0"
            |> String.concat ""
            |> int

        let removeZero number =
            number |> string |> Seq.head |> string |> int

        let toRomanNumeral value =
            symbolRange
            |> List.filter (fun range ->
                let (lower, mid, upper) = range
                value >= int lower && value <= int upper)
            |> List.head
            |> (fun range ->
                let (lower, mid, upper) = range

                if (value = int lower) then
                    [ string lower ]
                else if (value = int mid) then
                    [ string mid ]
                else if (value = int upper) then
                    [ string upper ]
                else if (value = int upper - int lower) then
                    [ string lower; string upper ]
                else if (value = int mid - int lower) then
                    [ string lower; string mid ]
                else if (value > int mid) then
                    let repeat = (value |> removeZero) - (int mid |> removeZero)

                    string mid
                    :: (List.replicate repeat (string lower))
                else
                    let repeat = (value |> removeZero)
                    List.replicate repeat (string lower))

        let rec traverse acc curr =
            let (places, romanNumerals) = acc

            match curr with
            | [] -> romanNumerals |> String.concat ""
            | x :: xs ->
                let romanNumeral = x |> toPlaceValue places |> toRomanNumeral
                traverse (places + 1, romanNumeral @ romanNumerals) xs

        let init = (0, [])

        let numbers = number |> string |> Seq.rev |> Seq.toList

        traverse init numbers

module IntegertoRomanNumeralsTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData(3, "III")
          TestCaseData(58, "LVIII")
          TestCaseData(1994, "MCMXCIV") ]

    [<TestCaseSource("testCaseData")>]
    let ``convert when passed with a integer, should return roman numeral value`` input expected =
        let actual = IntegerToRomanNumerals.convert input
        should equal expected actual
