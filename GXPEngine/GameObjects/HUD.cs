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
    int ScoreP1 = 0;
    int ScoreP2 = 0;
    EasyDraw Player1Score;
    EasyDraw Player2Score;
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
        Player2Score.Text(String.Format("Score: {0:0000000}", ScoreP2), true);
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

    }

    public void TriggerGood(int player)
    {

    }

    public void TriggerNormal(int player)
    {

    }

    public void TriggerWrong(int player)
    {

    }

    public void TriggerMissed(int player)
    {

    }
}