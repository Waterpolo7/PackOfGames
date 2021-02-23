
using System;

namespace Chess
{


    class MainChess
    {
       
        
        
        
        

        static void Main(string[] args)
        {
            int[] ikaron = new int[] {3, 5, 2, 7};
            int[] okarin = new int[ikaron.Length];
            int[] serati = new int[] {17, 90, 34, 12, 677, 45, 2};
            
            int[] matari = MergeArrays(ikaron, serati);
            
            
            /*OutputIndex(matari);
            okarin = CopyArray(ikaron);
            OutputIndex(ikaron); 
            
            OutputIndex(okarin); 
            */


            OneDChess.Start();
            OneDChess.Play();
            
        }

        

        static void OutputIndex(int[] x){
            Console.WriteLine("Contains of this index are: ");
            for(int i = 0; i < x.Length; i++){
                Console.Write("-{" + x[i].ToString() + "}-");
            }
            Console.WriteLine("Contains of this index reversed are: ");
            for(int j = x.Length; j > 0; j--){
                Console.Write("-[" + x[j - 1].ToString() + "]-");
            }
        }
        static int IndexSum(int[] x)
        {
            int y = new int();
            for (int i = 0; i < x.Length; i++){
                y += x[i];
            }

            return y;

        }
        static int[] CopyArray(int[] x){
            int[] y = new int[x.Length];
            
            for(int i = 0; i < x.Length; i++){
                y[i] = x[i];
            }

            return y;
        }
        static int[] MergeArrays(int[] x, int[] y){
            int[] z = new int[x.Length + y.Length];
            for(int i = 0; i < x.Length; i++){
                z[i] = x[i];
            }
            for (int j = x.Length; j < y.Length; j++){
                z[j] = y[y.Length - 1];
            }
            return z;
        }

        //OneDChess

            
        
        //End OneDChess
    }
    static class OneDChess{
            static int[] piecePlaces;
            static bool isPink = true;

            static string[] pieces = new string[] {" ", "H", "R", "K", "h", "r", "k"};
            
            static int width = 8;
            public static bool playing = true;

            public static void Start(){
                piecePlaces = new int[]{3, 1, 2, 0, 0, 5, 4, 6};
            }

            public static void Play(){
                
                while(playing){
                    if(isPink){
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if(!isPink){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Render(width, piecePlaces);
                    ChangePieces(Input());
                    isPink = !isPink;
                }
                
            }
            public static void Render(int width, int[] piecePlaces){
                
                Console.WriteLine("-----");
                for(int i = 0; i < width; i++){
                    Console.WriteLine("|" +(i + 1).ToString() + " " + pieces[piecePlaces[i]] + "|");
                }
                Console.WriteLine("-----");
            }
            public static int[] Input(){
                
                string[] x = new string[2]; 
                int[] y = new int[2];
                
                Console.WriteLine("Start Pos: ");
                x[0] = Console.ReadLine();
                Console.WriteLine("End Pos: ");
                x[1] = Console.ReadLine();

                

                for(int i = 0; i < x.Length; i++){
                    
                    y[i] = Convert.ToInt32(x[i]);
                    
                    y[i] -= 1;
                    
                }

                if(IsAir(y)){
                    Console.WriteLine("Error 003: This is air");
                    Play();
                }

                if(isPink != IsUp(y[0], pieces)){
                    Console.WriteLine("Error 004: This is the other player's piece");
                    Play();
                    return null;
                }
                else{
                    return y;
                }
                
                
                
                
                
                
                
            }
            public static void ChangePieces(int[] x){
                piecePlaces[x[1]] = piecePlaces[x[0]];
                piecePlaces[x[0]] = 0;

                if(IsLegal(piecePlaces[x[0]], x)){
                    Render(8, piecePlaces);
                }
                else{
                    Console.WriteLine("Error 005: Illegal Move");
                    Play();
                }

                
            }

            public static bool IsUp(int positionToCheck, string[] pieces){
                bool x;
                
                x = Char.IsUpper(Convert.ToChar(pieces[piecePlaces[positionToCheck]]));
                //Console.WriteLine(x);

                

                return x;
            }
            public static bool IsAir(int[] inputGiven){
                if(piecePlaces[inputGiven[0]] <= 0){
                    return true;
                }
                else{
                    return false;
                }
            }

            public static void Quit(){
                Console.WriteLine("Quit");
            }

            public static bool IsLegal(int value, int[] valueOfInput){
                //Horse check
                if(value == 1){
                    if(valueOfInput[1] == valueOfInput[0] + 2 ||valueOfInput[1] == valueOfInput[0] - 2){
                        return true;
                    }
                }
                else if(value == 4){
                    if(valueOfInput[1] == valueOfInput[0] + 2 ||valueOfInput[1] == valueOfInput[0] - 2){
                        return true;
                    }
                }
                else{
                    Console.WriteLine("Error 005: Illegal Move");
                    Play();
                    return false;
                }
                
                
                
                return false;
                
            }
    }

    
}
