namespace STM32FlashBootloader
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.connectionBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.disconButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.comboBoxPartiy = new System.Windows.Forms.ComboBox();
            this.parityLabel = new System.Windows.Forms.Label();
            this.comboBoxStop = new System.Windows.Forms.ComboBox();
            this.stopBit_label = new System.Windows.Forms.Label();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.baud_label = new System.Windows.Forms.Label();
            this.comboBoxCom = new System.Windows.Forms.ComboBox();
            this.com_label = new System.Windows.Forms.Label();
            this.comGrupBox = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.browseText = new System.Windows.Forms.TextBox();
            this.wAddressBox = new System.Windows.Forms.TextBox();
            this.writeButton = new System.Windows.Forms.Button();
            this.goTexbox = new System.Windows.Forms.TextBox();
            this.goToButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.lengthTextbox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.rdmemoryButton = new System.Windows.Forms.Button();
            this.butongetid = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.getVersionButton = new System.Windows.Forms.Button();
            this.buttonGetHelp = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.connectionBox.SuspendLayout();
            this.comGrupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // connectionBox
            // 
            this.connectionBox.Controls.Add(this.textBox1);
            this.connectionBox.Controls.Add(this.progressBar1);
            this.connectionBox.Controls.Add(this.disconButton);
            this.connectionBox.Controls.Add(this.connectButton);
            this.connectionBox.Controls.Add(this.comboBoxPartiy);
            this.connectionBox.Controls.Add(this.parityLabel);
            this.connectionBox.Controls.Add(this.comboBoxStop);
            this.connectionBox.Controls.Add(this.stopBit_label);
            this.connectionBox.Controls.Add(this.comboBoxBaud);
            this.connectionBox.Controls.Add(this.baud_label);
            this.connectionBox.Controls.Add(this.comboBoxCom);
            this.connectionBox.Controls.Add(this.com_label);
            resources.ApplyResources(this.connectionBox, "connectionBox");
            this.connectionBox.Name = "connectionBox";
            this.connectionBox.TabStop = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // disconButton
            // 
            resources.ApplyResources(this.disconButton, "disconButton");
            this.disconButton.Name = "disconButton";
            this.disconButton.UseVisualStyleBackColor = true;
            this.disconButton.Click += new System.EventHandler(this.disconButton_Click);
            // 
            // connectButton
            // 
            resources.ApplyResources(this.connectButton, "connectButton");
            this.connectButton.Name = "connectButton";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // comboBoxPartiy
            // 
            this.comboBoxPartiy.FormattingEnabled = true;
            this.comboBoxPartiy.Items.AddRange(new object[] {
            resources.GetString("comboBoxPartiy.Items"),
            resources.GetString("comboBoxPartiy.Items1"),
            resources.GetString("comboBoxPartiy.Items2")});
            resources.ApplyResources(this.comboBoxPartiy, "comboBoxPartiy");
            this.comboBoxPartiy.Name = "comboBoxPartiy";
            // 
            // parityLabel
            // 
            resources.ApplyResources(this.parityLabel, "parityLabel");
            this.parityLabel.Name = "parityLabel";
            // 
            // comboBoxStop
            // 
            this.comboBoxStop.FormattingEnabled = true;
            this.comboBoxStop.Items.AddRange(new object[] {
            resources.GetString("comboBoxStop.Items"),
            resources.GetString("comboBoxStop.Items1")});
            resources.ApplyResources(this.comboBoxStop, "comboBoxStop");
            this.comboBoxStop.Name = "comboBoxStop";
            // 
            // stopBit_label
            // 
            resources.ApplyResources(this.stopBit_label, "stopBit_label");
            this.stopBit_label.Name = "stopBit_label";
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Items.AddRange(new object[] {
            resources.GetString("comboBoxBaud.Items"),
            resources.GetString("comboBoxBaud.Items1")});
            resources.ApplyResources(this.comboBoxBaud, "comboBoxBaud");
            this.comboBoxBaud.Name = "comboBoxBaud";
            // 
            // baud_label
            // 
            resources.ApplyResources(this.baud_label, "baud_label");
            this.baud_label.Name = "baud_label";
            // 
            // comboBoxCom
            // 
            this.comboBoxCom.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxCom, "comboBoxCom");
            this.comboBoxCom.Name = "comboBoxCom";
            // 
            // com_label
            // 
            resources.ApplyResources(this.com_label, "com_label");
            this.com_label.Name = "com_label";
            // 
            // comGrupBox
            // 
            this.comGrupBox.Controls.Add(this.browseButton);
            this.comGrupBox.Controls.Add(this.browseText);
            this.comGrupBox.Controls.Add(this.wAddressBox);
            this.comGrupBox.Controls.Add(this.writeButton);
            this.comGrupBox.Controls.Add(this.goTexbox);
            this.comGrupBox.Controls.Add(this.goToButton);
            this.comGrupBox.Controls.Add(this.textBox2);
            this.comGrupBox.Controls.Add(this.saveButton);
            this.comGrupBox.Controls.Add(this.lengthTextbox);
            this.comGrupBox.Controls.Add(this.addressTextBox);
            this.comGrupBox.Controls.Add(this.lengthLabel);
            this.comGrupBox.Controls.Add(this.addressLabel);
            this.comGrupBox.Controls.Add(this.rdmemoryButton);
            this.comGrupBox.Controls.Add(this.butongetid);
            this.comGrupBox.Controls.Add(this.buttonClear);
            this.comGrupBox.Controls.Add(this.getVersionButton);
            this.comGrupBox.Controls.Add(this.buttonGetHelp);
            resources.ApplyResources(this.comGrupBox, "comGrupBox");
            this.comGrupBox.Name = "comGrupBox";
            this.comGrupBox.TabStop = false;
            // 
            // browseButton
            // 
            resources.ApplyResources(this.browseButton, "browseButton");
            this.browseButton.Name = "browseButton";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // browseText
            // 
            resources.ApplyResources(this.browseText, "browseText");
            this.browseText.Name = "browseText";
            // 
            // wAddressBox
            // 
            resources.ApplyResources(this.wAddressBox, "wAddressBox");
            this.wAddressBox.Name = "wAddressBox";
            // 
            // writeButton
            // 
            resources.ApplyResources(this.writeButton, "writeButton");
            this.writeButton.Name = "writeButton";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // goTexbox
            // 
            resources.ApplyResources(this.goTexbox, "goTexbox");
            this.goTexbox.Name = "goTexbox";
            // 
            // goToButton
            // 
            resources.ApplyResources(this.goToButton, "goToButton");
            this.goToButton.Name = "goToButton";
            this.goToButton.UseVisualStyleBackColor = true;
            this.goToButton.Click += new System.EventHandler(this.goToButton_Click);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // lengthTextbox
            // 
            resources.ApplyResources(this.lengthTextbox, "lengthTextbox");
            this.lengthTextbox.Name = "lengthTextbox";
            // 
            // addressTextBox
            // 
            resources.ApplyResources(this.addressTextBox, "addressTextBox");
            this.addressTextBox.Name = "addressTextBox";
            // 
            // lengthLabel
            // 
            resources.ApplyResources(this.lengthLabel, "lengthLabel");
            this.lengthLabel.Name = "lengthLabel";
            // 
            // addressLabel
            // 
            resources.ApplyResources(this.addressLabel, "addressLabel");
            this.addressLabel.Name = "addressLabel";
            // 
            // rdmemoryButton
            // 
            resources.ApplyResources(this.rdmemoryButton, "rdmemoryButton");
            this.rdmemoryButton.Name = "rdmemoryButton";
            this.rdmemoryButton.UseVisualStyleBackColor = true;
            this.rdmemoryButton.Click += new System.EventHandler(this.rdmemoryButton_Click);
            // 
            // butongetid
            // 
            resources.ApplyResources(this.butongetid, "butongetid");
            this.butongetid.Name = "butongetid";
            this.butongetid.UseVisualStyleBackColor = true;
            this.butongetid.Click += new System.EventHandler(this.butongetid_Click);
            // 
            // buttonClear
            // 
            resources.ApplyResources(this.buttonClear, "buttonClear");
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // getVersionButton
            // 
            resources.ApplyResources(this.getVersionButton, "getVersionButton");
            this.getVersionButton.Name = "getVersionButton";
            this.getVersionButton.UseVisualStyleBackColor = true;
            this.getVersionButton.Click += new System.EventHandler(this.getVersionButton_Click);
            // 
            // buttonGetHelp
            // 
            resources.ApplyResources(this.buttonGetHelp, "buttonGetHelp");
            this.buttonGetHelp.Name = "buttonGetHelp";
            this.buttonGetHelp.UseVisualStyleBackColor = true;
            this.buttonGetHelp.Click += new System.EventHandler(this.buttonGetHelp_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectionBox);
            this.Controls.Add(this.comGrupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.connectionBox.ResumeLayout(false);
            this.connectionBox.PerformLayout();
            this.comGrupBox.ResumeLayout(false);
            this.comGrupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox connectionBox;
        private System.Windows.Forms.Label com_label;
        private System.Windows.Forms.ComboBox comboBoxCom;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.Label baud_label;
        private System.Windows.Forms.ComboBox comboBoxPartiy;
        private System.Windows.Forms.Label parityLabel;
        private System.Windows.Forms.ComboBox comboBoxStop;
        private System.Windows.Forms.Label stopBit_label;
        private System.Windows.Forms.Button disconButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox comGrupBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button getVersionButton;
        private System.Windows.Forms.Button buttonGetHelp;
        private System.Windows.Forms.Button butongetid;
        private System.Windows.Forms.Button rdmemoryButton;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox lengthTextbox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button goToButton;
        private System.Windows.Forms.TextBox goTexbox;
        private System.Windows.Forms.TextBox browseText;
        private System.Windows.Forms.TextBox wAddressBox;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

