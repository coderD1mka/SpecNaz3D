using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

/// <summary>
/// Расширяем класс LoadBalancingClient для изменения callback`ов и реакции на обновления от сервера
/// </summary>
public class MyClient:LoadBalancingClient
{
    /// <summary> Нужно ли прервать игровой цикл (по отношению к серверу) </summary>
    public bool shouldExit;

    private bool _connected;

    /// <summary> Вызвать для соединения с Photon`ом </summary>
    public void CallConnect()
    {
        _connected = false;

        this.AppId = "5c7b022485294358baf048a08eb85932";    // AppId назначенное Photon Cloud`ом
        this.AppVersion = "1.0";                                        // Версия приложения (нашего)

        if (!this.ConnectToRegionMaster("ru"))
        {
            this.DebugReturn(DebugLevel.ERROR,"Не могу подключиться к "+this.CurrentServerAddress);
            return;
        }

        Debug.Log("Успешное подключение к Photon Cloud ! Ура!");
        _connected = true;
    }

    /// <summary> Взаимодействие с сервером (получение/ отправка данных) </summary>
    public IEnumerator GameLoop()
    {
        if (!shouldExit)
        {
            this.Service();

            yield return new WaitForSeconds(0.01f);
        }
    }

    /// <summary> Отключение от сервера </summary>
    public void DisconnectClient()
    {
        if (_connected)
        {
            this.Disconnect();
        }
    }
}
