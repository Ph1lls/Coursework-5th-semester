using UnityEngine;

public class ControlMenuManager : MonoBehaviour
{
    public GameObject controlMenu; 

    private bool isControlMenuActive = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleControlMenu();
        }
    }

    public void ToggleControlMenu()
    {
        isControlMenuActive = !isControlMenuActive;

        if (controlMenu != null)
        {
            controlMenu.SetActive(isControlMenuActive);
        }
    }
}
