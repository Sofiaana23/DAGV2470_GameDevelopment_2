using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CollectorBehavior : MonoBehaviour
{
    public UnityEvent collectEvent;

    private void OnTriggerEnter(Collider other)
    {
        CollectObjectBehavior collectible = other.gameObject.GetComponent<CollectObjectBehavior>();
        if (collectible != null)
        {
            collectible.collectEvent.Invoke();
            collectEvent.Invoke();
        }
    }
}
