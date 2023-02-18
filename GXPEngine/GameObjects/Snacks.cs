﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

class Snacks : Sprite
{
    int currentLifeTimeMs = 0;
    bool canmove = false;
    int delayInMs;
    float snackSpeed;
    int snackRow;
    int snackType;
    int initializeValue = 0;
    public Snacks(TiledObject obj=null) : base("circle.png", true, true)
    {
        Initialize(obj);
    }

    public Snacks(string filename, TiledObject obj = null) : base(filename, true, true)
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
            snackType = obj.GetIntProperty("snackType", 1);
        }
    }

    void Update()
    {
        if (initializeValue == 0) { ChangeX(); initializeValue++; }
        currentLifeTimeMs += Time.deltaTime;
        if (currentLifeTimeMs >= delayInMs)
        {
            canmove = true;
        }

        if (canmove)
        {
            y = y + 1 * snackSpeed;
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
        switch (snackType - 1)
        {
            case 0:

                break;

            case 1:

                break;

            case 2:

                break;

            case 3:

                break;
        }
    }

}

