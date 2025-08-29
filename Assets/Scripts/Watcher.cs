using UnityEngine;

public class Watcher : MonoBehaviour
{
    [SerializeField] private Transform myTransform;
    [SerializeField] private Canvas ViewRange;
    public Vector2 Pos => myTransform.position;
    public float NeckRotation;
    public bool isActive = false;

    [SerializeField] private Parameters parameters;
    [SerializeField] private Player player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NeckRotation = 90;
    }

    // Update is called once per frame
    void Update()
    {
        SynchronizeNeckRotation();
    }

    public bool WatchPlayerMove()
    {
        if (!isActive) return false;
        if (!player.IsMoving) return false;
        float playerNeckRotation = Vector2.Angle(Vector2.right, player.Pos - Pos);
        // 視界の外なら動いていても感知しない
        if (Mathf.Abs(playerNeckRotation - NeckRotation) > 0.5*parameters.WatcherViewRange) return false;
        return true;
    }

    private void SynchronizeNeckRotation()
    {
        ViewRange.transform.rotation = Quaternion.Euler(0, 0, NeckRotation);
    }
}
