// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;

// 1.4.2
Expr e1 = new Mul(new Var("z"),new Add(new CstI(18), new Var("x")));
Expr e2 = new Sub(new Var("z"),new Mul(new Add(new CstI(19), new CstI(1)), new Var("x")));
Expr e3 = new Sub(new Sub(new Sub(new Sub(new Add(new Var("x"), new Add(new CstI(65),new Add(new Var("x"), new Add(new CstI(5),new CstI(78))))),new Mul(new Var("y"),new CstI(10))),new Mul(new Var("y"),new CstI(10))),new Mul(new Var("y"),new CstI(10))),new Mul(new Var("y"),new CstI(10)));
Expr e4 = new Sub(new Var("x"), new Mul(new CstI(0), new CstI(10)));
Expr e5 = new Sub(new Var("x"), new Var("x"));
Expr e6 = new Add(new Var("x"), new CstI(0));
Expr e7 = new Add(new CstI(0),new Var("x"));
   
Console.WriteLine("e1 tostring :: {0}", e1.ToString());
Console.WriteLine("e2 tostring :: {0}", e2.ToString());
Console.WriteLine("e3 tostring :: {0}", e3.ToString());

// 1.4.3 Test
Dictionary<string, int> env = new Dictionary<string, int>();
env.Add("x", 1);
env.Add("y", 4);
env.Add("z", 6);
Console.WriteLine("e1 Eval :: {0}", e1.Eval(env));
Console.WriteLine("e2 Eval :: {0}", e2.Eval(env));
Console.WriteLine("e3 Eval :: {0}", e3.Eval(env));
// 1.4.4 Test
Console.WriteLine("e4 Simplify :: {0}", e4.Simplify().ToString());
Console.WriteLine("e5 Simplify :: {0}", e5.Simplify().ToString());
Console.WriteLine("e6 Simplify :: {0}", e6.Simplify().ToString());
Console.WriteLine("e7 Simplify :: {0}", e7.Simplify().ToString());
Console.WriteLine("e4 Simplify + Eval :: {0}", e4.Simplify().Eval(env));
Console.WriteLine("e5 Simplify + Eval :: {0}", e5.Simplify().Eval(env));
Console.WriteLine("e6 Simplify + Eval :: {0}", e6.Simplify().Eval(env));
Console.WriteLine("e7 Simplify + Eval :: {0}", e7.Simplify().Eval(env));


// 1.4.1 
public abstract class Expr
{
   public abstract string ToString();
   public abstract int Eval(Dictionary<string, int> env);

   public abstract Expr Simplify();

}

public class CstI : Expr
{
   public int num;

   public CstI(int i) =>  num = i;
   
   public override string ToString() => String.Format("{0}", num);

   public override int Eval(Dictionary<string, int> env) => num;
   
   public override Expr Simplify() => new CstI(num);
}

public class Var : Expr
{
   public string var;
   public Var(string name) => var = name;
   public override string ToString() => String.Format("{0}", var);

   public override int Eval(Dictionary<string, int> env) => env[var];
   
   public override Expr Simplify() => new Var(var);

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

   public override Expr Simplify()
   {
      Expr x = expression1.Simplify();
      Expr y = expression2.Simplify();
      switch (operation)
      {
         case "+":
            if ((x is CstI xc) && (y is CstI yc))
            {
               return new CstI(xc.num + yc.num);
            }
            else if ((x is Var xv) && (y is CstI yc1))
            {
               if (yc1.num == 0)
               {
                  return  xv;
               }
               return new Add(xv, y);
            }
            else if ((x is CstI xc1) && (y is Var yv))
            {
               if (xc1.num == 0)
               {
                  return  yv;
               }
               return new Add(xc1, y);
            }
            Expr rec = new Add (x.Simplify(),y.Simplify());
            return rec;
         
         case "-" :
            if ((x is CstI xc2) && (y is CstI yc2))
            {
               return new CstI(xc2.num - yc2.num);
            }
            else if ((x is Var xv) && (y is CstI yc1))
            {
               if (yc1.num == 0)
               {
                  return  xv;
               }
               return new Sub(xv, y);
            }
            else if ((x is CstI xc1) && (y is Var yv))
            {
               if (xc1.num == 0)
               {
                  return  yv;
               }
               return new Sub(xc1, y);
            }
            Expr rec1 = new Sub (x.Simplify(),y.Simplify());
            return rec1;
        
         case "*":
            if ((x is CstI xc3) && (y is CstI yc3))
            {
               return new CstI(xc3.num * yc3.num);
            }
            else if ((x is Var xv) && (y is CstI yc1))
            {
               if (yc1.num == 0)
               {
                  return  new CstI(0);
               }
               return new Mul(xv, y);
            }
            else if ((x is CstI xc1) && (y is Var yv))
            {
               if (xc1.num == 0)
               {
                  return  new CstI(0);
               }
               return new Mul(xc1, y);
            }
            Expr rec2 = new Mul (x.Simplify(),y.Simplify());
            return rec2;
         default :
            return new Binop("¯/_(ツ)_/¯", expression1, expression2);
         
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


