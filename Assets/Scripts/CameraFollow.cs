using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 用来引用人物角色的 Transform 组件
    public float smoothSpeed = 0.125f; // 控制相机跟随的平滑度
    public float edgeBuffer = 1.0f; // 人物到达屏幕边缘多少距离时相机开始跟随
    public Vector3 offset; // 相机和人物之间的偏移量，用于调整相机的位置

    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            // 水平方向的跟随
            float horizontalScreenEdge = mainCamera.ScreenToWorldPoint(new Vector3(edgeBuffer, 0f, mainCamera.nearClipPlane)).x;

            if (target.position.x < transform.position.x - horizontalScreenEdge || target.position.x > transform.position.x + horizontalScreenEdge)
            {
                float horizontalMoveSpeed = Mathf.Abs(target.GetComponent<Rigidbody2D>().velocity.x);
                Vector3 horizontalDesiredPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
                Vector3 horizontalSmoothedPosition = Vector3.Lerp(transform.position, horizontalDesiredPosition, smoothSpeed * horizontalMoveSpeed * Time.fixedDeltaTime);
                transform.position = horizontalSmoothedPosition;
            }

            // 垂直方向的跟随
            float verticalScreenEdge = mainCamera.ScreenToWorldPoint(new Vector3(0f, edgeBuffer, mainCamera.nearClipPlane)).y;

            if (target.position.y < transform.position.y - verticalScreenEdge || target.position.y > transform.position.y + verticalScreenEdge)
            {
                float verticalMoveSpeed = Mathf.Abs(target.GetComponent<Rigidbody2D>().velocity.y);
                Vector3 verticalDesiredPosition = new Vector3(transform.position.x, targetPosition.y, transform.position.z);
                Vector3 verticalSmoothedPosition = Vector3.Lerp(transform.position, verticalDesiredPosition, smoothSpeed * verticalMoveSpeed * Time.fixedDeltaTime);
                transform.position = verticalSmoothedPosition;
            }
        }
    }


}
