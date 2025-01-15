using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int yPos;
    public int xUpPos;
    public int zUpPos;

    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        IEnumerator EnemyDrop()
        {
            while (enemyCount < 10)
            {
                xPos = Random.Range(-27, -8);
                zPos = Random.Range(23, 46);
                yPos = Random.Range(1, 2);

                xUpPos = Random.Range(-2, 51);
                zUpPos = Random.Range(111, 123);

                if (yPos < 2)
                {
                    Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
                }
                else
                {
                    Instantiate(theEnemy, new Vector3(xUpPos, 14, zUpPos), Quaternion.identity);
                }
                //WaitForSeconds(2f);
                yield return new WaitForSeconds(2f);
                enemyCount += 1;            
            }
        }
    }

    // Update is called once per frame
   
}
