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
    int initializationValue = 0;
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
        SetCycle(0, 1, 1);
    }

    public void Hit(int player)
    {
        Random rand = new Random();
        if (player == 1)
        {
            SetCycle(rand.Next(2), 5, 4);
            Task.Delay(350).ContinueWith(t => SetCycle(0, 1, 1));
        }
        else if (player == 2)
        {
            SetCycle(rand.Next(2), 5, 4);
            Task.Delay(350).ContinueWith(t => SetCycle(0, 1, 1));
        }
    }
    void ChangeSprite()
    {
        initializeFromTexture(Texture2D.GetInstance(character[characterType], true));
    }

    void Update()
    {
        Animate();
    }
}
