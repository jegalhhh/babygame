using UnityEngine;

public class AppClick : MonoBehaviour
{
    public GameObject[] PhoneUIs;

    void Start()
    {
        foreach (GameObject ui in PhoneUIs)
        {
            ui.SetActive(false);  // 처음엔 안 보이게
        }
    }

    public void ShowPhoneUIs()
    {
        foreach (GameObject ui in PhoneUIs)
        {
            ui.SetActive(true);  // 클릭 시 보이게
            ui.GetComponent<UIFadeIn>()?.StartFade();
        }
    }
}
