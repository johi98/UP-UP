using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;//플레이어의 Vector3값을 가져옴

    public Vector3 Offset;//카메라가 플레이어에게서 떨어지는 위치 값

    private Vector3 Velocity;
    public float smoothDamp;

    public float PositionOffset;

    private void Start()
    {
        Vector3 TargetPosition = Player.position + Offset;
        //카메라의 포지션을 플레이어의 위치에서 Offset만큼 떨어진 위치에 배치를 표시
        transform.position = TargetPosition;
        //카메라의 위치를 TargetPosition에 배치함
    }

    private void FixedUpdate()
    {
        Vector3 TargetPosition = Player.position + Offset;
                                                 
        if(Player.position.y > transform.position.y - PositionOffset)
        {//공의 포지션이 카메라보다 낮다는 것은 공이 떨어질 때를 의미
            transform.position = TargetPosition = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, smoothDamp);
            //현재위치, 이동할 위치, 현재속도, 목표에 도달할기까지 걸릴 시간
            //목표에 도달하는 시간값을 -값으로 주어 공이 떨어질때 같이 움직이지 않음
        }


    }
}
