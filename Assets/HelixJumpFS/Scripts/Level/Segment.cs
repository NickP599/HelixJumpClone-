using UnityEngine;

public enum SegmentType
{
    Default,
    Trap,
    Empty,
    Finish
}

public class Segment : MonoBehaviour
{
    [SerializeField] private SegmentType type;

    [SerializeField] private Material trapMat;
    [SerializeField] private Material finshMat;

    private MeshRenderer meshRenderer;

    public SegmentType Type => type;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    public void SetTrap()
    {
        meshRenderer.enabled = true;

        meshRenderer.material = trapMat;

        type = SegmentType.Trap;
    }

    public void SetEmpty()
    {
        meshRenderer.enabled = false;

        type = SegmentType.Empty;
    }

    public void SetFinish()
    {
        meshRenderer.enabled = true;

        meshRenderer.material = finshMat;

        type = SegmentType.Finish;
    }

}