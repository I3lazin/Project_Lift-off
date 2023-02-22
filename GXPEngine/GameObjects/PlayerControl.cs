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
        if (Input.GetKeyDown(Key.Q))
        {
            Console.WriteLine("Pressed: Q");
            return 1;
        }
        if (Input.GetKeyDown(Key.W))
        {
            Console.WriteLine("Pressed: W");
            return 2;
        }
        if (Input.GetKeyDown(Key.E))
        {
            Console.WriteLine("Pressed: E");
            return 3;
        }
        if (Input.GetKeyDown(Key.R))
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


    void CorrectButton1(float y)
    {
        switch (y)
        {
            case float n when (n > 0 && n < 722):
                snackLoader.DestoryListSnack(ClosestSnack1);
                ClosestSnack1.Destroy();
                hud.TriggerToFast(1);
                break;
            case float n when (n > 840 && n < 860):
                snackLoader.DestoryListSnack(ClosestSnack1);
                ClosestSnack1.Destroy();
                hud.TriggerPerfect(1);
                break;
            case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                snackLoader.DestoryListSnack(ClosestSnack1);
                ClosestSnack1.Destroy();
                hud.TriggerGood(1);
                break;
            case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                snackLoader.DestoryListSnack(ClosestSnack1);
                ClosestSnack1.Destroy();
                hud.TriggerNormal(1);
                break;
        }
    }
    void CorrectButton2(float y)
    {
        switch (y)
        {
            case float n when (n > 0 && n < 722):
                snackLoader.DestoryListSnack(ClosestSnack2);
                ClosestSnack2.Destroy();
                hud.TriggerToFast(1);
                break;
            case float n when (n > 840 && n < 860):
                snackLoader.DestoryListSnack(ClosestSnack2);
                ClosestSnack2.Destroy();
                hud.TriggerPerfect(1);
                break;
            case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                snackLoader.DestoryListSnack(ClosestSnack2);
                ClosestSnack2.Destroy();
                hud.TriggerGood(1);
                break;
            case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                snackLoader.DestoryListSnack(ClosestSnack2);
                ClosestSnack2.Destroy();
                hud.TriggerNormal(1);
                break;
        }
    }

    void Update()
    {
        MyGame myGame = (MyGame)game;
        if (hud == null) hud = game.FindObjectOfType<HUD>();

        switch (CheckInputPlayer1())
        {
            case 1:
                if (Row1Disabled) { break; }
                switch (ClosestSnack1.snackType)
                {
                    case 0:
                        {
                            CorrectButton1(ClosestSnack1.y);
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
                if (Row1Disabled) { break; }
                switch (ClosestSnack1.snackType)
                {
                    case 1:
                        {
                            CorrectButton1(ClosestSnack1.y);
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
                if (Row2Disabled) { break; }
                switch (ClosestSnack2.snackType)
                {
                    case 2:
                        {
                            CorrectButton2(ClosestSnack2.y);
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
                if (Row2Disabled) { break; }
                switch (ClosestSnack2.snackType)
                {
                    case 3:
                        {
                            CorrectButton2(ClosestSnack2.y);
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
        }
        /**
        switch (CheckInputPlayer2())
        {
            case 1:
                switch (ClosestSnack3.snackType)
                {
                    case 0:
                        {
                            switch (ClosestSnack3.y)
                            {
                                case float n when (n > 0 && n < 722):
                                    ClosestSnack3.Destroy();
                                    hud.TriggerToFast(2);
                                    break;
                                case float n when (n > 840 && n < 860):
                                    ClosestSnack3.Destroy();
                                    hud.TriggerPerfect(2);
                                    break;
                                case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                                    ClosestSnack3.Destroy();
                                    hud.TriggerGood(2);
                                    break;
                                case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                                    ClosestSnack3.Destroy();
                                    hud.TriggerNormal(2);
                                    break;
                            }
                            break;
                        }
                    case int n when (n > 0 && n < 4):
                        {
                            ClosestSnack3.Destroy();
                            hud.TriggerWrong(2);
                            break;
                        }
                    case 4:
                        {
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
                            switch (ClosestSnack3.y)
                            {
                                case float n when (n > 0 && n < 722):
                                    ClosestSnack3.Destroy();
                                    hud.TriggerToFast(2);
                                    break;
                                case float n when (n > 840 && n < 860):
                                    ClosestSnack3.Destroy();
                                    hud.TriggerPerfect(2);
                                    break;
                                case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                                    ClosestSnack3.Destroy();
                                    hud.TriggerGood(2);
                                    break;
                                case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                                    ClosestSnack3.Destroy();
                                    hud.TriggerNormal(2);
                                    break;
                            }
                            break;
                        }
                    case int n when (n > 1 && n < 4 && n == 0):
                        {
                            ClosestSnack3.Destroy();
                            hud.TriggerWrong(2);
                            break;
                        }
                    case 4:
                        {
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
                            switch (ClosestSnack4.y)
                            {
                                case float n when (n > 0 && n < 722):
                                    ClosestSnack4.Destroy();
                                    hud.TriggerToFast(2);
                                    break;
                                case float n when (n > 840 && n < 860):
                                    ClosestSnack4.Destroy();
                                    hud.TriggerPerfect(2);
                                    break;
                                case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                                    ClosestSnack4.Destroy();
                                    hud.TriggerGood(2);
                                    break;
                                case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                                    ClosestSnack4.Destroy();
                                    hud.TriggerNormal(2);
                                    break;
                            }
                            break;
                        }
                    case int n when (n >= 0 && n < 2 && n == 3):
                        {
                            ClosestSnack4.Destroy();
                            hud.TriggerWrong(2);
                            break;
                        }
                    case 4:
                        {
                            ClosestSnack4.Destroy();
                            hud.TriggerBad(2);
                            break;
                        }
                }
                break;
            case 4:
                switch (ClosestSnack4.snackType)
                {
                    case 3:
                        {
                            switch (ClosestSnack4.y)
                            {
                                case float n when (n > 0 && n < 722):
                                    ClosestSnack4.Destroy();
                                    hud.TriggerToFast(2);
                                    break;
                                case float n when (n > 840 && n < 860):
                                    ClosestSnack4.Destroy();
                                    hud.TriggerPerfect(2);
                                    break;
                                case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                                    ClosestSnack4.Destroy();
                                    hud.TriggerGood(2);
                                    break;
                                case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                                    ClosestSnack4.Destroy();
                                    hud.TriggerNormal(2);
                                    break;
                            }
                            break;
                        }
                    case int n when (n >= 0 && n < 3):
                        {
                            ClosestSnack4.Destroy();
                            hud.TriggerWrong(2);
                            break;
                        }
                    case 4:
                        {
                            ClosestSnack4.Destroy();
                            hud.TriggerBad(2);
                            break;
                        }
                }
                break;
        }
        **/
    }
}