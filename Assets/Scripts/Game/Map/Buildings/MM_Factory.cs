using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Map.Buildings
{
    public class MM_Factory : MM_Node
    {
        public MM_Factory(int n_Id, int n_X, int n_Y, int n_Z) : base(n_Id, n_X, n_Y, n_Z)
        {
        }

        public override void Build()
        {
            throw new System.NotImplementedException();
        }
    }
}
