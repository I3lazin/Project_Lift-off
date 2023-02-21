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
    HUD hud = new HUD();
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
        if (Time.time - currentLifeTimeMs >= delayInMs)
        {
            canmove = true;
        }
        if (canmove)
        {
            y = y + 1 * snackSpeed;
        }
        if (y > 929)
        {
            hud.TriggerMissed();
            DestoryListSnack();
        }
        if (y > 1088)
        {
            this.Destroy();
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

    void DestoryListSnack()
    {
        MyGame myGame = (MyGame)game;
        switch (snackRow)
        {
            case 1:
                myGame.snacks1.Remove(this);
                break;

            case 2:
                myGame.snacks2.Remove(this);
                break;

            case 3:
                myGame.snacks3.Remove(this);
                break;

            case 4:
                myGame.snacks4.Remove(this);
                break;
        }
    }
}

