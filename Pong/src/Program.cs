using SDL2Engine;

namespace Pong
{
    internal class Pong
    {
        static void Main(string[] args)
        {
            // creates a simple scene with a rotating rectangle that follows the mouse
            // left click to spawn a new rectangle at the mouse position
            var scene = SDL2Engine.EngineTest.CreateScene();

            // use engine class to run a scene
            // contains the game loop and window creation
            var engine = new Engine(scene);

            // create the window and run the game loop until window is closed
            engine.Run();
        }
    }
}
