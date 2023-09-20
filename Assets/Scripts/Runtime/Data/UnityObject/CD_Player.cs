using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Player", menuName = "ColorsRunners/CD_Player", order = 0)]
    public class CD_Player : ScriptableObject
    {
        public PlayerData Data;

    }
}