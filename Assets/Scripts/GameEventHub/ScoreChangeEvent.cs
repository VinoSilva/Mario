    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreChangeEvent
{
    private static int scoreAdd = 0;

    public static int ScoreAdd { get => scoreAdd; private set => scoreAdd = value; }

    public static void Raise(GameEvent e,int scoreToAdd){
        ScoreAdd = scoreToAdd;

        e.Raise();

        ScoreAdd = 0;
    }
}
