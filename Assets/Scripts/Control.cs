using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour 
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }
}