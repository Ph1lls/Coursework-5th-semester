using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sprite pic;
    [TextArea(3, 10)]
    public string[] sentences;
}
