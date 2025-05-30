# a2957d - Inline x86_64 Assembly Execution

This module provides the ability to execute inline x86_64 assembly instructions from C#, enabling access to hardware features and instructions not directly available through managed code.

## Overview

The `a2957d.C.M()` method allows execution of x86_64 machine code with up to 3 arguments, enabling access to:
- Hardware random number generators (RDRAND)
- Bit manipulation instructions (ROL, ROR)
- Cryptographic instruction extensions (AES-NI, SHA)
- CPUID and other system introspection instructions
- Performance-critical operations requiring specific assembly sequences

## Usage

```csharp
_a2957d_.C.M(
    code: "hex string of machine code",
    arg0: parameter1,
    arg1: parameter2, 
    arg2: parameter3
);
```

## Example: Hardware Random Number Generator

See `03d7ca/C/methods/e9b6ec/_.cs` for a complete implementation of a random number generator using the RDRAND instruction:

```csharp
_a2957d_.C.M(
    arg0: transactionPointer,
    code: 
        // Assembly sequence using RDRAND instruction
        "48 8b 31" +           // mov rsi,QWORD PTR [rcx]
        // ... additional instructions ...
        "48 0f c7 f2" +        // rdrand rdx  - Hardware RNG
        // ... result handling ...
);
```

This example demonstrates accessing the CPU's hardware random number generator, which provides cryptographically secure random numbers directly from the processor.

## Implementation

The module:
1. Allocates executable memory with appropriate protections
2. Converts hex string machine code to executable bytes
3. Executes the code with provided arguments
4. Cleans up allocated memory

## Security Note

This module enables execution of arbitrary machine code. Use only with trusted, well-understood assembly sequences for legitimate systems programming needs.