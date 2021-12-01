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
        #region 데이터 변수 모음
        string sqlTemp = "";
        string sqlMoist = "";

        string type = null;         // 종류 (0 : Android -> Pi, 1 : Pi -> Android)
        string moist = null;        // 온도
        string temp = null;         // 습도
        string set_temp = null;     // 설정 온도
        string set_moist = null;    // 설정 습도
        string water_level = null;  // 물통 수위
        string feed_mode = null;    // 먹이(자동/수동) (0 : 자동, 1 : 수동)
        string food_empty = null;   // 밥통 여부 (0 : 없음, 1 : 있음)

        string tret1 = null;
        string tret2 = null;
        string date = null;

        string and_server_status = null; // 서버 <-> 안드로이드 연결 상태 (0 : no, 1 : yes)
        string pi_server_status = null;  // 서버 <-> 파이 연결 상태 (0 : no, 1 : yes)

        #endregion

        #region 함수들

        #region init settings - AddText(string str, int i)

        // 기능을 분리하여 표현할 수 있다.
        delegate void cbAddText(string str, int i);
        void AddText(string str, int i)
        {
            if (tbServer.InvokeRequired || statusStrip1.InvokeRequired || lbTempNow.InvokeRequired || lbMoistNow.InvokeRequired || lbTempTarget.InvokeRequired || lbMoistTarget.InvokeRequired)
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
                        tbServer.AppendText(str);       break;

                    case 2:
                        if (mylib.GetToken(1, str, ':') == androidIp) { sbClientList.Text = android; }
                        else if (mylib.GetToken(1, str, ':') == raspIp) { sbClientList.Text = rasp; }
                        break;

                    case 3:
                        tbServerLog.Text = str;         break;

                    case 4:
                        lbTempNow.Text = $"{str}℃";     break;

                    case 5:
                        lbMoistNow.Text = $"{str}%";    break;

                    case 6:
                        lbTempTarget.Text = $"{str}℃";  break;

                    case 7:
                        lbMoistTarget.Text = $"{str}%"; break;

                }
            }
        }

        #endregion

        #region isAlive(Socket sck)
        bool isAlive(Socket sck) //미완성?
        {
            if (sck == null)
            {
                return false;
            }
            if (sck.Connected == false)
            {
                return false;
            }

            bool b1 = sck.Poll(1000, SelectMode.SelectRead); //정상(false) 오류(true)
            bool b2 = (sck.Available == 0); //오류(true) 정상(false)    /
            if (b1 && b2)
            {
                return false;
            }

            try
            {
                sck.Send(new byte[1], 0, SocketFlags.OutOfBand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        SqlDB sqldb;
        #region DataBase 접속 경로

        public static string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\송연석\Documents\SenserDB.mdf;Integrated Security=True;Connect Timeout=30";

        #endregion

        #endregion

        #region 서버 변수 및 TcpType(string ip_port)


        #region 라즈베리파이 서버 변수

        TcpClient[] PiTcp = new TcpClient[1];
        Socket PiSock = null;
        TcpListener PiListen = null;     // Raspiberry, port 9090
        Thread PiThreadServer = null;
        Thread PiThreadRead = null;
        Thread PiThreadSend = null;

        const string raspIp = "192.168.2.58";       // "192.168.2.62" , 58
        string raspPort = null;
        string rasp = "라즈베리파이";

        #endregion

        #region 안드로이드 서버 변수

        TcpClient[] AndroidTcp = new TcpClient[10];     // 확인하고 필요 없으면 합치기
        Socket AndroidSock = null;
        TcpListener AndroidListen = null;     // Android, port 9000
        Thread AndroidThreadServer = null;
        Thread AndroidThreadRead = null;
        Thread AndroidThreadSend = null; // 활용하는 방법으로 해보자 

        int CurrentAndroidNum = 0;
        int android_count = 0;
        const string androidIp = "192.168.2.58";    // "192.168.2.70", 58
        string androidPort = null;
        string android = "애플리케이션";
        
        // 날짜 입력
        DateTime dt = DateTime.Now;

        #endregion

        string TcpType(string ip_port)
        {
            string types = mylib.GetToken(0, ip_port, ':');
            if (types == androidIp)
            {
                androidPort = mylib.GetToken(1, ip_port, ':');
                AddText($"App :{ip_port}", 2);
            }
            else
            {
                raspPort = mylib.GetToken(1, ip_port, ':');
                AddText($"Pi :{ip_port}", 2);
            }

            return types;
        }

        #endregion

        #region 라즈베리파이 Part

        private void btnPiServerStart_Click(object sender, EventArgs e)
        {
            if (PiListen != null)
            {
                if (MessageBox.Show("라즈베리파이 서버를 다시 시작하시겠습니까?.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    PiListen.Stop();
                    // Pi용 스레드 구성

                    if (PiThreadServer != null) PiThreadServer.Abort();
                    if (PiThreadRead != null) PiThreadRead.Abort();
                }
            }

            PiListen = new TcpListener(int.Parse(tbPiServerPort.Text));
            PiListen.Start();
            AddText($"라즈베리파이 서버가 [{tbPiServerPort.Text}] Port에서 시작되었습니다.\r\n", 1);

            if (PiThreadServer != null) PiThreadServer.Abort();
            PiThreadServer = new Thread(PiServerProcess);
            PiThreadServer.Start();


        }

        private void btnPiServerOff_Click(object sender, EventArgs e)
        {
            pi_server_status = "0";
            // dead 메시지 보내기 (서버 -> 파이)
            string send2Pi = $"{set_temp},{set_moist},{feed_mode},{pi_server_status}\n\n\n"; // in.readline()이 '\n'을 기준으로 돌아감
            byte[] sArr = Encoding.UTF8.GetBytes(send2Pi);      // utf-8

            PiTcp[0].Client.Send(sArr);
            CloseServer();
        }

        #region Pi Connect 요구 처리 프로세스 : PiServerProcess()

        /// <summary>
        /// Pi Connect 요구 처리 프로세스
        /// </summary>
        void PiServerProcess()  // Connect 요구 처리 쓰레드
        {
            while (true)
            {
                if (PiListen.Pending())
                {
                    PiTcp[0] = PiListen.AcceptTcpClient(); // 세션 수립
                    string sLabel = PiTcp[0].Client.RemoteEndPoint.ToString();  // Client IP Address : Port(Session)
                    AddText($"라즈베리파이 [{sLabel}] 로부터 접속되었습니다\r\n", 1);

                    TcpType(sLabel);
                    sbLabel1.Text = sLabel;

                    pi_server_status = "1";
                    // 최근 기록 보내기 (연결 확인용) (서버 -> 파이)
                    string send2Pi = $"{set_temp},{set_moist},{feed_mode},{pi_server_status}\n"; // in.readline()이 '\n'을 기준으로 돌아감
                    byte[] sArr = Encoding.UTF8.GetBytes(send2Pi);      // utf-8

                    PiTcp[0].Client.Send(sArr);

                    if (PiThreadRead != null) PiThreadRead.Abort();
                    PiThreadRead = new Thread(PiReadProcess);
                    PiThreadRead.Start();
                }
                Thread.Sleep(100);
            }
        }

        #endregion
        #region Pi Read 처리 프로세스 : PiReadProcess()

        /// <summary>
        /// Read 처리 프로세스
        /// </summary>
        void PiReadProcess() // Multi Client : CurrentClinrNum
        {
            byte[] bArr = new byte[512]; //나머지 버퍼도 한번 점검해주세요
            while (true)
            {                
                if (PiTcp[0].Available > 0)
                {
                    int n = PiTcp[0].Client.Receive(bArr); //bArr[n] = 0;
                    //byte[] aa = Encoding.Convert(Encoding.UTF8, Encoding.Default, bArr);
                    //string msg = Encoding.Default.GetString(aa, 0, n); // int n 빼먹으면 tret2 값 이상함
                    string msg = Encoding.UTF8.GetString(bArr, 0, n);
                    PiExecute(msg);
                    InsertDB(temp, moist, tret1, tret2, date);
                    AddText(msg, 3);
                    AddText($"Pi>>{msg}\r\n", 1);
                    //디버깅용: Send 임시로 박아넣음: 아예 합칠수도 있음

                    #region 서버 -> 파이 데이터 통신 프로토콜
                    // set_temp,set_moist,water_level,feed_mode,food_empty,pi_server_status
                    #endregion
                    PiSendProcess();

                }
                Thread.Sleep(100);
            }
        }
        void PiSendProcess()
        {
            // 서버 -> 파이 프로토콜
            pi_server_status = "1";
            string send2Pi = $"{set_temp},{set_moist},{feed_mode},{pi_server_status}"; // in.readline()이 '\n'을 기준으로 돌아감
            byte[] cArr = Encoding.UTF8.GetBytes(send2Pi);      // utf-8
            PiTcp[0].Client.Send(cArr);
            AddText($"Pi<<{send2Pi}\r\n", 1);
        }
        #endregion

        void InsertDB(string temp, string moist, string tret1, string tret2, string date)
        {
            //SQL 부분도 별도 함수로 처리하는게 좋지 않나
            // db 각 컬럼 데이터타입에 대해 고민 해볼 것
            sqlTemp = $"INSERT INTO Temperature (temp, tret1, tret2, date) VALUES ('{temp}', '{tret1}', '{tret2}', '{date}')";
            sqlMoist = $"INSERT INTO Moisture (moist, tret1, tret2, date) VALUES ('{moist}', '{tret1}', '{tret2}', '{date}')";
            sqldb.Run(sqlTemp);
            sqldb.Run(sqlMoist);
        }
        void PiExecute(string msg)
        {
            string cmd = msg;

            #region 라즈베리파이 -> 서버 데이터 전송 프로토콜
            // temp,moist,tret1,tret2,water_level,feed_mode,food_empty
            // tret1, tret2 : 센서 1, 센서 2
            // tret1, tret2 == -1 : 오류
            // tret1, tret2 == 1 : 정상 
            #endregion

            //int idx = 0 
            //const int BAX_BUF  변수처럼 >> 
            const int PI_IDX = 0;

            // 온습도 표시기 적용
            moist = $"{int.Parse(mylib.GetToken(PI_IDX + 0, cmd, ',').Trim()) / 2}";
            temp = $"{double.Parse(mylib.GetToken(PI_IDX + 1, cmd, ',').Trim()) / 10 / 2}";
            tret1 = mylib.GetToken(PI_IDX + 2, cmd, ',').Trim();
            tret2 = mylib.GetToken(PI_IDX + 3, cmd, ',').Trim();
            date = dt.ToString("yyyy.MM.dd HH:mm:s");
            water_level = mylib.GetToken(PI_IDX + 4, cmd, ',').Trim();
            feed_mode = mylib.GetToken(PI_IDX + 5, cmd, ',').Trim();
            food_empty = mylib.GetToken(PI_IDX + 6, cmd, ',').Trim();


            AddText(temp, 4);    // 온도
            AddText(moist, 5);   // 습도

        }

        #endregion

        #region 안드로이드 Part

        private void btnAppServerStart_Click(object sender, EventArgs e)
        {
            if (AndroidListen != null)
            {
                if (MessageBox.Show("안드로이드 서버를 다시 시작하시겠습니까?.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    AndroidListen.Stop();
                    // 안드로이드용 스레드 구성

                    if (AndroidThreadServer != null) AndroidThreadServer.Abort();
                    if (AndroidThreadRead != null) AndroidThreadRead.Abort();
                }
            }

            AndroidListen = new TcpListener(int.Parse(tbAndroidServerPort.Text));
            AndroidListen.Start();
            AddText($"안드로이드 서버가 [{tbAndroidServerPort.Text}] Port에서 시작되었습니다.\r\n", 1);

            if (AndroidThreadServer != null) AndroidThreadServer.Abort();
            AndroidThreadServer = new Thread(AndroidServerProcess);
            AndroidThreadServer.Start();

            if (AndroidThreadRead != null) AndroidThreadRead.Abort();
            AndroidThreadRead = new Thread(AndroidReadProcess);
            AndroidThreadRead.Start();
        }

        private void btnAndServerOff_Click(object sender, EventArgs e)
        {
            and_server_status = "0";
            // dead 메시지 보내기 : 서버 -> 안드로이드
            string send2And = $"{temp},{moist},{water_level},{feed_mode},{food_empty},{and_server_status}\n\n\n";
            byte[] sArr = Encoding.UTF8.GetBytes(send2And);

            int andIdx = 0;
            for (int i = 0; i < CurrentAndroidNum; i++)
            {
                if (AndroidTcp[i].Client.RemoteEndPoint.ToString() == androidIp)
                    andIdx = i;
            }

            AndroidTcp[andIdx].Client.Send(sArr);
            CloseServer();
        }

        #region Android Connect 요구 처리 프로세스 : AndroidServerProcess()

        /// <summary>
        /// Connect 요구 처리 프로세스
        /// </summary>
        void AndroidServerProcess()  // Connect 요구 처리 쓰레드
        {
            while (true)
            {
                if (AndroidListen.Pending())
                {
                    if (CurrentAndroidNum == 10) break; // Process over

                    AndroidTcp[CurrentAndroidNum] = AndroidListen.AcceptTcpClient(); // 세션 수립
                    string sLabel = AndroidTcp[CurrentAndroidNum].Client.RemoteEndPoint.ToString();  // Client IP Address : Port(Session)
                    AddText($"안드로이드 [{sLabel}] 로부터 접속되었습니다\r\n", 1);

                    TcpType(sLabel);
                    sbLabel1.Text = sLabel;

                    #region serverprocess에 관한 주석

                    // 설명 (참고만)
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
                    #endregion

                    if (mylib.GetToken(0, AndroidTcp[CurrentAndroidNum].Client.RemoteEndPoint.ToString(), ':') == androidIp && android_count == 1)
                    {// android가 이미 연결되어 있다면, CurrentAndroidNum은 증가하지 않는다.
                        AndroidTcp[CurrentAndroidNum - 1] = AndroidTcp[CurrentAndroidNum];
                    }
                    else
                    {
                        android_count = 1;

                        // 최근 기록 보내기 (연결 확인용) (서버 -> 안드로이드)
                        int andIdx = 0;
                        and_server_status = "1";
                        string send2And = $"{temp},{moist},{water_level},{feed_mode},{food_empty},{and_server_status}";

                        byte[] bArr = Encoding.UTF8.GetBytes(send2And);

                        for (int i = 0; i < CurrentAndroidNum; i++)
                        {
                            if (AndroidTcp[i].Client.RemoteEndPoint.ToString() == androidIp)
                                andIdx = i;
                        }
                        AndroidTcp[andIdx].Client.Send(bArr);
                        CurrentAndroidNum++;
                    }
                }
                Thread.Sleep(100);
            }

        }

        #endregion

        #region Android Read 처리 프로세스 : AndroidReadProcess()

        /// <summary>
        /// Read 처리 프로세스
        /// </summary>
        void AndroidReadProcess() // Multi Client : CurrentClinrNum
        {
            byte[] bArr = new byte[512];
            while (true)
            {
                for (int i = 0; i < CurrentAndroidNum; i++)
                {
                    if (AndroidTcp[i].Available > 0)
                    {
                        int n = AndroidTcp[i].Client.Receive(bArr);
                        //byte[] aa = Encoding.Convert(Encoding.UTF8, Encoding.Default, bArr);
                        string msg = Encoding.UTF8.GetString(bArr, 0, n); // int n 빼먹으면 tret2 값 이상함
                        AndExecute(msg);

                        AddText($"And>>{msg}\r\n", 1);

                        AndSendProcess();
                    }
                }
                Thread.Sleep(100);
            }
        }
        void AndExecute(string msg)
        {
            string cmd = mylib.GetToken(1, msg, ':');
            try
            {
                if (mylib.GetToken(0, msg, ':').Trim(' ') != "A") return;

                AddText($"App : {cmd}", 1);
                type = mylib.GetToken(0, cmd, ',');
            }
            catch (Exception e1) { MessageBox.Show(e1.Message); return; }

            if (int.Parse(type) != 0) return;

            #region 안드로이드 -> 서버 데이터 통신 프로토콜
            // set_temp,set_moist,water_level,feed_mode,food_empty
            #endregion

            const int AND_IDX = 0;
            set_temp = mylib.GetToken(AND_IDX + 0, cmd, ',').Trim();
            set_moist = mylib.GetToken(AND_IDX + 1, cmd, ',').Trim();
            water_level = mylib.GetToken(AND_IDX + 2, cmd, ',').Trim();
            feed_mode = mylib.GetToken(AND_IDX + 3, cmd, ',').Trim();
            food_empty = mylib.GetToken(AND_IDX + 4, cmd, ',').Trim();

            AddText(set_temp, 6);      // 설정 온도
            AddText(set_moist, 7);      // 설정 습도


        }
        void AndSendProcess()
        {
            #region 서버 -> 안드로이드 데이터 통신 프로토콜
            // temp, moist, water_level, feed_mode, food_empty, and_server_status
            #endregion

            and_server_status = "1";
            string sent2App = $"{temp},{moist},{water_level},{feed_mode},{food_empty},{and_server_status}\n"; // in.readline()이 '\n'을 기준으로 돌아감
            byte[] cArr = Encoding.UTF8.GetBytes(sent2App);      // utf-8

            int andIdx = 0;
            for (int j = 0; j < CurrentAndroidNum; j++)
            {
                if (AndroidTcp[j].Client.RemoteEndPoint.ToString() == androidIp)
                    andIdx = j;
            }

            AndroidTcp[andIdx].Client.Send(cArr);
            AddText($"And<<{sent2App}\r\n", 1);
        }

        #endregion

        #region 라즈베리파이 온습도 데이터 -> C# -> 안드로이드 전송 : AndroidSendProcess()

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
        void AndroidSendProcess()  // 수정하기
        {
            //잠깐 쉬었다가 
            Thread.Sleep(2000);
            // 안드로이드 보내는 것은 별도 스레드 사용해서 적용하기
            // 즉시 보내지도록
            while (true)
            {
                int androidNo = 0;

                for (int i = 0; i < CurrentAndroidNum; i++)
                {
                    if (AndroidTcp[i].Client.RemoteEndPoint.ToString() == androidIp)
                        androidNo = i;
                }
                sbClientList.Text = android;

                and_server_status = (isAlive(AndroidTcp[androidNo].Client) == true) ? "1" : "0";
                string sent2App = $"{temp},{moist},{water_level},{feed_mode},{food_empty},{and_server_status}\n"; // in.readline()이 '\n'을 기준으로 돌아감
                byte[] bArr = Encoding.UTF8.GetBytes(sent2App);      // utf-8


                //대충 이런식으로 채크
                if (isAlive(AndroidTcp[androidNo].Client))
                    AndroidTcp[androidNo].Client.Send(bArr); //여기서 끊겼다고 오류 뜸 어짜피 이 오류는 못막아줌
                else
                {
                    MessageBox.Show("안드로이드 연결 끊김");
                    AddText("안드로이드 연결 끊김\n", 1);
                    break;
                }
                Thread.Sleep(2000);
            }
        }

        #endregion



        #endregion

        #region 서버 닫기 : CloseServer()

        void CloseServer()
        {
            if (AndroidThreadServer != null) AndroidThreadServer.Abort();
            if (AndroidThreadRead != null) AndroidThreadRead.Abort();
            if (PiThreadServer != null) PiThreadServer.Abort();
            if (PiThreadRead != null) PiThreadRead.Abort();
            if (AndroidThreadSend != null) AndroidThreadSend.Abort();
        }

        #endregion

        #region DB

        #region DB 조회 (온도, 습도 데이터 조회)
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
        #endregion

        #endregion

        // 최근 데이터를 종료할 때 저장
        iniFile ini = new iniFile(".\\currentData.ini");
        private void frmServer_Load(object sender, EventArgs e)
        {
            // MSSQL 연동하기
            // DB 연결 완료
            sqldb = new SqlDB(ConnString);

            // ini에 파일 저장
            int X = int.Parse(ini.GetPString("Location", "X", $"{Location.X}"));
            int Y = int.Parse(ini.GetPString("Location", "Y", $"{Location.Y}"));
            Location = new Point(X, Y);

            type = ini.GetPString("Device Type", "Type", $"{type}");
            temp = ini.GetPString("Current Status", "Temp", $"{temp}");
            moist = ini.GetPString("Current Status", "Moist", $"{moist}");
            set_temp = ini.GetPString("Current Setting Status", "Set Temp", $"{set_temp}");
            set_moist = ini.GetPString("Current Setting Status", "Set Moist", $"{set_moist}");
            water_level = ini.GetPString("Water Level", "Water Level", $"{water_level}");
            feed_mode = ini.GetPString("Feed Settings", "Feed Mode", $"{feed_mode}");
            food_empty = ini.GetPString("Feed Settings", "Food Empty", $"{food_empty}");

            AddText(temp, 4);
            AddText(moist, 5);
            AddText(set_temp, 6);
            AddText(set_moist, 7);
        }
        public frmServer()
        {
            InitializeComponent();
        }

        #region Program Close

        /// <summary>
        /// 프로그램을 종료할 때 : 스레드를 모두 종료한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 프로그램 종료 시 라즈베리파이에 데드 메시지 
            CloseServer();

            // ini에 파일 저장
            ini.WritePString("Location", "X", $"{Location.X}");
            ini.WritePString("Location", "Y", $"{Location.Y}");

            ini.WritePString("Device Type", "Type", $"{type}");
            ini.WritePString("Current Status", "Temp", $"{temp}");
            ini.WritePString("Current Status", "Moist", $"{moist}");
            ini.WritePString("Current Setting Status", "Set Temp", $"{set_temp}");
            ini.WritePString("Current Setting Status", "Set Moist", $"{set_moist}");
            ini.WritePString("Water Level", "Water Level", $"{water_level}");
            ini.WritePString("Feed Settings", "Feed Mode", $"{feed_mode}");
            ini.WritePString("Feed Settings", "Food Empty", $"{food_empty}");

        }


        #endregion

        #region 안드로이드 연결 확인 + 디버깅 : btnAndroid, btnDebug
        private void btnAndroid_Click(object sender, EventArgs e)
        {
            if (AndroidThreadSend != null) AndroidThreadSend.Abort();
            AndroidThreadSend = new Thread(AndroidSendProcess);
            AndroidThreadSend.Start();
        }

        /// <summary>
        /// 디버깅 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebug_Click(object sender, EventArgs e)
        {

            Random rand = new Random();
            double randCurrTemp = rand.Next(100, 400) / 10.0;
            double randTargetTemp = rand.Next(100, 400) / 10.0;
            double randCurrMoist = rand.Next(300, 700) / 10.0;
            double randTargetMoist = rand.Next(300, 700) / 10.0;

            // 랜덤
            AddText($"{randCurrTemp}", 4);          // TempNow
            AddText($"{randCurrMoist}", 5);         // MoistNow
            AddText($"{randTargetTemp}", 6);        // TempTarget
            AddText($"{randTargetMoist}", 7);       // MoistTarget
        }



        #endregion


        //#region CmRunning(string c) - 삭제 예정
        //void CmdRunning(string c)
        //{
        //    try
        //    {
        //        type = mylib.GetToken(0, c, ',');
        //    }
        //    catch (Exception e1)
        //    {
        //        MessageBox.Show(e1.Message);
        //        return;
        //    }

        //    switch (int.Parse(type))
        //    {
        //        case 0:     // App -> Pi
        //                    // 1. App -> Server

        //            #region 안드로이드 -> 서버 데이터 통신 프로토콜
        //            // A:(0),set_temp,set_moist,feed_mode,feed_hour,feed_min,feeding_sign
        //            // 0은 임의로 붙인 것 
        //            #endregion


        //            set_temp = mylib.GetToken(2, c, ',').Trim();
        //            set_moist = mylib.GetToken(1, c, ',').Trim();
        //            feed_mode = mylib.GetToken(3, c, ',').Trim();
        //            feed_hour = mylib.GetToken(4, c, ',').Trim();
        //            feed_min = mylib.GetToken(5, c, ',').Trim();
        //            feeding_sign = mylib.GetToken(6, c, ',').Trim();

        //            AddText(set_temp, 6);      // 설정 온도
        //            AddText(set_moist, 7);      // 설정 습도

        //            // 2. Server -> Pi

        //            #region 서버 -> 라즈베리파이 데이터 통신 프로토콜
        //            // set_temp,set_moist,feed_mode,feed_hour,feed_min,feeding_sign,pi_server_status
        //            #endregion

        //            //if (PiThreadSend == null)
        //            //{
        //            //    PiThreadSend = new Thread(PiSendProcess);
        //            //    PiThreadSend.Start();
        //            //}

        //            break;

        //        case 1:
        //            // DB 입력 + Pi -> App

        //            // 1. Pi -> Server
        //            #region 라즈베리파이 -> 서버 데이터 전송 프로토콜
        //            // Pi:1,temp,moist,tret1,tret2,water_level,feed_hour,feed_min,feeding_sign
        //            // tret1, tret2 : 센서 1, 센서 2
        //            // tret1, tret2 == -1 : 오류
        //            // tret1, tret2 == 1 : 정상 
        //            #endregion

        //            // 온습도 표시기 적용


        //            moist = $"{double.Parse(mylib.GetToken(2, c, ',').Trim()) / 10 / 2}";
        //            temp = $"{int.Parse(mylib.GetToken(1, c, ',').Trim()) / 2}";
        //            moist = lbMoistNow.Text;
        //            temp = lbTempNow.Text;
        //            string tret1 = mylib.GetToken(3, c, ',').Trim();
        //            string tret2 = mylib.GetToken(4, c, ',').Trim();

        //            string date = dt.ToString("yyyy.MM.dd HH:mm:s");

        //            water_level = mylib.GetToken(5, c, ',').Trim();
        //            feed_hour = mylib.GetToken(6, c, ',').Trim();
        //            feed_min = mylib.GetToken(7, c, ',').Trim();
        //            feeding_sign = mylib.GetToken(8, c, ',').Trim();

        //            // db 각 컬럼 데이터타입에 대해 고민 해볼 것
        //            sqlTemp = $"INSERT INTO Temperature (temp, tret1, tret2, date) VALUES ('{temp}', '{tret1}', '{tret2}', '{date}')";
        //            sqlMoist = $"INSERT INTO Moisture (moist, tret1, tret2, date) VALUES ('{moist}', '{tret1}', '{tret2}', '{date}')";
        //            sqldb.Run(sqlTemp);
        //            sqldb.Run(sqlMoist);

        //            AddText(temp, 4);    // 온도
        //            AddText(moist, 5);           // 습도

        //            // 2. Server -> Android (별도 스레드)
        //            #region 서버 -> 안드로이드 데이터 통신 프로토콜
        //            // temp,moist,water_level,feeding_sign,app_server_status
        //            #endregion                    

        //            if (AndroidThreadSend == null)
        //            {
        //                AndroidThreadSend = new Thread(AndroidSendProcess);
        //                AndroidThreadSend.Start();
        //            }
        //            break;
        //    }
        //}
        //#endregion


        //#region isPi(string msg) - 삭제 예정

        ///// <summary>
        ///// 안드로이드 - C# - 라즈베리파이 제어
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ////void isPi(string msg)
        ////{
        ////    string cmd;
        ////    if (mylib.GetToken(0, msg, ':').Trim(' ') == "A")     // 앱에서 전송된 자료
        ////    {   // App -> Pi
        ////        cmd = mylib.GetToken(1, msg, ':');
        ////        AddText($"App : {cmd}\n", 1);
        ////        CmdRunning($"0,{cmd}");     // 테스트 목적, 나중에 0도 같이 보내도록 하던지 아니면 여기서 처리할지 생각하기
        ////    }
        ////    else  // 라즈베리파이에서 전송된 자료
        ////    {   // Pi -> App
        ////        cmd = mylib.GetToken(1, msg, ':');
        ////        AddText($"Pi : {cmd}\n", 1);
        ////        CmdRunning(cmd);
        ////    }
        ////}

        //#endregion

        //#region Connect 이상 확인 - 삭제 예정 ; IsConnected()

        ///// <summary>
        ///// 클라이언트 연결이 원활한지 확인하는 함수.(구현중....)
        ///// </summary>
        //void IsConnected()
        //{
        //    int androidNo = 0;
        //    try
        //    {
        //        while (true)
        //        {
        //            string temp = "checking conn...";
        //            sbClientList.Text = android;
        //            byte[] bArr = Encoding.Default.GetBytes(temp);

        //            for (int i = 0; i < CurrentAndroidNum; i++)
        //            {
        //                if (AndroidTcp[i].Client.RemoteEndPoint.ToString() == $"{androidIp}:{androidPort}")
        //                    androidNo = i;
        //            }
        //            AndroidTcp[androidNo].Client.Send(bArr);
        //            AddText($"{temp}\n", 1);

        //            Thread.Sleep(500);
        //        }
        //    }
        //    catch 
        //    {
        //        AddText("not connected...\n", 1);
        //    }
        //}

        //#endregion
        #region 서버 Part (주석)





        /// <summary>
        /// 서버가 시작될 때 listen을 시작하여 연결이 될 때까지 대기시킨다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnServerStart_Click(object sender, EventArgs e)
        //{
        //    if (PiListen != null)
        //    {
        //        if (MessageBox.Show("라즈베리파이 서버를 다시 시작하시겠습니까?.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //        {
        //            PiListen.Stop();
        //            // Pi용 스레드 구성

        //            if (PiThreadServer != null) PiThreadServer.Abort();
        //            if (PiThreadRead != null) PiThreadRead.Abort();
        //        }
        //    }

        //    if (AndroidListen != null)
        //    {
        //        if (MessageBox.Show("안드로이드 서버를 다시 시작하시겠습니까?.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //        {
        //            AndroidListen.Stop();
        //            // 안드로이드용 스레드 구성

        //            if (AndroidThreadServer != null) AndroidThreadServer.Abort();
        //            if (AndroidThreadRead != null) AndroidThreadRead.Abort();
        //        }
        //    }
        //    PiListen = new TcpListener(int.Parse(tbPiServerPort.Text));
        //    PiListen.Start();
        //    AddText($"라즈베리파이 서버가 [{tbPiServerPort.Text}] Port에서 시작되었습니다.\r\n", 1);

        //    AndroidListen = new TcpListener(int.Parse(tbAndroidServerPort.Text));
        //    AndroidListen.Start();
        //    AddText($"안드로이드 서버가 [{tbAndroidServerPort.Text}] Port에서 시작되었습니다.\r\n", 1);

        //    if (PiThreadServer != null) PiThreadServer.Abort();
        //    PiThreadServer = new Thread(PiServerProcess);
        //    PiThreadServer.Start();

        //    if (PiThreadRead != null) PiThreadRead.Abort();
        //    PiThreadRead = new Thread(PiReadProcess);
        //    PiThreadRead.Start();

        //    if (AndroidThreadServer != null) AndroidThreadServer.Abort();
        //    AndroidThreadServer = new Thread(AndroidServerProcess);
        //    AndroidThreadServer.Start();

        //    if (AndroidThreadRead != null) AndroidThreadRead.Abort();
        //    AndroidThreadRead = new Thread(AndroidReadProcess);
        //    AndroidThreadRead.Start();
        //}

        #endregion



    }
}
