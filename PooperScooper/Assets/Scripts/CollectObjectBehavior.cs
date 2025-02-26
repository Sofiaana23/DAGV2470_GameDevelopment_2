using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CollectObjectBehavior : MonoBehaviour
{
    public UnityEvent collectEvent;

    private void OnTriggerEnter(Collider other) 
    {     
        Debug.Log("CollecteObject: OnTriggerEnter");
        CollectorBehavior collector = other.gameObject.GetComponent<CollectorBehavior>();
        if (collector != null)
        {
            collector.collectEvent.Invoke();
            collectEvent.Invoke();
        }

    }
}
