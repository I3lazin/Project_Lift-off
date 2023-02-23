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
    int onlyonce = 0;
    public bool canmove = false;
    public int delayInMs;
    public float snackSpeed;
    public int snackRow;
    public int snackType;
    string[] snack = {"Snack0.png","Snack1.png","Snack2.png","Snack3.png","triangle.png"};

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
        if (y >= 929)
        {
            DestoryListSnack(this);
            if (snackRow == 1 && onlyonce == 0 || snackRow == 2 && onlyonce == 0)
            {
                onlyonce++;
                hud.TriggerMissed(1);
            }
            else if (snackRow == 3 && onlyonce == 0 || snackRow == 4 && onlyonce == 0)
            {
                onlyonce++;
                hud.TriggerMissed(2);
               
            }
        }
        if (y > 1208)
        {

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
                if (myGame.snacks1.Count == 0) { myGame.controls.Row1Disabled = true;}
                myGame.snacks1.Remove(obj);
                break;

            case 2:
                var numberOfSnacks2 = myGame.snacks2.Count();
                if (myGame.snacks2.Count == 0) { myGame.controls.Row2Disabled = true;}
                myGame.snacks2.Remove(obj);
                break;

            case 3:
                var numberOfSnacks3 = myGame.snacks3.Count();
                if (myGame.snacks3.Count == 0) { myGame.controls.Row3Disabled = true;}
                myGame.snacks3.Remove(obj);
                break;

            case 4:
                var numberOfSnacks4 = myGame.snacks4.Count();
                if (myGame.snacks4.Count == 0) { myGame.controls.Row4Disabled = true;}
                myGame.snacks4.Remove(obj);
                break;
        }
    }

}

