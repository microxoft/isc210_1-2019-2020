using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Clase1_TicTacToe
{
    public enum GameState
    {
        Menu,
        Starting,
        Playing,
        Gameover
    }

    public enum GameOverState
    {
        GameOn,
        Player1,
        Player2,
        Tie
    }

    public class Game
    {
        public int PlayedTurns { get; set; }
        public GameState CurrentState { get; set; }
        public char[,] Board { get; set; }
        public bool CurrentPlayer { get; set; }
    }

    class Program
    {
        const int FPSTIME = 33, LEFTMARGIN = 5, COLSIZE = 10, TOPMARGIN = 3, ROWSIZE = 4;
        static int tmp;
        public static Game CurrentGame;
        static Thread _inputThread;
        static char _tmpPlayer;

        public static void InitializeGame()
        {
            CurrentGame = new Game();
            CurrentGame.Board = new char[3, 3];
            CurrentGame.CurrentState = GameState.Menu;
            CurrentGame.PlayedTurns = 0;

            _inputThread = new Thread(GetInput);
            _inputThread.Start();
        }

        static void Main(string[] args)
        {
            InitializeGame();
            
            while(CurrentGame.CurrentState != GameState.Gameover)
            {
                switch(CurrentGame.CurrentState)
                {
                    case GameState.Menu:
                        ShowMenu();
                        break;
                    case GameState.Starting:
                        ShowFrame(true);
                        break;
                    case GameState.Playing:
                        // Asumiendo que el hilo de GetInput() hace su trabajo de capturar y actualizar el comportamiento del juego,
                        // nos toca verificar si la lógica del juego sufre algún cambio, para finalmente renderizar.

                        ShowFrame(false);
                        ShowBoard();

                        CurrentGame.CurrentState = GameState.Gameover;
                        switch (CheckGameOver())
                        {
                            case GameOverState.Player1:
                                Console.WriteLine("¡ Ganó el jugador 1 !");
                                break;
                            case GameOverState.Player2:
                                Console.WriteLine("¡ Ganó el jugador 2 !");
                                break;
                            case GameOverState.Tie:
                                Console.WriteLine("¡ Es un empate !");
                                break;
                            default:
                                CurrentGame.CurrentState = GameState.Playing;
                                break;
                        }
                        
                        break;
                }

                Thread.Sleep(FPSTIME);
            }

            Console.WriteLine("¡Gracias por jugar!\n\nPresione una tecla para salir.");
            FinalizeGame();

            Console.ReadKey();
        }

        static GameOverState CheckGameOver()
        {
            _tmpPlayer = '\0';
            // Si ganó el jugador 1 o 2, se retorna lo correspondiente.
            for(tmp = 0; tmp < 3; tmp++)
            {
                if (CurrentGame.Board[tmp, 0] != '\0' && CurrentGame.Board[tmp, 0] == CurrentGame.Board[tmp, 1] && CurrentGame.Board[tmp, 0] == CurrentGame.Board[tmp, 2])
                    _tmpPlayer = CurrentGame.Board[tmp, 0];
                if (CurrentGame.Board[0, tmp] != '\0' && CurrentGame.Board[0, tmp] == CurrentGame.Board[1, tmp] && CurrentGame.Board[0, tmp] == CurrentGame.Board[2, tmp])
                    _tmpPlayer = CurrentGame.Board[0, tmp];
            }

            if (CurrentGame.Board[0, 0] != '\0' && CurrentGame.Board[0, 0] == CurrentGame.Board[1, 1] && CurrentGame.Board[0, 0] == CurrentGame.Board[2, 2])
                _tmpPlayer = CurrentGame.Board[0, 0];

            if (CurrentGame.Board[0, 2] != '\0' && CurrentGame.Board[0, 2] == CurrentGame.Board[1, 1] && CurrentGame.Board[0, 2] == CurrentGame.Board[2, 0])
                _tmpPlayer = CurrentGame.Board[0, 2];

            if (_tmpPlayer != '\0')
                return _tmpPlayer == 'X' ? GameOverState.Player1 : GameOverState.Player2;

            // Si no ganó ningún jugador, pero el tablero está lleno, es un empate.
            if (CurrentGame.PlayedTurns == CurrentGame.Board.Length)
                return GameOverState.Tie;

            // Si el tablero no está lleno aún, y no ha ganado nadie, el juego sigue.
            return GameOverState.GameOn;
        }

        static void ShowBoard()
        {
            int _counter = 0;
            foreach(char currentPiece in CurrentGame.Board)
            {
                Console.SetCursorPosition(_counter % 3 * COLSIZE + LEFTMARGIN, _counter / 3 * ROWSIZE + TOPMARGIN);
                Console.Write(currentPiece);

                _counter++;
            }
        }

        static void ShowFrame(bool isStarting)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("|    7    |    8    |    9    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("|    4    |    5    |    6    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("|    1    |    2    |    3    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine($"\n{(isStarting ? "Presione una tecla para empezar con el jugador 1." : ("Le toca al jugador " + (CurrentGame.CurrentPlayer ? "dos." : "uno.")))}");
            Console.WriteLine(!isStarting ? "Seleccione una casilla [1-9]" : "");
        }

        static void FinalizeGame()
        {
            _inputThread.Abort();
            _inputThread.Join();
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("¡Bienvenido a nuestro Tic Tac Toe!");
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("\n\t1: Jugar");
            Console.WriteLine("\t2: Salir");
            Console.WriteLine("\n\tSeleccione: ");
        }

        static void GetInput()
        {
            string _currentInput;
            int i, j;
            while(true)
            {
                
                switch(CurrentGame.CurrentState)
                {
                    case GameState.Menu:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        CurrentGame.CurrentState = _currentInput == "1" ? GameState.Starting : GameState.Gameover;
                        break;
                    case GameState.Starting:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        CurrentGame.CurrentState = GameState.Playing;
                        break;
                    case GameState.Playing:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        tmp = Convert.ToInt32(_currentInput);

                        if (tmp < 1 || tmp > 9)
                            continue;
                        
                        i = 3 - ((tmp - 1) / 3) - 1;
                        j = (tmp - 1) % 3;

                        if (CurrentGame.Board[i, j] != '\0')
                            continue;

                        CurrentGame.PlayedTurns++;

                        CurrentGame.Board[i,j] = CurrentGame.CurrentPlayer ? 'O' : 'X';
                        CurrentGame.CurrentPlayer = !CurrentGame.CurrentPlayer;
                        break;
                }
            }
        }
    }
}
