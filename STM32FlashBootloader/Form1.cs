using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM32FlashBootloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[] receivedData = new byte[0];

        public enum BootLoaderCommand : byte
        {
            GetHelp         = 0x00,
            GetVersion      = 0x01,
            GetID           = 0x02,
            ReadMemory      = 0x11,
            Go              = 0x21,
            WriteMemory     = 0x31,
            Erase           = 0x43,
            WriteProtect    = 0x63,
            ReadoutProtect  = 0x82,
            GetCheckSum     = 0xA1
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)
            {
                serialPort1.PortName = comboBoxCom.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBoxBaud.Text);
                serialPort1.DataBits = 8;
                serialPort1.Parity   = (Parity)Enum.Parse(typeof(Parity), comboBoxPartiy.Text, ignoreCase: true);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStop.Text, ignoreCase: true);
                try
                {
                    serialPort1.Open();
                    connectButton.Enabled = false;
                    disconButton.Enabled  = true;
                    comboBoxCom.Enabled = false;
                    comboBoxBaud.Enabled = false;
                    comboBoxPartiy.Enabled = false;
                    comboBoxStop.Enabled = false;

                    

                    textBox2.Clear();
                    progressBar1.Value = 100;
                    textBox1.Text = "Port Açıldı";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String [] ports = SerialPort.GetPortNames();
            comboBoxCom.Items.AddRange(ports);

            connectButton.Enabled = true;
            disconButton.Enabled  = false;

            textBox1.Enabled = false;

        }

        private void disconButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) 
            {
                try
                {
                    serialPort1.Close();
                    progressBar1.Value = 0;
                    textBox1.Text = "Port Kapatıldı";
                    connectButton.Enabled = true;
                    disconButton.Enabled = false;
                    comboBoxCom.Enabled = true;
                    comboBoxBaud.Enabled = true;
                    comboBoxPartiy.Enabled = true;
                    comboBoxStop.Enabled = true;
                    textBox2.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = serialPort1.BytesToRead;

                byte[] buffer = new byte[bytesToRead];

                serialPort1.Read(buffer, 0, bytesToRead);

                string hexOutput = BitConverter.ToString(buffer).Replace("-", " ");

                // if buffer includes 1F which is NACK, break the process
                if (buffer.Contains((byte)0x1F))
                {
                    this.Invoke(new Action(() =>
                    {
                        textBox2.AppendText("NACK received, command failed." + Environment.NewLine);
                    }));
                    return;
                }

                string [] hexOutput_spliit = hexOutput.Split(' ');

                
                if (hexOutput_spliit[0] == "79")
                {
                    hexOutput = string.Join(" ", hexOutput_spliit.Skip(1)); // Remove the first byte (79)
                }

                this.Invoke(new Action(() =>
                {

                    textBox2.AppendText(hexOutput + " ");
                    textBox2.SelectionStart = textBox2.TextLength;
                    textBox2.ScrollToCaret();
                }));
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void getVersionButton_Click(object sender, EventArgs e)
        {
            byte cmd = (byte)BootLoaderCommand.GetVersion;
            SendBootLoaderCommand(cmd,new byte[0]);

            textBox2.AppendText(Environment.NewLine);
        }

        private void buttonGetHelp_Click(object sender, EventArgs e)
        {
            byte cmd = (byte)BootLoaderCommand.GetHelp;
            
            SendBootLoaderCommand(cmd, new byte[0]);
            textBox2.AppendText(Environment.NewLine);
        }
        byte calculateCRC(byte[] data)
        {
            byte crc = 0x00;

            foreach (byte b in data)
            {
                crc ^= b; 
            }
            return crc;
        }
        private void SendBootLoaderCommand(byte cmd, byte[] data)
        {
            List<byte> packet = new List<byte>();
            packet.Add(0x7f); // bootloader header
            packet.Add((byte)(1 + data.Length)); // len = cmd + data
            packet.Add(cmd); // cmd
            packet.AddRange(data);

            byte[] crcInput = packet.Skip(1).ToArray();
            byte crc = calculateCRC(crcInput);

            packet.Add(crc);

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(packet.ToArray(), 0, packet.Count);
                serialPort1.Write("\r");
                serialPort1.Write("\n");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }

        private void butongetid_Click(object sender, EventArgs e)
        {
            byte cmd = (byte)BootLoaderCommand.GetID;
            
            SendBootLoaderCommand(cmd, new byte[0]);
            textBox2.AppendText(Environment.NewLine);
        }

        private void sendReadMemoryData(uint address, byte length)
        {
            byte[] data = new byte[7];
            // address -> msb to lsb
            data[0] = (byte)(address >> 24);
            data[1] = (byte)(address >> 16);
            data[2] = (byte)(address >> 8);
            data[3] = (byte)(address);
            
            byte addressCheckSum = (byte)(data[0] ^ data[1] ^ data[2] ^ data[3]);
            data[4] = addressCheckSum; // Address Checksum
            data[5] = length;
            data[6] = (byte) ~ length;

            byte cmd = (byte)BootLoaderCommand.ReadMemory;
            SendBootLoaderCommand(cmd, data);
        }

        private void rdmemoryButton_Click(object sender, EventArgs e)
        {
            if(addressTextBox.Text == "" || lengthTextbox.Text == "")
            {
                MessageBox.Show("Please enter the address and length", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string address = addressTextBox.Text.Trim();
                if(address.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    address = address.Substring(2);
                }
                uint addressValue = Convert.ToUInt32(address, 16);
                byte length = byte.Parse(lengthTextbox.Text.Trim());

                if(length < 1 || length > 255)
                {
                    MessageBox.Show("Length must be between 1 and 255", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sendReadMemoryData(addressValue, length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message ,"Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                MessageBox.Show("No data to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            saveFileDialog.Filter = "Bin Files (*.bin)|*.bin|Tüm Dosyalar (*.*)|*.*";
            saveFileDialog.Title = "Save File";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) ;
            
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string s = textBox2.Text;
                    string sonuc = (s.Length > 1) ? s.Substring(3) : string.Empty;

                    byte[] data = Encoding.UTF8.GetBytes(sonuc);

                    File.WriteAllBytes(saveFileDialog.FileName,data);
                    MessageBox.Show("Saved Succesfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    sonuc = string.Empty; // Clear the string after saving
                    textBox2.Text = string.Empty; // Clear the text box after saving

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            
        }


        private void goToButton_Click(object sender, EventArgs e)
        {
            if(goTexbox.Text == "")
            {
                MessageBox.Show("Please enter the address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string address = goTexbox.Text.Trim();
                if (address.StartsWith("0x"))
                {
                    address = address.Substring(2);
                }
                uint addressValue = Convert.ToUInt32(address, 16);

                sendGoAddressData(addressValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void sendGoAddressData(uint address)
        {
            byte[] data = new byte[7];
            // address -> msb to lsb
            data[0] = (byte)(address >> 24);
            data[1] = (byte)(address >> 16);
            data[2] = (byte)(address >> 8);
            data[3] = (byte)(address);

            byte addressCheckSum = (byte)(data[0] ^ data[1] ^ data[2] ^ data[3]);
            data[4] = addressCheckSum; // Address Checksum

            byte cmd = (byte)BootLoaderCommand.Go;
            SendBootLoaderCommand(cmd, data);
        }

        private void SendWriteAddressData(uint address)
        {
            byte[] data = new byte[9];
            
            byte[] lengthBytes = new byte[4];
            int length = binData.Length;
            lengthBytes[0] = (byte)(length >> 24 & 0xFF) ;
            lengthBytes[1] = (byte)(length >> 16 & 0xFF);
            lengthBytes[2] = (byte)(length >> 8 & 0xFF);
            lengthBytes[3] = (byte)(length & 0xFF);

            // address -> msb to lsb
            data[0] = (byte)(address >> 24 & 0xFF);
            data[1] = (byte)(address >> 16 & 0xFF);
            data[2] = (byte)(address >> 8 & 0xFF);
            data[3] = (byte)(address & 0xFF);

            byte addressCheckSum = (byte)(data[0] ^ data[1] ^ data[2] ^ data[3]); 
            data[4] = addressCheckSum; // Address Checksum

            data[5] = lengthBytes[0];
            data[6] = lengthBytes[1];
            data[7] = lengthBytes[2];
            data[8] = lengthBytes[3];

            byte cmd = (byte)BootLoaderCommand.WriteMemory;

            SendBootLoaderCommand(cmd, data);
            sendDataBlocks(address);

        }

        
        private void sendBytesToSTM32(byte[]data)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(data, 0, data.Length);
            }
            else
            {
                MessageBox.Show("Serial Port is not open !");
            } 
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            if (wAddressBox.Text == "" || browseText.Text == "")
            {
                MessageBox.Show("Please enter bin file and address ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string address = wAddressBox.Text.Trim();
                if (address.StartsWith("0x"))
                {
                    address = address.Substring(2);
                }
                uint addressValue = Convert.ToUInt32(address, 16);

                SendWriteAddressData(addressValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        string binFilePath;
        byte[] binData;

        private void sendDataBlocks(uint startAddress)
        {
            int offset = 0;
            while (offset < binData.Length)
            {
                int remaningBytes = binData.Length - offset;
                int currenBloackSize = remaningBytes > 256 ? 256 : remaningBytes;

                byte N = (byte)(currenBloackSize - 1);            //   -> n = max(255)
                byte[] packet = new byte[currenBloackSize + 2];   //   -> packet = 258 - N - checksum

                packet[0] = (byte)N;

                Array.Copy(binData, offset, packet, 1, currenBloackSize);

                byte checkSum = N;
                for (int i = 1; i <= currenBloackSize; i++)
                {
                    checkSum ^= packet[i];
                }
                packet[packet.Length - 1] = checkSum;

                sendBytesToSTM32(packet);

                offset += currenBloackSize;
                startAddress += (uint)currenBloackSize;

                System.Threading.Thread.Sleep(30);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary files (*.bin) | *.bin";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                browseText.Text = openFileDialog.FileName;
                binFilePath = browseText.Text;
                binData = File.ReadAllBytes(binFilePath);
            }
        }
    }
}
