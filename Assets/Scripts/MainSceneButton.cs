using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainSceneChange()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void StartSceneChange()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
