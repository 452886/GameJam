using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverItem : MonoBehaviour
{
    [SerializeField] float hoverspeed = 2f;
    [SerializeField] float height = 2f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] Vector3 rotationAngle = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, rotationAngle, rotationSpeed);
        transform.localPosition = new Vector3(0f, Mathf.Abs(Mathf.Sin(Time.time * hoverspeed)) * height, 0f);
    }
}
