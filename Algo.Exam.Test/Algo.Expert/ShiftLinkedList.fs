namespace Algo.Exam.Algo.Expert

// https://www.algoexpert.io/questions/shift-linked-list
module ShiftLinkedList =
    type LinkedList =
        | Empty
        | Node of value: int * next: LinkedList

    module LinkedList =
        let isLast node =
            match node with
            | Node (_, next) when next = Empty -> true
            | _ -> false

        let isEmpty node =
            match node with
            | Empty -> true
            | _ -> false

        let getValue node =
            match node with
            | Node (value, _) -> value
            | Empty -> 0

    let shift head k =

        let rec traverse current index =
            match current with
            | Empty -> Empty, Empty
            | Node (value, next) ->
                if (LinkedList.isLast next) then
                    Node((value), Empty), next
                else
                    let (acc, last) = traverse next (index + 1)

                    if (index = 0) then
                        Node(LinkedList.getValue last, Node(value, acc)), last
                    else
                        Node(value, acc), last

        [ 1..k ]
        |> List.fold (fun acc _ -> traverse acc 0 |> fst) head


[<NUnit.Framework.TestFixture>]
module ShiftLinkedListTest =
    open FsUnit
    open NUnit.Framework
    open ShiftLinkedList

    let testCaseData =
        [ TestCaseData(
              Node(0, Node(1, Node(2, Node(3, Node(4, Node(5, Empty)))))),
              2,
              Node(4, Node(5, Node(0, Node(1, Node(2, Node(3, Empty))))))
          ) ]

    [<TestCaseSource("testCaseData")>]
    let ``shift should shift tail to head k times`` input k expected =
        let actual = shift input k
        should equal expected actual
