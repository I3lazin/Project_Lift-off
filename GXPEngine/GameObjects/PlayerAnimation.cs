using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

public class PlayerAnimation : AnimationSprite
{
    int characterType;
    int hitType = 0;
    string[] character = {"Sprite Sheet Male.png","Sprite Sheet Female.png"};

    public PlayerAnimation(TiledObject obj = null) : base("Sprite Sheet Male.png", 5, 3, 5, true, false)
    {
        Initialize(obj);
    }

    void Initialize(TiledObject obj = null)
    {
        if (obj != null)
        {
            characterType = obj.GetIntProperty("CharacterType", 0);
        }
        ChangeSprite();
        SetCycle(0, 1, 1, false);
    }

    public void Hit(int player)
    {
        if (player == 1)
        {
            SetCycle(hitType * 5, 5, 5);
            Task.Delay(400).ContinueWith(t => SetCycle(0, 1, 1, false));
            hitType++;
        }
        else if (player == 2)
        {
            SetCycle(hitType * 5, 5, 5);
            Task.Delay(400).ContinueWith(t => SetCycle(0, 1, 1, false));
            hitType++;
        }
    }
    void ChangeSprite()
    {
        initializeFromTexture(Texture2D.GetInstance(character[characterType], true));
    }

    void Update()
    {
        Animate();
        if (hitType == 3)
        {
            hitType = 0;
        } 
    }
}
