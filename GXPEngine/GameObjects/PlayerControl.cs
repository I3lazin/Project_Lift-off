using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

class PlayerControl : Pivot
{
    PlayerControl() : base()
    {

    }

    void CheckInputs()
    {
        // Player 1
        if (Input.GetKeyDown(Key.Q))
        {
            Console.WriteLine("Pressed: Q");
        }
        if (Input.GetKeyDown(Key.W))
        {
            Console.WriteLine("Pressed: W");
        }
        if (Input.GetKeyDown(Key.E))
        {
            Console.WriteLine("Pressed: E");
        }
        if (Input.GetKeyDown(Key.R))
        {
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

    void Update()
    {
        CheckInputs();
    }
}
