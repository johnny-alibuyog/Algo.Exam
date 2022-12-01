namespace Algo.Exam.Test.LeetCode

module CombinationSum =
    let findCombination candidates target =
        let rec backTrack remaining candidates index acc =
            if remaining = 0 then
                [ acc |> List.sort ]
            elif remaining < 0 then
                []
            else
                [ index .. (candidates |> List.length) - 1 ]
                |> List.collect (fun i -> backTrack (remaining - candidates[i]) candidates i (candidates[i] :: acc))

        backTrack target candidates 0 []

//if target = 0 then
//    [ acc ]
//elif target < 0 then
//    []
//else
//    candidates
//    |> List.filter (fun x -> x <= target)
//    |> List.collect (fun x -> findCombination candidates (target - x) (x :: acc))

module CombinationSumTest =
    open FsUnit
    open NUnit.Framework

    let testCaseData =
        [ TestCaseData([ 2; 3; 6; 7 ], 7, [ [ 2; 2; 3 ]; [ 7 ] ])
          TestCaseData(
              [ 2; 3; 5 ],
              8,
              [ [ 2; 2; 2; 2 ]
                [ 2; 3; 3 ]
                [ 3; 5 ] ]
          ) ]

    [<TestCaseSource("testCaseData")>]
    let ``CombinationSum.findCombination should get all combinations of candidates that sum to target``
        (candidates: int list)
        (target: int)
        (expected: int list list)
        =
        let actual = CombinationSum.findCombination candidates target
        should equal (expected |> List.sort) (actual |> List.sort)
