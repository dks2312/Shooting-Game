using UnityEngine;

public class TurretScript : MonoBehaviour
{
    Ray ra;
    RaycastHit hi;

    ParticleSystem fo;
    MeshRenderer Traffic;
    Animation ani;

    float tim = 0, delay = 0.5f;

    private void Awake()
    {
        fo = GameObject.FindWithTag("FO").GetComponent<ParticleSystem>();
        Traffic = GameObject.Find("TrafficLight").GetComponent<MeshRenderer>();
        ani = GameObject.Find("handle").GetComponent<Animation>();
    }
    void Update()
    {
        if (tim > delay)
        {
            Traffic.material.color = Color.green;
            if (Input.GetMouseButtonDown(0))
            {
                ra = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ra, out hi, 100f) && hi.transform.tag == "Lever")
                {
                    GameObject.Find("gauge").GetComponent<GaugeScript>().score += 0.1f;

                    ani.PlayQueued("LeverOn");
                    fo.Play();
                    Traffic.material.color = Color.red;
                    tim = 0f;
                    ani.PlayQueued("LeverOff");
                }
            }
        }
        else  tim += Time.deltaTime;
    }
}
