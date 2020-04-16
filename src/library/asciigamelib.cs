using System;
using System.Threading;
namespace ascigame
{
    class engine
    {
        public static int Points = 0;
        public static int playerX = 5;
        public static int playerY = 5;
        public static bool ifmap = false;
        public static bool ifplayer = false;
        public static string maincolor;
        public static string map1;
        public static string map1stats;
        public static bool ifstartup = true;
        public static int columbs = 66;
        public static string[] map1infoarr = {"000", "000"};
        public static string[] map1Arr = { "000", "000" };
        public static int lines = 18;
        public static int Previouse_cursor_x;
        public static int Previouse_cursor_y;
        public void startup()
        {
            
            Console.Title = "Unnamed asciigame project";
            Console.Clear();
            Console.WriteLine(" Powered by ");
            Console.WriteLine("   +---------+");
            Console.WriteLine("  /         /|");
            Console.WriteLine(" /         / |");
            Console.WriteLine("+---------+  |");
            Console.WriteLine("|         |  |");
            Console.WriteLine("|asciigame|  +");
            Console.WriteLine("|         | /");
            Console.WriteLine("|         |/");
            Console.WriteLine("+---------+");
            Thread.Sleep(1000);


        }
        public void clear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("______________________________________________________________________________");
            Console.Clear();
        }
        public void setTitle(string title)
        {
            Console.Title = title;
        }
        public void Getmap(string mapfile, string mapInfo)
        {
            if (ifstartup == true)
            {
                startup();
                ifstartup = false;
            }

            map1 = System.IO.File.ReadAllText(mapfile);
            map1stats = System.IO.File.ReadAllText(mapInfo);
            //split the map info into an array 
            map1infoarr = map1stats.Split(',');

            //get the amount of columbs in the map
            columbs = int.Parse(map1infoarr[0]);
            //This will get the amount of lines from the map info
            lines = int.Parse(map1infoarr[1]);



        }



        //this function draws the map after the Getmap function is called
        public void Draw_map()
        {
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("______________________________________________________________________________");
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            if (maincolor == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                
            }
            if (ifstartup == true)
            {
                startup();
                ifstartup = false;
            }
            
            
            ifmap = true;



            //for drawing things get the cursor coordinates before they are moved
             Previouse_cursor_x = Console.CursorLeft;
             Previouse_cursor_y = Console.CursorTop;
            
            //split the map into an array for example *|*|* will turn into ["*", "*", "*"]
            map1Arr = map1.Split('|');

            
            int line = 0;

            int columb = 0;
            int i = 0;
            Console.SetCursorPosition(0, 0);
      
            //go through and draw the map
            while (columb < columbs && line < lines)
            {

                
                if (columb < columbs && line < lines && i < map1Arr.Length)
                {
                   
                    
                    i++;
                    //get the charecter that needs to be drawn
                    string current_char = map1Arr[i];
                    //if the charecter is a star then set the color to green
                    if (current_char == "*")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Green;



                    }
                    //if the charecter is a period then set the color to dark red(brown)
                    if (current_char == ".")
                    {
                        
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    int x = Console.CursorLeft;
                    int y = Console.CursorTop;
                    if (x == playerX && y == playerY)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("@");
                    }
                    else
                    {

                        //write the charecter
                        Console.Write(current_char);
                    }
                    //go to next columb
                    columb++;
                }
               

                //if the all the columbs in the line are completed then go to the next line unless your on the last line
                if (columb == columbs && line < lines)
                {
                    line++;
                    Console.CursorLeft = 0;
                    
                    columb = 0;
               
               
                }

                
            }

            
            

        }
        public void setColor(string color)
        {
            if (ifstartup == true)
            {
                startup();
                ifstartup = false;
            }
            if (color == "red")
            {
                maincolor = "red";
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
        public void DrawPlayer(int x, int y)
        {
            
            ifplayer = true;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("______________________________________________________________________________");
            Console.Clear();


   
            if (maincolor == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (ifstartup == true)
            {
                startup();
                ifstartup = false;
                
            }

            playerX = x;
            playerY = y;
            int Previouse_cursor_x = Console.CursorLeft;
            int Previouse_cursor_y = Console.CursorTop;

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(playerX, playerY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
          
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("@");

        

        }
        public void MovePlayer(int x, int y)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
     
           
            playerX = x;
            playerY = y;
            Draw_map();

        }
        public void wasdMovement()
        {
            //create the key object
            ConsoleKeyInfo cki;

            cki = Console.ReadKey();
            //check for wasd keypresses
            if (cki.Key == ConsoleKey.W)
            {
                
                MovePlayer(playerX, playerY - 1);


            }
            if (cki.Key == ConsoleKey.A)
            {
                MovePlayer(playerX - 1, playerY);
            }
            if (cki.Key == ConsoleKey.S)
            {
                MovePlayer(playerX, playerY + 1);

            }
            if (cki.Key == ConsoleKey.D)
            {
                MovePlayer(playerX + 1, playerY);
            }
        }
        public void setPlayerCollisionControll(string type, int x, int y)
        {
            if (playerX == x && playerY == y)
            {
                if (type == "gameover")
                {

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"
 _____                         ____                 
/ ____|                       / __ \                
| |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
| | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|
| |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   
\_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   ");

                    Console.WriteLine("To Continue please use the move keys");
                }



                if (type == "Point")
                {
                    Points++;
                }
            }
        }

    }
}
