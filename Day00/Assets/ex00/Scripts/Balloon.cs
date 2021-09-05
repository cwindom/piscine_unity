using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    float breath = 100;
    Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 scaleChangeMinus = new Vector3(0.001f, 0.001f, 0.001f);
    [SerializeField] private Transform balloon;
    private float time;
    void Update()
    {
        time += Time.deltaTime;
        balloon.localScale -= scaleChangeMinus;
        if (Input.GetKeyDown(KeyCode.Space) && breath > 0)
        {
            balloon.localScale += scaleChange;
            breath -= 20;
        }
        if (breath < 100)
            breath += 0.5f;
        if (balloon.localScale.x >= 4 || balloon.localScale.y >= 4 || balloon.localScale.z >= 4 ||
            balloon.localScale.x <= 0.5 || balloon.localScale.y <= 0.5 || balloon.localScale.z <= 0.5)
        {
            Destroy(balloon.gameObject);
            Debug.Log("Balloon life time: " + Mathf.RoundToInt(time) + "s");
        }
    }
}
