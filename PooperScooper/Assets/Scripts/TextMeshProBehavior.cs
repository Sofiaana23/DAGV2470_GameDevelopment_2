using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TextMeshProBehaviour : MonoBehaviour
{

    private TextMeshProUGUI label;
    public UnityEvent startEvent;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        startEvent.Invoke();
    }

    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
}
