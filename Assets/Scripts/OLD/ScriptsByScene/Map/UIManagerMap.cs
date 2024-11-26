using Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace ScriptsByScene
{
    public class UIManagerMap : MonoBehaviour
    {
        //buildingselectedstate enums
        //buildbulldozestate enums
        //isReadyPlaystate enums
        //isNewGamestate enums



        private TMP_Text altBuild_1, altBuild_2;
        public void AltBuildController_UI()
        {

            if (Helpers.BuilderHelper.AltState == Helpers.AltState.FirstSelected)
            {
                altBuild_1.text = $"{Helpers.MapHelper.CalculateNodePos(Helpers.BuilderHelper.N_Id_1_Alt)[0]},{Helpers.MapHelper.CalculateNodePos(Helpers.BuilderHelper.N_Id_1_Alt)[1]}";
            }
            else if (Helpers.BuilderHelper.AltState == Helpers.AltState.SecondSelected)
            {
                altBuild_2.text = $"{Helpers.MapHelper.CalculateNodePos(Helpers.BuilderHelper.N_Id_2_Alt)[0]},{Helpers.MapHelper.CalculateNodePos(Helpers.BuilderHelper.N_Id_2_Alt)[1]}";
            }
            else
            {
                altBuild_1.text = "0,0";
                altBuild_2.text = "0,0";
            }
        }
    }
}
