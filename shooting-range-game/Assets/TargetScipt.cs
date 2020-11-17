using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScipt : MonoBehaviour
{
    bool hp = true;
    int zzz, speed = 2;

    float tim = 0, delay = 6f;

    

    void Start()
    {
        zzz = Random.Range(-1, 1);
        if (zzz == 0) zzz = 1;

        transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(-5, 5));
    }

    void Update()
    {
        if (hp)
        {
            if (Mathf.Abs(this.transform.position.z) >= 9) zzz = -zzz;
            this.transform.position += Vector3.forward * zzz * Time.deltaTime * speed;
        }
        else  
        {
            if (tim <= delay) tim += Time.deltaTime;
            else { 
                hp = true;
                speed = 4;
                this.transform.position += new Vector3(1, 1.2f, 0);
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if(hp){
            hp = false;

            if (tim == 0) {
                GameObject.Find("gauge").GetComponent<GaugeScript>().gauge += 2f;
                GameObject.Find("gauge").GetComponent<GaugeScript>().score += Mathf.Abs(this.transform.position.z)/10 - 0.1f;
                //Debug.Log(GameObject.Find("gauge").GetComponent<GaugeScript>().score); //맞출 때 디버깅
            }

            tim = 1;

            this.transform.position -= new Vector3(1, 1.2f, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 90);         
        }
    }
}
