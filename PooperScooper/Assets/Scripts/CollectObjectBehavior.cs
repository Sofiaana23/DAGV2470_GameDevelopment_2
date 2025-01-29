using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CollectObjectBehavior : MonoBehaviour
{
    public UnityEvent collectEvent;

    private void OnTriggerEnter (Collider other) 
    {     
        CollectorBehavior collector = other.gameObject.GetComponent<CollectorBehavior>();
        if (collector != null)
        {
            collector.collectEvent.Invoke();
            collectEvent.Invoke();
        }

    }
}
