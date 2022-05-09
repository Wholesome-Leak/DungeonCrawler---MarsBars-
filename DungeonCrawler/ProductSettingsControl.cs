using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MahApps.Metro.Controls;

namespace DungeonCrawler
{
	// Token: 0x02000061 RID: 97
	public class ProductSettingsControl : UserControl, IComponentConnector
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002BE RID: 702 RVA: 0x000094F0 File Offset: 0x000076F0
		// (set) Token: 0x060002BF RID: 703 RVA: 0x000094F8 File Offset: 0x000076F8
		public ObservableCollection<string> pmCollection { get; set; }

		// Token: 0x060002C0 RID: 704 RVA: 0x0001A088 File Offset: 0x00018288
		public ProductSettingsControl()
		{
			this.InitializeComponent();
			base.DataContext = DungeonCrawlerSettings.CurrentSetting;
			switch (DungeonCrawlerSettings.CurrentSetting.Role)
			{
			case LFGRole.Tank:
				this.B.IsChecked = new bool?(true);
				break;
			case LFGRole.DPS:
				this.A.IsChecked = new bool?(true);
				break;
			case LFGRole.Heal:
				this.a.IsChecked = new bool?(true);
				break;
			}
			this.pmCollection = new ObservableCollection<string>(DungeonCrawlerSettings.CurrentSetting.PlayersToInvite);
			this.A.ItemsSource = this.pmCollection;
			this.A.Click += this.c;
			this.a.Click += this.D;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00009501 File Offset: 0x00007701
		private void A(object sender, RoutedEventArgs e)
		{
			DungeonCrawlerSettings.CurrentSetting.Role = LFGRole.DPS;
			DungeonCrawlerSettings.CurrentSetting.Save();
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00009519 File Offset: 0x00007719
		private void a(object sender, RoutedEventArgs e)
		{
			DungeonCrawlerSettings.CurrentSetting.Role = LFGRole.Heal;
			DungeonCrawlerSettings.CurrentSetting.Save();
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00009531 File Offset: 0x00007731
		private void B(object sender, RoutedEventArgs e)
		{
			DungeonCrawlerSettings.CurrentSetting.Role = LFGRole.Tank;
			DungeonCrawlerSettings.CurrentSetting.Save();
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x000094CB File Offset: 0x000076CB
		private void A(object sender, KeyEventArgs e)
		{
			DungeonCrawlerSettings.CurrentSetting.Save();
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x000094CB File Offset: 0x000076CB
		private void A(object sender, MouseEventArgs e)
		{
			DungeonCrawlerSettings.CurrentSetting.Save();
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0001A15C File Offset: 0x0001835C
		private void b(object sender, RoutedEventArgs e)
		{
			ProfileEditor profileEditor = new ProfileEditor();
			profileEditor.ShowDialog();
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0001A178 File Offset: 0x00018378
		private void C(object sender, RoutedEventArgs e)
		{
			AdvancedOptions advancedOptions = new AdvancedOptions();
			advancedOptions.ShowDialog();
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0001A194 File Offset: 0x00018394
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this.A)
			{
				this.A = true;
				Uri resourceLocator = new Uri("/DungeonCrawler;component/gui/productsettingscontrol.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0001A1C4 File Offset: 0x000183C4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.A(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((ProductSettingsControl)target).KeyUp += this.A;
				((ProductSettingsControl)target).MouseLeave += this.A;
				break;
			case 2:
				this.A = (RadioButton)target;
				this.A.Checked += this.A;
				break;
			case 3:
				this.a = (RadioButton)target;
				this.a.Checked += this.a;
				break;
			case 4:
				this.B = (RadioButton)target;
				this.B.Checked += this.B;
				break;
			case 5:
				this.A = (ToggleSwitch)target;
				break;
			case 6:
				this.a = (ToggleSwitch)target;
				break;
			case 7:
				this.B = (ToggleSwitch)target;
				break;
			case 8:
				this.A = (GroupBox)target;
				break;
			case 9:
				this.A = (StackPanel)target;
				break;
			case 10:
				this.A = (DataGrid)target;
				break;
			case 11:
				this.A = (Button)target;
				break;
			case 12:
				this.a = (Button)target;
				break;
			case 13:
				((Button)target).Click += this.b;
				break;
			case 14:
				this.B = (Button)target;
				this.B.Click += this.C;
				break;
			default:
				this.A = true;
				break;
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0001A384 File Offset: 0x00018584
		[DebuggerStepThrough]
		[CompilerGenerated]
		private void c(object sender, RoutedEventArgs e)
		{
			ProductSettingsControl.A a = new ProductSettingsControl.A();
			a.A = this;
			a.A = sender;
			a.A = e;
			a.A = AsyncVoidMethodBuilder.Create();
			a.A = -1;
			a.A.Start<ProductSettingsControl.A>(ref a);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0001A3CC File Offset: 0x000185CC
		[CompilerGenerated]
		private void D(object sender, RoutedEventArgs e)
		{
			if (this.A.SelectedIndex >= 0)
			{
				this.pmCollection.Remove(this.A.SelectedValue.ToString());
				DungeonCrawlerSettings.CurrentSetting.PlayersToInvite = this.pmCollection.ToList<string>();
			}
		}

		// Token: 0x040001BD RID: 445
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<string> A;

		// Token: 0x040001BE RID: 446
		internal RadioButton A;

		// Token: 0x040001BF RID: 447
		internal RadioButton a;

		// Token: 0x040001C0 RID: 448
		internal RadioButton B;

		// Token: 0x040001C1 RID: 449
		internal ToggleSwitch A;

		// Token: 0x040001C2 RID: 450
		internal ToggleSwitch a;

		// Token: 0x040001C3 RID: 451
		internal ToggleSwitch B;

		// Token: 0x040001C4 RID: 452
		internal GroupBox A;

		// Token: 0x040001C5 RID: 453
		internal StackPanel A;

		// Token: 0x040001C6 RID: 454
		internal DataGrid A;

		// Token: 0x040001C7 RID: 455
		internal Button A;

		// Token: 0x040001C8 RID: 456
		internal Button a;

		// Token: 0x040001C9 RID: 457
		internal Button B;

		// Token: 0x040001CA RID: 458
		private bool A;
	}
}
