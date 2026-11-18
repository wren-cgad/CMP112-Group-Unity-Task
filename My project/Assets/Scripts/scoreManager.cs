using UnityEngine;
using TMPro;


public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI display;
    public int score = 0;
    public static scoreManager instance; 

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        display.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 1;
        display.text = "" + score;
    }
}
