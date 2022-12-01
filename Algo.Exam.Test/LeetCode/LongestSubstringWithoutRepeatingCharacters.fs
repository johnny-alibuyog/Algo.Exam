namespace Algo.Exam.Test.LeetCode

module LongestSubstringWithoutRepeatingCharacters =
    // 1. use list of set to accumulate result
    // 2. iterate throuth the string
    // 3. generate accumulation folder
    //    - when accumulation is empty, create new set and add curr to it
    //    - when first accumulation's set contains curr string, create another and add it to accumulation list
    // 4. select the set with most elements and return

    let getLongsetSubstring (str: string) =
        let init: Set<char> list = List.empty

        let folder acc curr =
            match acc with
            | [] -> acc |> List.insertAt 0 (Set.ofList [ curr ])
            | x :: xs ->
                if (x.Contains curr) then
                    acc |> List.insertAt 0 (Set.ofList [ curr ])
                else
                    xs |> List.insertAt 0 (x.Add curr)

        let count (set: Set<char>) = set.Count

        let map (set: Set<char>) =
            (set.Count, set |> Set.map string |> String.concat "")

        str
        |> Seq.toList
        |> Seq.map char
        |> Seq.fold folder init
        |> Seq.maxBy count
        |> map

module LongestSubstringWithoutRepeatingCharactersTest =
    open FsUnit
    open NUnit.Framework
    open LongestSubstringWithoutRepeatingCharacters

    let testCaseData =
        [ TestCaseData("abcabcbb", 3)
          TestCaseData("bbbbb", 1)
          TestCaseData("pwwkew", 3) ]

    [<TestCaseSource("testCaseData")>]
    let ``can find longest substring without repeating characters`` input expected =
        let (actual, _) = getLongsetSubstring input
        should equal expected actual