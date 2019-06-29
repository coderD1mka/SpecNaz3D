﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // этот метод вызывается из сценария стрельбы RayShooter
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();

        if(behavior!=null)
        {
            behavior.SetAlive(false);
        }

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75,0,0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject); // цель самоуничтожается
    }
}
