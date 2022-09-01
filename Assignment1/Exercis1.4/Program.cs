// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;

// 1.4.2
Expr e1 = new Mul(new Var("z"),new Add(new CstI(18), new Var("x")));
Expr e2 = new Sub(new Var("z"),new Mul(new Add(new CstI(19), new CstI(1)), new Var("x")));
Expr e3 = new Sub(new Sub(new Sub(new Sub(new Add(new Var("x"), new Add(new CstI(65),new Add(new Var("x"), new Add(new CstI(5),new CstI(78))))),new Mul(new Var("y"),new CstI(10))),new Mul(new Var("y"),new CstI(10))),new Mul(new Var("y"),new CstI(10))),new Mul(new Var("y"),new CstI(10)));
Console.WriteLine("e1 tostring :: {0}", e1.ToString());
Console.WriteLine("e2 tostring :: {0}", e2.ToString());
Console.WriteLine("e3 tostring :: {0}", e3.ToString());

Dictionary<string, int> env = new Dictionary<string, int>();
env.Add("x", 1);
env.Add("y", 4);
env.Add("z", 6);
Console.WriteLine("e1 Eval :: {0}", e1.Eval(env));
Console.WriteLine("e2 Eval :: {0}", e2.Eval(env));
Console.WriteLine("e3 Eval :: {0}", e3.Eval(env));
// 1.4.1 
public abstract class Expr
{
   public abstract string ToString();
   public abstract int Eval(Dictionary<string, int> env);

  // public abstract string Simplify();

}

public class CstI : Expr
{
   public int num;

   public CstI(int i) =>  num = i;

   public override string ToString() => String.Format("{0}", num);

   public override int Eval(Dictionary<string, int> env) => num;
}

public class Var : Expr
{
   public string var;
   public Var(string name) => var = name;
   public override string ToString() => String.Format("{0}", var);

   public override int Eval(Dictionary<string, int> env) => env[var];

}

public class Binop : Expr
{
   public string operation;
   public Expr expression1;
   public Expr expression2;

   public Binop(string opr, Expr e1, Expr e2)
   {
      operation = opr;
      expression1 = e1;
      expression2 = e2;
   }
   public override string ToString() => String.Format("({0} {1} {2})", expression1.ToString(), operation, expression2.ToString());

   public override int Eval(Dictionary<string, int> env)
   {
      switch (operation)
      {
         case "+":
            return expression1.Eval(env) + expression2.Eval(env);
         case "-" :
            return expression1.Eval(env) - expression2.Eval(env);
         case "*":
            return expression1.Eval(env) * expression2.Eval(env);
         default :
            return 0000;
      }
   }
}

public class Add : Binop
{
   public Add(Expr e1, Expr e2) : base("+", e1, e2){}
}

public class Sub : Binop
{
   public Sub(Expr e1, Expr e2) : base("-", e1, e2){}
}

public class Mul : Binop
{
   public Mul(Expr e1, Expr e2) : base("*", e1, e2){}
}


