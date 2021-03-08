using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int MAX_SPEED;
    public float moveSpeed;
    public float jumpForce;
    private bool onBridge;

    enum Lane { LEFT, CENTER, RIGHT };
    Lane currentLane = Lane.CENTER;

    // Start is called before the first frame update
    void Start()
    {
       MAX_SPEED = 17;
       onBridge = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void Move(float dir)
    {
        if(!onBridge)
        {
            if (dir > 0 && currentLane != Lane.RIGHT)
            {
                float newZPos = this.transform.position.z + 5f;
                //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, newZPos);
                StartCoroutine("LaneShiftRight");
                if (currentLane == Lane.LEFT)
                {
                    currentLane = Lane.CENTER;
                }
                else
                {
                    currentLane = Lane.RIGHT;
                }
            }
            else if (dir < 0 && currentLane != Lane.LEFT)
            {
                float newZPos = this.transform.position.z - 5f;
                //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, newZPos);
                StartCoroutine("LaneShiftLeft");
                if (currentLane == Lane.RIGHT)
                {
                    currentLane = Lane.CENTER;
                }
                else
                {
                    currentLane = Lane.LEFT;
                }
            }
        }

    }

    public void Jump()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
    }

    public void ChangeSpeed(float addSpeed)
    {
        if(moveSpeed + addSpeed > MAX_SPEED)
            moveSpeed += addSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bridge"))
        {
            onBridge = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bridge") || collision.gameObject.CompareTag("Land"))
        {
            onBridge = false;
        }
    }

    IEnumerator LaneShiftLeft()
    {
        Vector3 curPos = this.transform.position;
        float newZPos = this.transform.position.z - 5f;
        Vector3 desPos = new Vector3(this.transform.position.x, this.transform.position.y, newZPos);

        while (curPos != desPos)
        {
            curPos = Vector3.Lerp(curPos, desPos, 0.8f);
            this.transform.position = curPos;
            yield return null;
        }
    }

    IEnumerator LaneShiftRight()
    {
        Vector3 curPos = this.transform.position;
        float newZPos = this.transform.position.z + 5f;
        Vector3 desPos = new Vector3(this.transform.position.x, this.transform.position.y, newZPos);

        while (curPos != desPos)
        {
            curPos = Vector3.Lerp(curPos, desPos, 0.8f);
            this.transform.position = curPos;
            yield return null;
        }
    }
}
