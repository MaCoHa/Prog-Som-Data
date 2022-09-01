open Intro2

let printSuccess = true

//testing function
let test case val1 val2 =
    if val1 = val2
    then
        if printSuccess
        then printfn "SUCCESS: '%A' evaluates to '%A'" case val1
    else printfn "FAILURE: '%A' has inconsistency between '%A' and '%A'" case val1 val2

test "eval e1" (eval e1 env) 17
test "eval e2" (eval e2 env) 6
test "eval e3" (eval e3 env) 1002

test "max" (eval (expr.Prim("max", expr.CstI 3, expr.CstI 5)) emptyenv) 5
test "min" (eval (expr.Prim("min", expr.CstI 3, expr.CstI 5)) emptyenv) 3
test "eqal" (eval (expr.Prim("==", expr.CstI 3, expr.CstI 5)) env) 0
test "not equal" (eval (expr.Prim("==", expr.CstI 5, expr.CstI 5)) env) 1
    





