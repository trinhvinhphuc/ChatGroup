using System.Net.Sockets;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.Json;
using System.Text;
using System.Windows.Forms;
using System;

namespace GroupClient
{
    public partial class Client : Form
    {
        bool active = true;
        IPEndPoint ipe;
        Socket client;
        public Client()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            ipe = new IPEndPoint(IPAddress.Parse(ipBox.Text), Int32.Parse(portBox.Text));
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipe);

            Common.Login login = new Common.Login(usernameBox.Text, passwordBox.Text);

            String loginJson = JsonSerializer.Serialize(login);
            Common.Json json = new Common.Json (1, loginJson);
            sendJson(json);
            threadStart();
        }
        private void sendJson(Common.Json json)
        {
            String message = JsonSerializer.Serialize(json);
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(message);

            client.Send(data, data.Length, SocketFlags.None);
        }
        private void appendInTextBox(TextBox textBox, String text)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action<TextBox, String>(appendInTextBox), new object[] { textBox, text });
                return;
            }
            textBox.AppendText(text);
            textBox.AppendText(Environment.NewLine);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Common.Message messageJson = new Common.Message(usernameBox.Text, toBox.Text, messageBox.Text);
            String message = JsonSerializer.Serialize(messageJson);
            Common.Json stringJson = new Common.Json(4, message);
            sendJson(stringJson);
        }
        private void changeButtonEnable(Button btn, bool enable)
        {
            btn.BeginInvoke(new MethodInvoker(() =>
            {
                btn.Enabled = enable;
            }));
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Common.Logout logout = new Common.Logout(usernameBox.Text);
            Common.Json json = new Common.Json(5, JsonSerializer.Serialize(logout));
            sendJson(json);
        }
        private void signinButton_Click(object sender, EventArgs e)
        {
            ipe = new IPEndPoint(IPAddress.Parse(ipBox.Text), Int32.Parse(portBox.Text));
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipe);

            Common.Login login = new Common.Login(usernameBox.Text, passwordBox.Text);

            String loginJson = JsonSerializer.Serialize(login);
            Common.Json json = new Common.Json(6, loginJson);
            sendJson(json);
            threadStart();            
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if ( client != null && ipe != null )
            {
                Common.Json close = new Common.Json(10, "CLOSE");
                sendJson(close);
            }
            
            active = false;
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            Environment.Exit(0);
        }
        private void threadStart()
        {
            var thread = new Thread(() =>
            {
                do
                {
                    byte[] data = new byte[1024];
                    int recv = client.Receive(data);
                    if (recv == 0) continue;
                    String message = Encoding.ASCII.GetString(data, 0, recv);
                    Common.Json? notification = JsonSerializer.Deserialize<Common.Json?>(message);
                    if (notification != null)
                    {
                        switch (notification.type)
                        {
                            case 3:
                                switch (notification.json.ToUpper())
                                {
                                    case "LOGIN SUCCESS":
                                        MessageBox.Show("Login successes!!", "Notification");
                                        changeButtonEnable(loginButton, false);
                                        changeButtonEnable(signinButton, false);
                                        changeButtonEnable(logoutButton, true);
                                        break;
                                    case "LOGIN FAILED":
                                        MessageBox.Show("Login failed!!", "Notification");
                                        break;
                                    case "SIGNIN SUCCESS":
                                        MessageBox.Show("Signin successes!!", "Notification");
                                        changeButtonEnable(loginButton, false);
                                        changeButtonEnable(signinButton, false);
                                        changeButtonEnable(logoutButton, true);
                                        break;
                                    case "SIGNIN FAILED":
                                        MessageBox.Show("Signin failed!!", "Notification");
                                        break;
                                    case "SEND FAILED":
                                        appendInTextBox(messagesBox, "*Your message unsuccessfully send*");
                                        break;
                                    case "LOGOUT SUCCESS":
                                        MessageBox.Show("Logout successes!!", "Notification");
                                        changeButtonEnable(loginButton, true);
                                        changeButtonEnable(signinButton, true);
                                        changeButtonEnable(logoutButton, false);
                                        active = false;
                                        break;
                                    case "LOGOUT FAILED":
                                        MessageBox.Show("Logout failed!!", "Notification");
                                        break;
                                }                                                             
                                break;
                            case 4:
                                Common.Message? mess = JsonSerializer.Deserialize<Common.Message?>(notification.json);
                                if (mess != null)
                                {
                                    appendInTextBox(messagesBox, mess.fromUsername + ": " + mess.message);
                                }
                                break;
                        }
                    }
                }
                while (active);
            });
            thread.Start();
        }
    }
}