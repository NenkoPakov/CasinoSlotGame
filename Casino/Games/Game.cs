using Casino.Games.Interfaces;
using Casino.Wrappers;

namespace Casino
{
    public abstract class Game : IGame
    {
        private readonly IConsole _console;

        public Game(IConsole console)
        {
            this._console = console; 
        }

        public abstract void Play();

        public void Quit()
        {
            this._console.WriteLine(GlobalConstants.QUIT);
        }
    }
}
