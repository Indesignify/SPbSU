module Program
    
let isPalindrome (number:int) =
    let list = List.ofArray (number.ToString().ToCharArray())
    let rec reverseRec ls temps =
        match ls with
        | h :: t -> reverseRec t (h :: temps)
        | [] -> temps
    let reverces = reverseRec list []
    reverces = list

let theBiggestPalindrome =
    let rec findMax number1 number2 max =
        let rec loop number1 number2 max =
            let newMax = number1 * number2
            if newMax > max && isPalindrome newMax then newMax
            elif number1 > 99 then loop (number1 - 1) number2 max
            else max
        let aMax = loop number1 number2 max
        if aMax > max then findMax number1 (number2 - 1) aMax
        elif number2 > 99 then findMax number1 (number2 - 1) aMax
        else max
    findMax 999 999 -1