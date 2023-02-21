using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class PlayerControl : Sprite
{
    HUD hud = null;
    Snacks[] snacks = null;
    int firstClosest = 0;
    int secondClosest = 0;
    public Level myLevel;

    public PlayerControl(TiledObject obj = null) : base("Blank.png", false, true)
    {
        
    }

    int CheckInputPlayer1()
    {
        MyGame myGame = (MyGame)game;
        // Player 1
        if (Input.GetKeyDown(Key.Q))
        {
            foreach (Snacks snack in myGame.snacks1)
            {
                Console.WriteLine(myGame.snacks1[0] + "/n snackSpeed: {0} /n snackType: {1} /n snackDelay: {2} /n Y value: {3}", snack.snackSpeed, snack.snackType, snack.delayInMs, snack.y);
                if (snack.y < firstClosest)
                {
                    firstClosest = secondClosest;
                }
                //snack.y;
            }
            Console.WriteLine();
            hud.AddScoreP1(100);
            return 1;
        }
        if (Input.GetKey(Key.W))
        {
            Console.WriteLine("Pressed: W");
            hud.AddScoreP1(100);
            return 2;
        }
        if (Input.GetKeyDown(Key.E))
        {
            Console.WriteLine("Pressed: E");
            hud.AddScoreP1(100);
            return 3;
        }
        if (Input.GetKeyDown(Key.R))
        {
            Console.WriteLine("Pressed: R");
            hud.AddScoreP1(100);
            return 4;
        }
        else
        {
            return 0;
        }
    }

    int CheckInputPlayer2()
    {
        MyGame myGame = (MyGame)game;
        // Player 2
        if (Input.GetKeyDown(Key.O))
        {
            Console.WriteLine("Pressed: O");
            hud.AddScoreP2(100);
            return 1;
        }
        if (Input.GetKeyDown(Key.P))
        {
            Console.WriteLine("Pressed: P");
            hud.AddScoreP2(100);
            return 2;
        }
        if (Input.GetKeyDown(Key.SQ_BRACKET_1))
        {
            Console.WriteLine("Pressed: [");
            hud.AddScoreP2(100);
            return 3;
        }
        if (Input.GetKeyDown(Key.SQ_BRACKET_2))
        {
            Console.WriteLine("Pressed: ]");
            hud.AddScoreP2(100);
            return 4;
        } 
        else
        {
            return 0;
        }
    }
    
    int CheckSelectLevelInput()
    {
        MyGame myGame = (MyGame)game;
        // Select level
        if (Input.GetKeyDown(Key.B))
        {
            Console.WriteLine("Pressed: B");
            return 1;
        }
        if (Input.GetKeyDown(Key.N))
        {
            Console.WriteLine("Pressed: N");
            return 2;
        }
        else
        {
            return 0;
        }
    }

    void Update()
    {
        MyGame myGame = (MyGame)game;
        if (hud == null) hud = game.FindObjectOfType<HUD>();
        //Not ideal to call findobjectsoftype in Update
        //snacks = game.FindObjectsOfType<Snacks>();

        CheckInputPlayer1();
        CheckInputPlayer2();
    }
}
