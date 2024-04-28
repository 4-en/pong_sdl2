using SDL2;
using SDL2Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace Pong.src
{
    internal class PongGame
    {
        public static Scene CreateScene()
        {


            var scene = new Scene("PongGame Scene");

            var leftPaddle = scene.CreateChild("Left Paddle");
            _ = leftPaddle.AddComponent<WSController>();
            _ = leftPaddle.AddComponent<Paddle>();
            leftPaddle.transform.position = new Vec2D(50, 750);

            var rightPaddle = scene.CreateChild("Right Paddle");
            _ = rightPaddle.AddComponent<ArrowKeysController>();
            _ = rightPaddle.AddComponent<Paddle>();
            rightPaddle.transform.position = new Vec2D(1870, 750);

            ////PongBall variante round
            //var pongBall = scene.CreateChild("Pongball");
            ////_ = pongBall.AddComponent<ArrowKeysController>();
            //_ = pongBall.AddComponent<PongBall>();
            //pongBall.transform.position = new Vec2D(950, 750);

            ////PongBall variante round
            var pongSquare = scene.CreateChild("Pongball");
            //_ = pongBall.AddComponent<ArrowKeysController>();
            _ = pongSquare.AddComponent<PongSquare>();
            pongSquare.transform.position = new Vec2D(960, 750);

            ////Boarder variante 1 
            //var leftBoarder = scene.CreateChild("Boarder");
            //_ = leftBoarder.AddComponent<Boarder>();
            //leftBoarder.transform.position = new Vec2D(5, 750);

            //var rightBoarder = scene.CreateChild("Boarder");
            //_ = rightBoarder.AddComponent<Boarder>();
            //rightBoarder.transform.position = new Vec2D(1915, 750);

            //Boarder variante 2
            var testBoarder = scene.CreateChild("Boarder");
            _ = testBoarder.AddComponent<Boarder2>();
            testBoarder.transform.position = new Vec2D(960, 750);


            return scene;
        }
        public static void Run()
        {

            var scene = CreateScene();

            var engine = new SDL2Engine.Engine(scene);

            engine.Run();
        }
    }
}


class ArrowKeysController : Script
{
    public override void Update()
    {

        var gameObject = this.gameObject;
        var speed = 10;
        if (Input.GetKeyPressed(((int)SDL_Keycode.SDLK_UP)))
        {
            gameObject.transform.position += new Vec2D(0, -speed);
        }
        if (Input.GetKeyPressed(((int)SDL_Keycode.SDLK_DOWN)))
        {
            gameObject.transform.position += new Vec2D(0, speed);
        }

    }
}


class WSController : Script
{
    public override void Update()
    {
        // a better way to do this would be to use a rigidbody with velocity
        var gameObject = this.gameObject;
        var speed = 10;
        if (Input.GetKeyPressed(((int)SDL_Keycode.SDLK_w)))
        {
            gameObject.transform.position += new Vec2D(0, -speed);
        }
        if (Input.GetKeyPressed(((int)SDL_Keycode.SDLK_s)))
        {
            gameObject.transform.position += new Vec2D(0, speed);
        }

    }
}