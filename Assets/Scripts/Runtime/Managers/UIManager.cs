using System;
using Runtime.Enums;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour
    {
        private bool _isReadyForIdleGame = false;
        
        private void OnEnable()
        {
            SubscribeEvents();
            OpenStartPanel();
     
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
            CoreGameSignals.Instance.onReset += OnReset;
            
        }
        
        private void OpenStartPanel()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
          
            
             CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level, 1);
        }

        private void OnLevelInitialize(byte levelValue)
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level, 1);
 
            UISignals.Instance.onSetNewLevelValue?.Invoke(levelValue);
        }
        public void OnPlay()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
            CoreUISignals.Instance.onClosePanel?.Invoke(0);
            CoreUISignals.Instance.onClosePanel?.Invoke(2);
        
            CameraSignals.Instance.onChangeCameraState?.Invoke(CameraStates.Follow);
            
        }
        
        private void OnOpenWinPanel()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Win, 2);
        }

        
        private void OnOpenFailPanel()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Fail, 2);
        }

        public void OnNextLevel()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CameraSignals.Instance.onSetCinemachineTarget?.Invoke(CameraTargetState.Player);
            GameStateManager.SetGameState(GameStateManager.GameState.Runner);
            CameraSignals.Instance.onChangeCameraState?.Invoke(CameraStates.Follow);
           
        }

        public void OnRestartLevel()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CameraSignals.Instance.onSetCinemachineTarget?.Invoke(CameraTargetState.Player);
            GameStateManager.SetGameState(GameStateManager.GameState.Runner);
            CameraSignals.Instance.onChangeCameraState?.Invoke(CameraStates.Follow);
        }

        private void OnLevelFailed()
        {
            OnOpenFailPanel();
        }

        private void OnLevelSuccessful()
        {
            OnOpenWinPanel();
        }

        public void OnIncomeUpdate()
        {
            UISignals.Instance.onClickIncome?.Invoke();
            UISignals.Instance.onSetIncomeLvlText?.Invoke();
        }

        public void OnStackUpdate()
        {
            UISignals.Instance.onClickStack?.Invoke();
            UISignals.Instance.onSetStackLvlText?.Invoke();
        }
        private void OnLastCollectableAddedToPlayer(bool isReady)
        {
            _isReadyForIdleGame = isReady;
        }
        public void Claim()
        {
            if (_isReadyForIdleGame )
            {
                //CoreGameSignals.Instance.onChangeGameState?.Invoke();
                
            }
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
        
        private void OnReset()
        {
            CameraSignals.Instance.onSetCinemachineTarget?.Invoke(CameraTargetState.Player);
            CoreUISignals.Instance.onCloseAllPanels?.Invoke();
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level, 1);
        }
    }
}