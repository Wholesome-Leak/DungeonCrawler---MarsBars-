using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using robotManager.Products;
using wManager.Wow.Bot.Tasks;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x0200003A RID: 58
	internal class j : State
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00014590 File Offset: 0x00012790
		public override string DisplayName
		{
			get
			{
				return "dRoute";
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600018C RID: 396 RVA: 0x000145A4 File Offset: 0x000127A4
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00008E87 File Offset: 0x00007087
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

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600018E RID: 398 RVA: 0x000145BC File Offset: 0x000127BC
		public override bool NeedToRun
		{
			get
			{
				bool result;
				if (!Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause || !C.a() || D.A() || e.a() == null)
				{
					result = false;
				}
				else
				{
					bool flag;
					if (DungeonCrawlerSettings.CurrentSetting.Role != LFGRole.Tank)
					{
						flag = (ObjectManager.GetObjectWoWPlayer().Count(new Func<WoWPlayer, bool>(j.A.A.A)) == 0);
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						result = this.A.IsReady;
					}
					else
					{
						result = (DungeonCrawlerSettings.CurrentSetting.Role == LFGRole.Tank && this.A.IsReady);
					}
				}
				return result;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0001465C File Offset: 0x0001285C
		public override void Run()
		{
			this.A = new Timer(250.0);
			if (Var.GetVar<string>("skipStep") == "true")
			{
				MovementManager.StopMoveOnly();
				Var.SetVar("skipStep", "false");
				this.B();
			}
			if (DungeonCrawlerSettings.CurrentSetting.Role == LFGRole.Tank)
			{
				this.A();
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x000146C4 File Offset: 0x000128C4
		public void A()
		{
			if (this.a.IsReady)
			{
				j.a a = new j.a();
				this.a = new Timer(10000.0);
				a.A = C.E().Replace("#||#", "");
				if (!string.IsNullOrWhiteSpace(a.A) && global::A.A.B().Name != a.A)
				{
					Main.logDebug("Setting lfgHealer to '" + a.A + "'", false);
					global::A.A.a(Party.GetPartyHomeAndInstance().FirstOrDefault(new Func<WoWPlayer, bool>(a.A)));
				}
			}
			Dungeon dungeon = e.a();
			if (dungeon.DungeonProfile != null)
			{
				if (global::A.A.C() == null || !dungeon.DungeonProfile.DungeonSteps.Contains(global::A.A.C()))
				{
					this.A(dungeon.DungeonProfile);
				}
				if (!MovementManager.InMovement)
				{
					Main.status("Current Step: " + global::A.A.C().StepName);
					StepType stepType = global::A.A.C().StepType;
					StepType stepType2 = stepType;
					FollowPathStep followPathStep = stepType2 as FollowPathStep;
					if (followPathStep == null)
					{
						InteractStep interactStep = stepType2 as InteractStep;
						if (interactStep == null)
						{
							GossipNpcStep gossipNpcStep = stepType2 as GossipNpcStep;
							if (gossipNpcStep == null)
							{
								RunCodeStep runCodeStep = stepType2 as RunCodeStep;
								if (runCodeStep == null)
								{
									FollowNPCStep followNPCStep = stepType2 as FollowNPCStep;
									if (followNPCStep != null)
									{
										this.A(followNPCStep);
									}
								}
								else
								{
									this.A(runCodeStep);
								}
							}
							else
							{
								this.A(gossipNpcStep);
							}
						}
						else
						{
							this.A(interactStep);
						}
					}
					else
					{
						this.A(followPathStep);
					}
					if (global::A.A.C().StepType.StepTypeName == "StepType")
					{
						this.B();
					}
				}
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0001487C File Offset: 0x00012A7C
		public void a()
		{
			float num = 9999f;
			Dungeon dungeon = e.a();
			if (dungeon.DungeonProfile != null)
			{
				if (global::A.A.C() == null)
				{
					foreach (DungeonStep dungeonStep in dungeon.DungeonProfile.DungeonSteps.Where(new Func<DungeonStep, bool>(j.A.A.A)))
					{
						FollowPathStep followPathStep = (FollowPathStep)dungeonStep.StepType;
						if (followPathStep.Path.Count > 0)
						{
							float num2 = followPathStep.Path.Min(new Func<Vector3, float>(j.A.A.A));
							if (num2 < num)
							{
								num = num2;
								global::A.A.A(dungeonStep);
							}
						}
					}
				}
				if (!MovementManager.InMovement)
				{
					Main.status("Current Step: " + global::A.A.C().StepName);
					StepType stepType = global::A.A.C().StepType;
					StepType stepType2 = stepType;
					FollowPathStep followPathStep2 = stepType2 as FollowPathStep;
					if (followPathStep2 == null)
					{
						this.B();
					}
					else
					{
						this.A(followPathStep2);
					}
					if (global::A.A.C().StepType.StepTypeName == "StepType")
					{
						this.B();
					}
				}
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000149E4 File Offset: 0x00012BE4
		private void A(FollowNPCStep followNPCStep_0)
		{
			if (followNPCStep_0.NpcId > 0)
			{
				j.B b = new j.B();
				b.A = ObjectManager.GetNearestWoWUnit(ObjectManager.GetWoWUnitByEntry(followNPCStep_0.NpcId), true);
				if (b.A != null)
				{
					if (b.A.InCombat || b.A.HasTarget)
					{
						WoWUnit woWUnit = ObjectManager.GetWoWUnitAttackables(float.MaxValue).FirstOrDefault(new Func<WoWUnit, bool>(b.A));
						if (woWUnit != null)
						{
							Interact.InteractGameObject(woWUnit.GetBaseAddress, false, false);
							Fight.StartFight(woWUnit.Guid, false, true, false, false);
						}
					}
					else
					{
						Vector3 position = b.A.Position;
						if (b.A.GetDistance > 10f)
						{
							GoToTask.ToPosition(position, 3.5f, false, null);
						}
					}
				}
			}
			else
			{
				Main.log("No npc id set for step '" + global::A.A.C().StepName + "'.");
			}
			if (global::A.A.C().Condition == null || !global::A.A.C().Condition.HasCondition)
			{
				this.B();
			}
			else
			{
				this.b();
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00014B10 File Offset: 0x00012D10
		private void A(GossipNpcStep gossipNpcStep_0)
		{
			if (gossipNpcStep_0.NpcId > 0)
			{
				WoWUnit nearestWoWUnit = ObjectManager.GetNearestWoWUnit(ObjectManager.GetWoWUnitByEntry(gossipNpcStep_0.NpcId), true);
				if (nearestWoWUnit != null)
				{
					Main.log("Gossiping with " + nearestWoWUnit.Name + ".");
					Vector3 position = nearestWoWUnit.Position;
					GoToTask.ToPositionAndIntecractWithNpc(position, gossipNpcStep_0.NpcId, gossipNpcStep_0.GossipIndex, false, null, false);
				}
			}
			else
			{
				Main.log("No npc id set for step '" + global::A.A.C().StepName + "'.");
			}
			if (global::A.A.C().Condition == null || !global::A.A.C().Condition.HasCondition)
			{
				Main.log("No complete condition.");
				this.B();
			}
			else
			{
				Main.log("Handle complete condition.");
				this.b();
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00014BDC File Offset: 0x00012DDC
		private void A(InteractStep interactStep_0)
		{
			if (interactStep_0.GameObjectId > 0)
			{
				WoWGameObject nearestWoWGameObject = ObjectManager.GetNearestWoWGameObject(ObjectManager.GetWoWGameObjectByEntry(interactStep_0.GameObjectId), true, true);
				if (nearestWoWGameObject != null)
				{
					Main.log("Interacting with " + nearestWoWGameObject.Name + ".");
					Vector3 position = nearestWoWGameObject.Position;
					GoToTask.ToPositionAndIntecractWithGameObject(position, interactStep_0.GameObjectId, -1, false, null);
				}
			}
			else
			{
				Main.log("No gameobject id set for step '" + global::A.A.C().StepName + "'.");
			}
			if (global::A.A.C().Condition == null || !global::A.A.C().Condition.HasCondition)
			{
				this.B();
			}
			else if (global::A.A.C().Condition != null)
			{
				this.b();
			}
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00014CA0 File Offset: 0x00012EA0
		private void A(FollowPathStep followPathStep_0)
		{
			if (followPathStep_0.Path.Count > 0 && !MovementManager.InMovement)
			{
				int num = Math.NearestVector3OfListVectors3(followPathStep_0.Path, j.A.Position);
				if (GoToTask.ToPosition(followPathStep_0.Path[num], 3.5f, false, null))
				{
					MovementManager.Go(followPathStep_0.Path.GetRange(num, followPathStep_0.Path.Count - num), true);
				}
			}
			else
			{
				Main.log("No vectors in path for step '" + global::A.A.C().StepName + "'.");
			}
			if ((global::A.A.C().Condition == null || !global::A.A.C().Condition.HasCondition) && j.A.Position.DistanceTo(followPathStep_0.Path.Last<Vector3>()) < 10f)
			{
				this.B();
			}
			else if (global::A.A.C().Condition != null)
			{
				this.b();
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00014D98 File Offset: 0x00012F98
		private void A(RunCodeStep runCodeStep_0)
		{
			if (!string.IsNullOrWhiteSpace(runCodeStep_0.Code))
			{
				string text = "using System;\r\n                        using System.Collections.Generic;\r\n                        using System.ComponentModel;\r\n                        using System.Configuration;\r\n                        using System.IO;\r\n                        using System.Linq;\r\n                        using System.Threading;\r\n                        using robotManager;\r\n                        using robotManager.FiniteStateMachine;\r\n                        using robotManager.Helpful;\r\n                        using wManager.Wow.Class;\r\n                        using wManager.Wow.Helpers;\r\n                        using wManager.Wow.ObjectManager;\r\n                        using Timer = robotManager.Helpful.Timer;\r\n                        using wManager.Wow.Enums;\r\n\r\n                        public class Main\r\n                        {\r\n                            public static void Pulse()\r\n                            {\r\n                                [RUNCODE];\r\n                            }\r\n                        }";
				string text2;
				if (!RunCode.CompileAndInvokeStaticMethod(0, text.Replace("[RUNCODE]", runCodeStep_0.Code), "Main", "Pulse", ref text2, false, true))
				{
					Logging.WriteError(text2, true);
				}
			}
			else
			{
				Main.log("No code found in RuncodeStep - '" + global::A.A.C().StepName + "'.");
			}
			if (!global::A.A.C().Condition.HasCondition)
			{
				this.B();
			}
			else if (global::A.A.C().Condition != null)
			{
				this.b();
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00014E40 File Offset: 0x00013040
		private void B()
		{
			j.b b = new j.b();
			Dungeon dungeon = e.a();
			dungeon.DungeonProfile.DungeonSteps.FirstOrDefault(new Func<DungeonStep, bool>(j.A.A.a)).StepComplete = true;
			b.A = dungeon.DungeonProfile.DungeonSteps.OrderBy(new Func<DungeonStep, int>(j.A.A.B)).FirstOrDefault(new Func<DungeonStep, bool>(j.A.A.b));
			if (b.A != null)
			{
				if (dungeon.DungeonProfile.DungeonSteps.Count(new Func<DungeonStep, bool>(b.A)) > 1)
				{
					MessageBox.Show(string.Format("More than one DungeonStep with order {0}. This will cause problems, please fix the order of the steps in the profile editor. DungeonCrawler will now stop.", b.A.Order));
					Products.ProductStop();
				}
				Main.log(string.Format("Moving from step {0}:{1} to step {2}:{3}.", new object[]
				{
					global::A.A.C().StepName,
					global::A.A.C().Order,
					b.A.StepName,
					b.A.Order
				}));
				global::A.A.A(b.A);
			}
			else
			{
				Main.log("No step after " + global::A.A.C().StepName + ". Profile complete.");
				global::A.A.A(null);
				e.A(true);
				this.A = true;
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00014FD0 File Offset: 0x000131D0
		private void b()
		{
			switch (global::A.A.C().Condition.ConditionType)
			{
			case ConditionType.Csharp:
				this.B();
				break;
			case ConditionType.FlagsChanged:
			{
				WoWGameObject woWGameObject = ObjectManager.GetWoWGameObjectByEntry(global::A.A.C().Condition.GameObjectId).OrderBy(new Func<WoWGameObject, float>(j.A.A.A)).FirstOrDefault<WoWGameObject>();
				Main.logDebug(string.Format("FlagsChanged Complete condition, InitialFlags: {0}, CurrentFlags:{1}", global::A.A.C().Condition.InitialFlags, woWGameObject.FlagsInt), false);
				if (woWGameObject.FlagsInt != global::A.A.C().Condition.InitialFlags)
				{
					this.B();
				}
				break;
			}
			case ConditionType.HaveItem:
			{
				int itemCountByIdLUA = ItemsManager.GetItemCountByIdLUA((uint)global::A.A.C().Condition.ItemId);
				if (itemCountByIdLUA > 0)
				{
					this.B();
				}
				break;
			}
			case ConditionType.MobDead:
			{
				WoWUnit woWUnit = ObjectManager.GetObjectWoWUnit().Where(new Func<WoWUnit, bool>(j.A.A.A)).OrderBy(new Func<WoWUnit, float>(j.A.A.a)).FirstOrDefault<WoWUnit>();
				Main.log(string.Format("mob dead condition hit, mob dead id: {0}", global::A.A.C().Condition.DeadMobId));
				if (woWUnit != null && woWUnit.IsDead)
				{
					Main.log(string.Format("Mob detected: {0} - {1} yards away. Moving to next step.", woWUnit.Name, woWUnit.GetDistance));
					this.B();
				}
				else
				{
					Main.log("Mob not found. Moving to next step.");
					this.B();
				}
				break;
			}
			case ConditionType.MobPosition:
			{
				WoWUnit woWUnit2 = ObjectManager.GetWoWUnitByEntry(global::A.A.C().Condition.MobPositionId).OrderBy(new Func<WoWUnit, float>(j.A.A.B)).FirstOrDefault<WoWUnit>();
				string[] array = global::A.A.C().Condition.MobPositionVector.Split(new char[]
				{
					','
				});
				Vector3 vector = new Vector3(Convert.ToDouble(array[0]), Convert.ToDouble(array[1]), Convert.ToDouble(array[2]), "None");
				if (woWUnit2 != null && vector.DistanceTo(woWUnit2.Position) < 5f)
				{
					this.B();
				}
				break;
			}
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000083B0 File Offset: 0x000065B0
		private void A(object sender, ElapsedEventArgs e)
		{
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0001524C File Offset: 0x0001344C
		private void A(DungeonProfile dungeonProfile_0)
		{
			DungeonStep dungeonStep = dungeonProfile_0.DungeonSteps.Where(new Func<DungeonStep, bool>(j.A.A.C)).OrderBy(new Func<DungeonStep, int>(j.A.A.c)).FirstOrDefault<DungeonStep>();
			if (dungeonStep != null)
			{
				Main.log("Found current step " + dungeonStep.StepName + ".");
				global::A.A.A(dungeonStep);
			}
			else
			{
				Main.log("Could not find a non-complete step.");
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> NextStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00013988 File Offset: 0x00011B88
		public override List<State> BeforeStates
		{
			get
			{
				return new List<State>();
			}
		}

		// Token: 0x040000E9 RID: 233
		private static readonly WoWLocalPlayer A = ObjectManager.Me;

		// Token: 0x040000EA RID: 234
		private Timer A = new Timer(250.0);

		// Token: 0x040000EB RID: 235
		private Timer a = new Timer(250.0);

		// Token: 0x040000EC RID: 236
		private Timer B = new Timer(250.0);

		// Token: 0x040000ED RID: 237
		private bool A = false;

		// Token: 0x040000EE RID: 238
		private int A;

		// Token: 0x0200003B RID: 59
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x060001A1 RID: 417 RVA: 0x00008EA8 File Offset: 0x000070A8
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.Name == global::A.A.a().Name;
			}

			// Token: 0x060001A2 RID: 418 RVA: 0x00008EBF File Offset: 0x000070BF
			internal bool A(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.StepType.GetType() == typeof(FollowPathStep);
			}

			// Token: 0x060001A3 RID: 419 RVA: 0x00008EDB File Offset: 0x000070DB
			internal float A(Vector3 vector3_0)
			{
				return vector3_0.DistanceTo(j.A.Position);
			}

			// Token: 0x060001A4 RID: 420 RVA: 0x00008EED File Offset: 0x000070ED
			internal bool a(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order == global::A.A.C().Order;
			}

			// Token: 0x060001A5 RID: 421 RVA: 0x00008F01 File Offset: 0x00007101
			internal int B(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x060001A6 RID: 422 RVA: 0x00008F09 File Offset: 0x00007109
			internal bool b(DungeonStep dungeonStep_0)
			{
				return !dungeonStep_0.StepComplete && dungeonStep_0.Order > global::A.A.C().Order;
			}

			// Token: 0x060001A7 RID: 423 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float A(WoWGameObject woWGameObject_0)
			{
				return woWGameObject_0.GetDistance;
			}

			// Token: 0x060001A8 RID: 424 RVA: 0x00008F28 File Offset: 0x00007128
			internal bool A(WoWUnit woWUnit_0)
			{
				return woWUnit_0.Entry == global::A.A.C().Condition.DeadMobId;
			}

			// Token: 0x060001A9 RID: 425 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float a(WoWUnit woWUnit_0)
			{
				return woWUnit_0.GetDistance;
			}

			// Token: 0x060001AA RID: 426 RVA: 0x000085D8 File Offset: 0x000067D8
			internal float B(WoWUnit woWUnit_0)
			{
				return woWUnit_0.GetDistance;
			}

			// Token: 0x060001AB RID: 427 RVA: 0x00008F41 File Offset: 0x00007141
			internal bool C(DungeonStep dungeonStep_0)
			{
				return !dungeonStep_0.StepComplete;
			}

			// Token: 0x060001AC RID: 428 RVA: 0x00008F01 File Offset: 0x00007101
			internal int c(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order;
			}

			// Token: 0x040000EF RID: 239
			public static readonly j.A A = new j.A();

			// Token: 0x040000F0 RID: 240
			public static Func<WoWPlayer, bool> A;

			// Token: 0x040000F1 RID: 241
			public static Func<DungeonStep, bool> A;

			// Token: 0x040000F2 RID: 242
			public static Func<Vector3, float> A;

			// Token: 0x040000F3 RID: 243
			public static Func<DungeonStep, bool> a;

			// Token: 0x040000F4 RID: 244
			public static Func<DungeonStep, int> A;

			// Token: 0x040000F5 RID: 245
			public static Func<DungeonStep, bool> B;

			// Token: 0x040000F6 RID: 246
			public static Func<WoWGameObject, float> A;

			// Token: 0x040000F7 RID: 247
			public static Func<WoWUnit, bool> A;

			// Token: 0x040000F8 RID: 248
			public static Func<WoWUnit, float> A;

			// Token: 0x040000F9 RID: 249
			public static Func<WoWUnit, float> a;

			// Token: 0x040000FA RID: 250
			public static Func<DungeonStep, bool> b;

			// Token: 0x040000FB RID: 251
			public static Func<DungeonStep, int> a;
		}

		// Token: 0x0200003C RID: 60
		[CompilerGenerated]
		private sealed class a
		{
			// Token: 0x060001AE RID: 430 RVA: 0x00008F4C File Offset: 0x0000714C
			internal bool A(WoWPlayer woWPlayer_0)
			{
				return woWPlayer_0.Name == this.A;
			}

			// Token: 0x040000FC RID: 252
			public string A;
		}

		// Token: 0x0200003D RID: 61
		[CompilerGenerated]
		private sealed class B
		{
			// Token: 0x060001B0 RID: 432 RVA: 0x00008F5F File Offset: 0x0000715F
			internal bool A(WoWUnit woWUnit_0)
			{
				return woWUnit_0.Target == this.A.Guid;
			}

			// Token: 0x040000FD RID: 253
			public WoWUnit A;
		}

		// Token: 0x0200003E RID: 62
		[CompilerGenerated]
		private sealed class b
		{
			// Token: 0x060001B2 RID: 434 RVA: 0x00008F74 File Offset: 0x00007174
			internal bool A(DungeonStep dungeonStep_0)
			{
				return dungeonStep_0.Order == this.A.Order;
			}

			// Token: 0x040000FE RID: 254
			public DungeonStep A;
		}
	}
}
