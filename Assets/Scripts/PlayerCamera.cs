using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float lookSpeed;
    public float maxXRotation = 20;

    [SerializeField]
    private float currentXRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
        currentXRotation = transform.localRotation.eulerAngles.x;
    }

    private void moveCamera()
    {
        currentXRotation = transform.localRotation.eulerAngles.x;

        var moveX = Input.GetAxis("Mouse X");
        var moveY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(-moveY, moveX, 0) * lookSpeed * Time.deltaTime);

        // Zero out the Z rotation
        Quaternion rotation = transform.rotation;
        rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, 0);
        transform.rotation = rotation;
    }
}
