using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    [SerializeField]
    public float sensitivity = 3.0f;
    [SerializeField]
    public float smoothing = 2.0f;

    public GameObject characther;

    public Vector2 mouseLook;

    public Vector2 smoothV;
    // Start is called before the first frame update
    void Start()
    {
        characther = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        //for remainders
        mouseLook += smoothV;

        //rotates cam
        transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.right);
        //rotates player
        characther.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, characther.transform.up);

    }
}
