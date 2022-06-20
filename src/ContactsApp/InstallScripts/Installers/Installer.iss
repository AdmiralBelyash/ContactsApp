#define Name "ContactsApp"
#define Version "0.0.1"
#define Publisher  "Ivan Burakov"
#define URL "https://github.com/AdmirallBelyash"
#define ExeName "ContactsApp"

[Setup]
AppId = {{AC2F2855-FF95-4C0D-81EB-46E4052298FE}

AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

DefaultDirName = {pf}\{#Name}
DefaultGroupName = {#Name}

OutputDir=..\setup
OutputBaseFileName=setup

SetupIconFile=contacts_app.ico

Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
; Создание иконки на рабочем столе
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; Исполняемый файл
Source: "..\Release\ContactsApp.View.exe"; DestDir: "{app}"; Flags: ignoreversion

; Прилагающиеся ресурсы
Source: "..\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"
Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon