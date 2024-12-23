using UnityEngine;

public class Achivment : MonoBehaviour
{

    private bool isPaused = false;
    public GameObject AchivmentMenu;

    private bool isAchivmentMenuActive = false;


    public void ToggleControlMenu()
    {
        isAchivmentMenuActive = !isAchivmentMenuActive;


        if (AchivmentMenu != null)
        {
            AchivmentMenu.SetActive(isAchivmentMenuActive);
        }

    }
}
