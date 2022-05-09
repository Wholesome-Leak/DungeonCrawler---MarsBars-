using System;
using System.Collections.Generic;
using robotManager.Helpful;
using wManager.Wow.Helpers;

namespace A
{
	// Token: 0x02000014 RID: 20
	internal static class E
	{
		// Token: 0x04000041 RID: 65
		public static List<PathFinder.OffMeshConnection> A = new List<PathFinder.OffMeshConnection>
		{
			new PathFinder.OffMeshConnection(new List<Vector3>
			{
				new Vector3(-5163.13, 659.6456, 348.2787, "None"),
				new Vector3(-5164.263, 649.1226, 348.2698, "None")
				{
					Action = "c#: Logging.WriteNavigator(\"[OffMeshConnection] Gnomeregan Elevator > Wait Elevator\"); while (Conditions.InGameAndConnectedAndProductStartedNotInPause) { var elevator = ObjectManager.GetWoWGameObjectByEntry(80023).OrderBy(o => o.GetDistance).FirstOrDefault(); if (elevator != null && elevator.IsValid && elevator.Position.DistanceTo(new Vector3(-5164.24, 650.354, 349.52)) < 0.5) break; Thread.Sleep(10); }"
				},
				new Vector3(-5163.218, 660.1608, 247.7662, "None")
				{
					Action = "c#: Logging.WriteNavigator(\"[OffMeshConnection] Gnomeregan Elevator > Wait to leave Elevator\"); while (Conditions.InGameAndConnectedAndProductStartedNotInPause) { var elevator = ObjectManager.GetWoWGameObjectByEntry(80023).OrderBy(o => o.GetDistance).FirstOrDefault(); if (elevator != null && elevator.IsValid && elevator.Position.DistanceTo(new Vector3(-5164.24, 650.354, 249.4379)) < 0.5) break; Thread.Sleep(10); }"
				}
			}, 0, 0, true),
			new PathFinder.OffMeshConnection(new List<Vector3>
			{
				new Vector3(-5163.218, 660.1608, 247.7662, "None"),
				new Vector3(-5164.148, 649.5967, 248.1887, "None")
				{
					Action = "c#: Logging.WriteNavigator(\"[OffMeshConnection] Gnomeregan Elevator > Wait Elevator\"); while (Conditions.InGameAndConnectedAndProductStartedNotInPause) { var elevator = ObjectManager.GetWoWGameObjectByEntry(80023).OrderBy(o => o.GetDistance).FirstOrDefault(); if (elevator != null && elevator.IsValid && elevator.Position.DistanceTo(new Vector3(-5164.24, 650.354, 249.4379)) < 0.5) break; Thread.Sleep(10); }"
				},
				new Vector3(-5163.13, 659.6456, 348.2787, "None")
				{
					Action = "c#: Logging.WriteNavigator(\"[OffMeshConnection] Gnomeregan Elevator > Wait to leave Elevator\"); while (Conditions.InGameAndConnectedAndProductStartedNotInPause) { var elevator = ObjectManager.GetWoWGameObjectByEntry(80023).OrderBy(o => o.GetDistance).FirstOrDefault(); if (elevator != null && elevator.IsValid && elevator.Position.DistanceTo(new Vector3(-5164.24, 650.354, 349.52)) < 0.5) break; Thread.Sleep(10); }"
				}
			}, 0, 0, true)
		};
	}
}
