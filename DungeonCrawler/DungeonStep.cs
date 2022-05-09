using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200001B RID: 27
public class DungeonStep
{
	// Token: 0x17000016 RID: 22
	// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000887E File Offset: 0x00006A7E
	// (set) Token: 0x060000B3 RID: 179 RVA: 0x00008886 File Offset: 0x00006A86
	public string StepName { get; set; }

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000888F File Offset: 0x00006A8F
	// (set) Token: 0x060000B5 RID: 181 RVA: 0x00008897 File Offset: 0x00006A97
	public DungeonStepCondition Condition { get; set; }

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x060000B6 RID: 182 RVA: 0x000088A0 File Offset: 0x00006AA0
	// (set) Token: 0x060000B7 RID: 183 RVA: 0x000088A8 File Offset: 0x00006AA8
	public int Order { get; set; }

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x060000B8 RID: 184 RVA: 0x000088B1 File Offset: 0x00006AB1
	// (set) Token: 0x060000B9 RID: 185 RVA: 0x000088B9 File Offset: 0x00006AB9
	public StepType StepType { get; set; }

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x060000BA RID: 186 RVA: 0x000088C2 File Offset: 0x00006AC2
	// (set) Token: 0x060000BB RID: 187 RVA: 0x000088CA File Offset: 0x00006ACA
	public bool StepComplete { get; set; }

	// Token: 0x0400005C RID: 92
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string A;

	// Token: 0x0400005D RID: 93
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DungeonStepCondition A;

	// Token: 0x0400005E RID: 94
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int A;

	// Token: 0x0400005F RID: 95
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private StepType A;

	// Token: 0x04000060 RID: 96
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool A;
}
