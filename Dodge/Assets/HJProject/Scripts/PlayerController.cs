using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody playerRigidbody = default;
    public float speed = 8f;
    // Start is called before the first frame update
    
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 playerVelo = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = playerVelo;


        // playerVelo.magnitude
    }



    private void LegacyMove(){
        if(Input.GetKey(KeyCode.UpArrow) == true){
            playerRigidbody.AddForce(0f,0f,speed);
        }
        if(Input.GetKey(KeyCode.DownArrow) == true){
            playerRigidbody.AddForce(0f,0f,-speed);
        }
        if(Input.GetKey(KeyCode.RightArrow) == true){
            playerRigidbody.AddForce(speed,0f,0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow) == true){
            playerRigidbody.AddForce(-speed,0f,0f);
        }
    }   // Update()

    //! 이전에 움직이던 방식을 캐싱해 놓은 함수

    

    //! 플레이어가 사망했을 때 호출하는 함수
    public void Die(){
        gameObject.SetActive(false);
        gameManager.EndGame();
    }       // Die()
}
