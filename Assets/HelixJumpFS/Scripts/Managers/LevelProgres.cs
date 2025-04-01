using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgres : BallEvent
{
    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    protected override void Awake()
    {
        base.Awake();
        Load();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
#endif

    protected override void OnSegemnetCollision(SegmentType type)
    {
        if(type == SegmentType.Finish)
           currentLevel++;

        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("LevelProgres :currentLevel ", currentLevel);
    }

    private void Load()
    {
        currentLevel = PlayerPrefs.GetInt("LevelProgres :currentLevel ", 1);
    }

#if UNITY_EDITOR
    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

#endif
}
