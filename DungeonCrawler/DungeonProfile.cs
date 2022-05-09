using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using robotManager.Helpful;
using wManager.Wow.Helpers;

// Token: 0x0200001A RID: 26
public class DungeonProfile
{
	// Token: 0x17000010 RID: 16
	// (get) Token: 0x060000A5 RID: 165 RVA: 0x000087E4 File Offset: 0x000069E4
	// (set) Token: 0x060000A6 RID: 166 RVA: 0x000087EC File Offset: 0x000069EC
	public string Name { get; set; }

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x060000A7 RID: 167 RVA: 0x000087F5 File Offset: 0x000069F5
	// (set) Token: 0x060000A8 RID: 168 RVA: 0x000087FD File Offset: 0x000069FD
	public string DungeonName { get; set; }

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x060000A9 RID: 169 RVA: 0x00008806 File Offset: 0x00006A06
	// (set) Token: 0x060000AA RID: 170 RVA: 0x0000880E File Offset: 0x00006A0E
	public List<DungeonStep> DungeonSteps { get; set; }

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x060000AB RID: 171 RVA: 0x00008817 File Offset: 0x00006A17
	// (set) Token: 0x060000AC RID: 172 RVA: 0x0000881F File Offset: 0x00006A1F
	public List<PathFinder.OffMeshConnection> offMeshConnections { get; set; }

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x060000AD RID: 173 RVA: 0x00008828 File Offset: 0x00006A28
	// (set) Token: 0x060000AE RID: 174 RVA: 0x00008830 File Offset: 0x00006A30
	public List<Vector3> DeathRunPath { get; set; }

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x060000AF RID: 175 RVA: 0x00008839 File Offset: 0x00006A39
	// (set) Token: 0x060000B0 RID: 176 RVA: 0x00008841 File Offset: 0x00006A41
	public int FinalBossId { get; set; }

	// Token: 0x060000B1 RID: 177 RVA: 0x0000884A File Offset: 0x00006A4A
	public DungeonProfile()
	{
		this.Name = "";
		this.DungeonSteps = new List<DungeonStep>();
		this.offMeshConnections = new List<PathFinder.OffMeshConnection>();
		this.DeathRunPath = new List<Vector3>();
	}

	// Token: 0x04000056 RID: 86
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string A;

	// Token: 0x04000057 RID: 87
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string a;

	// Token: 0x04000058 RID: 88
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DungeonStep> A;

	// Token: 0x04000059 RID: 89
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<PathFinder.OffMeshConnection> A;

	// Token: 0x0400005A RID: 90
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Vector3> A;

	// Token: 0x0400005B RID: 91
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int A;
}
