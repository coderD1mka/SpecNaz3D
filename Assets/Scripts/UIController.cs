using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;  // ссылка на компонент Text, для установки текста
    [SerializeField] private SettingsPopup settingsPopup;

    private void Start()
    {
        settingsPopup.Close();
    }

	// Update is called once per frame
	void Update ()
	{
	    scoreLabel.text = Time.realtimeSinceStartup.ToString();
	}

    /// <summary> метод вызываемый кнопкой настроек </summary>
    public void OnOpenSettings()
    {
       settingsPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
