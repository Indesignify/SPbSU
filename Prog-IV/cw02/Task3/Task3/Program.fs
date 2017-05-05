module Program

exception ErrorEmpty of string
    
type PriorityQueue<'a>() =
    let mutable queue : list<(list<'a> * int)> = []

    let getFirst (x, y) = x
    let getSecond (x, y) = y

    member q.Enqueue value (priority : int) =
        let rec add count prefix (queueList : list<(list<'a> * int)>) =
            if (count = queue.Length) then
                queue <- queue @ [[value], (priority)]
            elif (getSecond queueList.Head < priority) then
                queue <- List.rev prefix @ [[value], (priority)] @ queueList
            else
                add (count + 1) (queueList.Head :: prefix) queueList.Tail
        add 0 [] queue

    member q.Dequeue =
        match queue with
        | head :: tail ->
            let result = getFirst queue.Head
            queue <- queue.Tail
            result
        | [] -> failwith "Queue is empty, please retry!"

    member q.IsEmpty = queue.Length = 0

// Test to see the output
let queue = new PriorityQueue<int>()
queue.Enqueue 5 8
queue.Enqueue 12 3
queue.Enqueue 6 9
queue.Enqueue 5 1
queue.Enqueue 7 10
queue.Enqueue 11 9
queue.Enqueue 3 4
queue.Enqueue 2 7

while not queue.IsEmpty do
    printfn "%A" queue.Dequeue