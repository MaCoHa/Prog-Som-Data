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
    
test "fmt a1" (fmt a1) "(v - (w + z))"
test "fmt a2" (fmt a2) "(2 * (v - (w + z)))"
test "fmt a3" (fmt a3) "(x + (y + (z + v)))"

test "simplify add 0 left"  (simplify <| Add(CstI 0, Var "x")) (Var "x")
test "simplify add 0 right" (simplify <| Add(Var "x", CstI 0)) (Var "x")
test "simplify add 0 both"  (simplify <| Add(CstI 0, CstI 0)) (CstI 0)
test "simplify add cons"    (simplify <| Add(CstI 4, CstI 9)) (CstI 13)
test "simplify add vars"    (simplify <| Add(CstI 4, Var "x")) (Add(CstI 4, Var "x"))

test "simplify sub 0 left"  (simplify <| Sub(CstI 0, Var "x")) (Sub(CstI 0, Var "x"))
test "simplify sub 0 right" (simplify <| Sub(Var "x", CstI 0)) (Var "x")
test "simplify sub eq vars" (simplify <| Sub(CstI 0, CstI 0)) (CstI 0)
test "simplify sub 2 cons"  (simplify <| Sub(Var "x", Var "x")) (CstI 0)
test "simplify sub cons"    (simplify <| Sub(CstI 4, CstI 9)) (CstI -5)
test "simplify sub vars"    (simplify <| Sub(CstI 4, Var "x")) (Sub(CstI 4, Var "x"))

test "simplify mul 1 left"  (simplify <| Mul(CstI 1, Var "x")) (Var "x")
test "simplify mul 1 right" (simplify <| Mul(Var "x", CstI 1)) (Var "x")
test "simplify mul 1 both"  (simplify <| Mul(CstI 1, CstI 1)) (CstI 1)
test "simplify mul 0 1"     (simplify <| Mul(CstI 0, CstI 1)) (CstI 0)
test "simplify mul cons"    (simplify <| Mul(CstI 4, CstI 9)) (CstI 36)
test "simplify mul vars"    (simplify <| Mul(CstI 4, Var "x")) (Mul(CstI 4, Var "x"))






