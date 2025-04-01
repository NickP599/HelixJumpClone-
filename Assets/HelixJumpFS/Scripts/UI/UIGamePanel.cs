using UnityEngine;

public class UIGamePanel : BallEvent
{
    [SerializeField] private GameObject passedPanel;
    [SerializeField] private GameObject defeatPanel;

    private void Start()
    {
        passedPanel.SetActive(false);
        defeatPanel.SetActive(false);
    }

    protected override void OnSegemnetCollision(SegmentType type)
    {
        if(type == SegmentType.Trap)
        {
            defeatPanel?.SetActive(true);
        }

        if(type == SegmentType.Finish)
        {
            passedPanel?.SetActive(true);
        }
    }

}
