using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using robotManager.Events;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using wManager;
using wManager.Wow.Bot.States;
using wManager.Wow.Class;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace A
{
	// Token: 0x02000002 RID: 2
	internal static class A
	{
		// Token: 0x06000002 RID: 2 RVA: 0x000083B2 File Offset: 0x000065B2
		[CompilerGenerated]
		public static Timer A()
		{
			return global::A.A.a;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000083B9 File Offset: 0x000065B9
		[CompilerGenerated]
		public static void A(Timer timer_0)
		{
			global::A.A.a = timer_0;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000083C1 File Offset: 0x000065C1
		[CompilerGenerated]
		public static WoWUnit a()
		{
			return global::A.A.A;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000083C8 File Offset: 0x000065C8
		[CompilerGenerated]
		public static void A(WoWUnit woWUnit_0)
		{
			global::A.A.A = woWUnit_0;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000083D0 File Offset: 0x000065D0
		[CompilerGenerated]
		public static WoWUnit B()
		{
			return global::A.A.a;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000083D7 File Offset: 0x000065D7
		[CompilerGenerated]
		public static void a(WoWUnit woWUnit_0)
		{
			global::A.A.a = woWUnit_0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000083DF File Offset: 0x000065DF
		[CompilerGenerated]
		public static bool b()
		{
			return global::A.A.B;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000083E6 File Offset: 0x000065E6
		[CompilerGenerated]
		public static void A(bool bool_0)
		{
			global::A.A.B = bool_0;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000083EE File Offset: 0x000065EE
		[CompilerGenerated]
		public static DungeonStep C()
		{
			return global::A.A.A;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000083F5 File Offset: 0x000065F5
		[CompilerGenerated]
		public static void A(DungeonStep dungeonStep_0)
		{
			global::A.A.A = dungeonStep_0;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000083FD File Offset: 0x000065FD
		[CompilerGenerated]
		public static string c()
		{
			return global::A.A.A;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00008404 File Offset: 0x00006604
		[CompilerGenerated]
		public static void A(string string_0)
		{
			global::A.A.A = string_0;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000095E8 File Offset: 0x000077E8
		public static bool D()
		{
			bool result;
			try
			{
				global::A.A.A = new Engine(true);
				global::A.A.A = false;
				EventsLua.AttachEventLua(162, new EventsLua.MethodDelegate(global::A.A.A.A.A));
				PathFinder.OffMeshConnections.AddRange(global::A.E.A, true);
				EventsLuaWithArgs.OnEventsLuaWithArgs += new EventsLuaWithArgs.EventsLuaWithArgsHandler(global::A.C.A);
				FiniteStateMachineEvents.OnBeforeCheckIfNeedToRunState += new FiniteStateMachineEvents.FSMEngineStateCancelableHandler(global::A.A.a);
				FiniteStateMachineEvents.OnRunState += new FiniteStateMachineEvents.FSMEngineStateCancelableHandler(global::A.A.A);
				if (!Var.Exist("skipStep"))
				{
					Var.SetVar("skipStep", "false");
				}
				Q.A();
				if (DungeonCrawlerSettings.CurrentSetting.AutoEquip)
				{
					global::A.A.A = new Timer();
					global::A.A.A.Elapsed += global::A.B.A;
					global::A.A.A.Interval = 5000.0;
					global::A.A.A.Start();
				}
				LuaFrame.CreateFrame();
				global::A.A.A(new Timer());
				global::A.A.A().Elapsed += global::A.A.A;
				global::A.A.A().Interval = 500.0;
				global::A.A.A().Start();
				NpcDB.AddNpcRange(f.A, false, false);
				global::A.C.A(DungeonCrawlerSettings.CurrentSetting.Role);
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), string.Format("{0}Trainer", ObjectManager.Me.WowClass));
				Main.log(string.Format("Class Trainer Type: {0}", global::A.A.A));
				SpellManager.UpdateSpellBook();
				CustomClass.LoadCustomClass();
				global::A.A.A.States.Clear();
				global::A.A.A.AddState(new Relogger
				{
					Priority = 2000
				});
				global::A.A.A.AddState(new Pause
				{
					Priority = 200
				});
				global::A.A.A.AddState(new G
				{
					Priority = 185
				});
				global::A.A.A.AddState(new n
				{
					Priority = 180
				});
				global::A.A.A.AddState(new MyMacro
				{
					Priority = 150
				});
				if (DungeonCrawlerSettings.CurrentSetting.Role != LFGRole.Tank)
				{
					global::A.A.A.AddState(new i
					{
						Priority = 120
					});
				}
				global::A.A.A.AddState(new o
				{
					Priority = 110
				});
				global::A.A.A.AddState(new L
				{
					Priority = 108
				});
				global::A.A.A.AddState(new g
				{
					Priority = 105
				});
				global::A.A.A.AddState(new Regeneration
				{
					Priority = 100
				});
				global::A.A.A.AddState(new h
				{
					Priority = 80
				});
				global::A.A.A.AddState(new Looting
				{
					Priority = 70
				});
				global::A.A.A.AddState(new K
				{
					Priority = 60
				});
				global::A.A.A.AddState(new M
				{
					Priority = 55
				});
				global::A.A.A.AddState(new m
				{
					Priority = 50
				});
				if (DungeonCrawlerSettings.CurrentSetting.IsLeader)
				{
					global::A.A.A.AddState(new H
					{
						Priority = 35
					});
				}
				global::A.A.A.AddState(new P
				{
					Priority = 30
				});
				global::A.A.A.AddState(new l
				{
					Priority = 28
				});
				if (DungeonCrawlerSettings.CurrentSetting.Role == LFGRole.Tank)
				{
					global::A.A.A.AddState(new N
					{
						Priority = 26
					});
					global::A.A.A.AddState(new k
					{
						Priority = 25
					});
				}
				else
				{
					global::A.A.A.AddState(new J
					{
						Priority = 15
					});
				}
				global::A.A.A.AddState(new j
				{
					Priority = 20
				});
				global::A.A.A.AddState(new I
				{
					Priority = 17
				});
				global::A.A.A.AddState(new AntiAfk
				{
					Priority = 10
				});
				global::A.A.A.AddState(new Idle
				{
					Priority = 0
				});
				global::A.A.A.States.Sort();
				global::A.A.A.StartEngine(18, "", false);
				StopBotIf.LaunchNewThread();
				if (wManagerSetting.CurrentSetting.NpcScanAuctioneer || wManagerSetting.CurrentSetting.NpcScanVendor || wManagerSetting.CurrentSetting.NpcScanRepair || wManagerSetting.CurrentSetting.NpcScanMailboxes)
				{
					NPCScanState.LaunchNewThread();
				}
				result = true;
			}
			catch (Exception ex)
			{
				try
				{
					global::A.A.E();
				}
				catch
				{
				}
				string str = "> Bot > Bot  > Pulse(): ";
				Exception ex2 = ex;
				Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
				result = false;
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000840C File Offset: 0x0000660C
		private static void A(object sender, ElapsedEventArgs e)
		{
			LuaFrame.UpdateFrame();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00009AE0 File Offset: 0x00007CE0
		private static void A(Engine engine_0, State state_0, CancelEventArgs cancelEventArgs_0)
		{
			if (!state_0.DisplayName.Contains("Security"))
			{
				global::A.A.A(state_0.DisplayName);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00009B10 File Offset: 0x00007D10
		public static void a(Engine engine_0, State state_0, CancelEventArgs cancelEventArgs_0)
		{
			if (engine_0.States.Count > 1)
			{
				global::A.A.A(engine_0.States.Where(new Func<State, bool>(global::A.A.A.A.A)).Count(new Func<State, bool>(global::A.A.A.A.a)) == 0);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00009B84 File Offset: 0x00007D84
		public static void d()
		{
			switch (ObjectManager.Me.WowClass)
			{
			case 1:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "WarriorTrainer");
				break;
			case 2:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "PaladinTrainer");
				break;
			case 3:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "HunterTrainer");
				break;
			case 4:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "RogueTrainer");
				break;
			case 5:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "PriestTrainer");
				break;
			case 6:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "DeathKnightTrainer");
				break;
			case 7:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "ShamanTrainer");
				break;
			case 8:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "MageTrainer");
				break;
			case 9:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "WarlockTrainer");
				break;
			case 10:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "MonkTrainer");
				break;
			case 11:
				global::A.A.A = (Npc.NpcType)Enum.Parse(typeof(Npc.NpcType), "DruidTrainer");
				break;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00009D48 File Offset: 0x00007F48
		internal static void E()
		{
			try
			{
				global::A.e.a(null);
				global::A.B.A.Clear();
				if (DungeonCrawlerSettings.CurrentSetting.AutoEquip)
				{
					global::A.A.A.Dispose();
				}
				global::A.A.A().Dispose();
				LuaFrame.HideFrame();
				Q.a();
				EventsLuaWithArgs.OnEventsLuaWithArgs -= new EventsLuaWithArgs.EventsLuaWithArgsHandler(global::A.C.A);
				FiniteStateMachineEvents.OnBeforeCheckIfNeedToRunState -= new FiniteStateMachineEvents.FSMEngineStateCancelableHandler(global::A.A.a);
				CustomClass.DisposeCustomClass();
				global::A.A.A.StopEngine();
				Fight.StopFight();
				MovementManager.StopMove();
			}
			catch (Exception ex)
			{
				string str = "> Bot > Bot  > Dispose(): ";
				Exception ex2 = ex;
				Main.logError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00008413 File Offset: 0x00006613
		private static void e()
		{
			Logging.Write("Level UP! Reload Fight Class.");
			SpellManager.UpdateSpellBook();
			CustomClass.ResetCustomClass();
			global::A.A.a = true;
		}

		// Token: 0x04000001 RID: 1
		public static Engine A = new Engine(true);

		// Token: 0x04000002 RID: 2
		public static bool A;

		// Token: 0x04000003 RID: 3
		public static bool a;

		// Token: 0x04000004 RID: 4
		public static Npc.NpcType A;

		// Token: 0x04000005 RID: 5
		public static Timer A;

		// Token: 0x04000006 RID: 6
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static Timer a;

		// Token: 0x04000007 RID: 7
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static WoWUnit A;

		// Token: 0x04000008 RID: 8
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static WoWUnit a;

		// Token: 0x04000009 RID: 9
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static bool B;

		// Token: 0x0400000A RID: 10
		internal static bool b = false;

		// Token: 0x0400000B RID: 11
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static DungeonStep A;

		// Token: 0x0400000C RID: 12
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static string A;

		// Token: 0x0400000D RID: 13
		public static Stopwatch A;

		// Token: 0x02000003 RID: 3
		[CompilerGenerated]
		[Serializable]
		private sealed class A
		{
			// Token: 0x06000018 RID: 24 RVA: 0x00008456 File Offset: 0x00006656
			internal void A(object object_0)
			{
				global::A.A.e();
			}

			// Token: 0x06000019 RID: 25 RVA: 0x0000845D File Offset: 0x0000665D
			internal bool A(State state_0)
			{
				return state_0.DisplayName == "dVendoring" || state_0.DisplayName == "dTraining";
			}

			// Token: 0x0600001A RID: 26 RVA: 0x00008484 File Offset: 0x00006684
			internal bool a(State state_0)
			{
				return state_0.NeedToRun;
			}

			// Token: 0x0400000E RID: 14
			public static readonly global::A.A.A A = new global::A.A.A();

			// Token: 0x0400000F RID: 15
			public static EventsLua.MethodDelegate A;

			// Token: 0x04000010 RID: 16
			public static Func<State, bool> A;

			// Token: 0x04000011 RID: 17
			public static Func<State, bool> a;
		}
	}
}
