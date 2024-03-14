using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    // Variables
    [Header("Button")]
    public Button button;
    [Header("Scene Loader")]
    public SceneLoader sceneLoader;
    [Header("Scene data")]
    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        sceneLoader = gameObject.AddComponent<SceneLoader>();

        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    void TaskOnClick()
    {
        sceneLoader.LoadSceneAsyncByIndex(sceneIndex);
    }
}
