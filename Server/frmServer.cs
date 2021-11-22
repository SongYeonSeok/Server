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

        #region init settings - AddText(string str, int i)

        int android_count = 0;
        // 기능을 분리하여 표현할 수 있다.
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
                // options
                switch (i)
                {
                    case 1:
                        tbServer.Text += str;
                        break;

                    case 2:
                        if (mylib.GetToken(1, str, ':') == androidIp) { sbClientList.Text = android; }
                        else if (mylib.GetToken(1, str, ':') == raspIp) { sbClientList.Text = rasp; }
                        break;

                    case 3:
                        tbServerLog.Text = str;
                        break;

                    case 4:
                        lbTempNow.Text = $"{str}℃";
                        break;

                    case 5:
                        lbMoistNow.Text = $"{str}%";
                        break;

                    case 6:
                        lbTempTarget.Text = $"{str}℃";
                        break;

                    case 7:
                        lbMoistTarget.Text = $"{str}%";
                        break;

                }
            }
        }

        #endregion

        SqlDB sqldb;

        // DataBase 접속 경로
        public static string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\송연석\Documents\SenserDB.mdf;Integrated Security=True;Connect Timeout=30";


        /// <summary>
        /// 프로그램이 실행되는 즉시 DB 연결 완료!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServer_Load(object sender, EventArgs e)
        {
            // MSSQL 연동하기
            // DB 연결 완료
            sqldb = new SqlDB(ConnString);
        }


        public frmServer()
        {
            InitializeComponent();
        }


        string[] user = new string[10];


        //======================================== <DB 조회> ===========================================
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
        //=================================================================================================

        #region DB 입력 및 전송 CmdRunning(string c)

        // 날짜 입력
        DateTime dt = DateTime.Now;
        string moist = null;
        string temp = null;
        void CmdRunning(string c)
        {
            string sql1 = "";
            string sql2 = "";
            string type;

            try
            {
                type = mylib.GetToken(0, c, ',');
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }


            if (type == "0")  // app -> Pi
            {
                // "0" : Temperature & Moisture
                // 1. app -> server
                moist = mylib.GetToken(1, c, ',');
                temp = mylib.GetToken(2, c, ',');

                AddText($"{temp}", 6);
                AddText($"{moist}", 7);

                try
                {
                    // 2. server -> pi
                    if (sbClientList.Text != rasp)
                    {
                        sbClientList.Text = rasp;
                        string sent2pi = $"{temp},{moist}";
                        byte[] bArr = Encoding.Default.GetBytes(sent2pi);
                        //tcp[GetTcpIndex()].Client.Send(bArr);

                        //int andIdx = 0;
                        // 안드로이드 종료되었을 때 등록하는 방법


                        for (int i = 0; i < CurrentClientNum; i++)
                        {
                            for (int j = 0; j < CurrentClientNum; j++)
                            {
                                if (user[i] == tcp[j].Client.RemoteEndPoint.ToString())
                                {
                                    tcp[i].Client.Send(bArr);//안드로이드에서 처리할 문제 있음!!
                                }
                            }
                            //if (tcp[i].Client.RemoteEndPoint.ToString() == android) andIdx = i;
                        }
                        //tcp[andIdx].Client.Send(bArr);       // 단, 무조건 pi 먼저 연결!
                    }
                }
                catch (Exception e1) { MessageBox.Show(e1.Message); }
            }

            if (type == "1")
            {     // 온습도 (1,X,XXXX,X,X)
                // tret1, tret2 : 센서 1, 센서 2
                // tret1, tret2 == -1 : 오류
                // tret1, tret2 == 1 : 정상
                moist = mylib.GetToken(1, c, ',');
                temp = $"{double.Parse(mylib.GetToken(2, c, ',')) / 10 * 2}";
                string tret1 = mylib.GetToken(3, c, ',');
                string tret2 = mylib.GetToken(4, c, ',');
                string date = dt.ToString("yyyy.MM.dd HH:mm:s");


                // 온습도 표시기 적용
                AddText(temp, 4);
                AddText(moist, 5);

                // db 각 컬럼 데이터타입에 대해 고민 해볼 것
                sql1 = $"INSERT INTO Temperature (temp, tret1, tret2, date) VALUES ('{temp}', '{tret1}', '{tret2}', '{date}')";
                sql2 = $"INSERT INTO Moisture (moist, tret1, tret2, date) VALUES ('{moist}', '{tret1}', '{tret2}', '{date}')";
                sqldb.Run(sql1);
                sqldb.Run(sql2);

                if (threadAndroidSend == null)
                {
                    threadAndroidSend = new Thread(AppSendProcess);
                    threadAndroidSend.Start();
                }
            }
        }

        #endregion


        #region 서버 변수 및 TcpType(string ip_port)

        Socket sock = null;
        TcpClient[] tcp = new TcpClient[10];
        TcpListener listen = null;
        Thread threadServer = null;
        Thread threadRead = null;
        Thread threadAndroidSend = null;
        Thread threadIsConnected = null;
        int CurrentClientNum = 0;



        const string androidIp = "192.168.2.70";    // "192.168.2.44", 58
        string androidPort = null;
        string android = "애플리케이션";
        const string raspIp = "192.168.2.62";       // "192.168.2.62" , 58
        string raspPort = null;
        string rasp = "라즈베리파이";
        

        string TcpType(string ip_port)
        {
            string types = mylib.GetToken(0, ip_port, ':');
            if (types == androidIp)
            {
                androidPort = mylib.GetToken(1, ip_port, ':');
                AddText($"App :{ip_port}", 2);
            }
            else if (types == raspIp)
            {
                raspPort = mylib.GetToken(1, ip_port, ':');
                AddText($"Pi :{ip_port}", 2);
            }

            return types;
        }

        #endregion

        //========================== < 서버 Part > =============================================

        /// <summary>
        /// 서버 -> 클라이언트
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

            if (threadServer != null) threadServer.Abort();
            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            if (threadRead != null) threadRead.Abort();
            threadRead = new Thread(ReadProcess);
            threadRead.Start();

            if (threadAndroidSend != null) threadAndroidSend.Abort();
            threadAndroidSend = new Thread(AppSendProcess);
            threadAndroidSend.Start();

            if (threadIsConnected != null) threadIsConnected.Abort();
            threadIsConnected = new Thread(IsConnected);
            threadIsConnected.Start();
        }

        #region Connect 요구 처리 프로세스 : ServerProcess()

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

                    TcpType(sLabel);
                    sbLabel1.Text = sLabel;

                    // 설명
                    // 하나의 android 기기 당 고정 ip를 설정해 놓았고, 작동할 때마다 세션이 변경되는 현상으로 인해 TcpClient 배열에 하나의 android 고정 ip + 최신 세션이 입력되어야 했다.
                    // 그래서 android_count와 GetToken, tcp[idx].Client.RemoteEndPoint.ToString()을 사용하여 구현하였다.
                    // -- 아이디어 --
                    // android_count는 global 변수로 설정하여 초기값을 0으로 설정하였다. 처음 android이 등록되면 android_count를 1로 설정하도록 구현하였다.
                    // 그리고 mylib.GetToken(0, tcp[CurrentClientNum].Client.RemoteEndPoint.ToString(), ':') (이하 tcp[idx]로 표기) 값은 ip 번호이므로,  
                    // tcp[idx]를 ':'로 구분한 배열에서 첫 번째 값이 android 고정 ip와 같고, android_count가 1일 때
                    // '기존 tcp[처음 입력된 값에 해당하는 인덱스] = tcp[현재 인덱스]'로 작성하고, CurrentClientNum에 1을 더하지 않도록 했다.
                    // 
                    // 이렇게 구현한 결과, 세션이 변경되면서 연결 되더라도, 안드로이드 연결 ip와 세션이 최신화되어 접속된다. (구현 완료)
                    // (글을 다듬을 필요가 있다.)
                    //

                    if (mylib.GetToken(0, tcp[CurrentClientNum].Client.RemoteEndPoint.ToString(), ':') == androidIp && android_count == 1)
                    {// android가 이미 연결되어 있다면, CurrentClientNum은 증가하지 않는다.
                        tcp[CurrentClientNum - 1] = tcp[CurrentClientNum];
                    }
                    else
                    {
                        android_count = 1;
                        CurrentClientNum++;
                    }


                }
                Thread.Sleep(100);
            }

        }

        #endregion


        #region Read 처리 프로세스 : ReadProcess()

        /// <summary>
        /// Read 처리 프로세스
        /// </summary>
        void ReadProcess() // Multi Client : CurrentClinrNum
        {

            while (true)
            {
                // 버퍼 초기화 필요!
                byte[] bArr = new byte[512];
                for (int i = 0; i < CurrentClientNum; i++)
                {
                    NetworkStream ns = tcp[i].GetStream();
                    if (ns.DataAvailable)
                    {
                        int n = ns.Read(bArr, 0, 512); bArr[n] = 0;
                        byte[] aa = Encoding.Convert(Encoding.UTF8, Encoding.Default, bArr);
                        string msg = Encoding.Default.GetString(aa, 0, n); // int n 빼먹으면 tret2 값 이상함
                        //CmdTypes(msg);
                        isPi(msg);

                        AddText(msg, 3);
                    }
                }
                Thread.Sleep(100);
            }
        }

        #endregion

        #region 라즈베리파이 온습도 데이터 -> C# -> 안드로이드 전송 : AppSendProcess()

        


        /// <summary>
        /// 라즈베리파이 온습도 데이터 -> C# -> 안드로이드 전송
        /// 심플한 방법으로 구동되는지 해보기
        /// 스레드 생성 따로 빼기 >> 일단 임시로 버튼
        /// while(true)
        /// {
        ///     try()
        ///     barr = {온도, 습도, 기타 등등}  << 왠만하면 Pi 직접받은 신호랑 무관하게 ,, 차라리 db 라스트 엔트리 
        ///     androidList = {192.168.2.77:session, }  
        /// 
        ///     tcp[androidNo].client.send(barr);       // 아무튼 Pi 한테 잡신호 보내지 말 것 >> Pi한테 가는 신호는 전부 명령(온도설정/습도)      
        ///     delay(500)
        /// 
        /// }
        /// 
        /// </summary>
        void AppSendProcess()  // 수정하기
        {
            // 안드로이드 보내는 것은 별도 스레드 사용해서 적용하기
            // 즉시 보내지도록
            while (true)
            {
                int androidNo = 0;
                sbClientList.Text = android;
                string sent2App = $"{lbTempNow},{lbMoistNow}";
                byte[] bArr = Encoding.Default.GetBytes(sent2App);

                for (int i = 0; i < CurrentClientNum; i++)
                {
                    if (tcp[i].Client.RemoteEndPoint.ToString() == $"{androidIp}:{androidPort}")
                        androidNo = i;
                }
                tcp[androidNo].Client.Send(bArr);

                Thread.Sleep(500);
            }
            
                    // 밑에 스레드 생성만큼은 자동실행X 수동으로 본인 컨트롤 밑에

        }

        #endregion

        #region 안드로이드 -> C# -> 라즈베리파이 제어 / 라즈베리파이인지 아닌지 구별 : isPi(string msg)

        /// <summary>
        /// 안드로이드 - C# - 라즈베리파이 제어
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void isPi(string msg)
        {
            string cmd;
            if (mylib.GetToken(0, msg, ':').Trim(' ') == "A")     // 앱에서 전송된 자료
            {   // App -> Pi
                cmd = mylib.GetToken(1, msg, ':');
                AddText($"App : {cmd}\n", 1);
                CmdRunning($"0,{cmd}");     // 테스트 목적, 나중에 0도 같이 보내도록 하던지 아니면 여기서 처리할지 생각하기
            }
            else // if(mylib.GetToken(0, msg, ':') == "P")    // 라즈베리파이에서 전송된 자료
            {   // Pi -> App
                cmd = mylib.GetToken(1, msg, ':');
                AddText($"Pi : {cmd}\n", 1);
                CmdRunning(cmd);
            }
        }

        #endregion

        #region Connect 이상 확인 (구현 중....)

        /// <summary>
        /// 클라이언트 연결이 원활한지 확인하는 함수.(구현중....)
        /// </summary>
        void IsConnected()
        {
            int androidNo = 0;
            try
            {
                while (true)
                {
                    string temp = "checking conn...";
                    sbClientList.Text = android;
                    byte[] bArr = Encoding.Default.GetBytes(temp);

                    for (int i = 0; i < CurrentClientNum; i++)
                    {
                        if (tcp[i].Client.RemoteEndPoint.ToString() == $"{androidIp}:{androidPort}")
                            androidNo = i;
                    }
                    tcp[androidNo].Client.Send(bArr);
                    AddText($"{temp}\n", 1);

                    Thread.Sleep(500);
                }
            }
            catch (Exception e1) 
            {
                AddText("no connected...\n", 1);
                AddText($"{e1.Message}\n", 1);
                MessageBox.Show(e1.Message); 
            }
        }

        #endregion


        #region Tcp List 중 선택되어 있는 리스트 인덱스를 반환한다. : GetTcpIndex()

        /// <summary>
        /// TCP List 중 선택되어 있는 리스트 인덱스를 반환한다.
        /// </summary>
        /// <returns></returns>
        int GetTcpIndex() // Tcp List 중 선택되어 있는 리스트 인덱스를 반환
        {
            string deviceType = null;
            if (sbClientList.Text == android)
                deviceType = androidIp;
            else if (sbClientList.Text == rasp)
                deviceType = raspIp;
            else return -1;

            for (int i = 0; i < CurrentClientNum; i++)
            {
                if (tcp[i].Client.RemoteEndPoint.ToString() == deviceType)
                    return i;
            }
            return -1;
        }

        #endregion



        #region Program Close

        /// <summary>
        /// 프로그램을 종료할 때 : 스레드를 모두 종료한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadServer != null) threadServer.Abort();
            if (threadRead != null) threadRead.Abort();
            if (threadAndroidSend != null) threadAndroidSend.Abort();
            if (threadIsConnected != null) threadIsConnected.Abort();
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

        #endregion


    }
}
