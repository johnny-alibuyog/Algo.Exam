namespace Algo.Exam

module Some =
    let f x y = x + y

//type LinkedList =
//    | Node of value: int * next: LinkedList
//    | Empty

//module LinkedList =
//    let isEmpty ll =
//        match ll with
//        | Empty -> true
//        | _ -> false

//    let isTailTip ll =
//        match ll with
//        | Node (_, next) when isEmpty next -> true
//        | _ -> false

//    let getValue ll =
//        match ll with
//        | Node (value, _) -> value
//        | _ -> 0

//    let getNext ll =
//        match ll with
//        | Node (_, next) -> next
//        | Empty -> Empty

//    let rec iter ll =
//        seq {
//            let next = getNext ll
//            if not (isEmpty ll) then yield ll

//            if not (isEmpty next) then
//                yield! iter next
//        }

//    let makeTailHeadOf head next = Node((getValue head), next)

//    let makeTailHead state =
//        // traverse node to tip of the tail
//        // set 'next' to Empty for node before the tip end
//        // return body and end tip in tupple
//        let rec traverse cur tip =
//            match cur with
//            | Node (value, next) ->
//                let acc =
//                    if isTailTip next then
//                        traverse Empty next
//                    else
//                        traverse next Empty
//                //let node, _ = traverse next
//                //node
//                //let tip =
//                //    if isTailTip next then
//                //        next
//                //    else
//                //        Empty
//                let (child, _) = acc
//                (Node(value, child)), tip

//            | Empty -> Empty, Empty

//        let (body, tip) = traverse state Empty

//        Node((getValue tip), body)

//    //let child =
//    //    if (isTailTip next) then
//    //        Empty
//    //    else
//    //        traverse next

//    //if (isEmpty child)

//    //Node (value, chid)
//    //| Empty -> Empty

//    //cur, next
//    //    let next = getNext cur

//    //    if isTailTip next then
//    //        cur, Node((getValue next), Empty)
//    //    else
//    //        (traverse next)

//    //let (body, tip) = traverse state

//    //Node((getValue tip), body)

//    let makeHeadTail state =
//        // separate then 'head' from the 'next'
//        // empty the 'next' of the head
//        // traverse to the last of the 'next'
//        // set the 'next' of the last the 'head'
//        let next = getNext state
//        let head = Node((getValue state), Empty)

//        let rec traverse current =
//            match current with
//            | Node (value, next) ->
//                let child =
//                    if (isEmpty next) then
//                        Node(value, head)
//                    else
//                        traverse next

//                Node(value, child)

//            | Empty -> current

//        traverse next

//    let updateNextOf target targetNextValue cur =
//        let rec traverse previous next =
//            match next with
//            | Node _ ->
//                let next1 =
//                    match previous, target with
//                    | p, t when p = t -> targetNextValue
//                    | _ -> traverse next (getNext next)

//                Node((getValue previous), next1)
//            | Empty -> next

//        traverse cur (getNext cur)

//    //let updateNextOf parentVal newChildVal cur =
//    //    cur
//    //    |> iter
//    //    |> Seq.rev
//    //    |> Seq.reduce (fun child parent ->
//    //        if parent = parentVal then
//    //            Node((getValue parent), newChildVal)
//    //        else
//    //            Node(getValue parent, child))

//    let rec getPrev next cur =
//        match cur with
//        | Node (_, n) when n = next -> cur
//        | Node (_, n) -> getPrev next n
//        | Empty -> cur


//    let rec shift k acc =
//        // 1. traverse to last
//        // 2. get the last
//        // 3. set the 'next' of item before the last to Empty
//        // 4. get the head
//        // 5. make the tail the head (tail.next = head)
//        // 6. if k not 0 recurse (k - 1) else stop

//        //let cc =
//        match k with
//        | v when v > 0 -> acc |> makeTailHead |> shift (k - 1)
//        | v when v < 0 -> acc |> makeHeadTail |> shift (k + 1)
//        | _ -> acc


////let next k =
////    if (k < 0) then k + 1
////    else if (k > 0) then k - 1
////    else 0

////if (k = 0) then
////    acc
////else
////    let last = acc |> iter |> Seq.last
////    let prev = acc |> getPrev last

////    let newAcc =
////        acc
////        |> updateNextOf prev Empty
////        |> makeTailHeadOf last

////    shift (next k) newAcc


//module LinkedListTest =
//    let data = Node(1, Node(2, Node(3, Node(4, Node(5, Empty)))))

//    let run () =
//        data
//        |> LinkedList.shift 2
//        |> LinkedList.iter
//        |> Seq.iter (fun x -> printf $"{LinkedList.getValue x}")
