using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public bool useOfSetValue;
    public float rotateSpeed;
    public Transform pivot;
    void Start()
    {
        if (!useOfSetValue)
        {
            offset = target.transform.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.transform.Rotate(-vertical,0 , 0);

        float Xangel = pivot.transform.eulerAngles.x;
        float Yangel = target.transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(Xangel, Yangel, 0);

        transform.position = target.transform.position - (rotation * offset);

        if (transform.position.y < target.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
        }
       

        transform.LookAt(target.transform);
    }
}
