using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreak.Assets.Scripts
{
    public class BallController : MonoBehaviour
    {
        private Rigidbody2D Rigidbody2D;
        public float BounceForce;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.GameManagerInstance.isGameStarted)
            {
                Rigidbody2D.gravityScale = 1;
            }

        }

        void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }


        void StartBounce()
        {
            var randomDirection = new Vector2(Random.Range(-1, 1), 1);
            var collisionCount = float.TryParse(GameManager.GameManagerInstance.NumberOfCollisions.ToString(), out var numberOfCollisions) ? Vector2.zero : new Vector2(numberOfCollisions, numberOfCollisions);
            Rigidbody2D.AddForce((randomDirection + collisionCount) * BounceForce, ForceMode2D.Impulse);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Brick")
            {
                GameManager.GameManagerInstance.NumberOfCollisions++;
            }
            
            if (collision.gameObject.tag == "Brick")
            {
                StartBounce();
                GameManager.GameManagerInstance.IncreaseScore();
                GameManager.GameManagerInstance.NumberOfCollisions = 0;

            }
            
            if (collision.gameObject.tag == "BoundryBottom")
            {
                GameManager.GameManagerInstance.Restart();
            }

            


            
        }
    }
}

