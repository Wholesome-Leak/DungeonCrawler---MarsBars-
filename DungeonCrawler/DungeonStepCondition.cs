using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200001C RID: 28
public class DungeonStepCondition
{
	// Token: 0x1700001B RID: 27
	// (get) Token: 0x060000BD RID: 189 RVA: 0x000088D3 File Offset: 0x00006AD3
	// (set) Token: 0x060000BE RID: 190 RVA: 0x000088DB File Offset: 0x00006ADB
	public bool HasCondition { get; set; }

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x060000BF RID: 191 RVA: 0x000088E4 File Offset: 0x00006AE4
	// (set) Token: 0x060000C0 RID: 192 RVA: 0x000088EC File Offset: 0x00006AEC
	public ConditionType ConditionType { get; set; }

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x060000C1 RID: 193 RVA: 0x000088F5 File Offset: 0x00006AF5
	// (set) Token: 0x060000C2 RID: 194 RVA: 0x000088FD File Offset: 0x00006AFD
	public int GameObjectId { get; set; }

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x060000C3 RID: 195 RVA: 0x00008906 File Offset: 0x00006B06
	// (set) Token: 0x060000C4 RID: 196 RVA: 0x0000890E File Offset: 0x00006B0E
	public int InitialFlags { get; set; }

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x060000C5 RID: 197 RVA: 0x00008917 File Offset: 0x00006B17
	// (set) Token: 0x060000C6 RID: 198 RVA: 0x0000891F File Offset: 0x00006B1F
	public int ItemId { get; set; }

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x060000C7 RID: 199 RVA: 0x00008928 File Offset: 0x00006B28
	// (set) Token: 0x060000C8 RID: 200 RVA: 0x00008930 File Offset: 0x00006B30
	public string CSharpCondition { get; set; }

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x060000C9 RID: 201 RVA: 0x00008939 File Offset: 0x00006B39
	// (set) Token: 0x060000CA RID: 202 RVA: 0x00008941 File Offset: 0x00006B41
	public int DeadMobId { get; set; }

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x060000CB RID: 203 RVA: 0x0000894A File Offset: 0x00006B4A
	// (set) Token: 0x060000CC RID: 204 RVA: 0x00008952 File Offset: 0x00006B52
	public int MobPositionId { get; set; }

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x060000CD RID: 205 RVA: 0x0000895B File Offset: 0x00006B5B
	// (set) Token: 0x060000CE RID: 206 RVA: 0x00008963 File Offset: 0x00006B63
	public string MobPositionVector { get; set; }

	// Token: 0x04000061 RID: 97
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool A;

	// Token: 0x04000062 RID: 98
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ConditionType A;

	// Token: 0x04000063 RID: 99
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int A;

	// Token: 0x04000064 RID: 100
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int a;

	// Token: 0x04000065 RID: 101
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int B;

	// Token: 0x04000066 RID: 102
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string A;

	// Token: 0x04000067 RID: 103
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int b;

	// Token: 0x04000068 RID: 104
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int C;

	// Token: 0x04000069 RID: 105
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string a;
}
