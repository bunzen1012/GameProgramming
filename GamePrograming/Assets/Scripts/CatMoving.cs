using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//스네이크, 클래스는 대문자시작 잊지말기
public class CatMoving : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Vector3 initialPosition;
    bool isSpeedBoosted = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;

        // 시작 시 10초마다 SpeedBoost 코루틴을 호출
        StartCoroutine(SpeedBoostTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpeedBoosted)
        {
                SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10.0f;
        randomDirection += initialPosition;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10.0f, NavMesh.AllAreas);
        navMeshAgent.SetDestination(hit.position);
    }

    IEnumerator SpeedBoostTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            isSpeedBoosted = true;
            navMeshAgent.speed *= 3.0f; // 속도를 3배로 증가
            yield return new WaitForSeconds(3.0f);
            isSpeedBoosted = false;
            navMeshAgent.speed /= 3.0f; // 원래 속도로 복원
        }
    }
}

