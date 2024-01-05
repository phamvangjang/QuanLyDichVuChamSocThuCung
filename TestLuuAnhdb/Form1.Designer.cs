namespace TestLuuAnhdb
{
    partial class Form1
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
            this.txtImg = new System.Windows.Forms.TextBox();
            this.btnChonha = new System.Windows.Forms.Button();
            this.btnImgtoByte = new System.Windows.Forms.Button();
            this.btnBytetoimg = new System.Windows.Forms.Button();
            this.rtbanh = new System.Windows.Forms.RichTextBox();
            this.lvanh = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // txtImg
            // 
            this.txtImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImg.Location = new System.Drawing.Point(65, 32);
            this.txtImg.Name = "txtImg";
            this.txtImg.Size = new System.Drawing.Size(278, 34);
            this.txtImg.TabIndex = 0;
            // 
            // btnChonha
            // 
            this.btnChonha.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonha.Location = new System.Drawing.Point(359, 24);
            this.btnChonha.Name = "btnChonha";
            this.btnChonha.Size = new System.Drawing.Size(198, 42);
            this.btnChonha.TabIndex = 1;
            this.btnChonha.Text = "Chon hinh anh";
            this.btnChonha.UseVisualStyleBackColor = true;
            this.btnChonha.Click += new System.EventHandler(this.btnChonha_Click);
            // 
            // btnImgtoByte
            // 
            this.btnImgtoByte.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImgtoByte.Location = new System.Drawing.Point(65, 87);
            this.btnImgtoByte.Name = "btnImgtoByte";
            this.btnImgtoByte.Size = new System.Drawing.Size(202, 42);
            this.btnImgtoByte.TabIndex = 2;
            this.btnImgtoByte.Text = "anh sang byte";
            this.btnImgtoByte.UseVisualStyleBackColor = true;
            this.btnImgtoByte.Click += new System.EventHandler(this.btnImgtoByte_Click);
            // 
            // btnBytetoimg
            // 
            this.btnBytetoimg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBytetoimg.Location = new System.Drawing.Point(65, 338);
            this.btnBytetoimg.Name = "btnBytetoimg";
            this.btnBytetoimg.Size = new System.Drawing.Size(202, 42);
            this.btnBytetoimg.TabIndex = 3;
            this.btnBytetoimg.Text = "byte sang anh";
            this.btnBytetoimg.UseVisualStyleBackColor = true;
            this.btnBytetoimg.Click += new System.EventHandler(this.btnBytetoimg_Click);
            // 
            // rtbanh
            // 
            this.rtbanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbanh.Location = new System.Drawing.Point(65, 146);
            this.rtbanh.Name = "rtbanh";
            this.rtbanh.Size = new System.Drawing.Size(492, 174);
            this.rtbanh.TabIndex = 4;
            this.rtbanh.Text = "";
            // 
            // lvanh
            // 
            this.lvanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvanh.HideSelection = false;
            this.lvanh.Location = new System.Drawing.Point(65, 397);
            this.lvanh.Name = "lvanh";
            this.lvanh.Size = new System.Drawing.Size(488, 239);
            this.lvanh.SmallImageList = this.imageList1;
            this.lvanh.TabIndex = 5;
            this.lvanh.UseCompatibleStateImageBehavior = false;
            this.lvanh.View = System.Windows.Forms.View.Details;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 648);
            this.Controls.Add(this.lvanh);
            this.Controls.Add(this.rtbanh);
            this.Controls.Add(this.btnBytetoimg);
            this.Controls.Add(this.btnImgtoByte);
            this.Controls.Add(this.btnChonha);
            this.Controls.Add(this.txtImg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImg;
        private System.Windows.Forms.Button btnChonha;
        private System.Windows.Forms.Button btnImgtoByte;
        private System.Windows.Forms.Button btnBytetoimg;
        private System.Windows.Forms.RichTextBox rtbanh;
        private System.Windows.Forms.ListView lvanh;
        private System.Windows.Forms.ImageList imageList1;
    }
}

