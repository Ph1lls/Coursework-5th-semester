using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObj : MonoBehaviour
{
    public Transform detectPoint;
    private const float detectRadius = 0.01f;

    void Update()
    {
        if (DetectObj())
        {
            if (InteractImput())
            {
                Debug.Log("Ã≈Õﬂ ÃŒ∆ÕŒ “–Œ√¿“‹!!!");
            }
        }
    }

    bool InteractImput()
    {
        return Input.GetKey(KeyCode.E);

    }

    bool DetectObj()
    {
        return Physics2D.OverlapCircle(detectPoint.position, detectRadius);
    }
}
