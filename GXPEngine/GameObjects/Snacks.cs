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
    string[] snack = {"Snack0.png","Snack1.png","Snack2.png","Snack3.png","Pickle.png"};

    public Snacks(TiledObject obj = null) : base("Snack0.png", false, false)
    {
        Initialize(obj);
    }


    void Initialize(TiledObject obj = null)
    {
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
            y = y + (1.5f * snackSpeed);
        }
        if (y >= 1180)
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
        if (y > 1440)
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
                x = 970;
                break;
            case 1:
                x = 1180;
                break;
            case 2:
                x = 1395;
                break;
            case 3:
                x = 1605;
                break;
            default:
                x = 970;
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
                if (myGame.snacks1.Count == 0) { myGame.controls.Row1Disabled = true;}
                myGame.snacks1.Remove(obj);
                break;

            case 2:
                if (myGame.snacks2.Count == 0) { myGame.controls.Row2Disabled = true;}
                myGame.snacks2.Remove(obj);
                break;

            case 3:
                if (myGame.snacks3.Count == 0) { myGame.controls.Row3Disabled = true;}
                myGame.snacks3.Remove(obj);
                break;

            case 4:
                if (myGame.snacks4.Count == 0) { myGame.controls.Row4Disabled = true;}
                myGame.snacks4.Remove(obj);
                break;
        }
    }

}

