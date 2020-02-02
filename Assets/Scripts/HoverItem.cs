using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverItem : MonoBehaviour
{
    [SerializeField] float hoverspeed = 2f;
    [SerializeField] float height = 2f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] Vector3 rotationAngle = Vector3.up;

    private float noise = 0f;
    // Start is called before the first frame update
    void Start()
    {
        noise = Random.Range(1, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, rotationAngle, rotationSpeed);
        transform.localPosition = new Vector3(0f, Mathf.Abs(Mathf.Sin(Time.time * hoverspeed * noise)) * height, 0f);
    }
}
