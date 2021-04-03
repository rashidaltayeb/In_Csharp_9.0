# New_in_Csharp_9.0  

.Net 5 is paired with C# 9.0, which brings many new features to the language. The new language features include : \
1- top-level statements\
2- records\
3- init-only setters

## top-level statements 

With top-level statements, you can replace that main method with the using statement and the single line that does the work to output the result

 
## records

Record types make it easy to create immutable reference types in .NET.

## Init only setters

is provide consistent syntax to initialize members of an object. Property initializers make it clear which value is setting which property. The downside is that those properties must be settable. Starting with C# 9.0, you can create init accessors instead of set accessors for properties and indexers. Callers can use property initializer syntax to set these values in creation expressions, but those properties are readonly once construction has completed.

### Screen Shoot:

