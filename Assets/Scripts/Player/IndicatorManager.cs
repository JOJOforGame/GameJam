using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndicatorManager : MonoBehaviour
{
    public TextMeshProUGUI IndicatorText;
    public GameObject Indicator;

    void Start()
    {
        Indicator.SetActive(false);
    }

    public void ShowIndicator(string objName)
    {
        IndicatorText.text = "E: " + objName;
        Indicator.SetActive(true);
    }

    public void HideIndicator()
    {
        Indicator.SetActive(false);
    }
}
