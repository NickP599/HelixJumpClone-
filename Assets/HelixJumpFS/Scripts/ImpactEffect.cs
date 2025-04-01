
using UnityEngine;

public class ImpactEffect : BallEvent
{
    [SerializeField] private GameObject gameObjectPrefab;
    [SerializeField] private Transform targerTransform;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private SenRandomColors targetColor;
  
    [SerializeField] private float OffSetY;

 

   

    protected override void OnSegemnetCollision(SegmentType type)
    {
        if(type != SegmentType.Empty)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
       if(gameObjectPrefab != null)
        {
            GameObject gameObject = Instantiate(gameObjectPrefab, parentTransform);
            gameObject.transform.position = new Vector3(transform.position.x, targerTransform.position.y + OffSetY, transform.position.z);
            SpriteRenderer spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
            Color color = targetColor.ballMathColor;
            color.a = 1f;
            spriteRenderer.color = color;


            Destroy(gameObject, 3);
        }     
          
    }

}
