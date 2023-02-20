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
    public PlayerControl(TiledObject obj = null) : base("Blank.png", false, true)
    {
        
    }

    int CheckInputPlayer1()
    {
        // Player 1
        if (Input.GetKeyDown(Key.Q))
        {
            Console.WriteLine("Pressed: Q");
            hud.AddScoreP1(100);
            return 1;
        }
        if (Input.GetKeyDown(Key.W))
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
        if (hud == null) hud = game.FindObjectOfType<HUD>();
        CheckInputPlayer1();
        CheckInputPlayer2();
    }
}
