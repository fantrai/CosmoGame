using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI text;

    public string Text { get => text.text; set => text.text = value; }

    public virtual void Progression(float thisProgress, float maxProgress)
    {
        if (gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
        }

        slider.maxValue = maxProgress;
        slider.value = thisProgress;

        if (slider.normalizedValue >= 1)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void Progression(float thisProgress, float maxProgress, string text) 
    {
        Progression(thisProgress, maxProgress);
        Text = text;
    }
}
