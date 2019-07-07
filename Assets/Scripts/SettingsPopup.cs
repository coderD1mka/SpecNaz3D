using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary></summary>
public class SettingsPopup : MonoBehaviour
{
    /// <summary> Показать всплывающее меню</summary>
    public void Open()
    {
        gameObject.SetActive(true);  // активируем gameobject чтобы показать окно
    }

    /// <summary> Скрыть всплывающее меню</summary>
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
