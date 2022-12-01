namespace Algo.Exam.Test.LeetCode

module ValidParentheses =
    let validate str =
        let pair = [ '(', ')'; '[', ']'; '{', '}' ] |> Map.ofList

        let rec isPalindrome (list1, list2) =
            let o = list1 |> List.head
            let c = list2 |> List.last

            let matched =
                match pair |> Map.tryFind o with
                | Some v -> v = c
                | None -> false

            let length = list1 |> List.tail |> List.length

            match matched, length with
            | true, 0 -> true
            | true, _ -> isPalindrome (list1 |> List.tail, list2 |> List.take length)
            | _ -> false

        let rec traverse acc curr =
            match acc, curr with
            | [], [] -> true
            | [], _ -> false
            | _, [] -> false
            | a, b when a.Length > b.Length -> false
            | _ ->
                if isPalindrome (acc, curr |> List.take acc.Length) then
                    let (nextAcc, nextCurr) =
                        curr
                        |> List.skip acc.Length
                        |> function
                            | [] -> [], []
                            | x :: [] -> [ x ], []
                            | x :: xs -> [ x ], xs

                    traverse nextAcc nextCurr

                else
                    let (nextAcc, nextCurr) = (acc @ [ curr |> List.head ]), (curr |> List.tail)
                    traverse nextAcc nextCurr

        let charList = str |> Seq.toList

        if (charList |> List.length) % 2 = 0 then
            traverse ([ List.head charList ]) (List.tail charList)
        else
            false

module ValidParenthesesTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData("()", true)
          TestCaseData("()[]{}", true)
          TestCaseData("{(]", false)
          TestCaseData("{}]", false)
          TestCaseData("(]", false)
          TestCaseData("([)]", false)
          TestCaseData("{[]}", true) ]

    [<TestCaseSource("testCaseData")>]
    let ``validate should return true if string is valid`` input expected =
        let actual = ValidParentheses.validate input
        should equal expected actual
