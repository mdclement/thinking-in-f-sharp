namespace ThinkingInFSharp

open NUnit.Framework
open FsUnit

type FizzBuzzTranslator() =
    static member Translate(input) =
        ()


[<TestFixture>] 
type ``FizzBuzz Tests`` ()=
    [<TestCase(1, "1")>]
    [<TestCase(2, "2")>]
    [<TestCase(3, "Fizz")>]
    [<TestCase(5, "Buzz")>]
    [<TestCase(6, "Fizz")>]
    [<TestCase(10, "Buzz")>]
    [<TestCase(15, "FizzBuzz")>]
    member x.
        ``input is expected`` (input : int, expected : string)= 
                FizzBuzzTranslator.Translate(input) |> should equal expected

    [<Test>]
    member x.
        ``execute`` ()=
            let result = {1 .. 100} |> Seq.map(fun n -> FizzBuzzTranslator.Translate(n))
            printfn "%A " (Seq.toList result)
