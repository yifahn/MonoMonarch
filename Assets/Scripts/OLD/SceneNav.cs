using UnityEngine;

namespace Assets.Scripts
{
    public class SceneNav : MonoBehaviour
    {
        public void Navigate()
        {
            Managers.SceneManager.Instance.SceneSelector(Helpers.SceneHelper.SceneStateUpdate(gameObject.name));
        }
    }
}

