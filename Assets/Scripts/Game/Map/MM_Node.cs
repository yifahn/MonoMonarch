using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Map
{
    /// <summary>
    /// grassland > node,
    /// {building} > building > node
    /// </summary>
    public abstract class MM_Node : MonoBehaviour
    {

        #region Constructor
        protected MM_Node(int n_Id, int n_X, int n_Y, int n_Z)
        {
            N_Id = n_Id;
            N_X = n_X;
            N_Y = n_Y;
            N_Z = n_Z;
        }
        #endregion

        #region Data Container
        private int n_Id;
        private int n_X;
        private int n_Y;
        private int n_Z;
        #endregion

        #region Getters & Setters
        /// <summary>
        /// id of node
        /// </summary>
        public int N_Id { get { return n_Id; } protected set { n_Id = value; } }
        /// <summary>
        /// x of node in 3D world space
        /// </summary>
        public int N_X { get { return n_X; } protected set { n_X = value; } }
        /// <summary>
        /// y of node in 3D world space
        /// </summary>
        public int N_Y { get { return n_Y; } protected set { n_Y = value; } }
        /// <summary>
        /// z of node in 3D world space
        /// </summary>
        public int N_Z { get { return n_Z; } protected set { n_Z = value; } }
        #endregion

        #region Behaviour
        public abstract void Build();
        #endregion

    }
}