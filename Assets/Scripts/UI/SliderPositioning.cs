using UnityEngine;

public class SliderPositioning : MonoBehaviour
{
    [SerializeField] GameObject treeSliderPrefab;
    [SerializeField] Transform canvasParent;

    private GameObject spawnedTreeSlider;

    void Start()
    {
        spawnedTreeSlider = Instantiate(treeSliderPrefab);
        spawnedTreeSlider.transform.parent = canvasParent;
    }

    public void DrawSliderHere() {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        spawnedTreeSlider.transform.position = pos;
    }
}
