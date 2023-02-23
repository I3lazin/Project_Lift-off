using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class HUD : GameObject
{
    public bool canScore = true;
    int ScoreP1 = 0;
    int ScoreP2 = 0;
    EasyDraw Player1Score;
    EasyDraw Player2Score;
    EasyDraw trigger1, trigger2;
    Font bangerFont;
    public HUD()
    {
        //Font
        bangerFont = Utils.LoadFont("Font.ttf",60);

        //Player 1 Score
        Player1Score = new EasyDraw(700, 90);
        Player1Score.TextFont(bangerFont);
        Player1Score.TextAlign(CenterMode.Min,CenterMode.Center);
        Player1Score.Fill(Color.Yellow);
        Player1Score.Text("Score: 000000");
        Player1Score.SetXY(120, 1350);
        AddChild(Player1Score);

        //Player 2 Score
        Player2Score = new EasyDraw(700, 90);
        Player2Score.TextFont(bangerFont);
        Player2Score.TextAlign(CenterMode.Min, CenterMode.Center);
        Player2Score.Fill(Color.Yellow);
        Player2Score.Text("Score: 000000");
        Player2Score.SetXY(1930, 1350);
        AddChild(Player2Score);

        //Player 1 Feeback
        trigger1 = new EasyDraw(500, 90);
        trigger1.TextFont(bangerFont);
        trigger1.TextAlign(CenterMode.Min, CenterMode.Center);
        trigger1.Fill(Color.Yellow);
        trigger1.SetXY(120, 100);
        AddChild(trigger1);

        //Player 2 Feeback
        trigger2 = new EasyDraw(500, 80);
        trigger2.TextFont(bangerFont);
        trigger2.TextAlign(CenterMode.Min, CenterMode.Center);
        trigger2.Fill(Color.Yellow);
        trigger2.SetXY(1900, 100);
        AddChild(trigger2);


    }

    public void SetScoreP1() 
    {
        Player1Score.Text(String.Format("Score: {0:0000000}",ScoreP1), true);
    }

    public void SetScoreP2()
    {
        Player2Score.Text(String.Format("Score: {0:0000000}",ScoreP2), true);
    }

    public void AddScoreP1(int addedpoints)
    {
        ScoreP1 += addedpoints;
        SetScoreP1();
    }

    public void AddScoreP2(int addedpoints)
    {
        ScoreP2 += addedpoints;
        SetScoreP2();
    }

    public void RemoveScoreP1(int removedpoints)
    {
        ScoreP1 -= removedpoints;
        SetScoreP1();
    }

    public void RemoveScoreP2(int removedpoints)
    {
        ScoreP2 -= removedpoints;
        SetScoreP2();
    }

    public void TriggerPerfect(int player)
    {
        if (!canScore)
        {
            return;
        }
        else
        {
            if (player == 1)
            {
                AddScoreP1(250);
                trigger1.Text("PERFECT!");
                Task.Delay(200).ContinueWith(t => trigger1.ClearTransparent());
            }
            else if (player == 2)
            {
                AddScoreP2(250);
                trigger2.Text("PERFECT!");
                Task.Delay(200).ContinueWith(t => trigger2.ClearTransparent());
            }
        }
    }

    public void TriggerGood(int player)
    {
        if (!canScore)
        {
            return;
        }
        else
        {
            if (player == 1)
            {
                AddScoreP1(150); 
                trigger1.Text("GOOD!");
                Task.Delay(200).ContinueWith(t => trigger1.ClearTransparent());
            }
            else if (player == 2)
            {
                AddScoreP2(150);
                trigger2.Text("GOOD!");
                Task.Delay(200).ContinueWith(t => trigger2.ClearTransparent());
            }
        }
    }

    public void TriggerNormal(int player)
    {
        if (!canScore)
        {
            return;
        }
        else
        {
            if (player == 1)
            {
                AddScoreP1(100);
                trigger1.Text("OK!");
                Task.Delay(200).ContinueWith(t => trigger1.ClearTransparent());
            }
            else if (player == 2)
            {
                AddScoreP2(100);
                trigger2.Text("OK!");
                Task.Delay(200).ContinueWith(t => trigger2.ClearTransparent());
            }
        }
    }

    public void TriggerWrong(int player)
    {
        if (!canScore)
        {
            return;
        }
        else
        {
            if (player == 1)
            {
                if (ScoreP1 > 0) { RemoveScoreP1(50); }
                trigger1.Text("Wrong!");
                Task.Delay(200).ContinueWith(t => trigger1.ClearTransparent());
            }
            else if (player == 2)
            {
                if (ScoreP2 > 0) { RemoveScoreP2(50); }
                trigger2.Text("Wrong!");
                Task.Delay(200).ContinueWith(t => trigger2.ClearTransparent());
            }
        }
    }

    public void TriggerMissed(int player)
    {
        if (!canScore)
        {
            return;
        }
        else
        {
            if (player == 1)
            {
                if (ScoreP1 > 0) { RemoveScoreP1(50); }
                trigger1.Text("Missed!");
                trigger1.ClearTransparent();
            }
            else if (player == 2)
            {
                if (ScoreP2 > 0) { RemoveScoreP2(50); }
                trigger2.Text("Missed!");
                trigger2.ClearTransparent() ;
            }
        }
    }

    public void TriggerBad(int player)
    {
        if (!canScore)
        {
            return;
        }
        else
        {
            if (player == 1)
            {
                if (ScoreP1 > 0) { RemoveScoreP1(50); }
                trigger1.Text("Bad Item!");
                Task.Delay(200).ContinueWith(t => trigger1.ClearTransparent());
            }
            else if (player == 2)
            {
                if (ScoreP2 > 0) { RemoveScoreP2(50); }
                trigger2.Text("Bad Item!");
                Task.Delay(200).ContinueWith(t => trigger2.ClearTransparent());
            }
        }
    }

    public void TriggerToFast(int player)
    {
        if (!canScore)
        {
            return;
        }
        else
        {
            if (player == 1)
            {
                if (ScoreP1 > 0) { RemoveScoreP1(50); }
                trigger1.Text("To Fast!");
                Task.Delay(200).ContinueWith(t => trigger1.ClearTransparent());
            }
            else if (player == 2)
            {
                if (ScoreP2 > 0) { RemoveScoreP2(50); }
                trigger2.Text("To Fast!");
                Task.Delay(200).ContinueWith(t => trigger2.ClearTransparent());
            }
        }
    }
    void Update()
    {

    }
}