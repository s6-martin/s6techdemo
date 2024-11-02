using System;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    TMP_Text _hudInfo;

    public void setHUD(string name, string tag)
    {
        if (tag == "Door")
            _hudInfo.text = "Press F to open door";

        _hudInfo.text = $"Press F to pick up {name}";
    }

    public void ClearHUD()
    {
        _hudInfo.text = string.Empty;
    }
}
