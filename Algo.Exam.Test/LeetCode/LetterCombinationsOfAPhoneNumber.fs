namespace Algo.Exam.Test.LeetCode

module LetterCombinationsOfAPhoneNumber =
    let private phoneNumberMap =
        [ (2, [ 'a'; 'b'; 'c' ])
          (3, [ 'd'; 'e'; 'f' ])
          (4, [ 'g'; 'h'; 'i' ])
          (5, [ 'j'; 'k'; 'l' ])
          (6, [ 'm'; 'n'; 'o' ])
          (7, [ 'p'; 'q'; 'r'; 's' ])
          (8, [ 't'; 'u'; 'v' ])
          (9, [ 'w'; 'x'; 'y'; 'z' ]) ]
        |> Map.ofList

    let convert (phoneNumber: string) =
        phoneNumber
        |> Seq.map (fun x -> phoneNumberMap[x |> string |> int])
        // give me cartesian product of all letters
        |> Seq.fold
            (fun acc x ->
                acc
                |> Seq.collect (fun y -> x |> Seq.map (fun z -> y @ [ z ])))
            (Seq.singleton [])
        |> Seq.map (fun x -> x |> List.map string |> String.concat "")
        |> Seq.toList

module LetterCombinationsOfAPhoneNumberTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData(
              "23",
              [ "ad"
                "ae"
                "af"
                "bd"
                "be"
                "bf"
                "cd"
                "ce"
                "cf" ]
          )
          TestCaseData("", [""] :> string list) ]

    [<TestCaseSource("testCaseData")>]
    let ``ThreeSum.evaluate should get unique triples`` input expected =
        let actual = LetterCombinationsOfAPhoneNumber.convert input
        should equal expected actual
