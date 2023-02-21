using System;                   // System contains a lot of default C# libraries 
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Activation;
using System.Threading.Tasks;
using GXPEngine;                // GXPEngine contains the engine
using TiledMapParser;

public class MyGame : Game {
    string nextlevel = null;
    string nextsong = null;
    public List<Snacks> snacks1 = new List<Snacks>();
    public List<Snacks> snacks2 = new List<Snacks>();
    public List<Snacks> snacks3 = new List<Snacks>();
    public List<Snacks> snacks4 = new List<Snacks>();

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

    public void LoadLevel(string filename, string musicname)
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
            AddChild(new HUD());
            nextlevel= null;
        }
    }

	void Update() {

    }

	static void Main() {
		new MyGame().Start();
	}
}