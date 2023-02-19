using System;                   // System contains a lot of default C# libraries 
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Activation;
using GXPEngine;                // GXPEngine contains the engine
using TiledMapParser;

public class MyGame : Game {
	SoundChannel soundTrack;
    EasyDraw Player1ScoreUI;
    EasyDraw Player2ScoreUI;
    string nextlevel = null;
    string nextsong = null;
    public MyGame() : base(1920, 1080, true)
	{
        LoadLevel("Level1.tmx", "Testsong.wav");
        OnAfterStep += CheckLoadLevel;
    }

    void DestroyAll()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.Destroy();
        }
    }

    void LoadLevel(string filename, string musicname)
    {
        nextlevel = filename;
        nextsong = musicname;
    }

    void CheckLoadLevel()
    {
        if (nextlevel != null)
        {
            DestroyAll();
            AddChild(new Level(nextlevel, nextsong));

            CreateUI();
            nextlevel= null;
        }
    }

    void CreateUI()
    {
        Player1ScoreUI = new EasyDraw(100, 20, false);
        Player2ScoreUI = new EasyDraw(100, 20, false);
        Player2ScoreUI.SetXY(width - Player2ScoreUI.width, 0);
    }

	void Update() {
            
    }

	static void Main() {
		new MyGame().Start();
	}
}