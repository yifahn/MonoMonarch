using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Managers
{
    public static class Game
    {

        #region Build States
        private static bool isBuild;
        private static bool isBulldoze;

        private static bool isSingle;
        private static bool isShift;
        private static bool isMulti;

        private static bool isOverwrite;


        public static bool IsBuild { get { return isBuild; } set { isBuild = value; } }
        public static bool IsBulldoze { get { return isBulldoze; } set { isBulldoze = value; } }

        public static bool IsSingle { get { return isSingle; } set { isSingle = value; } }
        public static bool IsShift { get { return isShift; } set { isShift = value; } }
        public static bool IsMulti { get { return isMulti; } set { isMulti = value; } }

        public static bool IsOverwrite { get {  return isOverwrite; } set { isOverwrite = value; } }
        #endregion

    }
}
