using UnityEngine.Events;
using UnityEngine;

public class LoadItem : MonoBehaviour
{
    public UnityEvent customEvent;
    void Start()
    {
        customEvent.Invoke();
    }

}
