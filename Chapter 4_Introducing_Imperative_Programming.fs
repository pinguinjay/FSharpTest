for (b,pj) in [("Banana 1",false);("Banana 2",true)] do
    if pj then
        printfn "%s is in pyjamas todays" b;;
//Banana 2 is in pyjamas today!
open System.Text.RegularExpressions;;
for m in Regex.Matches("All the Pretty Horses","[a-zA-Z]+") do
    printfn "res = %s" m.Value
//res = All
//res = the
//res = Pretty
//res = Horses
type DiscreteEventCounter =
    {mutable Total : int;
    mutable Positive : int;
    Name : string}
let recordEvent (s:DiscreteEventCounter) isPositive=
    s.Total<-s.Total + 1
    if isPositive then s.Positive <- s.Positive + 1
let reportStatus (s:DiscreteEventCounter) =
    printfn "We have %d %s out of %d" s.Positive s.Name s.Total
let newCounter nm = 
    { Total = 0;
      Positive=0;
      Name = nm}
//You can use this type as follows (this example uses the http function from Chapter 2)
/// Get the contents of the URL via a web request
open System.IO
open System.Net
let http (url: string) =
    let req = WebRequest.Create(url)
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    resp.Close()
    html

let longPageCounter = newCounter "long page(s)"
let fetch url = 
    let page = http url
    recordEvent  longPageCounter (page.Length>10000)
    page
//Every call to the function fetch mutates the mutable-record fields in the global variable longPageCounter.
// For example:
fetch "http://www.smh.com.au" |> ignore;;
fetch "http://www.theage.com.au" |> ignore;;
reportStatus longPageCounter;;
//We have 2 long page(s) out of 

type Cell = { mutable data : int };;
let cell1 = { data = 3 };;
//val cell1 : Cell = { data = 3;}
 let cell2 = cell1;;
//val cell2 : Cell = { data = 3;}
 cell1.data <- 7;;
//val it : unit = ()
cell1;;
//val cell1 : Cell = { data = 7;}
cell2;;
//val cell2 : Cell = { data = 7;}

let mutable cell1 = 1;;
//val mutable cell1 : int = 1
cell1 <- 3;;
cell1;;
//val it : int = 3


let sum n m = 
    let mutable res = 0
    for i = n to m do
        res<- res + i
    res
sum 3 6;;
//val it : int = 18

let generateStamp = 
    let mutable count = 0
    (fun() -> count <-count + 1; count)
generateStamp();;
//val it : int = 1
 generateStamp();;
//val it : int = 2

//Working with Arrays
//Mutable arrays are a key data structure used as a building block in many high-performance computing 
//scenarios. This example illustrates how to use a one-dimensional array of float values
let arr = [|1.0; 1.0; 1.0|];;
//val arr : float [] = [|1.0; 1.0; 1.0|]
arr.[1];;
//val it : float = 1.0
arr.[1] <- 3.0;;
arr;;
//val it : float [] = [|1.0; 3.0; 1.0|]
