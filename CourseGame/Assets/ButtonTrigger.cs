using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private Interactor anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Move(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Move(false);
        }
    }
}
