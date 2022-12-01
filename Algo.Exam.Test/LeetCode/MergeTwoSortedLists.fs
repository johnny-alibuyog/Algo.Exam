namespace Algo.Exam.Test.LeetCode

module MergeTwoSortedLists =
    type LinkedList =
        | Empty
        | Node of value: int * next: LinkedList

    module LinkedList =
        let isEmpty node =
            match node with
            | Empty -> true
            | _ -> false

        let next node =
            match node with
            | Empty -> Empty
            | Node (_, next) -> next

        let value node =
            match node with
            | Node (value, _) -> value
            | Empty -> 0

        let rec append node2 node1 =
            match node1, node2 with
            | Empty, Empty -> Empty
            | Empty, Node (v2, _) -> Node(v2, Empty)
            | Node (_, _), Empty -> node1
            | Node (v1, n1), Node (_, _) -> Node(v1, append node2 n1)

    let merge l1 l2 =
        let rec traverse acc l1 l2 =
            match l1, l2 with
            | Empty, Empty -> acc
            | Empty, _ -> traverse (acc |> LinkedList.append l2) Empty (l2 |> LinkedList.next)
            | _, Empty -> traverse (acc |> LinkedList.append l1) (l1 |> LinkedList.next) Empty
            | _ ->
                if (l1 |> LinkedList.value) < (l2 |> LinkedList.value) then
                    traverse (acc |> LinkedList.append l1) (l1 |> LinkedList.next) l2
                else
                    traverse (acc |> LinkedList.append l2) l1 (l2 |> LinkedList.next)

        traverse Empty l1 l2

module MergetTwoSortedListsTest =
    open FsUnit
    open NUnit.Framework
    open MergeTwoSortedLists

    let testCaseData =
        [ TestCaseData(
              Node(1, Node(2, Node(4, Empty))),
              Node(1, Node(3, Node(4, Empty))),
              Node(1, Node(1, Node(2, Node(3, Node(4, Node(4, Empty))))))
          )
          TestCaseData(
              Node(1, Node(2, Node(4, Empty))),
              Node(1, Node(3, Node(4, Empty))),
              Node(1, Node(1, Node(2, Node(3, Node(4, Node(4, Empty))))))
          )
          TestCaseData(
              arg1 = Node(1, Node(2, Node(4, Empty))),
              arg2 = Node(1, Node(3, Node(4, Empty))),
              arg3 = Node(1, Node(1, Node(2, Node(3, Node(4, Node(4, Empty))))))
          )
          TestCaseData(
              Node(1, Node(2, Node(4, Empty))),
              Node(1, Node(3, Node(4, Empty))),
              Node(1, Node(1, Node(2, Node(3, Node(4, Node(4, Empty))))))
          )
          TestCaseData(
              Node(1, Node(2, Node(4, Empty))),
              Node(1, Node(3, Node(4, Empty))),
              Node(1, Node(1, Node(2, Node(3, Node(4, Node(4, Empty))))))
          )
          TestCaseData(
              Node(1, Node(2, Node(4, Empty))),
              Node(1, Node(3, Node(4, Empty))),
              Node(1, Node(1, Node(2, Node(3, Node(4, Node(4, Empty))))))
          )
          TestCaseData(
              Node(1, Node(2, Node(4, Empty))),
              Node(1, Node(3, Node(4, Empty))),
              Node(1, Node(1, Node(2, Node(3, Node(4, Node(4, Empty))))))
          )
          TestCaseData(
              Node(1, Node(2, Node(4, Empty))),
              Node(1, Node(3, Node(4, Empty))),
              Node(1, Node(1, Node(2, Node(3, Node(4, Node(4,Empty))))))
          ) ]

    [<TestCaseSource("testCaseData")>]
    let ``merge should be able to merge sordted list`` (l1: LinkedList) (l2: LinkedList) (expected: LinkedList) =
        let actual = merge l1 l2
        should equal expected actual
