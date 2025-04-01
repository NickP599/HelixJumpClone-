using UnityEngine;

public abstract class BallEvent : MonoBehaviour
{
  [SerializeField] protected BallController ballController;

    protected virtual void Awake()
    {
        ballController.OnSigmentCollision.AddListener(OnSegemnetCollision);
    }
    protected virtual void OnDestroy()
    {
        ballController.OnSigmentCollision.RemoveListener(OnSegemnetCollision);
    }

    protected virtual void OnSegemnetCollision(SegmentType type) { }
}
