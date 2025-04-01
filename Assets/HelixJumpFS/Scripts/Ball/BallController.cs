using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneColliderTrigger
{
   private BallMovement m_BallMovement;

    [HideInInspector] public UnityEvent<SegmentType> OnSigmentCollision;

    private void Start()
    {
        m_BallMovement = GetComponent<BallMovement>();
    }

    protected override void OnOneColliderTrigger(Collider other)
    {
       Segment segment = other.GetComponent<Segment>();
       

        if (segment != null)
        {
            if(segment.Type == SegmentType.Empty)
            {
                m_BallMovement.Fall(other.transform.position.y);
               
            }

            if(segment.Type == SegmentType.Default)
            {
                m_BallMovement.Jump();

            }

            if(segment.Type == SegmentType.Trap)
            {
                m_BallMovement.Stop();
            }

            OnSigmentCollision.Invoke(segment.Type);
        }
    }
}
