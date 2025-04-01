using UnityEngine;

public class ImputManager : BallEvent
{
    [SerializeField] private MouseRotator mouseRotator;

    protected override void OnSegemnetCollision(SegmentType type)
    {
        if(type == SegmentType.Finish || type == SegmentType.Trap)
        {
            mouseRotator.enabled = false;
        }
    }
}
