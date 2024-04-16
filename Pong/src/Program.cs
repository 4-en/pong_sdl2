using SDL2Engine;

namespace Pong
{
    internal class Pong
    {
        static void Main(string[] args)
        {
            var scene = SDL2Engine.EngineTest.CreateScene();

            var engine = new Engine(scene);
            engine.Run();
        }
    }
}
