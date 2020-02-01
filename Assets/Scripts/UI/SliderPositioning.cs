using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositioning : MonoBehaviour
{
    [SerializeField] Transform sliderpos;
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(sliderpos.position);
        transform.position = pos;
    }
}
