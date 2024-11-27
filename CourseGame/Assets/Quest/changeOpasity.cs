using UnityEngine;
using UnityEngine.UI;

public class changeOpacity : MonoBehaviour
{
    public Button needButton;
    private Image buttonImage;

    void Start()
    {
        buttonImage = needButton.GetComponent<Image>();
    }

    public void SetOpacity(float alpha)
    {
        Color color = buttonImage.color;
        color.a = alpha; 
        buttonImage.color = color;
    }

    public void MakeTransparent()
    {
        SetOpacity(0f); 
    }

    public void MakeOpaque()
    {
        SetOpacity(1f); 
    }
}
