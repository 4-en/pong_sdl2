﻿using SDL2Engine;
using System.Collections.Generic;
using static SDL2.SDL;

namespace Pong.src
{
    class Boarder2 : Drawable
    {
        public float Left { get; private set; }
        public float Right { get; private set; }
        public float Top { get; private set; }
        public float Bottom { get; private set; }

        public override void Draw(Camera camera)
        {
            var PaddleWidth = 800;
            var PaddleHeight = 400;
            var BorderThickness = 5;
            var renderer = Engine.renderer;

            var root = this.gameObject;

            // Set the color to white
            SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);

            // Define the inner rectangle (empty area)
            var InnerRect = new SDL_Rect();
            InnerRect.x = (int)(root.transform.position.x - PaddleWidth / 2); // Adjust the position to make the inner rectangle smaller
            InnerRect.y = (int)(root.transform.position.y - PaddleHeight / 2); // Adjust the position to make the inner rectangle smaller
            InnerRect.w = (int)PaddleWidth; // Adjust the width to make the inner rectangle smaller
            InnerRect.h = (int)PaddleHeight; // Adjust the height to make the inner rectangle smaller

            // Convert to camera space
            Vec2D innerRectCenter = camera.WorldToScreen(root.transform.position);

            InnerRect.x = (int)(innerRectCenter.x - PaddleWidth / 2);
            InnerRect.y = (int)(innerRectCenter.y - PaddleHeight / 2);

            // Draw the inner rectangle (empty area)
            SDL_RenderDrawRect(renderer, ref InnerRect);


            // Draw the outer border
            for (int i = 0; i < BorderThickness; i++)
            {
                // Draw the top line of the outer border
                SDL_RenderDrawLine(renderer,
                    (int)InnerRect.x - i, (int)InnerRect.y - i,                             // Start point: Top-left corner (adjusted by thickness)
                    (int)(InnerRect.x + InnerRect.w) + i, (int)InnerRect.y - i);           // End point: Top-right corner (adjusted by thickness)

                // Draw the right line of the outer border
                SDL_RenderDrawLine(renderer,
                    (int)(InnerRect.x + InnerRect.w) + i, (int)InnerRect.y - i,           // Start point: Top-right corner (adjusted by thickness)
                    (int)(InnerRect.x + InnerRect.w) + i, (int)(InnerRect.y + InnerRect.h) + i); // End point: Bottom-right corner (adjusted by thickness)

                // Draw the bottom line of the outer border
                SDL_RenderDrawLine(renderer,
                    (int)(InnerRect.x + InnerRect.w) + i, (int)(InnerRect.y + InnerRect.h) + i, // Start point: Bottom-right corner (adjusted by thickness)
                    (int)InnerRect.x - i, (int)(InnerRect.y + InnerRect.h) + i);             // End point: Bottom-left corner (adjusted by thickness)

                // Draw the left line of the outer border
                SDL_RenderDrawLine(renderer,
                    (int)InnerRect.x - i, (int)(InnerRect.y + InnerRect.h) + i,             // Start point: Bottom-left corner (adjusted by thickness)
                    (int)InnerRect.x - i, (int)InnerRect.y - i);                            // End point: Top-left corner (adjusted by thickness)
            }
        }
    }
}