using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Map.Buildings
{
    /// <summary>
    /// grassland > node
    /// {building} > building > node
    /// </summary>
    public class MM_TownCentre : MM_Buildings, IInteractable
    {

        #region Constructor
        public MM_TownCentre(int n_Id, int n_X, int n_Y, int n_Z, int b_H, int b_W, GameObject prefab) : base(n_Id, n_X, n_Y, n_Z, b_H, b_W, prefab)
        {
            Prefab = prefab;
        }
        #endregion

        #region Data Containers
        private GameObject prefab;
        #endregion

        #region Getters & Setters
        /// <summary>
        /// towncentre prefab
        /// </summary>
        public override GameObject Prefab { get { return prefab; } protected set { prefab = value; } }
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