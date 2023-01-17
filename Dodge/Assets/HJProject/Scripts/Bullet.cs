using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody = default;
    public float bulletSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = gameObject.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;

        //3초 뒤에 스스로 파괴되는 코드
        Destroy(gameObject, 3f);
    }       // Start()

    // Update is called once per frame
    void Update()
    {

    }

    // 총알이 무언가와 부딧쳤을 경우 실행되는 함수
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player == null || player == default)
            {
                return;
            }
            
            // 플레리어의 컨트롤을 정상적으로 가져온 경우
            // 총알을 맞은 플레이어는 죽는다.
            player.Die();
        }
        
    }   // OnTriggerEnter()
}
