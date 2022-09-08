open Assignment2.Incomp1

//testing script
let printSuccess = true
let test case expected actual =
    if actual = expected
    then
        if printSuccess
        then printfn "SUCCESS: '%A' evaluates to '%A'" case actual
    else printfn "FAILURE: '%A' should be '%A' but was '%A'" case expected actual


test "scomp e1" (scomp e1 []) [SCstI 17; SVar 0; SVar 1; SAdd; SSwap; SPop]
test "scomp e2" (scomp e2 []) [SCstI 17; SCstI 22; SCstI 100; SVar 1; SMul; SSwap; SPop; SVar 1; SAdd; SSwap; SPop]
test "scomp e3" (scomp e3 []) [SCstI 5; SCstI 4; SSub; SCstI 100; SVar 1; SMul; SSwap; SPop]
test "scomp e5" (scomp e5 []) [SCstI 2; SCstI 3; SVar 0; SCstI 4; SAdd; SSwap; SPop; SMul]

test "assemble e2" (assemble (scomp e1 [])) [0; 17; 1; 0; 1; 1; 2; 6; 5]


// Exercise 2.5
intsToFile (assemble (scomp e1 [])) "is1.txt"
printfn "Created file: '%A'" "is1.txt"
// > javac Machine.java
// > java Machine is1.txt
// Result: 34
