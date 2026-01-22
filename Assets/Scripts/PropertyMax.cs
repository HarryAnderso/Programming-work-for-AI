using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class PropertyMax : ConditionTask {

        public BBParameter<GameObject> otherFSMObject;
        private Blackboard agentBlackboard;
        private Blackboard otherFSMBlackboard;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){

            otherFSMBlackboard = otherFSMObject.value.GetComponent<Blackboard>();
            agentBlackboard = agent.GetComponent<Blackboard>();

            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            float healthCheck = otherFSMBlackboard.GetVariableValue<float>("Health");

			if (agentBlackboard.GetVariableValue<float>("RecoveryHealth") >= 10)
			{
				otherFSMBlackboard.SetVariableValue("Health", 10);
                agentBlackboard.SetVariableValue("RecoveryHealth", 0);
                return true;
			}
			else return false;

        }
    }
}