using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary></summary>
public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;

    private void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }

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

    /// <summary> Срабатывает в момент завершения ввода данных в текстовое поле</summary>
    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    /// <summary> Срабатывает при изменении ползунка в Popup окне</summary>
    public void OnSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED,speed);
        PlayerPrefs.SetFloat("speed",speed);
    }
}
