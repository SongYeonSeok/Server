# Server
- 스마트 IoT 도마뱀 사육장 서버 프로그램
> KOSTA IoT 기반의 스마트 개발자 양성 과정에서 진행한 Final Project

### Stacks & Skills
<img alt="C#" src ="https://img.shields.io/badge/C Sharp-239120.svg?&style=for-the-badge&logo=C Sharp&logoColor=white"/>  <img alt="Microsoft SQL Server" src ="https://img.shields.io/badge/MSSQL-CC2927.svg?&style=for-the-badge&logo=Microsoft SQL Server&logoColor=white"/>

### 목차
---
0. 참고사항
1. Logic Process
2. 서버 프로그램 구상안
3. 기능 정의
    - 서버 프로그램 구성
    - 변수 및 통신 프로토콜
    - 프로그램 실행 시작
    - Pi to Server
        - 데이터베이스
        - 정보 분석
        - 위험 경보
    - Android to Server
    - 서버 프로그램 종료
4. 참고 자료
---
### 0. 참고사항
- Final Project 발표 날(2021.12.15), 최종 점검을 위해서 서버 프로그램을 실행하였지만, 문제가 발생하여 서버 Logic Process를 변경하였다.
- 이후 서버 Logic Process는 최종적으로 변경된 내용을 토대로 작성되었다.
- [변경 사항 확인](https://github.com/yeonseoksong/Server/blob/master/changed.md)

### 1. Logic Process
![image](https://user-images.githubusercontent.com/49339278/147594849-0e961dbf-6779-473e-8089-2853322efdec.png)

### 2. 서버 프로그램 구상안
- 최초 설계
  - ![image](https://user-images.githubusercontent.com/49339278/147595758-d3a2d5d6-cae4-457a-b5f4-22739050d25f.png)
  - Python의 웹 프레임워크인 Flask를 이용한 웹 서버를 구축하여 안드로이드와 라즈베리파이 간 통신이 가능하도록 계획하였다.
  - 라즈베리파이에 Flask 웹 서버를 구축하고, 기능별로 도메인 주소를 나눠 모바일 앱의 기능과 연동시켜 안드로이드와 라즈베리파이가 Flask 웹 서버를 통해 데이터 통신하는 것을 목표로 하였다.
  
- 최초 설계 문제점 : Flask 웹서버와의 소켓 통신을 위해 Python의 socket 패키지와 Flask의 socketio 웹 소켓 패키지를 적용하였으나 소켓 통신이 이뤄지지 않는 문제가 발생하였다.

- 1차 수정 설계
  - ![image](https://user-images.githubusercontent.com/49339278/147595729-9387afff-7a68-4ed3-a764-c5909f667a7b.png)
  - Flask 웹 서버 프로그램 설계 실패로 회의를 진행하였다. IoT 개발자 양성과정을 통해 C# 언어에 대한 친밀성이 높았다는 점과 C#의 Windows Form 라이브러리로 TCP/IP 소켓 프로그래밍을 사용한 프로그램을 개발한 경험이 있다는 점에 근거하여 C# Windows Form 라이브러리를 사용하여 서버 프로그램을 개발하기로 결정하였다.
  - 외온성 변온동물인 도마뱀의 특성상 주위 환경 및 온도변화에 매우 민감하다. 만약 온습도 센서 DHT-11가 고장이 나서 정상적으로 온도와 습도를 측정하지 못한다면 온/습도를 제어하는 데에 큰 문제점이 발생할 것이라 예상하였다.
  - DHT-11 센서 불량 여부를 분석하기 위해 온도, DHT-11 센서 상태, 날짜로 이루어진 온도 데이터베이스와 습도, DHT-11 센서 상태, 날짜로 이루어진 습도 데이터베이스를 구축하는 게 좋겠다는 결론을 내렸고, Visual Studio 2019에서 제공되는 MS-SQL을 사용하여 데이터베이스를 구축하였다.

- 1차 수정 설계 문제점
  - 라즈베리파이와 안드로이드, 서버를 모두 연결하여 데이터를 주고받는 과정에서 데이터 충돌이 발생하여 소켓 통신 오류가 발생하였다.
  - 오류가 발생하게 된 원인은 하나의 포트로 서버를 구성했기 때문이었다. 안정적인 소켓 통신을 위해 서버 포트를 안드로이드 전용 포트(9000)와 라즈베리파이 전용 포트(9090)로 나눠서, 안드로이드 전용 서버와 라즈베리파이 전용 서버를 구성하였다.

- 최종 설계 구상안
  - ![image](https://user-images.githubusercontent.com/49339278/147595774-1963bdea-0dfd-4bd2-8ada-491d2009650c.png)
  - 서버 프로그램을 개발하기 위해 C#의 Windows Form 라이브러리를 사용하기로 결정하였다.
  - 안드로이드 전용 포트(9000)와 라즈베리파이 전용 포트(9090)로 나눠서 서버 프로그램 안에 안드로이드 전용 서버와 라즈베리파이 전용 서버를 구축하였다.
  - C# 서버 프로그램에 Metro UI를 적용하여 사용자들이 사용하기 쉽고 정보를 한 눈에 알아볼 수 있도록 구성하였다.


### 3. 기능 정의
#### 서버 프로그램 구성
- 서버 메뉴와 상태 표시줄
  - 서버 메뉴 구성 : 서버 시작, 프로토콜 확인 텍스트 박스, 서버 기록 확인 텍스트 박스
  - 서버 시작 버튼을 클릭하면, 라즈베리파이와 안드로이드 서버가 생성되어 라즈베리파이와 안드로이드에서 연결 요청이 올 때까지 기다린다.
  - ![image](https://user-images.githubusercontent.com/49339278/147596128-5c8a4af4-7edb-4ae2-8212-4e1052d3b878.png)

- 온습도 메뉴 : 현재 온습도, 설정한 온습도를 확인할 수 있는 메뉴이다.
  - ![image](https://user-images.githubusercontent.com/49339278/147596165-0b7237e1-e3de-40ed-b835-fd95749317c7.png)

- 설정 메뉴 : 서버 프로그램의 유지보수를 위한 기능으로 이루어진 메뉴이다.
  - ![image](https://user-images.githubusercontent.com/49339278/147596293-50960e27-8494-4a32-a32f-1dc8e7e3a0f3.png)

#### 변수 및 통신 프로토콜
- 사용한 변수 목록
  ![image](https://user-images.githubusercontent.com/49339278/147596362-4c8e802e-e33c-4dae-b87b-02ff57c515e6.png)

- 통신 프로토콜
  - 안드로이드와 라즈베리파이, 서버 간의 데이터를 통신하기 위해서 표준화된 통신 규칙이 필요하다. 이를 위해 안드로이드 앱 개발 팀원과 라즈베리파이와 서버 통신을 담당하는 팀원과의 회의를 거쳐 표준화된 규칙을 만들었다.
  - 데이터를 전송할 때, 데이터의 종류를 구분하기 위해 콤마(```,```)를 사용하였다.
  ![image](https://user-images.githubusercontent.com/49339278/147596440-046ae874-d19f-4fa0-b811-6709ff127114.png)

#### 프로그램 실행 시작
- ```mylibrary.dll``` 파일에 있는 ```iniFile``` 함수를 사용하여 최근 데이터를 저장하고, 추후에 불러올 currentData.ini 파일을 생성한다.
- 프로그램을 실행할 때 DB와 연결되고, currentData.ini 파일에 저장되어 있는 온습도, 설정 온습도, 물통 수위, 자동 급여 On/Off 여부, 급여기 현황, 사육장 적정 최대/최소 온습도 데이터를 불러온다.
- 불러온 온습도, 설정 온습도 데이터는 온습도 메뉴의 현재 온습도, 설정 온습도에 입력된다.

#### Pi <-> Server
![image](https://user-images.githubusercontent.com/49339278/147594881-97baf6fb-d591-4d12-9f54-043ef6ff437a.png)
1. 라즈베리파이 서버 생성
    - 서버 시작 버튼을 누르면 라즈베리파이 서버 소켓을 생성하고 소켓에 포트번호 9090을 부여한다. 그 후 listen을 시작하여 라즈베리파이가 서버와 연결이 될 때까지 접속을 기다린다.
    - 만약 라즈베리파이 서버가 이미 생성되어 있다면 "라즈베리파이 서버를 다시 시작하시겠습니까?"라는 메시지를 띄운다. OK를 클릭하면 라즈베리파이 서버 listen을 종료하고 라즈베리파이 스레드를 모두 종료시킨 후에, 다시 라즈베리파이 서버를 생성한다.
    - 이후 라즈베리파이 연결 요청을 처리할 수 있는 ```PiThreadServer``` 스레드와 라즈베리파이에서 전송된 데이터를 읽고 처리하는 ```PiThreadRead``` 스레드, 라즈베리파이로 데이터를 전송하는 ```PiThreadSend``` 스레드를 실행시킨다.

2. Pi Server Process : 라즈베리파이 Connect 요구 처리 스레드(PiThreadServer)에서 실행되는 함수
    - 라즈베리파이에서 연결 요청이 들어오면, 연결 요청을 수락하는 기능을 가진 ```AcceptTcpClient()``` 함수를 호출하여 라즈베리파이 연결에 대한 새로운 소켓을 생성한다.
    - 라즈베리파이와 서버가 연결이 되었으므로, 서버와 라즈베리파이의 연결 상태 변수의 값을 1로 설정하여 서버와 라즈베리파이는 연결이 되었음을 표시한다.
    - 이후 연결 확인을 위해 최근에 저장된 데이터와 서버-라즈베리파이 연결 상태 변수의 값을 라즈베리파이로 전송하여 라즈베리파이와의 연결이 성공적으로 이루어져 있음을 알린다.

3. Pi Read Process : 라즈베리파이에서 전송된 데이터를 읽고 처리하는 스레드(PiThreadRead)에서 실행되는 함수
    - 라즈베리파이로부터 받은 온습도, DHT-11 에러 유무, 설정 온습도, 물통 수위, 자동 급여 On/Off 여부, 급여기 현황 데이터를 저장하고 온습도 메뉴에 있는 현재 온도와 현재 습도 현황판에 입력시킨다.
    - 라즈베리파이로부터 받은 온습도, DHT-11 에러 유무 데이터와 날짜와 시간 데이터를 데이터베이스에 적재한다.

4. Pi Send Process : 서버에서 라즈베리파이로 데이터를 전송하는 스레드(PiThreadSend)에서 실행되는 함수
    - 서버에서 라즈베리파이로 설정 온습도, 자동급여 On/Off 여부, 서버와 라즈베리파이 연결 상태 변수를 전송한다. 서버와 라즈베리파이는 서로 연결 중인 상태이므로 서버-라즈베리파이 연결 상태 변수의 값으로 1을 전송한다.

5. Pi Server Off : 라즈베리파이 서버 종료
    - 라즈베리파이와 서버의 연결이 종료되므로 서버와 라즈베리파이의 연결 상태를 나타내는 변수의 값을 0으로 설정한다.
    - 서버를 종료하기 전에 마지막으로 저장된 설정 온습도, 자동급여 On/Off 여부, 서버와 라즈베리파이 연결 상태 변수 값을 라즈베리파이에 전송한다.
    - 이후 스레드를 모두 종료하여 라즈베리파이 서버를 종료하고, "라즈베리파이 서버를 종료합니다." 메시지 박스를 띄워 라즈베리파이 서버가 종료되었음을 알린다.

##### 데이터베이스
- MS-SQL 데이터베이스 파일인 SensorDB.mdf을 Visual Studio 2019에 연동하여 Temperature 테이블과 Moisture 테이블을 생성하였다.
    
    ![image](https://user-images.githubusercontent.com/49339278/147598804-b661a9a4-6098-41ed-8f0a-9529e82395c3.png)
    
    ```sql
    -- T-SQL
    -- id는 자동으로 1씩 증가하도록 지정해두었다.
    CREATE TABLE [dbo].[Temperature] (
    	[Id] INT IDENTITY (1, 1) NOT NULL,
    	[temp] NVARCHAR (50) NOT NULL,
    	[tret1] NVARCHAR (50) NOT NULL,
    	[tret2] NVARCHAR (50) NOT NULL,
    	[date] NVARCHAR (50) NOT NULL,
    	PRIMARY KEY CRUSTERED ([Id] ASC)
    );
    ```
    
    ![image](https://user-images.githubusercontent.com/49339278/147598850-7571f991-2334-4ca0-838e-0f419e4d4387.png)
    
    ```sql
    - T-SQL
    -- id는 자동으로 1씩 증가하도록 지정해두었다.
    CREATE TABLE [dbo].[Moisture] (
    	[Id] INT IDENTITY (1, 1) NOT NULL,
    	[moist] NVARCHAR (50) NOT NULL,
    	[tret1] NVARCHAR (50) NOT NULL,
    	[tret2] NVARCHAR (50) NOT NULL,
    	[date] NVARCHAR (50) NOT NULL,
    	PRIMARY KEY CRUSTERED ([Id] ASC)
    );
    ```
    
- 라즈베리파이에서 전송된 데이터를 읽고 처리하는 스레드(PiThreadRead)에서 myLibrary.dll 파일에 있는 InsertDB 함수를 사용하여 온도, 습도, DHT-11 센서 에러 유무, 날짜와 시간을 Temperature 테이블과 Moisture 테이브를 입력할 수 있는 insert SQL을 입력하고 실행시킨다.
    
    ```csharp
    void InsertDB(string temp, string moist, string tret1, string tret2, string date)
    {
    	sqlTemp = $"INSERT INTO Temperature (temp, tret1, tret2, date) VALUES ('{temp}', '{tret1}', '{tret2}', '{date}')";
    	sqlMoist = $"INSERT INTO Moisture (moist, tret1, tret2, date) VALUES ('{moist}', '{tret1}', '{tret2}', '{date}')";
    	sqldb.Run(sqlTemp);
    	sqldb.Run(sqlMoist);
    }
    ```
    
- 온도 데이터베이스와 습도 데이터베이스를 확인하기 위해 아래와 같이 상태 표시줄에 DB 목록 메뉴 아이템을 생성한 후, 온도 메뉴와 습도 메뉴를 생성하였다.
![image](https://user-images.githubusercontent.com/49339278/147598898-895b28f4-50a7-4238-8f21-091a069973f7.png)

- 온도 메뉴와 습도 메뉴를 클릭하면 데이터베이스를 확인할 수 있도록 온도 데이터베이스 조회 클릭 함수와 습도 데이터베이스 조회 클릭 함수를 생성하였다.

```csharp
// 온도 데이터베이스 조회
private void TempTable_Click(object sender, EventArgs e)
{
	string sql = "select * from Temperature";
	sqldb.Render(sql);
}

// 습도 데이터베이스 조회
private void MoistTable_Click(object sender, EventArgs e)
{
  string sql = "select * from Moisture";
	sqldb.Render(sql);
}
```

![image](https://user-images.githubusercontent.com/49339278/147598915-013548f4-e8d4-4593-8d0c-535037abaa54.png)

##### 정보 분석

- DB에 적재한 DHT-11 에러 유무 데이터를 활용하여 센서 정확도를 측정하고자 한다.
- 1034개 데이터 중, 579개 데이터를 정보 분석에 사용하였다.
    - 2021년 11월 23일 14시 49분 이전 데이터와 25일 16시 25분 38초부터 30일 10시 4분 3초 데이터는 테스트를 위해 입력된 데이터이므로 제외하였다.

- 정보 분석을 하기 위해, MS-SQL의 SensorDB.mdf 파일에 있는 온도 DB와 습도 DB 자료를 검토한 후, 탭 키로 구분하여 텍스트 파일로 자료를 처리하였고, R 프로그램의 dplyr 패키지를 활용하여 데이터를 분석하였다.
  - [R 코드](https://github.com/yeonseoksong/Server/blob/master/accuracy%20test.R)
- ![image](https://user-images.githubusercontent.com/49339278/147599325-1d4a2f94-7f71-4996-866f-e2812380df07.png)

- 결과
    
    | Tret2   \  Tret1 | 1 (정상) | -1 (오류) | 합계 |
    |:---:|:---:|:---:|:---:|
    | 1 (정상) | 543 | 20 | 563 |
    | -1 (오류) | 13 | 3 | 16 |
    | 합계 | 556 | 23 | 579 |
    - 579개 데이터를 분석한 결과, 두 센서가 모두 정상인 데이터는 543개, 한 센서만 정상인 데이터는 33개, 모두 오류인 경우는 3개로, 정확도는 543/579 = 0.938로 높은 정확도를 가지고 있는 것을 확인하였다.

##### 위험 경보
- 도마뱀 중 크레스티드 게코 도마뱀의 사육 적정 온도는 18도 ~ 27도이고, 사육 적정 습도는 60% ~ 80%이다. 목도리도마뱀의 경우 사육 적정 온도는 23.9도 ~ 37.7도이고, 사육 적정 습도는 55 ~ 65%이므로 키우는 파충류의 특성에 맞게 최소 온도와 최대 온도, 최소 습도와 최대 습도를 설정할 수 있도록 구현하였다.
- 사육 적정 온도와 습도에서 벗어나면 tbServer 텍스트박스와 tbServerLog 텍스트 박스를 빨갛게 표시하여 위험 경보를 알리도록 구현하였다.
![image](https://user-images.githubusercontent.com/49339278/147599760-3d30176e-4368-4e73-87af-a0ac55a15d5b.png)

- 사육 적정 온도 기본 값은 25 ~ 35 ℃, 적정 습도 기본 값 40% ~ 55% 범위를 기준으로 설정하였다.
- 만약 키우는 도마뱀의 사육 적정 온습도가 다르다면, 상태 표시줄에 있는 온습도 설정에 들어가서 ‘기타’를 클릭하고 사육 적정 온습도 범위를 지정할 수 있다.
![image](https://user-images.githubusercontent.com/49339278/147599770-3ade8422-40d4-48c3-9178-25a19307eac5.png)

#### Android <-> Server
![image](https://user-images.githubusercontent.com/49339278/147595452-1ca9c12a-3dfa-4bf6-8d23-d44556989b2a.png)
1. 안드로이드 서버 생성
    - 서버 시작 버튼을 누르면 안드로이드 서버 소켓을 생성하고, 소켓에 포트번호 9000을 부여한다. 이후 listen을 시작하여 안드로이드와 서버가 연결일 될 때까지 접속을 기다린다.
    - 만약 안드로이드 서버가 이미 생성되어 있다면 "안드로이드 서버를 다시 시작하시겠습니까?라는 메시지 팝업을 띄운다. OK를 클릭하면 안드로이드 서버 listen을 종료하고 안드로이드 스레드를 모두 종료시킨 후에 다시 안드로이드 서버를 생성한다.
    - 이후 안드로이드의 연결 요청을 처리할 수 있는 ```AndroidThreadServer``` 스레드와 안드로이드에서 전송된 데이터를 읽고 처리할 수 있는 ```AndroidThreadRead``` 스레드, 서버에서 안드로이드로 데이터를 전송하는 ```AndroidThreadSend``` 스레드를 시작한다.

2. Android Server Process : 안드로이드 Connect 요구 처리 스레드(AndroidThreadServer)에서 실행되는 함수
    - 안드로이드에서 연결 요청이 들어오면, 연결 요청을 수락하는 기능을 가진 ```AcceptTcpClient()``` 함수를 호출하여 안드로이드 연결에 대한 새로운 소켓을 생성한다.
    - 안드로이드와 서버가 연결이 되었으므로, 안드로이드와 서버의 연결 상태를 나타내는 변수의 값을 1로 설정하여 안드로이드와 서버는 연결이 되었음을 저장하고, 이를 전송한다.
    - 이후 연결 확인을 위해 최근에 저장된 데이터와 안드로이드-서버 연결 상태 변수의 값을 안드로이드로 전송하여 안드로이드와 연결이 성공적으로 이루어져 있음을 알린다.

3. Android Read Process : 안드로이드에서 전송된 데이터를 읽고 처리하는 스레드(AndroidThreadRead)에서 실행되는 함수
    - 안드로이드로부터 받은 설정 온습도, 자동급여 On/Off 여부 데이터를 저장하고 온습도 메뉴의 설정 온도와 설정 습도 현황판에 입력시킨다.

4. Android Send Process : 서버에서 안드로이드로 데이터를 전송하는 스레드(AndroidThreadSend)에서 실행되는 함수
    - 서버에서 안드로이드로 온습도, 물통 수위, 자동급여 On/Off 여부, 급여기 현황, 서버와 안드로이드 연결 상태 데이터를 전송한다.
    - 안드로이드와 서버는 서로 연결 중인 상태이므로 안드로이드-서버 연결 상태 변수에 1을 입력한다.

5. Android Server Off : 안드로이드 서버 종료
    - 안드로이드와 서버의 연결이 종료되므로 안드로이드와 서버의 연결 상태를 나타내는 변수 값을 0으로 설정한다.
    - 서버를 종료하기 전에 마지막 설정 값인 온습도, 물통 수위, 자동급여 On/Off 여부, 급여기 현황, 서버와 안드로이드 연결 상태 데이터를 전송한다.
    - 이후 스레드를 모두 종료하여 안드로이드 서버를 종료하고, "안드로이드 서버를 종료합니다." 메시지 박스를 띄워 안드로이드 서버가 종료되었음을 알린다.

#### 서버 프로그램 종료
- 실행 중인 스레드를 모두 종료한다.
- 프로그램 종료 시, 라즈베리파이에 설정 온습도, 자동급여 On/Off 여부, 서버와 라즈
베리 파이 연결 상태 데이터를 전송한다. 연결이 끊어지므로 서버-라즈베리파이 연결
상태 값은 0으로 전송된다.
- 마찬가지로 안드로이드에 온습도, 물통 수위, 자동급여 On/Off 여부, 급여기 현황,
안드로이드와 서버 연결 상태 데이터를 전송한다. 연결이 끊어지므로 안드로이드-서버
연결 상태 값은 0으로 전송된다.
- currentData.ini 파일에 온습도, 설정 온습도, 물통 수위, 자동급여 On/Off 여부, 급여
기 현황, 사육장 적정 최대/최소 온습도 데이터를 저장한다

### 4. 참고 자료
- [서버 프로그램 테스트용 프로그램](https://github.com/yeonseoksong/ServerTest)
- [myLibrary.dll 함수 관련 사이트](https://github.com/phantasmist/myLibrary)
- [예제로 배우는 C# 프로그래밍](http://www.csharpstudy.com/)
- KOSTA IoT 기반의 스마트 시스템 개발자 양성 과정
