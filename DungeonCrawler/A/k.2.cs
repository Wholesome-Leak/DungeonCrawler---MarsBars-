using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000041 RID: 65
	internal class k : State
	{
		// Token: 0x060001BF RID: 447 RVA: 0x00008FCC File Offset: 0x000071CC
		[CompilerGenerated]
		public IEnumerable<WoWUnit> A()
		{
			return this.A;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00008FD4 File Offset: 0x000071D4
		[CompilerGenerated]
		public void A(IEnumerable<WoWUnit> ienumerable_0)
		{
			this.A = ienumerable_0;
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00015438 File Offset: 0x00013638
		public override string DisplayName
		{
			get
			{
				return "dPrepull";
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0001544C File Offset: 0x0001364C
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x00008FDD File Offset: 0x000071DD
		public override int Priority
		{
			get
			{
				return this.A;
			}
			set
			{
				this.A = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00015464 File Offset: 0x00013664
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause || !C.a() || ObjectManager.Me.InCombat || Fight.InFight)
				{
					result = false;
				}
				else
				{
					if (this.A.IsReady && MovementManager.InMovement)
					{
						this.A = new Timer(500.0);
						IEnumerable<Vector3> source = MovementManager.CurrentPath.Where(new Func<Vector3, bool>(k.a.A.A));
						if (source.Count<Vector3>() > 0)
						{
							using (IEnumerator<Vector3> enumerator = source.OrderBy(new Func<Vector3, float>(k.a.A.a)).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									k.A a = new k.A();
									a.A = enumerator.Current;
									this.A(ObjectManager.GetWoWUnitAttackables(30f).Where(new Func<WoWUnit, bool>(a.A)));
									if (this.A().Count<WoWUnit>() > 0)
									{
										return true;
									}
								}
							}
						}
					}
					result = false;
				}
				return result;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000155A8 File Offset: 0x000137A8
		public override void Run()
		{
			this.A = new Timer(500.0);
			MovementManager.StopMoveOnly();
			WoWUnit woWUnit = this.A().OrderBy(new Func<WoWUnit, float>(k.a.A.A)).FirstOrDefault<WoWUnit>();
			Main.log("Pulling " + woWUnit.Name + ", the mob is on our route.");
			Interact.InteractGameObject(woWUnit.GetBaseAddress, false, false);
			Fight.StartFight(woWUnit.Guid, false, true, false, false);
		}

		// Token: 0x04000104 RID: 260
		private Timer A = new Timer(250.0);

		// Token: 0x04000105 RID: 261
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerable<WoWUnit> A;

		// Token: 0x04000106 RID: 262
		private int A;

		// Token: 0x02000042 RID: 66
		[CompilerGenerated]
		private sealed class A
		{
			// Token: 0x060001CA RID: 458 RVA: 0x00015638 File Offset: 0x00013838
			internal bool A(WoWUnit woWUnit_0)
			{
				return woWUnit_0.Reaction != 3 && woWUnit_0.Position.DistanceTo(this.A) <= 30f && !TraceLine.TraceLineGo(ObjectManager.Me.Position, woWUnit_0.Position, 337) && !woWUnit_0.IsBlacklisted;
			}

			// Token: 0x04000107 RID: 263
			public Vector3 A;
		}

		// Token: 0x02000043 RID: 67
		[CompilerGenerated]
		[Serializable]
		private sealed class a
		{
			// Token: 0x060001CD RID: 461 RVA: 0x0000900E File Offset: 0x0000720E
			internal bool A(Vector3 vector3_0)
			{
				return vector3_0.DistanceTo(ObjectManager.Me.Position) <= 30f && !TraceLine.TraceLineGo(ObjectManager.Me.Position, vector3_0, 337);
			}

			// Token: 0x060001CE RID: 462 RVA: 0x00009042 File Offset: 0x00007242
			internal float a(Vector3 vector3_0)
			{
				return vector3_0.DistanceTo(ObjectManager.Me.Position);
			}

			// Token: 0x060001CF RID: 463 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float A(WoWUnit woWUnit_0)
			{
				return woWUnit_0.GetDistance;
			}

			// Token: 0x04000108 RID: 264
			public static readonly k.a A = new k.a();

			// Token: 0x04000109 RID: 265
			public static Func<Vector3, bool> A;

			// Token: 0x0400010A RID: 266
			public static Func<Vector3, float> A;

			// Token: 0x0400010B RID: 267
			public static Func<WoWUnit, float> A;
		}
	}
}
