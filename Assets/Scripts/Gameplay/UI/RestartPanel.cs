using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RestartPanel : MonoBehaviour
{
    public Text getscore;
    public Text score;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowRestartPanel()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
        score.text = getscore.text;
    }

    public void RestartMainScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
