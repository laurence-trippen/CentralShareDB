; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "CentralShareDB-Client"
!define PRODUCT_VERSION "1.0"
!define PRODUCT_PUBLISHER "Laurence Trippen"
!define PRODUCT_WEB_SITE "https://github.com/laurence-trippen"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\CentralShareDB-Client.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "..\..\..\..\Downloads\server.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Language Selection Dialog Settings
!define MUI_LANGDLL_REGISTRY_ROOT "${PRODUCT_UNINST_ROOT_KEY}"
!define MUI_LANGDLL_REGISTRY_KEY "${PRODUCT_UNINST_KEY}"
!define MUI_LANGDLL_REGISTRY_VALUENAME "NSIS:Language"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
!define MUI_LICENSEPAGE_RADIOBUTTONS
!insertmacro MUI_PAGE_LICENSE "D:\Documents\NSIS\LICENSE.txt"
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!define MUI_FINISHPAGE_RUN "$INSTDIR\CentralShareDB-Client.exe"
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_LANGUAGE "French"
!insertmacro MUI_LANGUAGE "German"

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "D:\Documents\NSIS\CentralShareDB-Client-Setup.exe"
InstallDir "$PROGRAMFILES\CentralShareDB-Client"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

Function .onInit
  !insertmacro MUI_LANGDLL_DISPLAY
FunctionEnd

Section "Hauptgruppe" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "D:\Documents\NSIS\CentralShareDB-Client\System.Runtime.InteropServices.RuntimeInformation.dll"
  File "D:\Documents\NSIS\CentralShareDB-Client\System.Buffers.dll"
  File "D:\Documents\NSIS\CentralShareDB-Client\MongoDB.Driver.xml"
  File "D:\Documents\NSIS\CentralShareDB-Client\MongoDB.Driver.dll"
  File "D:\Documents\NSIS\CentralShareDB-Client\MongoDB.Driver.Core.xml"
  File "D:\Documents\NSIS\CentralShareDB-Client\MongoDB.Driver.Core.dll"
  File "D:\Documents\NSIS\CentralShareDB-Client\MongoDB.Bson.xml"
  File "D:\Documents\NSIS\CentralShareDB-Client\MongoDB.Bson.dll"
  File "D:\Documents\NSIS\CentralShareDB-Client\DnsClient.xml"
  File "D:\Documents\NSIS\CentralShareDB-Client\DnsClient.dll"
  File "D:\Documents\NSIS\CentralShareDB-Client\CentralShareDB-Client.pdb"
  File "D:\Documents\NSIS\CentralShareDB-Client\CentralShareDB-Client.exe.config"
  File "D:\Documents\NSIS\CentralShareDB-Client\CentralShareDB-Client.exe"
  CreateDirectory "$SMPROGRAMS\CentralShareDB-Client"
  CreateShortCut "$SMPROGRAMS\CentralShareDB-Client\CentralShareDB.lnk" "$INSTDIR\CentralShareDB-Client.exe"
  CreateShortCut "$DESKTOP\CentralShareDB.lnk" "$INSTDIR\CentralShareDB-Client.exe"
SectionEnd

Section -AdditionalIcons
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\CentralShareDB-Client\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\CentralShareDB-Client\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\CentralShareDB-Client.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\CentralShareDB-Client.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd


Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) wurde erfolgreich deinstalliert."
FunctionEnd

Function un.onInit
!insertmacro MUI_UNGETLANGUAGE
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "M�chten Sie $(^Name) und alle seinen Komponenten deinstallieren?" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\CentralShareDB-Client.exe"
  Delete "$INSTDIR\CentralShareDB-Client.exe.config"
  Delete "$INSTDIR\CentralShareDB-Client.pdb"
  Delete "$INSTDIR\DnsClient.dll"
  Delete "$INSTDIR\DnsClient.xml"
  Delete "$INSTDIR\MongoDB.Bson.dll"
  Delete "$INSTDIR\MongoDB.Bson.xml"
  Delete "$INSTDIR\MongoDB.Driver.Core.dll"
  Delete "$INSTDIR\MongoDB.Driver.Core.xml"
  Delete "$INSTDIR\MongoDB.Driver.dll"
  Delete "$INSTDIR\MongoDB.Driver.xml"
  Delete "$INSTDIR\System.Buffers.dll"
  Delete "$INSTDIR\System.Runtime.InteropServices.RuntimeInformation.dll"

  Delete "$SMPROGRAMS\CentralShareDB-Client\Uninstall.lnk"
  Delete "$SMPROGRAMS\CentralShareDB-Client\Website.lnk"
  Delete "$DESKTOP\CentralShareDB.lnk"
  Delete "$SMPROGRAMS\CentralShareDB-Client\CentralShareDB.lnk"

  RMDir "$SMPROGRAMS\CentralShareDB-Client"
  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd