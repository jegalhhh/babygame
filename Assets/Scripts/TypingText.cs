// TextMeshPro 버전이라면 이걸로!
using UnityEngine;
using TMPro;
using System.Collections;

public class TypingText : MonoBehaviour
{
    public TextMeshProUGUI uiText;  // TextMeshPro 텍스트
    [TextArea]
    public string fullText;         // 출력할 문장
    public float typingSpeed = 0.05f;

    private Coroutine typingCoroutine;

    void OnEnable()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        uiText.text = "";
        foreach (char c in fullText)
        {
            uiText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
