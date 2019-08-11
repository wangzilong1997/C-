using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    readonly float leftBorder = -3;
    readonly float rightBorder = 3;
    readonly float initPosotionY = 0;
    readonly float MAX_GROUND_COUNT = 10;
    readonly float MIN_GROUND_COUNT_UNDER_PLAYER = 3;
    static int groundNumber = -1;
    public float spacingY;
    public float singleFloorHeight;
    public List<Transform> grounds;
    public Transform player;
    public Text displayCountFloor;

    void Start()
    {
        grounds = new List<Transform>();
        for (int i = 0; i < MAX_GROUND_COUNT; i++) {
            SpawnGround();
        }
        
    }
    public void ControlSpawnGround() {
        int groundsCountUnderPlayer = 0; //玩家下方的地板数量
        foreach(Transform ground in grounds){
           if(ground.position.y<player.transform.position.y){
               groundsCountUnderPlayer++;
           }
        }
        if (groundsCountUnderPlayer < MIN_GROUND_COUNT_UNDER_PLAYER) {
            SpawnGround();
            ControlGroundsCount();
        }
        
    }
    public void ControlGroundsCount() { 
        if (grounds.Count > MAX_GROUND_COUNT){
            Destroy(grounds[0].gameObject);
            grounds.RemoveAt(0);
        }
    }

    float NewGroundPositionX(){
        if (grounds.Count == 0) {
            return 0;
        }
        return Random.Range(leftBorder, rightBorder);
    }
    //计算新地板的Y坐标
    float NewGroundPositionY() {
        if (grounds.Count == 0) {
            return initPosotionY;
        }
        int lowerIndex = grounds.Count - 1;
        return grounds[lowerIndex].transform.position.y - spacingY;
    }
    // 不断产生单一地板
    void SpawnGround() {
        GameObject newGround = Instantiate(Resources.Load<GameObject>("地板"));
        //float newGroundPositionY = initPosotionY - spacingY * i;
        newGround.transform.position = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
        grounds.Add(newGround.transform);
    }
    float CountLowerGroundFloor() {
        float playerPositionY = player.transform.position.y;
        float deep = Mathf.Abs(initPosotionY - playerPositionY);
        return (deep / singleFloorHeight) + 1;
    }
    void DisplayCountFloor() {
        displayCountFloor.text = "地下" + CountLowerGroundFloor().ToString("0000") + "楼";
    }
    void Update()
    {
        ControlSpawnGround();
        DisplayCountFloor();
    }
}
