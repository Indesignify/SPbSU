module Tests

open Program
open FsUnit
open NUnit.Framework

[<Test>]
let ``Adding one element test`` () =
    let q = PriorityQueue<int>()
    q.Enqueue 5 8
    q.Dequeue |> should equal [5]