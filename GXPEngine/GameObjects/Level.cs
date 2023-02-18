using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

class Level : GameObject
{
    TiledLoader loader;
    string currentLevelName;

    public Level(string filename)
    {
        currentLevelName = filename;
        loader = new TiledLoader(filename);
        CreateLevel();
    }

    void CreateLevel(bool includeImageLayers=true)
    {
        loader.autoInstance = true;

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
    }

    public string GetCurrentLevel()
    {
        return currentLevelName;
    }
}



