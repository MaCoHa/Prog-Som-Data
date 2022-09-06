(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | If (e1,e2,e3)     -> if (eval e1 env) = 0 then eval e3 env else eval e2 env
    | Prim(opr, e1, e2) -> 
                            let i1 = eval e1 env
                            let i2 = eval e2 env
                            match opr with
                            |"+" -> i1 + i2
                            |"-" -> i1 - i2
                            |"*" -> i1 * i2
                            |"max" -> if i1 > i2 then i1 else i2
                            |"min" -> if i1 > i2 then i2 else i1
                            |"==" -> if i1 = i2 then 1 else 0
                            | _ -> failwith "unknown Operator";;
                            


let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;



type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Sub of aexpr * aexpr
    | Mul of aexpr * aexpr;;


let a1 = Sub (Var "v", Add (Var "w", Var "z"))
let a2 = Mul (CstI 2, Sub (Var "v", Add (Var "w", Var "z")))
let a3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))

let rec fmt a: string =
    match a with
    | CstI x -> string x
    | Var x -> x
    | Add (x, y) -> "(" + (fmt x) + " + " + (fmt y) + ")"
    | Sub (x, y) -> "(" + (fmt x) + " - " + (fmt y) + ")"
    | Mul (x, y) -> "(" + (fmt x) + " * " + (fmt y) + ")"


let rec simplify a : aexpr =
    match a with
    | CstI x -> CstI x
    | Var x -> Var x
    | Add (x, y) ->
        match simplify x, simplify y with
        | CstI x, CstI y -> CstI (x + y)
        | Var x, CstI y ->
            match x, y with
            | x, 0 -> Var x
            | x, y -> Add (Var x, CstI y)
        | CstI x, Var y ->
            match x, y with
            | 0, y -> Var y
            | x, y -> Add (CstI x, Var y)
        | x, y -> simplify (Add (x, y))
    | Sub (x, y) ->
        match simplify x, simplify y with
        | CstI x, CstI y -> CstI (x - y)
        | Var x, CstI y ->
            match x, y with
            | x, 0 -> Var x
            | x, y -> Sub (Var x, CstI y)
        | Var x, Var y when x = y -> CstI 0
        | x, y -> Sub (x, y)
    | Mul (x, y) ->
        match simplify x, simplify y with
        | CstI x, CstI y -> CstI (x * y)
        | Var x, CstI y ->
            match x, y with
            | _, 0 -> CstI 0
            | x, 1 -> Var x
            | x, y -> Mul (Var x, CstI y)
        | CstI x, Var y ->
            match x, y with
            | 0, _ -> CstI 0
            | 1, y -> Var y
            | x, y -> Mul (CstI x, Var y)
        | x, y -> simplify (Mul (x, y))


let rec differential a dx: aexpr =
    match a with
    | CstI _ -> CstI 0
    | Var x when x = dx -> CstI 1
    | Var _ -> CstI 0
    | Add (a1, a2) -> Add(differential a1 dx, differential a2 dx)
    | Sub (a1, a2) -> Sub(differential a1 dx, differential a2 dx)
    | Mul (a1, a2) -> Add(
                          Mul(differential a1 dx, a2),
                          Mul(a1, differential a2 dx)
                      )
