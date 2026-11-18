using UnityEngine;
using TMPro;


public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI display;
    public int score = 0;
    public static scoreManager instance; 

    void Start()
    {
        display.text = "Score: " + score;
    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        display.text = "Score: " + score;
    }
}
