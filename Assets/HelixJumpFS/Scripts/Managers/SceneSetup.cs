using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private LevelProgres gameProgres;


    private void Start()
    {
        levelGenerator.Generate(gameProgres.CurrentLevel);

        ballController.transform.position = new Vector3(ballController.transform.position.x, levelGenerator.LastFloorY, ballController.transform.position.z);
    }
}
