namespace Algo.Exam.LeetCode

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
            num
            |> string
            |> Seq.map string
            |> Seq.map int
            |> Seq.fold folder Empty

        let add list1 list2 =
            let (num1, num2) = (list1 |> toNumber, list2 |> toNumber)
            let result = num1 + num2
            result |> toLinkedList

    module Test =
        let run () =
            let list1 = Node(2, Node(4, Node(3, Empty)))
            let list2 = Node(5, Node(6, Node(4, Empty)))

            let result = LinkedList.add list1 list2

            result |> printfn "%A"
