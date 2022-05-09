using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using MahApps.Metro.Controls;

namespace DungeonCrawler
{
	// Token: 0x0200005C RID: 92
	public class AdvancedOptions : MetroWindow, IComponentConnector
	{
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x00009485 File Offset: 0x00007685
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x0000948D File Offset: 0x0000768D
		public ObservableCollection<string> SpellsCollection { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00009496 File Offset: 0x00007696
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x0000949E File Offset: 0x0000769E
		public ObservableCollection<int> LevelsCollection { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x000094A7 File Offset: 0x000076A7
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x000094AF File Offset: 0x000076AF
		public ObservableCollection<QueueDungeon> DungeonsCollection { get; set; }

		// Token: 0x060002A9 RID: 681 RVA: 0x000197AC File Offset: 0x000179AC
		public AdvancedOptions()
		{
			this.InitializeComponent();
			using (List<Dungeon>.Enumerator enumerator = e.A.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AdvancedOptions.A a = new AdvancedOptions.A();
					a.A = enumerator.Current;
					if (DungeonCrawlerSettings.CurrentSetting.SpecificDungeons.Count(new Func<QueueDungeon, bool>(a.A)) == 0)
					{
						DungeonCrawlerSettings.CurrentSetting.SpecificDungeons.Add(new QueueDungeon
						{
							Name = a.A.Name,
							MinLevel = 0,
							MaxLevel = 80,
							Enabled = false,
							DungeonId = a.A.DungeonId
						});
					}
				}
			}
			DungeonCrawlerSettings.CurrentSetting.Save();
			base.DataContext = DungeonCrawlerSettings.CurrentSetting;
			this.SpellsCollection = new ObservableCollection<string>(DungeonCrawlerSettings.CurrentSetting.SpellsToBuy);
			this.A.ItemsSource = this.SpellsCollection;
			this.LevelsCollection = new ObservableCollection<int>(DungeonCrawlerSettings.CurrentSetting.LevelsToTrain);
			this.a.ItemsSource = this.LevelsCollection;
			this.DungeonsCollection = new ObservableCollection<QueueDungeon>(DungeonCrawlerSettings.CurrentSetting.SpecificDungeons);
			this.B.ItemsSource = this.DungeonsCollection;
			this.A.Click += this.a;
			this.B.Click += this.B;
			this.a.Click += this.b;
			this.b.Click += this.C;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000094B8 File Offset: 0x000076B8
		private void A(object sender, RoutedEventArgs e)
		{
			DungeonCrawlerSettings.CurrentSetting.Save();
			base.Close();
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000094CB File Offset: 0x000076CB
		private void A(object sender, EventArgs e)
		{
			DungeonCrawlerSettings.CurrentSetting.Save();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00019964 File Offset: 0x00017B64
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.A)
			{
				this.A = true;
				Uri resourceLocator = new Uri("/DungeonCrawler;component/gui/advancedoptions.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00019994 File Offset: 0x00017B94
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.A(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((AdvancedOptions)target).Closed += this.A;
				break;
			case 2:
				this.A = (DataGrid)target;
				break;
			case 3:
				this.A = (Button)target;
				break;
			case 4:
				this.a = (Button)target;
				break;
			case 5:
				this.a = (DataGrid)target;
				break;
			case 6:
				this.B = (Button)target;
				break;
			case 7:
				this.b = (Button)target;
				break;
			case 8:
				this.B = (DataGrid)target;
				break;
			case 9:
				this.A = (ToggleSwitch)target;
				break;
			case 10:
				((Button)target).Click += this.A;
				break;
			default:
				this.A = true;
				break;
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00019A84 File Offset: 0x00017C84
		[DebuggerStepThrough]
		[CompilerGenerated]
		private void a(object sender, RoutedEventArgs e)
		{
			AdvancedOptions.a a = new AdvancedOptions.a();
			a.A = this;
			a.A = sender;
			a.A = e;
			a.A = AsyncVoidMethodBuilder.Create();
			a.A = -1;
			a.A.Start<AdvancedOptions.a>(ref a);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00019ACC File Offset: 0x00017CCC
		[DebuggerStepThrough]
		[CompilerGenerated]
		private void B(object sender, RoutedEventArgs e)
		{
			AdvancedOptions.B b = new AdvancedOptions.B();
			b.A = this;
			b.A = sender;
			b.A = e;
			b.A = AsyncVoidMethodBuilder.Create();
			b.A = -1;
			b.A.Start<AdvancedOptions.B>(ref b);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00019B14 File Offset: 0x00017D14
		[CompilerGenerated]
		private void b(object sender, RoutedEventArgs e)
		{
			if (this.A.SelectedIndex >= 0)
			{
				this.SpellsCollection.Remove(this.A.SelectedValue.ToString());
				DungeonCrawlerSettings.CurrentSetting.SpellsToBuy = this.SpellsCollection.ToList<string>();
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00019B68 File Offset: 0x00017D68
		[CompilerGenerated]
		private void C(object sender, RoutedEventArgs e)
		{
			if (this.a.SelectedIndex >= 0)
			{
				this.LevelsCollection.Remove(int.Parse(this.a.SelectedValue.ToString()));
				DungeonCrawlerSettings.CurrentSetting.LevelsToTrain = this.LevelsCollection.ToList<int>();
			}
		}

		// Token: 0x04000197 RID: 407
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<string> A;

		// Token: 0x04000198 RID: 408
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<int> A;

		// Token: 0x04000199 RID: 409
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<QueueDungeon> A;

		// Token: 0x0400019A RID: 410
		internal DataGrid A;

		// Token: 0x0400019B RID: 411
		internal Button A;

		// Token: 0x0400019C RID: 412
		internal Button a;

		// Token: 0x0400019D RID: 413
		internal DataGrid a;

		// Token: 0x0400019E RID: 414
		internal Button B;

		// Token: 0x0400019F RID: 415
		internal Button b;

		// Token: 0x040001A0 RID: 416
		internal DataGrid B;

		// Token: 0x040001A1 RID: 417
		internal ToggleSwitch A;

		// Token: 0x040001A2 RID: 418
		private bool A;

		// Token: 0x0200005D RID: 93
		[CompilerGenerated]
		private sealed class A
		{
			// Token: 0x060002B3 RID: 691 RVA: 0x000094D8 File Offset: 0x000076D8
			internal bool A(QueueDungeon queueDungeon_0)
			{
				return queueDungeon_0.Name == this.A.Name;
			}

			// Token: 0x040001A3 RID: 419
			public Dungeon A;
		}
	}
}
