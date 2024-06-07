namespace RWP4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Formula1 = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.Formula2 = new System.Windows.Forms.TabPage();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.Formula3 = new System.Windows.Forms.TabPage();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.Formula4 = new System.Windows.Forms.TabPage();
            this.elementHost4 = new System.Windows.Forms.Integration.ElementHost();
            this.Formula5 = new System.Windows.Forms.TabPage();
            this.elementHost5 = new System.Windows.Forms.Integration.ElementHost();
            this.Morph = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Combination = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Formula1.SuspendLayout();
            this.Formula2.SuspendLayout();
            this.Formula3.SuspendLayout();
            this.Formula4.SuspendLayout();
            this.Formula5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Formula1);
            this.tabControl1.Controls.Add(this.Formula2);
            this.tabControl1.Controls.Add(this.Formula3);
            this.tabControl1.Controls.Add(this.Formula4);
            this.tabControl1.Controls.Add(this.Formula5);
            this.tabControl1.Location = new System.Drawing.Point(4, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 439);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Formula1
            // 
            this.Formula1.Controls.Add(this.elementHost1);
            this.Formula1.Location = new System.Drawing.Point(4, 25);
            this.Formula1.Name = "Formula1";
            this.Formula1.Padding = new System.Windows.Forms.Padding(3);
            this.Formula1.Size = new System.Drawing.Size(786, 410);
            this.Formula1.TabIndex = 0;
            this.Formula1.Text = "Параболоид";
            this.Formula1.UseVisualStyleBackColor = true;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(3, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(780, 404);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // Formula2
            // 
            this.Formula2.Controls.Add(this.elementHost2);
            this.Formula2.Location = new System.Drawing.Point(4, 25);
            this.Formula2.Name = "Formula2";
            this.Formula2.Padding = new System.Windows.Forms.Padding(3);
            this.Formula2.Size = new System.Drawing.Size(786, 410);
            this.Formula2.TabIndex = 1;
            this.Formula2.Text = "Седловая";
            this.Formula2.UseVisualStyleBackColor = true;
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(3, 3);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(780, 404);
            this.elementHost2.TabIndex = 0;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = null;
            // 
            // Formula3
            // 
            this.Formula3.Controls.Add(this.elementHost3);
            this.Formula3.Location = new System.Drawing.Point(4, 25);
            this.Formula3.Name = "Formula3";
            this.Formula3.Size = new System.Drawing.Size(786, 410);
            this.Formula3.TabIndex = 2;
            this.Formula3.Text = "Поверхность";
            this.Formula3.UseVisualStyleBackColor = true;
            // 
            // elementHost3
            // 
            this.elementHost3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost3.Location = new System.Drawing.Point(0, 0);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(786, 410);
            this.elementHost3.TabIndex = 0;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = null;
            // 
            // Formula4
            // 
            this.Formula4.Controls.Add(this.elementHost4);
            this.Formula4.Location = new System.Drawing.Point(4, 25);
            this.Formula4.Name = "Formula4";
            this.Formula4.Size = new System.Drawing.Size(786, 410);
            this.Formula4.TabIndex = 3;
            this.Formula4.Text = "Пульсирующая";
            this.Formula4.UseVisualStyleBackColor = true;
            // 
            // elementHost4
            // 
            this.elementHost4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost4.Location = new System.Drawing.Point(0, 0);
            this.elementHost4.Name = "elementHost4";
            this.elementHost4.Size = new System.Drawing.Size(786, 410);
            this.elementHost4.TabIndex = 0;
            this.elementHost4.Text = "elementHost4";
            this.elementHost4.Child = null;
            // 
            // Formula5
            // 
            this.Formula5.Controls.Add(this.elementHost5);
            this.Formula5.Location = new System.Drawing.Point(4, 25);
            this.Formula5.Name = "Formula5";
            this.Formula5.Size = new System.Drawing.Size(786, 410);
            this.Formula5.TabIndex = 4;
            this.Formula5.Text = "Эллиптическая";
            this.Formula5.UseVisualStyleBackColor = true;
            // 
            // elementHost5
            // 
            this.elementHost5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost5.Location = new System.Drawing.Point(0, 0);
            this.elementHost5.Name = "elementHost5";
            this.elementHost5.Size = new System.Drawing.Size(786, 410);
            this.elementHost5.TabIndex = 0;
            this.elementHost5.Text = "elementHost5";
            this.elementHost5.Child = null;
            // 
            // Morph
            // 
            this.Morph.Location = new System.Drawing.Point(0, 0);
            this.Morph.Name = "Morph";
            this.Morph.Size = new System.Drawing.Size(70, 36);
            this.Morph.TabIndex = 1;
            this.Morph.Text = "Play";
            this.Morph.UseVisualStyleBackColor = true;
            this.Morph.Click += new System.EventHandler(this.Morph_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Combination);
            this.groupBox1.Controls.Add(this.Morph);
            this.groupBox1.Location = new System.Drawing.Point(4, 485);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 37);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Combination
            // 
            this.Combination.Location = new System.Drawing.Point(77, 0);
            this.Combination.Name = "Combination";
            this.Combination.Size = new System.Drawing.Size(112, 37);
            this.Combination.TabIndex = 2;
            this.Combination.Text = "Комбинация";
            this.Combination.UseVisualStyleBackColor = true;
            this.Combination.Click += new System.EventHandler(this.Combination_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Blender (почти)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Formula1.ResumeLayout(false);
            this.Formula2.ResumeLayout(false);
            this.Formula3.ResumeLayout(false);
            this.Formula4.ResumeLayout(false);
            this.Formula5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Formula2;
        private System.Windows.Forms.TabPage Formula3;
        private System.Windows.Forms.TabPage Formula4;
        private System.Windows.Forms.TabPage Formula5;
        private System.Windows.Forms.TabPage Formula1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private System.Windows.Forms.Integration.ElementHost elementHost4;
        private System.Windows.Forms.Integration.ElementHost elementHost5;
        private System.Windows.Forms.Button Morph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Combination;
    }
}

