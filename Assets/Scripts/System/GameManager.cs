using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awaker()
    {
        Application.targetFrameRate = 60;

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
