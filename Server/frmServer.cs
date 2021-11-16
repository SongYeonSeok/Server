using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using myLibrary;



namespace Server
{
    public partial class frmServer : MetroFramework.Forms.MetroForm
    {
        //===================== < DB Part > =======================
        // MSSQL 연동하기
        // DataBase 접속 경로
        public static string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\송연석\Documents\SenserDB.mdf;Integrated Security=True;Connect Timeout=30";

        // DB 연결 완료
        SqlDB sqldb = new SqlDB(ConnString);


        public frmServer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 온도 데이터 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TempTable_Click(object sender, EventArgs e)
        {
            string sql = "select * from Temperature";
            sqldb.Render(sql);
        }
        /// <summary>
        /// 습도 데이터 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoistTable_Click(object sender, EventArgs e)
        {
            string sql = "select * from Moisture";
            sqldb.Render(sql);
        }

        // 날짜 입력
        DateTime dt = DateTime.Now;
        void CmdTypes(string c)
        {
            string sql1 = "";
            string sql2 = "";
            int type;

            try
            {
                type = int.Parse(mylib.GetToken(0, c, ','));
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }


            switch(type)
            {
                case 1:     // 온습도 (X,XXXX,X,X)
                    // tret1, tret2 : 센서 1, 센서 2
                    // tret1, tret2 == -1 : 오류
                    // tret1, tret2 == 1 : 정상
                    int moist = int.Parse(mylib.GetToken(1, c, ','));
                    double temp = double.Parse(mylib.GetToken(2, c, ',')) / 10 * 2;
                    int tret1 = int.Parse(mylib.GetToken(3, c, ','));
                    int tret2 = int.Parse(mylib.GetToken(4, c, ','));
                    string date = dt.ToString("yyyy.MM.dd HH:mm:s");

                    sql1 = $"INSERT INTO Temperature (temp, tret1, tret2, date) VALUE ({temp}, {tret1}, {tret2}, {date})";
                    sql2 = $"INSERT INTO Moisture (temp, tret1, tret2, date) VALUE ({moist}, {tret1}, {tret2}, {date})";
                    sqldb.Run(sql1);
                    sqldb.Run(sql2);
                    break;
            }
        }

        //TcpClient[] tcpArr = new TcpClient[5];
        //tcpArr[0] = android; //폰
                // 온도
                   // 습도
                   // 가습기

        //===========================================================================


        delegate void cbAddText(string str, int i);
        void AddText(string str, int i)
        {
            if (tbServer.InvokeRequired || statusStrip1.InvokeRequired)
            {
                cbAddText cb = new cbAddText(AddText);
                object[] obj = { str, i };
                Invoke(cb, obj);
            }
            else
            {
                if (i == 1)
                    tbServer.Text += str;
                else if (i == 2)
                    sbClientList.DropDownItems.Add(str);
            }
        }

        //========================== < 서버 Part > ============================
        Socket sock = null;
        TcpClient[] tcp = new TcpClient[10];
        TcpListener listen = null;
        Thread threadServer = null;
        Thread threadRead = null;
        int CurrentClientNum = 0;

        /// <summary>
        /// 서버가 시작될 때 listen을 시작하여 연결이 될 때까지 대기시킨다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            if (listen != null)
            {
                if (MessageBox.Show("서버를 다시 시작하시겠습니까?.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    listen.Stop();
                    if (threadServer != null) threadServer.Abort();
                    if (threadRead != null) threadRead.Abort();
                }
            }
            listen = new TcpListener(int.Parse(tbServerPort.Text));
            listen.Start();
            AddText($"서버가 [{tbServerPort.Text}] Port에서 시작되었습니다.\r\n", 1);

            threadServer = new Thread(ServerProcess);
            threadServer.Start();
        }

        /// <summary>
        /// Connect 요구 처리 프로세스
        /// </summary>
        void ServerProcess()  // Connect 요구 처리 쓰레드
        {
            while (true)
            {
                if (listen.Pending())
                {
                    if (CurrentClientNum == 9) break; // Process over

                    tcp[CurrentClientNum] = listen.AcceptTcpClient(); // 세션 수립
                    string sLabel = tcp[CurrentClientNum].Client.RemoteEndPoint.ToString();  // Client IP Address : Port(Session)
                    AddText($"Client [{sLabel}] 로부터 접속되었습니다\r\n", 1);
                    //sbClientList.DropDownItems.Add(sLabel);
                    AddText(sLabel, 2);
                    sbLabel1.Text = sLabel;


                    tbRedStatus.Text = "Connect";
                    tbYellowStatus.Text = "Connect";
                    tbGreenStatus.Text = "Connect";

                    if (threadRead == null)
                    {
                        threadRead = new Thread(ReadProcess);
                        threadRead.Start();
                    }
                    CurrentClientNum++;
                }
                Thread.Sleep(100);
            }

        }

        /// <summary>
        /// Read 처리 프로세스
        /// </summary>
        void ReadProcess() // Multi Client : CurrentClinrNum
        {
            byte[] bArr = new byte[512];
            while (true)
            {
                for (int i = 0; i < CurrentClientNum; i++)
                {
                    NetworkStream ns = tcp[i].GetStream();
                    if (ns.DataAvailable)
                    {
                        int n = ns.Read(bArr, 0, 512); bArr[n] = 0;
                        byte[] aa = Encoding.Convert(Encoding.UTF8, Encoding.Default, bArr);
                        // CmdTypes(Encoding.Default.GetString(aa));
                        AddText(Encoding.Default.GetString(aa, 0, aa.Length), 1);
                        //========= < 프로토콜 설정하게 된다면 > =========
                        // 프로토콜 양식 합의 후 지정


                        //013560 == 센서타입(온도) 센서번호(1) 센서값(35.60) :: 명령어 프로토콜 안정했네
                        // if 문 혹은 함수 >> table 명 자동 반환
                        //string sql = $"insert value(val1, val2, val3) into {테이블명} (컬1, 컬2, 컬3...)";
                        //sqldb.run(sql);
                        //AddText(Encoding.Default.GetString(bArr,0,n), 1);
                    }
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 서버에서 클라이언트로 값을 전송한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pmnuSendServerText_Click(object sender, EventArgs e)
        {
            try
            {
                string str = (tbServer.SelectedText == "") ? tbServer.Text : tbServer.SelectedText;
                byte[] bArr = Encoding.Default.GetBytes(str);
                byte[] cArr = Encoding.Convert(Encoding.Default, Encoding.UTF8, bArr);
                tcp[GetTcpIndex()].Client.Send(cArr);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        Thread threadClientRead = null;
        

        void ClientReadProcess()
        {
            byte[] bArr = new byte[512];
            while (true)
            {
                if (sock.Available > 0)
                {
                    int n = sock.Receive(bArr);
                    AddText($"{Encoding.Default.GetString(bArr, 0, n)}", 2);
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 서버와 클라이언트와 연결을 하게 되면, 클라이언트 목록을 추가한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbClientList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbClientList.Text = e.ClickedItem.Text;
        }

        /// <summary>
        /// TCP List 중 선택되어 있는 리스트 인덱스를 반환한다.
        /// </summary>
        /// <returns></returns>
        int GetTcpIndex() // Tcp List 중 선택되어 있는 리스트 인덱스를 반환
        {
            for (int i = 0; i < CurrentClientNum; i++)
            {
                if (tcp[i].Client.RemoteEndPoint.ToString() == sbClientList.Text)
                    return i;
            }
            return -1;
        }

        //========================================================================================


        //==================================== < HW Control > ===================================
        //==================================== 삭제 예정 =========================================
        // LED Control Method

        string cmd;
        void lightsLED(int type, int options)
        {
            try
            {
                if (type == 0)       // RED LED
                {
                    // Lights Off
                    if (options == 0)
                    {
                        tbRedStatus.Text = "Off";
                        cmd = "0,0";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                    // Lights On
                    else if (options == 1)
                    {
                        tbRedStatus.Text = "On";
                        cmd = "0,1";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                }
                else if (type == 1)     // YELLOW LED
                {
                    // Lights Off
                    if (options == 0)
                    {
                        tbYellowStatus.Text = "Off";
                        cmd = "1,0";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                    // Lights On
                    else if (options == 1)
                    {
                        tbYellowStatus.Text = "On";
                        cmd = "1,1";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                }
                else if (type == 2)     // GREEN LED
                {
                    // Lights Off
                    if (options == 0)
                    {
                        tbGreenStatus.Text = "Off";
                        cmd = "2,0";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                    // Lights On
                    else if (options == 1)
                    {
                        tbGreenStatus.Text = "On";
                        cmd = "2,1";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }
        void lightsLED(string cmd)
        {
            if((cmd.Length > 3) || (cmd.Length < 1))
            {
                return;
            }

            int type = int.Parse(mylib.GetToken(0, cmd, ','));
            int options = int.Parse(mylib.GetToken(1, cmd, ','));

            try
            {
                if (type == 0)       // RED LED
                {
                    // Lights Off
                    if (options == 0)
                    {
                        tbRedStatus.Text = "Off";
                        cmd = "0,0";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                    // Lights On
                    else if (options == 1)
                    {
                        tbRedStatus.Text = "On";
                        cmd = "0,1";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                }
                else if (type == 1)     // YELLOW LED
                {
                    // Lights Off
                    if (options == 0)
                    {
                        tbYellowStatus.Text = "Off";
                        cmd = "1,0";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                    // Lights On
                    else if (options == 1)
                    {
                        tbYellowStatus.Text = "On";
                        cmd = "1,1";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                }
                else if (type == 2)     // GREEN LED
                {
                    // Lights Off
                    if (options == 0)
                    {
                        tbGreenStatus.Text = "Off";
                        cmd = "2,0";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                    // Lights On
                    else if (options == 1)
                    {
                        tbGreenStatus.Text = "On";
                        cmd = "2,1";
                        byte[] bArr = Encoding.Default.GetBytes(cmd);
                        tcp[GetTcpIndex()].Client.Send(bArr);
                    }
                }
            }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
        }

        // Red Lights Control
        private void cbRedOff_CheckedChanged(object sender, EventArgs e)
        {
            lightsLED(0, 0);
        }
        private void cbRedOn_CheckedChanged(object sender, EventArgs e)
        {
            lightsLED(0, 1);
        }

        // Yellow Lights Control
        private void cbYellowOff_CheckedChanged(object sender, EventArgs e)
        {
            lightsLED(1, 0);
        }
        private void cbYellowOn_CheckedChanged(object sender, EventArgs e)
        {
            lightsLED(1, 1);
        }

        // Green Lights Control
        private void cbGreenOff_CheckedChanged(object sender, EventArgs e)
        {
            lightsLED(2, 0);
        }
        private void cbGreenOn_CheckedChanged(object sender, EventArgs e)
        {
            lightsLED(2, 1);
        }


        //===================================================================================

        //================================ < Program Close > ====================================
        /// <summary>
        /// 프로그램을 종료할 때 : 스레드를 모두 종료한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadServer != null) threadServer.Abort();
            if (threadRead != null) threadRead.Abort();
            if (threadClientRead != null) threadClientRead.Abort();
        }

        /// <summary>
        /// 폼 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 안드로이드 - C# - 라즈베리파이 제어
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbServerLog_TextChanged(object sender, EventArgs e)
        {
            string cmd;
            if(mylib.GetToken(0, tbServerLog.Text, ':') == "A")     // 앱에서 전송된 자료
            {   // App -> Pi
                //if(sbClientList.Text != pmnuSendRp.Text)
                //    sbClientList.Text = pmnuSendRp.Text;
                cmd = mylib.GetToken(1, tbServerLog.Text, ':');
                tbServer.Text += $"App : {cmd}";

                // LED
                lightsLED(cmd);
            }
            else if(mylib.GetToken(0, tbServerLog.Text, ':') == "P")    // 라즈베리파이에서 전송된 자료
            {   // Pi -> App
                //if(sbClientList.Text != pmnuSendApp.Text)
                //    sbClientList.Text = pmnuSendApp.Text;
                cmd = mylib.GetToken(1, tbServerLog.Text, ':');
                tbServer.Text += $"Pi : {cmd}";
                byte[] bArr = Encoding.Default.GetBytes(cmd);
                tcp[GetTcpIndex()].Client.Send(bArr);
            }

        }

    }
}
