namespace Algo.Exam.LeetCode

module LongestSubstringWithoutRepeatingCharacters =
    // 1. use list of set to accumulate result
    // 2. iterate throuth the string
    // 3. generate accumulation folder
    //    - when accumulation is empty, create new set and add curr to it
    //    - when first accumulation's set contains curr string, create another and add it to accumulation list
    // 4. select the set with most elements and return


    let getLongsetSubstring str =
        let init: Set<char> list = List.empty

        let folder acc curr =
            match acc with
            | [] -> acc |> List.insertAt 0 (Set.ofList [ curr ])
            | x :: xs ->
                if (x.Contains curr) then
                    acc |> List.insertAt 0 (Set.ofList [ curr ])
                else
                    xs |> List.insertAt 0 (x.Add curr)

        let count (set: Set<char>) = set.Count

        let map (set: Set<char>) = (set.Count,  set |> Set.map string |> String.concat "")

        str
        |> Seq.map char
        |> Seq.fold folder init
        |> Seq.maxBy count
        |> map

    //let init = (false, Set.empty, 0)

    //let folder (acc: (bool * Set<string> * int)) (curr: string) =
    //    let (duplicate, prev, count) = acc

    //    if (duplicate) then
    //        (duplicate, prev, count)
    //    else if (prev.Contains curr) then
    //        (true, prev, count)
    //    else
    //        (duplicate, (prev.Add curr), count + 1)

    //str |> Seq.map string |> Seq.fold folder init

    module Test =
        let run () =
            let input = "pwwkew"
            //let input = "bbbbb"
            //let input = "abcabcbb"
            getLongsetSubstring input |> printfn "%A"
