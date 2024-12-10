using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform enemy;
    [SerializeField] private GunController gunController;
    private Rigidbody2D rigid;
    Vector2 movement;
    public void Init()
    {
        gunController.Init(this);
    }
    private void OnDrawGizmosSelected()
    {
        //Debug.Log(transform.up.y);
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Dir();

        if (Input.GetKey(KeyCode.Space))
        {
            gunController.Fire();
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            RotateLeftRight(-rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            RotateLeftRight(rotateSpeed * Time.deltaTime);
        }



    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            MoveUpDown(moveSpeed);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            MoveUpDown(-moveSpeed);
        }
        else
        {
            StopMove();
        }
    }
    private void Dir()
    {

        float angel = Mathf.Atan2(transform.up.y, transform.up.x);
        movement.x = Mathf.Cos(angel);
        movement.y = Mathf.Sin(angel);
    }

    private void MoveUpDown(float speed)
    {
        rigid.linearVelocity = movement.normalized * speed;
    }
    private void StopMove()
    {
        rigid.linearVelocity = Vector2.zero;
    }
    private void RotateLeftRight(float rotateSpeed)
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }

}
