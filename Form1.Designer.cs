namespace _3DProjection
{
    partial class Projection3D
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            canvas = new Panel();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = SystemColors.ActiveCaptionText;
            canvas.Location = new Point(12, 12);
            canvas.Name = "canvas";
            canvas.Size = new Size(1138, 685);
            canvas.TabIndex = 0;
            canvas.Paint += canvas_Paint;
            // 
            // Projection3D
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 709);
            Controls.Add(canvas);
            Name = "Projection3D";
            Text = "Projection3D";
            ResumeLayout(false);
        }

        #endregion

        private Panel canvas;
    }
}
