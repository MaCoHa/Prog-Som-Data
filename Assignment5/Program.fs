//test script
let printSuccess = true
let test case actual expected =
    if actual = expected
    then
        if printSuccess
        then printfn "SUCCESS: '%A' evaluates to '%A'" case actual
    else printfn "FAILURE: '%A' should be '%A' but was '%A'" case expected actual


//exe5.1A
let rec merge lst1 lst2 =
    match lst1, lst2 with
    | (x::xt),(y::yt) -> if x < y then x :: (merge xt lst2) else y :: (merge lst1 yt)
    | [] , ylst -> ylst
    | xlst , []  -> xlst
    
test "test1" (merge [1;3;5;12] [2;3;4;7]) [1;2;3;3;4;5;7;12]
test "test2" (merge [1;3;12;12] [2;3;4;7]) [1;2;3;3;4;7;12;12]

