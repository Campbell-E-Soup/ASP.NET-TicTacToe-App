namespace TicTacToe.Models
{
    public class TTTSession
    {
        private const string GAMEKEY = "GameState";
        private ISession session { get; set; }
        public TTTSession(ISession sess) => session = sess;

        public void SetGameState(GameState game)
        {
            session.SetObject<GameState>(GAMEKEY, game);
        }
        public GameState GetGameState()
        {
            return session.GetObject<GameState>(GAMEKEY) ?? new GameState();
        }
    }
        
}
