using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    float speedX = 0;
    float speedY = 0;
    Vector3 startPos;
    Vector3 endPos;
    List<Vector3> moveHis = new List<Vector3>();
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isReachTargetPosition; // 目的地に着いたかどうか
    private Vector3 targetPosition;     // 目的地
    public const float X_MIN_MOVE_RANGE = -2.3f;     // x軸 下限
    public const float X_MAX_MOVE_RANGE = 2.1f;     // x軸 上限
    public const float Y_MIN_MOVE_RANGE = -3.8f;    // y軸 下限
    public const float Y_MAX_MOVE_RANGE = 3.6f;    // y軸 上限
    float SPEED = 0.02f;    // 移動スピード
    float lifetime = 0f;
    float deltatime = 0f;　//時間をカウント
    float stoptime = 0.5f;
    Rigidbody2D rb;

    
    void OnMouseDown() //クリックされた時
    {
        Debug.Log(moveHis);
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        this.startPos = Input.mousePosition;
        moveHis.Add(this.startPos);
        Debug.Log(startPos);
    }

    void OnMouseDrag() //クリック中
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
        moveHis.Add(currentPosition);
        if(moveHis.Count > 12)
        {
            moveHis.RemoveAt(0);
        }

    }

    void OnMouseUp() //クリックを離した時
    {
        Vector3 endPos = moveHis[moveHis.Count - 1];
        Vector3 beforeendPos = moveHis[moveHis.Count - 2];
        Debug.Log(endPos);
        float swipeLengthX = endPos.x - beforeendPos.x;
        float swipeLengthY = endPos.y - beforeendPos.y;
        this.speedX = swipeLengthX;
        this.speedY = swipeLengthY;
    }

    void Start()
    {
        this.isReachTargetPosition = false;
        //decideTargetPotision();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Translate(this.speedX, this.speedY, 0);
        this.speedX *= 0.98f;
        this.speedY *= 0.98f;

        decideTargetPotision();

        // 現在地から目的地までSPEEDの速度で移動する
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, SPEED);
        // 目的地についたらisReachTargetPositionをtrueにする
        if (transform.position == targetPosition)
        {
            isReachTargetPosition = true;
        }

        //時間経過で消滅
        this.lifetime += Time.deltaTime;
        if (this.lifetime > 10)
        {
            this.SPEED *= 0.001f;
        }

        if (this.lifetime > 20)
        {
            Destroy(gameObject);
        }
    }
  
    // 目的地を設定する
    void decideTargetPotision()
    {
        // まだ目的地についてなかったら（移動中なら）目的地を変えない
        if (!isReachTargetPosition)
        {
            return;
        }

        // 目的地に着いていたら目的地を再設定する
        targetPosition = new Vector3(Random.Range(X_MIN_MOVE_RANGE, X_MAX_MOVE_RANGE), Random.Range(Y_MIN_MOVE_RANGE, Y_MAX_MOVE_RANGE), 0);
        isReachTargetPosition = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "blue")
        {
            Debug.Log("blue");
            targetPosition = new Vector3(Random.Range(X_MIN_MOVE_RANGE, X_MAX_MOVE_RANGE), Random.Range(Y_MIN_MOVE_RANGE, Y_MAX_MOVE_RANGE), 0);
            isReachTargetPosition = false;

        }
        else if (other.gameObject.tag == "red")
        {
            targetPosition = new Vector3(Random.Range(X_MIN_MOVE_RANGE, X_MAX_MOVE_RANGE), Random.Range(Y_MIN_MOVE_RANGE, Y_MAX_MOVE_RANGE), 0);
            isReachTargetPosition = false;

        }
    }
}
