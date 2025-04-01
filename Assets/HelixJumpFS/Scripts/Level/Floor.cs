using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private List<Segment> defaultSegment;
    private Rigidbody rb;
    public bool IsFloor;

    private void Awake()
    {
        IsFloor = false;
        rb = GetComponent<Rigidbody>();
    }

    public void AddEmptySegment(int amount)
    {
        for (int i = 0; i < amount; i++) 
        {
            defaultSegment[i].SetEmpty();
        }

        for (int i = amount; i > 0 ; i--)
        {
            defaultSegment.RemoveAt(i);
        }
    }

    public void SetRandomTrapSegment(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, defaultSegment.Count);

            defaultSegment[index].SetTrap();
            defaultSegment.RemoveAt(index);
        }
    }

    public void SetRandomRotation()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public void SetAllFinishSegment()
    {
        for (int i = 0;i < defaultSegment.Count; i++)
        {
            defaultSegment[i].SetFinish();
        }
    }

    public void SetKinimatickFals()
    {
        rb.isKinematic = false;
    }
}




