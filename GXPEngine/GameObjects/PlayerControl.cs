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

    public PlayerControl(TiledObject obj = null) : base("circle.png", false, true)
    {
        
    }

    int CheckInputPlayer1()
    {
        //get snack item lists row 1 & 2
        MyGame myGame = (MyGame)game;
        foreach (Snacks snack in myGame.snacks1)
        {
            if (snack.y > ClosestSnack1.y || ClosestSnack1 == null)
            {
                ClosestSnack1 = snack;
            }
            
        }
        foreach (Snacks snack in myGame.snacks2)
        {
            if (snack.y > ClosestSnack2.y || ClosestSnack2 == null)
            {
                ClosestSnack2 = snack;
            }
        }

        // Player 1
        if (Input.GetKeyDown(Key.Q) && !Row1Disabled)
        {
            Console.WriteLine("Pressed: Q");
            return 1;
        }
        if (Input.GetKeyDown(Key.W) && !Row1Disabled)
        {
            Console.WriteLine("Pressed: W");
            return 2;
        }
        if (Input.GetKeyDown(Key.E) && !Row2Disabled)
        {
            Console.WriteLine("Pressed: E");
            return 3;
        }
        if (Input.GetKeyDown(Key.R) && !Row2Disabled)
        {
            Console.WriteLine("Pressed: R");
            return 4;
        }
        else
        {
            return 0;
        }
    }

    int CheckInputPlayer2()
    {
        //get snack item lists row 3 & 4
        MyGame myGame = (MyGame)game;
        foreach (Snacks snack in myGame.snacks3)
        {
            if (snack.y > ClosestSnack3.y || ClosestSnack3 == null)
            {
                ClosestSnack3 = snack;
            }
        }
        foreach (Snacks snack in myGame.snacks4)
        {
            if (snack.y > ClosestSnack4.y || ClosestSnack4 == null)
            {
                ClosestSnack4 = snack;
            }
        }
        // Player 2
        if (Input.GetKeyDown(Key.O) && !Row3Disabled)
        {
            Console.WriteLine("Pressed: O");
            return 1;
        }
        if (Input.GetKeyDown(Key.P) && !Row3Disabled)
        {
            Console.WriteLine("Pressed: P");
            return 2;
        }
        if (Input.GetKeyDown(Key.SQ_BRACKET_1) && !Row4Disabled)
        {
            Console.WriteLine("Pressed: [");
            return 3;
        }
        if (Input.GetKeyDown(Key.SQ_BRACKET_2) && !Row4Disabled)
        {
            Console.WriteLine("Pressed: ]");
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


    void CorrectButton(float y, Snacks snack, int player)
    {
        switch (y)
        {
            case float n when (n > 0 && n < 722):
                snackLoader.DestoryListSnack(snack);
                snack.Destroy();
                hud.TriggerToFast(player);
                break;
            case float n when (n > 840 && n < 860):
                snackLoader.DestoryListSnack(snack);
                snack.Destroy();
                hud.TriggerPerfect(player);
                break;
            case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                snackLoader.DestoryListSnack(snack);
                snack.Destroy();
                hud.TriggerGood(player);
                break;
            case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                snackLoader.DestoryListSnack(snack);
                snack.Destroy();
                hud.TriggerNormal(player);
                break;
        }
    }

    void Update()
    {
        if (hud == null) hud = game.FindObjectOfType<HUD>();
        switch (CheckInputPlayer1())
        {
            case 1:
                switch (ClosestSnack1.snackType)
                {
                    case 0:
                        {
                            CorrectButton(ClosestSnack1.y, ClosestSnack1,1);
                            break;
                        }
                    case int n when (n > 0 && n < 4):
                        {
                            snackLoader.DestoryListSnack(ClosestSnack1);
                            ClosestSnack1.Destroy();
                            hud.TriggerWrong(1);
                            break;
                        }
                    case 4:
                        {
                            snackLoader.DestoryListSnack(ClosestSnack1);
                            ClosestSnack1.Destroy();
                            hud.TriggerBad(1);
                            break;
                        }
                }
                break;
            case 2:
                switch (ClosestSnack1.snackType)
                {
                    case 1:
                        {
                            CorrectButton(ClosestSnack1.y, ClosestSnack1,1);
                            break;
                        }
                    case int n when (n > 1 && n < 4 && n == 0):
                        {
                            snackLoader.DestoryListSnack(ClosestSnack1);
                            ClosestSnack1.Destroy();
                            hud.TriggerWrong(1);
                            break;
                        }
                    case 4:
                        {
                            snackLoader.DestoryListSnack(ClosestSnack1);
                            ClosestSnack1.Destroy();
                            hud.TriggerBad(1);
                            break;
                        }
                }
                break;
            case 3:
                switch (ClosestSnack2.snackType)
                {
                    case 2:
                        {
                            CorrectButton(ClosestSnack2.y, ClosestSnack2,1);
                            break;
                        }
                    case int n when (n >= 0 && n < 2 && n == 3):
                        {
                            snackLoader.DestoryListSnack(ClosestSnack2);
                            ClosestSnack2.Destroy();
                            hud.TriggerWrong(1);
                            break;
                        }
                    case 4:
                        {
                            snackLoader.DestoryListSnack(ClosestSnack2);
                            ClosestSnack2.Destroy();
                            hud.TriggerBad(1);
                            break;
                        }
                }
                break;
            case 4:
                switch (ClosestSnack2.snackType)
                {
                    case 3:
                        {
                            CorrectButton(ClosestSnack2.y, ClosestSnack2,1);
                            break;
                        }
                    case int n when (n >= 0 && n < 3):
                        {
                            snackLoader.DestoryListSnack(ClosestSnack2);
                            ClosestSnack2.Destroy();
                            hud.TriggerWrong(1);
                            break;
                        }
                    case 4:
                        {
                            snackLoader.DestoryListSnack(ClosestSnack2);
                            ClosestSnack2.Destroy();
                            hud.TriggerBad(1);
                            break;
                        }
                }
                break;
            case 0:
                break;
        }
        switch (CheckInputPlayer2())
        {
            case 1:
                switch (ClosestSnack3.snackType)
                {
                    case 0:
                        {
                            CorrectButton(ClosestSnack3.y, ClosestSnack3, 2);
                            break;
                        }
                    case int n when (n > 0 && n < 4):
                        {
                            snackLoader.DestoryListSnack(ClosestSnack3);
                            ClosestSnack3.Destroy();
                            hud.TriggerWrong(2);
                            break;
                        }
                    case 4:
                        {
                            snackLoader.DestoryListSnack(ClosestSnack3);
                            ClosestSnack3.Destroy();
                            hud.TriggerBad(2);
                            break;
                        }
                }
                break;
            case 2:
                switch (ClosestSnack3.snackType)
                {
                    case 1:
                        {
                            CorrectButton(ClosestSnack3.y, ClosestSnack3, 2);
                            break;
                        }
                    case int n when (n > 1 && n < 4 && n == 0):
                        {
                            snackLoader.DestoryListSnack(ClosestSnack3);
                            ClosestSnack3.Destroy();
                            hud.TriggerWrong(2);
                            break;
                        }
                    case 4:
                        {
                            snackLoader.DestoryListSnack(ClosestSnack3);
                            ClosestSnack3.Destroy();
                            hud.TriggerBad(2);
                            break;
                        }
                }
                break;
            case 3:
                switch (ClosestSnack4.snackType)
                {
                    case 2:
                        {
                            CorrectButton(ClosestSnack4.y, ClosestSnack4, 2);
                            break;
                        }
                    case int n when (n >= 0 && n < 2 && n == 3):
                        {
                            snackLoader.DestoryListSnack(ClosestSnack4);
                            ClosestSnack4.Destroy();
                            hud.TriggerWrong(2);
                            break;
                        }
                    case 4:
                        {
                            snackLoader.DestoryListSnack(ClosestSnack4);
                            ClosestSnack4.Destroy();
                            hud.TriggerBad(2);
                            break;
                        }
                }
                break;
            case 4:
                switch (ClosestSnack2.snackType)
                {
                    case 3:
                        {
                            CorrectButton(ClosestSnack4.y, ClosestSnack4, 2);
                            break;
                        }
                    case int n when (n >= 0 && n < 3):
                        {
                            snackLoader.DestoryListSnack(ClosestSnack4);
                            ClosestSnack4.Destroy();
                            hud.TriggerWrong(2);
                            break;
                        }
                    case 4:
                        {
                            snackLoader.DestoryListSnack(ClosestSnack4);
                            ClosestSnack4.Destroy();
                            hud.TriggerBad(2);
                            break;
                        }
                }
                break;
            case 0:
                break;
        }
    }
}