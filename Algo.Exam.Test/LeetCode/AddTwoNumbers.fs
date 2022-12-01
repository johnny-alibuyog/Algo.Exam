namespace Algo.Exam.Test.LeetCode

module AddTwoNumbers =

    type LinkedList =
        | Node of int * LinkedList
        | Empty

    module LinkedList =
        // 1. convert the two linked list as reversed number
        //      - traverse accumulate on a reverse string
        //      - convert it to number
        // 2. add the two numbers
        // 3. convert the result into a new reversed linked
        let toNumber list =
            let rec traverse acc curr =
                match curr with
                | Node (value, next) -> traverse $"{value}{acc}" next
                | Empty -> acc

            list |> traverse "" |> int

        let toLinkedList num =
            let folder acc curr = Node(curr, acc)

            let log x = printfn "%A" x; x

            num
            |> string
            |> Seq.toList
            |> Seq.map (string >> int)
            |> Seq.fold folder Empty

        let add (list1: LinkedList) (list2: LinkedList) =
            let (num1, num2) = (list1 |> toNumber, list2 |> toNumber)
            let result = num1 + num2
            result |> toLinkedList

module AddTwoNumbersTest =
    open FsUnit
    open AddTwoNumbers
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData(
              Node(2, Node(4, Node(3, Empty))),
              Node(5, Node(6, Node(4, Empty))),
              Node(7, Node(0, Node(8, Empty)))
          )
          TestCaseData(Node(0, Empty), Node(0, Empty), Node(0, Empty))
          TestCaseData(
              Node(9, Node(9, Node(9, Node(9, Node(9, Node(9, Node(9, Empty))))))),
              Node(9, Node(9, Node(9, Node(9, Empty)))),
              Node(8, Node(9, Node(9, Node(9, Node(0, Node(0, Node(0, Node(1, Empty))))))))
          ) ]

    [<TestCaseSource("testCaseData")>]
    //[<TestCase(Node(2, Node(4, Node(3, Empty))), Node(5, Node(6, Node(4, Empty))), Node(7, Node(0, Node(8, Empty))))>]
    let ``can add two LinkedList`` list1 list2 expected =
        let actual = LinkedList.add list1 list2
        should equal expected actual
