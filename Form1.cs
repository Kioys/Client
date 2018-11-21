using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Media;

namespace Client
{
    public partial class Form1 : Form
    {
        string path = Application.StartupPath;
        Socket s;
        SoundPlayer sp;
        NotifyIcon notiBallon = new NotifyIcon();
        delegate void StringArgReturningVoidDelegate(string text);
        byte[] recvBuffer = new byte[1024];
        byte[] sendBuffer = new byte[1024];
        string[] rMsg;
        string finalMessage;
        string uUsername = "Default";

        public Form1()
        {
            InitializeComponent();

        }

        //funcion del boton que conecta al servidor con los parametros del usuario
        private void connectButton_Click(object sender, EventArgs e)
        {
            //Instancia y Reproducion de sonido
            PlaySound("Ping");

            //Visual updates
            connectButton.Enabled = false;
            hostLabel.Text = String.Format("Host:   {0}", uHostTB.Text);
            portLabel.Text = String.Format("Port:   {0}", uPortTB.Text);

            //Instanciar el thread que manejara los mensajes recividos con la funcion Recv()
            Thread recvT = new Thread(new ThreadStart(Recv));
            
            try
            {
                statusLabel.Text = "Status: Connecting"; //Visual update
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Unspecified); //Crear socket
                s.Connect(uHostTB.Text, Convert.ToInt32(uPortTB.Text)); //Conectarse al host

                //Enpaquetar la clave del usuario para enviarla al servidor
                sendBuffer = Encoding.ASCII.GetBytes(sPasswordTB.Text);
                s.Send(sendBuffer);

                // si SecurityAnsw() es distinto de false, se inicia el recvT thread
                if (SecurityAnsw() == false)
                {
                    sp.Stop();
                    statusLabel.Text = "Status: Rejected";
                    displayRTB.Text = "[X] CONNECTION REJECTED - [WRONG PASSWORD]";
                    s.Close();
                    MessageBox.Show("Contraseña rechazada por el servidor", "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    connectButton.Enabled = true;
                }
                else
                {
                    if (s.Connected)
                    {
                        recvT.Start(); //Thread Start

                        //Visual updates
                        sp.Stop();
                        statusLabel.Text = "Status: Connected!";
                        displayRTB.Text = String.Empty;
                        String welcomeMessage = String.Format("[O] CONNECTED:\n\n      Host:     {0}\n      Port:     {1}\n      Username: {2}\n\n~~WELCOME TO THE WILD~~\n", uHostTB.Text, uPortTB.Text, uUsernameTB.Text);
                        displayRTB.AppendText(welcomeMessage);
                        uUsername = uUsernameTB.Text;
                        statusLight.BackColor = Color.LimeGreen;
                        connectButton.Enabled = false;
                    }
                }
            }
            catch(SocketException ex)
            {
                sp.Stop();
                MessageBox.Show(ex.Message, String.Format("ERROR [{0}]", ex.ErrorCode), MessageBoxButtons.OK,MessageBoxIcon.Error);
                connectButton.Enabled = true;
                statusLabel.Text = "Status: Disconnected";
            }
        }

        //Respuesta de seguridad de parte del servidor
        bool SecurityAnsw()
        {
            while (true)
            {
                Array.Clear(recvBuffer, 0, recvBuffer.Length);
                s.Receive(recvBuffer);
                string answer = Encoding.ASCII.GetString(recvBuffer);

                if (answer.Contains("1"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //funcion que desempaqueta los packets recividos por parte del servidor
        private void Recv()
        {
            while (true)
            {
                try
                {
                    if (s.Connected)
                    {
                        //Limpear el recvBuffer y recivir el paquete
                        Array.Clear(recvBuffer, 0, recvBuffer.Length);
                        s.Receive(recvBuffer);

                        //Traducir y desempaquetar el packet
                        rMsg = Encoding.UTF8.GetString(recvBuffer).Split('~');
                        finalMessage = rMsg[1];
                        RecvHandler(finalMessage);

                        //Reproduccion de sonidos notificando cuando se recive un packet, solo si la ventana esta minimizada o desenfocada
                        if (WindowState == FormWindowState.Minimized || Form1.ActiveForm != GetContainerControl())
                        {
                            PlaySound("unfocusnotisound");
                        }
                        else
                        {
                            PlaySound("focusnotisound");
                        }
                    }    
                }
                catch (SocketException ex)
                {
                    if(ex.Message.Contains("Se ha anulado una conex"))
                    {
                        break;
                    }
                    else if (ex.Message.Contains("Se ha forzado la interrupci"))
                    {
                        s.Close();
                        MessageBox.Show(ex.Message, String.Format("ERROR [{0}]", ex.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        break;
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, String.Format("ERROR [{0}]", ex.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Thread.Sleep(1);
            }

        }

        //Funcion que imprime el paquete recivido en el displayRTB (RichTextBox)
        private void RecvHandler(string text)
        {
            if (this.displayRTB.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(RecvHandler);
                if (text != null)
                {
                    this.Invoke(d, new object[] { text });
                }
            }
            else
            {
                if (text != null)
                {
                    displayRTB.AppendText("\n" + text);
                }
            }
        }

        //Funcion que envia un paquete al servidor con el mensaje del usuario
        private void Send(string msg)
        {
            try
            {
                //Preparar el mensaje
                string pMsg = String.Format("~[{2}:{3}:{4}][{0}]: {1}~", uUsername, msg, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, Convert.ToInt32(DateTime.Now.TimeOfDay.Seconds));

                //limpear el sendBuffer, enpaquetar el mensaje y enviarlo
                Array.Clear(sendBuffer,0,sendBuffer.Length);
                sendBuffer = Encoding.ASCII.GetBytes(pMsg);
                s.Send(sendBuffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Cuando se presione enter dentro del messageTB (TextBox) se ejecute la funcion para enviar el mensaje
        private void messageTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if(s != null)
                {
                    if (s.Connected)
                    {
                        //Imprimir en el displayRTB el mensaje que se envio al servidor
                        String uText = String.Format("\n[{2}:{3}:{4}][{0}]: {1}", uUsername, messageTB.Text, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, Convert.ToInt32(DateTime.Now.TimeOfDay.Seconds));
                        displayRTB.AppendText(uText);

                        //Ejecutar la funcion Send() y limpiar el messageTB
                        Send(messageTB.Text);
                        messageTB.Text = String.Empty;
                    }
                    else
                    {
                        MessageBox.Show("You are not connected to a server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            } 
        }

        //Cuando se cierra la aplicacion, envia un mensaje y cierra el socket actual
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(s != null)
            {
                try
                {
                    string pMsg = String.Format("~[SERVER] {0} ah salido del chat~PARAM_EXIT", uUsername);
                    Array.Clear(sendBuffer, 0, sendBuffer.Length);
                    sendBuffer = Encoding.ASCII.GetBytes(pMsg);
                    s.Send(sendBuffer);
                    s.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Funcion para hacer un auto scroll down
        private void displayRTB_TextChanged(object sender, EventArgs e)
        {
            displayRTB.SelectionStart = displayRTB.Text.Length;
            displayRTB.ScrollToCaret();
            if(displayRTB.TextLength == displayRTB.MaxLength)//si el displayRTB alcanzo su maximo length, que se limpie
            {
                displayRTB.Text = String.Empty;
                displayRTB.AppendText("***CHAT WAS EREASED [CAUSE: it reached its maximum length]***");
            }
        }

        //Funcion para reproducir un sonido dentro de la carpeta de sonidos
        void PlaySound(string name)
        {
            string soundPath = String.Format(@"{0}\sounds\{1}.wav", path, name); ;
            sp = new SoundPlayer(soundPath);
            sp.Play();
        }

        //COMODIDAD DEL USUARIO
        private void sPasswordTB_Click(object sender, EventArgs e) => sPasswordTB.SelectAll();

        private void uHostTB_Click(object sender, EventArgs e) => uHostTB.SelectAll();

        private void uPortTB_Click(object sender, EventArgs e) => uPortTB.SelectAll();

        private void uUsernameTB_Click_1(object sender, EventArgs e) => uUsernameTB.SelectAll();
    }
}
