using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    public TimerCountdown Timer;
    public Score Points;
    

    public void GameOver(int highScore)
    {
        GameOverScreen.Setup(highScore);
    }
    private void Update()
    {
        if (Timer.secondsLeft == 0)
        {
            
            GameOver(Points.highScore);
        }
    }

}
