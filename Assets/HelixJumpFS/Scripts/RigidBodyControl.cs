using UnityEngine;

public class RigidBodyControl : BallEvent
{
    [SerializeField] private LevelGenerator levelGenerator;

    protected override void OnSegemnetCollision(SegmentType type)
    {

        if (type == SegmentType.Empty)
        {
            for (int i = 0; i < levelGenerator.FloorPrefabOnScene.Count; i++)
            {
                if (levelGenerator.FloorPrefabOnScene[i] is Floor floor)
                {
                    floor.IsFloor = true;
                }
            }
        }

    }
}

