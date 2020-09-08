using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDng : MonoBehaviour
{
    public Transform left, right, top, bottom;

    public DungeonGenerator generator;
    public Transform comingfrom;

    private int direction;
    private Transform roomTransform;

    void Start() {
        Invoke("generate", 1f);
        
    }

    void generate() {
        int i = 0;

        if (generator.dungeonLength > 0) {
            while(i < 1) {
                direction = Random.Range(1, 5);
                switch (direction) {
                    case 1:
                        roomTransform = left;
                        break;
                    case 2:
                        roomTransform = right;
                        break;
                    case 3:
                        roomTransform = top;
                        break;
                    case 4:
                        roomTransform = bottom;
                        break;
                    default:
                        return;
                }
                if (roomTransform != null) i++;
            }
            generator.dungeonLength--;
            Destroy(left.gameObject);
            Destroy(right.gameObject);
            Destroy(top.gameObject);
            Destroy(bottom.gameObject);
        }
    }
}
