using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RepairAT : ActionTask {

		public BBParameter<float> initialScanRadiusBB;
		public BBParameter<float> currentScanRadiusBB;
		public BBParameter<Transform> targetBB;
		public BBParameter<bool> hasTargetBB;

		public float repairRate = 25f;

		private Blackboard lightTowerBB;

        protected override void OnExecute()
        {
            lightTowerBB = targetBB.value.GetComponentInParent<Blackboard>();
        }

		protected override void OnUpdate()
		{
			float repairValue = lightTowerBB.GetVariableValue<float>("repairValue");
			repairValue += repairRate * Time.deltaTime;
			lightTowerBB.SetVariableValue("repairValue", repairValue);

			if(repairValue >= 100)
			{
				hasTargetBB.value = false;
				currentScanRadiusBB.value = initialScanRadiusBB.value;
				EndAction(true);
			}
		}
		
	}
}