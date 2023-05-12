using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어를 따라다니는 미니맵 카메라
/// </summary>
public class MinimapCamera : MonoBehaviour
{
    public float follwSpeed = 3.0f;
    Player player;

    private void Start()
    {
        player = GameManager.Inst.Player;
    }
    private void LateUpdate()
    {
        if(player.IsAlive)
        {
            Vector3 targetPos = player.transform.position;
            targetPos.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * follwSpeed);
        }
    }
    // 플레이어의 현재 속도에 따라 미니맵 카메라가 찍는 영역의 크기가 달라진다.
    // 1. 카메라의 최대 크기와 기본 크기 필요
    // 2. 플레이어가 최고 속도일 때 카메라의 크기는 최대가 된다.
    // 3. 플레이어가 정지했을 때 카메라의 크기는 기본 크기가 된다.
}
