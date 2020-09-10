using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDng : MonoBehaviour
{
    public Transform left, right, top, bottom;
    public Transform[] directions;

    public DungeonGenerator generator;
    public Transform comingfrom;

    private int direction;
    private Transform roomTransform;

    void Start() {
        if (comingfrom == null) comingfrom = left;
        directions = new Transform[] { left, right, top, bottom };
        /*if (comingfrom == left) Destroy(left.gameObject);
        else if (comingfrom == right) Destroy(right.gameObject);
        else if (comingfrom == top) Destroy(top.gameObject);
        else if (comingfrom == bottom) Destroy(bottom.gameObject);*/
        Invoke("generate", 1f);
    }

    void generate() {
        if (generator.dungeonLength > 0) {
            while(true) {
                direction = Random.Range(0, 4);
                roomTransform = directions[direction];

                if (roomTransform == left && comingfrom != left) break;
                else if (roomTransform == right && comingfrom != right) break;
                else if (roomTransform == top && comingfrom != top) break;
                else if (roomTransform == bottom && comingfrom != bottom) break;
                Debug.LogError("Asd");
            }
            GenerateDng newroom = Instantiate(this, roomTransform.position, Quaternion.identity);
            if(roomTransform == left) newroom.comingfrom = right;
            else if(roomTransform == right) newroom.comingfrom = left;
            else if(roomTransform == top) newroom.comingfrom = bottom;
            else newroom.comingfrom = top;
            //Debug.Log(newroom.comingfrom);

            generator.dungeonLength--;
            Destroy(left.gameObject);
            Destroy(right.gameObject);
            Destroy(top.gameObject);
            Destroy(bottom.gameObject);
        }
    }
}
