using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [Header("Fall")]
    [SerializeField] private float fallHight;
    [SerializeField] private float fallSpeedDefault;
    [SerializeField] private float fallSpeedMax;
    [SerializeField] private float fallSpeedAxeleratin;
    
    private Animator animator
        ;
    private float fallSpeed;
    private float floorY;

    void Start()
    {
        animator = GetComponent<Animator>();

        enabled = false;

    }

    void Update()
    {
        if (transform.position.y > floorY)
        {
            transform.Translate(0, -fallSpeed * Time.deltaTime, 0);
            
            if(fallSpeed < fallSpeedMax)
            {
                fallSpeed += fallSpeedAxeleratin * Time.deltaTime;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, floorY, transform.position.z);
            enabled = false;
        }
    }

    public void Jump()
    {
        fallSpeed = fallSpeedDefault;
        animator.speed = 1;
    }

    public void Fall(float startFloorY)
    {
        animator.speed = 0;
        enabled = true;
        floorY = startFloorY - fallHight;
    }

    public void Stop()
    {
        animator.speed = 0;
    }
}
