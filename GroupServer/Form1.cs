using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics;

namespace GroupServer
{
    public partial class Server : Form
    {
        bool active = true;
        String IP = null, message;
        IPEndPoint iep;
        Socket server, client;
        Dictionary<string, string> USER;
        Dictionary<string, Socket> CLIENT;
        Dictionary<string, List<string>> GROUP;
        public Server()
        {
            InitializeComponent();
        }
        private void Server_Load(object sender, EventArgs e)
        {
            var host = Dns.GetHostByName(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.ToString().Contains('.'))
                {
                    IP = ip.ToString();
                }
            }
            if (IP == null)
            {
                message = "No network adapters with an IPv4 address in the system!";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }
            ipBox.Text = IP;

            userInitialize();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            var thread = new Thread(() =>
            {
                iep = new IPEndPoint(IPAddress.Parse(IP), Int32.Parse(portBox.Text));
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                message = "Start accept connect from client!";
                appendInTextBox(messagesBox, message);
                changeButtonEnable(startButton, false);
                changeButtonEnable(cancelButton, true);

                server.Bind(iep);
                server.Listen(10);

                bool flag = false;
                do
                {
                    client = server.Accept();
                    byte[] data = new byte[1024];
                    int recv = client.Receive(data);
                    if (recv == 0) continue;
                    String s = Encoding.ASCII.GetString(data, 0, recv);

                    Common.Json info = JsonSerializer.Deserialize<Common.Json>(s);

                    if (info != null)
                    {
                        switch (info.type)
                        {
                            case 1:
                                Common.Login login = JsonSerializer.Deserialize<Common.Login>(info.json);
                                foreach (var account in USER)
                                {
                                    if (account.Key == login.name && account.Value == login.password && !CLIENT.ContainsKey(login.name))
                                    {
                                        flag = true;
                                        Common.Json notification = new Common.Json(3, "LOGIN SUCCESS");                sendJson(notification, client);
                                        appendInTextBox(messagesBox, login.name + " logged in!");

                                        CLIENT.Add(login.name, client);
                                        RecvClient(login.name, client);
                                        break;
                                    }
                                }
                                if (flag == false)
                                {
                                    Common.Json notification = new Common.Json(3, "LOGIN FAILED");
                                    sendJson(notification, CLIENT[login.name]);
                                    appendInTextBox(messagesBox, login.name + " can not login!");
                                }
                                break;
                            case 6:
                                Common.Login signin = JsonSerializer.Deserialize<Common.Login>(info.json);
                                if (signin != null && signin.name != null && !USER.ContainsKey(signin.name) && !CLIENT.ContainsKey(signin.name))
                                {
                                    Common.Json notification = new Common.Json(3, "SIGNIN SUCCESS");
                                    sendJson(notification, client);
                                    appendInTextBox(messagesBox, signin.name + " signed in!");

                                    CLIENT.Add(signin.name, client);
                                    USER.Add(signin.name, signin.password);
                                    RecvClient(signin.name, client);
                                }
                                else
                                {
                                    Common.Json notification = new Common.Json(3, "SIGNIN FAILED");
                                    sendJson(notification, client);
                                    appendInTextBox(messagesBox, signin.name + " can not signin!");
                                }
                                break;
                        }
                        
                    }
                }
                while (active);
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                server.Close();
            });
            thread.Start();
        }
        private void RecvClient(String username, Socket client)
        {
            var thread = new Thread(() =>
            {
                bool threadActive = true;
                do
                {
                    byte[] data = new byte[1024];
                    int recv = client.Receive(data);
                    if (recv > 0)
                    {
                        String message = Encoding.ASCII.GetString(data);
                        message = message.Replace("\0", string.Empty);
                        Common.Json? jsonString = JsonSerializer.Deserialize<Common.Json?>(message);
                        switch (jsonString.type)
                        {
                            case 4:
                                Common.Message? mess = JsonSerializer.Deserialize<Common.Message?>(jsonString.json);
                                if (mess != null && CLIENT.ContainsKey(mess.toUsername))
                                {
                                    appendInTextBox(messagesBox, mess.fromUsername + " to " + mess.toUsername + ": " + mess.message);
                                    Socket receiver = CLIENT[mess.toUsername];
                                    data = Encoding.ASCII.GetBytes(message);
                                    receiver.Send(data, data.Length, SocketFlags.None);
                                }
                                else if (mess != null && GROUP.ContainsKey(mess.toUsername))
                                {
                                    if (GROUP[mess.toUsername].Contains(mess.fromUsername))
                                    {
                                        appendInTextBox(messagesBox, mess.fromUsername + " to " + mess.toUsername + ": " + mess.message);
                                        foreach(String account in GROUP[mess.toUsername])
                                        {
                                            if (CLIENT.ContainsKey(account))
                                            {
                                                Socket receiver = CLIENT[account];
                                                data = Encoding.ASCII.GetBytes(message);
                                                receiver.Send(data, data.Length, SocketFlags.None);
                                            }
                                        }                          
                                    }
                                    else
                                    {
                                        Common.Json notification = new Common.Json(3, "SEND FAILED");
                                        sendJson(notification, CLIENT[mess.fromUsername]);
                                        appendInTextBox(messagesBox, mess.fromUsername + " unsuccessfully send a message!");
                                    }
                                }
                                break;
                            case 5:
                                Common.Logout? logout = JsonSerializer.Deserialize<Common.Logout?>(jsonString.json);
                                if (logout != null && logout.username != null && CLIENT.ContainsKey(logout.username))
                                {
                                    Common.Json notification = new Common.Json(3, "LOGOUT SUCCESS");
                                    sendJson(notification, CLIENT[logout.username]);
                                    appendInTextBox(messagesBox, logout.username + " logged out!");
                                    CLIENT.Remove(logout.username);
                                }
                                else
                                {
                                    Common.Json notification = new Common.Json(3, "LOGOUT FAILED");
                                    sendJson(notification, CLIENT[logout.username]);
                                    appendInTextBox(messagesBox, logout.username + " can not logout!");
                                }
                                break;
                            case 10:
                                client.Shutdown(SocketShutdown.Both);
                                client.Close();
                                threadActive = false;
                                break;
                        }
                    }                    
                }
                while(threadActive);
            });
            thread.Start();
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            active = false;
            //server.Close();
            Environment.Exit(0);
        }

        private void sendJson(Common.Json json, Socket client)
        {
            String message = JsonSerializer.Serialize(json);
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(message);

            client.Send(data, data.Length, SocketFlags.None);
        }
        private void changeButtonEnable(Button btn, bool enable)
        {
            btn.BeginInvoke(new MethodInvoker(() =>
            {
                btn.Enabled = enable;
            }));
        }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private void userInitialize()
        {
            CLIENT = new Dictionary<string, Socket>();
            GROUP = new Dictionary<string, List<string>>();
            USER = new Dictionary<string, string>();

            for (char uName = 'A'; uName <= 'Z'; uName++)
            {
                String pass = "123";
                USER.Add(uName.ToString(), pass);
            }

            for (int i = 0; i < 5; i++)
            {
                List<string> groupUser = new List<string>();
                for (byte j = 0; j < 3; j++)
                {
                    char u = (Char)('A' + 3 * i + j);
                    groupUser.Add(u.ToString());
                }
                GROUP.Add("G" + i.ToString(), groupUser);
            }
        }
    }
}