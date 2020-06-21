using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class FaceGenerator : MonoBehaviour
{
    public GameObject bluePrefab;
    public GameObject redPrefab;
    int number = 2; //1フレームに生成される顔それぞれの個数
    float span = 6f; //顔が生成される間隔
    float delta = 5.9f;　//時間をカウント
    float Xmax = 2.1f; //生成位置のx軸の最大値
    float Xmin = -2.3f; //生成位置のx軸の最小値
    float Ymax = 3.6f; //生成位置のy軸の最大値
    float Ymin = -3.8f; //生成位置のy軸の最小値
    float geneposX; //生成位置のx座標
    float geneposY;　//生成位置のy座標

    //ゲームの難易度に関わる数値
    public void SetParameter(float span, int number)
    {
        this.span = span;
        this.number = number;
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //一定間隔で顔を生成する
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            for (int r = 1; r <= this.number; r++)
            {
                geneposX = Random.Range(Xmin, Xmax);
                geneposY = Random.Range(Xmin, Xmax);
                Instantiate(bluePrefab, new Vector3(geneposX, geneposY, 0.0f), Quaternion.identity);

                geneposX = Random.Range(Xmin, Xmax);
                geneposY = Random.Range(Xmin, Xmax);
                Instantiate(redPrefab, new Vector3(geneposX, geneposY, 0.0f), Quaternion.identity);

                this.delta = 0;
            }
        }
    }
}
