module FsDijkstra

open GraphProvider

type Actors = StateMachine< "Actors.dgml", "Keanu Reeves" >

let findShortestPathOriginal (graph : Actors) startNode targetNode = 
    if startNode = targetNode then Some []
    else graph.FindShortestPathTo(startNode, targetNode) |> Option.map List.rev

let findShortestPath (a : Actors) startNode targetNode = 
    let findIndex name = a.Nodes |> Seq.findIndex (fun x -> x.Name = name)
    
    let dist = 
        a.Nodes
        |> Seq.map (fun x -> (System.Int32.MaxValue, x))
        |> Array.ofSeq
    
    let prev = Array.create (a.Nodes.Length) Option<StateMachine.Node>.None
    let startIndex = findIndex startNode
    dist.[startIndex] <- (0, dist.[startIndex] |> snd)
    let rec processNode visitedNodes = 
        let (act, u) = 
            dist
            |> Seq.filter (fun x -> 
                   visitedNodes
                   |> Seq.tryFind ((=) (snd x))
                   |> Option.isNone)
            |> Seq.minBy fst
        if u.Name = targetNode then 
            let rec path (node : StateMachine.Node) = 
                let index = findIndex node.Name
                match prev.[index] with
                | Some n -> n :: path n
                | None -> []
            
            let z = 
                path u
                |> List.rev
                |> List.map (fun n -> n.Name)
            
            match z with
            | [] -> None
            | x -> Some x
        else 
            let uIndex = findIndex u.Name
            let neighbors = u.NextNodes |> Seq.map snd
            let alt = act + 1
            for n in neighbors do
                let nIndex = findIndex n.Name
                let curDist = dist.[nIndex] |> fst
                if alt < curDist then 
                    dist.[nIndex] <- (alt, dist.[nIndex] |> snd)
                    prev.[nIndex] <- Some a.Nodes.[uIndex]
            processNode (u :: visitedNodes)
    processNode []

open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Can find path between Keanu Reeves and Kevin Bacon``() = 
    let a = Actors()
    findShortestPath a a.KeanuReeves a.KevinBacon 
    |> should equal (Some [ "Keanu Reeves"; "The Matrix"; "Laurence Fishburne"; "Mystic River" ])
