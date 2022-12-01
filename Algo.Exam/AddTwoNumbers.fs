namespace Algo.Exam
// https://leetcode.com/problems/add-two-numbers/

type LinkedList =
    | Node of int * LinkedList
    | Empty

module LinkedList =
    let toInt list =
        let rec traverse current =
            match current with
            | Node (value, next) -> $"{traverse next}{value}"
            | Empty -> ""

        list |> traverse |> int

    let toList (num: int) =
        let rec traverse chars1 =
            match chars1 with
            | x :: [] -> Node(int (string x), Empty)
            | x :: xs -> Node(int (string x), traverse xs)
            | _ -> Empty

        let chars = num |> string |> seq |> Seq.rev |> List.ofSeq
        traverse chars

module AddTwoNumbers =
    // convert list1 to numbers
    // convert list2 to numbers
    // add list1 to list2
    // reverse answer

    let run list1 list2 =
        let num1 = LinkedList.toInt list1
        let num2 = LinkedList.toInt list2
        let sum = num1 + num2
        LinkedList.toList sum

    let test () =
        let list1 = Node(2, Node(4, Node(3, Empty)))
        let list2 = Node(5, Node(6, Node(4, Empty)))
        run list1 list2 |> printfn "%A"

        let list1' = LinkedList.toList 9999999
        let list2' = LinkedList.toList 9999
        run list1' list2' |> printfn "%A"

        run (Node(2, Node(4, Node(3, Empty)))) (Node(5, Node(6, Node(4, Empty))))
        |> printfn "%A"
