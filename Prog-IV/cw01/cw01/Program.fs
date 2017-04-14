// First task
let infiniteSequenceOfSequences = Seq.map (fun x -> Seq.init x (fun y -> x)) (Seq.initInfinite (fun id -> id))
let infiniteSequence = infiniteSequenceOfSequences |> Seq.concat 

let output n =
    let infiniteSequenceForOutput = Seq.take n infiniteSequence
    for i in infiniteSequenceForOutput do
        printf "%d " i

// check to see if it works as expected
output 120

// Second Task
// Imperative realization, couldn't come up with functional...
let printSquare n =
    let array = Array2D.init n n (fun _ _ -> ' ')
    for i = 0 to n - 1 do
        for j = 0 to n - 1 do
            if i = 0 || j = 0 || j = (n - 1) || i = (n - 1) then Array2D.set array i j '*' else Array2D.set array i j ' '
    for i = 0 to n - 1 do
        for j = 0 to n - 1 do
            printf "%c" array.[i, j]
        printfn ""

// check to see the output
printf "\n"
printSquare 5

// Third task
type Stack<'a> (?items) =
    let items = defaultArg items []
 
    member x.Push(A) = Stack(A::items)
 
    member x.Pop() =
      match items with
        | x::xr -> (x, Stack(xr))
        | [] -> failwith "Stack is empty, please retry!"
 
    member x.IsEmpty() = items = []


let EmptyStack = Stack<int>()
let stack1 = EmptyStack.Push(80)
printfn "%A" (stack1.IsEmpty())