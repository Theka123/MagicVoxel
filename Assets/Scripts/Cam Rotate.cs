using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    //현재 각도
    Vector3 angle;
    //마우스 감도
    public float sensitivity = 200;

    // Start is called before the first frame update
    void Start()
    {
        //시작할 때 현재 카메라의 각도를 적용한다.
        angle = Camera.main.transform.eulerAngles;
        angle.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 정보 입력
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");

        //방향 확인
        angle.x = angle.x + x * sensitivity  * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;

        //카메라가 회전하는 각도를 제한하는 것
        angle.x = Mathf.Clamp(angle.x ,-90 ,90);

        //회전
        transform.eulerAngles = new Vector3(-angle.x, angle.y, transform.eulerAngles.z);
    }
}
