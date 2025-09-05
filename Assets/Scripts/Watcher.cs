using UnityEngine;

public class Watcher : MonoBehaviour
{
    [SerializeField] private Transform myTransform;
    [SerializeField] private Canvas ViewRange;
    [SerializeField] private Vector2 viewRangeOffset;
    public Vector2 Pos => myTransform.position;
    public float NeckRotation;
    public bool isActive = false;
    [SerializeField] private bool isModifyRange = true;
    private Vector3 maxViewRange;
    [SerializeField] public float viewReach;

    [SerializeField] private Parameters parameters;
    [SerializeField] private Player player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NeckRotation = 90;
        maxViewRange = ViewRange.transform.localScale;
        Debug.Log("pos :"+ Pos);
    }

    // Update is called once per frame
    void Update()
    {
        SynchronizeNeckRotation();
        if (isModifyRange) ModifyRange();
    }

    public bool WatchPlayerMove()
    {
        if (!isActive) return false;
        if (!player.IsMoving) return false;
        // 一定以上離れていると感知しない
        if ((player.Pos - Pos).sqrMagnitude > viewReach * viewReach) return false;
        float playerNeckRotation = Vector2.Angle(Vector2.right, player.Pos - (Pos + viewRangeOffset));
        // 視界の外なら動いていても感知しない
        if (Mathf.Abs(playerNeckRotation - NeckRotation) > 0.5*parameters.WatcherViewRange) return false;
        return true;
    }

    private void SynchronizeNeckRotation()
    {
        ViewRange.transform.rotation = Quaternion.Euler(0, 0, NeckRotation);
    }

    private void ModifyRange()
    {
        ViewRange.transform.localScale = (Mathf.Abs(NeckRotation - 90)+180)/270 * maxViewRange;
    }
}
