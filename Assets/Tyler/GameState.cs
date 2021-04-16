using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum GameMode
    {
        idle,
        playing,
        dead,
        levelEnd,
        end
    }

    public static float gameScore = 0;
    public static int level = 1;
    public static GameMode mode = GameMode.idle;

}

