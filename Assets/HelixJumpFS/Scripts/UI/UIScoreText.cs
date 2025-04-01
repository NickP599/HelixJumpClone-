using UnityEngine;
using TMPro;

public class UIScoreText: BallEvent
{
    [SerializeField] private ScoreColector scoreColector;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text maxscoreText;

    private void Start()
    {
        maxscoreText.text = scoreColector.MaxScores.ToString();
    }

    protected override void OnSegemnetCollision(SegmentType type)
    {       
       scoreText.text = scoreColector.Scores.ToString();
        maxscoreText.text = scoreColector.MaxScores.ToString();   
    }
}
