using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public float percent = 1.0f;

    private RectTransform barRect;

    private float width;

    public void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        barRect = transform.GetChild(0).GetComponent<RectTransform>();
        SetPercentage(percent);
    }

    public void SetPercentage(float percent)
    {
        Vector2 size = barRect.sizeDelta;
        size.x = width * percent;
        barRect.sizeDelta = size;
    }
}
