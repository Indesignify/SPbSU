module Tests

open Program
open FsUnit
open NUnit.Framework

[<Test>]
let ``The answer is`` () =
    theBiggestPalindrome |> should equal 906609
