using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Barbase
{
    private void Start()
    {
        Player player = GameManager.Inst.Player;  // 플레이어 찾기
        maxValue = player.MaxHP;                  // 최대 값 설정
        max.text = $"/ {maxValue}";               // 최대 값 표시
        current.text = player.HP.ToString() ;     // 현재 HP 설정

        slider.value = player.HP / maxValue;      // 슬라이더 값 설정
        player.onHealthChange += OnHealthChange;  // HP 변경될 때 실행될 함수 등록
    }

    /// <summary>
    /// HP가 변경되면 실행되는 함수
    /// </summary>
    /// <param name="ratio">슬라이더에서 표시될 비율</param>
    private void OnHealthChange(float ratio)
    {
        ratio = Mathf.Clamp01(ratio);               // ratio의 범위를 0~1 사이로
        slider.value = ratio;                       // 슬라이더 설정
        current.text = $"{(ratio * maxValue):f0}";  // 텍스트 변경
    }
}
