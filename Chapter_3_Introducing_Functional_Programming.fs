let s=" Couldn't put Humpty";;
//val s : string = "Couldn't put Humpty"
s.Length;;
//val it: int = 20
s.[14];;
//val it: char = 'H'
s.[13..16];;
//val it: string = " Hum"
//s.[13] <- 'h';;
//error FS0810: Property 'Chars' cannot be set
"Couldn't put Humpty" + " " + "together again";;
//val it : string = "Couldn't put Humpty together again"
let round0 x =
 if x >= 100 then 100
 elif x < 0 then 0
 else x
//Conditionals are really shorthand for pattern matching; for example, the previous code could be written like this:
let round1 x =
 match x with
 | _ when x >= 100 -> 100
 | _ when x < 0 -> 0
 | _ -> x
//Conditionals are always guarded by a Boolean-valued expression. You can build them using && and || (the “and” and “or” operators) as well as any library functions that return Boolean values
let round2 (x, y) =
 if x >= 100 || y >= 100 then 100, 100
 elif x < 0 || y < 0 then 0, 0
 else x, y

let rec factorial n = if n <= 1 then 1 else n * factorial (n - 1);;
factorial 5;;

let rec length l =
 match l with
 | [] -> 0
 | h :: t -> 1 + length t

 let rec repeatFetch url n =
    if n > 0 then
        let html = http url
        printfn "fetched <<< %s >>> on iteration %d" html n
        repeatFetch url (n - 1)

let people = 
    [("Adam", None); 
    ("Eve" , None); 
    ("Cain", Some("Adam","Eve")); 
    ("Abel", Some("Adam","Eve"))]
 //val people : (string * (string * string) option) list = [("Adam", None); ("Eve", None); ("Cain", Some ("Adam", "Eve")); ("Abel", Some ("Adam", "Eve"))]
 let showParents (name, parents) =
 match parents with
 | Some (dad, mum) -> printfn "%s has father %s and mother %s" name dad mum
 | None -> printfn "%s has no parents!" name

for person in people do showParents person;;
//Matching on Structured Values
//Pattern matching can be used to decompose structured values. Here is an example in which nested tuple values are matched
let highLow a b =
 match (a, b) with
 | ("lo", lo), ("hi", hi) -> (lo, hi)
 | ("hi", hi), ("lo", lo) -> (lo, hi)
 | _ -> failwith "expected a both a high and low value"

 highLow ("hi", 300) ("lo", 100);;

// Building Functions with Partial Application Composing functions is just one way
//to compute interesting new functions. Another useful way is to use partial application. 
//Here’s an example, with x and y in Cartesian coordinates:
let shift (dx, dy) (px, py) = (px + dx, py + dy)
let shiftRight = shift (1, 0)
let shiftUp = shift (0, 1)
let shiftLeft = shift (-1, 0)
let shiftDown = shift (0, -1)

open System.Drawing
let remap (r1:RectangleF) (r2:RectangleF) =
    let scalex = r2.Width / r1.Width
    let scaley = r2.Height / r1.Height
    let mapx x = r2.Left + (x - r1.Left) * scalex
    let mapy y = r2.Top + (y - r1.Top) * scaley
    let mapp (p:PointF) = PointF(mapx p.X, mapy p.Y)
    mapp
let rect1 = RectangleF(100.0f, 100.0f, 100.0f, 100.0f)
let rect2 = RectangleF(50.0f, 50.0f, 200.0f, 200.0f)
let mapp = remap rect1 rect2
