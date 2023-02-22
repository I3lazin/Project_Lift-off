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
    int waitingperiod = 500;
    EasyDraw Player1Score;
    EasyDraw Player2Score;
    EasyDraw triggerPerfect;
    EasyDraw triggerGood;
    EasyDraw triggerNormal;
    EasyDraw triggerWrong;
    EasyDraw triggerMissed;
    EasyDraw triggerBad;
    EasyDraw triggerToFast;
    Font bangerFont;
    public HUD()
    {
        //Font
        bangerFont = Utils.LoadFont("Font.otf",40);

        //Player 1 Score
        Player1Score = new EasyDraw(500, 60);
        Player1Score.TextFont(bangerFont);
        Player1Score.TextAlign(CenterMode.Min,CenterMode.Center);
        Player1Score.Fill(Color.Yellow);
        Player1Score.Text("Score: 000000");
        Player1Score.SetXY(120, 1020);
        AddChild(Player1Score);

        //Player 1 Hit

        //Player 2 Score
        Player2Score = new EasyDraw(500, 60);
        Player2Score.TextFont(bangerFont);
        Player2Score.TextAlign(CenterMode.Min, CenterMode.Center);
        Player2Score.Fill(Color.Yellow);
        Player2Score.Text("Score: 000000");
        Player2Score.SetXY(1450, 1020);
        AddChild(Player2Score);





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
            triggerPerfect = new EasyDraw(500, 60);
            triggerPerfect.TextFont(bangerFont);
            triggerPerfect.TextAlign(CenterMode.Min, CenterMode.Center);
            triggerPerfect.Fill(Color.Yellow);
            triggerPerfect.Text("PERFECT!");
            if (player == 1)
            {
                AddScoreP1(200);
                triggerPerfect.SetXY(120, 100);
            }
            else if (player == 2)
            {
                AddScoreP2(200);
                triggerPerfect.SetXY(1100, 100);
            }
        }
        AddChild(triggerPerfect);
        Task.Delay(waitingperiod).ContinueWith(t => { RemoveChild(triggerPerfect); });
    }

    public void TriggerGood(int player)
    {
        if (!canScore)
        {
            return;
        }
        else
        {
            triggerGood = new EasyDraw(500, 60);
            triggerGood.TextFont(bangerFont);
            triggerGood.TextAlign(CenterMode.Min, CenterMode.Center);
            triggerGood.Fill(Color.Yellow);
            triggerGood.Text("GOOD!");
            if (player == 1)
            {
                AddScoreP1(150);
                triggerGood.SetXY(120, 100);
            }
            else if (player == 2)
            {
                AddScoreP2(150);
                triggerGood.SetXY(1100, 100);
            }
            AddChild(triggerGood);
            Task.Delay(waitingperiod).ContinueWith(t => { RemoveChild(triggerGood); });
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
            triggerNormal = new EasyDraw(500, 60);
            triggerNormal.TextFont(bangerFont);
            triggerNormal.TextAlign(CenterMode.Min, CenterMode.Center);
            triggerNormal.Fill(Color.Yellow);
            triggerNormal.Text("OK!");
            if (player == 1)
            {
                AddScoreP1(100);
                triggerNormal.SetXY(120, 100);
            }
            else if (player == 2)
            {
                AddScoreP2(100);
                triggerNormal.SetXY(1100, 100);
            }
            AddChild(triggerNormal);
            Task.Delay(waitingperiod).ContinueWith(t => { RemoveChild(triggerNormal); });
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
            triggerWrong = new EasyDraw(500, 60);
            triggerWrong.TextFont(bangerFont);
            triggerWrong.TextAlign(CenterMode.Min, CenterMode.Center);
            triggerWrong.Fill(Color.Yellow);
            triggerWrong.Text("WRONG!");
            if (player == 1)
            {
                RemoveScoreP1(50);
                triggerWrong.SetXY(120, 100);
            }
            else if (player == 2)
            {
                RemoveScoreP2(50);
                triggerWrong.SetXY(1100, 100);
            }
            AddChild(triggerWrong);
            Task.Delay(waitingperiod).ContinueWith(t => { RemoveChild(triggerWrong); });
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
            triggerMissed = new EasyDraw(500, 60);
            triggerMissed.TextFont(bangerFont);
            triggerMissed.TextAlign(CenterMode.Min, CenterMode.Center);
            triggerMissed.Fill(Color.Yellow);
            triggerMissed.Text("MISSED!");
            if (player == 1)
            {
                RemoveScoreP1(50);
                triggerMissed.SetXY(120, 100);
            }
            else if (player == 2)
            {
                RemoveScoreP2(50);
                triggerMissed.SetXY(1100, 100);
            }
            AddChild(triggerMissed);
            Task.Delay(waitingperiod).ContinueWith(t => { RemoveChild(triggerMissed); });
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
            triggerBad = new EasyDraw(500, 60);
            triggerBad.TextFont(bangerFont);
            triggerBad.TextAlign(CenterMode.Min, CenterMode.Center);
            triggerBad.Fill(Color.Yellow);
            triggerBad.Text("BAD ITEM!");
            if (player == 1)
            {
                RemoveScoreP1(50);
                triggerBad.SetXY(120, 100);
            }
            else if (player == 2)
            {
                RemoveScoreP2(50);
                triggerBad.SetXY(1100, 100);
            }
            AddChild(triggerBad);
            Task.Delay(waitingperiod).ContinueWith(t => { RemoveChild(triggerBad); });
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
            triggerToFast = new EasyDraw(500, 60);
            triggerToFast.TextFont(bangerFont);
            triggerToFast.TextAlign(CenterMode.Min, CenterMode.Center);
            triggerToFast.Fill(Color.Yellow);
            triggerToFast.Text("TO FAST!");
            if (player == 1)
            {
                RemoveScoreP1(50);
                triggerToFast.SetXY(120, 100);
            }
            else if (player == 2)
            {
                RemoveScoreP2(50);
                triggerToFast.SetXY(1100, 100);
            }
            AddChild(triggerToFast);
            Task.Delay(waitingperiod).ContinueWith(t => { RemoveChild(triggerToFast); });
        }
    }
}