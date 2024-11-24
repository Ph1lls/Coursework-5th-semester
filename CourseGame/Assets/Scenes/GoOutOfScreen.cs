using UnityEngine;

public class GoOutOfScreen : MonoBehaviour
{
    [SerializeField] private Transition transition;
    [SerializeField] private int sceneID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transition.changeScene(sceneID);
        }
    }
}
