using Microsoft.Xna.Framework.Input;

//JaJuan Webster
//Professor Cascioli
//Asteroids!
//ABOVE AND BEYOND: Background Music & Game States

namespace Webster_HW_Project2_Asteroids
{
    enum GameState
    {
        START,
        GAME = Keys.F3,
        GAMEOVER
    }

    class GameManager
    {
        public GameState state;
    }
}
