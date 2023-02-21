using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Timer
{
    int starttime;
    bool timerOn;
    int waitperiod;
    public Timer(int delay)
    {
        waitperiod = delay;
    }

    public bool wait()
    {
        starttime = Time.time;
        if (Time.time - starttime == waitperiod)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        if (timerOn)
        {
            wait();
        }
    }
}


