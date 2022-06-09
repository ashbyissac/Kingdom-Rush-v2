using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;
    [SerializeField] float buildDelay = 0.75f;

    void Start()
    {
        StartCoroutine(BuildTower());    
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }
        
        if (bank.CurrentBalance >= cost)
        {
            bank.Withdraw(cost);
            Instantiate(tower, position, Quaternion.identity);
            return true;
        }

        return false;
    }

    IEnumerator BuildTower()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(true);
            }
        }
    }
}
