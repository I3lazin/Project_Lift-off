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
    PlayerControl controls = null;
    public string currentLevelName;
    string musicname = null;

    public Level(string filename)
    {
        currentLevelName = filename;
        loader = new TiledLoader(filename);
        CreateLevel();
    }

    public Level(string filename, string musicfilename)
    {
        currentLevelName = filename;
        loader = new TiledLoader(filename);
        musicname = musicfilename; 
        CreateLevel();
        if (musicfilename != null)
        {
            Task.Delay(200).ContinueWith(t => { new Sound(musicfilename,false,true).Play(); });
            if (filename != "Menu.tmx") { Task.Delay(1200).ContinueWith(t => { new Sound("Start.mp3", false, false).Play(); }); }
        }
        HUD hud = new HUD();
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

        // Background layer
        Pivot foreground = new Pivot();
        AddChild(foreground);
        loader.rootObject = foreground;
        loader.LoadImageLayers(1);

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
        if (controls == null) controls = game.FindObjectOfType<PlayerControl>();
        if (currentLevelName != "Menu.tmx")
        {
            controls.CheckInputPlayer1();
            controls.CheckInputPlayer2();
        }
        else if (currentLevelName == "Menu.tmx")
        {
            controls.CheckSelectLevelInput();
        }
    }
}