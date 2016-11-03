using UnityEngine;

public class Menu : MonoBehaviour 
{
    public GameObject menuButtonPrefab;
    private string[] _scenes = { "SciFi", "demoScene_free"};

	void Start () 
	{
	    for(var i = 0; i < _scenes.Length; i++)
        {
            CreateButton(i);
        }
	}
	
    private void CreateButton(int i)
    {
        if(menuButtonPrefab == null)
        {
            Debug.LogError("Button prefab is null!");
            return;
        }

        var go = Instantiate(menuButtonPrefab) as GameObject;
        go.transform.SetParent(this.transform, false);
        var button = go.GetComponent<MenuButton>();
        button.Initialize(_scenes[i]);
    }
}