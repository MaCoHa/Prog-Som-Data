   //page 336 
   //https://www.ecma-international.org/wp-content/uploads/ECMA-335_5th_edition_december_2010.pdf
  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3)
                          // Opcode
    IL_0000:  ldc.i4.0    // push value "0" onto the stack (part of initialization of "i")
    IL_0001:  stloc.0     // pop a value from the stack into local variable 0 (take value "0" from stack and save it in local variable "i")
    IL_0002:  br.s       IL_0032 // Branch to target (condition check for outer for-loop)

    IL_0004:  ldloc.0   // load local variable 0 onto the stack (load value of i)
    IL_0005:  stloc.1   // pop value from stack into local variable 1 (take value stored in stack (value of i) and pop into varaible 1 (least))
    IL_0006:  ldloc.0   // load local variable 0 onto the stack (load value of i onto the stack)
    IL_0007:  ldc.i4.1  // push 1 onto the stack as int32 (push value of least onto the stack as int32)
    IL_0008:  add       // add 2 numbers and return a new value (add (i + 1))
    IL_0009:  stloc.2   // pop a value from the stack and save it in local variable 2 (pop result of (IL_0008) and save it in "j")
    IL_000a:  br.s       IL_001a // branch to target (IL_001a) (condition check of inner for-loop)

    IL_000c:  ldarg.0 // load argument 0 onto the stack (load arr onto the stack)
    IL_000d:  ldloc.2 // load local variable 2 onto the stack (load value of j onto the stack)
    IL_000e:  ldelem.i4 // load element of type int32 at "i4" onto the top of the stack as an int32 (load value at index j of arr onto top of the stack)
    IL_000f:  ldarg.0 // Load argument 0 onto the stack (load arr onto the stack)
    IL_0010:  ldloc.1 // load local variable 0 onto the stack (load "i" onto the stack (since "least = i", it loads value of "i" which is local variable 0)
    IL_0011:  ldelem.i4 //load element of type int32 at "i4" onto the top of the stack (load value at index "least" of arr onto the top of the stack)
    IL_0012:  bge.s      IL_0016 // branch to (IL_0016) if greater than or equal to, short form (do not go into "if statement" if greater than or equal to)

    IL_0014:  ldloc.2 // Load local variable 2 onto the stack (load value of "j" onto the stack)
    IL_0015:  stloc.1 // pop value from stack into local variable 1 (pop value from the top of the stack ("j") and save it in variable "least")
    IL_0016:  ldloc.2 // load local variable 2 onto the stack (load value of "j" onto the stack)
    IL_0017:  ldc.i4.1 // push 1 onto the stack as int32 (push value "1" onto the stack)
    IL_0018:  add // add 2 numbers and return a new value (j++, which is basicly short of j = j + 1)
    IL_0019:  stloc.2 // pop a value from the stack and save it in local variable 2 (pop the value from "add" and save it in "j")
    IL_001a:  ldloc.2 //load local variable 2 onto the stack (load value of "j" onto the stack)
    IL_001b:  ldarg.0 // load argument 0 onto the stack (load arr onto the stack)
    IL_001c:  ldlen // push the length of array on the stack (push the length of the array to the stack)
    IL_001d:  conv.i4 // convert to int32, pushing int32 onto the stack (length of array converted from unsigned int to int32)
    IL_001e:  blt.s      IL_000c //branch to IL_000c if less than, short form (go into inner for-loop if condition is true)

    IL_0020:  ldarg.0 // Load argument 0 onto the stack. (load arr onto the stack)
    IL_0021:  ldloc.0 // Load local variable 0 onto the stack. (load value of "i" onto the stack)
    IL_0022:  ldelem.i4 // Load the element with type int32 at index onto the stack as an int32. (load value found at index i4 onto the stack (in other words, value of "arr[i]" onto the stack))
    IL_0023:  stloc.3 // Store value from stack into local variable 3. (store value found at arr[i] in local variable 3 (tmp)
    IL_0024:  ldarg.0 // Load argument 0 onto the stack. (load arr onto the stack)
    IL_0025:  ldloc.0 // Load local variable 0 onto the stack. (load "i" onto the stack)
    IL_0026:  ldarg.0 // Load argument 0 onto the stack. (load arr onto the stack)
    IL_0027:  ldloc.1 // Load local variable 1 onto the stack. (load "least" onto the stack)
    IL_0028:  ldelem.i4 // Load the element with type int32 at index onto the stack as an int32. (load value found at arr[j] onto the stack as int32)
    IL_0029:  stelem.i4 // Replace array element at index with the int32 value on the stack. (replace element at arr[i] with the value of type int32 on the stack (value of arr[least])
    IL_002a:  ldarg.0 // Load argument 0 onto the stack. (load arr onto the stack)
    IL_002b:  ldloc.1 // Load local variable 1 onto the stack. (load value of "least" onto the stack)
    IL_002c:  ldloc.3 // Load local variable 3 onto the stack. (load value of "tmp" onto the stack)
    IL_002d:  stelem.i4 // Replace array element at index with the int32 value on the stack. (replace element found at arr[least] with value of type int32 found at the stack (value of tmp))
    IL_002e:  ldloc.0 // Load local variable 0 onto the stack. (load value of "i" onto the stack)
    IL_002f:  ldc.i4.1 // Push 1 onto the stack as int32. (push int 1 onto the stack)
    IL_0030:  add // Add two values, returning a new value (add 2 values (increment value of "i")
    IL_0031:  stloc.0 // Store value from stack into local variable 0. (overwrite value stored in variable "i")
    IL_0032:  ldloc.0 // Load local variable 0 onto the stack. (load value from variable "i" onto the stack)
    IL_0033:  ldarg.0 // Load argument 0 onto the stack. (load arr onto the stack)
    IL_0034:  ldlen // Push the length (of type native unsigned int) of array on the stack. (load array length onto the stack)
    IL_0035:  conv.i4 // Convert to int32, pushing int32 on stack. (convert arr.length to type int32 and push to the stack)
    IL_0036:  blt.s      IL_0004 // Branch to target (IL_0004) (go into outer for-loop if condition is true)

    IL_0038:  ret // end of method
  } // end of method Selsort::SelectionSort

  