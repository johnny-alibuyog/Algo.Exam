namespace Algo.Exam.Test.LeetCode

module ContainerWithMostWater =

    let areaWithMostWater (list: int list) =
        (*
        - select middle
        - expand to around the midle
        -   compare area from previous and accumulate greater
        -   do recursion until end
        *)

        (*
        - move from outer indexs (left most and right most) towards the middle
        - compare area and accumulate greater
        *)

        let calculateArea l r =
            let height = min list[l] list[r]
            let width = r - l
            height * width

        let selectMiddle l =
            let even = (l |> List.length) % 2 = 0

            if (even) then
                let left = (l |> List.length) / 2
                let right = left + 1
                (left, right, calculateArea left right)
            else
                let mid = (l |> List.length) / 2
                let left = mid - 1
                let right = mid + 1
                (left, right, calculateArea left right)

        let rec expandFromMiddle (left, right, area) =
            let nLeft = left - 1
            let nRight = right + 1

            if (nLeft > -1 && nRight < (list.Length - 1)) then
                let nArea = calculateArea nLeft nRight
                expandFromMiddle (nLeft, nRight, max area nArea)
            else
                area

        list |> selectMiddle |> expandFromMiddle

    let areaWithMostWater2 (list: int list) =
        (*
        - move from outer indexes (left most and right most) towards the middle
        - compare area and accumulate greater
        *)

        let calculateArea l r =
            let height = min list[l] list[r]
            let width = r - l
            height * width

        let selectOuter (l: int list) =
            let left = 0
            let right = l.Length - 1
            (left, right, calculateArea left right)

        let nextRange (left: int, right: int) =
            if (list[left + 1] > list[right]) then
                left + 1, right
            else
                left, right - 1

        let rec collapseToMiddle (left, right, area) =
            let nLeft, nRight = nextRange (left, right)

            if (nLeft < nRight) then
                let nArea = calculateArea nLeft nRight
                collapseToMiddle (nLeft, nRight, max area nArea)
            else
                area

        list |> selectOuter |> collapseToMiddle

module ContainerWithMostWaterTest =
    open NUnit.Framework
    open FsUnit

    let testCaseData =
        [ TestCaseData([ 1; 8; 6; 2; 5; 4; 8; 3; 7 ], 49)
          TestCaseData([ 1; 1 ], 1) ]

    [<TestCaseSource("testCaseData")>]
    let ``should get the area with most water`` (input: int list) (expected: int) =
        let actual = ContainerWithMostWater.areaWithMostWater2 input
        should equal expected actual
