namespace GraphicsEditor
{
    partial class EditorForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.instrumentBox = new System.Windows.Forms.ComboBox();
            this.penColorDialog = new System.Windows.Forms.ColorDialog();
            this.brushColorDialog = new System.Windows.Forms.ColorDialog();
            this.penColorBtn = new System.Windows.Forms.Button();
            this.brushColorBtn = new System.Windows.Forms.Button();
            this.penLbl = new System.Windows.Forms.Label();
            this.brushLbl = new System.Windows.Forms.Label();
            this.figureList = new System.Windows.Forms.ListBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveListBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.loadListBtn = new System.Windows.Forms.Button();
            this.loadClassBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox.Location = new System.Drawing.Point(170, 40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(401, 338);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // instrumentBox
            // 
            this.instrumentBox.FormattingEnabled = true;
            this.instrumentBox.Location = new System.Drawing.Point(12, 40);
            this.instrumentBox.Name = "instrumentBox";
            this.instrumentBox.Size = new System.Drawing.Size(152, 23);
            this.instrumentBox.TabIndex = 3;
            this.instrumentBox.SelectedIndexChanged += new System.EventHandler(this.instrumentBox_SelectedIndexChanged);
            // 
            // penColorDialog
            // 
            this.penColorDialog.FullOpen = true;
            // 
            // brushColorDialog
            // 
            this.brushColorDialog.FullOpen = true;
            // 
            // penColorBtn
            // 
            this.penColorBtn.Location = new System.Drawing.Point(114, 82);
            this.penColorBtn.Name = "penColorBtn";
            this.penColorBtn.Size = new System.Drawing.Size(50, 50);
            this.penColorBtn.TabIndex = 4;
            this.penColorBtn.UseVisualStyleBackColor = true;
            this.penColorBtn.Click += new System.EventHandler(this.penColorBtn_Click);
            // 
            // brushColorBtn
            // 
            this.brushColorBtn.Location = new System.Drawing.Point(114, 138);
            this.brushColorBtn.Name = "brushColorBtn";
            this.brushColorBtn.Size = new System.Drawing.Size(50, 50);
            this.brushColorBtn.TabIndex = 5;
            this.brushColorBtn.UseVisualStyleBackColor = true;
            this.brushColorBtn.Click += new System.EventHandler(this.brushColorBtn_Click);
            // 
            // penLbl
            // 
            this.penLbl.AutoSize = true;
            this.penLbl.Location = new System.Drawing.Point(12, 100);
            this.penLbl.Name = "penLbl";
            this.penLbl.Size = new System.Drawing.Size(79, 15);
            this.penLbl.TabIndex = 6;
            this.penLbl.Text = "Pen Color";
            // 
            // brushLbl
            // 
            this.brushLbl.AutoSize = true;
            this.brushLbl.Location = new System.Drawing.Point(12, 156);
            this.brushLbl.Name = "brushLbl";
            this.brushLbl.Size = new System.Drawing.Size(87, 15);
            this.brushLbl.TabIndex = 7;
            this.brushLbl.Text = "BrushColor";
            // 
            // figureList
            // 
            this.figureList.FormattingEnabled = true;
            this.figureList.ItemHeight = 15;
            this.figureList.Location = new System.Drawing.Point(12, 226);
            this.figureList.Name = "figureList";
            this.figureList.Size = new System.Drawing.Size(152, 94);
            this.figureList.TabIndex = 8;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 326);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(12, 355);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 10;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // saveListBtn
            // 
            this.saveListBtn.Location = new System.Drawing.Point(12, 385);
            this.saveListBtn.Name = "saveListBtn";
            this.saveListBtn.Size = new System.Drawing.Size(152, 23);
            this.saveListBtn.TabIndex = 11;
            this.saveListBtn.Text = "Save list";
            this.saveListBtn.UseVisualStyleBackColor = true;
            this.saveListBtn.Click += new System.EventHandler(this.saveListBtn_Click);
            // 
            // loadListBtn
            // 
            this.loadListBtn.Location = new System.Drawing.Point(13, 415);
            this.loadListBtn.Name = "loadListBtn";
            this.loadListBtn.Size = new System.Drawing.Size(151, 23);
            this.loadListBtn.TabIndex = 12;
            this.loadListBtn.Text = "Load list";
            this.loadListBtn.UseVisualStyleBackColor = true;
            this.loadListBtn.Click += new System.EventHandler(this.loadListBtn_Click);
            // 
            // loadClassBtn
            // 
            this.loadClassBtn.Location = new System.Drawing.Point(496, 384);
            this.loadClassBtn.Name = "loadClassBtn";
            this.loadClassBtn.Size = new System.Drawing.Size(75, 54);
            this.loadClassBtn.TabIndex = 13;
            this.loadClassBtn.Text = "Load Class";
            this.loadClassBtn.UseVisualStyleBackColor = true;
            this.loadClassBtn.Click += new System.EventHandler(this.loadClassBtn_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 450);
            this.Controls.Add(this.loadClassBtn);
            this.Controls.Add(this.loadListBtn);
            this.Controls.Add(this.saveListBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.figureList);
            this.Controls.Add(this.brushLbl);
            this.Controls.Add(this.penLbl);
            this.Controls.Add(this.brushColorBtn);
            this.Controls.Add(this.penColorBtn);
            this.Controls.Add(this.instrumentBox);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(644, 497);
            this.MinimumSize = new System.Drawing.Size(644, 497);
            this.Name = "EditorForm";
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox instrumentBox;
        private System.Windows.Forms.ColorDialog penColorDialog;
        private System.Windows.Forms.ColorDialog brushColorDialog;
        private System.Windows.Forms.Button penColorBtn;
        private System.Windows.Forms.Button brushColorBtn;
        private System.Windows.Forms.Label penLbl;
        private System.Windows.Forms.Label brushLbl;
        private System.Windows.Forms.ListBox figureList;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveListBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button loadListBtn;
        private System.Windows.Forms.Button loadClassBtn;
    }
}

