using UnityEngine;

public class Interactor : MonoBehaviour
{
    private RectTransform rectTransform;
    private float duration = 0.2f;
    [SerializeField] private bool isHorizontal;

    private float startTime;
    private float startPosition;
    private float targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isMoving)
        {
            float fractionOfJourney = (Time.time - startTime) / duration;

            float value = Mathf.Lerp(startPosition, targetPosition, fractionOfJourney);
            Vector2 stepPosition = Vector2.zero;

            if(isHorizontal)
            {
                stepPosition.x = value;
            }
            else
            {
                stepPosition.y = value;
            }
            rectTransform.anchorMin = stepPosition;
            rectTransform.anchorMax = stepPosition;

            if (fractionOfJourney >= 1)
            {
                isMoving = false;
            }
        }
    }


    public void Move(bool opening)
    {
        if (!isMoving)
        {
            startTime = Time.time;
            isMoving = true;
            Vector2 position = rectTransform.anchorMin;
            startPosition = isHorizontal ? position.x : position.y;
            targetPosition = opening ? 0 : 1;
        }
    }
}
