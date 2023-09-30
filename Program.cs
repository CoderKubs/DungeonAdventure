



//Level 1 dictionary holding the level info
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Xml;

public class Program
{



    public static void Main(){

        
        Dictionary<string, object> level1 = new Dictionary<string, object>
                {
                    { "text", new List<string>
                        {
                            "\nYou wake up in a dark dungeon",
                        }
                    },
                    { "map", new char[][]
                        {
                            new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                            new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', ' ', ' ', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x'},
                            new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', ' ', 'o', 'x'},
                            new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', ' ', 'x', 'x'},
                            new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', ' ', 'x', 'x'},
                            }

                    }
                };

        Dictionary<string, object> level2 = new Dictionary<string, object>
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
                            new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', ' ', ' ', ' ', ' ', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x'},
                            new char[] { 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x'},
                            new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', ' ', 'o', 'x'},
                            new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', 'x', 'x', 'x'},
                            new char[] { 'x', 'x', 'x', 'x', 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x'},
                            }

                    }
                };


        // Accessing the "text" key in level1 dictionary
        List<string> level1Text = (List<string>)level1["text"];

        // Accessomg the "map" key in level dictionary
        char[][] level1Layout = (char[][])level1["map"];
        char[][] levelLayout = level1Layout;

        char playerChar = 'o';

        //
        //Main game
        //
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        do{
            DisplayLevel(level1Layout,level1Text,playerChar);
            //asks if they want to move and move
        
            Console.WriteLine("What do you want to do?");
            string output = GetWhatToDo();
            if(output.ToLower() == "move"){
                //Enters move character mode and it wont exit until you press escape.
                MoveCharacter(levelLayout,level1Text,playerChar);
            }

        } while (true);
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
    static void MoveCharacter(char[][] levelLayout, List<string> levelText,char playerChar){
        bool moving = true;
        do{
            DisplayLevel(levelLayout,levelText,playerChar);
            Console.WriteLine("Where do you want to go?");
            Console.WriteLine("Use the arrow keys or press escape to stop");

            //Moves the character depending on the output
            //Store the keyInfo from player output
            ConsoleKeyInfo keyInfo = GetDirectionFromPlayer();
            bool isTheLocationValid = false;

            //store the player location in location
            int[] playerLocation =  FindPlayer(levelLayout, playerChar);

            if(keyInfo.Key == ConsoleKey.RightArrow){
                isTheLocationValid = CheckPlayerMovement(playerLocation[0],playerLocation[1], levelLayout, "right");
                if(isTheLocationValid){
                    levelLayout[playerLocation[0]][playerLocation[1]] = ' ';
                    levelLayout[playerLocation[0]][playerLocation[1]+1] = playerChar;
                }
            } else if(keyInfo.Key == ConsoleKey.LeftArrow){
                isTheLocationValid = CheckPlayerMovement(playerLocation[0],playerLocation[1], levelLayout, "left");
                if(isTheLocationValid){
                    levelLayout[playerLocation[0]][playerLocation[1]] = ' ';
                    levelLayout[playerLocation[0]][playerLocation[1]-1] = playerChar;
                }
            } else if(keyInfo.Key == ConsoleKey.DownArrow){
                isTheLocationValid = CheckPlayerMovement(playerLocation[0],playerLocation[1], levelLayout, "down");
                if(isTheLocationValid){
                    levelLayout[playerLocation[0]][playerLocation[1]] = ' ';
                    levelLayout[playerLocation[0]+1][playerLocation[1]] = playerChar;
                }
            } else if(keyInfo.Key == ConsoleKey.UpArrow){
                isTheLocationValid = CheckPlayerMovement(playerLocation[0],playerLocation[1], levelLayout, "up");
                    if(isTheLocationValid){
                    levelLayout[playerLocation[0]][playerLocation[1]] = ' ';
                    levelLayout[playerLocation[0]-1][playerLocation[1]] = playerChar;
                }
            } else if(keyInfo.Key == ConsoleKey.Escape){
                moving = false;
            }

        } while(moving);

    }

    //returns the posisiton of the player in int[y,x] format
    static int[] FindPlayer(char[][] levelLayout, char playerChar){
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

    // Input an X and Y and see if the player can move there
    static bool CheckPlayerMovement(int y, int x, char[][] levelLayout, string direction){
        {
            if (direction == "down")//Do this on each one. If the direction you are moving takes you out of bounds, return false. then check if its not a ' '.
            {
                if (y + 1 < levelLayout.Length)
                {
                    if (levelLayout[y+1][x] != ' '){
                        return false;
                    } else {return true;}
                }
                else
                {
                    return false;
                }
            }
            else if (direction == "up")
            {
                if (y - 1 >= 0)
                {
                    if (levelLayout[y-1][x] != ' '){
                        return false;
                    } else {return true;}
                }
                else
                {
                    return false;
                }
            }
            else if (direction == "left")
            {
                if (x - 1 >= 0)
                {
                    if (levelLayout[y][x-1] != ' '){
                        return false;
                    } else {return true;}
                }
                else
                {
                    return false;
                }
            }
            else if (direction == "right")
            {
                if (x + 1 < levelLayout[y].Length)
                {
                    if (levelLayout[y][x+1] != ' '){
                        return false;
                    } else {return true;}
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    static void DisplayLevel(char[][]map, List<string> text,char playerChar){
        Console.Clear();
        // Print the text
        foreach (string line in text)
        {
            Console.WriteLine(line);
        }

        // Print the level layout
        Console.WriteLine("Level Layout:");
        foreach (char[] row in map)
        {
            foreach (char tile in row){
                if(tile == 'x'){
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");

                } else
                if(tile == playerChar){
                    
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(tile);

                    

                } else{
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(tile);
                }
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Black;
    }
}