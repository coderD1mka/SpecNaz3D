using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviour
{
    private MyClient _client;

    private void Awake()
    {
        _client=new MyClient();
        _client.shouldExit = false;
    }
	// Use this for initialization
	void Start ()
	{
		_client.CallConnect();
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine(_client.GameLoop());
	}

    private void OnDestroy()
    {
        _client.DisconnectClient();
    }
}
