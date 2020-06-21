using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject bluepoint;
    GameObject redpoint;
    int blue = 0;
    int red = 0;
    float time = 0f;
    GameObject generator;

    public void BlueBoxGetBlue()
    {
        this.blue += 1;
    }

    public void BlueBoxGetRed()
    {
        if (blue > 0) 
        {
            this.blue -= 1;
        }
    }

    public void RedBoxGetRed()
    {
        this.red += 1;
    }

    public void RedBoxGetBlue()
    {
        if (red > 0)
        {
            this.red -= 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.generator = GameObject.Find("FaceGenerator");
        this.bluepoint = GameObject.Find("bluepoint"); 
        this.redpoint = GameObject.Find("redpoint");
    }

    // Update is called once per frame
    void Update()
    {
        this.bluepoint.GetComponent<Text>().text = this.blue.ToString();
        this.redpoint.GetComponent<Text>().text = this.red.ToString();

        //時間経過によって難易度が変化する
        this.time += Time.deltaTime;

        if (this.time < 20 )
        {
            this.generator.GetComponent<FaceGenerator>().SetParameter(5.0f,1);
        }
        else if(20 <= this.time && this.time < 40)
        {
            this.generator.GetComponent<FaceGenerator>().SetParameter(5.0f, 2);
        }
        else if (40 <= this.time && this.time < 60)
        {
            this.generator.GetComponent<FaceGenerator>().SetParameter(7.0f, 3);
        }
        else if (60 <= this.time && this.time < 80)
        {
            this.generator.GetComponent<FaceGenerator>().SetParameter(7.0f, 4);
        }
        else if (80 <= this.time && this.time < 100)
        {
            this.generator.GetComponent<FaceGenerator>().SetParameter(5.0f, 5);
        }
    }
}
