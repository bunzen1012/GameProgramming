using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GooseMoving : MonoBehaviour
{
    NavMeshAgent navMeshAgent; //네비게이션 요소
    public Transform target; //쫓아야할 대상
    Vector3 initial_position; //최초 스폰 위치
    bool isReturning = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>(); //길찾기
        initial_position = transform.position;//몬스터 초기 위치 저장
    }

    // Update is called once per frame
    void Update()
    {
        if (isReturning)
        {
            navMeshAgent.SetDestination(initial_position);
        }

        else
        {
            navMeshAgent.SetDestination(target.position);

        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sight"))
        {
            Debug.Log("Touch!");
            StartCoroutine(Run5Second());
        }
    }

    IEnumerator Run5Second()
    {
        isReturning = true; // 초기 위치로 이동하도록 플래그 설정

        float normal_speed = navMeshAgent.speed;
        navMeshAgent.speed = normal_speed * 3.0f;
        navMeshAgent.SetDestination(initial_position);

        yield return new WaitForSeconds(5.0f);

        isReturning = false; // 다시 플레이어를 추적하도록 플래그 설정
        navMeshAgent.speed = normal_speed;
    }
}
