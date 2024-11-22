using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class progressBarScript : MonoBehaviour
{
    [SerializeField] GameObject bille;
    [SerializeField] GameObject maxHeight;
    private Vector3 currentPos;
    private float totalDist;
    private float currentDist;
    private UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        totalDist = Vector3.Distance(bille.transform.position, maxHeight.transform.position);
        slider = GetComponent<UnityEngine.UI.Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = bille.transform.position;
        currentDist = Vector3.Distance(currentPos, maxHeight.transform.position);
        slider.value = currentDist / totalDist;
    }
}
