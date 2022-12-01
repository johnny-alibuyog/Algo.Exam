namespace Algo.Exam.Test.LeetCode


module SubstringWithConcatenationOfAllWords =
    let rec distribute e = function
        | [] -> [[e]]
        | x::xs' as xs -> (e::xs)::[for xs in distribute e xs' -> x::xs]

    let rec permute = function
        | [] -> [[]]
        | e::xs -> List.collect (distribute e) (permute xs)

    let rec findSubstringIndexes (str: string) (word: string) acc =
        let index = str.IndexOf word
        if index = -1 then
            acc
        else
            findSubstringIndexes (str.Substring(index + 1)) word (index::acc)        

    let findIndexes str words =
        words
        |> permute
        |> List.map (fun x -> findSubstringIndexes str (String.concat "" x) [])
        |> List.collect id
        |> List.distinct


module SubstringWithConcatenationOfAllWordsTest =
    open FsUnit
    open NUnit.Framework
    
    let testCaseData =
        [ TestCaseData(
              "barfoothefoobarman",
              [ "foo"; "bar" ],
              [ 0; 9 ]
          )
          TestCaseData(
              "wordgoodgoodgoodbestword",
              [ "word"; "good"; "best"; "word" ],
              [ ] :> int list
          )
          TestCaseData(
              "barfoofoobarthefoobarman",
              [ "bar"; "foo"; "the" ],
              [ 6; 9; 12 ]
          ) ]

    [<TestCaseSource("testCaseData")>]
    let ``SubstringWithConcatenationOfAllWords.findIndexes should get indexes of all substrings``
        (str: string)
        (words: string list)
        (expected: int list)
        =
        let actual = SubstringWithConcatenationOfAllWords.findIndexes str words
        should equal (expected |> List.sort) (actual |> List.sort)