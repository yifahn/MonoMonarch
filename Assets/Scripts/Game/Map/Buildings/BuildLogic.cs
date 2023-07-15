using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Map.Buildings
{
    public static class BuildLogic
    {
        #region Data Containers
        private static string buildState;
        private static bool buildOverwrite;
        #endregion

        #region Getters & Setters
        /// <summary>
        /// build or bulldoze as string
        /// </summary>
        public static string BuildState { get { return buildState; } set { buildState = value; } }
        /// <summary>
        /// true or false as bool
        /// </summary>
        /// <param name="n"></param>
        public static bool BuildOverwrite { get { return buildOverwrite; } set { buildOverwrite = value; } }
        #endregion

        #region Action Delegator
        public static void Action(MM_Node n)
        {
            switch (BuildState)
            {
                case "build":
                    Build(n);
                    break;

                case "bulldoze":
                    Bulldoze(n);
                    break;
            }
        }
        #endregion

        #region Actions
        public static void Build(MM_Node n)
        {
        }
        public static void Bulldoze(MM_Node n)
        {

        }
        #endregion
    }
}
