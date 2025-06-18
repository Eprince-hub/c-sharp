<!-- Overloading the operator eg. + for concatenation and addition -->

# ✅ C# Operators

## 🔹 Arithmetic Operators

| Operator | Description         | Example |
| -------- | ------------------- | ------- |
| `+`      | Addition            | `a + b` |
| `-`      | Subtraction         | `a - b` |
| `*`      | Multiplication      | `a * b` |
| `/`      | Division            | `a / b` |
| `%`      | Modulus (remainder) | `a % b` |

## 🔹 Assignment Operators

| Operator | Description         | Example  |
| -------- | ------------------- | -------- |
| `=`      | Assign              | `a = b`  |
| `+=`     | Add and assign      | `a += b` |
| `-=`     | Subtract and assign | `a -= b` |
| `*=`     | Multiply and assign | `a *= b` |
| `/=`     | Divide and assign   | `a /= b` |
| `%=`     | Modulus and assign  | `a %= b` |

## 🔹 Comparison (Relational) Operators

| Operator | Description      | Example  |
| -------- | ---------------- | -------- |
| `==`     | Equal to         | `a == b` |
| `!=`     | Not equal to     | `a != b` |
| `>`      | Greater than     | `a > b`  |
| `<`      | Less than        | `a < b`  |
| `>=`     | Greater or equal | `a >= b` |
| `<=`     | Less or equal    | `a <= b` |

## 🔹 Logical Operators

| Operator | Description | Example  |
| -------- | ----------- | -------- | ---------- | --- | --- | --- |
| `&&`     | Logical AND | `a && b` |
| `        |             | `        | Logical OR | `a  |     | b`  |
| `!`      | Logical NOT | `!a`     |

## 🔹 Bitwise Operators

| Operator | Description      | Example  |
| -------- | ---------------- | -------- | --- | --- |
| `&`      | AND              | `a & b`  |
| `        | `                | OR       | `a  | b`  |
| `^`      | XOR              | `a ^ b`  |
| `~`      | NOT (complement) | `~a`     |
| `<<`     | Left shift       | `a << 2` |
| `>>`     | Right shift      | `a >> 2` |

## 🔹 Increment/Decrement Operators

| Operator | Description | Example        |
| -------- | ----------- | -------------- |
| `++`     | Increment   | `a++` or `++a` |
| `--`     | Decrement   | `a--` or `--a` |

## 🔹 Conditional (Ternary) Operator

| Operator | Description | Example             |
| -------- | ----------- | ------------------- |
| `?:`     | Ternary     | `condition ? x : y` |

## 🔹 Null-Coalescing Operators

| Operator | Description              | Example   |
| -------- | ------------------------ | --------- |
| `??`     | Returns left if not null | `a ?? b`  |
| `??=`    | Assign if left is null   | `a ??= b` |

## 🔹 Type Checking and Casting

| Operator | Description               | Example         |
| -------- | ------------------------- | --------------- |
| `is`     | Type check                | `obj is string` |
| `as`     | Safe cast (null if fails) | `obj as string` |

## 🔹 Other Operators

| Operator    | Description                | Example               |
| ----------- | -------------------------- | --------------------- |
| `=>`        | Lambda expression          | `(x) => x + 1`        |
| `sizeof`    | Size of a type             | `sizeof(int)`         |
| `typeof`    | Type of a class            | `typeof(MyClass)`     |
| `checked`   | Checks overflow at runtime | `checked(a + b)`      |
| `unchecked` | Ignores overflow           | `unchecked(a + b)`    |
| `new`       | Create object or array     | `new MyClass()`       |
| `await`     | Await async result         | `await Task.Run(...)` |

In math, `PEMDAS` is an acronym that helps students remember the order of operations. The order is:

Parentheses (whatever is inside the parenthesis is performed first)
Exponents
Multiplication and Division (from left to right)
Addition and Subtraction (from left to right)

Does it sound like `BODMAS` as well?
