using UnityEngine;

public class P1 : MonoBehaviour
{
    Camera cam;
    private float speed = 5;
    float h, v,m;
    float y;
    void Start()
    {
        y = transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButton(1)) m = Input.GetAxisRaw("Mouse X");
        else m = 0;

        y += m * speed;

        transform.position += this.transform.forward * v * speed * Time.deltaTime;
        transform.position += this.transform.right * h * speed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, y, this.transform.rotation.eulerAngles.z);
    }
}
