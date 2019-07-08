using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;  // ссылка на компонент Text, для установки текста
    [SerializeField] private SettingsPopup settingsPopup;

    private int _score;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT,OnEnemyHit);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT,OnEnemyHit);
    }

    private void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();
        settingsPopup.Close();
    }

    private void OnEnemyHit()
    {
        _score++;
        scoreLabel.text = _score.ToString();
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
