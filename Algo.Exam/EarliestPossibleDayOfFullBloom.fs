// https://leetcode.com/problems/earliest-possible-day-of-full-bloom/

namespace Algo.Exam

module EarliestPossibleDayOfFullBloom2 =
    type Seed =
        { waitTime: int
          plantTime: int
          growTime: int
          bloomTime: int }

    module Seed =
        let create waitTime plantTime growTime =
            { waitTime = waitTime
              plantTime = plantTime
              growTime = growTime
              bloomTime = waitTime + plantTime + growTime }

        let waitTime acc =
            acc
            |> List.tryHead
            |> function
                | Some x -> x.waitTime + x.plantTime
                | None -> 0

        let bloomTime seed = seed.bloomTime

    let farm (plantTimes: int list) (growTimes: int list) =
        let log x =
            x |> printfn "%A"
            x

        let logfx x =
            let wt seed = String.replicate seed.waitTime "_"
            let pt seed = String.replicate seed.plantTime "p"
            let gt seed = String.replicate seed.growTime "g"
            let bt seed = String.replicate 1 "b"
            let p seed = $"{wt seed}{pt seed}{gt seed}{bt seed}"
            x |> List.iter (fun i -> printfn $"{p i}")
            x

        let toTupples (list1: int list) (list2: int list) =
            [ 0 .. (List.length list1 - 1) ]
            |> List.map (fun i -> (list1[i], list2[i]))

        toTupples plantTimes growTimes
        |> log
        //|> List.sortByDescending (fun (pt, _) -> pt)
        //|> List.sortByDescending (fun (pt, gt) -> gt - pt)
        //|> List.sortBy (fun (pt, gt) -> pt + gt)
        |> List.sortByDescending (fun (_, gt) -> gt)
        //|> List.sortBy (fun (pt, gt) -> pt + gt)
        //|> List.sortByDescending (fun (_, gt) -> gt)
        |> List.fold
            (fun acc cur ->
                let wt = acc |> Seed.waitTime
                let (pt, gt) = cur
                acc |> List.insertAt 0 (Seed.create wt pt gt))
            []
        |> logfx
        |> List.maxBy Seed.bloomTime

    module Test =
        let run () =
            farm [ 1; 4; 3 ] [ 2; 3; 1 ] |> printf "%A"
//   [ 6674
//     4297
//     5471
//     8794
//     4363
//     1258
//     7560
//     2448
//     3181
//     7857
//     5603
//     2628
//     2451
//     469
//     2453
//     3908
//     2122
//     5887
//     3968
//     5274
//     5935
//     7404
//     745
//     6954
//     6188
//     8810
//     5510
//     2863
//     5924
//     8018
//     8426
//     1328
//     4409
//     3938
//     5224
//     6823
//     8522
//     8417
//     6014
//     7360
//     7450
//     8211
//     5193
//     2728
//     3948
//     1049
//     594
//     7207
//     7931
//     5538
//     3968
//     8519
//     2010
//     209
//     5914
//     5384
//     8842
//     3433
//     1057
//     6826
//     7695
//     7969
//     7213
//     913
//     797
//     252
//     7608
//     1672
//     8555
//     7669
//     1672
//     3759
//     4804
//     2736
//     3962
//     1107
//     7743
//     7137
//     3292
//     1990
//     7896
//     6506
//     7089
//     1414
//     6287
//     6650
//     3759
//     5188
//     3079
//     3336
//     3336
//     7223
//     1389
//     7567
//     5819
//     8207
//     6837
//     6680
//     8391
//     3160
//     5569
//     6004
//     5377
//     8796
//     7769
//     8881
//     618
//     7500
//     1891
//     2048
//     2025
//     8962
//     8167
//     6861
//     6449
//     56
//     6281
//     8290
//     7432
//     6294
//     4246
//     5193
//     5936
//     3096
//     5136
//     8019
//     1770
//     172
//     1038
//     2986
//     5170
//     2062
//     7248
//     228
//     7689
//     549
//     8379
//     2259
//     492
//     8299
//     8210
//     3423
//     4405
//     4274
//     2896
//     583
//     8899
//     2817
//     7102
//     8608
//     7014
//     8534
//     891
//     8420
//     5769
//     8926
//     2837
//     2882
//     7216
//     8427
//     4416
//     5063
//     6179
//     1353
//     171
//     8972
//     779
//     5287
//     4402
//     5627
//     5389
//     6200
//     3576
//     7320
//     7565 ]

//   [ 6155
//     6180
//     2575
//     6632
//     3786
//     1490
//     5054
//     114
//     6888
//     8927
//     3686
//     7352
//     1182
//     2039
//     784
//     2882
//     545
//     359
//     2187
//     8589
//     7653
//     8520
//     2264
//     6397
//     7752
//     7811
//     3552
//     2267
//     1136
//     4367
//     8397
//     2574
//     4792
//     1411
//     3606
//     7538
//     1120
//     3707
//     4071
//     7266
//     8390
//     3923
//     6674
//     1852
//     7256
//     3778
//     2590
//     1288
//     8446
//     6074
//     1948
//     5643
//     3401
//     3290
//     8132
//     2168
//     6802
//     319
//     3201
//     7981
//     8624
//     8660
//     2515
//     8884
//     777
//     1263
//     8688
//     6110
//     7376
//     4554
//     2039
//     963
//     4996
//     5830
//     3858
//     1182
//     2435
//     2131
//     6709
//     2875
//     420
//     2061
//     6138
//     5490
//     7100
//     7417
//     7814
//     7479
//     862
//     3672
//     4781
//     3279
//     6608
//     2492
//     6210
//     7413
//     6057
//     631
//     2547
//     1790
//     7575
//     249
//     870
//     1364
//     4407
//     6025
//     4027
//     8185
//     6169
//     8577
//     7200
//     7767
//     4750
//     840
//     1944
//     4312
//     2261
//     6644
//     6651
//     4477
//     3846
//     7228
//     8448
//     3778
//     6472
//     1790
//     2931
//     556
//     8185
//     1196
//     4974
//     2950
//     3565
//     6500
//     2073
//     7496
//     4362
//     1658
//     8075
//     1426
//     4911
//     2207
//     8936
//     2152
//     5595
//     3822
//     3019
//     5651
//     3950
//     878
//     2161
//     5964
//     980
//     6691
//     4967
//     7937
//     7530
//     6616
//     4304
//     4976
//     294
//     8401
//     3725
//     137
//     8507
//     6817
//     4153
//     1507
//     4305
//     441
//     6076
//     1472
//     1711
//     765
//     7137 ]
//|> printfn "%A"


module EarliestPossibleDayOfFullBloom =

    type Seed =
        { mutable plantTime: int
          mutable growTime: int
          mutable bloomed: bool
          mutable acc: string }

    type Farm =
        { mutable day: int
          mutable planted: int
          mutable grew: int
          mutable bloomed: int
          seeds: Seed list }

    module Seed =
        let create plantTime growTime =
            { plantTime = plantTime
              growTime = growTime
              bloomed = false
              acc = "" }

        let forPlanting seed = seed.plantTime > 0

        let forGrowing seed = seed.plantTime = 0 && seed.growTime > 0

        let forBloom seed =
            seed.plantTime = 0
            && seed.growTime = 0
            && not seed.bloomed

        let bloomTime seed = seed.plantTime + seed.growTime + 1

        let growTime seed = seed.growTime

        let plantTime seed = seed.plantTime

    module Farm =
        let day farm = farm.day

        let init (plantTimes: int list) (growTimes: int list) =
            if (plantTimes.Length <> growTimes.Length) then
                failwith $"plantTimes: {plantTimes.Length} growTimes: {growTimes.Length}"

            let seeds =
                plantTimes
                |> List.mapi (fun i _ -> Seed.create plantTimes[i] growTimes[i])
                |> List.sortBy Seed.plantTime
                |> List.sortByDescending Seed.growTime

            { day = 0
              planted = 0
              grew = 0
              bloomed = 0
              seeds = seeds }

        let canPlant state =
            state.planted = 0 (* can plant 1 seed per day *)

        let isHarvestTime state =
            state.bloomed >= List.length state.seeds

        let callItADay state =
            { state with
                day = state.day + 1
                planted = 0 }

        let startADay state =
            state.seeds
            |> List.iter (fun seed ->
                if (canPlant state) && (Seed.forPlanting seed) then
                    seed.acc <- $"{seed.acc}p"
                    seed.plantTime <- seed.plantTime - 1
                    state.planted <- state.planted + 1
                else if (Seed.forGrowing seed) then
                    seed.acc <- $"{seed.acc}g"
                    seed.growTime <- seed.growTime - 1
                    state.grew <- state.grew + 1
                else if (Seed.forBloom seed) then
                    seed.acc <- $"{seed.acc}b"
                    seed.bloomed <- true
                    state.bloomed <- state.bloomed + 1
                else
                    seed.acc <- $"{seed.acc}_")

            state

        let rec farm state =
            state
            |> startADay
            |> function
                | acc when isHarvestTime acc -> acc
                | acc -> acc |> callItADay |> farm

    module Test =
        let earliestFullBloom plantTimes growTimes =
            (plantTimes, growTimes)
            ||> Farm.init
            |> Farm.farm
            |> Farm.day

        let run () =
            //earliestFullBloom ([ 4; 3 ]) ([ 1; 2 ])
            earliestFullBloom [ 6674
                                4297
                                5471
                                8794
                                4363
                                1258
                                7560
                                2448
                                3181
                                7857
                                5603
                                2628
                                2451
                                469
                                2453
                                3908
                                2122
                                5887
                                3968
                                5274
                                5935
                                7404
                                745
                                6954
                                6188
                                8810
                                5510
                                2863
                                5924
                                8018
                                8426
                                1328
                                4409
                                3938
                                5224
                                6823
                                8522
                                8417
                                6014
                                7360
                                7450
                                8211
                                5193
                                2728
                                3948
                                1049
                                594
                                7207
                                7931
                                5538
                                3968
                                8519
                                2010
                                209
                                5914
                                5384
                                8842
                                3433
                                1057
                                6826
                                7695
                                7969
                                7213
                                913
                                797
                                252
                                7608
                                1672
                                8555
                                7669
                                1672
                                3759
                                4804
                                2736
                                3962
                                1107
                                7743
                                7137
                                3292
                                1990
                                7896
                                6506
                                7089
                                1414
                                6287
                                6650
                                3759
                                5188
                                3079
                                3336
                                3336
                                7223
                                1389
                                7567
                                5819
                                8207
                                6837
                                6680
                                8391
                                3160
                                5569
                                6004
                                5377
                                8796
                                7769
                                8881
                                618
                                7500
                                1891
                                2048
                                2025
                                8962
                                8167
                                6861
                                6449
                                56
                                6281
                                8290
                                7432
                                6294
                                4246
                                5193
                                5936
                                3096
                                5136
                                8019
                                1770
                                172
                                1038
                                2986
                                5170
                                2062
                                7248
                                228
                                7689
                                549
                                8379
                                2259
                                492
                                8299
                                8210
                                3423
                                4405
                                4274
                                2896
                                583
                                8899
                                2817
                                7102
                                8608
                                7014
                                8534
                                891
                                8420
                                5769
                                8926
                                2837
                                2882
                                7216
                                8427
                                4416
                                5063
                                6179
                                1353
                                171
                                8972
                                779
                                5287
                                4402
                                5627
                                5389
                                6200
                                3576
                                7320
                                7565 ] [
                6155
                6180
                2575
                6632
                3786
                1490
                5054
                114
                6888
                8927
                3686
                7352
                1182
                2039
                784
                2882
                545
                359
                2187
                8589
                7653
                8520
                2264
                6397
                7752
                7811
                3552
                2267
                1136
                4367
                8397
                2574
                4792
                1411
                3606
                7538
                1120
                3707
                4071
                7266
                8390
                3923
                6674
                1852
                7256
                3778
                2590
                1288
                8446
                6074
                1948
                5643
                3401
                3290
                8132
                2168
                6802
                319
                3201
                7981
                8624
                8660
                2515
                8884
                777
                1263
                8688
                6110
                7376
                4554
                2039
                963
                4996
                5830
                3858
                1182
                2435
                2131
                6709
                2875
                420
                2061
                6138
                5490
                7100
                7417
                7814
                7479
                862
                3672
                4781
                3279
                6608
                2492
                6210
                7413
                6057
                631
                2547
                1790
                7575
                249
                870
                1364
                4407
                6025
                4027
                8185
                6169
                8577
                7200
                7767
                4750
                840
                1944
                4312
                2261
                6644
                6651
                4477
                3846
                7228
                8448
                3778
                6472
                1790
                2931
                556
                8185
                1196
                4974
                2950
                3565
                6500
                2073
                7496
                4362
                1658
                8075
                1426
                4911
                2207
                8936
                2152
                5595
                3822
                3019
                5651
                3950
                878
                2161
                5964
                980
                6691
                4967
                7937
                7530
                6616
                4304
                4976
                294
                8401
                3725
                137
                8507
                6817
                4153
                1507
                4305
                441
                6076
                1472
                1711
                765
                7137
            ]
            |> printfn "%A"

            ()
