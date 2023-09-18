using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    public GameObject number;

    float angle;
    float radians;
    float radius;

    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 12; i++)
        {
            angle = i * 360f / 12f - 120;
            radians = angle * Mathf.Deg2Rad;

            radius = 2f;
            position = new Vector3(radius * Mathf.Cos(radians), -radius * Mathf.Sin(radians), 0);

            Instantiate(number, position, Quaternion.identity);

            TextMesh textMesh = number.GetComponent<TextMesh>();
            if (textMesh != null)
            {
                textMesh.text = i.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
