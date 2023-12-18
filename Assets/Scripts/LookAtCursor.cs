using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private Transform tr;
    [SerializeField] private float offset;

    void Start()
    {
        tr = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = mousePos - tr.position;

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis((angle - offset) * -1, Vector3.forward);
        tr.rotation = rotation;
    }
}
