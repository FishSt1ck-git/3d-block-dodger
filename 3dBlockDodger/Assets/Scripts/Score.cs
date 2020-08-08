using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public int blinkDelay;

    private Text score;
    private Text highscore;
    private bool freezeScore = false;
    private int blinkCounter;
    private string endScore;
    private float currentHighscore;

    public void Start()
    {
        score = FindObjectsOfType<Text>().Where(x => x.name == "scoreText").SingleOrDefault();
        highscore = FindObjectsOfType<Text>().Where(x => x.name == "highscoreText").SingleOrDefault();
        currentHighscore = PlayerPrefs.GetFloat("highscore", 0);
        highscore.text = $"Highscore: {currentHighscore:0}m";
    }

    public void Update()
    {
        if (!freezeScore)
        {
            score.text = player.position.z.ToString("0") + "m";
        }
        else
        {
            BlinkScore();
        }
    }

    private void BlinkScore()
    {
        if (blinkCounter <= blinkDelay)
        {
            blinkCounter++;
        }
        else
        {
            if (score.text.Equals(endScore))
            {
                score.text = string.Empty;
                blinkCounter = 0;
            }
            else
            {
                score.text = endScore;
                blinkCounter = 0;
            }
        }
    }

    public void FreezeScore()
    {
        freezeScore = true;

        if(player.position.z  > currentHighscore)
        {
            PlayerPrefs.SetFloat("highscore", player.position.z);
            endScore = $"Game over! NEW HIGHSCORE!: {score.text}";
        }
        else
        {
            endScore = $"Game over! Score: {score.text}";
        }
    }
}
