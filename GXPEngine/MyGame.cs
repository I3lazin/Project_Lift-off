using System;                   // System contains a lot of default C# libraries 
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Activation;
using GXPEngine;                // GXPEngine contains the engine
using TiledMapParser;

public class MyGame : Game {
    EasyDraw Player1ScoreUI;
    EasyDraw Player2ScoreUI;
    string nextlevel = null;
    string nextsong = null;
    int scoreP1 = 0;
    int scoreP2 = 0;
    public MyGame() : base(1920, 1080, false, false, 960, 540)
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
        Player1ScoreUI.color = 0xffffff;
        Player2ScoreUI.color = 0xffffff;
        Player1ScoreUI.Text("test: " + scoreP1,0,0);
        Player2ScoreUI.Text("test: " + scoreP2,0,0);
        AddChild(Player1ScoreUI);
        AddChild(Player2ScoreUI);
    }

	void Update() {

    }

	static void Main() {
		new MyGame().Start();
	}
}