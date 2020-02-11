OFCT 2-2용 스트리밍 키트
20200130 yhsphd / yhsphd05@gmail.com

//설정 순서
1. 대회 관전용 클라이언트 osu!tourney를 설치해주세요.
	· https://osu.ppy.sh/help/wiki/osu!tourney에서 osu!tourney에 대한 **거의 모든** 정보를 읽을 수 있습니다!
	· tournemant.cfg 파일은 본 폴더에 들어 있는 샘플 설정을 사용해주세요.
	· tournament.cfg 파일을 생성하기 전, 새로 생성한 osu! 설치에서
		히트 라이트닝 : 꺼짐
		Seasonal backgrounds : Never
	설정을 변경해주세요. 만약 이미 토너먼트 클라이언트를 만들었을 떄에는
	tournament.cfg 파일의 이름을 잠시 변경해 일반 osu!를 켜서 설정을 바꾸거나,
	토너먼트 클라이언트 폴더의 osu!.(Windows계정이름).cfg 파일을 열어
		HitLighting = 0
		SeasonalBackgrounds = Never
	로 수정해주세요.
	
2. osu!tourney에 스킨을 설치해주세요.
	· https://o365sen-my.sharepoint.com/:u:/g/personal/yhsphd05_o365sen_net/EfMoRBLFe55El-vVjwpDVNkBnvrS7dXKg4WLk6kHbWv7hQ?e=ggUaQx
	에서 OFCT 스킨을 다운로드 받아, 압축 해제한 User, User_Blue 폴더를 osu!tourney 폴더의 Skins 폴더에 넣어주세요.
	
3. irc 클라이언트를 설정해주세요.
	· HexChat https://hexchat.github.io/ 을 기준으로 설명합니다.
	· irc에 익숙하시다면 다른 클라이언트를 사용하셔도 무방합니다.
	· OFCTloaderConfig.cfg 파일의 HexchatLocation 설정을 수정하면 OFCT loader의 자동 시작 기능도 사용할 수 있습니다.
	
	· Network List 창에서 대화명, 사용자 이름에 osu! 닉네임을 입력합니다.
	· Network List 창에서 추가 버튼을 누른 다음 네트워크 이름을 정합니다.
	· 편집 버튼을 누르고, newserver/6667이라 표시된 주소를 irc.ppy.sh/6667로 변경합니다.
	· https://old.ppy.sh/p/irc에서 irc 암호를 복사하여 암호 칸에 넣습니다.
	· 설정을 완료한 후, Network List에서 방금 추가한 osu! irc 네트워크를 선택하고 연결 버튼을 누르면 irc에 연결할 수 있습니다.
	· osu! irc는 osu! 게임 내에서 F9를 눌러 뜨는 채팅 기능과 동일합니다.

4. 폰트를 설치해주세요. (처음 설치하시는 분들 (이전에 설치하셨던 분들도 확인해주세요.))
	https://befonts.com/wp-content/uploads/2018/08/product-sans.zip
	https://noto-website-2.storage.googleapis.com/pkgs/NotoSansCJKkr-hinted.zip
	https://fonts.google.com/specimen/Exo+2
	
5. OBS 폴더의 OFCT 2-2.json 파일을 텍스트 에디터로 열어주세요. (파일을 변경하는 작업이니 복사해 사본을 남겨두면 좋아요.)
6. (메모장) Ctrl + H를 눌러 바꾸기 창을 여세요.
7. 찾을 내용에
		D:/Games/OFCT/Season2/202001_2/StreamKit
	, 바꿀 내용에는 스트림 키트 폴더의 경로를 적어주세요.
	
	· 폴더 경로를
		D:\Games\OFCT\Season2\202001_2\StreamKit
      와 같이 슬래시(/) 대신 역슬래시(\)로 표현하여 작성하면 문제가 발생하니 유의해주세요.
	  
	· 폴더 경로를 바꿀 내용 칸에 적을 때 맨 뒤에 / 또는 \가 있다면 지워주세요.
		(맨 끝에 스트림 키트 폴더 이름만 남게 해주세요.)
		
8. 모두 바꾸기를 누르고 저장해주세요.


9. OBS를 실행하는 바로가기 파일의 속성을 열어주세요.
10. 대상 칸 내용의 맨 끝에
		(공백)--allow-file-access-from-files
	를 추가하고 적용해주세요.
	
	· 시작 메뉴에서 OBS를 실행하신다면, 시작 메뉴에서 OBS를 찾은 뒤 우클릭하여 파일 위치 열기를 눌러주세요.
	  바로가기 파일을 찾을 수 있습니다.
		
11. OBS를 켜고 상단 메뉴에서
		장면 모음/가져오기
	를 눌러 OFCT 2-2.json 파일을 가져오세요.
	
12. 장면 모음 가져오기가 성공하였다면 장면을 넘길 때의 효과, 각 장면의 요소들을 볼 수 있습니다.
		· 만약 가져오기가 실패하였다면 검은 화면이 보입니다. 대부분 3번에서 실수가 발생하니,
		백업본을 이용하여 2번부터의 내용을 다시 따라해 주세요.
		
13. 프로파일을 가져와 주세요. (처음 설치하시는 분들)
	· OBS에서
		프로파일/가져오기
	를 눌러 OBS 폴더 안의 OFCT 폴더를 선택해주세요.
	· 성공하였다면 프로파일 메뉴에서 OFCT 프로파일을 선택할 수 있습니다.
	· 비트레이트, 녹화 저장 경로, 단축키 등을 자신의 환경에 맞춰 조절해주세요.
		· ~~공리 인터넷의 ㄹㅈㄷ속도 때문에~~ 비트레이트가 매우 낮은 수준으로 설정되어 있습니다.
		· 인터넷 속도 테스트를 https://www.speedtest.net/ 에서 실행하여
		업로드 속도가 20Mbps 이상 나온다면 7500~10000의 값으로 설정해주세요.
		
(Tip1) InGame 장면에서 화면 캡처 아래가 잘려 보여요!
	· 공리 모니터가 일반적인 16:9 비율이 아닌 1920x1200 16:10 비율이고, 이를 기준으로 만들어져 생기는 문제입니다.
	· Clients 소스를 클릭한 뒤 Ctrl + E를 눌러 자르기 아래 값을 465로 바꿔주세요.
	· 다시 소스를 클릭한 뒤 필터를 누른 뒤 3p 필터의 경로를
		스트림키트/Assets/Clientmask/ClientMask_(모니터 세로 해상도)_(클라이언트 세로 해상도).png
	로 바꿔주세요. ex)1920x1080 모니터에서 720p 클라이언트를 띄웠을 때 ClientMask_1080p_720p.png
	· 클라이언트 세로 해상도는 토너먼트 클라이언트 폴더의 tournament.cfg 파일에서 볼 수 있습니다.
	· 3p 필터를 끄면 디스플레이 캡처가 3인 클라이언트 모양으로 잘리지 않아, 1, 2 또는 4인 관전이 필요할 때 사용할 수 있습니다.
	
(Tip2) osu!/Screen 장면에서 화면 캡처 아래가 잘려 보여요!
	· Monitor#1@16:9 소스의 자르기 아래 값을 0으로 바꿔주세요.
	
(Tip3) 토너먼트 클라이언트의 소리가 너무 커요!
	· 첫 번째 클라이언트에서 마우스 휠을 굴려 볼륨을 조절해주세요.
	
(Tip4) irc 네트워크 편집 창에서 "이 네트워크에 자동 연결"에 체크하면, HexChat을 실행할 때 osu! irc에 자동으로 연결합니다.
(Tip5) irc 네트워크 편집 창의 연결 명령 탭에서 query banchobot 명령어를 추가하면,
		접속하면서 BanchoBot과의 귓속말을 바로 열 수 있어 로비를 생성할 때 유용합니다.
	

//방송 순서
1. 스트림 키트의 OFCTloader.cmd 파일을 실행해주세요.
	· .Net Framework 4.7.2 이상이 필요합니다. 만약 실행이 되지 않으면
		https://dotnet.microsoft.com/download/dotnet-framework
	에서 최신 버전을 설치해주세요.
	
2. 방송에 필요한 정보를 입력한 뒤 설정 버튼을 눌러주세요. 방송 정보, 팀 정보가 자동으로 업데이트됩니다.
	· 팀명은 정확하게 입력하여야 하므로 PlayerList.csv 파일을 참고해주세요.
	· 라운드 예시 : 예선 1라운드, 패자 2라운드, 결선 4강, 결승전
	· 경기 일정 예시 : 2020.01/22(수) 09:03 KST
	· 방송 제목 예시 : 예선 2라운드 맵풀 쇼케이스, 뒤풀이
	
3. 방송 시작 상자에서 실행할 프로그램을 선택한 후 실행 버튼을 눌러 실행해주세요.
	· 예를 들어, 맵풀 쇼케이스 방송에서는 Hexchat, osu!tourney, mapPick.csv를 사용하지 않습니다.
	· OFCTloaderConfig.cfg 파일의 osu!TourneyLocation 태그를 작성해주셔야 osu!Tourney를 실행할 수 있습니다.
	· osu!StateReader 프로그램은 스트림 키트 폴더의 osuStateReader.cmd를 실행하여 열 수도 있습니다.
	
4. irc에 접속해주세요.
	· 다른 심판이 멀티플레이어 로비를 먼저 판다면, 심판에게 "addref"를 요청해 권한을 받은 뒤, HexChat에서
		/join #mp_(mp번호, 괄호 x, 어디서나 가능)
	를 입력하여 로비 채팅에 들어옵니다.
	· 로비를 생성하기 위해서는,
		/query BanchoBot
	을 입력하여(어디서나 가능) BanchoBot과의 귓속말을 열고, BanchoBot에게
		!mp make (로비 이름, 괄호 x)
	채팅을 보내면 #mp_(로비 번호) 형식의 로비가 생성됩니다. 이때 방 제목은
		OFCT2:(레드 팀, 괄호o)vs(블루 팀, 괄호o)
	형식이어야 합니다.
	
5. osu!tourney가 실행되면, 클라이언트를 준비해주세요.
	· osu!tourney는 HexChat보다 먼저 실행하면 안 됩니다.
	· osu!tourney가 먼저 bancho에 접속하면 HexChat이 irc에 접속할 수 없습니다.
	· HexChat이 irc 접속에 계속 실패하면, osu!tourney를 끄고 HexChat이 irc에 접속할 때까지 기다려 주세요.
	· HexChat과 osu!tourney 모두 준비되면, osu!tourney에서 관전할 로비를 선택해주세요.
	· 왼쪽의 클라이언트들은 레드 팀, 오른쪽의 클라이언트들은 블루 팀입니다.
	· 블루 팀 클라이언트들의 스킨을 User_Blue로 변경해 주세요.

6. 디스코드의 음성채팅방 볼륨을 조정하고, OBS를 열어 방송을 시작합니다.
	· 방송을 시작하기 전, 트위치 방송 제목과 생방송 알림을 업데이트 해 주세요.
		방송 제목 예시
			· OFCT2-2 예선 1라운드 맵풀 쇼케이스
			· OFCT2-2 예선 1라운드 Team Tofunim vs. Team [RyuTell]
		생방송 알림 예시
			· OFCT2-2 예선 1라운드 맵풀 쇼케이스 방송이 시작되었습니다!
			· Team Tofunim vs. Team [RyuTell] 경기가 시작되었습니다!
			
	· 방송을 시작하기 전, OFCT 프로파일과 OFCT2-2 장면 모음이 선택되어 있는지 반드시 확인해 주세요.
	
(Tip1) 쇼케이스 등의 방송으로 osu!/Screen 장면을 보고 계시다면,
	· osu!@720p(1280x720 해상도로 실행중인 osu! 창 캡처)
	· Monitor#1@16:9(메인 모니터 전체 화면 캡처)
	소스 2개를 자물쇠 옆의 눈 모양을 클릭하여 숨기거나 보이게 해 사용할 수 있습니다.

(Tip2) 방송 중 잘못 작동하는 소스가 있으면 눈 모양을 두 번 클릭하여 새로고침 해주세요.
	· 만약 정상화되지 않는다면 osu!StateReader 프로그램을 재시작한 다음 소스를 새로고침 해주세요.
	· 그리고 공리를 탓하시면 됩니다.


스트림 키트 사용 중 문제점이나 문의사항, 질문 사항은 Discord yhsphd#1952로 연락주세요!


· 본 스트림 키트의
	Assets/GongliPsa.png
	Sources/jquery-3.3.1.min.js
	Sources/Microsoft.WindowsAPICodePack.dll
	Sources/Microsoft.WindowsAPICodePack.Shell.dll
	Sources/Newtonsoft.Json.dll
	Sources/OsuMemoryDataProvider.dll
	Sources/papaparse.min.js
	Sources/ProcessMemoryDataFinder.dll
	Sources/textFit.min.js
	Sources/websocket-sharp.dll
를 제외한 모든 파일은 전적으로 제가 작성하거나, 프로그래밍하거나, 디자인하였습니다.
저 혼자서 생성한 파일에 대해서는 자유로운 가공이나 사용, 재배포가 가능합니다.
하지만 나열된 파일은 제가 이외의 소스에서 가져온 파일을 사용하였거나 제가 생성하지 않은 파일이니 재배포 등의 행동에 주의해 주시기 바랍니다.
감사합니다.

yhsphd05@gmail.com으로 키트 내 사용된, 제가 프로그래밍한 프로그램의 소스를 요청할 수 있습니다.