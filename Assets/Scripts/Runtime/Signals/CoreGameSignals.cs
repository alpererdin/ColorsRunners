using System;
using System.Collections.Generic;
using MK.Toon;
using Runtime.Enums;
using Runtime.Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction<GameStates> onChangeGameStates = delegate { };
        public UnityAction<byte> onLevelInitialize = delegate { };
        public UnityAction onClearActiveLevel = delegate { };
        public UnityAction onLevelSuccessful = delegate { };
        public UnityAction onLevelFailed = delegate { };
        public UnityAction onNextLevel = delegate { };
        public UnityAction onRestartLevel = delegate { };
        public UnityAction onPlay = delegate { };
        public UnityAction onReset = delegate { };
        public Func<byte> onGetLevelID = delegate { return 0; };

        public UnityAction onMiniGameEntered = delegate { };
        public UnityAction<GameObject> onAtmTouched = delegate { };
        public UnityAction onMiniGameStart = delegate { };

        public UnityAction<GameObject> onEnterTurretArea=delegate {  };
        public UnityAction onExitTurretArea=delegate {  };
        

        public Func<byte> onGetIncomeLevel = delegate { return 0; };
        public Func<byte> onGetStackLevel = delegate { return 0; };
        
        public UnityAction onEnterDroneArea=delegate {  };
        public UnityAction onExitDroneArea=delegate {  };
        
        
    
        
        public UnityAction<GameStates> onChangeGameState = delegate { };
        
        public Func<GameStates> onGetGameState;
        
        public UnityAction onSizeUpPlayer = delegate { };
        public UnityAction onSizeDownPlayer = delegate { };
        public UnityAction<List<GameObject>> onPlayDroneAnim=delegate {  };
        public UnityAction<GameObject> wrongSideDestroyer=delegate {  };
        public UnityAction<OutlineData> onOutLineKiller=delegate {  };
        
    }
}