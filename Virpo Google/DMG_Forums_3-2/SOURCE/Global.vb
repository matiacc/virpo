'#########################################################################################################
' DMG Forums
' Copyright (c) 2005-2009
' by Dustin Grimmeissen and DMG Development
' 
' The DMG Forums application is free and open source software.  It may be modified and deployed in any way
' and in any environment.  The application may not be redistributed for profit without the express written
' consent of Dustin Grimmeissen and DMG Development, based in the United States of America and the State
' of Indiana.
' 
' All copyright notices within this program, including this one, must remain intact at all times.  The DMG
' Forums hyperlink with link back to http://www.dmgforums.com must remain visible in your outputted HTML.
' 
' For the full end-user license agreement, visit the license agreement section of http://www.dmgforums.com
'#########################################################################################################

Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Environment
Imports System.Net.Mail
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Web.SessionState
Imports Microsoft.VisualBasic

Namespace DMGForums.Global

	'---------------------------------------------------------------------------------------------------
	' Database - Class For Connecting To The Database
	'---------------------------------------------------------------------------------------------------
	Public Class Database
		Public Shared ConnString as String = System.Configuration.ConfigurationManager.AppSettings("DatabaseString")
		Public Shared DBPrefix as String = System.Configuration.ConfigurationManager.AppSettings("DatabasePrefix")
		Public Shared DBType as String = System.Configuration.ConfigurationManager.AppSettings("DatabaseType")

		Public Shared Function Read(strSql as String, Optional Rows as Integer = 0) as OdbcDataReader
			if (Rows <> 0) then
				if (DBType = "MySQL") then
					strSql = strSql & " LIMIT " & Rows
				else
					strSql = strSql.Replace("SELECT", "SELECT TOP " & Rows)
				end if
			end if

			Dim Connection as OdbcConnection = new OdbcConnection(ConnString)
			Connection.Open()
				Dim Command as OdbcCommand = new OdbcCommand(strSql, Connection)
				Return Command.ExecuteReader(CommandBehavior.CloseConnection Or CommandBehavior.SingleResult)
			Connection.Close()
		End Function
	
		Public Shared Sub Write(strSql as String)
			Dim Connection as OdbcConnection = new OdbcConnection(ConnString)
			Connection.Open()
				Dim Command as OdbcCommand = new OdbcCommand(strSql, Connection)
				Command.ExecuteNonQuery()
			Connection.Close()
		End Sub

		Public Shared Function GetTimeStamp(Optional SubtractDays as Integer = 0) as String
			if (DBType = "MySQL") then
				if (SubtractDays <> 0) then
					Return "DATE_SUB(CURRENT_TIMESTAMP(), INTERVAL " & SubtractDays & " DAY)"
				else
					Return "CURRENT_TIMESTAMP()"
				end if
			else
				if (SubtractDays <> 0) then
					Return "GETDATE()-" & SubtractDays
				else
					Return "GETDATE()"
				end if
			end if
		End Function

		Public Shared Function GetDateDiff(Units as String, FirstDate as String, SecondDate as String) as String
			if (DBType = "MySQL") then
				if (Units = "ss") then
					Return "TIME_TO_SEC(TIMEDIFF(" & SecondDate & "," & FirstDate & "))"
				else
					Return "DATEDIFF(" & SecondDate & ", " & FirstDate & ")"
				end if
			else
				Return "DATEDIFF(""" & Units & """, " & FirstDate & ", " & SecondDate & ")"
			end if
		End Function

		Public Shared Function DatabaseTimestamp(Optional SubtractDays as Integer = 0) as String
			Dim ReturnString as String = ""
			Dim Reader as OdbcDataReader
			if (DBType = "MySQL") then
				if (SubtractDays <> 0) then
					ReturnString = (DateTime.Now.AddDays((-1)*SubtractDays)).ToString("yyyy-MM-dd hh:mm:ss")
				else
					ReturnString = (DateTime.Now()).ToString("yyyy-MM-dd hh:mm:ss")
				end if
			else
				if (SubtractDays <> 0) then
					Reader = Database.Read("SELECT GETDATE()-" & SubtractDays & " as TheTime")
					While Reader.Read()
						ReturnString = Reader("TheTime").ToString()
					End While
					Reader.Close()
				else
					Reader = Database.Read("SELECT GETDATE() as TheTime")
					While Reader.Read()
						ReturnString = Reader("TheTime").ToString()
					End While
					Reader.Close()
				end if
			end if
			Return ReturnString
		End Function

		Public Shared Function GetAutoIncrement() as String
			if (DBType = "MySQL") then
				Return "AUTO_INCREMENT"
			else
				Return "IDENTITY"
			end if
		End Function

		Public Shared Function GetDBName() as String
			Dim ReturnString as String = ""
			Dim Connection as OdbcConnection = new OdbcConnection(ConnString)
			Connection.Open()
				ReturnString = Connection.Database.ToString()
			Connection.Close()
			Return ReturnString
		End Function

		Public Shared Function GetServerName() as String
			Dim ReturnString as String = ""
			Dim Connection as OdbcConnection = new OdbcConnection(ConnString)
			Connection.Open()
				ReturnString = Connection.DataSource.ToString()
			Connection.Close()
			Return ReturnString
		End Function

		Public Shared Function Type() as String
			Dim ReturnString as String = ""
			Dim Connection as OdbcConnection = new OdbcConnection(ConnString)
			Connection.Open()
				if Connection.Driver.ToString() = "SQLSRV32.DLL" then
					ReturnString = "SQL Server"
				else
					ReturnString = Connection.Driver.ToString()
				end if
			Connection.Close()
			Return ReturnString
		End Function

		Public Shared Function DatabaseConnection() as OdbcConnection
			Dim TheDB as OdbcConnection = new OdbcConnection(ConnString)
			Return TheDB
		End Function
	End Class


	'---------------------------------------------------------------------------------------------------
	' Header - Codebehind for inc_header.aspx
	'---------------------------------------------------------------------------------------------------
	Public Class Header
		Inherits System.Web.UI.UserControl
	End Class


	'---------------------------------------------------------------------------------------------------
	' Footer - Codebehind for inc_footer.aspx
	'---------------------------------------------------------------------------------------------------
	Public Class Footer
		Inherits System.Web.UI.UserControl
	End Class


	'---------------------------------------------------------------------------------------------------
	' Settings - Codebehind for inc_settings.aspx
	'---------------------------------------------------------------------------------------------------
	Public Class Settings
		Inherits System.Web.UI.UserControl

		Public Shared DefaultTemplate as Integer = 1
		Public Shared PageTitle as String = "DMG Forums"
		Public Shared ForumLogo as String = ""
		Public Shared SiteURL as String = ""
		Public Shared FontFace as String = "arial,helvetica"
		Public Shared FontSize as String = "2"
		Public Shared BGColor as String = "silver"
		Public Shared BGImage as String = ""
		Public Shared FontColor as String = "black"
		Public Shared LinkColor as String = "#190EAF"
		Public Shared LinkDecoration as String = "none"
		Public Shared ALinkColor as String = "#190EAF"
		Public Shared ALinkDecoration as String ="underline"
		Public Shared VLinkColor as String = "#190EAF"
		Public Shared VLinkDecoration as String = "none"
		Public Shared HLinkColor as String = "#190EAF"
		Public Shared HLinkDecoration as String = "underline"
		Public Shared ScrollbarColor as String = "#190EAF"
		Public Shared TopicsFontSize as String = "2"
		Public Shared TopicsFontColor as String = "black"
		Public Shared TableBGColor1 as String = "gainsboro"
		Public Shared TableBGColor2 as String = "whitesmoke"
		Public Shared TableBorderColor as String = "#060237"
		Public Shared LoginFontColor as String = "black"
		Public Shared HeaderColor as String = "#190EAF"
		Public Shared HeaderSize as String = "3"
		Public Shared HeaderFontColor as String = "#CDDC20"
		Public Shared SubHeaderColor as String = "#B6B6B6"
		Public Shared SubHeaderFontColor as String = "black"
		Public Shared FooterColor as String = "#190EAF"
		Public Shared FooterSize as String = "2"
		Public Shared FooterFontColor as String = "#CDDC20"
		Public Shared Copyright as String = "Copyright DMG Forums"
		Public Shared CustomHeader as String = ""
		Public Shared CustomFooter as String = ""
		Public Shared CustomCSS as String = ""
		Public Shared ItemsPerPage as Integer = 15
		Public Shared ButtonColor as String = "#190EAF"
		Public Shared SpamFilter as String = "30"
		Public Shared MetaKeywords as String = ""
		Public Shared ForumsDefault as Integer = 1
		Public Shared SideMargin as Integer = 10
		Public Shared TopMargin as Integer = 10
		Public Shared ShowStatistics as Integer = 1
		Public Shared MemberValidation as Integer = 0
		Public Shared MemberPhotoSize as Integer = 0
		Public Shared ThumbnailSize as Integer = 150
		Public Shared AvatarSize as Integer = 125
		Public Shared SearchTopics as Integer = 1
		Public Shared SearchMembers as Integer = 1
		Public Shared SearchBlogs as Integer = 1
		Public Shared SearchPages as Integer = 1
		Public Shared EmailSmtp as String = "mail.yourserver.com"
		Public Shared EmailPort as String = ""
		Public Shared EmailUsername as String = ""
		Public Shared EmailPassword as String = ""
		Public Shared EmailAddress as String = "mail@yourserver.com"
		Public Shared EmailAllowSend as Integer = 0
		Public Shared EmailAllowSub as Integer = 0
		Public Shared EmailWelcomeMessage as Integer = 0
		Public Shared AllowSub as Integer = 1
		Public Shared QuickRegistration as Integer = 0
		Public Shared CurseFilter as Integer = 0
		Public Shared RSSFeeds as Integer = 0
		Public Shared AllowRegistration as Integer = 1
		Public Shared AllowEdits as Integer = 1
		Public Shared AllowMedia as Integer = 1
		Public Shared HideMembers as Integer = 0
		Public Shared AllowReporting as Integer = 1
		Public Shared HideLogin as Integer = 0
		Public Shared HtmlTitle as String = "DMG Forums"
		Public Shared HorizDivide as String = "&nbsp;&nbsp;<b>|</b>&nbsp;&nbsp;"
		Public Shared VertDivide as String = "<br /><br />"
		Public Shared DMGVersion as String = "3.2"
		Public Shared DMGReleaseDate as String = "January 31, 2009"
		Public Shared DMGVersionText as String = "DMG Forums " & DMGVersion

		Private ShowBack as Boolean = true
		Public Property ShowBackground() as Boolean
			Get
				Return ShowBack
			End Get
			Set(ByVal Value as Boolean)
				if (Value = "false") then
					ShowBack = false
					CustomCSS = CustomCSS.Replace("BODY", ".DMGOldBody")
				else
					ShowBack = true
				end if
			End Set
		End Property

		Private CustTitle as String = ""
		Public Property CustomTitle() as String
			Get
				Return CustTitle
			End Get
			Set(ByVal Value as String)
				CustTitle = Value
			End Set
		End Property

		Public Sub New()
			Dim TemplateReader as OdbcDataReader = Database.Read("SELECT " & Database.DBPrefix & "_TEMPLATE_DEFAULT FROM " & Database.DBPrefix & "_SETTINGS WHERE ID = 1", 1)
				While(TemplateReader.Read())
					DefaultTemplate = TemplateReader(Database.DBPrefix & "_TEMPLATE_DEFAULT")
				End While
			TemplateReader.Close()

			Dim SettingsReader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_SETTINGS WHERE ID = " & DefaultTemplate)
				While(SettingsReader.Read())
				      PageTitle = SettingsReader(Database.DBPrefix & "_TITLE").ToString()
					FontFace = SettingsReader(Database.DBPrefix & "_FONTFACE").ToString()
					FontSize = SettingsReader(Database.DBPrefix & "_FONTSIZE").ToString()
					FontColor = SettingsReader(Database.DBPrefix & "_FONT_COLOR").ToString()
					BGColor = SettingsReader(Database.DBPrefix & "_BGCOLOR").ToString()
					BGImage = SettingsReader(Database.DBPrefix & "_BGIMAGE").ToString()
					LinkColor = SettingsReader(Database.DBPrefix & "_LINK_COLOR").ToString()
					LinkDecoration = SettingsReader(Database.DBPrefix & "_LINK_DECORATION").ToString()
					ALinkColor = SettingsReader(Database.DBPrefix & "_LINK_ACTIVE_COLOR").ToString()
					ALinkDecoration = SettingsReader(Database.DBPrefix & "_LINK_ACTIVE_DECORATION").ToString()
					VLinkColor = SettingsReader(Database.DBPrefix & "_LINK_VISITED_COLOR").ToString()
					VLinkDecoration = SettingsReader(Database.DBPrefix & "_LINK_VISITED_DECORATION").ToString()
					HLinkColor = SettingsReader(Database.DBPrefix & "_LINK_HOVER_COLOR").ToString()
					HLinkDecoration = SettingsReader(Database.DBPrefix & "_LINK_HOVER_DECORATION").ToString()
					ScrollbarColor = SettingsReader(Database.DBPrefix & "_SCROLLBAR_COLOR").ToString()
					TopicsFontSize = SettingsReader(Database.DBPrefix & "_TOPICS_FONTSIZE").ToString()
					TopicsFontColor = SettingsReader(Database.DBPrefix & "_TOPICS_FONTCOLOR").ToString()
					TableBGColor1 = SettingsReader(Database.DBPrefix & "_TOPICS_BGCOLOR1").ToString()
					TableBGColor2 = SettingsReader(Database.DBPrefix & "_TOPICS_BGCOLOR2").ToString()
					TableBorderColor = SettingsReader(Database.DBPrefix & "_TABLEBORDER_COLOR").ToString()
					LoginFontColor = SettingsReader(Database.DBPrefix & "_LOGIN_FONTCOLOR").ToString()
					HeaderColor = SettingsReader(Database.DBPrefix & "_HEADER_COLOR").ToString()
					HeaderSize = SettingsReader(Database.DBPrefix & "_HEADER_SIZE").ToString()
					HeaderFontColor = SettingsReader(Database.DBPrefix & "_HEADER_FONTCOLOR").ToString()
					SubHeaderColor = SettingsReader(Database.DBPrefix & "_SUBHEADER_COLOR").ToString()
					SubHeaderFontColor = SettingsReader(Database.DBPrefix & "_SUBHEADER_FONTCOLOR").ToString()
					FooterColor = SettingsReader(Database.DBPrefix & "_FOOTER_COLOR").ToString()
					FooterSize = SettingsReader(Database.DBPrefix & "_FOOTER_SIZE").ToString()
					FooterFontColor = SettingsReader(Database.DBPrefix & "_FOOTER_FONTCOLOR").ToString()
					Copyright = SettingsReader(Database.DBPrefix & "_COPYRIGHT").ToString()
					CustomHeader = SettingsReader(Database.DBPrefix & "_CUSTOM_HEADER").ToString()
					CustomFooter = SettingsReader(Database.DBPrefix & "_CUSTOM_FOOTER").ToString()
					CustomCSS = SettingsReader(Database.DBPrefix & "_CUSTOM_CSS").ToString()
					ItemsPerPage = SettingsReader(Database.DBPrefix & "_ITEMS_PER_PAGE")
					ButtonColor = SettingsReader(Database.DBPrefix & "_BUTTON_COLOR").ToString()
					ForumLogo = SettingsReader(Database.DBPrefix & "_LOGO").ToString()
					SiteURL = SettingsReader(Database.DBPrefix & "_URL").ToString()
					SpamFilter = SettingsReader(Database.DBPrefix & "_SPAM_FILTER").ToString()
					ForumsDefault = SettingsReader(Database.DBPrefix & "_FORUMS_DEFAULT")
					SideMargin = SettingsReader(Database.DBPrefix & "_MARGIN_SIDE")
					TopMargin = SettingsReader(Database.DBPrefix & "_MARGIN_TOP")
					ShowStatistics = SettingsReader(Database.DBPrefix & "_SHOWSTATISTICS")
					MetaKeywords = SettingsReader(Database.DBPrefix & "_CUSTOM_META").ToString()
					MemberValidation = SettingsReader(Database.DBPrefix & "_MEMBER_VALIDATION")
					MemberPhotoSize = SettingsReader(Database.DBPrefix & "_MEMBER_PHOTOSIZE")
					ThumbnailSize = SettingsReader(Database.DBPrefix & "_THUMBNAIL_SIZE")
					AvatarSize = SettingsReader(Database.DBPrefix & "_AVATAR_SIZE")
					SearchTopics = SettingsReader(Database.DBPrefix & "_SEARCH_TOPICS")
					SearchMembers = SettingsReader(Database.DBPrefix & "_SEARCH_MEMBERS")
					SearchBlogs = SettingsReader(Database.DBPrefix & "_SEARCH_BLOGS")
					SearchPages = SettingsReader(Database.DBPrefix & "_SEARCH_PAGES")
					EmailSmtp = SettingsReader(Database.DBPrefix & "_EMAIL_SMTP").ToString()
					EmailPort = SettingsReader(Database.DBPrefix & "_EMAIL_PORT").ToString()
					EmailUsername = SettingsReader(Database.DBPrefix & "_EMAIL_USERNAME").ToString()
					EmailPassword = SettingsReader(Database.DBPrefix & "_EMAIL_PASSWORD").ToString()
					EmailAddress = SettingsReader(Database.DBPrefix & "_EMAIL_ADDRESS").ToString()
					EmailAllowSend = SettingsReader(Database.DBPrefix & "_EMAIL_ALLOWSEND")
					EmailAllowSub = SettingsReader(Database.DBPrefix & "_EMAIL_ALLOWSUB")
					EmailWelcomeMessage = SettingsReader(Database.DBPrefix & "_EMAIL_WELCOMEMESSAGE")
					AllowSub = SettingsReader(Database.DBPrefix & "_ALLOWSUB")
					QuickRegistration = SettingsReader(Database.DBPrefix & "_QUICK_REGISTRATION")
					CurseFilter = SettingsReader(Database.DBPrefix & "_CURSE_FILTER")
					RSSFeeds = SettingsReader(Database.DBPrefix & "_RSS_FEEDS")
					AllowRegistration = SettingsReader(Database.DBPrefix & "_ALLOW_REGISTRATION")
					AllowEdits = SettingsReader(Database.DBPrefix & "_ALLOW_EDITS")
					AllowMedia = SettingsReader(Database.DBPrefix & "_ALLOW_MEDIA")
					HideMembers = SettingsReader(Database.DBPrefix & "_HIDE_MEMBERS")
					AllowReporting = SettingsReader(Database.DBPrefix & "_ALLOW_REPORTING")
					HtmlTitle = SettingsReader(Database.DBPrefix & "_HTML_TITLE")
					HideLogin = SettingsReader(Database.DBPrefix & "_HIDE_LOGIN")
					HorizDivide = SettingsReader(Database.DBPrefix & "_HORIZ_DIVIDE")
					VertDivide = SettingsReader(Database.DBPrefix & "_VERT_DIVIDE")
					DMGVersionText = "<a target=""_blank"" href=""http://www.dmgforums.com/"" style=""color: " & FooterFontColor & ";"">DMG Forums " & DMGVersion & "</a>"
				End While
			SettingsReader.close()
		End Sub
	End Class


	'---------------------------------------------------------------------------------------------------
	' Login - Codebehind For inc_login.ascx
	'---------------------------------------------------------------------------------------------------
	Public Class Login
		Inherits System.Web.UI.UserControl

		Public loginbutton As System.Web.UI.WebControls.Button
		Public logoutbutton As System.Web.UI.WebControls.Button
		Public usernamebox As System.Web.UI.WebControls.Textbox
		Public passwordbox As System.Web.UI.WebControls.Textbox
		Public rememberbox As System.Web.UI.WebControls.CheckBox

		Public ShowLoginPanel as Boolean = "true"

		Private ShowLoginBox as String = 2
		Public Property ShowLogin() as String
			Get
				Return ShowLoginBox
			End Get
			Set(ByVal Value as String)
				ShowLoginBox = Value
			End Set
		End Property 

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
			if (Session("ActiveLevel") is Nothing) or (Session("ActiveLevel") = 3) then
				Session("ActiveTime") = Database.DatabaseTimestamp(3)
			end if

			if (((Settings.HideLogin = 1) and (ShowLoginBox = 2)) or (ShowLoginBox = 0)) then
				ShowLoginPanel = "false"
			end if

			if Not Request.Cookies("dmgforums") Is Nothing then
				Dim aCookie As New System.Web.HttpCookie("dmgforums")

				Dim UserReader as OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL, MEMBER_DATE_LASTVISIT FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Server.HtmlEncode(Request.Cookies("dmgforums")("mukul")) & " AND MEMBER_PASSWORD = '" & Server.HtmlEncode(Request.Cookies("dmgforums")("gupta")) & "'", 1)
					While(UserReader.Read())
						Session("UserID") = UserReader("MEMBER_ID").ToString()
						Session("UserName") = UserReader("MEMBER_USERNAME").ToString()
						Session("UserLevel") = UserReader("MEMBER_LEVEL").ToString()
						Session("UserLogged") = "1"
						if (Session("ActiveLevel") is Nothing) or (Session("ActiveLevel") = 3) then
							Session("ActiveLevel") = 1
							if (Database.DBType = "MySQL") then
								Session("ActiveTime") = Functions.FormatDate(UserReader("MEMBER_DATE_LASTVISIT"), 4)
							else
								Session("ActiveTime") = UserReader("MEMBER_DATE_LASTVISIT")
							end if
						end if
						aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
						aCookie.Values("mukul") = UserReader("MEMBER_ID").ToString()
						aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now() & "aaa")
						aCookie.Values("gupta") = UserReader("MEMBER_PASSWORD").ToString()
						aCookie.Expires = DateTime.Now.AddDays(30)
						Response.Cookies.Add(aCookie)
					End While
				UserReader.Close()

				DataBase.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_DATE_LASTVISIT = " & Database.GetTimeStamp() & ", MEMBER_IP_LAST = '" & Request.UserHostAddress() & "' WHERE MEMBER_ID = " & Session("UserID"))

				if ((Session("UserLevel") = 0) or (Session("UserLevel") = -1)) then
					aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
					aCookie.Values("mukul") = "-3"
					aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now() & "bbb")
					aCookie.Values("gupta") = Functions.Encrypt(DateTime.Now() & "ccc")
					aCookie.Expires = DateTime.Now.AddDays(-1)
					Response.Cookies.Add(aCookie)
					Session("UserID") = "-1"
					Session("UserName") = ""
					Session("UserLogged") = "0"
					Session("UserLevel") = "0"
				end if
			else
				if (Session("UserLogged") = "1") then
					Dim UserReader as OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL, MEMBER_DATE_LASTVISIT FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Session("UserID"), 1)
						While(UserReader.Read())
							Session("UserID") = UserReader("MEMBER_ID").ToString()
							Session("UserName") = UserReader("MEMBER_USERNAME").ToString()
							Session("UserLevel") = UserReader("MEMBER_LEVEL").ToString()
							Session("UserLogged") = "1"
							if (Session("ActiveLevel") is Nothing) or (Session("ActiveLevel") = 3) then
								Session("ActiveLevel") = 1
								if (Database.DBType = "MySQL") then
									Session("ActiveTime") = Functions.FormatDate(UserReader("MEMBER_DATE_LASTVISIT"), 4)
								else
									Session("ActiveTime") = UserReader("MEMBER_DATE_LASTVISIT")
								end if
							end if
						End While
					UserReader.Close()

					DataBase.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_DATE_LASTVISIT = " & Database.GetTimeStamp() & ", MEMBER_IP_LAST = '" & Request.UserHostAddress() & "' WHERE MEMBER_ID = " & Session("UserID"))

					if ((Session("UserLevel") = 0) or (Session("UserLevel") = -1)) then
						Dim aCookie As New System.Web.HttpCookie("dmgforums")
						aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
						aCookie.Values("mukul") = "-3"
						aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now() & "bbb")
						aCookie.Values("gupta") = Functions.Encrypt(DateTime.Now() & "ccc")
						aCookie.Expires = DateTime.Now.AddDays(-1)
						Response.Cookies.Add(aCookie)
						Session("UserID") = "-1"
						Session("UserName") = ""
						Session("UserLogged") = "0"
						Session("UserLevel") = "0"
					end if
				else
					Session("UserID") = "-1"
					Session("UserName") = ""
					Session("UserLogged") = "0"
					Session("UserLevel") = "0"
				end if
			end if
		End Sub

		Sub LoginUser(sender As System.Object, e As System.EventArgs)
			Dim aCookie As New System.Web.HttpCookie("dmgforums")
			Dim strUserName as String = Functions.RepairString(usernamebox.text)
			Dim strPassword as String = Functions.RepairString(passwordbox.text)
			strPassword = Functions.Encrypt(strPassword)
			Dim LoginReader as OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_PASSWORD, MEMBER_LEVEL, MEMBER_VALIDATED, MEMBER_VALIDATION_STRING, MEMBER_DATE_LASTVISIT FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_USERNAME = '" & strUserName & "' and MEMBER_PASSWORD = '" & strPassword & "' and (MEMBER_LEVEL <> 0) and ((MEMBER_LEVEL <> -1 and MEMBER_VALIDATED = 1) or (MEMBER_LEVEL = -1 and MEMBER_VALIDATED = 0))", 1)
				If LoginReader.HasRows then
					While(LoginReader.Read())
						if (LoginReader("MEMBER_VALIDATED") = 1) then
							if (rememberbox.Checked()) then
								aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
								aCookie.Values("mukul") = LoginReader("MEMBER_ID").ToString()
								aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now() & "aaa")
								aCookie.Values("gupta") = LoginReader("MEMBER_PASSWORD").ToString()
								aCookie.Expires = DateTime.Now.AddDays(30)
								Response.Cookies.Add(aCookie)
							end if
							Session("UserName") = strUserName
							Session("UserLogged") = "1"
							Session("UserID") = LoginReader("MEMBER_ID").ToString()
							Session("UserLevel") = LoginReader("MEMBER_LEVEL").ToString()
							if (Session("ActiveLevel") is Nothing) or (Session("ActiveLevel") = 3) then
								Session("ActiveLevel") = 1
								if (Database.DBType = "MySQL") then
									Session("ActiveTime") = Functions.FormatDate(LoginReader("MEMBER_DATE_LASTVISIT"), 4)
								else
									Session("ActiveTime") = LoginReader("MEMBER_DATE_LASTVISIT")
								end if
							end if
							DataBase.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_DATE_LASTVISIT = " & Database.GetTimeStamp() & ", MEMBER_IP_LAST = '" & Request.UserHostAddress() & "' WHERE MEMBER_ID = " & Session("UserID"))
							Response.Redirect(Page.ResolveUrl(Request.Url.ToString()))
						elseif ((LoginReader("MEMBER_VALIDATED") = 0) and (Settings.MemberValidation = 2)) then
							Functions.MessageBox("Incorrect Username/Password")
							aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
							aCookie.Values("mukul") = "-3"
							aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now() & "aaa")
							aCookie.Values("gupta") = Functions.Encrypt(DateTime.Now() & "bbb")
							aCookie.Expires = DateTime.Now.AddDays(-1)
							Response.Cookies.Add(aCookie)
							Session("UserID") = "-1"
							Session("UserName") = ""
							Session("UserLogged") = "0"
							Session("UserLevel") = "0"
							usernamebox.text = ""
							passwordbox.text = ""
						else
							Session("ValidateUserID") = LoginReader("MEMBER_ID").ToString()
							Response.Redirect("validate.aspx")
						end if
					End While
				Else
					Functions.MessageBox("Incorrect Username/Password")
					aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now() & "aaa")
					aCookie.Values("mukul") = "-3"
					aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now() & "bbb")
					aCookie.Values("gupta") = Functions.Encrypt(DateTime.Now() & "ccc")
					aCookie.Expires = DateTime.Now.AddDays(-1)
					Response.Cookies.Add(aCookie)
					Session("UserID") = "-1"
					Session("UserName") = ""
					Session("UserLogged") = "0"
					Session("UserLevel") = "0"
					usernamebox.text = ""
					passwordbox.text = ""
				End If
			LoginReader.close()
		End Sub

		Sub LogoutUser(sender As System.Object, e As System.EventArgs)
			Session("ActiveLevel") = 3
			Dim aCookie As New System.Web.HttpCookie("dmgforums")
			aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now() & "aaa")
			aCookie.Values("mukul") = "-3"
			aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now() & "bbb")
			aCookie.Values("gupta") = Functions.Encrypt(DateTime.Now() & "ccc")
			aCookie.Expires = DateTime.Now.AddDays(-1)
			Response.Cookies.Add(aCookie)
			Session("UserID") = "-1"
			Session("UserName") = ""
			Session("UserLogged") = "0"
			Session("UserLevel") = "0"
			Response.Redirect("default.aspx")
		End Sub
	End Class


	'---------------------------------------------------------------------------------------------------
	' Functions - Class To Store Global Functions
	'---------------------------------------------------------------------------------------------------
	Public Class Functions
		Public Shared Function IsDBNull(ByVal dbvalue as Object) As Boolean
		     Return dbvalue Is DBNull.Value 
		End Function

		Public Shared Function IsInteger(ByVal TheString as String) As Boolean
			if TheString is Nothing then
				Return False
			else
				Dim RegInteger As Regex = New Regex("^-[1-9]+$|^[0-9]+$")
				Return RegInteger.IsMatch(TheString)
			end if
		End Function

           	Public Shared Function IsImage(file as HttpPostedFile) as Boolean
     			if (file.ContentLength > 0) and ((file.ContentType = "image/gif") or (file.ContentType = "image/jpeg") or (file.ContentType = "image/pjpeg") or (file.ContentType = "image/png")) then
				Return True
			else
				Return False
			end if
		End Function

		Public Shared Function LastTopicBy(ByVal theuserid As Object, theusername As Object, thedate As Object) as String
			If (IsDBNull(theuserid)) Then
				Return "&nbsp;"
			Else
				Return "Posted By <a href=""profile.aspx?ID=" & theuserid & """>" & theusername & "</a><br />" & FormatDate(thedate, 3)
			End If
		End Function

		Public Shared Function IsModerator(ByVal theUserID as String, theUserLevel as String, theForumID As Integer) as Boolean
			if theUserLevel = "3" then
				Return True
			else
				Dim PrivilegedReader as OdbcDataReader = Database.Read("SELECT PRIVILEGED_ID FROM " & Database.DBPrefix & "_PRIVILEGED WHERE MEMBER_ID = " & theUserID & " AND FORUM_ID = " & theForumID & " AND PRIVILEGED_ACCESS = 2")
					if PrivilegedReader.HasRows then
						Return True
					else
						Return False
					end if
				PrivilegedReader.Close()
			end if
		End Function

		Public Shared Function IsAuthor(ByVal theUserID as String, theTopicID As Integer) as Boolean
			Dim AuthorReader as OdbcDataReader = Database.Read("SELECT TOPIC_ID FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_ID = " & theTopicID & " AND TOPIC_AUTHOR = " & theUserID)
				if AuthorReader.HasRows then
					Return True
				else
					Return False
				end if
			AuthorReader.Close()
		End Function

		Public Shared Function IsPrivileged(ByVal theForumID As Integer, theForumType as Integer, theUserID as String, theUserLevel as String, theUserLogged as String) as Boolean
			if (theUserLevel = "3") or (theForumType = 0) then
				Return True
			else
				if (theForumType = 1) then
					Dim PrivilegedReader as OdbcDataReader = Database.Read("SELECT PRIVILEGED_ID FROM " & Database.DBPrefix & "_PRIVILEGED WHERE MEMBER_ID = " & theUserID & " AND FORUM_ID = " & theForumID & " AND ((PRIVILEGED_ACCESS = 1) or (PRIVILEGED_ACCESS = 2))")
						if PrivilegedReader.HasRows then
							Return True
						else
							Return False
						end if
					PrivilegedReader.Close()			
				elseif (theForumType = 3) then
					if theUserLevel = "2" then
						Return True
					else
						Return False
					end if
				elseif (theForumType = 4) then
					if theUserLogged = "1" then
						Return True
					else
						Return False
					end if
				else
					Return True
				end if
			end if
		End Function

		Public Shared Function IsPagePrivileged(ByVal thePageID As Integer, thePageSecurity as Integer, theUserID as String, theUserLevel as String, theUserLogged as String) as Boolean
			if (theUserLevel = "3") or (thePageSecurity = 0) then
				Return True
			else
				if (thePageSecurity = 1) then
					Dim PrivilegedReader as OdbcDataReader = Database.Read("SELECT PRIVILEGED_ID FROM " & Database.DBPrefix & "_PAGES_PRIVILEGED WHERE MEMBER_ID = " & theUserID & " AND PAGE_ID = " & thePageID & " AND PRIVILEGED_ACCESS = 1")
						if PrivilegedReader.HasRows then
							Return True
						else
							Return False
						end if
					PrivilegedReader.Close()			
				elseif (thePageSecurity = 3) then
					if theUserLevel = "2" then
						Return True
					else
						Return False
					end if
				elseif (thePageSecurity = 4) then
					if theUserLogged = "1" then
						Return True
					else
						Return False
					end if
				else
					Return True
				end if
			end if
		End Function

		Public Shared Function QuickPaging(ByVal TopicID as Integer, TopicReplies as Integer, Optional PageItems as Integer = 15) as String
			Dim ReturnString as String
			Dim PageJumps as Integer
			Dim NumPages as Integer = TopicReplies \ PageItems
			Dim Leftover as Integer = TopicReplies Mod PageItems
			If Leftover > 0 then
				NumPages += 1
			end if

			if NumPages > 1 then
				if NumPages >= 5 then
					PageJumps = 5
				else
					PageJumps = NumPages
				end if

				ReturnString = "<nobr>&nbsp;&nbsp;(&nbsp;<img src=""forumimages/page_icon.gif"">"

				Dim x As Integer
				For x = 1 to PageJumps
					ReturnString &= "&nbsp;<a href=""topics.aspx?ID=" & TopicID & "&PAGE=" & x & """>" & x & "</a>"
				Next

				if NumPages > 5 then
					ReturnString &= "&nbsp;...&nbsp;<a href=""topics.aspx?ID=" & TopicID & "&PAGE=" & NumPages & """>Last Page</a>"
				end if

				ReturnString &= "&nbsp;)</nobr>"
			else
				ReturnString = ""
			end if

			Return ReturnString
		End Function

		Public Shared Function Signature(ByVal ShowSig As Integer, Sig As String) as String
			If (ShowSig = 1) then
				Return "<br clear=""all"" /><br />" & FormatString(Sig)
			Else
				Return ""
			End If
		End Function

		Public Shared Function ShowTopicFileUpload(ByVal UploadedFile As String, Optional FeaturedTopic as Integer = 0) as String
			Dim ReturnString as String = ""

			if (UploadedFile.Length() > 14) then
				if (FeaturedTopic = 0) then
					ReturnString &= "<table border=""0"" width=""90%"" align=""center"" cellpadding=""0"" cellspacing=""0""><tr><td width=""100%""><br /><font size=""" & Settings.TopicsFontSize & """ color=""" & Settings.TopicsFontColor & """><b>Attached File</b></font><br /><table width=""100%"" style=""border-top:2px solid " & Settings.TableBorderColor & ";border-bottom:2px solid " & Settings.TableBorderColor & ";"" cellpadding=""5"" cellspacing=""0""><tr class=""TableRow2""><td width=""100%"" align=""left"">"
				end if

				If ((Right(UploadedFile.ToLower(), 4) = ".jpg") or (Right(UploadedFile.ToLower(), 4) = ".gif") or (Right(UploadedFile.ToLower(), 4) = ".png")) then
					ReturnString &= "<img src=""topicfiles/" & UploadedFile & """ border=""0"">"
				Else
					ReturnString &= GetFileIcon(UploadedFile) & "&nbsp;<a href=""topicfiles/" & UploadedFile & """ target=""_blank"">" & Right(UploadedFile, Len(UploadedFile)-14) & "</a>"
				End If

				if (FeaturedTopic = 0) then
					ReturnString &= "</td></tr></table></td></tr></table>"
				end if
			end if

			Return ReturnString
		End Function

		Public Shared Function GetTitle(ByVal Ranking as Integer, Posts as Integer, UseCustomTitle as Integer, Title as String, Optional MemberLevel as Integer = 1) as String
			Dim RankName as String = "Member"

			if (Ranking = 0) then
				Dim RankingReader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_RANKINGS WHERE RANK_POSTS <= " & Posts & " ORDER BY RANK_POSTS DESC, RANK_ID", 1)
					While(RankingReader.Read())
						RankName = RankingReader("RANK_NAME")
					End While
				RankingReader.close()
			else
				Dim RankingReader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_RANKINGS WHERE RANK_ID = " & Ranking & " ORDER BY RANK_ID", 1)
					While(RankingReader.Read())
						RankName = RankingReader("RANK_NAME")
					End While
				RankingReader.close()
			end if

			if (MemberLevel = 0) then
				RankName = "Banned"
			end if

			if (UseCustomTitle = 1) and (MemberLevel <> 0) then
				Return Title
			else
				Return RankName
			end if
		End Function

		Public Shared Function AllowCustom(ByVal Ranking as Integer, Posts as Integer, Allow as Integer, Type as String) as Boolean
			Dim TypeString as String
			Dim RankAllowCustom as Integer = 0
		
			if Type = "CustomTitle" then
				TypeString = "RANK_ALLOW_TITLE"
			elseif Type = "Avatar" then
				TypeString = "RANK_ALLOW_AVATAR"
			elseif Type = "Topics" then
				TypeString = "RANK_ALLOW_TOPICS"
			elseif Type = "Uploads" then
				TypeString = "RANK_ALLOW_UPLOADS"
			else
				TypeString = "RANK_ALLOW_AVATAR_CUSTOM"
			end if

			if (Ranking = 0) then
				Dim RankingReader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_RANKINGS WHERE RANK_POSTS <= " & Posts & " ORDER BY RANK_POSTS DESC, RANK_ID", 1)
					While(RankingReader.Read())
						RankAllowCustom = RankingReader(TypeString)
					End While
				RankingReader.close()
			else
				Dim RankingReader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_RANKINGS WHERE RANK_ID = " & Ranking & " ORDER BY RANK_ID", 1)
					While(RankingReader.Read())
						RankAllowCustom = RankingReader(TypeString)
					End While
				RankingReader.close()
			end if

			If (RankAllowCustom = 1) or (Allow = 1) then
				Return True
			Else
				Return False
			End If
		End Function

		Public Shared Function PosterDetails(ByVal UserID as Integer, Location as String, Posts as Object, JoinDate as Object, UseCustomAvatar as Integer, AllowCustomAvatar as Integer, CustomAvatarLoaded as Integer, UseCustomTitle as Integer, AllowCustomTitle as Integer, Title as String, AvatarImage as Object, AvatarImageType as Object, UseAvatar as Integer, Photo as String, MemberLevel as Integer, MemberRanking as Integer, ListType as Integer) as String
			Dim ReturnString as String
			Dim RankName as String = "Member"
			Dim RankImage as String = ""
			Dim RankAllowAvatar as String = "0"
			Dim Folder as String = "avatars"

			ReturnString = "<center>"

			if (MemberLevel <> 0) and (MemberLevel <> -1) then
				if (MemberRanking = 0) then
					Dim RankingReader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_RANKINGS WHERE RANK_POSTS <= " & Posts & " ORDER BY RANK_POSTS DESC", 1)
						While(RankingReader.Read())
							RankName = RankingReader("RANK_NAME").ToString()
							RankImage = RankingReader("RANK_IMAGE").ToString()
							RankAllowAvatar = RankingReader("RANK_ALLOW_AVATAR").ToString()
						End While
					RankingReader.close()
				else
					Dim RankingReader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_RANKINGS WHERE RANK_ID = " & MemberRanking & " ORDER BY RANK_ID DESC", 1)
						While(RankingReader.Read())
							RankName = RankingReader("RANK_NAME").ToString()
							RankImage = RankingReader("RANK_IMAGE").ToString()
							RankAllowAvatar = RankingReader("RANK_ALLOW_AVATAR").ToString()
						End While
					RankingReader.close()
				end if

				If (UseCustomTitle = 1) then
					RankName = Title
				End If
		
				If (UseCustomAvatar = 1) and (CustomAvatarLoaded = 1) then
					AvatarImage = UserID & "." & AvatarImageType
					Folder = "customavatars"
				End If

				if (ListType = 2) and (Photo <> "") and (Photo <> " ") and (Photo <> "None") then
					ReturnString &= "<br /><img src=""" & Photo & """><br />"
				end if


				if (RankImage <> "") and (RankImage <> " ") and (RankImage <> "None") then
					ReturnString &= "<br /><img src=""rankimages/" & RankImage & """>"
				end if
			else
				RankName = "Banned"
			end if

			ReturnString &= "<br />" & RankName
	
			if (RankAllowAvatar = "1") and (UseAvatar = 1) and (MemberLevel <> 0) then
				ReturnString &= "<br /><br /><img src=""" & Folder & "/" & AvatarImage & """>"
			end if

			ReturnString &= "</center><br />"

			if ListType = 1 then
				ReturnString &= "Join Date: " & FormatDate(JoinDate, 2) & "<br />Posts: " & Posts
	
				if (Location <> "") and (Location <> " ") then
					ReturnString &= "<br />Location: " & Location
				end if
			end if

			if (MemberLevel = -1) then
				ReturnString = ""
			end if

			Return ReturnString
		End Function

		Public Shared Function FormatDate(ByVal TheDate as DateTime, Optional Format as Integer = 1) as String
			Dim LongDateFormat as String = System.Configuration.ConfigurationManager.AppSettings("LongDateFormat")
			Dim ShortDateFormat as String = System.Configuration.ConfigurationManager.AppSettings("ShortDateFormat")
			Dim DateTimeFormat as String = System.Configuration.ConfigurationManager.AppSettings("DateTimeFormat")

			if Format = 1 then
				Return TheDate.ToString(LongDateFormat)
			else if Format = 2 then
				Return TheDate.ToString(ShortDateFormat)
			else if Format = 3 then
				Return TheDate.ToString(DateTimeFormat)
			else if Format = 4 then
				Return TheDate.ToString("yyyy-MM-dd hh:mm:ss")
			else
				Return TheDate.ToString(ShortDateFormat)
			end if
		End Function

		Public Shared Sub MessageBox(ByVal Message As String)
			Dim txtBox as String
			txtBox = "<script language=javascript>"
			txtBox &= "alert('" & Message &"');"
			txtBox &= "</script" &">"
			System.Web.HttpContext.Current.Response.Write(txtBox)
		End Sub

		Public Shared Function GetFileIcon(ByVal FileName As String) as String
			Dim icon as String = "file.png"

			FileName = FileName.ToLower()

			if (Right(FileName, 3) = ".gz") then
				icon = "gz.png"
			end if
			if (Right(FileName, 3) = ".js") then
				icon = "js.png"
			end if
			if (Right(FileName, 4) = ".zip") then
				icon = "zip.png"
			end if
			if (Right(FileName, 4) = ".xml") then
				icon = "xml.png"
			end if
			if (Right(FileName, 4) = ".xls") then
				icon = "xls.png"
			end if
			if (Right(FileName, 4) = ".wmv") then
				icon = "wmv.png"
			end if
			if (Right(FileName, 4) = ".wma") then
				icon = "wma.png"
			end if
			if (Right(FileName, 4) = ".txt") then
				icon = "txt.png"
			end if
			if (Right(FileName, 4) = ".wav") then
				icon = "wav.png"
			end if
			if (Right(FileName, 4) = ".bz2") then
				icon = "bz2.png"
			end if
			if (Right(FileName, 4) = ".swf") then
				icon = "swf.png"
			end if
			if (Right(FileName, 4) = ".tar") then
				icon = "tar.png"
			end if
			if (Right(FileName, 4) = ".tgz") then
				icon = "tgz.png"
			end if
			if (Right(FileName, 4) = ".mov") then
				icon = "mov.png"
			end if
			if (Right(FileName, 4) = ".mp3") then
				icon = "mp3.png"
			end if
			if (Right(FileName, 4) = ".mpg") then
				icon = "mpg.png"
			end if
			if (Right(FileName, 4) = ".pdf") then
				icon = "pdf.png"
			end if
			if (Right(FileName, 4) = ".php") then
				icon = "php.png"
			end if
			if (Right(FileName, 4) = ".png") then
				icon = "jpg.png"
			end if
			if (Right(FileName, 4) = ".ppt") then
				icon = "ppt.png"
			end if
			if (Right(FileName, 4) = ".rar") then
				icon = "rar.png"
			end if
			if (Right(FileName, 4) = ".rtf") then
				icon = "rtf.png"
			end if
			if (Right(FileName, 4) = ".jpg") then
				icon = "jpg.png"
			end if
			if (Right(FileName, 4) = ".htm") then
				icon = "html.png"
			end if
			if (Right(FileName, 4) = ".gif") then
				icon = "jpg.png"
			end if
			if (Right(FileName, 4) = ".doc") then
				icon = "doc.png"
			end if
			if (Right(FileName, 4) = ".csv") then
				icon = "csv.png"
			end if
			if (Right(FileName, 4) = ".css") then
				icon = "css.png"
			end if
			if (Right(FileName, 5) = ".conf") then
				icon = "conf.png"
			end if
			if (Right(FileName, 5) = ".html") then
				icon = "html.png"
			end if
			if (Right(FileName, 5) = ".docx") then
				icon = "doc.png"
			end if
			if (Right(FileName, 5) = ".xlsx") then
				icon = "xls.png"
			end if
			if (Right(FileName, 5) = ".pptx") then
				icon = "ppt.png"
			end if
			if (Right(FileName, 7) = ".tar.gz") then
				icon = "tgz.png"
			end if

			Dim ReturnString as String = "<img src=""forumimages/icons/" & icon & """ width=""16"" height=""16"">"
			Return ReturnString
		End Function

		Public Shared Function SendEmail(ByVal MailTo As String, MailFrom As String, Subject As String, Message As String) as Integer
			Try
				Dim Mail as MailMessage = new MailMessage()
				Mail.From = New MailAddress(MailFrom)
				Mail.To.Add(MailTo)
				Mail.Subject = Subject
				Mail.Body = Message
				Mail.IsBodyHtml = True
				Dim SMTP As New SmtpClient(Settings.EmailSmtp)
				if (Settings.EmailPort <> "" and Settings.EmailPort <> " ")
					SMTP.Port = Settings.EmailPort
				end if
				if (Settings.EmailUsername <> "" and Settings.EmailUsername <> " ")
					SMTP.Credentials = New System.Net.NetworkCredential(Settings.EmailUsername, Settings.EmailPassword)
				end if
				SMTP.Send(Mail)
				Return 0
			Catch e1 as System.Net.Sockets.SocketException
				' The SMTP server does not exist or the port is invalid
				Return 1
			Catch e2 as System.Net.Mail.SmtpFailedRecipientException
				' The SMTP Server is refusing to forward the message
				Return 2
			Catch e3 as SmtpException
				' Communication with SMTP Server Failed
				Return 3
			Catch e4 as Exception
				' Some other problem occurred
				Return 4
			End Try
		End Function

		Public Shared Sub SendToSubscribers(ByVal TopicID as Integer)
			if ((Settings.EmailAllowSub = 1) and (Settings.AllowSub = 1)) then
				Dim TopicSubject as String = ""
				Dim Reader as OdbcDataReader = Database.Read("SELECT M.MEMBER_EMAIL FROM " & Database.DBPrefix & "_SUBSCRIPTIONS S Left Outer Join " & Database.DBPrefix & "_MEMBERS M On S.SUB_MEMBER = M.MEMBER_ID WHERE S.SUB_TOPIC = " & TopicID & " AND S.SUB_EMAIL = 1")
				if Reader.HasRows() then
					Dim Reader2 as OdbcDataReader = Database.Read("SELECT TOPIC_SUBJECT FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_ID = " & TopicID)
					While Reader2.Read()
						TopicSubject = Reader2("TOPIC_SUBJECT").ToString()
					End While
					Reader2.Close()

					While Reader.Read()
						Dim FullPath as String = GetFullURLPath()
						Dim Mailer as Integer = SendEmail(Reader("MEMBER_EMAIL").ToString(), Settings.EmailAddress, Settings.PageTitle & ": Thread Updated", Functions.CustomMessage("EMAIL_SUBSCRIPTION") & "<br /><br />THREAD: " & TopicSubject & "<br /><br /><a href=""" & FullPath & "/topics.aspx?ID=" & TopicID & """>" & FullPath & "/topics.aspx?ID=" & TopicID & "</a>")
					End While
				end if
				Reader.Close()
			end if
		End Sub

		Public Shared Sub SendToModerators(ByVal SendType as Integer, TopicID as Integer, ForumID as Integer)
			Dim FullPath as String = GetFullURLPath()
			Dim MessageTitle as String = Settings.PageTitle
			Dim MessageText as String = Functions.CustomMessage("EMAIL_CONFIRMPOST") & "<br /><br /><a href=""" & FullPath & "/topics.aspx?ID=" & TopicID & """>" & FullPath & "/topics.aspx?ID=" & TopicID & "</a>"
			if (SendType = 1) then
				MessageTitle &= ": New Topic Posted"
			else
				MessageTitle &= ": New Reply Posted"
			end if
			Dim Reader as OdbcDataReader = Database.Read("SELECT M.MEMBER_EMAIL FROM " & Database.DBPrefix & "_PRIVILEGED P Left Outer Join " & Database.DBPrefix & "_MEMBERS M On P.MEMBER_ID = M.MEMBER_ID WHERE P.PRIVILEGED_ACCESS = 2 AND P.FORUM_ID = " & ForumID)
			While Reader.Read()
				Dim Mailer as Integer = SendEmail(Reader("MEMBER_EMAIL").ToString(), Settings.EmailAddress, MessageTitle, MessageText)
			End While
			Reader.Close()
		End Sub

		Public Shared Function GetFullURLPath() as String
			Dim FullPath as String = System.Web.HttpContext.Current.Request.Url.ToString()
			FullPath = Left(FullPath, Len(FullPath) - InStr(1, StrReverse(FullPath), "/"))
			Return FullPath
		End Function

		Public Shared Function LeftText(ByVal TheString as String, LeftLength as Integer) as String
			if (LeftLength = 0) then
				Return TheString
			else
				if (TheString.Length() < LeftLength) then
					Return TheString
				else
					Return Left(TheString, LeftLength) & "..."
				end if
			end if
		End Function

		Public Shared Function RepairString(ByVal TheString as String, Optional Validate as Integer = 1) as String
			Dim ReturnString as String = TheString
				ReturnString = ReturnString.Replace("'", "''")
				if (Validate = 1) then
					ReturnString = HtmlEncode(ReturnString)
				end if
			Return ReturnString
		End Function

		Public Shared Function Encrypt(ByVal TheString as String) As String
			Dim ClearBytes as Byte() = New UnicodeEncoding().GetBytes(TheString)
			Dim MyHash as HashAlgorithm = CryptoConfig.CreateFromName("MD5")
			Dim HashedBytes as Byte() = MyHash.ComputeHash(ClearBytes)
			Return BitConverter.ToString(HashedBytes)
		End Function

		Public Shared Function GetUniqueKey() As String
			Dim UniqueKey As String = Encrypt(Guid.NewGuid().ToString())
			Return UniqueKey
		End Function

		Public Shared Function FormatURL(ByVal TheString as String) As String
			if (Regex.IsMatch(TheString,"([\w]+?://[^ ,""\s<]*)")) then
				Return "<a target=""_blank"" href=""" & TheString & """>" & TheString & "</a>"
			elseif (Regex.IsMatch(TheString,"((www|ftp)\.[^ ,""\s<]*)"))
				Return "<a target=""_blank"" href=""http://" & TheString & """>" & TheString & "</a>"
			else
				Return TheString
			end if
		End Function

		Public Shared Function FormatString(ByVal TheString as String) As String
			Dim ReturnString as String = TheString
				ReturnString = ReturnString.Replace(CHR(13), "")
				ReturnString = ReturnString.Replace(CHR(10), "<br />")
				ReturnString = ReturnString.Replace(CHR(10) & CHR(10), "<br /><br />")
				ReturnString = Regex.Replace(ReturnString, "(^|[\n ])([\w]+?://[^ ,""\s<]*)", "$1<a target=""_blank"" href=""$2"">$2</a>")
				ReturnString = Regex.Replace(ReturnString, "(^|[\n ])((www|ftp)\.[^ ,""\s<]*)", "$1<a target=""_blank"" href=""http://$2"">$2</a>")
				ReturnString = Regex.Replace(ReturnString, "(^|[\n ])([a-z0-9&\-_.]+?)@([\w\-]+\.([\w\-\.]+\.)*[\w]+)", "$1<a href=""mailto:$2@$3"">$2@$3</a>")
				ReturnString = ForumCode(ReturnString)
				if (Settings.CurseFilter = 1) then
					ReturnString = ReplaceCurseWords(ReturnString)
				end if
			Return ReturnString
		End Function

		Public Shared Function CurseFilter(ByVal TheString as String) As String
			if (Settings.CurseFilter = 1) then
				Return ReplaceCurseWords(TheString)
			else
				Return TheString
			end if
		End Function

		Public Shared Function ReplaceCurseWords(ByVal TheString as String) As String
			Dim ReturnString as String = TheString
			Dim Reader as OdbcDataReader = Database.Read("SELECT CURSE_WORD, CURSE_REPLACEMENT FROM " & Database.DBPrefix & "_CURSE_FILTER ORDER BY CURSE_ID")
			While Reader.Read()
				ReturnString = Regex.Replace(ReturnString, Reader("CURSE_WORD").ToString(), Reader("CURSE_REPLACEMENT").ToString(), RegexOptions.IgnoreCase)
			End While
			Reader.Close()
			Return ReturnString
		End Function

		Public Shared Function ForumCode(ByVal TheString as String) as String
			Dim ReturnString as String = TheString
			ReturnString = Regex.Replace(ReturnString, "(\[b\])((.|\n)*?)(\[\/b\])", "<b>$2</b>")
			ReturnString = Regex.Replace(ReturnString, "(\[u\])((.|\n)*?)(\[\/u\])", "<u>$2</u>")
			ReturnString = Regex.Replace(ReturnString, "(\[i\])((.|\n)*?)(\[\/i\])", "<i>$2</i>")
			ReturnString = Regex.Replace(ReturnString, "(\[marquee\])((.|\n)*?)(\[\/marquee\])", "<marquee>$2</marquee>")
			ReturnString = Regex.Replace(ReturnString, "(\[sup\])((.|\n)*?)(\[\/sup\])", "<sup>$2</sup>")
			ReturnString = Regex.Replace(ReturnString, "(\[sub\])((.|\n)*?)(\[\/sub\])", "<sub>$2</sub>")
			ReturnString = Regex.Replace(ReturnString, "(\[highlight\])((.|\n)*?)(\[\/highlight\])", "<span style=""background-color: #FFFF00"">$2</span>")
			ReturnString = Regex.Replace(ReturnString, "(\[highlight\=)((.|\n)*?)(\])((.|\n)*?)(\[\/highlight\])", "<span style=""background-color: $2"">$5</span>")
			ReturnString = Regex.Replace(ReturnString, "(\[pre\])((.|\n)*?)(\[\/pre\])", "<pre id=""pref""><font size=""2"" id=""pref"">$2</font id=""pref""></pre id=""pref"">")
			ReturnString = Regex.Replace(ReturnString, "(\[hr\])", "<hr />")
			ReturnString = Regex.Replace(ReturnString, "(\[br\])", "<br />")
			ReturnString = Regex.Replace(ReturnString, "(\[s\])((.|\n)*?)(\[\/s\])", "<s>$2</s>")
			ReturnString = Regex.Replace(ReturnString, "(\[font\=)((.|\n)*?)(\])((.|\n)*?)(\[\/font\])", "<font face=""$2"">$5</font id=""$2"">")
			ReturnString = Regex.Replace(ReturnString, "(\[color\=)((.|\n)*?)(\])((.|\n)*?)(\[\/color\])", "<font color=""$2"">$5</font id=""$2"">")
			ReturnString = Regex.Replace(ReturnString, "(\[size\=)((.|\n)*?)(\])((.|\n)*?)(\[\/size\])", "<font size=""$2"">$5</font id=""size$2"">")
			ReturnString = Regex.Replace(ReturnString, "(\[h1\])((.|\n)*?)(\[\/h1\])", "<h1>$2</h1>")
			ReturnString = Regex.Replace(ReturnString, "(\[h2\])((.|\n)*?)(\[\/h2\])", "<h2>$2</h2>")
			ReturnString = Regex.Replace(ReturnString, "(\[h3\])((.|\n)*?)(\[\/h3\])", "<h3>$2</h3>")
			ReturnString = Regex.Replace(ReturnString, "(\[h4\])((.|\n)*?)(\[\/h4\])", "<h4>$2</h4>")
			ReturnString = Regex.Replace(ReturnString, "(\[h5\])((.|\n)*?)(\[\/h5\])", "<h5>$2</h5>")
			ReturnString = Regex.Replace(ReturnString, "(\[h6\])((.|\n)*?)(\[\/h6\])", "<h6>$2</h6>")
			ReturnString = Regex.Replace(ReturnString, "(\[list\])((.|\n)*?)(\[\/list\])", "<ul>$2</ul>")
			ReturnString = Regex.Replace(ReturnString, "(\[list\=numbers)(\])((.|\n)*?)(\[\/list\])", "<ol type=""1"">$3</ol>")
			ReturnString = Regex.Replace(ReturnString, "(\[list\=letters)(\])((.|\n)*?)(\[\/list\])", "<ol type=""A"">$3</ol>")
			ReturnString = Regex.Replace(ReturnString, "(\[\*\])", "<li />")
			ReturnString = Regex.Replace(ReturnString, "(\[left\])((.|\n)*?)(\[\/left\])", "<div align=""left"">$2</div>")
			ReturnString = Regex.Replace(ReturnString, "(\[right\])((.|\n)*?)(\[\/right\])", "<div align=""right"">$2</div>")
			ReturnString = Regex.Replace(ReturnString, "(\[center\])((.|\n)*?)(\[\/center\])", "<center>$2</center>")
			ReturnString = Regex.Replace(ReturnString, "(\[code\])((.|\n)*?)(\[\/code\])", "<div style=""margin:20px; margin-top:5px""><div style=""margin-bottom:2px"">Code:</div><pre style=""margin: 0px; padding: 6px; border: 1px inset; text-align: left;""><font size=""2"" id=""code"">$2</font id=""code""></pre></div>")
			ReturnString = Regex.Replace(ReturnString, "(\[url\])((.|\n)*?)(\[\/url\])", "<a target=""_blank"" href=""$2"">$2</a>")
			ReturnString = Regex.Replace(ReturnString, "(\[url\=)((.|\n)*?)(\])((.|\n)*?)(\[\/url\])", "<a target=""_blank"" href=""$2"">$5</a>")
			ReturnString = Regex.Replace(ReturnString, "(\[urlnopop\])((.|\n)*?)(\[\/urlnopop\])", "<a href=""$2"">$2</a>")
			ReturnString = Regex.Replace(ReturnString, "(\[urlnopop\=)((.|\n)*?)(\])((.|\n)*?)(\[\/urlnopop\])", "<a href=""$2"">$5</a>")
			ReturnString = Regex.Replace(ReturnString, "\[MemberPhoto\=(?<num>\d+)\]", AddressOf MemberPhoto, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

			Dim exp1 as New Regex("\[quote\]")
			Dim exp2 as New Regex("\[\/quote\]")
			Dim occur1 as Integer = exp1.Matches(ReturnString).Count
			Dim occur2 as Integer = exp2.Matches(ReturnString).Count
			if ((occur1 <> 0) or (occur2 <> 0)) then
				if (occur1 = occur2) then
					ReturnString = Regex.Replace(ReturnString, "(\[quote\])", "<div style=""margin:20px; margin-top:5px;""><div style=""margin-bottom:2px;"">Quote:</div><div style=""border-top: solid 1px; border-bottom: solid 1px; padding: 5px;"">")
					ReturnString = Regex.Replace(ReturnString, "(\[\/quote\])", "</div></div>")
				else
					ReturnString = Regex.Replace(ReturnString, "(\[quote\])((.|\n)*?)(\[\/quote\])", "<div style=""margin:20px; margin-top:5px;""><div style=""margin-bottom:2px;"">Quote:</div><div style=""border-top: solid 1px; border-bottom: solid 1px; padding: 5px;"">$2</span></div>")
				end if
			end if

			if (Settings.AllowMedia = 1) then
				ReturnString = Regex.Replace(ReturnString, "(\[)(image|img)(\])((.|\n)*?)(\[\/(image|img)\])", "<img src=""$4"">")
				ReturnString = Regex.Replace(ReturnString, "(\[)(image|img)(\=left\])((.|\n)*?)(\[\/(image|img)\])", "<img align=""left"" src=""$4"">")
				ReturnString = Regex.Replace(ReturnString, "(\[)(image|img)(\=right\])((.|\n)*?)(\[\/(image|img)\])", "<img align=""right"" src=""$4"">")
				ReturnString = Regex.Replace(ReturnString, "(\[)(image|img)(\=center\])((.|\n)*?)(\[\/(image|img)\])", "<center><img src=""$4""></center>")
				ReturnString = Regex.Replace(ReturnString, "(\[flash\])((.|\n)*?)(\[\/flash\])", "<object classid=""clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"" width=""425"" height=""350""><param name=""movie"" value=""$2""><embed src=""$2"" width=""425"" height=""350""></embed></object>")
				ReturnString = Regex.Replace(ReturnString, "(\[flash)( width\=)((.|\n)*?)( height\=)((.|\n)*?)(\])((.|\n)*?)(\[\/flash\])", "<object classid=""clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"" width=""$3"" height=""$6""><param name=""movie"" value=""$9""><embed src=""$9"" width=""$3"" height=""$6""></embed></object>")
				ReturnString = Regex.Replace(ReturnString, "(\[flash)( height\=)((.|\n)*?)( width\=)((.|\n)*?)(\])((.|\n)*?)(\[\/flash\])", "<object classid=""clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"" width=""$6"" height=""$3""><param name=""movie"" value=""$9""><embed src=""$9"" width=""$6"" height=""$3""></embed></object>")
				ReturnString = Regex.Replace(ReturnString, "(\[YouTube\])((.|\n)*?)(youtube.com\/watch\?v\=)((.|\n)*?)(\[\/YouTube\])", "<object width=""640"" height=""385""><param name=""movie"" value=""http://www.youtube.com/v/$5&fs=1&ap=%2526fmt%3D18""></param><param name=""wmode"" value=""transparent""></param><param name=""allowFullScreen"" value=""true""></param><param name=""allowscriptaccess"" value=""always""></param><embed src=""http://www.youtube.com/v/$5&fs=1&ap=%2526fmt%3D18"" type=""application/x-shockwave-flash"" wmode=""transparent"" allowscriptaccess=""always"" allowfullscreen=""true"" width=""640"" height=""385""></embed></object>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
				ReturnString = Regex.Replace(ReturnString, "(\[YouTubeLite\])((.|\n)*?)(youtube.com\/watch\?v\=)((.|\n)*?)(\[\/YouTubeLite\])", "<object width=""425"" height=""344""><param name=""movie"" value=""http://www.youtube.com/v/$5&fs=1""></param><param name=""wmode"" value=""transparent""></param><param name=""allowFullScreen"" value=""true""></param><param name=""allowscriptaccess"" value=""always""></param><embed src=""http://www.youtube.com/v/$5&fs=1"" type=""application/x-shockwave-flash"" wmode=""transparent"" allowscriptaccess=""always"" allowfullscreen=""true"" width=""425"" height=""344""></embed></object>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
				ReturnString = Regex.Replace(ReturnString, "(\[YouTubeHD\])((.|\n)*?)(youtube.com\/watch\?v\=)((.|\n)*?)(\[\/YouTubeHD\])", "<object width=""855"" height=""480""><param name=""movie"" value=""http://www.youtube.com/v/$5&fs=1&ap=%2526fmt%3D22""></param><param name=""wmode"" value=""transparent""></param><param name=""allowFullScreen"" value=""true""></param><param name=""allowscriptaccess"" value=""always""></param><embed src=""http://www.youtube.com/v/$5&fs=1&ap=%2526fmt%3D22"" type=""application/x-shockwave-flash"" wmode=""transparent"" allowscriptaccess=""always"" allowfullscreen=""true"" width=""855"" height=""480""></embed></object>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			end if
			Return ReturnString
		End Function

		Public Shared Function CustomHTMLVariables(ByVal TheString as String, TheUserID as String, TheUserLogged as String, TheUserLevel as String) as String
			Dim ReturnString as String = TheString
			ReturnString = Regex.Replace(ReturnString, "(\[ContentBox\=)((.|\n)*?)(\])((.|\n)*?)(\[\/ContentBox\])", "<table width=""100%"" align=""center"" class=""ContentBox"" cellpadding=""5"" cellspacing=""0""><tr class=""HeaderCell""><td align=""left""><font size=""" & Settings.HeaderSize & """ color=""" & Settings.HeaderFontColor & """><b>$2</b></font></td></tr><tr class=""TableRow1""><td style=""border-top:1px solid " & Settings.TableBorderColor & ";""><font size=""" & Settings.FontSize & """ color=""" & Settings.TopicsFontColor & """>$5</font></td></tr></table>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[ContentBox\])((.|\n)*?)(\[\/ContentBox\])", "<table width=""100%"" align=""center"" class=""ContentBox"" cellpadding=""5"" cellspacing=""0""><tr class=""TableRow1""><td><font size=""" & Settings.FontSize & """ color=""" & Settings.TopicsFontColor & """>$2</font></td></tr></table>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Text1\])", UserVariables("TEXT1"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Text2\])", UserVariables("TEXT2"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Text3\])", UserVariables("TEXT3"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Text4\])", UserVariables("TEXT4"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Text5\])", UserVariables("TEXT5"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Var1\])", UserVariables("VAR1"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Var2\])", UserVariables("VAR2"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Var3\])", UserVariables("VAR3"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Var4\])", UserVariables("VAR4"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Var5\])", UserVariables("VAR5"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[p\])", "<br clear=""all"" /><br />", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[br\])", "<br />", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[pagetitle\])", Settings.PageTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[forumlogo\])", Settings.ForumLogo, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[homeurl\])", Settings.SiteURL, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[fontface\])", Settings.FontFace, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[fontcolor\])", Settings.FontColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[headercolor\])", Settings.HeaderColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[headerfontcolor\])", Settings.HeaderFontColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[bordercolor\])", Settings.TableBorderColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[LinkDecoration\])", Settings.LinkDecoration, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[LinkColor\])", Settings.LinkColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[ALinkDecoration\])", Settings.ALinkDecoration, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[ALinkColor\])", Settings.ALinkColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[VLinkDecoration\])", Settings.VLinkDecoration, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[VLinkColor\])", Settings.VLinkColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[HLinkDecoration\])", Settings.HLinkDecoration, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[HLinkColor\])", Settings.HLinkColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[ButtonColor\])", Settings.ButtonColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[FontSize\])", Settings.FontSize, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[TopicsFontSize\])", Settings.TopicsFontSize, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[TopicsFontColor\])", Settings.TopicsFontColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[BackgroundColor\])", Settings.BGColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[ScrollbarColor\])", Settings.ScrollbarColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[TableBGColor1\])", Settings.TableBGColor1, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[TableBGColor2\])", Settings.TableBGColor2, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[LoginFontColor\])", Settings.LoginFontColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[HeaderFontSize\])", Settings.HeaderSize, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[SubHeaderColor\])", Settings.SubHeaderColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[SubHeaderFontColor\])", Settings.SubHeaderFontColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[FooterColor\])", Settings.FooterColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[FooterFontSize\])", Settings.FooterSize, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[FooterFontColor\])", Settings.FooterFontColor, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Forums\])((.|\n)*?)(\[\/Forums\])", "<a href=""ForumHome.aspx"">$2</a>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Forum\=)((.|\n)*?)(\])((.|\n)*?)(\[\/Forum\])", "<a href=""forums.aspx?ID=$2"">$5</a>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[Page\=)((.|\n)*?)(\])((.|\n)*?)(\[\/Page\])", "<a href=""page.aspx?ID=$2"">$5</a>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[menu\])", MenuHTML(TheUserID, TheUserLogged, TheUserLevel, 1), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[menu\=H\])", MenuHTML(TheUserID, TheUserLogged, TheUserLevel, 1), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[menu\=V\])", MenuHTML(TheUserID, TheUserLogged, TheUserLevel, 2), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[ForumMenu\])", ForumMenu(TheUserID, TheUserLogged, TheUserLevel, 1), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[ForumMenu\=H\])", ForumMenu(TheUserID, TheUserLogged, TheUserLevel, 1), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[ForumMenu\=V\])", ForumMenu(TheUserID, TheUserLogged, TheUserLevel, 2), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu\])", PageMenu(1, 0), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu\=H\])", PageMenu(2, 0), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu\=V\])", PageMenu(1, 0), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu Align\=H\])", PageMenu(2, 0), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu Align\=V\])", PageMenu(1, 0), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu Parent\=(?<num>\d+)\])", AddressOf PageMenuParentV, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu Align\=H Parent\=(?<num>\d+)\])", AddressOf PageMenuParentH, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu Align\=V Parent\=(?<num>\d+)\])", AddressOf PageMenuParentV, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu Parent\=(?<num>\d+) Align\=H\])", AddressOf PageMenuParentH, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PageMenu Parent\=(?<num>\d+) Align\=V\])", AddressOf PageMenuParentV, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[CreateTopicLink\])((.|\n)*?)(\[\/CreateTopicLink\])", "<a href=""newtopic_selectforum.aspx"">$2</a>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[RegisterLink\])", ShowLink(TheUserID, TheUserLogged, TheUserLevel, 1), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[AdminLink\])", ShowLink(TheUserID, TheUserLogged, TheUserLevel, 2), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[PMLink\])", ShowLink(TheUserID, TheUserLogged, TheUserLevel, 3), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[ImageRotator\=(?<num>\d+)\]", AddressOf ImageRotator, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics Topics\=(?<num>\d+)\](?<title>.+)\[\/LatestTopics\]", AddressOf LatestTopicsNumberTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics ForumID\=(?<forumid>\d+)\](?<title>.+)\[\/LatestTopics\]", AddressOf LatestTopicsForumTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics Topics\=(?<num>\d+)\]", AddressOf LatestTopicsNumber, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics ForumID\=(?<forumid>\d+)\]", AddressOf LatestTopicsForum, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics Topics\=(?<num>\d+) ForumID\=(?<forumid>\d+)\](?<title>.+)\[\/LatestTopics\]", AddressOf LatestTopicsNumberForumTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics ForumID\=(?<forumid>\d+) Topics\=(?<num>\d+)\](?<title>.+)\[\/LatestTopics\]", AddressOf LatestTopicsNumberForumTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics Topics\=(?<num>\d+) ForumID\=(?<forumid>\d+)\]", AddressOf LatestTopicsNumberForum, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics ForumID\=(?<forumid>\d+) Topics\=(?<num>\d+)\]", AddressOf LatestTopicsNumberForum, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics\=(?<num>\d+)\](?<title>.+)\[\/LatestTopics\]", AddressOf LatestTopicsNumberTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics\=(?<num>\d+)\]", AddressOf LatestTopicsNumber, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopics\](?<title>.+)\[\/LatestTopics\]", AddressOf LatestTopicsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[LatestTopics\])", LatestTopics(10, 1, "Latest Topics"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[LatestTopicsNoBox\])", LatestTopics(10, 0, "Latest Topics"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopicsNoBox\=(?<num>\d+)\]", AddressOf LatestTopicsNumberNoBox, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopicsNoBox Topics\=(?<num>\d+)\]", AddressOf LatestTopicsNumberNoBox, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopicsNoBox ForumID\=(?<forumid>\d+)\]", AddressOf LatestTopicsForumNoBox, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopicsNoBox Topics\=(?<num>\d+) ForumID\=(?<forumid>\d+)\]", AddressOf LatestTopicsNumberForumNoBox, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestTopicsNoBox ForumID\=(?<forumid>\d+) Topics\=(?<num>\d+)\]", AddressOf LatestTopicsNumberForumNoBox, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestBlogs\=(?<num>\d+)\](?<title>.+)\[\/LatestBlogs\]", AddressOf LatestBlogsNumberTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[LatestBlogs\=)(?<num>\d+)(\])", AddressOf LatestBlogsNumber, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestBlogsNoBox\=(?<num>\d+)\]", AddressOf LatestBlogsNumberNoBox, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[LatestBlogs\](?<title>.+)\[\/LatestBlogs\]", AddressOf LatestBlogsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[LatestBlogs\])", LatestBlogs(10, 1), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[LatestBlogsNoBox\])", LatestBlogs(10, 0), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[NewsTopics\=(?<days>\d+)\](?<title>.+)\[\/NewsTopics\]", AddressOf FeaturedTopicsDaysTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[NewsTopics\=(?<days>\d+)\]", AddressOf FeaturedTopicsDays, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[NewsTopics\](?<title>.+)\[\/NewsTopics\]", AddressOf FeaturedTopicsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[NewsTopics\])", FeaturedTopics(0, 0, 500), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+) Max\=(?<max>\d+) Chars\=(?<chars>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxDaysCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+) Days\=(?<days>\d+) Chars\=(?<chars>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxDaysCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+) Chars\=(?<chars>\d+) Max\=(?<max>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxDaysCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+) Chars\=(?<chars>\d+) Days\=(?<days>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxDaysCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+) Days\=(?<days>\d+) Max\=(?<max>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxDaysCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+) Max\=(?<max>\d+) Days\=(?<days>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxDaysCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+) Max\=(?<max>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxDaysTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+) Days\=(?<days>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxDaysTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+) Max\=(?<max>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+) Chars\=(?<chars>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+) Days\=(?<days>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsDaysCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+) Chars\=(?<chars>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsDaysCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsDaysTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsCharsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+)\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsMaxTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+) Max\=(?<max>\d+) Chars\=(?<chars>\d+)\]", AddressOf FeaturedTopicsMaxDaysChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+) Days\=(?<days>\d+) Chars\=(?<chars>\d+)\]", AddressOf FeaturedTopicsMaxDaysChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+) Chars\=(?<chars>\d+) Max\=(?<max>\d+)\]", AddressOf FeaturedTopicsMaxDaysChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+) Chars\=(?<chars>\d+) Days\=(?<days>\d+)\]", AddressOf FeaturedTopicsMaxDaysChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+) Days\=(?<days>\d+) Max\=(?<max>\d+)\]", AddressOf FeaturedTopicsMaxDaysChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+) Max\=(?<max>\d+) Days\=(?<days>\d+)\]", AddressOf FeaturedTopicsMaxDaysChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+) Days\=(?<days>\d+)\]", AddressOf FeaturedTopicsMaxDays, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+) Max\=(?<max>\d+)\]", AddressOf FeaturedTopicsMaxDays, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+) Chars\=(?<chars>\d+)\]", AddressOf FeaturedTopicsMaxChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+) Max\=(?<max>\d+)\]", AddressOf FeaturedTopicsMaxChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+) Chars\=(?<chars>\d+)\]", AddressOf FeaturedTopicsDaysChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+) Days\=(?<days>\d+)\]", AddressOf FeaturedTopicsDaysChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Max\=(?<max>\d+)\]", AddressOf FeaturedTopicsMax, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Days\=(?<days>\d+)\]", AddressOf FeaturedTopicsDays, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics Chars\=(?<chars>\d+)\]", AddressOf FeaturedTopicsChars, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[FeaturedTopics\](?<title>.+)\[\/FeaturedTopics\]", AddressOf FeaturedTopicsTitle, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "(\[FeaturedTopics\])", FeaturedTopics(0, 0, 500), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[\/LatestBlogs\]", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[\/LatestTopics\]", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[\/NewsTopics\]", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[PhotoGallery Columns\=(?<cols>\d+) ID\=(?<num>\d+)\]", AddressOf PhotoGalleryWithCols, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[PhotoGallery ID\=(?<num>\d+) Columns\=(?<cols>\d+)\]", AddressOf PhotoGalleryWithCols, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\[PhotoGallery\=(?<num>\d+)\]", AddressOf PhotoGalleryNoCols, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = Regex.Replace(ReturnString, "\<form(?<text>(.|\n)*?)\<\/form\>", AddressOf HtmlFormBuilder, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			ReturnString = ForumCode(ReturnString)
			Return ReturnString
		End Function

		Public Shared Function HtmlFormBuilder(ByVal m As Match) As String
			Dim FormText as String = (m.Groups("text").Value).ToString()
			FormText = Regex.Replace(FormText, """", "'")
			Dim FormTarget as String = " target='_top'"
			if (FormText.IndexOf("target=") > 0) then
				FormTarget = ""
			end if
			FormText = "<iframe id=""DMGForm"" src=""htmlform.aspx?TEXT=<form" & FormTarget & FormText & "</form>"" frameborder=""0"" scrolling=""no"" allowtransparency=""true""></iframe>"
			return FormText
		End Function

		Public Shared Function MemberPhoto(ByVal m As Match) As String
			Dim PhotoID as Integer = cLng((m.Groups("num").Value).ToString())
			Dim ReturnString as String = ""
			if (IsInteger(PhotoID)) then
				Dim Reader as OdbcDataReader = Database.Read("SELECT PHOTO_ID, PHOTO_EXTENSION FROM " & Database.DBPrefix & "_MEMBER_PHOTOS WHERE PHOTO_ID = " & PhotoID, 1)
				While Reader.Read()
					ReturnString = "<a href=""javascript:openPhoto('showphoto.aspx?PHOTO=memberphotos/" & Reader("PHOTO_ID") & "." & Reader("PHOTO_EXTENSION").ToString() & "')""><img src=""memberphotos/" & Reader("PHOTO_ID") & "_s." & Reader("PHOTO_EXTENSION").ToString() & """></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
				End While
				Reader.Close()
			end if
			return ReturnString
		End Function

		Public Shared Function PhotoGalleryNoCols(ByVal m As Match) As String
			Dim GalleryID as Integer = cLng((m.Groups("num").Value).ToString())
			return PhotoGallery(GalleryID, 5)
		End Function

		Public Shared Function PhotoGalleryWithCols(ByVal m As Match) As String
			Dim GalleryID as Integer = cLng((m.Groups("num").Value).ToString())
			Dim NumCols as Integer = cLng((m.Groups("cols").Value).ToString())
			return PhotoGallery(GalleryID, NumCols)
		End Function

		Public Shared Function LatestTopicsNumber(ByVal m As Match) As String
			Dim NumTopics as Integer = cLng((m.Groups("num").Value).ToString())
			return LatestTopics(NumTopics, 1, "Latest Topics")
		End Function

		Public Shared Function LatestTopicsForum(ByVal m As Match) As String
			Dim ForumID as Integer = cLng((m.Groups("forumid").Value).ToString())
			return LatestTopics(10, 1, "Latest Topics", ForumID)
		End Function

		Public Shared Function LatestTopicsTitle(ByVal m As Match) As String
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return LatestTopics(10, 1, BoxTitle)
		End Function

		Public Shared Function LatestTopicsNumberTitle(ByVal m As Match) As String
			Dim NumTopics as Integer = cLng((m.Groups("num").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return LatestTopics(NumTopics, 1, BoxTitle)
		End Function

		Public Shared Function LatestTopicsForumTitle(ByVal m As Match) As String
			Dim ForumID as Integer = cLng((m.Groups("forumid").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return LatestTopics(10, 1, BoxTitle, ForumID)
		End Function

		Public Shared Function LatestTopicsNumberForum(ByVal m As Match) As String
			Dim NumTopics as Integer = cLng((m.Groups("num").Value).ToString())
			Dim ForumID as Integer = cLng((m.Groups("forumid").Value).ToString())
			return LatestTopics(NumTopics, 1, "Latest Topics", ForumID)
		End Function

		Public Shared Function LatestTopicsNumberForumTitle(ByVal m As Match) As String
			Dim NumTopics as Integer = cLng((m.Groups("num").Value).ToString())
			Dim ForumID as Integer = cLng((m.Groups("forumid").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return LatestTopics(NumTopics, 1, BoxTitle, ForumID)
		End Function

		Public Shared Function LatestTopicsNumberNoBox(ByVal m As Match) As String
			Dim NumTopics as Integer = cLng((m.Groups("num").Value).ToString())
			return LatestTopics(NumTopics, 0, "Latest Topics")
		End Function

		Public Shared Function LatestTopicsForumNoBox(ByVal m As Match) As String
			Dim ForumID as Integer = cLng((m.Groups("forumid").Value).ToString())
			return LatestTopics(10, 0, "Latest Topics", ForumID)
		End Function

		Public Shared Function LatestTopicsNumberForumNoBox(ByVal m As Match) As String
			Dim NumTopics as Integer = cLng((m.Groups("num").Value).ToString())
			Dim ForumID as Integer = cLng((m.Groups("forumid").Value).ToString())
			return LatestTopics(NumTopics, 0, "Latest Topics", ForumID)
		End Function

		Public Shared Function LatestTopics(NumTopics as Integer, ShowBox as Integer, BoxTitle as String, Optional ForumID as Integer = 0) as String
			Dim ReturnString as String = ""

			Dim WhereClause as String = ""
			Dim NewTopicLink as String = "newtopic_selectforum.aspx"
			if (ForumID <> 0) then
				WhereClause = " F.FORUM_ID = " & ForumID & " AND"
				NewTopicLink = "newtopic.aspx?ID=" & ForumID
			end if

			Dim TheFontColor as String = ""

			if (ShowBox = 1) then
				ReturnString &= "<table width=""100%"" class=""ContentBox"" cellpadding=""5"" cellspacing=""0"">"
				ReturnString &= "<tr class=""HeaderCell"">"
				ReturnString &= "<td align=""left"">"
				ReturnString &= "<font size=""" & Settings.HeaderSize & """ color=""" & Settings.HeaderFontColor & """><b>"
				ReturnString &= BoxTitle
				ReturnString &= "</b></font></td></tr><tr class=""TableRow1""><td>"
				TheFontColor = " color=""" & Settings.TopicsFontColor & """"
			end if

			Dim count as Integer = 0
			Dim HTReader as OdbcDataReader = Database.Read("SELECT T.TOPIC_ID, T.TOPIC_SUBJECT, T.TOPIC_AUTHOR, T.TOPIC_DATE, T.TOPIC_LASTPOST_AUTHOR, T.TOPIC_LASTPOST_DATE, T.TOPIC_REPLIES, M1.MEMBER_USERNAME as TheAuthor, M2.MEMBER_USERNAME as LastPoster FROM (" & Database.DBPrefix & "_TOPICS T INNER JOIN " & Database.DBPrefix & "_MEMBERS M1 ON T.TOPIC_AUTHOR = M1.MEMBER_ID INNER JOIN " & Database.DBPrefix & "_MEMBERS M2 ON T.TOPIC_LASTPOST_AUTHOR = M2.MEMBER_ID) LEFT OUTER JOIN " & Database.DBPrefix & "_FORUMS F ON T.FORUM_ID = F.FORUM_ID WHERE" & WhereClause & " F.FORUM_TYPE = 0 AND F.FORUM_STATUS <> 0 AND F.FORUM_SHOWLATEST = 1 AND T.TOPIC_STATUS <> 0 AND T.TOPIC_CONFIRMED = 1 ORDER BY T.TOPIC_LASTPOST_DATE DESC", NumTopics)
			While HTReader.Read()
				if count > 0 then
					ReturnString &= "<br /><br />"
				end if
				ReturnString &= "<font size=""2""" & TheFontColor & "><b><a href=""topics.aspx?ID=" & HTReader("TOPIC_ID") & """>" & Left(HTReader("TOPIC_SUBJECT").ToString(), 60)
				if Len(HTReader("TOPIC_SUBJECT").ToString()) > 60 then
					ReturnString &= "..."
				end if
				ReturnString &= "</a></b></font><font size=""1""" & TheFontColor & "><br />"
				ReturnString &= "Posted by <a href=""profile.aspx?ID=" & HTReader("TOPIC_AUTHOR") & """>" & HTReader("TheAuthor").ToString() & "</a>"
				if HTReader("TOPIC_REPLIES") = 0 then
					ReturnString &= " on " & FormatDate(HTReader("TOPIC_DATE"), 2) & "."
				else
					ReturnString &= ".  Last Replied by <a href=""profile.aspx?ID=" & HTReader("TOPIC_LASTPOST_AUTHOR") & """>" & HTReader("LastPoster").ToString() & "</a> on " & FormatDate(HTReader("TOPIC_LASTPOST_DATE"), 2) & ".  (" & HTReader("TOPIC_REPLIES").ToString() & " Replies)"
				end if
				ReturnString &= "</font>"
				count = count + 1
			End While
			HTReader.Close()

			if (ShowBox = 1) then
				ReturnString &= "<center><br /><font size=""2""><a href=""" & NewTopicLink & """><b>Create New Topic</b></a></font></center>"
				ReturnString &= "</td></tr></table>"
			else
				ReturnString &= "<br /><br /><li /><font size=""2""><a href=""" & NewTopicLink & """><b>Create New Topic</b></a></font>"
			end if

			Return ReturnString
		End Function

		Public Shared Function LatestBlogsNumber(ByVal m As Match) As String
			Dim NumBlogs as Integer = cLng((m.Groups("num").Value).ToString())
			return LatestBlogs(NumBlogs, 1)
		End Function

		Public Shared Function LatestBlogsNumberTitle(ByVal m As Match) As String
			Dim NumBlogs as Integer = cLng((m.Groups("num").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return LatestBlogs(NumBlogs, 1, BoxTitle)
		End Function

		Public Shared Function LatestBlogsTitle(ByVal m As Match) As String
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return LatestBlogs(10, 1, BoxTitle)
		End Function

		Public Shared Function LatestBlogsNumberNoBox(ByVal m As Match) As String
			Dim NumBlogs as Integer = cLng((m.Groups("num").Value).ToString())
			return LatestBlogs(NumBlogs, 0)
		End Function

		Public Shared Function LatestBlogs(NumBlogs as Integer, ShowBox as Integer, Optional BoxTitle as String = "Latest Blog Entries") as String
			Dim ReturnString as String = ""

			Dim TheFontColor as String = ""

			if (ShowBox = 1) then
				ReturnString &= "<table width=""100%"" class=""ContentBox"" cellpadding=""5"" cellspacing=""0"">"
				ReturnString &= "<tr class=""HeaderCell"">"
				ReturnString &= "<td align=""left"">"
				ReturnString &= "<font size=""" & Settings.HeaderSize & """ color=""" & Settings.HeaderFontColor & """><b>"
				ReturnString &= BoxTitle
				ReturnString &= "</b></font></td></tr><tr class=""TableRow1""><td>"
				TheFontColor = " color=""" & Settings.TopicsFontColor & """"
			end if

			Dim count as Integer = 0
			Dim HTReader as OdbcDataReader = Database.Read("SELECT B.BLOG_ID, B.BLOG_AUTHOR, B.BLOG_DATE, B.BLOG_REPLIES, B.BLOG_TITLE, M.MEMBER_USERNAME FROM " & Database.DBPrefix & "_BLOG_TOPICS B Left Outer Join " & Database.DBPrefix & "_MEMBERS M On B.BLOG_AUTHOR = M.MEMBER_ID ORDER BY BLOG_DATE DESC", NumBlogs)
			While HTReader.Read()
				if count > 0 then
					ReturnString &= "<br /><br />"
				end if
				ReturnString &= "<font size=""2""" & TheFontColor & "><b><a href=""blogs.aspx?ID=" & HTReader("BLOG_ID") & """>" & Left(HTReader("BLOG_TITLE").ToString(), 60)
				if Len(HTReader("BLOG_TITLE").ToString()) > 60 then
					ReturnString &= "..."
				end if
				ReturnString &= "</a></b></font><font size=""1""" & TheFontColor & "><br />"
				ReturnString &= "Posted by <a href=""profile.aspx?ID=" & HTReader("BLOG_AUTHOR") & """>" & HTReader("MEMBER_USERNAME").ToString() & "</a> on " & FormatDate(HTReader("BLOG_DATE"), 2) & "."
				if HTReader("BLOG_REPLIES") > 0 then
					ReturnString &= "  (" & HTReader("BLOG_REPLIES").ToString() & " Comments)"
				end if
				ReturnString &= "</font>"
				count = count + 1
			End While
			HTReader.Close()

			if (ShowBox = 1) then
				ReturnString &= "</td></tr></table>"
			end if

			Return ReturnString
		End Function

		Public Shared Function ImageRotator(ByVal m As Match) As String
			Dim RotatorID as String = (m.Groups("num").Value).ToString()
			Dim ReturnString as String = ""

			Dim Reader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_ROTATOR_IMAGES WHERE ROTATOR_ID = " & RotatorID & " ORDER BY NEWID()", 1)
			While Reader.Read()
				if ((Reader("IMAGE_URL").ToString()).Length() > 0) then
					ReturnString &= "<a"
					if (Reader("IMAGE_WINDOW") = 1) then
						ReturnString &= " target=""_blank"""
					end if
					ReturnString &= " href=""" & Reader("IMAGE_URL").ToString() & """>"
				end if
				ReturnString &= "<img src=""rotatorimages/" & Reader("IMAGE_ID").ToString() & "." & Reader("IMAGE_EXTENSION").ToString() & """ border=""" & Reader("IMAGE_BORDER").ToString() & """>"
				if ((Reader("IMAGE_DESCRIPTION").ToString()).Length() > 0) then
					ReturnString &= "<br />" & Reader("IMAGE_DESCRIPTION").ToString()
				end if
				if ((Reader("IMAGE_URL").ToString()).Length() > 0) then
					ReturnString &= "</a>"
				end if
			End While
			Reader.Close()

			Return ReturnString
		End Function

		Public Shared Function PhotoGallery(ByVal GalleryID as Integer, NumCols as Integer) As String
			Dim ReturnString as String = "<table class=""PhotoGalleryTable"">"
			Dim ColumnWidth as Integer = System.Math.Floor(100.00/NumCols)
			Dim Count as Integer = 1

			Dim Reader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_GALLERY_PHOTOS WHERE GALLERY_ID = " & GalleryID & " ORDER BY PHOTO_ID")
			While Reader.Read()
				if (Count = 1) then
					ReturnString &= "<tr>"
				end if
				ReturnString &= "<td width=""" & ColumnWidth & "%"">"
				ReturnString &= "<a href=""javascript:openPhoto('showphoto.aspx?PHOTO=photogalleries/" & Reader("PHOTO_ID").ToString() & "." & Reader("PHOTO_EXTENSION").ToString() & "')"">"
				ReturnString &= "<img border=""0"" src=""photogalleries/" & Reader("PHOTO_ID").ToString() & "_s." & Reader("PHOTO_EXTENSION").ToString() & """>"
				if ((Reader("PHOTO_DESCRIPTION").ToString()).Length() > 0) then
					ReturnString &= "<br />" & Reader("PHOTO_DESCRIPTION").ToString()
				end if
				ReturnString &= "</a>"
				ReturnString &= "</td>"
				if (Count = NumCols) then
					ReturnString &= "</tr>"
					Count = 1
				else
					Count = Count + 1
				end if
			End While
			Reader.Close()

			if (Count <> 1) then
				ReturnString &= "</tr>"
			end if

			ReturnString &= "</table>"
			Return ReturnString
		End Function

		Public Shared Function UserVariables(Field as String) as String
			Dim ReturnString as String = ""
			Dim VarReader as OdbcDataReader = Database.Read("SELECT " & Field & " as TheField FROM " & Database.DBPrefix & "_VARIABLES WHERE ID = 1")
			While VarReader.Read()
				ReturnString = VarReader("TheField").ToString()
			End While
			VarReader.Close()
			Return ReturnString
		End Function

		Public Shared Function CustomMessage(Field as String) as String
			Dim ReturnString as String = ""
			Dim Reader as OdbcDataReader = Database.Read("SELECT " & Field & " as TheField FROM " & Database.DBPrefix & "_CUSTOM_MESSAGES WHERE ID = 1")
			While Reader.Read()
				ReturnString = Reader("TheField").ToString()
			End While
			Reader.Close()
			Return ReturnString
		End Function

		Public Shared Function ShowLink(mID as String, mLogged as String, mLevel as String, LinkType as Integer) as String
			Dim ReturnString as String = ""
			if (LinkType = 1) then
				if (mLogged = "1") then
					ReturnString = "<a href=""usercp.aspx?ID=" & mID & """>User CP</a>"
				else
					ReturnString = "<a href=""register.aspx"">Register</a>"
				end if
			elseif (LinkType = 2) then
				if ((mLogged = "1") and (mLevel = "3")) then
					ReturnString = "<a href=""admin.aspx"">Administration</a>"
				end if
			elseif (LinkType = 3) then
				if (mLogged = "1") then
					Dim PMCount as Integer = 0
					if (Functions.IsInteger(mID)) then
						Dim PMReader as OdbcDataReader = Database.Read("SELECT Count(*) as TheCount FROM " & Database.DBPrefix & "_PM_TOPICS WHERE (TOPIC_TO = " & mID & " AND TOPIC_TO_READ = 0) or (TOPIC_FROM = " & mID & " AND TOPIC_FROM_READ = 0)")
						While PMReader.Read()
							PMCount = PMReader("TheCount")
						End While
						PMReader.Close()
					end if
					if PMCount > 0 then
						ReturnString = "<a href=""pm_inbox.aspx""><b>Private Messages (" & PMCount & ")</b></a>"
					else
						ReturnString = "<a href=""pm_inbox.aspx"">Private Messages</a>"
					end if
				end if
			end if
			Return ReturnString
		End Function

		Public Shared Function FeaturedTopicsMax(ByVal m As Match) As String
			Dim Max as Integer = cLng((m.Groups("max").Value).ToString())
			return FeaturedTopics(0, Max, 500)
		End Function

		Public Shared Function FeaturedTopicsDays(ByVal m As Match) As String
			Dim NewsDays as Integer = cLng((m.Groups("days").Value).ToString())
			return FeaturedTopics(NewsDays, 0, 500)
		End Function

		Public Shared Function FeaturedTopicsChars(ByVal m As Match) As String
			Dim Chars as Integer = cLng((m.Groups("chars").Value).ToString())
			return FeaturedTopics(0, 0, Chars)
		End Function

		Public Shared Function FeaturedTopicsTitle(ByVal m As Match) As String
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return FeaturedTopics(0, 0, 500, BoxTitle)
		End Function

		Public Shared Function FeaturedTopicsMaxDays(ByVal m As Match) As String
			Dim Max as Integer = cLng((m.Groups("max").Value).ToString())
			Dim NewsDays as Integer = cLng((m.Groups("days").Value).ToString())
			return FeaturedTopics(NewsDays, Max, 500)
		End Function

		Public Shared Function FeaturedTopicsMaxChars(ByVal m As Match) As String
			Dim Max as Integer = cLng((m.Groups("max").Value).ToString())
			Dim Chars as Integer = cLng((m.Groups("chars").Value).ToString())
			return FeaturedTopics(0, Max, Chars)
		End Function

		Public Shared Function FeaturedTopicsMaxTitle(ByVal m As Match) As String
			Dim Max as Integer = cLng((m.Groups("max").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return FeaturedTopics(0, Max, 500, BoxTitle)
		End Function

		Public Shared Function FeaturedTopicsDaysChars(ByVal m As Match) As String
			Dim NewsDays as Integer = cLng((m.Groups("days").Value).ToString())
			Dim Chars as Integer = cLng((m.Groups("chars").Value).ToString())
			return FeaturedTopics(NewsDays, 0, Chars)
		End Function

		Public Shared Function FeaturedTopicsDaysTitle(ByVal m As Match) As String
			Dim NewsDays as Integer = cLng((m.Groups("days").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return FeaturedTopics(NewsDays, 0, 500, BoxTitle)
		End Function

		Public Shared Function FeaturedTopicsCharsTitle(ByVal m As Match) As String
			Dim Chars as Integer = cLng((m.Groups("chars").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return FeaturedTopics(0, 0, Chars, BoxTitle)
		End Function

		Public Shared Function FeaturedTopicsMaxDaysTitle(ByVal m As Match) As String
			Dim Max as Integer = cLng((m.Groups("max").Value).ToString())
			Dim NewsDays as Integer = cLng((m.Groups("days").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return FeaturedTopics(NewsDays, Max, 500, BoxTitle)
		End Function

		Public Shared Function FeaturedTopicsMaxCharsTitle(ByVal m As Match) As String
			Dim Max as Integer = cLng((m.Groups("max").Value).ToString())
			Dim Chars as Integer = cLng((m.Groups("chars").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return FeaturedTopics(0, Max, Chars, BoxTitle)
		End Function

		Public Shared Function FeaturedTopicsDaysCharsTitle(ByVal m As Match) As String
			Dim NewsDays as Integer = cLng((m.Groups("days").Value).ToString())
			Dim Chars as Integer = cLng((m.Groups("chars").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return FeaturedTopics(NewsDays, 0, Chars, BoxTitle)
		End Function

		Public Shared Function FeaturedTopicsMaxDaysChars(ByVal m As Match) As String
			Dim Max as Integer = cLng((m.Groups("max").Value).ToString())
			Dim NewsDays as Integer = cLng((m.Groups("days").Value).ToString())
			Dim Chars as Integer = cLng((m.Groups("chars").Value).ToString())
			return FeaturedTopics(NewsDays, Max, Chars)
		End Function

		Public Shared Function FeaturedTopicsMaxDaysCharsTitle(ByVal m As Match) As String
			Dim Max as Integer = cLng((m.Groups("max").Value).ToString())
			Dim NewsDays as Integer = cLng((m.Groups("days").Value).ToString())
			Dim Chars as Integer = cLng((m.Groups("chars").Value).ToString())
			Dim BoxTitle as String = (m.Groups("title").Value).ToString()
			return FeaturedTopics(NewsDays, Max, Chars, BoxTitle)
		End Function

		Public Shared Function FeaturedTopics(NewsDays as Integer, Max as Integer, Chars as Integer, Optional BoxTitle as String = "Featured Topics") as String
			Dim Show as Integer = 0
			Dim PageItems as Integer
			if Settings.ItemsPerPage <> 0 then
				PageItems = Settings.ItemsPerPage
			else
				PageItems = 15
			end if

			Dim NumPages, Leftover as Integer
			Dim ReturnString as String
			ReturnString = "<!-- Top News -->"

			Dim WhereClause as String
			if (NewsDays = 0) then
				WhereClause = "(T.TOPIC_NEWS = 1) and (T.TOPIC_STATUS <> 0)"
			else
				WhereClause = "(T.TOPIC_NEWS = 1) and (T.TOPIC_STATUS <> 0) and (" & Database.GetDateDiff("d", "T.TOPIC_DATE", Database.GetTimeStamp()) & " <= " & NewsDays & ")"
			end if

			Dim NewsReader as OdbcDataReader = Database.Read("SELECT T.TOPIC_ID, T.TOPIC_SUBJECT, T.TOPIC_MESSAGE, T.TOPIC_AUTHOR, T.TOPIC_DATE, T.TOPIC_REPLIES, T.TOPIC_FILEUPLOAD, M.MEMBER_USERNAME FROM " & Database.DBPrefix & "_TOPICS T Left Outer Join " & Database.DBPrefix & "_MEMBERS M On T.TOPIC_AUTHOR = M.MEMBER_ID WHERE " & WhereClause & " ORDER BY T.TOPIC_DATE DESC", Max)
			if NewsReader.HasRows() then
				ReturnString &= "<table width=""100%"" class=""ContentBox"" cellpadding=""5"" cellspacing=""0"">"
				ReturnString &= "<tr class=""HeaderCell"">"
				ReturnString &= "<td align=""left"" colspan=""2"">"
				ReturnString &= "<font size=""" & Settings.HeaderSize & """ color=""" & Settings.HeaderFontColor & """><b>"
				ReturnString &= BoxTitle
				ReturnString &= "</b></font></td><td align=""right"">"
				if (Settings.RSSFeeds = 1) then
					ReturnString &= "<a target=""_blank"" href=""rssfeed.aspx?ID=news""><img src=""forumimages/rss.gif"" border=""0""></a>"
				end if
				ReturnString &= "</td></tr>"
				Show = 1
			end if
			While NewsReader.Read()
				NumPages = NewsReader("TOPIC_REPLIES") \ PageItems
				Leftover = NewsReader("TOPIC_REPLIES") Mod PageItems
				If Leftover > 0 then
					NumPages += 1
				end if
				ReturnString &= "<tr class=""SubHeaderCell""><td align=""left"" valign=""middle"" nowrap><font size=""2"" color=""" & Settings.SubHeaderFontColor & """><b>"
				ReturnString &= "<a href=""topics.aspx?ID=" & NewsReader("TOPIC_ID") & """>" & NewsReader("TOPIC_SUBJECT").ToString() & "</a></b>" & QuickPaging(NewsReader("TOPIC_ID"), NewsReader("TOPIC_REPLIES"), Settings.ItemsPerPage) & "</font></td>"
				ReturnString &= "<td width=""100%"" align=""center"" valign=""middle"" nowrap><font size=""1"" color=""" & Settings.SubHeaderFontColor & """>Posted By <a href=""profile.aspx?ID=" & NewsReader("TOPIC_AUTHOR") & """>" & NewsReader("MEMBER_USERNAME").ToString() & "</a></font></td>"
				ReturnString &= "<td align=""center"" valign=""middle"" nowrap><font size=""1"" color=""" & Settings.SubHeaderFontColor & """>" & FormatDate(NewsReader("TOPIC_DATE"), 1) & "<br />" & FormatDate(NewsReader("TOPIC_DATE"), 2) & "</font></td></tr>"
			 	ReturnString &= "<tr class=""TableRow1""><td width=""100%"" colspan=""3""><font size=""2"" color=""" & Settings.TopicsFontColor & """>"
				Dim HasImageUpload as Boolean = "false"
				if ((Right(NewsReader("TOPIC_FILEUPLOAD").ToString(), 4) = ".jpg") or (Right(NewsReader("TOPIC_FILEUPLOAD").ToString(), 4) = ".gif") or (Right(NewsReader("TOPIC_FILEUPLOAD").ToString(), 4) = ".png")) then
					HasImageUpload = "true"
					ReturnString &= ShowTopicFileUpload(NewsReader("TOPIC_FILEUPLOAD").ToString(), 1)
				end if
				ReturnString &= FormatString(LeftText(NewsReader("TOPIC_MESSAGE").ToString(), Chars))
				ReturnString &= "</font></td></tr>"
				ReturnString &= "<tr class=""TableRow1""><td colspan=""3"" align=""left""><font size=""2"" color=""" & Settings.TopicsFontColor & """>"
				ReturnString &= "<img src=""forumimages/latestcomments.gif"">&nbsp;<a href=""topics.aspx?ID=" & NewsReader("TOPIC_ID") & "&PAGE=" & NumPages & """>Read The Latest Comments (" & NewsReader("TOPIC_REPLIES") & ")</a>"
				if ((Not HasImageUpload) and (NewsReader("TOPIC_FILEUPLOAD").ToString() <> "")) then
					ReturnString &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & ShowTopicFileUpload(NewsReader("TOPIC_FILEUPLOAD").ToString(), 1)
				end if
				ReturnString &= "</td></tr>"
			End While
			NewsReader.Close()

			if Show = 1 then
				ReturnString &= "</table>"
			end if
			Return ReturnString
		End Function

		Public Shared Function MenuHTML(ByVal mID as String, mLogged as String, mLevel as String, MenuType as Integer) as String
			Dim ReturnString as String = ""
			Dim Count as Integer = 0
			Dim NewWindow as String = ""
			Dim Sep as String = ""
			Dim Separator as String = " "
			if (MenuType = 1) then
				Separator = Settings.HorizDivide
			else
				Separator = Settings.VertDivide
			end if

			Dim Reader as OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_MAIN_MENU ORDER BY LINK_ORDER")
			While Reader.Read()
				if (Count > 0) then
					Sep = Separator
				else
					Sep = ""
				end if

				if (Reader("LINK_WINDOW") = 1) then
					NewWindow = " target=""_blank"""
				else
					NewWindow = ""
				end if

				if (Reader("LINK_TYPE") = 1) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""default.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
				elseif (Reader("LINK_TYPE") = 2) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""page.aspx?ID=" & Reader("LINK_PARAMETER").ToString() & """>" & Reader("LINK_TEXT").ToString() & "</a>"
				elseif (Reader("LINK_TYPE") = 3) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""forumhome.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
				elseif (Reader("LINK_TYPE") = 4) then
					if ((mLogged = "0") and (Settings.AllowRegistration = 1)) then
						ReturnString &= Sep & "<a" & NewWindow & " href=""register.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
					end if
				elseif (Reader("LINK_TYPE") = 5) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""active.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
				elseif (Reader("LINK_TYPE") = 6) then
					if ((mLogged = "1") or (Settings.HideMembers = 0)) then
						ReturnString &= Sep & "<a" & NewWindow & " href=""members.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
					end if
				elseif (Reader("LINK_TYPE") = 7) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""search.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
				elseif (Reader("LINK_TYPE") = 8) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""forumhome.aspx?ID=" & Reader("LINK_PARAMETER").ToString() & """>" & Reader("LINK_TEXT").ToString() & "</a>"
				elseif (Reader("LINK_TYPE") = 9) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""forums.aspx?ID=" & Reader("LINK_PARAMETER").ToString() & """>" & Reader("LINK_TEXT").ToString() & "</a>"
				elseif (Reader("LINK_TYPE") = 10) then
					if mLogged = "1" then
						ReturnString &= Sep & "<a" & NewWindow & " href=""usercp.aspx?ID=" & mID & """>" & Reader("LINK_TEXT").ToString() & "</a>"
					end if
				elseif (Reader("LINK_TYPE") = 11) then
					if mLogged = "1" then
						Dim PMCount as Integer = 0
						if (Functions.IsInteger(mID)) then
							Dim PMReader as OdbcDataReader = Database.Read("SELECT Count(*) as TheCount FROM " & Database.DBPrefix & "_PM_TOPICS WHERE (TOPIC_TO = " & mID & " AND TOPIC_TO_READ = 0) or (TOPIC_FROM = " & mID & " AND TOPIC_FROM_READ = 0)")
							While PMReader.Read()
								PMCount = PMReader("TheCount")
							End While
							PMReader.Close()
						end if
						if (PMCount > 0) then
							ReturnString &= Sep & "<a" & NewWindow & " href=""pm_inbox.aspx""><b>" & Reader("LINK_TEXT").ToString() & " (" & PMCount & ")</b></a>"
						else
							ReturnString &= Sep & "<a" & NewWindow & " href=""pm_inbox.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
						end if
					end if
				elseif (Reader("LINK_TYPE") = 12) then
					if mLogged = "1" then
						ReturnString &= Sep & "<a" & NewWindow & " href=""editprofile.aspx?ID=" & mID & """>" & Reader("LINK_TEXT").ToString() & "</a>"
					end if
				elseif (Reader("LINK_TYPE") = 13) then

					if mLevel = "3" then
						ReturnString &= Sep & "<a" & NewWindow & " href=""admin.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
					end if
				elseif (Reader("LINK_TYPE") = 14) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""" & Reader("LINK_PARAMETER").ToString() & """>" & Reader("LINK_TEXT").ToString() & "</a>"
				elseif (Reader("LINK_TYPE") = 15) then
					ReturnString &= Sep & "<a" & NewWindow & " href=""login.aspx"">" & Reader("LINK_TEXT").ToString() & "</a>"
				end if

				Count = Count + 1
			End While
			Reader.Close()
			Return ReturnString
		End Function

		Public Shared Function ForumMenu(ByVal mID as String, mLogged as String, mLevel as String, MenuType as Integer) as String
			Dim Separator as String = " "
			if (MenuType = 1) then
				Separator = Settings.HorizDivide
			else
				Separator = Settings.VertDivide
			end if

			Dim PMCount as Integer = 0
			if (Functions.IsInteger(mID)) then
				Dim PMReader as OdbcDataReader = Database.Read("SELECT Count(*) as TheCount FROM " & Database.DBPrefix & "_PM_TOPICS WHERE (TOPIC_TO = " & mID & " AND TOPIC_TO_READ = 0) or (TOPIC_FROM = " & mID & " AND TOPIC_FROM_READ = 0)")
				While PMReader.Read()
					PMCount = PMReader("TheCount")
				End While
				PMReader.Close()
			end if

			Dim ReturnString as String = ""

			if (Settings.ForumsDefault <> 1) then
				ReturnString &= "<a href=""default.aspx"">Main Page</a>" & Separator
			end if
			ReturnString &= "<a href=""ForumHome.aspx"">Forums</a>"
			if mLogged = "0" then
				ReturnString &= Separator & "<a href=""register.aspx"">Register</a>"
			end if
			ReturnString &= Separator & "<a href=""active.aspx"">Active Topics</a>"
			ReturnString &= Separator & "<a href=""members.aspx"">Members</a>"
			ReturnString &= Separator & "<a href=""search.aspx"">Search</a>"
			if mLogged = "1" then
				ReturnString &= Separator & "<a href=""usercp.aspx?ID=" & mID & """>User CP</a>"
				if PMCount > 0 then
					ReturnString &= Separator & "<a href=""pm_inbox.aspx""><b>Private Messages (" & PMCount & ")</b></a>"
				else
					ReturnString &= Separator & "<a href=""pm_inbox.aspx"">Private Messages</a>"
				end if
			end if
			if mLevel = "3" then
				ReturnString &= Separator & "<a href=""admin.aspx"">Administration</a>"
			end if

			Return ReturnString
		End Function

		Public Shared Function PageMenuParentV(ByVal m As Match) As String
			Dim ParentID as Integer = cLng((m.Groups("num").Value).ToString())
			return PageMenu(1, ParentID)
		End Function

		Public Shared Function PageMenuParentH(ByVal m As Match) As String
			Dim ParentID as Integer = cLng((m.Groups("num").Value).ToString())
			return PageMenu(2, ParentID)
		End Function

		Public Shared Function PageMenu(MenuType as Integer, ParentID as Integer) as String
			Dim ReturnString as String = ""
			Dim Count as Integer = 0
			Dim MenuReader as OdbcDataReader = Database.Read("SELECT PAGE_ID, PAGE_NAME FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_STATUS <> 0 AND PAGE_PARENT = " & ParentID & " ORDER BY PAGE_SORT ASC, PAGE_NAME")
				While MenuReader.Read()
					if (MenuType = 1) then
						if (Count > 0) then
							ReturnString &= "<br /><br />"
						else
							Count += 1
						end if
						if MenuReader("PAGE_ID") = 1 then
							ReturnString &= "<a href=""default.aspx"">" & MenuReader("PAGE_NAME") & "</a>"
						else
							ReturnString &= "<a href=""page.aspx?ID=" & MenuReader("PAGE_ID") & """>" & MenuReader("PAGE_NAME") & "</a>"
						end if
					else
						if (Count > 0) then
							ReturnString &= "&nbsp;&nbsp;<b>|</b>&nbsp;&nbsp;"
						else
							Count += 1
						end if
						if MenuReader("PAGE_ID") = 1 then
							ReturnString &= "<a href=""default.aspx"">" & MenuReader("PAGE_NAME") & "</a>"
						else
							ReturnString &= "<a href=""page.aspx?ID=" & MenuReader("PAGE_ID") & """>" & MenuReader("PAGE_NAME") & "</a>"
						end if
					end if
				End While
			MenuReader.Close()
			if ((System.Web.HttpContext.Current.Session("UserLevel") = "3") and (ParentID = 0)) then
				if (MenuType = 1) then
					ReturnString &= "<br /><br />"
				else
					ReturnString &= "&nbsp;&nbsp;<b>|</b>&nbsp;&nbsp;"
				end if
				ReturnString &= "<a href=""admin.aspx"">Admin</a>"
			end if
			Return ReturnString
		End Function

		Public Shared Sub UpdateCounts(UpdateType as Integer, Param1 as Integer, Param2 as Integer, Param3 as Integer)
			'UpdateType: 1 = normal
			'UpdateType: 2 = topic confirmed, Param1 = ForumID
			'UpdateType: 3 = reply confirmed, Param1 = ForumID
			'UpdateType: 4 = topic moved, Param1 = Old Forum, Param2 = New Forum, Param3 = TopicID
			'UpdateType: 5 = reply deleted, Param1 = ForumID

			Dim Reader as OdbcDataReader

			if (UpdateType = 2) then
				Reader = Database.Read("SELECT TOPIC_LASTPOST_AUTHOR, TOPIC_LASTPOST_DATE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & Param1 & " ORDER BY TOPIC_LASTPOST_DATE DESC", 1)
				While Reader.Read()
					Database.Write("UPDATE " & Database.DBPrefix & "_FORUMS SET FORUM_TOPICS = (FORUM_TOPICS+1), FORUM_POSTS = (FORUM_POSTS+1), FORUM_LASTPOST_AUTHOR = " & Reader("TOPIC_LASTPOST_AUTHOR") & ", FORUM_LASTPOST_DATE = '" & Reader("TOPIC_LASTPOST_DATE") & "' WHERE FORUM_ID = " & Param1)
				End While
				Reader.Close()
			else if (UpdateType = 3) then
				Reader = Database.Read("SELECT TOPIC_LASTPOST_AUTHOR, TOPIC_LASTPOST_DATE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & Param1 & " ORDER BY TOPIC_LASTPOST_DATE DESC", 1)
				While Reader.Read()
					Database.Write("UPDATE " & Database.DBPrefix & "_FORUMS SET FORUM_POSTS = (FORUM_POSTS+1), FORUM_LASTPOST_AUTHOR = " & Reader("TOPIC_LASTPOST_AUTHOR") & ", FORUM_LASTPOST_DATE = '" & Reader("TOPIC_LASTPOST_DATE") & "' WHERE FORUM_ID = " & Param1)
				End While
				Reader.Close()
			else if (UpdateType = 4) then
				Dim TopicReplies as Integer = 0
				Reader = Database.Read("SELECT TOPIC_REPLIES FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_ID = " & Param3)
				While Reader.Read()
					TopicReplies = Reader("TOPIC_REPLIES")
				End While
				Reader.Close()

				Reader = Database.Read("SELECT TOPIC_LASTPOST_AUTHOR, TOPIC_LASTPOST_DATE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & Param1 & " ORDER BY TOPIC_LASTPOST_DATE DESC", 1)
				if Reader.HasRows() then
					While Reader.Read()
						Database.Write("UPDATE " & Database.DBPrefix & "_FORUMS SET FORUM_TOPICS = (FORUM_TOPICS-1), FORUM_POSTS = (FORUM_POSTS - " & TopicReplies & " - 1), FORUM_LASTPOST_AUTHOR = " & Reader("TOPIC_LASTPOST_AUTHOR") & ", FORUM_LASTPOST_DATE = '" & Reader("TOPIC_LASTPOST_DATE") & "' WHERE FORUM_ID = " & Param1)
					End While
				else
					Database.Write("UPDATE " & Database.DBPrefix & "_FORUMS SET FORUM_TOPICS = 0, FORUM_POSTS = 0, FORUM_LASTPOST_AUTHOR = 0 WHERE FORUM_ID = " & Param1)
				end if
				Reader.Close()

				Reader = Database.Read("SELECT TOPIC_LASTPOST_AUTHOR, TOPIC_LASTPOST_DATE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & Param2 & " ORDER BY TOPIC_LASTPOST_DATE DESC", 1)
				While Reader.Read()
					Database.Write("UPDATE " & Database.DBPrefix & "_FORUMS SET FORUM_TOPICS = (FORUM_TOPICS+1), FORUM_POSTS = (FORUM_POSTS + " & TopicReplies & " + 1), FORUM_LASTPOST_AUTHOR = " & Reader("TOPIC_LASTPOST_AUTHOR") & ", FORUM_LASTPOST_DATE = '" & Reader("TOPIC_LASTPOST_DATE") & "' WHERE FORUM_ID = " & Param2)
				End While
				Reader.Close()
			else if (UpdateType = 5) then
				Reader = Database.Read("SELECT TOPIC_LASTPOST_AUTHOR, TOPIC_LASTPOST_DATE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & Param1 & " ORDER BY TOPIC_LASTPOST_DATE DESC", 1)
				While Reader.Read()
					Database.Write("UPDATE " & Database.DBPrefix & "_FORUMS SET FORUM_POSTS = (FORUM_POSTS-1), FORUM_LASTPOST_AUTHOR = " & Reader("TOPIC_LASTPOST_AUTHOR") & ", FORUM_LASTPOST_DATE = '" & Reader("TOPIC_LASTPOST_DATE") & "' WHERE FORUM_ID = " & Param1)
				End While
				Reader.Close()
			else
				Dim TopicsCount as OdbcDataReader = Database.Read("SELECT TOPIC_ID FROM " & Database.DBPrefix & "_TOPICS")
				While TopicsCount.Read()
					Database.Write("UPDATE " & Database.DBPrefix & "_TOPICS SET TOPIC_REPLIES = (SELECT COUNT(*) as RCounter FROM " & Database.DBPrefix & "_REPLIES WHERE TOPIC_ID = " & TopicsCount("TOPIC_ID") & " and REPLY_CONFIRMED = 1) WHERE TOPIC_ID = " & TopicsCount("TOPIC_ID"))
				End While
				TopicsCount.Close()

				Dim ForumsCount as OdbcDataReader = Database.Read("SELECT FORUM_ID FROM " & Database.DBPrefix & "_FORUMS")
				While ForumsCount.Read()
					if (Database.DBType = "MySQL") then
						Database.Write("UPDATE " & Database.DBPrefix & "_FORUMS SET FORUM_LASTPOST_AUTHOR = (SELECT TOPIC_LASTPOST_AUTHOR FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & ForumsCount("FORUM_ID") & " ORDER BY TOPIC_LASTPOST_DATE DESC LIMIT 1), FORUM_LASTPOST_DATE = (SELECT TOPIC_LASTPOST_DATE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & ForumsCount("FORUM_ID") & " ORDER BY TOPIC_LASTPOST_DATE DESC LIMIT 1), FORUM_TOPICS = (SELECT COUNT(*) as TCounter FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & ForumsCount("FORUM_ID") & "), FORUM_POSTS = ((SELECT COUNT(*) as PCounter1 FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & ForumsCount("FORUM_ID") & ") + (SELECT COUNT(*) as PCounter2 FROM " & Database.DBPrefix & "_REPLIES R Left Outer Join " & Database.DBPrefix & "_TOPICS T On R.TOPIC_ID = T.TOPIC_ID WHERE R.REPLY_CONFIRMED <> 0 and T.TOPIC_STATUS <> 0 and T.TOPIC_CONFIRMED <> 0 and T.FORUM_ID = " & ForumsCount("FORUM_ID") & ")) WHERE FORUM_ID = " & ForumsCount("FORUM_ID"))
					else
						Database.Write("UPDATE " & Database.DBPrefix & "_FORUMS SET FORUM_LASTPOST_AUTHOR = (SELECT TOP 1 TOPIC_LASTPOST_AUTHOR FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & ForumsCount("FORUM_ID") & " ORDER BY TOPIC_LASTPOST_DATE DESC), FORUM_LASTPOST_DATE = (SELECT TOP 1 TOPIC_LASTPOST_DATE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & ForumsCount("FORUM_ID") & " ORDER BY TOPIC_LASTPOST_DATE DESC), FORUM_TOPICS = (SELECT COUNT(*) as TCounter FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & ForumsCount("FORUM_ID") & "), FORUM_POSTS = ((SELECT COUNT(*) as PCounter1 FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_STATUS <> 0 and TOPIC_CONFIRMED <> 0 and FORUM_ID = " & ForumsCount("FORUM_ID") & ") + (SELECT COUNT(*) as PCounter2 FROM " & Database.DBPrefix & "_REPLIES R Left Outer Join " & Database.DBPrefix & "_TOPICS T On R.TOPIC_ID = T.TOPIC_ID WHERE R.REPLY_CONFIRMED <> 0 and T.TOPIC_STATUS <> 0 and T.TOPIC_CONFIRMED <> 0 and T.FORUM_ID = " & ForumsCount("FORUM_ID") & ")) WHERE FORUM_ID = " & ForumsCount("FORUM_ID"))
					end if
				End While
				ForumsCount.Close()
			end if
		End Sub
	End Class

End Namespace
