namespace Translat
{
    partial class form_trans
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_source = new System.Windows.Forms.TextBox();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.radioButton_ktoe = new System.Windows.Forms.RadioButton();
            this.radioButton_etok = new System.Windows.Forms.RadioButton();
            this.button_translate = new System.Windows.Forms.Button();
            this.button_change = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.checkBox_top = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_source
            // 
            this.textBox_source.Font = new System.Drawing.Font("굴림", 12F);
            this.textBox_source.Location = new System.Drawing.Point(13, 13);
            this.textBox_source.Multiline = true;
            this.textBox_source.Name = "textBox_source";
            this.textBox_source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_source.Size = new System.Drawing.Size(259, 103);
            this.textBox_source.TabIndex = 0;
            // 
            // textBox_result
            // 
            this.textBox_result.Font = new System.Drawing.Font("굴림", 12F);
            this.textBox_result.Location = new System.Drawing.Point(12, 154);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_result.Size = new System.Drawing.Size(259, 103);
            this.textBox_result.TabIndex = 1;
            // 
            // radioButton_ktoe
            // 
            this.radioButton_ktoe.AutoSize = true;
            this.radioButton_ktoe.Checked = true;
            this.radioButton_ktoe.Location = new System.Drawing.Point(13, 123);
            this.radioButton_ktoe.Name = "radioButton_ktoe";
            this.radioButton_ktoe.Size = new System.Drawing.Size(63, 16);
            this.radioButton_ktoe.TabIndex = 2;
            this.radioButton_ktoe.TabStop = true;
            this.radioButton_ktoe.Text = "한 > 영";
            this.radioButton_ktoe.UseVisualStyleBackColor = true;
            this.radioButton_ktoe.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_etok
            // 
            this.radioButton_etok.AutoSize = true;
            this.radioButton_etok.Location = new System.Drawing.Point(81, 123);
            this.radioButton_etok.Name = "radioButton_etok";
            this.radioButton_etok.Size = new System.Drawing.Size(63, 16);
            this.radioButton_etok.TabIndex = 3;
            this.radioButton_etok.Text = "영 > 한";
            this.radioButton_etok.UseVisualStyleBackColor = true;
            this.radioButton_etok.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // button_translate
            // 
            this.button_translate.Location = new System.Drawing.Point(12, 270);
            this.button_translate.Name = "button_translate";
            this.button_translate.Size = new System.Drawing.Size(75, 23);
            this.button_translate.TabIndex = 4;
            this.button_translate.Text = "번역하기";
            this.button_translate.UseVisualStyleBackColor = true;
            this.button_translate.Click += new System.EventHandler(this.button_translate_Click);
            // 
            // button_change
            // 
            this.button_change.Location = new System.Drawing.Point(105, 270);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(75, 23);
            this.button_change.TabIndex = 5;
            this.button_change.Text = "전환";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(196, 270);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(75, 23);
            this.button_copy.TabIndex = 6;
            this.button_copy.Text = "복사";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // checkBox_top
            // 
            this.checkBox_top.AutoSize = true;
            this.checkBox_top.Location = new System.Drawing.Point(151, 123);
            this.checkBox_top.Name = "checkBox_top";
            this.checkBox_top.Size = new System.Drawing.Size(88, 16);
            this.checkBox_top.TabIndex = 7;
            this.checkBox_top.Text = "항상 앞으로";
            this.checkBox_top.UseVisualStyleBackColor = true;
            this.checkBox_top.CheckedChanged += new System.EventHandler(this.checkBox_top_CheckedChanged);
            // 
            // form_trans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 305);
            this.Controls.Add(this.checkBox_top);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.button_translate);
            this.Controls.Add(this.radioButton_etok);
            this.Controls.Add(this.radioButton_ktoe);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.textBox_source);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_trans";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "번역기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_source;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.RadioButton radioButton_ktoe;
        private System.Windows.Forms.RadioButton radioButton_etok;
        private System.Windows.Forms.Button button_translate;
        private System.Windows.Forms.Button button_change;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.CheckBox checkBox_top;
    }
}

