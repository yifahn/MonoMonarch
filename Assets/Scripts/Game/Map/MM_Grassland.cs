using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Map
{
    /// <summary>
    /// grassland > node,
    /// {building} > building > node
    /// </summary>
    public class MM_Grassland : MM_Node, IInteractable
    {

        #region Constructor
        public MM_Grassland(int n_Id, int n_X, int n_Y, int n_Z, int g_H, int g_W, GameObject prefab) : base(n_Id, n_X, n_Y, n_Z)
        {
            G_H = g_H;
            G_W = g_W;
            Prefab = prefab;
        }
        #endregion

        #region Data Containers
        private int g_H;
        private int g_W;
        private GameObject prefab;
        #endregion

        #region Getters & Setters
        /// <summary>
        /// height of grassland
        /// </summary>
        public int G_H { get { return g_H; } protected set { g_H = value; } }
        /// <summary>
        /// width of grassland
        /// </summary>
        public int G_W { get { return g_W; } protected set { g_W = value; } }
        /// <summary>
        /// grassland prefab
        /// </summary>
        public GameObject Prefab { get { return prefab; } protected set { prefab = value; } }
        #endregion

        #region Behaviour
        public void Interact()
        {
            Build();
        }
        public override void Build()
        {

        }
        #endregion

    }

}