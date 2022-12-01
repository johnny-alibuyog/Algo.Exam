namespace Algo.Exam.Test.LeetCode

module LongestPalindromicSubstring1 =

    let private minus x y = x - y

    let private minus1 x = minus x 1

    let private getUpperIndex x = x |> String.length |> minus1

    let getCenterIndexes str =
        let rec accumulate acc whole currentIndex =
            let rec compareRight str index =
                let hasNext = (str |> getUpperIndex) > index

                if (hasNext) then
                    let equalToNext = str[index] = str[index + 1]

                    if (equalToNext) then
                        compareRight whole (index + 1)
                    else
                        index
                else
                    index

            let lastIndex = compareRight whole currentIndex
            let newAcc = [ currentIndex..lastIndex ] :: acc
            let hasNext = (whole |> getUpperIndex) > lastIndex

            if (hasNext) then
                accumulate newAcc whole (lastIndex + 1)
            else
                newAcc

        let hasValue = (str |> String.length) > 0

        if (hasValue) then
            accumulate [] str 0
        else
            []

    let rec expandFromCenter whole indexRange =
        let (currLefti, currRighti) = (List.head indexRange, List.last indexRange)
        let (lefti, righti) = (currLefti - 1, currRighti + 1)
        let hasLeft = lefti > -1
        let hasRight = righti < (whole |> String.length)

        if (not hasLeft || not hasRight) then
            whole[currLefti..currRighti]
        else
            let leftEqualsRight = whole[lefti] = whole[righti]

            if (not leftEqualsRight) then
                whole[currLefti..currRighti]
            else
                expandFromCenter whole ([ lefti; righti ])


    let longestPalindrome str =
        (*
        - define center indexes
        - compare left to right (rec)
        - when equal, increment and compare
        *)

        match str with
        | None -> None
        | Some s when s = "" -> None
        | Some s ->
            let evaluatePalindorme = expandFromCenter s
            let length x = x |> String.length

            s
            |> getCenterIndexes
            |> List.map evaluatePalindorme
            |> List.sortBy length
            |> List.tryLast


module LongestPalindromicSubstring2 =
    type Acc = Acc of s: string * left: int * rigth: int

    let longestPalindrome str =
        (*
        - traverse through string
        - define cernter (left, right)
        - expand on center (left, right)
        - repeat if has next
        *)

        let rec defineCenter (s: string) (left: int, right: int) =
            let nRight = right + 1

            if (s.Length > nRight) && (s[left] = s[nRight]) then
                defineCenter s (left, nRight)
            else
                (left, right)

        let rec expandFromCenter (s: string) (left: int, right: int) =
            let eLeft = left - 1
            let eRight = right + 1

            if (eLeft > - 1)
               && (eRight < s.Length)
               && (s[eLeft] = s[eRight]) then
                expandFromCenter s (eLeft, eRight)
            else
                left, right

        let rec traverse (acc: string) s left right =
            let (nLeft, nRight) =
                (left, right)
                |> (defineCenter s)
                |> (expandFromCenter s)

            let nLength = nRight - nLeft + 1

            let newAcc =
                if (nLength > acc.Length) then
                    s[nLeft..nRight]
                else
                    acc

            if ((nRight + 1) < s.Length) then
                let next = nRight + 1
                traverse newAcc s next next
            else
                newAcc

        match str with
        | None -> None
        | Some s when s = "" -> None
        | Some s -> Some(traverse "" s 0 0)

module LongestPalindromicSubstringTest =
    open NUnit.Framework
    open FsUnit

    let testCaseData =
        [ TestCaseData(Some "babad", Some "bab")
          TestCaseData(Some "cbbd", Some "bb")
          TestCaseData(Some "", None) ]

    [<TestCaseSource("testCaseData")>]
    let ``palindromes should return longest palindrome1 substring`` (input: string option) (expected: string option) =
        let actual = LongestPalindromicSubstring1.longestPalindrome input
        should equal expected actual

    [<TestCaseSource("testCaseData")>]
    let ``palindromes should return longest palindrome substring`` (input: string option) (expected: string option) =
        let actual = LongestPalindromicSubstring2.longestPalindrome input
        should equal expected actual
