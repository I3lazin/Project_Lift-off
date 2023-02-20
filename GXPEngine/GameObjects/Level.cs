using System;
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
        if (musicname != null)
        {
            new Sound(musicname).Play();
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
        loader.addColliders = true;
        Pivot mainlayer1 = new Pivot();
        AddChild(mainlayer1);
        loader.rootObject = mainlayer1;
        loader.LoadObjectGroups(0);

        // Main Layer 2
        loader.addColliders = false;
        Pivot mainlayer2 = new Pivot();
        AddChild(mainlayer2);
        loader.rootObject = mainlayer2;
        loader.LoadObjectGroups(1);
    }

    void Update()
    {

    }
}



