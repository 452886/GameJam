using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverItem : MonoBehaviour
{
    [SerializeField] float hoverspeed = 2f;
    [SerializeField] float height = 2f;
    [SerializeField][Range(0.001f, 0.1f)] float rotationSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 90f, 0f) * rotationSpeed);
        transform.localPosition = new Vector3(0f, Mathf.Abs(Mathf.Sin(Time.time * hoverspeed)) * height, 0f);
    }
}
