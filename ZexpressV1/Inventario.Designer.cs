namespace ZexpressV1
{
    partial class Inventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.palettePrincipal = new Krypton.Toolkit.KryptonCustomPaletteBase(this.components);
            this.contextMenuInventario = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Editar = new System.Windows.Forms.ToolStripMenuItem();
            this.Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvInventario = new Krypton.Toolkit.KryptonDataGridView();
            this.txtDescripcion = new Krypton.Toolkit.KryptonTextBox();
            this.txtUnidadesDisponibles = new Krypton.Toolkit.KryptonTextBox();
            this.txtLlenos = new Krypton.Toolkit.KryptonTextBox();
            this.txtVacios = new Krypton.Toolkit.KryptonTextBox();
            this.Descripcion = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.btnGuardar = new Krypton.Toolkit.KryptonButton();
            this.Atras = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.contextMenuInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // palettePrincipal
            // 
            this.palettePrincipal.ButtonSpecs.FormClose.Image = global::ZexpressV1.Properties.Resources.registro__1_;
            this.palettePrincipal.ButtonSpecs.FormMax.Image = global::ZexpressV1.Properties.Resources.registro__2_;
            this.palettePrincipal.ButtonSpecs.FormMin.Image = global::ZexpressV1.Properties.Resources.registro__3_;
            this.palettePrincipal.ButtonStyles.ButtonAlternate.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonAlternate.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonAlternate.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Border.Rounding = 5F;
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(60)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(60)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(60)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(60)))));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonAlternate.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.ButtonStyles.ButtonLowProfile.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonLowProfile.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.ButtonStyles.ButtonStandalone.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCheckedTracking.Back.Color1 = System.Drawing.Color.Silver;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCheckedTracking.Back.Color2 = System.Drawing.Color.Silver;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCheckedTracking.Border.Color1 = System.Drawing.Color.Silver;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCheckedTracking.Border.Color2 = System.Drawing.Color.Silver;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateCommon.Content.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateTracking.Back.Color1 = System.Drawing.Color.Silver;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateTracking.Back.Color2 = System.Drawing.Color.Silver;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateTracking.Border.Color1 = System.Drawing.Color.Silver;
            this.palettePrincipal.ButtonStyles.ButtonStandalone.StateTracking.Border.Color2 = System.Drawing.Color.Silver;
            this.palettePrincipal.Common.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.Common.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.Common.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.Common.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.Common.StateCommon.Border.Rounding = 5F;
            this.palettePrincipal.Common.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.Common.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.Common.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.palettePrincipal.FormStyles.FormMain.StateCommon.Border.Rounding = 5F;
            this.palettePrincipal.FormStyles.FormMain.StateCommon.Border.Width = 1;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.Background.ColorAlign = Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Back.ColorAlign = Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Content.Color2 = System.Drawing.Color.Black;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(1);
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Gainsboro;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.Gainsboro;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderRow.Border.Color1 = System.Drawing.Color.Gainsboro;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderRow.Border.Color2 = System.Drawing.Color.Gainsboro;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Color2 = System.Drawing.Color.Black;
            this.palettePrincipal.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.GridStyles.GridCommon.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.Silver;
            this.palettePrincipal.GridStyles.GridCommon.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.Silver;
            this.palettePrincipal.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = System.Drawing.Color.LightGray;
            this.palettePrincipal.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = System.Drawing.Color.Silver;
            this.palettePrincipal.HeaderStyles.HeaderCommon.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.palettePrincipal.HeaderStyles.HeaderCommon.StateCommon.Border.Color2 = System.Drawing.Color.LightGray;
            this.palettePrincipal.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.HeaderStyles.HeaderForm.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.HeaderStyles.HeaderForm.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.HeaderStyles.HeaderPrimary.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.HeaderStyles.HeaderPrimary.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.HeaderStyles.HeaderPrimary.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.HeaderStyles.HeaderPrimary.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.HeaderStyles.HeaderPrimary.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.palettePrincipal.LabelStyles.LabelNormalPanel.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.LabelStyles.LabelNormalPanel.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.palettePrincipal.LabelStyles.LabelNormalPanel.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettePrincipal.PanelStyles.PanelClient.StateCommon.Color1 = System.Drawing.Color.White;
            this.palettePrincipal.PanelStyles.PanelClient.StateCommon.Color2 = System.Drawing.Color.White;
            this.palettePrincipal.UseThemeFormChromeBorderWidth = Krypton.Toolkit.InheritBool.True;
            // 
            // contextMenuInventario
            // 
            this.contextMenuInventario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Editar,
            this.Eliminar});
            this.contextMenuInventario.Name = "contextMenuTransacciones";
            this.contextMenuInventario.Size = new System.Drawing.Size(181, 48);
            // 
            // Editar
            // 
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(180, 22);
            this.Editar.Text = "toolStripMenuItem1";
            // 
            // Eliminar
            // 
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(180, 22);
            this.Eliminar.Text = "toolStripMenuItem2";
            // 
            // dgvInventario
            // 
            this.dgvInventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(469, 112);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(699, 433);
            this.dgvInventario.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvInventario.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvInventario.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvInventario.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvInventario.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgvInventario.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.DataCell.Content.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInventario.StateCommon.DataCell.Content.Padding = new System.Windows.Forms.Padding(1);
            this.dgvInventario.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
            this.dgvInventario.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White;
            this.dgvInventario.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInventario.StateCommon.HeaderColumn.Content.Padding = new System.Windows.Forms.Padding(1);
            this.dgvInventario.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.White;
            this.dgvInventario.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.White;
            this.dgvInventario.StateCommon.HeaderRow.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.HeaderRow.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.HeaderRow.Content.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvInventario.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInventario.TabIndex = 31;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.LocalCustomPalette = this.palettePrincipal;
            this.txtDescripcion.Location = new System.Drawing.Point(186, 112);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.txtDescripcion.Size = new System.Drawing.Size(234, 33);
            this.txtDescripcion.TabIndex = 32;
            // 
            // txtUnidadesDisponibles
            // 
            this.txtUnidadesDisponibles.LocalCustomPalette = this.palettePrincipal;
            this.txtUnidadesDisponibles.Location = new System.Drawing.Point(186, 172);
            this.txtUnidadesDisponibles.Name = "txtUnidadesDisponibles";
            this.txtUnidadesDisponibles.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.txtUnidadesDisponibles.Size = new System.Drawing.Size(234, 33);
            this.txtUnidadesDisponibles.TabIndex = 33;
            // 
            // txtLlenos
            // 
            this.txtLlenos.LocalCustomPalette = this.palettePrincipal;
            this.txtLlenos.Location = new System.Drawing.Point(186, 228);
            this.txtLlenos.Name = "txtLlenos";
            this.txtLlenos.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.txtLlenos.Size = new System.Drawing.Size(234, 33);
            this.txtLlenos.TabIndex = 34;
            // 
            // txtVacios
            // 
            this.txtVacios.LocalCustomPalette = this.palettePrincipal;
            this.txtVacios.Location = new System.Drawing.Point(186, 280);
            this.txtVacios.Name = "txtVacios";
            this.txtVacios.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.txtVacios.Size = new System.Drawing.Size(234, 33);
            this.txtVacios.TabIndex = 35;
            // 
            // Descripcion
            // 
            this.Descripcion.LocalCustomPalette = this.palettePrincipal;
            this.Descripcion.Location = new System.Drawing.Point(60, 115);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.Descripcion.Size = new System.Drawing.Size(120, 30);
            this.Descripcion.TabIndex = 36;
            this.Descripcion.Values.Text = "Descripción";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LocalCustomPalette = this.palettePrincipal;
            this.kryptonLabel2.Location = new System.Drawing.Point(60, 172);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonLabel2.Size = new System.Drawing.Size(98, 30);
            this.kryptonLabel2.TabIndex = 37;
            this.kryptonLabel2.Values.Text = "Unidades";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LocalCustomPalette = this.palettePrincipal;
            this.kryptonLabel3.Location = new System.Drawing.Point(60, 228);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonLabel3.Size = new System.Drawing.Size(70, 30);
            this.kryptonLabel3.TabIndex = 38;
            this.kryptonLabel3.Values.Text = "Llenas";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LocalCustomPalette = this.palettePrincipal;
            this.kryptonLabel4.Location = new System.Drawing.Point(60, 280);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonLabel4.Size = new System.Drawing.Size(63, 30);
            this.kryptonLabel4.TabIndex = 39;
            this.kryptonLabel4.Values.Text = "Vacio";
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = Krypton.Toolkit.ButtonStyle.Alternate;
            this.btnGuardar.LocalCustomPalette = this.palettePrincipal;
            this.btnGuardar.Location = new System.Drawing.Point(60, 370);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.btnGuardar.Size = new System.Drawing.Size(98, 56);
            this.btnGuardar.TabIndex = 40;
            this.btnGuardar.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnGuardar.Values.Text = "Aceptar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Atras
            // 
            this.Atras.Location = new System.Drawing.Point(12, 12);
            this.Atras.Name = "Atras";
            this.Atras.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.Atras.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.Atras.OverrideDefault.Border.Color1 = System.Drawing.Color.White;
            this.Atras.OverrideDefault.Border.Color2 = System.Drawing.Color.White;
            this.Atras.Size = new System.Drawing.Size(42, 42);
            this.Atras.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.Atras.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.Atras.StateCommon.Back.Image = global::ZexpressV1.Properties.Resources.flecha_izquierda__3_;
            this.Atras.StateCommon.Back.ImageAlign = Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.Atras.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.Atras.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.Atras.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.Atras.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.Atras.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.Atras.StateTracking.Back.Image = global::ZexpressV1.Properties.Resources.flecha_izquierda__4_;
            this.Atras.StateTracking.Border.Color1 = System.Drawing.Color.White;
            this.Atras.StateTracking.Border.Color2 = System.Drawing.Color.White;
            this.Atras.TabIndex = 42;
            this.Atras.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.Atras.Values.Text = "";
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(60, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(203, 56);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 41;
            this.kryptonLabel1.Values.Text = "Inventario";
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 609);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.Descripcion);
            this.Controls.Add(this.txtVacios);
            this.Controls.Add(this.txtLlenos);
            this.Controls.Add(this.txtUnidadesDisponibles);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.dgvInventario);
            this.HeaderStyle = Krypton.Toolkit.HeaderStyle.Primary;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LocalCustomPalette = this.palettePrincipal;
            this.Name = "Inventario";
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zexpress";
            this.Load += new System.EventHandler(this.Inventario_Load);
            this.contextMenuInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonCustomPaletteBase palettePrincipal;
        private System.Windows.Forms.ContextMenuStrip contextMenuInventario;
        private System.Windows.Forms.ToolStripMenuItem Editar;
        private System.Windows.Forms.ToolStripMenuItem Eliminar;
        private Krypton.Toolkit.KryptonDataGridView dgvInventario;
        private Krypton.Toolkit.KryptonTextBox txtDescripcion;
        private Krypton.Toolkit.KryptonTextBox txtUnidadesDisponibles;
        private Krypton.Toolkit.KryptonTextBox txtLlenos;
        private Krypton.Toolkit.KryptonTextBox txtVacios;
        private Krypton.Toolkit.KryptonLabel Descripcion;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonButton btnGuardar;
        private Krypton.Toolkit.KryptonButton Atras;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}