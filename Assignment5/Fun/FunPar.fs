// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | EQ
  | IMP
  | NE
  | GT
  | LT
  | GE
  | LE
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | FUN
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_IMP
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_FUN
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | EQ  -> 3 
  | IMP  -> 4 
  | NE  -> 5 
  | GT  -> 6 
  | LT  -> 7 
  | GE  -> 8 
  | LE  -> 9 
  | PLUS  -> 10 
  | MINUS  -> 11 
  | TIMES  -> 12 
  | DIV  -> 13 
  | MOD  -> 14 
  | ELSE  -> 15 
  | END  -> 16 
  | FALSE  -> 17 
  | IF  -> 18 
  | IN  -> 19 
  | LET  -> 20 
  | FUN  -> 21 
  | NOT  -> 22 
  | THEN  -> 23 
  | TRUE  -> 24 
  | CSTBOOL _ -> 25 
  | NAME _ -> 26 
  | CSTINT _ -> 27 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_EQ 
  | 4 -> TOKEN_IMP 
  | 5 -> TOKEN_NE 
  | 6 -> TOKEN_GT 
  | 7 -> TOKEN_LT 
  | 8 -> TOKEN_GE 
  | 9 -> TOKEN_LE 
  | 10 -> TOKEN_PLUS 
  | 11 -> TOKEN_MINUS 
  | 12 -> TOKEN_TIMES 
  | 13 -> TOKEN_DIV 
  | 14 -> TOKEN_MOD 
  | 15 -> TOKEN_ELSE 
  | 16 -> TOKEN_END 
  | 17 -> TOKEN_FALSE 
  | 18 -> TOKEN_IF 
  | 19 -> TOKEN_IN 
  | 20 -> TOKEN_LET 
  | 21 -> TOKEN_FUN 
  | 22 -> TOKEN_NOT 
  | 23 -> TOKEN_THEN 
  | 24 -> TOKEN_TRUE 
  | 25 -> TOKEN_CSTBOOL 
  | 26 -> TOKEN_NAME 
  | 27 -> TOKEN_CSTINT 
  | 30 -> TOKEN_end_of_input
  | 28 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_AtExpr 
    | 19 -> NONTERM_AtExpr 
    | 20 -> NONTERM_AtExpr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AppExpr 
    | 24 -> NONTERM_AppExpr 
    | 25 -> NONTERM_Const 
    | 26 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 30 
let _fsyacc_tagOfErrorTerminal = 28

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | IMP  -> "IMP" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | FUN  -> "FUN" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | IMP  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | FUN  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 22us; 65535us; 0us; 2us; 6us; 7us; 8us; 9us; 10us; 11us; 14us; 15us; 16us; 17us; 34us; 18us; 35us; 19us; 36us; 20us; 37us; 21us; 38us; 22us; 39us; 23us; 40us; 24us; 41us; 25us; 42us; 26us; 43us; 27us; 44us; 28us; 49us; 29us; 50us; 30us; 53us; 31us; 54us; 32us; 56us; 33us; 24us; 65535us; 0us; 4us; 4us; 58us; 5us; 59us; 6us; 4us; 8us; 4us; 10us; 4us; 14us; 4us; 16us; 4us; 34us; 4us; 35us; 4us; 36us; 4us; 37us; 4us; 38us; 4us; 39us; 4us; 40us; 4us; 41us; 4us; 42us; 4us; 43us; 4us; 44us; 4us; 49us; 4us; 50us; 4us; 53us; 4us; 54us; 4us; 56us; 4us; 22us; 65535us; 0us; 5us; 6us; 5us; 8us; 5us; 10us; 5us; 14us; 5us; 16us; 5us; 34us; 5us; 35us; 5us; 36us; 5us; 37us; 5us; 38us; 5us; 39us; 5us; 40us; 5us; 41us; 5us; 42us; 5us; 43us; 5us; 44us; 5us; 49us; 5us; 50us; 5us; 53us; 5us; 54us; 5us; 56us; 5us; 24us; 65535us; 0us; 45us; 4us; 45us; 5us; 45us; 6us; 45us; 8us; 45us; 10us; 45us; 14us; 45us; 16us; 45us; 34us; 45us; 35us; 45us; 36us; 45us; 37us; 45us; 38us; 45us; 39us; 45us; 40us; 45us; 41us; 45us; 42us; 45us; 43us; 45us; 44us; 45us; 49us; 45us; 50us; 45us; 53us; 45us; 54us; 45us; 56us; 45us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 26us; 51us; 74us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 12us; 1us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 1us; 2us; 2us; 23us; 2us; 3us; 24us; 1us; 4us; 12us; 4us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 4us; 12us; 4us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 4us; 12us; 4us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 5us; 1us; 5us; 1us; 5us; 12us; 5us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 6us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 17us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 20us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 20us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 21us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 21us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 22us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 2us; 20us; 21us; 2us; 20us; 21us; 1us; 20us; 1us; 20us; 1us; 20us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 24us; 1us; 25us; 1us; 26us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 17us; 19us; 22us; 25us; 27us; 40us; 42us; 55us; 57us; 70us; 72us; 74us; 76us; 89us; 91us; 104us; 117us; 130us; 143us; 156us; 169us; 182us; 195us; 208us; 221us; 234us; 247us; 260us; 273us; 286us; 299us; 312us; 314us; 316us; 318us; 320us; 322us; 324us; 326us; 328us; 330us; 332us; 334us; 336us; 338us; 341us; 344us; 346us; 348us; 350us; 352us; 354us; 356us; 358us; 360us; 362us; 364us; 366us; 368us; |]
let _fsyacc_action_rows = 62
let _fsyacc_actionTableElements = [|8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 0us; 49152us; 12us; 32768us; 0us; 3us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 0us; 16385us; 5us; 16386us; 1us; 56us; 20us; 47us; 25us; 61us; 26us; 46us; 27us; 60us; 5us; 16387us; 1us; 56us; 20us; 47us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 12us; 32768us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 23us; 8us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 12us; 32768us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 15us; 10us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 11us; 16388us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 1us; 32768us; 26us; 13us; 1us; 32768us; 4us; 14us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 9us; 16389us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 3us; 16390us; 12us; 36us; 13us; 37us; 14us; 38us; 3us; 16391us; 12us; 36us; 13us; 37us; 14us; 38us; 3us; 16392us; 12us; 36us; 13us; 37us; 14us; 38us; 0us; 16393us; 0us; 16394us; 0us; 16395us; 9us; 16396us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 9us; 16397us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 5us; 16398us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 5us; 16399us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 5us; 16400us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 5us; 16401us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 12us; 32768us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 19us; 50us; 12us; 32768us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 16us; 51us; 12us; 32768us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 19us; 54us; 12us; 32768us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 16us; 55us; 12us; 32768us; 2us; 57us; 3us; 39us; 5us; 40us; 6us; 41us; 7us; 42us; 8us; 43us; 9us; 44us; 10us; 34us; 11us; 35us; 12us; 36us; 13us; 37us; 14us; 38us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 0us; 16402us; 0us; 16403us; 1us; 32768us; 26us; 48us; 2us; 32768us; 3us; 49us; 26us; 52us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 0us; 16404us; 1us; 32768us; 3us; 53us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 0us; 16405us; 8us; 32768us; 1us; 56us; 11us; 16us; 18us; 6us; 20us; 47us; 21us; 12us; 25us; 61us; 26us; 46us; 27us; 60us; 0us; 16406us; 0us; 16407us; 0us; 16408us; 0us; 16409us; 0us; 16410us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 9us; 10us; 23us; 24us; 30us; 36us; 45us; 58us; 67us; 80us; 89us; 101us; 103us; 105us; 114us; 124us; 133us; 137us; 141us; 145us; 146us; 147us; 148us; 158us; 168us; 174us; 180us; 186us; 192us; 205us; 218us; 231us; 244us; 257us; 266us; 275us; 284us; 293us; 302us; 311us; 320us; 329us; 338us; 347us; 356us; 357us; 358us; 360us; 363us; 372us; 381us; 382us; 384us; 393us; 402us; 403us; 412us; 413us; 414us; 415us; 416us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 6us; 4us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 1us; 7us; 8us; 3us; 2us; 2us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16402us; 16403us; 65535us; 65535us; 65535us; 65535us; 16404us; 65535us; 65535us; 65535us; 16405us; 65535us; 16406us; 16407us; 16408us; 16409us; 16410us; |]
let _fsyacc_reductions ()  =    [| 
# 263 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 272 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "FunPar.fsy"
                                                               _1 
                   )
# 34 "FunPar.fsy"
                 : Absyn.expr));
# 283 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "FunPar.fsy"
                                                               _1                     
                   )
# 38 "FunPar.fsy"
                 : Absyn.expr));
# 294 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               _1                     
                   )
# 39 "FunPar.fsy"
                 : Absyn.expr));
# 305 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 40 "FunPar.fsy"
                 : Absyn.expr));
# 318 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               Fun(_2, _4)            
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 330 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 341 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 353 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 365 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 377 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 389 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 401 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 413 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 425 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 437 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 449 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 461 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 473 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               _1                     
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 484 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Var _1                 
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 495 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 508 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 522 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "FunPar.fsy"
                                                               _2                     
                   )
# 62 "FunPar.fsy"
                 : Absyn.expr));
# 533 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 66 "FunPar.fsy"
                 : Absyn.expr));
# 545 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 67 "FunPar.fsy"
                 : Absyn.expr));
# 557 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
# 568 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 72 "FunPar.fsy"
                 : Absyn.expr));
|]
# 580 "FunPar.fs"
let tables () : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 31;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
