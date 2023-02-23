namespace Murray.Vistas
{
    partial class Principal
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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges9 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges10 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation2 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.pnlBarraSup = new System.Windows.Forms.Panel();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbRestaurar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.pnlIzq = new System.Windows.Forms.Panel();
            this.gradientPanelIzq = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.btnSeguridad = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnProductos = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnCompras = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnVentas = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnContactos = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.separadorLogo = new Bunifu.UI.WinForms.BunifuSeparator();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlSeparadorMenu = new System.Windows.Forms.Panel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.menuTransitionMostrar = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.pnlBarraSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            this.pnlIzq.SuspendLayout();
            this.gradientPanelIzq.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBarraSup
            // 
            this.pnlBarraSup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.pnlBarraSup.Controls.Add(this.lblMenu);
            this.pnlBarraSup.Controls.Add(this.pbMenu);
            this.pnlBarraSup.Controls.Add(this.pbMinimizar);
            this.pnlBarraSup.Controls.Add(this.pbRestaurar);
            this.pnlBarraSup.Controls.Add(this.pbMaximizar);
            this.pnlBarraSup.Controls.Add(this.pbCerrar);
            this.menuTransitionMostrar.SetDecoration(this.pnlBarraSup, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnlBarraSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraSup.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraSup.Name = "pnlBarraSup";
            this.pnlBarraSup.Size = new System.Drawing.Size(1067, 25);
            this.pnlBarraSup.TabIndex = 0;
            this.pnlBarraSup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            // 
            // lblMenu
            // 
            this.menuTransitionMostrar.SetDecoration(this.lblMenu, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.White;
            this.lblMenu.Location = new System.Drawing.Point(47, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(64, 25);
            this.lblMenu.TabIndex = 5;
            this.lblMenu.Text = "Menú";
            this.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbMenu
            // 
            this.pbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuTransitionMostrar.SetDecoration(this.pbMenu, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbMenu.Image = global::Murray.Properties.Resources.menu;
            this.pbMenu.Location = new System.Drawing.Point(0, 0);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(47, 25);
            this.pbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMenu.TabIndex = 4;
            this.pbMenu.TabStop = false;
            this.pbMenu.Click += new System.EventHandler(this.ActivarMenu);
            // 
            // pbMinimizar
            // 
            this.menuTransitionMostrar.SetDecoration(this.pbMinimizar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbMinimizar.Image = global::Murray.Properties.Resources.substract;
            this.pbMinimizar.Location = new System.Drawing.Point(879, 0);
            this.pbMinimizar.Name = "pbMinimizar";
            this.pbMinimizar.Size = new System.Drawing.Size(47, 25);
            this.pbMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMinimizar.TabIndex = 3;
            this.pbMinimizar.TabStop = false;
            this.pbMinimizar.Click += new System.EventHandler(this.Minimizar);
            this.pbMinimizar.MouseLeave += new System.EventHandler(this.Botones_MouseLeave);
            this.pbMinimizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Botones_MouseMove);
            // 
            // pbRestaurar
            // 
            this.menuTransitionMostrar.SetDecoration(this.pbRestaurar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbRestaurar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbRestaurar.Image = global::Murray.Properties.Resources.squares;
            this.pbRestaurar.Location = new System.Drawing.Point(926, 0);
            this.pbRestaurar.Name = "pbRestaurar";
            this.pbRestaurar.Size = new System.Drawing.Size(47, 25);
            this.pbRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRestaurar.TabIndex = 2;
            this.pbRestaurar.TabStop = false;
            this.pbRestaurar.Click += new System.EventHandler(this.Restaurar);
            this.pbRestaurar.MouseLeave += new System.EventHandler(this.Botones_MouseLeave);
            this.pbRestaurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Botones_MouseMove);
            // 
            // pbMaximizar
            // 
            this.menuTransitionMostrar.SetDecoration(this.pbMaximizar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbMaximizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbMaximizar.Image = global::Murray.Properties.Resources.square;
            this.pbMaximizar.Location = new System.Drawing.Point(973, 0);
            this.pbMaximizar.Name = "pbMaximizar";
            this.pbMaximizar.Size = new System.Drawing.Size(47, 25);
            this.pbMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMaximizar.TabIndex = 1;
            this.pbMaximizar.TabStop = false;
            this.pbMaximizar.Click += new System.EventHandler(this.Maximizar);
            this.pbMaximizar.MouseLeave += new System.EventHandler(this.Botones_MouseLeave);
            this.pbMaximizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Botones_MouseMove);
            // 
            // pbCerrar
            // 
            this.menuTransitionMostrar.SetDecoration(this.pbCerrar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbCerrar.Image = global::Murray.Properties.Resources.close;
            this.pbCerrar.Location = new System.Drawing.Point(1020, 0);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(47, 25);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCerrar.TabIndex = 0;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.Salir);
            this.pbCerrar.MouseLeave += new System.EventHandler(this.Botones_MouseLeave);
            this.pbCerrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Botones_MouseMove);
            // 
            // pnlIzq
            // 
            this.pnlIzq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.pnlIzq.Controls.Add(this.gradientPanelIzq);
            this.menuTransitionMostrar.SetDecoration(this.pnlIzq, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnlIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzq.Location = new System.Drawing.Point(0, 25);
            this.pnlIzq.Name = "pnlIzq";
            this.pnlIzq.Size = new System.Drawing.Size(200, 504);
            this.pnlIzq.TabIndex = 1;
            // 
            // gradientPanelIzq
            // 
            this.gradientPanelIzq.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanelIzq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gradientPanelIzq.BackgroundImage")));
            this.gradientPanelIzq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gradientPanelIzq.BorderRadius = 1;
            this.gradientPanelIzq.Controls.Add(this.btnSeguridad);
            this.gradientPanelIzq.Controls.Add(this.btnProductos);
            this.gradientPanelIzq.Controls.Add(this.btnCompras);
            this.gradientPanelIzq.Controls.Add(this.btnVentas);
            this.gradientPanelIzq.Controls.Add(this.btnContactos);
            this.gradientPanelIzq.Controls.Add(this.separadorLogo);
            this.gradientPanelIzq.Controls.Add(this.pnlTitulo);
            this.gradientPanelIzq.Controls.Add(this.pnlSeparadorMenu);
            this.menuTransitionMostrar.SetDecoration(this.gradientPanelIzq, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.gradientPanelIzq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanelIzq.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(22)))), ((int)(((byte)(25)))));
            this.gradientPanelIzq.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(110)))));
            this.gradientPanelIzq.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(136)))));
            this.gradientPanelIzq.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(161)))));
            this.gradientPanelIzq.Location = new System.Drawing.Point(0, 0);
            this.gradientPanelIzq.Name = "gradientPanelIzq";
            this.gradientPanelIzq.Quality = 10;
            this.gradientPanelIzq.Size = new System.Drawing.Size(200, 504);
            this.gradientPanelIzq.TabIndex = 0;
            // 
            // btnSeguridad
            // 
            this.btnSeguridad.AllowAnimations = true;
            this.btnSeguridad.AllowMouseEffects = true;
            this.btnSeguridad.AllowToggling = false;
            this.btnSeguridad.AnimationSpeed = 200;
            this.btnSeguridad.AutoGenerateColors = false;
            this.btnSeguridad.AutoRoundBorders = false;
            this.btnSeguridad.AutoSizeLeftIcon = true;
            this.btnSeguridad.AutoSizeRightIcon = true;
            this.btnSeguridad.BackColor = System.Drawing.Color.Transparent;
            this.btnSeguridad.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnSeguridad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSeguridad.BackgroundImage")));
            this.btnSeguridad.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSeguridad.ButtonText = "Usuarios";
            this.btnSeguridad.ButtonTextMarginLeft = 0;
            this.btnSeguridad.ColorContrastOnClick = 45;
            this.btnSeguridad.ColorContrastOnHover = 45;
            this.btnSeguridad.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.btnSeguridad.CustomizableEdges = borderEdges6;
            this.menuTransitionMostrar.SetDecoration(this.btnSeguridad, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnSeguridad.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSeguridad.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSeguridad.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnSeguridad.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSeguridad.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSeguridad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguridad.ForeColor = System.Drawing.Color.White;
            this.btnSeguridad.IconLeft = global::Murray.Properties.Resources.security;
            this.btnSeguridad.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeguridad.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSeguridad.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSeguridad.IconMarginLeft = 11;
            this.btnSeguridad.IconPadding = 5;
            this.btnSeguridad.IconRight = null;
            this.btnSeguridad.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeguridad.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSeguridad.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSeguridad.IconSize = 40;
            this.btnSeguridad.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnSeguridad.IdleBorderRadius = 0;
            this.btnSeguridad.IdleBorderThickness = 0;
            this.btnSeguridad.IdleFillColor = System.Drawing.Color.Empty;
            this.btnSeguridad.IdleIconLeftImage = global::Murray.Properties.Resources.security;
            this.btnSeguridad.IdleIconRightImage = null;
            this.btnSeguridad.IndicateFocus = false;
            this.btnSeguridad.Location = new System.Drawing.Point(0, 204);
            this.btnSeguridad.Name = "btnSeguridad";
            this.btnSeguridad.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSeguridad.OnDisabledState.BorderRadius = 1;
            this.btnSeguridad.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSeguridad.OnDisabledState.BorderThickness = 1;
            this.btnSeguridad.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSeguridad.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSeguridad.OnDisabledState.IconLeftImage = null;
            this.btnSeguridad.OnDisabledState.IconRightImage = null;
            this.btnSeguridad.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnSeguridad.onHoverState.BorderRadius = 1;
            this.btnSeguridad.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSeguridad.onHoverState.BorderThickness = 1;
            this.btnSeguridad.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnSeguridad.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSeguridad.onHoverState.IconLeftImage = null;
            this.btnSeguridad.onHoverState.IconRightImage = null;
            this.btnSeguridad.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSeguridad.OnIdleState.BorderRadius = 1;
            this.btnSeguridad.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSeguridad.OnIdleState.BorderThickness = 1;
            this.btnSeguridad.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.btnSeguridad.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSeguridad.OnIdleState.IconLeftImage = global::Murray.Properties.Resources.security;
            this.btnSeguridad.OnIdleState.IconRightImage = null;
            this.btnSeguridad.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnSeguridad.OnPressedState.BorderRadius = 1;
            this.btnSeguridad.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSeguridad.OnPressedState.BorderThickness = 1;
            this.btnSeguridad.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnSeguridad.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSeguridad.OnPressedState.IconLeftImage = null;
            this.btnSeguridad.OnPressedState.IconRightImage = null;
            this.btnSeguridad.Size = new System.Drawing.Size(200, 39);
            this.btnSeguridad.TabIndex = 9;
            this.btnSeguridad.Tag = "Seguridad";
            this.btnSeguridad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSeguridad.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSeguridad.TextMarginLeft = 0;
            this.btnSeguridad.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSeguridad.UseDefaultRadiusAndThickness = true;
            this.btnSeguridad.Click += new System.EventHandler(this.BotonMenu_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.AllowAnimations = true;
            this.btnProductos.AllowMouseEffects = true;
            this.btnProductos.AllowToggling = false;
            this.btnProductos.AnimationSpeed = 200;
            this.btnProductos.AutoGenerateColors = false;
            this.btnProductos.AutoRoundBorders = false;
            this.btnProductos.AutoSizeLeftIcon = true;
            this.btnProductos.AutoSizeRightIcon = true;
            this.btnProductos.BackColor = System.Drawing.Color.Transparent;
            this.btnProductos.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnProductos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProductos.BackgroundImage")));
            this.btnProductos.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnProductos.ButtonText = "Productos";
            this.btnProductos.ButtonTextMarginLeft = 0;
            this.btnProductos.ColorContrastOnClick = 45;
            this.btnProductos.ColorContrastOnHover = 45;
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges7.BottomLeft = true;
            borderEdges7.BottomRight = true;
            borderEdges7.TopLeft = true;
            borderEdges7.TopRight = true;
            this.btnProductos.CustomizableEdges = borderEdges7;
            this.menuTransitionMostrar.SetDecoration(this.btnProductos, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnProductos.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProductos.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnProductos.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnProductos.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.IconLeft = global::Murray.Properties.Resources.box;
            this.btnProductos.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnProductos.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnProductos.IconMarginLeft = 11;
            this.btnProductos.IconPadding = 5;
            this.btnProductos.IconRight = null;
            this.btnProductos.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnProductos.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnProductos.IconSize = 40;
            this.btnProductos.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnProductos.IdleBorderRadius = 0;
            this.btnProductos.IdleBorderThickness = 0;
            this.btnProductos.IdleFillColor = System.Drawing.Color.Empty;
            this.btnProductos.IdleIconLeftImage = global::Murray.Properties.Resources.box;
            this.btnProductos.IdleIconRightImage = null;
            this.btnProductos.IndicateFocus = false;
            this.btnProductos.Location = new System.Drawing.Point(0, 165);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnProductos.OnDisabledState.BorderRadius = 1;
            this.btnProductos.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnProductos.OnDisabledState.BorderThickness = 1;
            this.btnProductos.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnProductos.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnProductos.OnDisabledState.IconLeftImage = null;
            this.btnProductos.OnDisabledState.IconRightImage = null;
            this.btnProductos.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnProductos.onHoverState.BorderRadius = 1;
            this.btnProductos.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnProductos.onHoverState.BorderThickness = 1;
            this.btnProductos.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnProductos.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnProductos.onHoverState.IconLeftImage = null;
            this.btnProductos.onHoverState.IconRightImage = null;
            this.btnProductos.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnProductos.OnIdleState.BorderRadius = 1;
            this.btnProductos.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnProductos.OnIdleState.BorderThickness = 1;
            this.btnProductos.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.btnProductos.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnProductos.OnIdleState.IconLeftImage = global::Murray.Properties.Resources.box;
            this.btnProductos.OnIdleState.IconRightImage = null;
            this.btnProductos.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnProductos.OnPressedState.BorderRadius = 1;
            this.btnProductos.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnProductos.OnPressedState.BorderThickness = 1;
            this.btnProductos.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnProductos.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnProductos.OnPressedState.IconLeftImage = null;
            this.btnProductos.OnPressedState.IconRightImage = null;
            this.btnProductos.Size = new System.Drawing.Size(200, 39);
            this.btnProductos.TabIndex = 6;
            this.btnProductos.Tag = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProductos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnProductos.TextMarginLeft = 0;
            this.btnProductos.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnProductos.UseDefaultRadiusAndThickness = true;
            this.btnProductos.Click += new System.EventHandler(this.BotonMenu_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.AllowAnimations = true;
            this.btnCompras.AllowMouseEffects = true;
            this.btnCompras.AllowToggling = false;
            this.btnCompras.AnimationSpeed = 200;
            this.btnCompras.AutoGenerateColors = false;
            this.btnCompras.AutoRoundBorders = false;
            this.btnCompras.AutoSizeLeftIcon = true;
            this.btnCompras.AutoSizeRightIcon = true;
            this.btnCompras.BackColor = System.Drawing.Color.Transparent;
            this.btnCompras.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnCompras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCompras.BackgroundImage")));
            this.btnCompras.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCompras.ButtonText = "Compras";
            this.btnCompras.ButtonTextMarginLeft = 0;
            this.btnCompras.ColorContrastOnClick = 45;
            this.btnCompras.ColorContrastOnHover = 45;
            this.btnCompras.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges8.BottomLeft = true;
            borderEdges8.BottomRight = true;
            borderEdges8.TopLeft = true;
            borderEdges8.TopRight = true;
            this.btnCompras.CustomizableEdges = borderEdges8;
            this.menuTransitionMostrar.SetDecoration(this.btnCompras, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnCompras.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCompras.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCompras.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnCompras.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompras.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnCompras.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.White;
            this.btnCompras.IconLeft = global::Murray.Properties.Resources.carts;
            this.btnCompras.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCompras.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnCompras.IconMarginLeft = 11;
            this.btnCompras.IconPadding = 5;
            this.btnCompras.IconRight = null;
            this.btnCompras.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompras.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCompras.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnCompras.IconSize = 40;
            this.btnCompras.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnCompras.IdleBorderRadius = 0;
            this.btnCompras.IdleBorderThickness = 0;
            this.btnCompras.IdleFillColor = System.Drawing.Color.Empty;
            this.btnCompras.IdleIconLeftImage = global::Murray.Properties.Resources.carts;
            this.btnCompras.IdleIconRightImage = null;
            this.btnCompras.IndicateFocus = false;
            this.btnCompras.Location = new System.Drawing.Point(0, 126);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCompras.OnDisabledState.BorderRadius = 1;
            this.btnCompras.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCompras.OnDisabledState.BorderThickness = 1;
            this.btnCompras.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCompras.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCompras.OnDisabledState.IconLeftImage = null;
            this.btnCompras.OnDisabledState.IconRightImage = null;
            this.btnCompras.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnCompras.onHoverState.BorderRadius = 1;
            this.btnCompras.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCompras.onHoverState.BorderThickness = 1;
            this.btnCompras.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnCompras.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnCompras.onHoverState.IconLeftImage = null;
            this.btnCompras.onHoverState.IconRightImage = null;
            this.btnCompras.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnCompras.OnIdleState.BorderRadius = 1;
            this.btnCompras.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCompras.OnIdleState.BorderThickness = 1;
            this.btnCompras.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.btnCompras.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnCompras.OnIdleState.IconLeftImage = global::Murray.Properties.Resources.carts;
            this.btnCompras.OnIdleState.IconRightImage = null;
            this.btnCompras.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnCompras.OnPressedState.BorderRadius = 1;
            this.btnCompras.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCompras.OnPressedState.BorderThickness = 1;
            this.btnCompras.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnCompras.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnCompras.OnPressedState.IconLeftImage = null;
            this.btnCompras.OnPressedState.IconRightImage = null;
            this.btnCompras.Size = new System.Drawing.Size(200, 39);
            this.btnCompras.TabIndex = 5;
            this.btnCompras.Tag = "Compras";
            this.btnCompras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCompras.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCompras.TextMarginLeft = 0;
            this.btnCompras.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCompras.UseDefaultRadiusAndThickness = true;
            this.btnCompras.Click += new System.EventHandler(this.BotonMenu_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.AllowAnimations = true;
            this.btnVentas.AllowMouseEffects = true;
            this.btnVentas.AllowToggling = false;
            this.btnVentas.AnimationSpeed = 200;
            this.btnVentas.AutoGenerateColors = false;
            this.btnVentas.AutoRoundBorders = false;
            this.btnVentas.AutoSizeLeftIcon = true;
            this.btnVentas.AutoSizeRightIcon = true;
            this.btnVentas.BackColor = System.Drawing.Color.Transparent;
            this.btnVentas.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnVentas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVentas.BackgroundImage")));
            this.btnVentas.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnVentas.ButtonText = "Ventas";
            this.btnVentas.ButtonTextMarginLeft = 0;
            this.btnVentas.ColorContrastOnClick = 45;
            this.btnVentas.ColorContrastOnHover = 45;
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges9.BottomLeft = true;
            borderEdges9.BottomRight = true;
            borderEdges9.TopLeft = true;
            borderEdges9.TopRight = true;
            this.btnVentas.CustomizableEdges = borderEdges9;
            this.menuTransitionMostrar.SetDecoration(this.btnVentas, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnVentas.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnVentas.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnVentas.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnVentas.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.White;
            this.btnVentas.IconLeft = global::Murray.Properties.Resources.ventas;
            this.btnVentas.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnVentas.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnVentas.IconMarginLeft = 11;
            this.btnVentas.IconPadding = 5;
            this.btnVentas.IconRight = null;
            this.btnVentas.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentas.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnVentas.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnVentas.IconSize = 40;
            this.btnVentas.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnVentas.IdleBorderRadius = 0;
            this.btnVentas.IdleBorderThickness = 0;
            this.btnVentas.IdleFillColor = System.Drawing.Color.Empty;
            this.btnVentas.IdleIconLeftImage = global::Murray.Properties.Resources.ventas;
            this.btnVentas.IdleIconRightImage = null;
            this.btnVentas.IndicateFocus = false;
            this.btnVentas.Location = new System.Drawing.Point(0, 87);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnVentas.OnDisabledState.BorderRadius = 1;
            this.btnVentas.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnVentas.OnDisabledState.BorderThickness = 1;
            this.btnVentas.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnVentas.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnVentas.OnDisabledState.IconLeftImage = null;
            this.btnVentas.OnDisabledState.IconRightImage = null;
            this.btnVentas.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnVentas.onHoverState.BorderRadius = 1;
            this.btnVentas.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnVentas.onHoverState.BorderThickness = 1;
            this.btnVentas.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnVentas.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnVentas.onHoverState.IconLeftImage = null;
            this.btnVentas.onHoverState.IconRightImage = null;
            this.btnVentas.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnVentas.OnIdleState.BorderRadius = 1;
            this.btnVentas.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnVentas.OnIdleState.BorderThickness = 1;
            this.btnVentas.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.btnVentas.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnVentas.OnIdleState.IconLeftImage = global::Murray.Properties.Resources.ventas;
            this.btnVentas.OnIdleState.IconRightImage = null;
            this.btnVentas.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnVentas.OnPressedState.BorderRadius = 1;
            this.btnVentas.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnVentas.OnPressedState.BorderThickness = 1;
            this.btnVentas.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnVentas.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnVentas.OnPressedState.IconLeftImage = null;
            this.btnVentas.OnPressedState.IconRightImage = null;
            this.btnVentas.Size = new System.Drawing.Size(200, 39);
            this.btnVentas.TabIndex = 4;
            this.btnVentas.Tag = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVentas.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnVentas.TextMarginLeft = 0;
            this.btnVentas.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnVentas.UseDefaultRadiusAndThickness = true;
            this.btnVentas.Click += new System.EventHandler(this.BotonMenu_Click);
            // 
            // btnContactos
            // 
            this.btnContactos.AllowAnimations = true;
            this.btnContactos.AllowMouseEffects = true;
            this.btnContactos.AllowToggling = false;
            this.btnContactos.AnimationSpeed = 200;
            this.btnContactos.AutoGenerateColors = false;
            this.btnContactos.AutoRoundBorders = false;
            this.btnContactos.AutoSizeLeftIcon = true;
            this.btnContactos.AutoSizeRightIcon = true;
            this.btnContactos.BackColor = System.Drawing.Color.Transparent;
            this.btnContactos.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnContactos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContactos.BackgroundImage")));
            this.btnContactos.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnContactos.ButtonText = "Contactos";
            this.btnContactos.ButtonTextMarginLeft = 0;
            this.btnContactos.ColorContrastOnClick = 45;
            this.btnContactos.ColorContrastOnHover = 45;
            this.btnContactos.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges10.BottomLeft = true;
            borderEdges10.BottomRight = true;
            borderEdges10.TopLeft = true;
            borderEdges10.TopRight = true;
            this.btnContactos.CustomizableEdges = borderEdges10;
            this.menuTransitionMostrar.SetDecoration(this.btnContactos, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnContactos.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnContactos.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnContactos.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnContactos.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnContactos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContactos.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnContactos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContactos.ForeColor = System.Drawing.Color.White;
            this.btnContactos.IconLeft = global::Murray.Properties.Resources.team;
            this.btnContactos.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContactos.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnContactos.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnContactos.IconMarginLeft = 11;
            this.btnContactos.IconPadding = 5;
            this.btnContactos.IconRight = null;
            this.btnContactos.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContactos.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnContactos.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnContactos.IconSize = 40;
            this.btnContactos.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnContactos.IdleBorderRadius = 0;
            this.btnContactos.IdleBorderThickness = 0;
            this.btnContactos.IdleFillColor = System.Drawing.Color.Empty;
            this.btnContactos.IdleIconLeftImage = global::Murray.Properties.Resources.team;
            this.btnContactos.IdleIconRightImage = null;
            this.btnContactos.IndicateFocus = false;
            this.btnContactos.Location = new System.Drawing.Point(0, 48);
            this.btnContactos.Name = "btnContactos";
            this.btnContactos.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnContactos.OnDisabledState.BorderRadius = 1;
            this.btnContactos.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnContactos.OnDisabledState.BorderThickness = 1;
            this.btnContactos.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnContactos.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnContactos.OnDisabledState.IconLeftImage = null;
            this.btnContactos.OnDisabledState.IconRightImage = null;
            this.btnContactos.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnContactos.onHoverState.BorderRadius = 1;
            this.btnContactos.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnContactos.onHoverState.BorderThickness = 1;
            this.btnContactos.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnContactos.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnContactos.onHoverState.IconLeftImage = null;
            this.btnContactos.onHoverState.IconRightImage = null;
            this.btnContactos.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnContactos.OnIdleState.BorderRadius = 1;
            this.btnContactos.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnContactos.OnIdleState.BorderThickness = 1;
            this.btnContactos.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.btnContactos.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnContactos.OnIdleState.IconLeftImage = global::Murray.Properties.Resources.team;
            this.btnContactos.OnIdleState.IconRightImage = null;
            this.btnContactos.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnContactos.OnPressedState.BorderRadius = 1;
            this.btnContactos.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnContactos.OnPressedState.BorderThickness = 1;
            this.btnContactos.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.btnContactos.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnContactos.OnPressedState.IconLeftImage = null;
            this.btnContactos.OnPressedState.IconRightImage = null;
            this.btnContactos.Size = new System.Drawing.Size(200, 39);
            this.btnContactos.TabIndex = 3;
            this.btnContactos.Tag = "Contactos";
            this.btnContactos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnContactos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnContactos.TextMarginLeft = 0;
            this.btnContactos.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnContactos.UseDefaultRadiusAndThickness = true;
            this.btnContactos.Click += new System.EventHandler(this.BotonMenu_Click);
            // 
            // separadorLogo
            // 
            this.separadorLogo.BackColor = System.Drawing.Color.Transparent;
            this.separadorLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("separadorLogo.BackgroundImage")));
            this.separadorLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.separadorLogo.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.menuTransitionMostrar.SetDecoration(this.separadorLogo, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.separadorLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.separadorLogo.LineColor = System.Drawing.Color.Silver;
            this.separadorLogo.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.separadorLogo.LineThickness = 1;
            this.separadorLogo.Location = new System.Drawing.Point(0, 40);
            this.separadorLogo.Name = "separadorLogo";
            this.separadorLogo.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.separadorLogo.Size = new System.Drawing.Size(200, 8);
            this.separadorLogo.TabIndex = 2;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.pbLogo);
            this.menuTransitionMostrar.SetDecoration(this.pnlTitulo, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 5);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(200, 35);
            this.pnlTitulo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.menuTransitionMostrar.SetDecoration(this.lblTitulo, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(47, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(153, 35);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Murray";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbLogo
            // 
            this.menuTransitionMostrar.SetDecoration(this.pbLogo, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::Murray.Properties.Resources.atom;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(47, 35);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pnlSeparadorMenu
            // 
            this.menuTransitionMostrar.SetDecoration(this.pnlSeparadorMenu, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnlSeparadorMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparadorMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSeparadorMenu.Name = "pnlSeparadorMenu";
            this.pnlSeparadorMenu.Size = new System.Drawing.Size(200, 5);
            this.pnlSeparadorMenu.TabIndex = 0;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(197)))));
            this.menuTransitionMostrar.SetDecoration(this.pnlPrincipal, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(200, 25);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(867, 504);
            this.pnlPrincipal.TabIndex = 2;
            // 
            // menuTransitionMostrar
            // 
            this.menuTransitionMostrar.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.HorizSlide;
            this.menuTransitionMostrar.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.menuTransitionMostrar.DefaultAnimation = animation2;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 529);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlIzq);
            this.Controls.Add(this.pnlBarraSup);
            this.menuTransitionMostrar.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlBarraSup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            this.pnlIzq.ResumeLayout(false);
            this.gradientPanelIzq.ResumeLayout(false);
            this.pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarraSup;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbRestaurar;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMenu;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Panel pnlIzq;
        private System.Windows.Forms.Panel pnlPrincipal;
        private Bunifu.UI.WinForms.BunifuGradientPanel gradientPanelIzq;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlSeparadorMenu;
        private Bunifu.UI.WinForms.BunifuSeparator separadorLogo;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnContactos;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnVentas;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnCompras;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnProductos;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSeguridad;
        private Bunifu.UI.WinForms.BunifuTransition menuTransitionMostrar;
    }
}