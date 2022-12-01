namespace Algo.Exam.Test.LeetCode

module RemoveNthNodeFromEndOfList =
    type ListNode =
        | Empty
        | Node of value: int * next: ListNode

    let removeNthFromEnd (root: ListNode) (targetIndex: int) =
        let rec traverse current index =
            match current with
            | Empty -> Empty, (index + 1)
            | Node (value, next) ->
                let (child, counter) = traverse next index

                if (counter = targetIndex) then
                    child, (counter + 1)
                else
                    Node(value, child), (counter + 1)

        traverse root 0 |> fst


module RemoveNthNodeFromEndOfListTest =
    open FsUnit
    open NUnit.Framework
    open RemoveNthNodeFromEndOfList

    let testCaseData =
        [ TestCaseData(Node(1, Node(2, Node(3, Node(4, Node(5, Empty))))), 2, Node(1, Node(2, Node(3, Node(5, Empty)))))
          TestCaseData(Node(1, Empty), 1, Empty)
          TestCaseData(Node(1, Node(2, Empty)), 1, Node(1, Empty))
          TestCaseData(Node(1, Node(2, Empty)), 2, Node(2, Empty)) ]

    [<TestCaseSource("testCaseData")>]
    let ``RemoveNthFromEnd should remove the nth node from the end of the list`` input n expected =
        let actual = removeNthFromEnd input n
        should equal expected actual
