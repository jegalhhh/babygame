using UnityEngine;

public class Scenesloader : MonoBehaviour
{
    public void LoadTutorialScene()
    {
        SceneFader fader = FindObjectOfType<SceneFader>();
        if (fader != null)
        {
            fader.FadeToScene("TutorialScene");
        }
        else
        {
            Debug.LogWarning("SceneFader가 씬에 없습니다. 즉시 전환합니다.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
        }
    }
}
