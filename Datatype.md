# C# Data Types

## 🧮 Primitive (Value) Types

Primitive types are predefined by the C# language and store actual values directly in memory (stack). They are derived from `System.ValueType`.

### Numeric Types

- **Signed Integers**:

  - `sbyte` (8-bit): –128 to 127 => Not Common ‼️
  - `short` (16-bit): –32,768 to 32,767
  - `int` (32-bit): –2,147,483,648 to 2,147,483,647
  - `long` (64-bit): –9,223,372,036,854,775,808 to 9,223,372,036,854,775,807

- **Unsigned Integers**:

  - `byte` (8-bit): 0 to 255 => Not Common ‼️
  - `ushort` (16-bit): 0 to 65,535 => Not Common ‼️
  - `uint` (32-bit): 0 to 4,294,967,295 => Not Common ‼️
  - `ulong` (64-bit): 0 to 18,446,744,073,709,551,615 => Not Common ‼️

- **Floating-Point Types**:

  - `float` (32-bit): ±1.5 × 10^–45 to ±3.4 × 10^38
  - `double` (64-bit): ±5.0 × 10^–324 to ±1.7 × 10^308

- **Decimal Type**:
  - `decimal` (128-bit): ±1.0 × 10^–28 to ±7.9 × 10^28

### Other Primitive Types

- `char`: Represents a single 16-bit Unicode character.
- `bool`: Represents a Boolean value (`true` or `false`).
- `nint` / `nuint`: Platform-specific signed and unsigned integers, respectively => Not Common ‼️

## 🧱 Non-Primitive (Reference) Types

Non-primitive types store references to memory locations where the actual data is held (heap). They are derived from `System.Object`.

- `string`: Represents a sequence of Unicode characters.
- `object`: The base type from which all other types derive.
- **Classes**: User-defined types that encapsulate data and behavior.
- **Interfaces**: Define contracts that classes or structs can implement.
- **Arrays**: Collections of elements of the same type.
- **Delegates**: References to methods with a specific parameter list and return type.
- **Enums**: User-defined types consisting of named constants.
- **Structs**: Value types that can encapsulate data and related functionality.

## 🔍 Summary Comparison

| Feature            | Primitive (Value) Types            | Non-Primitive (Reference) Types      |
| ------------------ | ---------------------------------- | ------------------------------------ |
| **Memory Storage** | Stack                              | Heap                                 |
| **Stores**         | Actual value                       | Reference to data                    |
| **Inheritance**    | Derived from `System.ValueType`    | Derived from `System.Object`         |
| **Examples**       | `int`, `float`, `bool`, `char`     | `string`, `object`, `class`, `array` |
| **Default Value**  | Zero-equivalent (e.g., 0, `false`) | `null`                               |

---

Understanding the differences between these data types is fundamental for efficient memory management and effective programming in C#.
