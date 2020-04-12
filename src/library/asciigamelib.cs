using System;

namespace ascigame
{
    class engine
    {

        int playerX = 5;
        int playerY = 5;
        static string map1;
        static string map1stats;
    
        public void Getmap(string mapfile, string mapInfo)
        {
            
            map1 = System.IO.File.ReadAllText(mapfile);
            map1stats = System.IO.File.ReadAllText(mapInfo);
            
            
            
        }
        public string test()
        {
            return "iwygdyuweg";
        }
        static string[] map1infoarr;
        static string[] map1Arr;
        //this function draws the map after the Getmap function is called
        public void Draw_map()
        {
            //split the map info into an array 
            map1infoarr = map1stats.Split(',');
            //get the amount of columbs in the map
            int columbs = int.Parse(map1infoarr[0]);
            

            //for drawing things get the cursor coordinates before they are moved
            int Previouse_cursor_x = Console.CursorLeft;
            int Previouse_cursor_y = Console.CursorTop;
            //split the map into an array for example *|*|* will turn into ["*", "*", "*"]
            map1Arr = map1.Split('|');
            //This will get the amount of lines from the map info
            int lines = int.Parse(map1infoarr[1]); ;
            
            int line = 0;
            int columb = 0;
            int i = 0;
            //go through and draw the map
            while (columb <= columbs && line <= lines)
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
                    //write the charecter
                    Console.Write(current_char);
                    //go to next columb
                    columb++;
                }
               

                //if the all the columbs in the line are completed then go to the next line unless your on the last line
                if (columb == columbs && line < lines)
                {
                    line++;
                  
                    columb = 0;
               
               
                }
                if (columb == columbs && line == lines)
                {
                    Console.SetCursorPosition(Previouse_cursor_x, Previouse_cursor_y);
                }
                
            }

            
            

        }
        public void setColor(string color)
        {
            
            if (color == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
        public void DrawPlayer(int x, int y)
        {
         
            playerX = x;
            playerY = y;
            int Previouse_cursor_x = Console.CursorLeft;
            int Previouse_cursor_y = Console.CursorTop;

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(playerX, playerY);
            Console.Write("##");
            
         
        }
    }
}
