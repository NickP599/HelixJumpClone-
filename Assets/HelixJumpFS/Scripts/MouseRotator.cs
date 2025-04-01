using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    [SerializeField] private string mouseInputAxis;
    [SerializeField] private float sensetive;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            transform.Rotate(0,Input.GetAxis(mouseInputAxis) * -sensetive, 0);
        }
    }
}
