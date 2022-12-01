//type Seed = { 
//    plantTime: number, 
//    growTime: number,
//    bloomed: boolean,
//    acc: string
//}

//type FarmState = {
//    day: number,
//    planted: number,
//    grew: number,
//    bloomed: number
//}

//// https://leetcode.com/problems/earliest-possible-day-of-full-bloom/
//// sort byGrowTimeDesc
//// sort byPlantTime
//// sort byBloomTime



//module FarmState {
//    export const init = () : FarmState => ({ day: 0, planted: 0, grew: 0, bloomed: 0 });

//    export const canPlant = ({ planted }: FarmState) => planted == 0 ; /* can plant 1 seed per day */

//    export const isHarvestTime = (state: FarmState, seeds: Seed[]) => state.bloomed >= seeds.length;

//    export const callItADay = (state: FarmState) => {
//        state.day++;
//        state.planted = 0;
//    }
//}

//module Seed { 
//    export const create = (plantTime: number, growTime: number) : Seed => ({ plantTime: plantTime, growTime: growTime, bloomed: false, acc: "" });

//    export const forPlanting = ({ plantTime }: Seed) => plantTime > 0;
    
//    export const forGrowing = ({ plantTime, growTime }: Seed) => plantTime == 0 && growTime > 0;
    
//    export const forBloom = ({ plantTime, growTime , bloomed }: Seed) => !bloomed && plantTime == 0 && growTime == 0;

//    //export const bloomTime = ({ plantTime, growTime }: Seed) =>  plantTime + growTime + 1; 

//    //export const byBloomTime = (session1: Seed, session2: Seed) => (bloomTime(session1)) - (bloomTime(session2));

//    export const byGrowTimeDesc = (session1: Seed, session2: Seed) => session2.growTime - session1.growTime;

//    export const byPlantTime = (session1: Seed, session2: Seed) => session1.plantTime - session2.plantTime;

//    export const farm = (state: FarmState, seed: Seed) => {
//        if (FarmState.canPlant(state) && Seed.forPlanting(seed)) {
//            //seed.acc += "p";
//            seed.plantTime--;
//            state.planted++;
//        }
//        else if (Seed.forGrowing(seed)) {
//            //seed.acc += "g";
//            seed.growTime--;
//            state.grew++;
//        }
//        else if (Seed.forBloom(seed)) {
//            //seed.acc += "b";
//            seed.bloomed = true;
//            state.bloomed++;
//        }
//        else {
//            //seed.acc += "_";
//        }
//        return state;
//    }
//}

//function earliestFullBloom(plantTimes: number[], growTimes: number[]): number {
//    const seeds = plantTimes
//        .map((_, i) => Seed.create(plantTimes[i], growTimes[i]))
//        .sort(Seed.byPlantTime)
//        .sort(Seed.byGrowTimeDesc);

//    const state = FarmState.init();
    
//    while (true) {
//        seeds.reduce(Seed.farm, state)

//        if (FarmState.isHarvestTime(state, seeds)) {
//            seeds.forEach(x => console.log(x.acc));
//            break;
//        }
//        FarmState.callItADay(state);

//        if (state.day >= 10000) {
//            console.log(seeds.forEach(x => console.log(x.acc));
//            seeds.forEach(x => console.log(x.acc));
//            break;
//        }
//    }
//    return state.day;
//};

////console.log(earliestFullBloom([1,4,3], [2,3,1]));
////console.log(earliestFullBloom([1,2,3,2], [2,1,2,1]));
//console.log(earliestFullBloom(
//    [6674,4297,5471,8794,4363,1258,7560,2448,3181,7857,5603,2628,2451,469,2453,3908,2122,5887,3968,5274,5935,7404,745,6954,6188,8810,5510,2863,5924,8018,8426,1328,4409,3938,5224,6823,8522,8417,6014,7360,7450,8211,5193,2728,3948,1049,594,7207,7931,5538,3968,8519,2010,209,5914,5384,8842,3433,1057,6826,7695,7969,7213,913,797,252,7608,1672,8555,7669,1672,3759,4804,2736,3962,1107,7743,7137,3292,1990,7896,6506,7089,1414,6287,6650,3759,5188,3079,3336,3336,7223,1389,7567,5819,8207,6837,6680,8391,3160,5569,6004,5377,8796,7769,8881,618,7500,1891,2048,2025,8962,8167,6861,6449,56,6281,8290,7432,6294,4246,5193,5936,3096,5136,8019,1770,172,1038,2986,5170,2062,7248,228,7689,549,8379,2259,492,8299,8210,3423,4405,4274,2896,583,8899,2817,7102,8608,7014,8534,891,8420,5769,8926,2837,2882,7216,8427,4416,5063,6179,1353,171,8972,779,5287,4402,5627,5389,6200,3576,7320,7565],
//    [6155,6180,2575,6632,3786,1490,5054,114,6888,8927,3686,7352,1182,2039,784,2882,545,359,2187,8589,7653,8520,2264,6397,7752,7811,3552,2267,1136,4367,8397,2574,4792,1411,3606,7538,1120,3707,4071,7266,8390,3923,6674,1852,7256,3778,2590,1288,8446,6074,1948,5643,3401,3290,8132,2168,6802,319,3201,7981,8624,8660,2515,8884,777,1263,8688,6110,7376,4554,2039,963,4996,5830,3858,1182,2435,2131,6709,2875,420,2061,6138,5490,7100,7417,7814,7479,862,3672,4781,3279,6608,2492,6210,7413,6057,631,2547,1790,7575,249,870,1364,4407,6025,4027,8185,6169,8577,7200,7767,4750,840,1944,4312,2261,6644,6651,4477,3846,7228,8448,3778,6472,1790,2931,556,8185,1196,4974,2950,3565,6500,2073,7496,4362,1658,8075,1426,4911,2207,8936,2152,5595,3822,3019,5651,3950,878,2161,5964,980,6691,4967,7937,7530,6616,4304,4976,294,8401,3725,137,8507,6817,4153,1507,4305,441,6076,1472,1711,765,7137]
//));

