using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreak.Assets.Scripts
{
    public class BrickController : MonoBehaviour
    {
        private Rigidbody2D Rigidbody2D;
        public float MoveSpeed;

        // Start is called before the first frame update
        void Start()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            TouchMove();
        }

        void TouchMove()
        {
            if (Input.GetMouseButton(0) && GameManager.GameManagerInstance.isGameStarted)
            {
                var touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (touchPosition.x < 0)
                {
                    //move left
                    Rigidbody2D.velocity = Vector2.left * MoveSpeed;
                }
                else if (touchPosition.x > 0)
                {
                    //move right
                    Rigidbody2D.velocity = Vector2.right * MoveSpeed;
                }
            }
            else
            {
                Rigidbody2D.velocity = Vector2.zero;
            }
        }
    }

}
