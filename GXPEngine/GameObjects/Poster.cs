using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

public class Poster : Sprite
{

    public Poster(TiledObject obj = null) : base("Poster.png", false, false)
    {
        Initialize(obj);
    }


    void Initialize(TiledObject obj = null)
    {

    }
}


