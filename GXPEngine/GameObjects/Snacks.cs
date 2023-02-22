using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

public class Snacks : Sprite
{
    HUD hud = null;
    int initializationvalue = 0;
    int currentLifeTimeMs = 0;
    public bool canmove = false;
    public int delayInMs;
    public float snackSpeed;
    public int snackRow;
    public int snackType;
    string[] snack = {"circle.png","checkers.png","colors.png","square.png","triangle.png"};

    public Snacks(TiledObject obj=null) : base("circle.png", false, true)
    {
        Initialize(obj);
    }


    void Initialize(TiledObject obj = null)
    {
        collider.isTrigger= true;
        if (obj != null)
        {
            delayInMs = obj.GetIntProperty("delayInMs", 2000);
            snackSpeed = obj.GetFloatProperty("snackSpeed", 2);
            snackRow = obj.GetIntProperty("snackRow",1);
            snackType = obj.GetIntProperty("snackType", 0);
        }
        ChangeSprite();
        ChangeX();
        currentLifeTimeMs = Time.time;
    }

    void Update()
    {
        if (initializationvalue == 0)
        {
            ChangeX();
            initializationvalue = 1;
        }

        if (hud == null) hud = game.FindObjectOfType<HUD>();
        MyGame myGame = (MyGame)game;
        if (Time.time - currentLifeTimeMs >= delayInMs)
        {
            canmove = true;
        }
        if (canmove)
        {
            y = y + 1 * snackSpeed;
        }
        if (y > 928)
        {
            Console.WriteLine("I can run these commands");
            DestoryListSnack(this);
        }
        if (y > 980)
        {
            if (snackRow == 1 || snackRow == 2)
            {
                hud.TriggerMissed(1);
            }
            else if (snackRow == 3 || snackRow == 4)
            {
                hud.TriggerMissed(2);
            }
            this.Destroy();
        }
        if (myGame.snacks1.Count == 0 && myGame.snacks2.Count == 0 && myGame.snacks3.Count == 0 && myGame.snacks4.Count == 0)
        {
            hud.canScore = false;
        }
    }

    void ChangeX()
    {

        switch (snackRow - 1)
        {
            case 0:
                x = 736;
                break;
            case 1:
                x = 896;
                break;
            case 2:
                x = 1056;
                break;
            case 3:
                x = 1216;
                break;
            default:
                x = 736;
                break;
        }
    }

    void ChangeSprite()
    {
        initializeFromTexture(Texture2D.GetInstance(snack[snackType], true));
    }

    public void DestoryListSnack(Snacks obj)
    {

        MyGame myGame = (MyGame)game;
        switch (obj.snackRow)
        {
            case 1:
                var numberOfSnacks1 = myGame.snacks1.Count();
                Console.WriteLine("Removed from list 1: {0}",numberOfSnacks1);
                if (myGame.snacks1.Count == 0) { myGame.controls.Row1Disabled = true;}
                myGame.snacks1.Remove(obj);
                Console.WriteLine("Removed from list 1: {0}",numberOfSnacks1);
                break;

            case 2:
                var numberOfSnacks2 = myGame.snacks2.Count();
                Console.WriteLine("Removed from list 2: {0}",numberOfSnacks2);
                if (myGame.snacks2.Count == 0) { myGame.controls.Row2Disabled = true;}
                myGame.snacks2.Remove(obj);
                Console.WriteLine("Removed from list 2: {0}",numberOfSnacks2);
                break;

            case 3:
                var numberOfSnacks3 = myGame.snacks3.Count();
                Console.WriteLine("Removed from list 3: {0}",numberOfSnacks3);
                if (myGame.snacks3.Count == 0) { myGame.controls.Row3Disabled = true;}
                myGame.snacks3.Remove(obj);
                Console.WriteLine("Removed from list 3: {0}",numberOfSnacks3);
                break;

            case 4:
                var numberOfSnacks4 = myGame.snacks4.Count();
                Console.WriteLine("Number in List Before Destroy: {0}",numberOfSnacks4);
                if (myGame.snacks4.Count == 0) { myGame.controls.Row4Disabled = true;}
                myGame.snacks4.Remove(obj);
                Console.WriteLine("Number in List After Destory: {0}",numberOfSnacks4);
                break;
        }
    }

}

