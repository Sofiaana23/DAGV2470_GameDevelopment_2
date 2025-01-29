using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerBehavior : MonoBehaviour
{
    public UnityEvent timeEvent;
    private float timer = 0f;
    public float interval = 0.1f;

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= interval)
        {
            if (timeEvent != null)
            {
                timeEvent.Invoke();
            }
            timer = 0f;
        }
    }
}
