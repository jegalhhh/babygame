using UnityEngine;

public class lastloader : MonoBehaviour
{
    public void LoadTutorialScene()
    {
        SceneFader fader = FindObjectOfType<SceneFader>();
        if (fader != null)
        {
            fader.FadeToScene("last");
        }
        else
        {
           
            UnityEngine.SceneManagement.SceneManager.LoadScene("last");
        }
    }
}
