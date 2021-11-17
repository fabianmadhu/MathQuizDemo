using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string selected)
    {
        SceneManager.LoadScene(selected);
    }
    public void selectGamemode(string mode)
    {
        QuestionManager.op = mode;
        SceneManager.LoadScene("PlayGround");
    }
}
