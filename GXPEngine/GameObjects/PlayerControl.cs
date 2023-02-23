using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class PlayerControl : Sprite
{
    HUD hud = null;
    int barheight = 1050;
    public bool Row1Disabled = false;
    public bool Row2Disabled = false;
    public bool Row3Disabled = false;
    public bool Row4Disabled = false;
    Snacks snackLoader = new Snacks();
    Snacks ClosestSnack1 = new Snacks();
    Snacks ClosestSnack2 = new Snacks();
    Snacks ClosestSnack3 = new Snacks();
    Snacks ClosestSnack4 = new Snacks();
    public Level myLevel;

    public PlayerControl(TiledObject obj = null) : base("Blank.png", false, true)
    {
        
    }

    public async void CheckInputPlayer1()
    {
        //get snack item lists row 1 & 2
        MyGame myGame = (MyGame)game;
        if (myGame.snacks1.Count != 0) { ClosestSnack1 = myGame.snacks1[0]; }
        if (myGame.snacks2.Count != 0) { ClosestSnack2 = myGame.snacks2[0]; }

        // Player 1
        if (Input.GetKeyDown(Key.Q) && !Row1Disabled)
        {
            CorrectSnackType(0, ClosestSnack1, 1);
            Console.WriteLine("Pressed: Q");
        }
        if (Input.GetKeyDown(Key.W) && !Row1Disabled)
        {
            CorrectSnackType(1, ClosestSnack1, 1);
            Console.WriteLine("Pressed: W");
        }
        if (Input.GetKeyDown(Key.E) && !Row2Disabled)
        {
            CorrectSnackType(2, ClosestSnack2, 1);
            Console.WriteLine("Pressed: E");
        }
        if (Input.GetKeyDown(Key.R) && !Row2Disabled)
        {
            CorrectSnackType(3, ClosestSnack2, 1);
            Console.WriteLine("Pressed: R");
        }
    }

    public async void CheckInputPlayer2()
    {
        //get snack item lists row 3 & 4
        MyGame myGame = (MyGame)game;
        if (myGame.snacks3.Count != 0) { ClosestSnack3 = myGame.snacks3[0]; }
        if (myGame.snacks4.Count != 0) { ClosestSnack4 = myGame.snacks4[0]; }

        // Player 2
        if (Input.GetKeyDown(Key.O) && !Row3Disabled)
        {
            CorrectSnackType(0,ClosestSnack3,2);
            Console.WriteLine("Pressed: O");
        }
        if (Input.GetKeyDown(Key.P) && !Row3Disabled)
        {
            CorrectSnackType(1, ClosestSnack3, 2);
            Console.WriteLine("Pressed: P");
        }
        if (Input.GetKeyDown(Key.SQ_BRACKET_1) && !Row4Disabled)
        {
            CorrectSnackType(2, ClosestSnack4, 2);
            Console.WriteLine("Pressed: [");
        }
        if (Input.GetKeyDown(Key.SQ_BRACKET_2) && !Row4Disabled)
        {
            CorrectSnackType(3, ClosestSnack4, 2);
            Console.WriteLine("Pressed: ]");
        } 
    }
    
    public async void CheckSelectLevelInput()
    {
        // Select level
        if (Input.GetKeyDown(Key.B))
        {
            Console.WriteLine("Pressed: B");
        }
        if (Input.GetKeyDown(Key.N))
        {
            Console.WriteLine("Pressed: N");
        }
    }

    void CorrectHeight(float y, Snacks snack, int player)
    {
        switch (y)
        {
            case float n when (n > 0 && n < 722):
                snackLoader.DestoryListSnack(snack);
                snack.Destroy();
                hud.TriggerToFast(player);
                break;
            case float n when (n > barheight - 10 && n < barheight + 10):
                snackLoader.DestoryListSnack(snack);
                snack.Destroy();
                hud.TriggerPerfect(player);
                break;
            case float n when (n > barheight - 40 && n < barheight - 10 || n > barheight + 10 && n < barheight + 40):
                snackLoader.DestoryListSnack(snack);
                snack.Destroy();
                hud.TriggerGood(player);
                break;
            case float n when (n > barheight - 128 && n < barheight - 40 || n > barheight + 40 && n < barheight + 128):
                snackLoader.DestoryListSnack(snack);
                snack.Destroy();
                hud.TriggerNormal(player);
                break;
        }
    }

    void CorrectSnackType(int input,Snacks snack, int player)
    {
        if (snack.snackType == input)
        {
            CorrectHeight(snack.y, snack, player);
        }
        else if (snack.snackType == 4)
        {
            snackLoader.DestoryListSnack(snack);
            snack.Destroy();
            hud.TriggerBad(player);
        }
        else
        {
            snackLoader.DestoryListSnack(snack);
            snack.Destroy();
            hud.TriggerWrong(player);
        }
    }

    void Update()
    {
        if (hud == null) hud = game.FindObjectOfType<HUD>();
    }
}