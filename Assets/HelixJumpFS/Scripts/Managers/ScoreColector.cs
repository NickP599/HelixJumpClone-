using UnityEngine;

public class ScoreColector : BallEvent
{
    [SerializeField] private LevelProgres levelProgres;

    private int scores;
    public int Scores => scores;

    private int maxScores;
    public int MaxScores => maxScores;

    private int EmptySegmentPassedAmount = 0;

    protected override void Awake()
    {
        base.Awake();
        Load();
    }


    protected override void OnSegemnetCollision(SegmentType type)
    {       
        if(type != SegmentType.Empty)
        {
            EmptySegmentPassedAmount = 0;
        }

        if(type == SegmentType.Empty)
        {
            scores += levelProgres.CurrentLevel;
            EmptySegmentPassedAmount++;

            if(EmptySegmentPassedAmount >= 2)
            {
                scores += (levelProgres.CurrentLevel * EmptySegmentPassedAmount);
            }
        }  
           
        if(type == SegmentType.Finish)
        {
            if (scores > maxScores)
            {
                maxScores = scores; 
            }
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("levelProgres: maxScores", maxScores);
    }

    private void Load()
    {
        maxScores = PlayerPrefs.GetInt("levelProgres: maxScores",0);
    }
}
