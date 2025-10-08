using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Camera cameraComponent;

    [SerializeField]
    private Transform targetTransform;

    [SerializeField, Header("ステージの範囲を指定します")]
    private Vector2 stageRange;
    [SerializeField]
    private Vector2 stageCenter = Vector2.zero;

    private Vector2 cameraRange;

    void Awake()
    {
        float viewHeight = cameraComponent.orthographicSize * 2;
        float viewWidth = viewHeight * cameraComponent.aspect;
        cameraRange = new Vector2(viewWidth, viewHeight);
    }

    void Update()
    {
        Vector3 cameraPosition = (Vector3)StageLimited(targetTransform.position) + new Vector3(0, 0, -10);
        cameraComponent.transform.position = cameraPosition;
    }

    private Vector2 StageLimited(Vector2 currentPos)
    {
        float rightLimit = stageCenter.x + (stageRange.x / 2) - (cameraRange.x / 2);
        float leftLimit = stageCenter.x - (stageRange.x / 2) + (cameraRange.x / 2);
        float upLimit = stageCenter.y + (stageRange.y / 2) - (cameraRange.y / 2);
        float downLimit = stageCenter.y - (stageRange.y / 2) + (cameraRange.y / 2);

        float posX = Mathf.Clamp(currentPos.x, leftLimit, rightLimit);
        float posY = Mathf.Clamp(currentPos.y, downLimit, upLimit);

        return new Vector2(posX, posY);
    }
}
