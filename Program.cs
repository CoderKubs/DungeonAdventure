



//Level 1 dictionary holding the level info
using System.Runtime.ExceptionServices;
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
                    { "options", new List<Tuple<string, int>>
                        {
                            Tuple.Create("north", 2),
                            Tuple.Create("south", 3),
                            Tuple.Create("east", 4),
                            Tuple.Create("west", 5),
                            Tuple.Create("n", 2),
                            Tuple.Create("s", 1),
                            Tuple.Create("e", 4),
                            Tuple.Create("w", 5),
                            Tuple.Create("gate", 2),
                        }
                    },
                    { "map", new char[][]
                        {
                            new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                            new char[] { 'x', 'x', ' ', 'x', ' ', ' ', 'x', 'x', 'x', 'x', 'x', 'x' },
                            new char[] { 'x', 'x', ' ', 'x', 'x', ' ', 'x', ' ', ' ', ' ', 'x', 'x' },
                            new char[] { 'x', 'x', ' ', ' ', ' ', ' ', ' ', ' ', 'x', 'x', 'x', 'x' },
                            new char[] { 'x', 'x', ' ', ' ', ' ', 'x', 'x', ' ', ' ', ' ', ' ', 'x' },
                            new char[] { 'x', 'x', ' ', ' ', ' ', 'x', 'x', 'x', 'x', 'x', ' ', 'x' },
                            new char[] { 'x', 'x', ' ', ' ', ' ', 'x', 'x', 'x', 'x', 'x', ' ', 'x' },
                            new char[] { 'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x' },
                            new char[] { 'x', ' ', 'x', 'x', '@', 'x', 'x', 'x', 'x', 'x', 'x', 'x' },
                            new char[] { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x' }
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
            int[] playerlocation =  FindPlayer(levelLayout);

            if(keyInfo.Key == ConsoleKey.RightArrow){
                isTheLocationValid = CheckPlayerMovement(playerlocation[0],playerlocation[1]+1, levelLayout);
                if(isTheLocationValid){
                    levelLayout[playerlocation[0]][playerlocation[1]] = ' ';
                    levelLayout[playerlocation[0]][playerlocation[1]+1] = '@';
                }
            } else if(keyInfo.Key == ConsoleKey.LeftArrow){
                isTheLocationValid = CheckPlayerMovement(playerlocation[0],playerlocation[1]-1, levelLayout);
                if(isTheLocationValid){
                    levelLayout[playerlocation[0]][playerlocation[1]] = ' ';
                    levelLayout[playerlocation[0]][playerlocation[1]-1] = '@';
                }
            } else if(keyInfo.Key == ConsoleKey.DownArrow){
                isTheLocationValid = CheckPlayerMovement(playerlocation[0]+1,playerlocation[1], levelLayout);
                if(isTheLocationValid){
                    levelLayout[playerlocation[0]][playerlocation[1]] = ' ';
                    levelLayout[playerlocation[0]+1][playerlocation[1]] = '@';
                }
            } else if(keyInfo.Key == ConsoleKey.UpArrow){
                isTheLocationValid = CheckPlayerMovement(playerlocation[0]-1,playerlocation[1], levelLayout);
                    if(isTheLocationValid){
                    levelLayout[playerlocation[0]][playerlocation[1]] = ' ';
                    levelLayout[playerlocation[0]-1][playerlocation[1]] = '@';
                }
            } else if(keyInfo.Key == ConsoleKey.Escape){
                moving = false;
            }

        } while(moving);

    }

    //returns the posisiton of the player in int[x,y] format
    static int[] FindPlayer(char[][] levelLayout){
        for (int i = 0; i < levelLayout.Length; i++){
            for (int j = 0; j < levelLayout[i].Length; j++){
                if(levelLayout[i][j] == '@'){
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
    static bool CheckPlayerMovement(int x, int y, char[][] levelLayout){
        if(levelLayout[x][y] == ' '){
            return true;
        } else {
            return false;
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
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(tile);
                    Console.ForegroundColor = ConsoleColor.White;
                } else
                if(tile == playerChar){
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(tile);
                    Console.ForegroundColor = ConsoleColor.White;
                } else{
                    Console.Write(tile);
                }
            }
            Console.WriteLine();
        }
    }
}