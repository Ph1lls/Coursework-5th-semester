using UnityEngine;

public class animateBox : MonoBehaviour
{
    [SerializeField] private bool isPicLeft;
    private RectTransform rectTransform;
    private float duration = 0.2f;

    private float startTime;
    private float journeyLength;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    public bool isActive = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if(Screen.height <  1500)
        {
            journeyLength = Screen.height*0.3f;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, journeyLength);
        }
        else
        {
            journeyLength = Screen.height*0.15f;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, journeyLength);
            int x;
            if(isPicLeft)
            {
                x=0;
            }
            else
            {
                x=1;
            }
            rectTransform.pivot = new Vector2(x, 0.5f);
        }

        startPosition = rectTransform.anchoredPosition;
        startPosition.y = -journeyLength/2;
        rectTransform.anchoredPosition = startPosition;
        targetPosition = startPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            float fractionOfJourney = (Time.time - startTime) / duration;

            Vector3 stepPosition = startPosition;
            stepPosition.y = Mathf.Lerp(startPosition.y, targetPosition.y, fractionOfJourney);

            rectTransform.anchoredPosition = stepPosition;

            if (fractionOfJourney >= 1)
            {
                isMoving = false;
            }
        }
    }


    public void Move(bool up)
    {
        isActive = up;

        if (!isMoving)
        {
            startTime = Time.time;
            isMoving = true;
            startPosition = rectTransform.anchoredPosition;
            targetPosition.y = up ? journeyLength/2 : -journeyLength/2;
        }
    }
}
