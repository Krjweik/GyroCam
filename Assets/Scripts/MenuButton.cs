using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour 
{
    private string _sceneName;

    public void Initialize(string sceneName)
    {
        _sceneName = sceneName;

        var text = GetComponentInChildren<Text>();
        text.text = sceneName;

        var button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}