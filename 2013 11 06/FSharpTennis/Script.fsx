type Player = 
    | PlayerOne
    | PlayerTwo

type Score = 
    | Love
    | Fifteen
    | Thirty
    | Forty

type GameScore =
    | Points of Score * Score
    | Advantage of Player
    | Win of Player

let newGame = Points (Love, Love)
let deuce = Points (Forty, Forty)

let givePoint = function
    | (Love, y) -> (Fifteen, y)
    | (Fifteen, y) -> (Thirty, y)
    | (Thirty, y) -> (Forty, y)
    | _ -> failwith "END OF THE WORLD"

let swap (x, y) = (y, x)

let score player (x, y) = 
    match player with
    | PlayerOne -> givePoint (x, y)
    | PlayerTwo -> swap (x, y) 
                    |> givePoint 
                    |> swap

let playerScores player = function
    | Points (Forty, Forty) -> Advantage player
    | Points (Forty, _) when player = PlayerOne -> Win player
    | Points (_, Forty) when player = PlayerTwo -> Win player
    | Points (x, y) -> Points (score player (x, y))
    | Advantage x when x = player -> Win player
    | Advantage _ -> deuce
    | _ -> failwith "END OF THE WORLD"








let playerOneScores = playerScores PlayerOne

let playerTwoScores = playerScores PlayerTwo

let shouldBeTrue x = 
    match x with 
    | false -> printf "Assertion failure.\n"
    | true -> printf "Passed.\n"


newGame
    |> (=) (Points (Love, Love))
    |> shouldBeTrue

Points (Love, Love)
    |> playerOneScores
    |> (=) (Points (Fifteen, Love))
    |> shouldBeTrue

Points (Fifteen, Love)
    |> playerOneScores
    |> (=) (Points (Thirty, Love))
    |> shouldBeTrue

Points (Thirty, Love)
    |> playerOneScores
    |> (=) (Points (Forty, Love))
    |> shouldBeTrue

Points (Forty, Love)
    |> playerOneScores
    |> (=) (Win PlayerOne)
    |> shouldBeTrue

deuce
    |> playerOneScores
    |> (=) (Advantage PlayerOne)
    |> shouldBeTrue

Advantage PlayerOne
    |> playerOneScores
    |> (=) (Win PlayerOne)
    |> shouldBeTrue

Advantage PlayerTwo
    |> playerOneScores
    |> (=) deuce
    |> shouldBeTrue

Points (Love, Love)
    |> playerTwoScores
    |> (=) (Points (Love, Fifteen))
    |> shouldBeTrue

Points (Love, Forty)
    |> playerTwoScores
    |> (=) (Win PlayerTwo)
    |> shouldBeTrue

Points (Forty, Thirty)
    |> playerTwoScores
    |> (=) deuce
    |> shouldBeTrue

Points (Thirty, Forty)
    |> playerOneScores
    |> (=) deuce
    |> shouldBeTrue

try
    Win PlayerOne
        |> playerOneScores
        |> ignore;
    shouldBeTrue false
with
   | _ ->  shouldBeTrue true