



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
    public static List<CharacterStats> fightingBots = new List<CharacterStats>();
    public static int currentLevel;
    public static char lastTile = ' ';

    public static (int health, int strength) playerStats = (100, 50);
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
                            { "bots", new List<CharacterStats>()
                                {
                                    new CharacterStats { Char = '1', Direction = "up", StandingOn = ' ', IsChasing = false, Health = 50, Strength = 10 },
                                    new CharacterStats { Char = '2', Direction = "right", StandingOn = ' ', IsChasing = false,  Health = 50, Strength = 10 },
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
                            },

                            { "bots", new List<Tuple<char, string, char, bool, (int, int)>>()
                                {

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
                            },
                            { "bots", new List<Tuple<char, string, char, bool, (int, int)>>()
                                {

                                }
                            }
                            
                        }

                    }
                };



        // Accessing the "text" key in level1 dictionary;

        currentLevel = 1;
        Dictionary<string, object> level;

        char playerChar = 'o';
        bool moving = false;
        bool fighting = false;
        char botChar = '.';

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

            if (fighting == false){
                //asks if they want to move, then move
                moving = false;
                Console.WriteLine("What do you want to do?");
                string output = GetWhatToDo();

                if(output.ToLower() == "move"){
                    //Enters move character mode and it wont exit until you press escape.
                    moving = true;
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
                        fighting = CheckIfBotNearby(level, playerChar);
                        if(fighting){
                            break;
                        }
                    }while(moving);
                
                }
            } else { //Fighting = true!
                //repeat until not fighting
                do{
                    fighting = Fighting(level, playerChar);
                }while(fighting);
            }


        } while (true);
    }

    //What happens during the fighting stage
    static bool Fighting(Dictionary<string,object> level, char playerChar){

        Console.Clear();
        DisplayLevel(level, playerChar);

        //Show the stats of you and the enemy
        Console.WriteLine("\n        FIGHT!");
        Console.WriteLine("You:");
        Console.WriteLine($"Health:{playerStats.health}     Power:{playerStats.strength}");

        
        //display each enemys stats
        foreach(CharacterStats bot in fightingBots){

            char botChar = bot.Char;
            int indexOfBot = fightingBots.FindIndex(bot => bot.Char == botChar);
            int botHealth = fightingBots[indexOfBot].Health;
            int botStrength = fightingBots[indexOfBot].Strength;


            Console.WriteLine($"\nEnemy: {indexOfBot+1}");
            Console.WriteLine($"health:{botHealth}     Power:{botStrength}");
        }


        // do the players turn, check if he won, if not, do the bots turn
        bool fighting = PlayerTurn(level);
        if (!fighting){
            return fighting;
        }
        BotTurn();
        return fighting;
    }

    //The bots turn for attacking
    static void BotTurn(){

    }

static bool PlayerTurn(Dictionary<string, object> level)
{
    bool fighting = true;
    Console.WriteLine("\nWhat action do you want to do?");
    string input = GetWhatToDo();

    if (input.ToLower() == "attack")
    {
        if (fightingBots.Count == 1)
        {
            CharacterStats enemy = fightingBots[0]; // Get the enemy into a variable
            enemy.Health -= playerStats.strength;   // Modify the enemy's health
            fightingBots[0] = enemy; // Put the modified enemy back into the list

            if (enemy.Health <= 0)
            {
                MoveCharToPlace(level, enemy.Char, "gone", ' ');
                fightingBots.Remove(enemy);
                fighting = false;
                 if (level.ContainsKey("bots") && level["bots"] is List<CharacterStats> botsList)
                        {
                            int indexToUpdate = 0; // Adjust for 0-based index
                            CharacterStats botToUpdate = botsList[indexToUpdate];
                            botToUpdate.Health = 0; // Update the bot's health

                            // Assign the modified bot back to the list
                            botsList[indexToUpdate] = botToUpdate;

                            level["bots"] = botsList; // Update the list in the dictionary
                        }
            }
        }
        else
        {
            Console.WriteLine("Which enemy do you want to attack?");
            int whichBotToFight;

            do
            {
                input = GetWhatToDo();

                if (int.TryParse(input, out whichBotToFight) && whichBotToFight >= 1 && whichBotToFight <= fightingBots.Count)
                {
                    CharacterStats enemy = fightingBots[whichBotToFight - 1]; // Get the enemy into a variable
                    enemy.Health -= playerStats.strength;   // Modify the enemy's health
                    fightingBots[whichBotToFight - 1] = enemy; // Put the modified enemy back into the list

                    if (enemy.Health <= 0)
                    {
                        fightingBots.RemoveAt(whichBotToFight - 1);

                        if (level.ContainsKey("bots") && level["bots"] is List<CharacterStats> botsList)
                        {
                            int indexToUpdate = whichBotToFight - 1; // Adjust for 0-based index
                            CharacterStats botToUpdate = botsList[indexToUpdate];
                            botToUpdate.Health = 0; // Update the bot's health

                            // Assign the modified bot back to the list
                            botsList[indexToUpdate] = botToUpdate;

                            level["bots"] = botsList; // Update the list in the dictionary
                        }
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer between 1 and " + fightingBots.Count + ".");
                }

            } while (true);
        }
    }
    else if (input.ToLower() == "run")
    {
        // Handle the "run" action here
    }

    return fighting;
}



    //A method that checks if any bots are near the player, Returns true or false
    static bool CheckIfBotNearby(Dictionary<string,object> level,char playerChar){

        bool fighting = false;

        //find player position
        int[] playerPosition = FindPlayer(level, playerChar);

        //set bots to a list of bots in the current level
        List<CharacterStats> bots = (List<CharacterStats>)level["bots"];

        foreach(CharacterStats bot in bots){

            //Set botChar to the character that the bot represents
            char botChar = bot.Char;

            int[] botPosition = FindPlayer(level, botChar);

            int horizontalDistance = Math.Abs(botPosition[0] - playerPosition[0]);
            int verticalDistance = Math.Abs(botPosition[1] - playerPosition[1]);

            // Check if the bot is within one space of the player
           if ((horizontalDistance == 1 && verticalDistance == 0) || (horizontalDistance == 0 && verticalDistance == 1))
            {
                fightingBots.Add(bot);
                fighting = true;
            }
        }

        return fighting;
    }




    static void MoveBots(Dictionary<string,object> level, char playerChar){
        
        //Create a new list that will replace the bots list but with new positions
        List<CharacterStats> updatedBots = new List<CharacterStats>();
        
        List<CharacterStats> bots = (List<CharacterStats>)level["bots"];
        foreach(CharacterStats bot in bots){
            if (bot.Health != 0){
                //break apart the bots info
                string direction = bot.Direction;
                char standingOnWhat = bot.StandingOn;
                bool chasingPlayer = bot.IsChasing;
                char botChar = bot.Char;

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
                        updatedBots.Add(new CharacterStats
                    {
                        Char = botChar,
                        Direction = direction,
                        StandingOn = standingOnWhat,
                        IsChasing = chasingPlayer,
                        Health = bot.Health, // You can access health and strength directly from the bot object
                        Strength = bot.Strength
                    });

                }

                // Replace the original 'bots' list with the updated 'updatedBots' list
                level["bots"] = updatedBots;
            }
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


public struct CharacterStats
{
    public char Char { get; set; }
    public string Direction { get; set; }
    public char StandingOn { get; set; }
    public bool IsChasing { get; set; }
    public int Health { get; set; }

    public int Strength { get; set; }



    // Add constructor and methods as needed
    //Make sure to change the MoveBots method to reflect changes
}