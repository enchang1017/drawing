namespace DrawingForm
{
    partial class DrawForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._drawingPanel = new System.Windows.Forms.Panel();
            this._ellipseButton = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._lineButton = new System.Windows.Forms.Button();
            this._diamondButton = new System.Windows.Forms.Button();
            this._drawingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _drawingPanel
            // 
            this._drawingPanel.BackColor = System.Drawing.Color.LightYellow;
            this._drawingPanel.Controls.Add(this._ellipseButton);
            this._drawingPanel.Controls.Add(this._clearButton);
            this._drawingPanel.Controls.Add(this._lineButton);
            this._drawingPanel.Controls.Add(this._diamondButton);
            this._drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._drawingPanel.Location = new System.Drawing.Point(0, 0);
            this._drawingPanel.Name = "_drawingPanel";
            this._drawingPanel.Size = new System.Drawing.Size(1121, 601);
            this._drawingPanel.TabIndex = 0;
            // 
            // _ellipseButton
            // 
            this._ellipseButton.Location = new System.Drawing.Point(583, 12);
            this._ellipseButton.Name = "_ellipseButton";
            this._ellipseButton.Size = new System.Drawing.Size(226, 45);
            this._ellipseButton.TabIndex = 3;
            this._ellipseButton.Text = "Ellipse";
            this._ellipseButton.UseVisualStyleBackColor = true;
            this._ellipseButton.Click += new System.EventHandler(this.ClickEllipseButton);
            // 
            // _clearButton
            // 
            this._clearButton.Location = new System.Drawing.Point(840, 12);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(226, 45);
            this._clearButton.TabIndex = 2;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            // 
            // _lineButton
            // 
            this._lineButton.Location = new System.Drawing.Point(318, 12);
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(226, 45);
            this._lineButton.TabIndex = 1;
            this._lineButton.Text = "Line";
            this._lineButton.UseVisualStyleBackColor = true;
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _diamondButton
            // 
            this._diamondButton.Location = new System.Drawing.Point(38, 12);
            this._diamondButton.Name = "_diamondButton";
            this._diamondButton.Size = new System.Drawing.Size(226, 45);
            this._diamondButton.TabIndex = 0;
            this._diamondButton.Text = "Diamond";
            this._diamondButton.UseVisualStyleBackColor = true;
            this._diamondButton.Click += new System.EventHandler(this.ClickDiamondButton);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 601);
            this.Controls.Add(this._drawingPanel);
            this.Name = "DrawForm";
            this.Text = "Form1";
            this._drawingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _drawingPanel;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _lineButton;
        private System.Windows.Forms.Button _diamondButton;
        private System.Windows.Forms.Button _ellipseButton;
    }
}

