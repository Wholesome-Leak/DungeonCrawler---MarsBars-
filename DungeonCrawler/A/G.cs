using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x0200002A RID: 42
	internal class G : State
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00008C5C File Offset: 0x00006E5C
		public override string DisplayName
		{
			get
			{
				return "dDeadSwim";
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00008C63 File Offset: 0x00006E63
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00008C6B File Offset: 0x00006E6B
		public override int Priority { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000133 RID: 307 RVA: 0x000138C0 File Offset: 0x00011AC0
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndProductStartedNotInPause || !G.A.IsDead || !MovementManager.InMovement || G.A.IsSwimming || MovementManager.CurrentPath.Count == 0)
				{
					result = false;
				}
				else
				{
					bool flag;
					if (G.A.HaveBuff("Ghost"))
					{
						if (MovementManager.CurrentPath.Find(new Predicate<Vector3>(G.A.A.A)) != null)
						{
							flag = (MovementManager.CurrentPath.Find(new Predicate<Vector3>(G.A.A.a)).Type == "Swimming");
							goto IL_B9;
						}
					}
					flag = false;
					IL_B9:
					result = flag;
				}
				return result;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00008C74 File Offset: 0x00006E74
		public override void Run()
		{
			Main.logDebug("dDeadSwim: Need to go under water. Diving.", false);
			MovementManager.GoUnderWater();
			Thread.Sleep(500);
		}

		// Token: 0x040000C4 RID: 196
		private static readonly WoWLocalPlayer A = ObjectManager.Me;

		// Token: 0x040000C5 RID: 197
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int A;

		// Token: 0x0200002B RID: 43
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x0600013B RID: 315 RVA: 0x00008CB0 File Offset: 0x00006EB0
			internal bool A(Vector3 vector3_0)
			{
				return vector3_0 == MovementManager.CurrentMoveTo;
			}

			// Token: 0x0600013C RID: 316 RVA: 0x00008CB0 File Offset: 0x00006EB0
			internal bool a(Vector3 vector3_0)
			{
				return vector3_0 == MovementManager.CurrentMoveTo;
			}

			// Token: 0x040000C6 RID: 198
			public static readonly G.A A = new G.A();

			// Token: 0x040000C7 RID: 199
			public static Predicate<Vector3> A;

			// Token: 0x040000C8 RID: 200
			public static Predicate<Vector3> a;
		}
	}
}
