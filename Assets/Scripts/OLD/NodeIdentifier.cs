using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeIdentifier : MonoBehaviour
{
    GameObject cell;

    void Start()
    {
        cell = this.gameObject;
    }
    public string GetName()
    {
        return cell.name;
    }

}
