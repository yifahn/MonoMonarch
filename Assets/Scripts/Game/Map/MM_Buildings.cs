using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Map
{
    /// <summary>
    /// grassland > node,
    /// {building} > building > node
    /// </summary>
    public abstract class MM_Buildings : MM_Node
    {

        #region Constructor
        protected MM_Buildings(int n_Id, int n_X, int n_Y, int n_Z, int b_W, int b_H, GameObject prefab) : base(n_Id, n_X, n_Y, n_Z)
        {
            Prefab = prefab;
        }
        #endregion

        #region Data Container
        private int b_H;
        private int b_W;
        #endregion

        #region Getters & Setters
        /// <summary>
        /// height of building
        /// </summary>
        public int B_H { get { return b_H; } protected set { b_H = value; } }
        /// <summary>
        /// width of building
        /// </summary>
        public int B_W { get { return b_W; } protected set { b_W = value; } }
        /// <summary>
        /// building prefab
        /// </summary>
        public abstract GameObject Prefab { get; protected set; }
        #endregion

    }
}
