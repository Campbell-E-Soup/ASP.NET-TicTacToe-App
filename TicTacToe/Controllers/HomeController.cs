using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
	public class HomeController : Controller
    {
        public IActionResult Index()
		{
            TTTSession session = new TTTSession(HttpContext.Session);
            GameState model = session.GetGameState();
            return View(model);
        }
        public IActionResult Place(string x, string y)
        {            
            int xx = Convert.ToInt32(x);
            int yy = Convert.ToInt32(y);
            if (xx != -1 && yy != -1) {
                if (xx >= 0 && xx < 3 && yy >= 0 && yy < 3)
                {
                    TTTSession session = new TTTSession(HttpContext.Session);
                    GameState state = session.GetGameState();
                    state.Board[xx, yy] = state.Turn;
                    state.Turn++;
                    if (state.Turn >= 3)
                    {
                        state.Turn = 1;
                    }
                    state.Won = state.CheckState();
                    session.SetGameState(state);
                }
            }

            return RedirectToAction("Index");
        }
        public IActionResult Restart()
        {
            TTTSession session = new TTTSession(HttpContext.Session);
            session.SetGameState(new GameState());
            return RedirectToAction("Index");
        }
	}
}
