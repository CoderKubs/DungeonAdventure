



//Level 1 dictionary holding the level info
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Xml;

public class Program
{
    public static int currentLevel;
    public static char lastTile = ' ';
    public static void Main(){

        
        Dictionary<string, object> levels = new Dictionary<string, object>
                {
                    {  "level1", new Dictionary<string, object>
                        {
                            { "text", new List<string>
                                {
                                    "\n'Where am I?' You ask, but no one can hear you",
                                    "'Maybe I should try to find someone...'",
                                }
                            },
                            { "map", new char[][]
                                {
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', 'x'},
                                    new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x'},
                                    new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x'},
                                    new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', ' ', ' ', 'x'},
                                    new char[] { ' ', ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' ', ' '},
                                    new char[] { ' ', '2', ' ', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' ', ' '},
                                    new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', ' ', ' ', 'x'},
                                    new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x', ' ', 'o', 'x'},
                                    new char[] { 'x', '1', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x'},
                                    }

                            },
                            { "directions", new List<Tuple<string, int>>
                                {
                                    //tuple saying what level to switch to if you go north
                                    Tuple.Create("north", 2),
                                    Tuple.Create("south", 2),
                                    Tuple.Create("east", 3),
                                    Tuple.Create("west", 2)
                                }
                            },
                            { "bots", new List<Tuple<char, string, char, bool>>
                                {
                                    Tuple.Create('1',"up", ' ', false),
                                    Tuple.Create('2',"left", ' ', false)
                                }
                            }
                        }

                    },
                    {  "level2", new Dictionary<string, object>
                        {
                            { "text", new List<string>
                                {
                                    "\n'Where am I?' You ask, but no one can hear you",
                                    "\n'Maybe I should try to find someone...'",
                                }
                            },
                            { "map", new char[][]
                                {
                                    new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'w', 'w', 'w', 'w', ' '},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'w', 'w', 'w', 'w', ' '},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    }

                            },
                            { "directions", new List<Tuple<string, int>>
                                {
                                    Tuple.Create("north", 1),
                                    Tuple.Create("south", 2),
                                    Tuple.Create("east", 1),
                                    Tuple.Create("west", 2)
                                }
                            }
                        }

                    },
                    {  "level3", new Dictionary<string, object>
                        {
                            { "text", new List<string>
                                {
                                    "\n'Where am I?' You ask, but no one can hear you",
                                    "\n'Maybe I should try to find someone...'",
                                }
                            },
                            { "map", new char[][]
                                {
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' '},
                                    new char[] { ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' '},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                                    }

                            },
                            { "directions", new List<Tuple<string, int>>
                                {
                                    Tuple.Create("north", 1),
                                    Tuple.Create("south", 2),
                                    Tuple.Create("east", 1),
                                    Tuple.Create("west", 1)
                                }
                            }
                        }

                    }
                };



        // Accessing the "text" key in level1 dictionary;

        currentLevel = 1;
        Dictionary<string, object> level;

        char playerChar = 'o';

        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        //
        //Main game
        //
        do{
            // set new variables for the level just in case we swiched
            level = (Dictionary<string, object>)levels[$"level{currentLevel}"];

            // Accessing the "text" key in level dictionary;
            
            DisplayLevel(level,playerChar);


            //asks if they want to move and move
            Console.WriteLine("What do you want to do?");
            string output = GetWhatToDo();

            if(output.ToLower() == "move"){
                //Enters move character mode and it wont exit until you press escape.
                bool moving = true;
                int pastMovesStopped = 0;
                do{
                    int newLevel = currentLevel;

                    //Move the player
                    //Make water slow down the player
                    if(lastTile == 'w'){
                        if(pastMovesStopped == 2){

                            pastMovesStopped = 0;
                            (newLevel, moving) = MoveCharacter(levels,playerChar);

                        } else {
                            pastMovesStopped ++;
                            
                            ConsoleKeyInfo keyInfo = GetDirectionFromPlayer();
                            if (keyInfo.Key == ConsoleKey.Escape){
                                moving = false;
                            }
                        }
                    } else {
                        (newLevel, moving) = MoveCharacter(levels,playerChar);
                        pastMovesStopped = 0;

                    }
                    

                    //Update the level
                    if (newLevel != currentLevel){
                        currentLevel = newLevel;
                    }


                    MoveBots(level,playerChar);
                    bool botNearby = CheckIfBotNearby(level, playerChar);

                    if(botNearby){
                        break;
                    }
                }while(moving);    
            
            }
        } while (true);
    }



    static bool CheckIfBotNearby(Dictionary<string,object> level,char playerChar){

        //find player position
        int[] playerPosition = FindPlayer(level, playerChar);

        //set bots to a list of bots in the current level
        List<Tuple<char, string, char, bool>> bots = (List<Tuple<char, string, char, bool>>)level["bots"];

        foreach(Tuple<char, string, char, bool> bot in bots){
            //Set botChar to the character that the bot represents
            char botChar = bot.Item1;

            int[] botPosition = FindPlayer(level, botChar);

            int horizontalDistance = Math.Abs(botPosition[0] - playerPosition[0]);
            int verticalDistance = Math.Abs(botPosition[1] - playerPosition[1]);

            // Check if the bot is within one space of the player
            if (horizontalDistance <= 1 && verticalDistance <= 1)
            {
                return true;
            }
        }
        return false;
    }




    static void MoveBots(Dictionary<string,object> level,char playerChar){
        
        //Create a new list that will replace the bots list but with new positions
        List<Tuple<char, string, char, bool>> updatedBots = new List<Tuple<char, string, char, bool>>();

        List<Tuple<char, string, char, bool>> bots = (List<Tuple<char, string, char, bool>>)level["bots"];
        foreach(Tuple<char, string, char, bool> bot in bots){

            //break apart the bots info
            string direction = bot.Item2;
            char standingOnWhat = bot.Item3;
            bool chasingPlayer = bot.Item4;
            char botChar = bot.Item1;

            if(chasingPlayer){

            } else{

                // Wandering ai
                int [] botPosition = FindPlayer(level, botChar);
                Tuple<bool,int> checkMovement = CheckPlayerMovement(botPosition[0], botPosition[1], level, direction);
                bool successful = checkMovement.Item1;

                if(successful){
                    standingOnWhat = MoveCharToPlace(level, botChar, direction, standingOnWhat);
                } else {

                    // Rotate the direction 90 degrees clockwise using a switch
                    switch (direction)
                    {
                        case "up":
                            direction = "right";
                            break;
                        case "right":
                            direction = "down";
                            break;
                        case "down":
                            direction = "left";
                            break;
                        case "left":
                            direction = "up";
                            break;
                    }
                }
                // Create an updated Tuple with the new direction and add it to the updatedBots list
                updatedBots.Add(new Tuple<char, string, char, bool>(botChar, direction, standingOnWhat, chasingPlayer));

            }

            // Replace the original 'bots' list with the updated 'updatedBots' list
            level["bots"] = updatedBots;

        }

    }




    static string GetWhatToDo(){
        bool validOutput = false;
        string? output;
        do{
            output = Console.ReadLine();
            if(output != "") validOutput = true;
        } while (!validOutput);
        return output;
    }


    //asks the player where to go and checks if its valid. If it is, move them there.
    static (int, bool) MoveCharacter(Dictionary<string,object> levels,char playerChar){

            Dictionary<string, object> level = (Dictionary<string, object>)levels[$"level{currentLevel}"];
            char[][] levelLayout = (char[][])level["map"];
            char[][] newLevelLayout = (char[][])level["map"];
        
            DisplayLevel(level,playerChar);
            Console.WriteLine("Where do you want to go?");
            Console.WriteLine("Use the arrow keys or press escape to stop");

            //Moves the character depending on the output
            //Store the keyInfo from player output
            ConsoleKeyInfo keyInfo = GetDirectionFromPlayer();
            bool isTheLocationValid = false;

            //store the player location in location
            int[] playerLocation =  FindPlayer(level, playerChar);
            int newLevelNumber = currentLevel;

            if(keyInfo.Key == ConsoleKey.RightArrow){
                (isTheLocationValid, newLevelNumber) = CheckPlayerMovement(playerLocation[0],playerLocation[1], level, "right");
                if(isTheLocationValid){
                    lastTile = MoveCharToPlace(level, playerChar, "right", lastTile);

                } else if(newLevelNumber != currentLevel){

                    //sets the player location on the old map to " " and adds it to the new map
                    levelLayout[playerLocation[0]][playerLocation[1]] = ' ';
                    SetNewLevelPlayerPosition(levels, newLevelNumber, playerLocation[0], 0, playerChar);
                }
            } else if(keyInfo.Key == ConsoleKey.LeftArrow){
                (isTheLocationValid, newLevelNumber) = CheckPlayerMovement(playerLocation[0], playerLocation[1], level, "left");
                if(isTheLocationValid){

                    lastTile = MoveCharToPlace(level, playerChar, "left", lastTile);

                } else if(newLevelNumber != currentLevel){
                    
                    //sets the player location on the old map to " " and adds it to the new map
                    levelLayout[playerLocation[0]][playerLocation[1]] = ' ';
                    SetNewLevelPlayerPosition(levels, newLevelNumber, playerLocation[0], newLevelLayout[0].Length-1, playerChar);
                }
            } else if(keyInfo.Key == ConsoleKey.DownArrow){
                (isTheLocationValid, newLevelNumber) = CheckPlayerMovement(playerLocation[0],playerLocation[1], level, "down");
                if(isTheLocationValid){

                    lastTile = MoveCharToPlace(level, playerChar, "down", lastTile);

                } else if(newLevelNumber != currentLevel){

                    //sets the player location on the old map to " " and adds it to the new map
                    levelLayout[playerLocation[0]][playerLocation[1]] = ' ';
                    SetNewLevelPlayerPosition(levels, newLevelNumber, 0, playerLocation[1], playerChar);

                }
            } else if(keyInfo.Key == ConsoleKey.UpArrow){
                (isTheLocationValid, newLevelNumber) = CheckPlayerMovement(playerLocation[0], playerLocation[1], level, "up");
                    if(isTheLocationValid){

                    lastTile = MoveCharToPlace(level, playerChar, "up", lastTile);

                } else if(newLevelNumber != currentLevel){
                    
                    //sets the player location on the old map to " " and adds it to the new map
                    levelLayout[playerLocation[0]][playerLocation[1]] = ' ';
                    SetNewLevelPlayerPosition(levels, newLevelNumber, newLevelLayout.Length, playerLocation[1] , playerChar);
                }

            } else if(keyInfo.Key == ConsoleKey.Escape){
                return (currentLevel, false);
            }

            if (newLevelNumber != currentLevel)
            {
                return (newLevelNumber, true);
            }
        

        return (currentLevel, true);
    }

static char MoveCharToPlace(Dictionary<string, object> level, char thingToMove, string directon, char whatToReplaceWith){
            char lastTile = ' ';
            char[][] levelLayout = (char[][])level["map"];
            int[] thingToMoveLocation =  FindPlayer(level, thingToMove);

            if(directon == "right"){
                    lastTile = levelLayout[thingToMoveLocation[0]][thingToMoveLocation[1]+1];
                    levelLayout[thingToMoveLocation[0]][thingToMoveLocation[1]+1] = thingToMove;
            
            } else if(directon == "left"){
                    lastTile = levelLayout[thingToMoveLocation[0]][thingToMoveLocation[1]-1];
                    levelLayout[thingToMoveLocation[0]][thingToMoveLocation[1]-1] = thingToMove;

            } else if(directon == "down"){
                    lastTile = levelLayout[thingToMoveLocation[0]+1][thingToMoveLocation[1]];
                    levelLayout[thingToMoveLocation[0]+1][thingToMoveLocation[1]] = thingToMove;


            } else if(directon == "up"){
                    lastTile = levelLayout[thingToMoveLocation[0]-1][thingToMoveLocation[1]];
                    levelLayout[thingToMoveLocation[0]-1][thingToMoveLocation[1]] = thingToMove;
            }

            levelLayout[thingToMoveLocation[0]][thingToMoveLocation[1]] = whatToReplaceWith;
            return lastTile;
}



static void SetNewLevelPlayerPosition(Dictionary<string, object> levels, int newLevelNumber, int y, int x, char playerChar)
{
    // Get the new level
    Dictionary<string, object> newLevel = (Dictionary<string, object>)levels[$"level{newLevelNumber}"];

    // Get the map of the new level
    char[][] newLevelLayout = (char[][])newLevel["map"];

    // Set the player's character at the specified position
    newLevelLayout[y][x] = playerChar;
}

    //returns the posisiton of the player in int[y,x] format
    static int[] FindPlayer(Dictionary<string,object> level, char playerChar){

        //Gets the map from the current level
        char[][] levelLayout = (char[][])level["map"];

        for (int i = 0; i < levelLayout.Length; i++){
            for (int j = 0; j < levelLayout[i].Length; j++){
                if(levelLayout[i][j] == playerChar){
                    return new int[2] {i, j};
                }
            }
        }
        return new int[2] {-1,-1};
    }

    //get the direction from the player by using the arrow keys and output the key used.
    static ConsoleKeyInfo GetDirectionFromPlayer()
    {
        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow ||
                keyInfo.Key == ConsoleKey.DownArrow ||
                keyInfo.Key == ConsoleKey.RightArrow ||
                keyInfo.Key == ConsoleKey.LeftArrow ||
                keyInfo.Key == ConsoleKey.Escape)
            {
                return keyInfo;
            }
            else
            {
                Console.WriteLine("Invalid input. Please use the arrow keys to choose a direction or Esc to cancel.");
            }
        } while (true);
    }


    //inputs y and x position of object, level, direction object is trying to go.
    //outputs, is it valid?, level to swap to if you want to do that 
    static Tuple<bool,int> CheckPlayerMovement(int y , int x, Dictionary<string, object> level, string direction)
        {
            char[][] levelLayout = (char[][])level["map"];
            List<Tuple<string, int>> options = (List<Tuple<string, int>>)level["directions"];

            if (direction == "down")//Do this on each one. If the direction you are moving takes you out of bounds, return false. then check if its not a ' '.
            {
                if (y + 1 < levelLayout.Length)
                {
                    if (levelLayout[y+1][x] == 'x'){
                        return Tuple.Create(false, currentLevel);
                    } else {return Tuple.Create(true, currentLevel);}
                }
                else
                {   

                    return Tuple.Create(false, options.Find(d => d.Item1 == "south").Item2);
                }
            }
            else if (direction == "up")
            {
                if (y - 1 >= 0)
                {
                    if (levelLayout[y-1][x] == 'x'){
                        return Tuple.Create(false, currentLevel);;
                    } else {return Tuple.Create(true, currentLevel);}
                }
                else
                {
                    return Tuple.Create(false, options.Find(d => d.Item1 == "north").Item2);
                }
            }
            else if (direction == "left")
            {
                if (x - 1 >= 0)
                {
                    if (levelLayout[y][x-1] == 'x'){
                        return Tuple.Create(false, currentLevel);
                    } else {return Tuple.Create(true, currentLevel);}
                }
                else
                {
                    return Tuple.Create(false, options.Find(d => d.Item1 == "west").Item2);
                }
            }
            else if (direction == "right")
            {
                if (x + 1 < levelLayout[y].Length)
                {
                    if (levelLayout[y][x+1] == 'x'){
                        return Tuple.Create(false, currentLevel);
                    } else {return Tuple.Create(true, currentLevel);}
                }
                else
                {
                    return Tuple.Create(false, options.Find(d => d.Item1 == "east").Item2);
                }
            }
            else
            {
                return Tuple.Create(false, currentLevel);
            }
        }
    

    // Takes the level and outputs the text
    static string GetLevelText(Dictionary<string, object> level)
    {
        if (level.ContainsKey("text"))
        {
            List<string> text = (List<string>)level["text"];
            return string.Join("\n", text);
        } else {

            return "data not found";
        }
    }



    static void DisplayLevel(Dictionary<string, object> level,char playerChar){

        Console.Clear();
        char[][] map = (char[][])level["map"];

        // Print the text
        string text = GetLevelText(level);
        Console.WriteLine(text);

        // Print the level layout
        Console.WriteLine("\n");
        foreach (char[] row in map)
        {
            foreach (char tile in row){
                if(tile == 'x'){

                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ");

                } else
                if(tile == playerChar){
                    if(lastTile == ' '){
                        Console.BackgroundColor = ConsoleColor.Black;
                    } else if (lastTile == 'w'){
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    
                    Console.Write($"()");

                    

                } else
                if(tile == 'w'){
                    
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Write($"  ");

                }
                 else{
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($"{tile} ");
                }
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Black;
    }
}