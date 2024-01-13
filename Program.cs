using System.Numerics;
using System.Security;
using Raylib_cs;
using static Raylib_cs.Raylib;

const int winWidth = 2700;
const int cellWidth = 5;

InitWindow(winWidth, winWidth, "Automata");
ClearBackground(Color.WHITE);
SetTargetFPS(60);

// Mais interessantes:
// 73, 110, 18, 57, 182, 105, 137, 30, 89
var rule = 89;
var ruleSet = Convert.ToString(rule, 2).PadLeft(8, '0');
var currentLine = 0;
var board = new int[winWidth / cellWidth];
var newLine = new int[winWidth / cellWidth];
board[winWidth / cellWidth / 2] = 1;

while (!WindowShouldClose())
{
    BeginDrawing();
    for (var i = 0; i < board.Length; i++)
    {
        if (board[i] == 1)
            DrawRectangle(i * cellWidth, cellWidth * currentLine, cellWidth, cellWidth, Color.BLACK);

        var before = i <= 0 ? board.Length - 1 : i - 1;
        var next = i >= board.Length - 1 ? 0 : i + 1;
        var state = CalcStateFromNeighbours(board[before], board[i], board[next]);
        newLine[i] = state;
    }
    board = (int[])newLine.Clone();
    currentLine++;
    EndDrawing();
    Thread.Sleep(10);
}

CloseWindow();

int CalcStateFromNeighbours(int a, int b, int c)
{
    var neighbours = 7 - Convert.ToInt32($"{a}{b}{c}", 2);
    return ruleSet[neighbours] - '0';
}