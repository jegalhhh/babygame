using UnityEngine;
using System.Collections.Generic;

public class UIcontrol : MonoBehaviour
{
    public List<GameObject> targetUIs;

    public void ToggleUI()
    {
        foreach (GameObject ui in targetUIs)
        {
            bool isActive = ui.activeSelf;
            ui.SetActive(!isActive);
        }
    }
}
