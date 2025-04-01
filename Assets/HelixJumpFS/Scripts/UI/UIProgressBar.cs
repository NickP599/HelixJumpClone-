using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProgressBar : BallEvent
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private LevelProgres levelProgres;

    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI NextLevelText;
    [SerializeField] private Image progressBar;

    private float fillStepAmout;

    private void Start()
    {
        currentLevelText.text = levelProgres.CurrentLevel.ToString();
        NextLevelText.text = (levelProgres.CurrentLevel + 1).ToString();
        progressBar.fillAmount = 0;

        fillStepAmout = 1 / levelGenerator.FloorAmount;
    }

    private void Update()
    {
        Debug.Log(fillStepAmout);
    }

    protected override void OnSegemnetCollision(SegmentType type)
    {
        if(type == SegmentType.Empty || type == SegmentType.Finish)
        {
            progressBar.fillAmount += fillStepAmout;
        }
    }
}
