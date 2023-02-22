using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Level : Pivot
{
    TiledLoader loader;
    public string currentLevelName;


    public Level(string filename)
    {
        currentLevelName = filename;
        loader = new TiledLoader(filename);
        CreateLevel();
    }

    public Level(string filename, string musicname)
    {
        currentLevelName= filename;
        loader = new TiledLoader(filename);
        CreateLevel();
        HUD hud = new HUD();
        if (musicname != null)
        {
            Task.Delay(1000).ContinueWith(t => { new Sound(musicname).Play(); });
        }
    }

    void CreateLevel(bool includeImageLayers=true)
    {
        loader.autoInstance = true;
        loader.addColliders = false;

        // Background layer
        Pivot background = new Pivot();
        AddChild(background);
        loader.rootObject = background;
        loader.LoadImageLayers(0);

        
        // Main Layer 1
        Pivot mainlayer1 = new Pivot();
        AddChild(mainlayer1);
        loader.rootObject = mainlayer1;
        loader.LoadObjectGroups(0);

        // Main Layer 2
        Pivot mainlayer2 = new Pivot();
        AddChild(mainlayer2);
        loader.rootObject = mainlayer2;
        loader.LoadObjectGroups(1);

        // Seperate snacks into different Lists based off the row
        Snacks[] snacks = mainlayer1.FindObjectsOfType<Snacks>();
        MyGame myGame = (MyGame)game;
        foreach (Snacks snack in snacks)
        {
            switch (snack.snackRow)
            {
                case 1:
                    myGame.snacks1.Add(snack);
                    break;
                case 2:
                    myGame.snacks2.Add(snack);
                    break;
                case 3:
                    myGame.snacks3.Add(snack);
                    break;
                case 4:
                    myGame.snacks4.Add(snack);
                    break;
            }
        }
    }

    void Update()
    {

    }
}



