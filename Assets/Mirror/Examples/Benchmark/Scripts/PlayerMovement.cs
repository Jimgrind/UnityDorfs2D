using UnityEngine;

namespace Mirror.Examples.OneK {
    public class PlayerMovement : NetworkBehaviour {
        
        public float speed = 5;
        public Rigidbody2D rb;

        [Client]
        void Update() {
            if (!isLocalPlayer) return;

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(x, y);
            //Debug.Log("Moving to " + dir.normalized);

            Move_Cmd(rb.position + (dir.normalized * speed * Time.deltaTime));

            x = Input.mousePosition.x - (Screen.width / 2);
            y = Input.mousePosition.y - (Screen.height / 2);

            //Debug.Log(Input.mousePosition);
            float angle = Mathf.Atan2(y, x);

            Rot_Cmd((Mathf.Rad2Deg * angle) - 90f);
        }

        [Command]
        void Move_Cmd(Vector2 position) {
            //Checks
            Move_Rpc(position);
        }

        [ClientRpc]
        void Move_Rpc(Vector2 position) {
            rb.MovePosition(position);
        }

        [Command]
        void Rot_Cmd(float angle) {
            //Checks
            Rot_Rpc(angle);
        }

        [ClientRpc]
        void Rot_Rpc(float angle) {
            rb.MoveRotation(angle);
        }
    }
}