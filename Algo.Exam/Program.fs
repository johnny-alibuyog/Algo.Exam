//open Algo.Exam
open Algo.Exam.LeetCode


MedianOfTwoSortedArrays.Test.run()

//LongestSubstringWithoutRepeatingCharacters.Test.run()
//AddTwoNumbers.Test.run()
//EarliestPossibleDayOfFullBloom2.Test.run ()
//EarliestPossibleDayOfFullBloom.Test.run ()
//AddTwoNumbers.test ()
//RussianDollEnvelopes.Test.run()

////LinkedListTest.run ()

////MatrixTest.run ()

//let list = [ 5; 1; 22; 25; 6; -1; 8; 10 ]

//let sequences =
//    [ [ 1; 6; -1; 10 ]
//      [ 1; 6 ]
//      [ -1; 10 ]
//      [ 6; -1 ]
//      [ 2; -1 ] ]

////let rec isSubsequnce array' sequence' (found: Unit option) =
////    match sequence', found with
////    | head :: tail, Some () ->
////        let index = array' |> List.tryFindIndex (fun x -> x = head)

////        match index with
////        | Some index' ->
////            let nextArray = array'[index'..]
////            isSubsequnce nextArray tail (Some())
////        | None -> isSubsequnce [] [] None
////    | [], Some _ -> true
////    | _ -> false

////sequences
////|> List.map (fun sequence -> isSubsequnce list sequence (Some()))
////|> fun x -> printf $"%A{x}"

//let seq =
//    sequences
//    |> List.head
//    |> List.reduce (fun prev next -> prev + next)

//let isSubseq (list': int list) (seq: int list) =
//    list'
//    |> List.fold
//        (fun acc cur ->
//            if (acc < seq.Length && cur = seq[acc]) then
//                acc + 1
//            else
//                acc)
//        0
//    |> fun acc -> acc = seq.Length

//sequences
//|> List.map (isSubseq list)
//|> printf "%A"
