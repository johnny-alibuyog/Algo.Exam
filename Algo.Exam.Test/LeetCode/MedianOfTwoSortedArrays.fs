namespace Algo.Exam.Test.LeetCode

module MedianOfTwoSortedArrays =
    // combine the two list and sort
    // compute for the median
    //   - if list.length is divisible by 2
    //      -> get the two medians and compute
    //   - else
    //      -> get the middle index

    let median list1 list2 =
        (list1 @ list2)
        |> List.sort
        |> (fun list ->
            let length = list.Length
            let mid = length / 2

            match (length % 2 = 0) with
            | true ->
                let (mid1, mid2) = (mid - 1, mid)
                (float list.[mid1] + float list[mid2]) / 2.0
            | false -> float list[mid])

module MedianOfTwoSortedArraysTest =
    open FsUnit
    open NUnit.Framework
    open MedianOfTwoSortedArrays

    let testCaseData =
        [ TestCaseData([ 1; 3 ], [ 2 ], 2.0)
          TestCaseData([ 1; 2 ], [ 3; 4 ], 2.5) ]

    [<TestCaseSource("testCaseData")>]
    let ``can get median`` list1 list2 expected =
        let actual = median list1 list2
        actual |> should equal expected
