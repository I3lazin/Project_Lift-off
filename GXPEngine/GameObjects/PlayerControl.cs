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
    Snacks ClosestSnack1 = new Snacks();
    Snacks ClosestSnack2 = new Snacks();
    Snacks ClosestSnack3 = new Snacks();
    Snacks ClosestSnack4 = new Snacks();
    public Level myLevel;

    public PlayerControl(TiledObject obj = null) : base("Blank.png", false, true)
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

        }
        foreach (Snacks snack in myGame.snacks4)
        {

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

    void Update()
    {
        MyGame myGame = (MyGame)game;
        if (hud == null) hud = game.FindObjectOfType<HUD>();
        //Not ideal to call findobjectsoftype in Update
        //snacks = game.FindObjectsOfType<Snacks>();

        switch (CheckInputPlayer1())
        {
            case 1:
                if (ClosestSnack1.snackType == 1)
                {
                    switch (ClosestSnack1.y)
                    {
                        case float n when (n > 840 && n < 860):
                            hud.TriggerPerfect(1);
                            break;
                        case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                            hud.TriggerGood(1);
                            break;
                        case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                            hud.TriggerNormal(1);
                            break;
                    }
                } else if (ClosestSnack1.snackType != 1)
                {
                    hud.TriggerWrong(1);
                }
                break;
            case 2:
                if (ClosestSnack1.snackType == 2)
                {
                    switch (ClosestSnack1.y)
                    {
                        case float n when (n > 840 && n < 860):
                            hud.TriggerPerfect(1);
                            break;
                        case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                            hud.TriggerGood(1);
                            break;
                        case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                            hud.TriggerNormal(1);
                            break;
                    }
                }
                else if (ClosestSnack1.snackType != 2)
                {
                    hud.TriggerWrong(1);
                }
                break;
            case 3:
                if (ClosestSnack2.snackType == 3)
                {
                    switch (ClosestSnack2.y)
                    {
                        case float n when (n > 840 && n < 860):
                            hud.TriggerPerfect(1);
                            break;
                        case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                            hud.TriggerGood(1);
                            break;
                        case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                            hud.TriggerNormal(1);
                            break;
                    }
                }
                else if (ClosestSnack2.snackType != 3)
                {
                    hud.TriggerWrong(1);
                }
                break;
            case 4:
                if (ClosestSnack2.snackType == 4)
                {
                    switch (ClosestSnack2.y)
                    {
                        case float n when (n > 840 && n < 860):
                            hud.TriggerPerfect(1);
                            break;
                        case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                            hud.TriggerGood(1);
                            break;
                        case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                            hud.TriggerNormal(1);
                            break;
                    }
                }
                else if (ClosestSnack2.snackType != 4)
                {
                    hud.TriggerWrong(1);
                }
                break;
        }
        switch (CheckInputPlayer2())
        {
            case 1:
                if (ClosestSnack3.snackType == 1)
                {
                    switch (ClosestSnack3.y)
                    {
                        case float n when (n > 840 && n < 860):
                            hud.TriggerPerfect(2);
                            break;
                        case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                            hud.TriggerGood(2);
                            break;
                        case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                            hud.TriggerNormal(2);
                            break;
                    }
                }
                else if (ClosestSnack3.snackType != 1)
                {
                    hud.TriggerWrong(2);
                }
                break;
            case 2:
                if (ClosestSnack3.snackType == 2)
                {
                    switch (ClosestSnack3.y)
                    {
                        case float n when (n > 840 && n < 860):
                            hud.TriggerPerfect(2);
                            break;
                        case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                            hud.TriggerGood(2);
                            break;
                        case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                            hud.TriggerNormal(2);
                            break;
                    }
                }
                else if (ClosestSnack3.snackType != 2)
                {
                    hud.TriggerWrong(2);
                }
                break;
            case 3:
                if (ClosestSnack4.snackType == 3)
                {
                    switch (ClosestSnack4.y)
                    {
                        case float n when (n > 840 && n < 860):
                            hud.TriggerPerfect(2);
                            break;
                        case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                            hud.TriggerGood(2);
                            break;
                        case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                            hud.TriggerNormal(2);
                            break;
                    }
                }
                else if (ClosestSnack4.snackType != 3)
                {
                    hud.TriggerWrong(2);
                }
                break;
            case 4:
                if (ClosestSnack4.snackType == 4)
                {
                    switch (ClosestSnack4.y)
                    {
                        case float n when (n > 840 && n < 860):
                            hud.TriggerPerfect(2);
                            break;
                        case float n when (n > 810 && n < 840 || n > 860 && n < 890):
                            hud.TriggerGood(2);
                            break;
                        case float n when (n > 722 && n < 810 || n > 860 && n < 928):
                            hud.TriggerNormal(2);
                            break;
                    }
                }
                else if (ClosestSnack4.snackType != 4)
                {
                    hud.TriggerWrong(2);
                }
                break;
        }
    }
}