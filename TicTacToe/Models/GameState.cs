using System.Drawing;
using System.Reflection;

namespace TicTacToe.Models
{
	public class GameState
	{
		public int[,] Board {  get; set; }
		public int Turn { get; set; } = 1;
		public int Won { get; set; } = 0;
		public static string[] Icons {  get; set; } 
		public static string[] Colors { get; set; }
        public GameState()
        {
            Board = new int[3, 3];
            //all slots should already be 0! (yes, that is factorial).
        }
		public int CheckState()
		{
            int Size = Board.GetLength(0);
            int EmptySpaces = 0;

			//verticals
			for (int i = 0; i < Size; i++)
			{
				int Xs = 0;
				int Os = 0;
				int Void = 0;
                for (int j = 0; j < Size; j++)
                {
					switch (Board[i, j])
					{
                        case 0: Void++; break;
						case 1: Xs++; break;
						case 2: Os++; break;
					}
                }
				EmptySpaces += Void;
				if (Xs == Size)
				{
					return 1;
				}
				else if (Os == Size)
				{
					return 2;
				}
            }
            //horizontal
            for (int i = 0; i < Size; i++)
            {
                int Xs = 0;
                int Os = 0;
                int Void = 0;
                for (int j = 0; j < Size; j++)
                {
                    switch (Board[j, i])
                    {
                        case 0: Void++; break;
                        case 1: Xs++; break;
                        case 2: Os++; break;
                    }
                }
                EmptySpaces += Void;
                if (Xs == Size)
                {
                    return 1;
                }
                else if (Os == Size)
                {
                    return 2;
                }
            }
			//diagonals
			for (int j = 0; j < 2; j++)
			{
				int Xs = 0;
				int Os = 0;
				int Void = 0;
				for (int i = 0; i < Size; i++)
				{
					int x = 0 + i;
					int y = 0 + i;
                    if (j == 1) 
					{
                        x = 2 - i;
                        y = 0 + i;
                    }
                    switch (Board[x, y])
					{
						case 0: Void++; break;
						case 1: Xs++; break;
						case 2: Os++; break;
					}
				}
                EmptySpaces += Void;
                if (Xs == Size)
                {
                    return 1;
                }
                else if (Os == Size)
                {
                    return 2;
                }
            }
			if (EmptySpaces == 0) { return -1; }
            return 0;
		}
        static GameState() 
		{
			Icons = new string[] {
                "fa-solid fa-fw",
				"fa-solid fa-xmark",
				"fa-solid fa-o"
			};
			Colors = new string[]
			{
				"primary",
				"danger",
				"success"
			};
		}
	}
}
