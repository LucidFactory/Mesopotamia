using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {

    // This is the blackboard container shared between all nodes.
    // Use this to store temporary data that multiple nodes need read and write access to.
    // Add other properties here that make sense for your specific use case.
    [System.Serializable]
    public class Blackboard {

        public Vector3 moveToPosition;
        public GameObject _canvasToHide;
        public GameObject _gameObjectToFind;
        public InkTest _inkTestScript;
        #region groupeEpreuve
        public string _groupeEpreuve;
        public string _epreuve;
        public int  _epreuveTime;
        public List<int> _epreuveScore;
        #endregion 
        public bool _timerIsFinished;
    }
}