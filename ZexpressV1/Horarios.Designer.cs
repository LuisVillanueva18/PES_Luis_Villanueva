namespace ZexpressV1
{
    partial class Horarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Horarios));
            this.btnRegresar = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.palettePrincipal = new Krypton.Toolkit.KryptonCustomPaletteBase(this.components);
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.btnMarcarEntrada = new Krypton.Toolkit.KryptonButton();
            this.btnMarcarSalida = new Krypton.Toolkit.KryptonButton();
            this.dgvTrabajadores = new Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuClientes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Editar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerarReporte = new Krypton.Toolkit.KryptonButton();
            this.dtpFechaReporte = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.dgvTrabajadoresActivos = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajadores)).BeginInit();
            this.contextMenuClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajadoresActivos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(12, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnRegresar.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnRegresar.OverrideDefault.Border.Color1 = System.Drawing.Color.White;
            this.btnRegresar.OverrideDefault.Border.Color2 = System.Drawing.Color.White;
            this.btnRegresar.Size = new System.Drawing.Size(42, 42);
            this.btnRegresar.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnRegresar.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnRegresar.StateCommon.Back.Image = global::ZexpressV1.Properties.Resources.flecha_izquierda__3_;
            this.btnRegresar.StateCommon.Back.ImageAlign = Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.btnRegresar.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.btnRegresar.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.btnRegresar.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.btnRegresar.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnRegresar.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnRegresar.StateTracking.Back.Image = global::ZexpressV1.Properties.Resources.flecha_izquierda__4_;
            this.btnRegresar.StateTracking.Border.Color1 = System.Drawing.Color.White;
            this.btnRegresar.StateTracking.Border.Color2 = System.Drawing.Color.White;
            this.btnRegresar.TabIndex = 36;
            this.btnRegresar.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnRegresar.Values.Text = "";
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(60, 12);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(137, 45);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonLabel5.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 35;
            this.kryptonLabel5.Values.Text = "Horarios";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LocalCustomPalette = this.palettePrincipal;
            this.kryptonLabel1.Location = new System.Drawing.Point(50, 67);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonLabel1.Size = new System.Drawing.Size(113, 30);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 37;
            this.kryptonLabel1.Values.Text = "Empleados";
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
            // kryptonLabel2
            // 
            this.kryptonLabel2.LocalCustomPalette = this.palettePrincipal;
            this.kryptonLabel2.Location = new System.Drawing.Point(691, 67);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonLabel2.Size = new System.Drawing.Size(117, 30);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonLabel2.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 38;
            this.kryptonLabel2.Values.Text = "Trabajando";
            // 
            // btnMarcarEntrada
            // 
            this.btnMarcarEntrada.Location = new System.Drawing.Point(640, 283);
            this.btnMarcarEntrada.Name = "btnMarcarEntrada";
            this.btnMarcarEntrada.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnMarcarEntrada.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnMarcarEntrada.OverrideDefault.Border.Color1 = System.Drawing.Color.White;
            this.btnMarcarEntrada.OverrideDefault.Border.Color2 = System.Drawing.Color.White;
            this.btnMarcarEntrada.Size = new System.Drawing.Size(42, 42);
            this.btnMarcarEntrada.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnMarcarEntrada.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnMarcarEntrada.StateCommon.Back.Image = global::ZexpressV1.Properties.Resources.EmpleadoS2;
            this.btnMarcarEntrada.StateCommon.Back.ImageAlign = Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.btnMarcarEntrada.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.btnMarcarEntrada.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.btnMarcarEntrada.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.btnMarcarEntrada.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnMarcarEntrada.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnMarcarEntrada.StateTracking.Back.Image = global::ZexpressV1.Properties.Resources.EmpleadoA2;
            this.btnMarcarEntrada.StateTracking.Border.Color1 = System.Drawing.Color.White;
            this.btnMarcarEntrada.StateTracking.Border.Color2 = System.Drawing.Color.White;
            this.btnMarcarEntrada.TabIndex = 43;
            this.btnMarcarEntrada.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnMarcarEntrada.Values.Text = "";
            this.btnMarcarEntrada.Click += new System.EventHandler(this.btnMarcarEntrada_Click_1);
            // 
            // btnMarcarSalida
            // 
            this.btnMarcarSalida.Location = new System.Drawing.Point(640, 356);
            this.btnMarcarSalida.Name = "btnMarcarSalida";
            this.btnMarcarSalida.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnMarcarSalida.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnMarcarSalida.OverrideDefault.Border.Color1 = System.Drawing.Color.White;
            this.btnMarcarSalida.OverrideDefault.Border.Color2 = System.Drawing.Color.White;
            this.btnMarcarSalida.Size = new System.Drawing.Size(42, 42);
            this.btnMarcarSalida.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnMarcarSalida.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnMarcarSalida.StateCommon.Back.Image = global::ZexpressV1.Properties.Resources.EmpleadoA11;
            this.btnMarcarSalida.StateCommon.Back.ImageAlign = Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.btnMarcarSalida.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.btnMarcarSalida.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.btnMarcarSalida.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.btnMarcarSalida.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.btnMarcarSalida.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnMarcarSalida.StateTracking.Back.Image = global::ZexpressV1.Properties.Resources.EmpleadoS1;
            this.btnMarcarSalida.StateTracking.Border.Color1 = System.Drawing.Color.White;
            this.btnMarcarSalida.StateTracking.Border.Color2 = System.Drawing.Color.White;
            this.btnMarcarSalida.TabIndex = 44;
            this.btnMarcarSalida.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnMarcarSalida.Values.Text = "";
            this.btnMarcarSalida.Click += new System.EventHandler(this.btnMarcarSalida_Click_1);
            // 
            // dgvTrabajadores
            // 
            this.dgvTrabajadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrabajadores.Location = new System.Drawing.Point(60, 118);
            this.dgvTrabajadores.Name = "dgvTrabajadores";
            this.dgvTrabajadores.Size = new System.Drawing.Size(551, 469);
            this.dgvTrabajadores.StateCommon.Background.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.Background.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvTrabajadores.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.White;
            this.dgvTrabajadores.StateCommon.DataCell.Content.Color2 = System.Drawing.Color.White;
            this.dgvTrabajadores.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTrabajadores.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvTrabajadores.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvTrabajadores.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTrabajadores.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.HeaderRow.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.HeaderRow.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.dgvTrabajadores.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.White;
            this.dgvTrabajadores.StateCommon.HeaderRow.Content.Color2 = System.Drawing.Color.White;
            this.dgvTrabajadores.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTrabajadores.TabIndex = 45;
            // 
            // contextMenuClientes
            // 
            this.contextMenuClientes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuClientes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Editar});
            this.contextMenuClientes.Name = "contextMenuTransacciones";
            this.contextMenuClientes.Size = new System.Drawing.Size(181, 26);
            // 
            // Editar
            // 
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(180, 22);
            this.Editar.Text = "toolStripMenuItem1";
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.ButtonStyle = Krypton.Toolkit.ButtonStyle.Alternate;
            this.btnGenerarReporte.LocalCustomPalette = this.palettePrincipal;
            this.btnGenerarReporte.Location = new System.Drawing.Point(1000, 61);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.btnGenerarReporte.Size = new System.Drawing.Size(90, 36);
            this.btnGenerarReporte.TabIndex = 48;
            this.btnGenerarReporte.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnGenerarReporte.Values.Text = "Reporte";
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporteHorarios_Click);
            // 
            // dtpFechaReporte
            // 
            this.dtpFechaReporte.DropButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.dtpFechaReporte.LocalCustomPalette = this.palettePrincipal;
            this.dtpFechaReporte.Location = new System.Drawing.Point(1096, 66);
            this.dtpFechaReporte.Name = "dtpFechaReporte";
            this.dtpFechaReporte.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.dtpFechaReporte.Size = new System.Drawing.Size(220, 31);
            this.dtpFechaReporte.TabIndex = 49;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(50, 103);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.OverrideDefault.Border.Rounding = 5F;
            this.kryptonButton1.Size = new System.Drawing.Size(584, 495);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.StateCommon.Border.Rounding = 5F;
            this.kryptonButton1.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(26)))));
            this.kryptonButton1.StateTracking.Border.Rounding = 5F;
            this.kryptonButton1.TabIndex = 50;
            this.kryptonButton1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Values.Text = "";
            // 
            // dgvTrabajadoresActivos
            // 
            this.dgvTrabajadoresActivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTrabajadoresActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrabajadoresActivos.Location = new System.Drawing.Point(704, 118);
            this.dgvTrabajadoresActivos.Name = "dgvTrabajadoresActivos";
            this.dgvTrabajadoresActivos.Size = new System.Drawing.Size(598, 469);
            this.dgvTrabajadoresActivos.StateCommon.Background.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.Background.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvTrabajadoresActivos.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.White;
            this.dgvTrabajadoresActivos.StateCommon.DataCell.Content.Color2 = System.Drawing.Color.White;
            this.dgvTrabajadoresActivos.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTrabajadoresActivos.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvTrabajadoresActivos.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvTrabajadoresActivos.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTrabajadoresActivos.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.HeaderRow.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.HeaderRow.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.dgvTrabajadoresActivos.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.White;
            this.dgvTrabajadoresActivos.StateCommon.HeaderRow.Content.Color2 = System.Drawing.Color.White;
            this.dgvTrabajadoresActivos.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTrabajadoresActivos.TabIndex = 52;
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(691, 103);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.OverrideDefault.Border.Rounding = 5F;
            this.kryptonButton3.Size = new System.Drawing.Size(625, 495);
            this.kryptonButton3.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.StateCommon.Border.Rounding = 5F;
            this.kryptonButton3.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(50)))));
            this.kryptonButton3.StateTracking.Border.Rounding = 5F;
            this.kryptonButton3.TabIndex = 53;
            this.kryptonButton3.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton3.Values.Text = "";
            // 
            // Horarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1369, 631);
            this.Controls.Add(this.dgvTrabajadoresActivos);
            this.Controls.Add(this.kryptonButton3);
            this.Controls.Add(this.dgvTrabajadores);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.dtpFechaReporte);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.btnMarcarSalida);
            this.Controls.Add(this.btnMarcarEntrada);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.kryptonLabel5);
            this.HeaderStyle = Krypton.Toolkit.HeaderStyle.Primary;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LocalCustomPalette = this.palettePrincipal;
            this.Name = "Horarios";
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Horarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajadores)).EndInit();
            this.contextMenuClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajadoresActivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonButton btnRegresar;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton btnMarcarEntrada;
        private Krypton.Toolkit.KryptonButton btnMarcarSalida;
        private Krypton.Toolkit.KryptonDataGridView dgvTrabajadores;
        private System.Windows.Forms.ContextMenuStrip contextMenuClientes;
        private System.Windows.Forms.ToolStripMenuItem Editar;
        private Krypton.Toolkit.KryptonButton btnGenerarReporte;
        private Krypton.Toolkit.KryptonDateTimePicker dtpFechaReporte;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonDataGridView dgvTrabajadoresActivos;
        private Krypton.Toolkit.KryptonButton kryptonButton3;
        private Krypton.Toolkit.KryptonCustomPaletteBase palettePrincipal;
    }
}