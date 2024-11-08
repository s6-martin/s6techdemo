using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    TMP_Text _hudInfo;
    [SerializeField]
    TMP_Text _ammoCount;
    [SerializeField]
    TMP_Text _score;
    [SerializeField]
    Image _crosshair;

    public static HUDController instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void SetHUD(string name, string tag)
    {
        if (tag == "Door")
        {
            _hudInfo.text = "Press F to open door";
            return;
        }

        _hudInfo.text = $"Press F to pick up {name}";
    }

    public void ClearHUD()
    {
        _hudInfo.text = string.Empty;
    }

    public void SetAmmo(int ammo)
    {
        if(!_ammoCount.gameObject.activeInHierarchy)
            _ammoCount.gameObject.SetActive(true);

        _ammoCount.text = $"Ammo count: {ammo}";
    }

    internal void SetCrosshair()
    {
        _crosshair.gameObject.SetActive(true);
    }
}
