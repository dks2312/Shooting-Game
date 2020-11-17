using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeScript : MonoBehaviour
{
    public float gauge = 0;
    public float score = 0;

    GameObject maca;
    ParticleSystem ps1;
    ParticleSystem ps2;
    
    void Start()
    {
        maca = GameObject.Find("Main Camera");
        ps1 = GameObject.Find("PS1").GetComponent<ParticleSystem>();
        ps2 = GameObject.Find("PS2").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, gauge / 10);
        this.transform.position = new Vector3(transform.position.x, transform.position.y, gauge / 2 - 5);

        if(gauge == 10)
        {
            if (score > 1) score = 1;

            var main1 = ps1.main;
            var main2 = ps2.main;

            main1.startColor = new Color(score, 1, 0, 1);
            main2.startColor = new Color(score, 1, 0, 1);
            
            ps1.GetComponent<ParticleSystem>().Play();
            ps2.GetComponent<ParticleSystem>().Play();

            maca.transform.rotation = Quaternion.Euler(0, -90, 0);
            maca.transform.position = new Vector3(8,4,0);

            maca.GetComponent<P1>().enabled = false;
        }
    }
}
