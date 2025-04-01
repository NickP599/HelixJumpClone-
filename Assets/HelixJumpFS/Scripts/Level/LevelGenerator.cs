using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;

    [Header("Settings")]
    [SerializeField] private int defaultFloorAmount;
    [SerializeField] private float floorHeight;
    [SerializeField] private int AmountEmptySegment;
    [SerializeField] private int minTrapSegment;
    [SerializeField] private int maxTrapSegment;

    private List<Floor> floorPrefabOnScene;
    public List<Floor> FloorPrefabOnScene => floorPrefabOnScene;

    private float floorAmount = 0;
    public float FloorAmount => floorAmount;

    private float lastFloorY = 0;
    public float LastFloorY => lastFloorY;

    private void Awake()
    {
        floorPrefabOnScene = new List<Floor>();
    }

    private void Update()
    {
        for (int i = 0; i < floorPrefabOnScene.Count; i++)
        {
            Debug.Log(floorPrefabOnScene[i]);
        }
       
    }
    public void Generate(int level)
    {
        DestroyChild();

        floorAmount = defaultFloorAmount + level;

        axis.transform.localScale = new Vector3(1, floorAmount * floorHeight + 1, 1);

        for (int i = 0; i < floorAmount; i++)
        {
            Floor floor = Instantiate(floorPrefab, transform);
            floor.transform.Translate(0, i * floorHeight, 0);
            floor.name = "Floor " + i;

            if (i == 0)
            {
                floor.SetAllFinishSegment();
            }

            if(i > 0 && i < floorAmount - 1)
            {
                floor.SetRandomRotation();
                floor.AddEmptySegment(AmountEmptySegment);
                floor.SetRandomTrapSegment(Random.Range(minTrapSegment,maxTrapSegment + 1));
            }

            if(i == floorAmount - 1)
            {
                floor.AddEmptySegment(2);

                lastFloorY = floor.transform.position.y;
            }

            floorPrefabOnScene.Add(floor);

        }

    }

    private void DestroyChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i) == axis) continue;

            Destroy(transform.GetChild(i).gameObject);

        }
    }
}
