// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let rec merge lst1 lst2 =
    match lst1, lst2 with
    | (x::xt),(y::yt) -> if x < y then x :: (merge xt lst2) else y :: (merge lst1 yt)
    | [] , ylst -> ylst
    | xlst , []  -> xlst
let test1 = printf "%A" <| merge [1;3;5;12] [2;3;4;7]

let test2 = printf "%A" <| merge [1;3;12;12] [2;3;4;7]

