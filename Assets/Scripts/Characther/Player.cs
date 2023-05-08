using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class Player : MonoBehaviour, IHealth, IMana
{
    /// <summary>
    /// 이 플레이어가 가지고 있을 인벤토리
    /// </summary>
    Inventory inven;

    /// <summary>
    /// 플레이어가 가지고 있는 돈
    /// </summary>
    int money = 0;
    public int Money
    {
        get => money;
        set
        {
            if (money != value)
            {
                money = value;
                onMoneyChange?.Invoke(money);
            }
        }
    }

    /// <summary>
    /// 생존 여부 표시용 변수
    /// </summary>
    bool isAlive = true;
    public bool IsAlive => isAlive;

    /// <summary>
    /// 플레이어의 현재 HP
    /// </summary>
    float hp = 100.0f;
    public float HP
    {
        get => hp;
        set
        {
            if (IsAlive)
            {
                hp = value;
                if (hp < 0)
                {
                    Die();
                }
                hp = Mathf.Clamp(hp, 0, maxHP);
                onHealthChange?.Invoke(hp / MaxHP);
            }
        }
    }
    /// <summary>
    /// HP가 변경되었을 때 실행될 델리게이트
    /// </summary>
    public Action<float> onHealthChange { get; set; }

    /// <summary>
    /// 플레이어가 죽었을 때 실행될 델리게이트
    /// </summary>
    public Action onDie { get; set; }

    /// <summary>
    /// 플레이어의 최대 HP
    /// </summary>
    float maxHP = 100.0f;

    public float MaxHP => maxHP;

    /// <summary>
    /// 플레이어의 현재 MP
    /// </summary>
    float mp = 100.0f;
    public float MP
    {
        get => mp;
        set
        {
            if (IsAlive)
            {
                mp = Mathf.Clamp(value, 0, maxMP);
                onManaChange?.Invoke(mp / maxMP);
            }
        }

    }

    /// <summary>
    /// 플레이어의 최대 MP
    /// </summary>
    float maxMP = 100.0f;
    public float MaxMP => maxMP;

    /// <summary>
    /// 마나가 변경되었을 때 호출되는 델리게이트
    /// </summary>
    public Action<float> onManaChange { get; set; }

    /// <summary>
    /// 돈이 변경되었을 때 실행될 델리게이트
    /// </summary>
    public Action<int> onMoneyChange;

    /// <summary>
    /// 아이템을 줏을 수 있는 거리
    /// </summary>
    public float ItemPickupRange = 2.0f;

    PlayerController playerController;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerController.OnItemPickUp += OnItemPickUp;        // 아이템 줍는다는 신호가 들어오면 줍는 처리 실행
    }

    private void Start()
    {
        inven = new Inventory(this);    // SceneLoaded보다 나중에 실행되어야 해서 Awake에서 하면 안됨
        GameManager.Inst.InvenUI.InitializeInventory(inven);
    }

    /// <summary>
    /// 아이템 줍는 처리를 하는 함수
    /// </summary>
    private void OnItemPickUp()
    {
        // 일정 범위 안에 있는 아이템 찾고
        Collider[] items = Physics.OverlapSphere(transform.position, ItemPickupRange, LayerMask.GetMask("Item"));
        foreach (Collider itemCollider in items)
        {
            Item item = itemCollider.gameObject.GetComponent<Item>();

            IConsumable consumable = item.ItemData as IConsumable;  // 즉시 소비되는 아이템인지 확인
            if (consumable != null)
            {
                consumable.Consume(gameObject);     // 즉시 소비되는 아이템이면 바로 사용
                Destroy(item.gameObject);           // 사용 후 제거
            }
            else if (inven.AddItem(item.ItemData.code))    // 하나씩 인벤토리에 추가하고
            {
                Destroy(item.gameObject);             // 먹은 아이템 삭제하기
            }
        }
    }
    public void Die()
    {
        isAlive = false;
        Debug.Log("플레이어 사망");
        onDie?.Invoke();
    }

    /// <summary>
    /// 체력을 지속적으로 회복시키는 함수
    /// </summary>
    /// <param name="totalRegen">전체 회복량</param>
    /// <param name="duration">전체 회복하는데 걸리는 시간</param>
    public void HealthRegenerate(float totalRegen, float duration)
    {
         StartCoroutine(HealthGenerateCoroutine(totalRegen, duration));
    }
    IEnumerator HealthGenerateCoroutine(float totalRegen, float duration)
    {
        // 초당 회복량 : totalRegen /duration
        float regenPerSec = totalRegen / duration;
        float timeElapsed = 0.0f;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            HP += Time.deltaTime * regenPerSec;
            yield return null;
        }
    }
    /// <summary>
    /// 마나를 지속적으로 회복시키는 함수
    /// </summary>
    /// <param name="totalRegen">전체 회복량</param>
    /// <param name="duration">전체 회복하는데 걸리는 시간</param>
    public void ManaRegenerate(float totalRegen, float duration)
    {
        StartCoroutine(ManaGenerateCoroutine(totalRegen, duration));
    }
    IEnumerator ManaGenerateCoroutine(float totalRegen, float duration)
    {
        // 초당 회복량 : totalRegen /duration
        float regenPerSec = totalRegen / duration;
        float timeElapsed = 0.0f;
        while(timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            MP += Time.deltaTime * regenPerSec;
            yield return null;
        }
    }

    /// <summary>
    /// 테스트용
    /// </summary>
    /// <param name="code">추가할 아이템 종류</param>
    /// <param name="count">추가할 갯수</param>
    public void Test_AddItem(ItemCode code, uint count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            inven.AddItem(code);
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        // 아이템 획득 반경 그리기
        Handles.DrawWireDisc(transform.position, Vector3.up, ItemPickupRange);
    }

   


#endif
}
