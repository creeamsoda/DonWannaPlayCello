using UnityEngine;

public class SortingOrderManage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("演者のSortingOrderを更新")]
    public void SortOtherPlayer()
    {
        GameObject[] otherPlayers = GameObject.FindGameObjectsWithTag("OtherPlayers");
        if (otherPlayers.Length == 0) return;
        foreach (GameObject otherPlayer in otherPlayers)
        {
            SpriteRenderer spriteRenderer = otherPlayer.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) continue;
            spriteRenderer.sortingOrder = Mathf.RoundToInt(-otherPlayer.transform.position.y * 100);
        }
    }

    public void ChangePlayerSortingOrder(Player player)
    {
        player.mySpriteRenderer.sortingOrder = Mathf.RoundToInt(-player.Pos.y * 100);
    }
}
