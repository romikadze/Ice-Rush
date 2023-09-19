using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeScript : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 1;
    Vector3 mouseDown;
    Vector3 mouseUp;
    Vector3 dir;
    TrajectoryRenderer trajectory;
    bool isReadyToJump = true;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        trajectory = GameObject.Find("TrajectoryRenderer").GetComponent<TrajectoryRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.isGameEnded)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && isReadyToJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isReadyToJump = false;
        StartCoroutine(JumpCooldown());
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(2);
        isReadyToJump = true;
    }


    private void OnMouseDown()
    {
        if (GameManager.gameManager.isGameEnded)
            return;

        mouseDown.x = Input.mousePosition.x;
        mouseDown.z = Input.mousePosition.y;
    }

    private void OnMouseDrag()
    {
        if (GameManager.gameManager.isGameEnded)
            return;

        mouseUp.x = Input.mousePosition.x;
        mouseUp.z = Input.mousePosition.y;
        dir = mouseDown - mouseUp;
        dir.x = Mathf.Clamp(dir.x, -100, 100);
        dir.z = Mathf.Clamp(dir.z, -100, 100);
        trajectory.ShowTrajectory(transform.position, dir/10);
    }

    private void OnMouseUp()
    {
        if (GameManager.gameManager.isGameEnded)
            return;

        rb.AddForce(dir/150 * speed, ForceMode.Impulse);
        trajectory.hideTrajectory();
    }
}
