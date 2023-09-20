using DG.Tweening;
using Runtime.Enums;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Rigidbody managerRigidbody;

        #endregion

        #region Private Variables

        private readonly string _obstacle = "Obstacle";
        private readonly string _atm = "ATM";
        private readonly string _collectable = "Collectable";
        private readonly string _conveyor = "Conveyor";
        private readonly string _stageArea = "StageArea";
        private readonly string _gate = "Gate";
        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
          /*  if (other.CompareTag(_stageArea))
            {
             
                manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();

                DOVirtual.DelayedCall(3, () =>
                {
                    var result = other.transform.parent.GetComponentInChildren<PoolController>()
                        .TakeResults(manager.StageValue);

                    if (result)
                    {
                        CoreGameSignals.Instance.onStageAreaSuccessful?.Invoke(manager.StageValue);
                        InputSignals.Instance.onEnableInput?.Invoke();
                    }
                    else
                    {
                        CoreGameSignals.Instance.onLevelFailed?.Invoke();
                    }
                });
                return;
            }*/
        /*  if (other.CompareTag(_gate))
          {
              
          }*/
            if (other.CompareTag(_obstacle))
            {
                managerRigidbody.transform.DOMoveZ(managerRigidbody.transform.position.z - 10f, 1f)
                    .SetEase(Ease.OutBack);
                return;
            }

            if (other.CompareTag(_atm))
            {
                CoreGameSignals.Instance.onAtmTouched?.Invoke(other.gameObject);
                return;
            }

            if (other.CompareTag(_collectable))
            {
                other.tag = "Collected";
                StackSignals.Instance.onInteractionCollectable?.Invoke(other.transform.parent.gameObject);
                CollectableSignals.Instance.onChangeCollectableAnimationState?.Invoke(CollectableAnimationStates.Run);
                return;
            }

            if (other.CompareTag(_conveyor))
            {
                CoreGameSignals.Instance.onMiniGameEntered?.Invoke();
                DOVirtual.DelayedCall(1.5f,
                    () => CameraSignals.Instance.onChangeCameraState?.Invoke(CameraStates.MiniGame));
                DOVirtual.DelayedCall(2.5f,
                    () => CameraSignals.Instance.onSetCinemachineTarget?.Invoke(CameraTargetState.FakePlayer));
                return;
            }
        }
    }
}