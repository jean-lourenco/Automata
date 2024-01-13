using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

InitWindow(600, 600, "Snaker");
SetTargetFPS(60);
var rect = new Vector2(0, 0);
var lastKey = KeyboardKey.KEY_RIGHT;

while (!WindowShouldClose())
{
    ClearBackground(Color.BLACK);
    BeginDrawing();
    DrawFPS(0, 600 - 20);
    DrawRectangle((int)rect.X, (int)rect.Y, 10, 10, Color.GREEN);

    if (IsKeyDown(KeyboardKey.KEY_UP))
    {
        rect.Y -= GetFrameTime() * 20;
        lastKey = KeyboardKey.KEY_UP;
    }
    else if (IsKeyDown(KeyboardKey.KEY_RIGHT))
    {
        rect.X += GetFrameTime() * 20;
        lastKey = KeyboardKey.KEY_RIGHT;
    }
    else if (IsKeyDown(KeyboardKey.KEY_DOWN))
    {
        rect.Y += GetFrameTime() * 20;
        lastKey = KeyboardKey.KEY_DOWN;
    }
    else if (IsKeyDown(KeyboardKey.KEY_LEFT))
    {
        rect.X -= GetFrameTime() * 20;
        lastKey = KeyboardKey.KEY_LEFT;
    }

    EndDrawing();
}

CloseWindow();