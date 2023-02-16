using System;                   // System contains a lot of default C# libraries 
using GXPEngine;                // GXPEngine contains the engine
using TiledMapParser;

public class MyGame : Game {
	SoundChannel soundTrack;

	public MyGame() : base(2560, 1440, false, false, 1920, 1080)
	{
        LoadLevel("Level1.tmx");
    }

    void LoadLevel(string filename)
    {
        TiledLoader loader = new TiledLoader(filename);
        loader.autoInstance = true;

		// Background layer
        Pivot background = new Pivot();
        AddChild(background);
		loader.rootObject= background;
		loader.LoadImageLayers(0);

		// Main Layer 1
		Pivot mainlayer1= new Pivot();
		AddChild(mainlayer1);
		loader.rootObject = mainlayer1;
		loader.LoadObjectGroups(0);

        // Main Layer 2
        Pivot mainlayer2 = new Pivot();
        AddChild(mainlayer2);
        loader.rootObject = mainlayer2;
        loader.LoadObjectGroups(1);
    }

	void MoveSpaceShip() {
		if (Input.GetKey(Key.A)) {

		}
		if (Input.GetKey(Key.D)) {

		}
		if (Input.GetKey(Key.W)) {

		}
		if (Input.GetKey(Key.S)) {

		}
	}



	void Update() {
		MoveSpaceShip();
	}

	static void Main() {
		new MyGame().Start();
	}
}