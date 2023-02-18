using System;                   // System contains a lot of default C# libraries 
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Activation;
using GXPEngine;                // GXPEngine contains the engine
using TiledMapParser;

public class MyGame : Game {
	SoundChannel soundTrack;
    Sound song1 = new Sound("Testsong.wav", false, true);
    bool notinlevel = true;
    EasyDraw Player1ScoreUI;
    EasyDraw Player2ScoreUI;
    public MyGame() : base(1920, 1080, false)
	{

    }

    void LoadLevel(string filename)
    {
        DestroyAll();
        AddChild(new Level(filename));
        CreateUI();
        notinlevel= false;
        song1.Play();
    }

	void CheckInputs() {
        // Player 1
		if (Input.GetKeyDown(Key.Q)) {
            Console.WriteLine("Pressed: Q");
        }
		if (Input.GetKeyDown(Key.W)) {
            Console.WriteLine("Pressed: W");
        }
		if (Input.GetKeyDown(Key.E)) {
            Console.WriteLine("Pressed: E");
        }
		if (Input.GetKeyDown(Key.R)) {
            Console.WriteLine("Pressed: R");
        }
        // Player 2
        if (Input.GetKeyDown(Key.O))
        {
            Console.WriteLine("Pressed: O");
        }
        if (Input.GetKeyDown(Key.P))
        {
            Console.WriteLine("Pressed: P");
        }
        if (Input.GetKeyDown(Key.SQ_BRACKET_1))
        {
            Console.WriteLine("Pressed: [");
        }
        if (Input.GetKeyDown(Key.SQ_BRACKET_2))
        {
            Console.WriteLine("Pressed: ]");
        }

        // Select level
        if (Input.GetKeyDown(Key.B))
        {
            Console.WriteLine("Pressed: B");
        }
        if (Input.GetKeyDown(Key.N))
        {
            Console.WriteLine("Pressed: N");
        }
    }

    void DestroyAll()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.Destroy();
        }

    }

    void CreateUI()
    {
        Player1ScoreUI = new EasyDraw(100, 20, false);
        Player2ScoreUI = new EasyDraw(100, 20, false);
        Player2ScoreUI.SetXY(width - Player2ScoreUI.width, 0);
    }

	void Update() {
        if (Input.AnyKey() && notinlevel)
        {
            LoadLevel("Level1.tmx");
        }    
    }

	static void Main() {
		new MyGame().Start();
	}
}