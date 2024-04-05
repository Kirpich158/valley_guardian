using UnityEngine;
using TMPro;

public class DebugToolScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private bool _isPanelShown = false;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.BackQuote) && !_isPanelShown) { // opening panel
            canvasGroup.alpha = 1;
            _isPanelShown = true;
        } else if (Input.GetKeyDown(KeyCode.BackQuote) && _isPanelShown) { // closing panel
            canvasGroup.alpha = 0;
            _isPanelShown = false;
        }
    }

    #region ItemSpawn
    [Space(20)]
    [Header("Item Spawning References")]
    public TMP_Dropdown itemDropDown;
    public float itemSpawnDistance;

    public void SpawnItem() {
        if (itemDropDown.value != 0) {
            Vector3 itemSpawnDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            Vector3 itemPos = PlayerMain.Instance.gameObject.transform.position + itemSpawnDir * itemSpawnDistance;
            DroppedItem.SpawnItem(itemPos, new Item((ItemType)itemDropDown.value - 1, 1));
        }
    }
    #endregion

    #region GoldSection
    [Space(20)]
    [Header("Gold Management References")]
    public PlayerCurrency currency;

    public void AddGold(TMP_InputField input) {
        currency.Gold += int.Parse(input.text);
    }
    public void RemoveGold(TMP_InputField input) {
        currency.Gold -= int.Parse(input.text);
    }
    #endregion

    #region EnemySpawn
    [Space(20)]
    [Header("Enemy Spawning References")]
    public TMP_Dropdown enemyDropDown;
    public GameObject[] enemies;
    public float enemySpawnDistance;

    public void SpawnEnemy() {
        if (enemyDropDown.value != 0) {
            Vector3 enemySpawnDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            Vector3 enemyPos = PlayerMain.Instance.gameObject.transform.position + enemySpawnDir * enemySpawnDistance;
            Instantiate(enemies[enemyDropDown.value - 1], enemyPos, Quaternion.identity);
        }
    }
    #endregion

    #region NPCSpawn
    [Space(20)]
    [Header("NPC Spawning References")]
    public TMP_Dropdown npcDropDown;
    public GameObject[] npcs;
    public float npcSpawnDistance;

    public void SpawnNPC() {
        if (npcDropDown.value != 0) {
            Vector3 npcSpawnDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            Vector3 npcPos = PlayerMain.Instance.gameObject.transform.position + npcSpawnDir * npcSpawnDistance;
            Instantiate(npcs[npcDropDown.value - 1], npcPos, Quaternion.identity);
        }
    }
    #endregion
}
