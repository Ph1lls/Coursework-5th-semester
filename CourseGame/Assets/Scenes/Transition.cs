using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    public void changeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
