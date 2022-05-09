using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using robotManager.Helpful;

// Token: 0x02000016 RID: 22
public class Dungeon
{
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x0600007D RID: 125 RVA: 0x000086C6 File Offset: 0x000068C6
	// (set) Token: 0x0600007E RID: 126 RVA: 0x000086CE File Offset: 0x000068CE
	public string Name { get; set; }

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600007F RID: 127 RVA: 0x000086D7 File Offset: 0x000068D7
	// (set) Token: 0x06000080 RID: 128 RVA: 0x000086DF File Offset: 0x000068DF
	public Vector3 Entrance { get; set; }

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000081 RID: 129 RVA: 0x000086E8 File Offset: 0x000068E8
	// (set) Token: 0x06000082 RID: 130 RVA: 0x000086F0 File Offset: 0x000068F0
	public Vector3 Start { get; set; }

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000083 RID: 131 RVA: 0x000086F9 File Offset: 0x000068F9
	// (set) Token: 0x06000084 RID: 132 RVA: 0x00008701 File Offset: 0x00006901
	public int DungeonId { get; set; }

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000085 RID: 133 RVA: 0x0000870A File Offset: 0x0000690A
	// (set) Token: 0x06000086 RID: 134 RVA: 0x00008712 File Offset: 0x00006912
	public int MapId { get; set; }

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000087 RID: 135 RVA: 0x0000871B File Offset: 0x0000691B
	// (set) Token: 0x06000088 RID: 136 RVA: 0x00008723 File Offset: 0x00006923
	public DungeonProfile DungeonProfile { get; set; }

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000089 RID: 137 RVA: 0x0000872C File Offset: 0x0000692C
	// (set) Token: 0x0600008A RID: 138 RVA: 0x00008734 File Offset: 0x00006934
	public bool HasCustomBehaviours { get; set; }

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x0600008B RID: 139 RVA: 0x0000873D File Offset: 0x0000693D
	// (set) Token: 0x0600008C RID: 140 RVA: 0x00008745 File Offset: 0x00006945
	public List<CustomDungeonBehaviour> CustomDungeonBehaviours { get; set; }

	// Token: 0x04000042 RID: 66
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string A;

	// Token: 0x04000043 RID: 67
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3 A;

	// Token: 0x04000044 RID: 68
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3 a;

	// Token: 0x04000045 RID: 69
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int A;

	// Token: 0x04000046 RID: 70
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int a;

	// Token: 0x04000047 RID: 71
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DungeonProfile A;

	// Token: 0x04000048 RID: 72
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool A;

	// Token: 0x04000049 RID: 73
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<CustomDungeonBehaviour> A;
}
