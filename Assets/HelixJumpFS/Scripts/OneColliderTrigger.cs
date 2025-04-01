using UnityEngine;

public abstract class OneColliderTrigger : MonoBehaviour
{
    private Collider lastCollider;    
    protected virtual void OnOneColliderTrigger(Collider other) { }

    private void OnTriggerEnter(Collider other)
    {
        if (lastCollider != null && lastCollider != other) return;

        lastCollider = other;

        OnOneColliderTrigger(other);

        Debug.Log("Pong");
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (lastCollider == other)
            lastCollider = null;
    }
}
