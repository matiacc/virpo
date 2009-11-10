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
Imports System.Data
Imports System.Data.Odbc
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Math
Imports System.IO
Imports System.Web
Imports System.Web.UI.WebControls
Imports Microsoft.VisualBasic
Imports DMGForums.Global

Namespace DMGForums

	'---------------------------------------------------------------------------------------------------
	' DefaultPage - Codebehind For Default.aspx
	'---------------------------------------------------------------------------------------------------
	Public Class DefaultPage
		Inherits System.Web.UI.Page
	
		Public Category As System.Web.UI.WebControls.Repeater
		Public PageTitle As System.Web.UI.WebControls.Label
		Public PageContent As System.Web.UI.WebControls.Label
		Public SubCategories As System.Web.UI.WebControls.DataList
		Public ForumPanel As System.Web.UI.WebControls.Panel
		Public StatsPanel As System.Web.UI.WebControls.PlaceHolder
		Public MembersText As System.Web.UI.WebControls.Label
		Public NewMemberText As System.Web.UI.WebControls.Label
		Public TopicsText As System.Web.UI.WebControls.Label
		Public SubTitleText as String
		Public PagePhoto As System.Web.UI.WebControls.Label
		Public PagePanel As System.Web.UI.WebControls.Panel
		Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

		Public DMGHeader As DMGForums.Global.Header
		Public DMGFooter As DMGForums.Global.Footer
		Public DMGLogin As DMGForums.Global.Login

		Public CategoryName as String
		Public CustomCategory as String = "No"

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
			if Not Page.IsPostBack() then
				SetSession()

				Dim ForumsDefault as Integer = 1
				Dim Reader as OdbcDataReader = Database.Read("SELECT " & Database.DBPrefix & "_FORUMS_DEFAULT FROM " & Database.DBPrefix & "_SETTINGS WHERE ID = 1", 1)
				While Reader.Read()
					ForumsDefault = Reader("" & Database.DBPrefix & "_FORUMS_DEFAULT")
				End While
				Reader.Close()

				if (ForumsDefault = 1) then
					DisplayForums()
				elseif (ForumsDefault = 2) then
					DisplayForums()
					DisplayDefaultPage()
				else
					DisplayDefaultPage()
				end if

				if (Settings.ShowStatistics = 1) and (ForumsDefault = 1 or ForumsDefault = 2) then
					DisplayStatistics()
				end if
			end if
		End Sub

		Sub DisplayDefaultPage()
			PagePanel.Visible = "True"

			Dim SubTitle as String = ""
			Dim SubShowTitle as Integer = 0
			Dim SubColumns as Integer = 1
			Dim SubAlign as Integer = 1
			Dim SubStatus as Integer = 1

			Dim PageReader as OdbcDataReader = Database.Read("SELECT PAGE_TITLE, PAGE_CONTENT, PAGE_SHOWTITLE, PAGE_AUTOFORMAT, PAGE_STATUS, PAGE_SHOWLOGIN, PAGE_SHOWHEADERS, PAGE_SUB_TITLE, PAGE_SUB_SHOWTITLE, PAGE_SUB_COLUMNS, PAGE_SUB_ALIGN, PAGE_SUB_STATUS, PAGE_PHOTO FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = 1", 1)
				While PageReader.Read()
					Dim Spacer as String = ""
					if (PageReader("PAGE_SHOWTITLE") = 1) then
						PageTitle.Text = PageReader("PAGE_TITLE").ToString()
						Spacer = "<br /><br clear=""all"" />"
					else
						PageTitle.visible = "false"
					end if
					if (PageReader("PAGE_SHOWHEADERS") <> 1) then
						DMGHeader.visible = "false"
						DMGFooter.visible = "false"
					end if
					DMGLogin.ShowLogin() = PageReader("PAGE_SHOWLOGIN")
					if (PageReader("PAGE_CONTENT").ToString() <> "") then
						PageContent.Text = Functions.CustomHTMLVariables(Spacer & PageReader("PAGE_CONTENT").ToString(), Session("UserID"), Session("UserLogged"), Session("UserLevel"))
						if (PageReader("PAGE_AUTOFORMAT") = 1) then
							PageContent.Text = Functions.FormatString(PageContent.Text)
						end if
					end if

					if (PageReader("PAGE_PHOTO") <> "") then
						PagePhoto.Text = "<img src=""pageimages/" & PageReader("PAGE_PHOTO").ToString() & """><br /><br />"
					end if

					SubStatus = PageReader("PAGE_SUB_STATUS")
					if (SubStatus = 1) then
						if (PageReader("PAGE_SUB_SHOWTITLE") = 1) then
							SubShowTitle = 1
							SubTitle = PageReader("PAGE_SUB_TITLE").ToString()
						end if								
						if (Functions.IsInteger(PageReader("PAGE_SUB_COLUMNS"))) then
							SubColumns = PageReader("PAGE_SUB_COLUMNS")
						end if
						SubAlign = PageReader("PAGE_SUB_ALIGN")
					end if
				End While
			PageReader.Close()

			SubCategories.DataSource = Database.Read("SELECT PAGE_ID, PAGE_NAME, PAGE_THUMBNAIL FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_PARENT = 1 AND PAGE_STATUS = 1 ORDER BY PAGE_SORT ASC, PAGE_NAME")
			SubCategories.DataBind()
				if ((SubCategories.Items.Count = 0) or (SubStatus = 0)) then
					SubCategories.Visible = "false"
				else
					if (SubShowTitle = 1) then
						SubTitleText = "<br clear=""all"" /><br />" & SubTitle
						if (SubColumns > 1) then
							SubCategories.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
							SubCategories.ItemStyle.HorizontalAlign = HorizontalAlign.Center
						end if
					end if
					SubCategories.RepeatColumns = SubColumns
					if (SubAlign = 2) then
						SubCategories.Attributes("align") = "Center"
					elseif (SubAlign = 3) then
						SubCategories.Attributes("align") = "Right"
					else
						SubCategories.Attributes("align") = "Left"
					end if
				end if
			SubCategories.DataSource.Close()
		End Sub

		Sub DisplayForums()
			ForumPanel.Visible = "True"

			Dim DataSet1 as new DataSet()
			Dim strSql as OdbcCommand
			Dim strSql2 as String

			if (Functions.IsInteger(Request.QueryString("ID"))) then
				strSql2 = " AND CATEGORY_ID = " & Request.Querystring("ID")
				CustomCategory = "Yes"
			else
				strSql2 = ""
				CustomCategory = "No"
			end if

			strSql = new OdbcCommand("SELECT * FROM " & Database.DBPrefix & "_CATEGORIES WHERE CATEGORY_STATUS = 1" & strSql2 & " ORDER BY CATEGORY_SORTBY", Database.DatabaseConnection())

			if CustomCategory = "Yes" then
				Dim CategoryReader as OdbcDataReader = Database.Read("SELECT CATEGORY_NAME FROM " & Database.DBPrefix & "_CATEGORIES WHERE CATEGORY_ID = " & Request.Querystring("ID"))
					if CategoryReader.HasRows() then
						While(CategoryReader.Read())
							CategoryName = CategoryReader("CATEGORY_NAME").ToString()
						End While
					else
						Response.Redirect("default.aspx")
					end if
				CategoryReader.close()
			end if

			Dim DataAdapter1 as new OdbcDataAdapter()
			DataAdapter1.SelectCommand = strSql
			DataAdapter1.Fill(DataSet1, "CATEGORIES")

			if (Functions.IsInteger(Request.QueryString("ID"))) then
				strSql2 = " AND F.CATEGORY_ID = " & Request.Querystring("ID")
			else
				strSql2 = ""
			end if

			strSql = new OdbcCommand("SELECT F.FORUM_STATUS, F.CATEGORY_ID, F.FORUM_ID, F.FORUM_NAME, F.FORUM_TYPE, F.FORUM_DESCRIPTION, M.MEMBER_USERNAME, M.MEMBER_ID, F.FORUM_LASTPOST_DATE, F.FORUM_TOPICS, F.FORUM_POSTS FROM (" & Database.DBPrefix & "_CATEGORIES AS C INNER JOIN " & Database.DBPrefix & "_FORUMS AS F ON C.CATEGORY_ID = F.CATEGORY_ID) LEFT JOIN " & Database.DBPrefix & "_MEMBERS AS M ON F.FORUM_LASTPOST_AUTHOR = M.MEMBER_ID WHERE (F.FORUM_STATUS <> 0 AND C.CATEGORY_STATUS = 1" & strSql2 & ") ORDER BY F.FORUM_SORTBY", Database.DatabaseConnection())

			DataAdapter1.SelectCommand = strSql
			DataAdapter1.Fill(DataSet1, "FORUMS")

			DataSet1.Relations.Add("CategoryRelation", DataSet1.Tables("CATEGORIES").Columns("CATEGORY_ID"), DataSet1.Tables("FORUMS").Columns("CATEGORY_ID"))

			Dim CategoryCount as Integer = Dataset1.Tables("CATEGORIES").Rows.Count - 1
			Dim x As Integer
			For x = 0 to CategoryCount
				if (Dataset1.Tables("CATEGORIES").Rows(x).GetChildRows("CategoryRelation").Length = 0) and (Session("UserLevel") <> "3") then
					Dataset1.Tables("CATEGORIES").Rows(x).Delete()
				end if
			Next

			Category.DataSource = DataSet1
			Category.DataBind()
		End Sub

		Sub DisplayStatistics()
			StatsPanel.Visible = "True"
			Dim Reader as OdbcDataReader

			Dim MembersString as String = ""
			Reader = Database.Read("SELECT Count(*) as NumMembers FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1")
			While Reader.Read()
                MembersString = "Hay un total de " & Reader("NumMembers").ToString() & " miembros.&nbsp;&nbsp;"
			End While
			Reader.Close()
			Reader = Database.Read("SELECT Count(*) as NumMembers FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1 AND MEMBER_POSTS > 0")
			While Reader.Read()
				if (Reader("NumMembers") > 0) then
                    MembersString &= Reader("NumMembers").ToString() & " miembros tienen posteado.&nbsp;&nbsp;"
				end if
			End While
			Reader.Close()
			Reader = Database.Read("SELECT Count(*) as NumMembers FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1 AND " & Database.GetDateDiff("dd", "MEMBER_DATE_JOINED", Database.GetTimeStamp()) & " <= 7")
			While Reader.Read()
				if (Reader("NumMembers") > 0) then
                    MembersString &= Reader("NumMembers").ToString() & " miembros se han unido esta semana."
				end if
			End While
			Reader.Close()
			MembersText.text = MembersString

			Reader = Database.Read("SELECT MEMBER_USERNAME, MEMBER_ID, MEMBER_DATE_JOINED FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1 ORDER BY MEMBER_DATE_JOINED DESC", 1)
			While Reader.Read()
                NewMemberText.Text = "Último miembro registrado: <a href=""profile.aspx?ID=" & Reader("MEMBER_ID") & """>" & Reader("MEMBER_USERNAME").ToString() & "</a>, el " & Functions.FormatDate(Reader("MEMBER_DATE_JOINED").ToString(), 1) & "."
			End While
			Reader.Close()

			Dim TopicsString as String
			Dim TopicsNumber, RepliesNumber as Integer
			Reader = Database.Read("SELECT Count(*) as Number FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_CONFIRMED = 1 AND TOPIC_STATUS <> 0")
			While Reader.Read()
				TopicsNumber = Reader("Number")
			End While
			Reader.Close()
			Reader = Database.Read("SELECT Count(*) as Number FROM " & Database.DBPrefix & "_REPLIES")
			While Reader.Read()
				RepliesNumber = Reader("Number")
			End While
			Reader.Close()
            TopicsString = "Hay en total " & TopicsNumber & " temas y " & TopicsNumber + RepliesNumber & " respuestas.&nbsp;&nbsp;"
			Reader = Database.Read("SELECT Count(*) as Number FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_CONFIRMED = 1 AND TOPIC_STATUS <> 0 AND " & Database.GetDateDiff("dd", "TOPIC_DATE", Database.GetTimeStamp()) & " <= 7")
			While Reader.Read()
				if (Reader("Number") > 0) then
                    TopicsString &= Reader("Number").ToString() & " temas han sido publicados esta semana."
				end if
			End While
			Reader.Close()
			TopicsText.text = TopicsString
		End Sub

		Sub EditCategory(sender As Object, e As EventArgs)
			Response.Redirect("editcategory.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub DeleteCategory(sender As Object, e As EventArgs)
			Response.Redirect("deletecategory.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub AddForum(sender As Object, e As EventArgs)
			Response.Redirect("newforum.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub EditForum(sender As Object, e As EventArgs)
			Response.Redirect("editforum.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub DeleteForum(sender As Object, e As EventArgs)
			Response.Redirect("deleteforum.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub NewTopic(sender As Object, e As EventArgs)
			Response.Redirect("newtopic.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub SetSession()
			if Not Request.Cookies("dmgforums") Is Nothing then
				Dim aCookie As New System.Web.HttpCookie("dmgforums")

				Dim UserReader as OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Server.HtmlEncode(Request.Cookies("dmgforums")("mukul")) & " AND MEMBER_PASSWORD = '" & Server.HtmlEncode(Request.Cookies("dmgforums")("gupta")) & "'", 1)
					While(UserReader.Read())
						Session("UserID") = UserReader("MEMBER_ID").ToString()
						Session("UserName") = UserReader("MEMBER_USERNAME").ToString()
						Session("UserLevel") = UserReader("MEMBER_LEVEL").ToString()
						Session("UserLogged") = "1"
						aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
						aCookie.Values("mukul") = UserReader("MEMBER_ID").ToString()
						aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now())
						aCookie.Values("gupta") = UserReader("MEMBER_PASSWORD").ToString()
						aCookie.Expires = DateTime.Now.AddDays(30)
						Response.Cookies.Add(aCookie)
					End While
				UserReader.Close()

				if ((Session("UserLevel") = 0) or (Session("UserLevel") = -1)) then
					aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
					aCookie.Values("mukul") = "-3"
					aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now())
					aCookie.Values("gupta") = Functions.Encrypt(DateTime.Now())
					aCookie.Expires = DateTime.Now.AddDays(-1)
					Response.Cookies.Add(aCookie)
					Session("UserID") = "-1"
					Session("UserName") = ""
					Session("UserLogged") = "0"
					Session("UserLevel") = "0"
				end if
			else
				if (Session("UserLogged") = "1") then
					Dim UserReader as OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Session("UserID"), 1)
						While(UserReader.Read())
							Session("UserID") = UserReader("MEMBER_ID").ToString()
							Session("UserName") = UserReader("MEMBER_USERNAME").ToString()
							Session("UserLevel") = UserReader("MEMBER_LEVEL").ToString()
							Session("UserLogged") = "1"
						End While
					UserReader.Close()

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
	End Class


	'---------------------------------------------------------------------------------------------------
	' ForumHome - Codebehind For ForumHome.aspx
	'---------------------------------------------------------------------------------------------------
	Public Class ForumHome
		Inherits System.Web.UI.Page
	
		Public Category As System.Web.UI.WebControls.Repeater
		Public StatsPanel As System.Web.UI.WebControls.PlaceHolder
		Public CategoryContentPanel As System.Web.UI.WebControls.PlaceHolder
		Public CategoryContent As System.Web.UI.WebControls.Literal
		Public MembersText As System.Web.UI.WebControls.Label
		Public NewMemberText As System.Web.UI.WebControls.Label
		Public TopicsText As System.Web.UI.WebControls.Label

		Public CategoryName as String
		Public CustomCategory as String = "No"

		Public DMGHeader As DMGForums.Global.Header
		Public DMGFooter As DMGForums.Global.Footer
		Public DMGLogin As DMGForums.Global.Login

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
			if Not Page.IsPostBack() then
				Dim DataSet1 as new DataSet()
				Dim strSql as OdbcCommand
				Dim strSql2 as String

				SetSession()

				if (Functions.IsInteger(Request.QueryString("ID"))) then
					strSql2 = " AND CATEGORY_ID = " & Request.Querystring("ID")
					CustomCategory = "Yes"
				else
					strSql2 = ""
					CustomCategory = "No"
				end if

				strSql = new OdbcCommand("SELECT * FROM " & Database.DBPrefix & "_CATEGORIES WHERE CATEGORY_STATUS = 1" & strSql2 & " ORDER BY CATEGORY_SORTBY", Database.DatabaseConnection())

				if CustomCategory = "Yes" then
					Dim CategoryReader as OdbcDataReader = Database.Read("SELECT CATEGORY_NAME, CATEGORY_CONTENT, CATEGORY_SHOWHEADERS, CATEGORY_SHOWLOGIN FROM " & Database.DBPrefix & "_CATEGORIES WHERE CATEGORY_ID = " & Request.Querystring("ID"))
						if CategoryReader.HasRows() then
							While(CategoryReader.Read())
								CategoryName = CategoryReader("CATEGORY_NAME").ToString()
								if (CategoryReader("CATEGORY_CONTENT").ToString().Length() > 0)
									CategoryContent.Text = Functions.CustomHTMLVariables(CategoryReader("CATEGORY_CONTENT").ToString(), Session("UserID"), Session("UserLogged"), Session("UserLevel"))
								else
									CategoryContentPanel.visible = "False"
								end if
								if (CategoryReader("CATEGORY_SHOWHEADERS") <> 1) then
									DMGHeader.visible = "false"
									DMGFooter.visible = "false"
								end if
								DMGLogin.ShowLogin() = CategoryReader("CATEGORY_SHOWLOGIN")
							End While
						else
							Response.Redirect("default.aspx")
						end if
					CategoryReader.close()
				end if

				Dim DataAdapter1 as new OdbcDataAdapter()
				DataAdapter1.SelectCommand = strSql
				DataAdapter1.Fill(DataSet1, "CATEGORIES")

				if (Functions.IsInteger(Request.QueryString("ID"))) then
					strSql2 = " AND F.CATEGORY_ID = " & Request.Querystring("ID")
				else
					strSql2 = ""
				end if

				strSql = new OdbcCommand("SELECT F.FORUM_STATUS, F.CATEGORY_ID, F.FORUM_ID, F.FORUM_NAME, F.FORUM_TYPE, F.FORUM_DESCRIPTION, M.MEMBER_USERNAME, M.MEMBER_ID, F.FORUM_LASTPOST_DATE, F.FORUM_TOPICS, F.FORUM_POSTS FROM (" & Database.DBPrefix & "_CATEGORIES AS C INNER JOIN " & Database.DBPrefix & "_FORUMS AS F ON C.CATEGORY_ID = F.CATEGORY_ID) LEFT JOIN " & Database.DBPrefix & "_MEMBERS AS M ON F.FORUM_LASTPOST_AUTHOR = M.MEMBER_ID WHERE (F.FORUM_STATUS <> 0 AND C.CATEGORY_STATUS = 1" & strSql2 & ") ORDER BY F.FORUM_SORTBY", Database.DatabaseConnection())

				DataAdapter1.SelectCommand = strSql
				DataAdapter1.Fill(DataSet1, "FORUMS")

				DataSet1.Relations.Add("CategoryRelation", DataSet1.Tables("CATEGORIES").Columns("CATEGORY_ID"), DataSet1.Tables("FORUMS").Columns("CATEGORY_ID"))

				Dim CategoryCount as Integer = Dataset1.Tables("CATEGORIES").Rows.Count - 1
				Dim x As Integer
				For x = 0 to CategoryCount
					if (Dataset1.Tables("CATEGORIES").Rows(x).GetChildRows("CategoryRelation").Length = 0) and (Session("UserLevel") <> "3") then
						Dataset1.Tables("CATEGORIES").Rows(x).Delete()
					end if
				Next

				Category.DataSource = DataSet1
				Category.DataBind()

				if (Settings.ShowStatistics = 1) then
					DisplayStatistics()
				end if
			end if
		End Sub

        Sub DisplayStatistics()
            StatsPanel.Visible = "True"
            Dim Reader As OdbcDataReader

            Dim MembersString As String = ""
            Reader = Database.Read("SELECT Count(*) as NumMembers FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1")
            While Reader.Read()
                MembersString = "Hay un total de " & Reader("NumMembers").ToString() & " miembros.&nbsp;&nbsp;"
            End While
            Reader.Close()
            Reader = Database.Read("SELECT Count(*) as NumMembers FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1 AND MEMBER_POSTS > 0")
            While Reader.Read()
                If (Reader("NumMembers") > 0) Then
                    MembersString &= Reader("NumMembers").ToString() & " miembros tienen posteado.&nbsp;&nbsp;"
                End If
            End While
            Reader.Close()
            Reader = Database.Read("SELECT Count(*) as NumMembers FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1 AND " & Database.GetDateDiff("dd", "MEMBER_DATE_JOINED", Database.GetTimeStamp()) & " <= 7")
            While Reader.Read()
                If (Reader("NumMembers") > 0) Then
                    MembersString &= Reader("NumMembers").ToString() & " miembros se han unido esta semana."
                End If
            End While
            Reader.Close()
            MembersText.text = MembersString

            Reader = Database.Read("SELECT MEMBER_USERNAME, MEMBER_ID, MEMBER_DATE_JOINED FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1 ORDER BY MEMBER_DATE_JOINED DESC", 1)
            While Reader.Read()
                NewMemberText.Text = "Último miembro registrado: <a href=""profile.aspx?ID=" & Reader("MEMBER_ID") & """>" & Reader("MEMBER_USERNAME").ToString() & "</a>, el " & Functions.FormatDate(Reader("MEMBER_DATE_JOINED").ToString(), 1) & "."
            End While
            Reader.Close()

            Dim TopicsString As String = ""
            Dim TopicsNumber As Integer = 0
            Dim RepliesNumber As Integer = 0
            Reader = Database.Read("SELECT Count(*) as Number FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_CONFIRMED = 1 AND TOPIC_STATUS <> 0")
            While Reader.Read()
                TopicsNumber = Reader("Number")
            End While
            Reader.Close()
            Reader = Database.Read("SELECT Count(*) as Number FROM " & Database.DBPrefix & "_REPLIES")
            While Reader.Read()
                RepliesNumber = Reader("Number")
            End While
            Reader.Close()
            TopicsString = "Hay en total " & TopicsNumber & " temas y " & TopicsNumber + RepliesNumber & " respuestas.&nbsp;&nbsp;"
            Reader = Database.Read("SELECT Count(*) as Number FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_CONFIRMED = 1 AND TOPIC_STATUS <> 0 AND " & Database.GetDateDiff("dd", "TOPIC_DATE", Database.GetTimeStamp()) & " <= 7")
            While Reader.Read()
                If (Reader("Number") > 0) Then
                    TopicsString &= Reader("Number").ToString() & " temas han sido publicados esta semana."
                End If
            End While
            Reader.Close()
            TopicsText.text = TopicsString
        End Sub

		Sub EditCategory(sender As Object, e As EventArgs)
			Response.Redirect("editcategory.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub DeleteCategory(sender As Object, e As EventArgs)
			Response.Redirect("deletecategory.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub AddForum(sender As Object, e As EventArgs)
			Response.Redirect("newforum.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub EditForum(sender As Object, e As EventArgs)
			Response.Redirect("editforum.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub DeleteForum(sender As Object, e As EventArgs)
			Response.Redirect("deleteforum.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub NewTopic(sender As Object, e As EventArgs)
			Response.Redirect("newtopic.aspx?ID=" & sender.CommandArgument)
		End Sub

		Sub SetSession()
			if Not Request.Cookies("dmgforums") Is Nothing then
				Dim aCookie As New System.Web.HttpCookie("dmgforums")

				Dim UserReader as OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Server.HtmlEncode(Request.Cookies("dmgforums")("mukul")) & " AND MEMBER_PASSWORD = '" & Server.HtmlEncode(Request.Cookies("dmgforums")("gupta")) & "'", 1)
					While(UserReader.Read())
						Session("UserID") = UserReader("MEMBER_ID").ToString()
						Session("UserName") = UserReader("MEMBER_USERNAME").ToString()
						Session("UserLevel") = UserReader("MEMBER_LEVEL").ToString()
						Session("UserLogged") = "1"
						aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
						aCookie.Values("mukul") = UserReader("MEMBER_ID").ToString()
						aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now())
						aCookie.Values("gupta") = UserReader("MEMBER_PASSWORD").ToString()
						aCookie.Expires = DateTime.Now.AddDays(30)
						Response.Cookies.Add(aCookie)
					End While
				UserReader.Close()

				if ((Session("UserLevel") = 0) or (Session("UserLevel") = -1)) then
					aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
					aCookie.Values("mukul") = "-3"
					aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now())
					aCookie.Values("gupta") = Functions.Encrypt(DateTime.Now())
					aCookie.Expires = DateTime.Now.AddDays(-1)
					Response.Cookies.Add(aCookie)
					Session("UserID") = "-1"
					Session("UserName") = ""
					Session("UserLogged") = "0"
					Session("UserLevel") = "0"
				end if
			else
				if (Session("UserLogged") = "1") then
					Dim UserReader as OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Session("UserID"), 1)
						While(UserReader.Read())
							Session("UserID") = UserReader("MEMBER_ID").ToString()
							Session("UserName") = UserReader("MEMBER_USERNAME").ToString()
							Session("UserLevel") = UserReader("MEMBER_LEVEL").ToString()
							Session("UserLogged") = "1"
						End While
					UserReader.Close()

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
	End Class


	'---------------------------------------------------------------------------------------------------
	' PageContent - Codebehind For page.aspx
	'---------------------------------------------------------------------------------------------------
	Public Class PageContent
		Inherits System.Web.UI.Page

		Public PageTitle As System.Web.UI.WebControls.Label
		Public PageContent As System.Web.UI.WebControls.Label
		Public SubCategories As System.Web.UI.WebControls.DataList
		Public PasswordPanel As System.Web.UI.WebControls.Panel
		Public PasswordBox As System.Web.UI.WebControls.TextBox
		Public SubTitleText as String
		Public PagePhoto As System.Web.UI.WebControls.Label
		Public PagePanel As System.Web.UI.WebControls.Panel
		Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

		Public DMGHeader As DMGForums.Global.Header
		Public DMGFooter As DMGForums.Global.Footer
		Public DMGLogin As DMGForums.Global.Login
		Public DMGSettings As DMGForums.Global.Settings

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
			if Not Page.IsPostBack() then
				SetSession()

				Dim PageID as String = "1"
				Dim SubTitle as String = ""
				Dim SubShowTitle as Integer = 0
				Dim SubColumns as Integer = 1
				Dim SubAlign as Integer = 1
				Dim SubStatus as Integer = 1

				if (Functions.IsInteger(Request.QueryString("ID"))) then
					PageID = Request.QueryString("ID")
				else
					Response.Redirect("default.aspx")
				end if

				Dim PageReader as OdbcDataReader = Database.Read("SELECT PAGE_ID, PAGE_TITLE, PAGE_CONTENT, PAGE_SHOWTITLE, PAGE_AUTOFORMAT, PAGE_STATUS, PAGE_SHOWHEADERS, PAGE_SHOWLOGIN, PAGE_SECURITY, PAGE_SUB_TITLE, PAGE_SUB_SHOWTITLE, PAGE_SUB_COLUMNS, PAGE_SUB_ALIGN, PAGE_SUB_STATUS, PAGE_PHOTO FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & PageID, 1)
				if (PageReader.HasRows()) then
					While PageReader.Read()
						if (PageReader("PAGE_STATUS") = 1) then
							Dim Spacer as String = ""
							DMGSettings.CustomTitle = PageReader("PAGE_TITLE").ToString()
							if (PageReader("PAGE_SHOWTITLE") = 1) then
								PageTitle.Text = PageReader("PAGE_TITLE").ToString()
								Spacer = "<br /><br clear=""all"" />"
							else
								PageTitle.visible = "false"
							end if
							if (PageReader("PAGE_SHOWHEADERS") <> 1) then
								DMGHeader.visible = "false"
								DMGFooter.visible = "false"
							end if
							DMGLogin.ShowLogin() = PageReader("PAGE_SHOWLOGIN")
							if (PageReader("PAGE_CONTENT").ToString() <> "") then
								PageContent.Text = Functions.CustomHTMLVariables(Spacer & PageReader("PAGE_CONTENT").ToString(), Session("UserID"), Session("UserLogged"), Session("UserLevel"))
								if (PageReader("PAGE_AUTOFORMAT") = 1) then
									PageContent.Text = Functions.FormatString(PageContent.Text)
								end if
							end if

							if ((PageReader("PAGE_SECURITY") = 1) or (PageReader("PAGE_SECURITY") = 3) or (PageReader("PAGE_SECURITY") = 4)) then
								if Not Functions.IsPagePrivileged(PageReader("PAGE_ID"), PageReader("PAGE_SECURITY"), Session("UserID"), Session("UserLevel"), Session("UserLogged")) then
									PagePanel.visible = "false"
									NoItemsDiv.InnerHtml = "You Do Not Have Access To This Page<br /><br />"
								end if
							elseif (PageReader("PAGE_SECURITY") = 2) then
								if (Session("PAGE_" & PageReader("PAGE_ID")) <> "logged") then
									PagePanel.visible = "false"
									PasswordPanel.visible = "true"
								end if
							end if

							if (PageReader("PAGE_PHOTO") <> "") then
								PagePhoto.Text = "<img src=""pageimages/" & PageReader("PAGE_PHOTO").ToString() & """><br /><br />"
							end if

							SubStatus = PageReader("PAGE_SUB_STATUS")
							if (SubStatus = 1) then
								if (PageReader("PAGE_SUB_SHOWTITLE") = 1) then
									SubShowTitle = 1
									SubTitle = PageReader("PAGE_SUB_TITLE").ToString()
								end if								
								if (Functions.IsInteger(PageReader("PAGE_SUB_COLUMNS"))) then
									SubColumns = PageReader("PAGE_SUB_COLUMNS")
								end if
								SubAlign = PageReader("PAGE_SUB_ALIGN")
							end if
						else
							PagePanel.visible = "false"
                            NoItemsDiv.InnerHtml = "This Page Is Currently Not Available<br /><br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page<br /><br />"
                        End If
                    End While
                Else
                    Response.Redirect("default.aspx")
                End If
                PageReader.Close()

                SubCategories.DataSource = Database.Read("SELECT PAGE_ID, PAGE_NAME, PAGE_THUMBNAIL FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_PARENT = " & PageID & " AND PAGE_STATUS = 1 ORDER BY PAGE_SORT ASC, PAGE_NAME")
                SubCategories.DataBind()
                If ((SubCategories.Items.Count = 0) Or (SubStatus = 0)) Then
                    SubCategories.Visible = "false"
                Else
                    If (SubShowTitle = 1) Then
                        SubTitleText = "<br clear=""all"" /><br />" & SubTitle
                        If (SubColumns > 1) Then
                            SubCategories.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                            SubCategories.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                        End If
                    End If
                    SubCategories.RepeatColumns = SubColumns
                    If (SubAlign = 2) Then
                        SubCategories.Attributes("align") = "Center"
                    ElseIf (SubAlign = 3) Then
                        SubCategories.Attributes("align") = "Right"
                    Else
                        SubCategories.Attributes("align") = "Left"
                    End If
                End If
                SubCategories.DataSource.Close()
            End If
        End Sub

        Sub ApplyPagePassword(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim thePassword As String = Functions.RepairString(PasswordBox.Text)
            thePassword = Functions.Encrypt(thePassword)
            Dim PasswordReader As OdbcDataReader = Database.Read("SELECT PAGE_ID FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_PASSWORD = '" & thePassword & "' AND PAGE_ID = " & Request.QueryString("ID"))
            If PasswordReader.HasRows Then
                Session("PAGE_" & Request.QueryString("ID")) = "logged"
                Response.Redirect(Page.ResolveUrl(Request.Url.ToString()))
            Else
                PasswordPanel.Visible = "false"
                PagePanel.Visible = "false"
                NoItemsDiv.InnerHtml = "Incorrect Password<br /><br />"
            End If
            PasswordReader.Close()
        End Sub

        Sub SetSession()
            If Not Request.Cookies("dmgforums") Is Nothing Then
                Dim aCookie As New System.Web.HttpCookie("dmgforums")

                Dim UserReader As OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Server.HtmlEncode(Request.Cookies("dmgforums")("mukul")) & " AND MEMBER_PASSWORD = '" & Server.HtmlEncode(Request.Cookies("dmgforums")("gupta")) & "'", 1)
                While (UserReader.Read())
                    Session("UserID") = UserReader("MEMBER_ID").ToString()
                    Session("UserName") = UserReader("MEMBER_USERNAME").ToString()
                    Session("UserLevel") = UserReader("MEMBER_LEVEL").ToString()
                    Session("UserLogged") = "1"
                    aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
                    aCookie.Values("mukul") = UserReader("MEMBER_ID").ToString()
                    aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now())
                    aCookie.Values("gupta") = UserReader("MEMBER_PASSWORD").ToString()
                    aCookie.Expires = DateTime.Now.AddDays(30)
                    Response.Cookies.Add(aCookie)
                End While
                UserReader.Close()

                If ((Session("UserLevel") = 0) Or (Session("UserLevel") = -1)) Then
                    aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
                    aCookie.Values("mukul") = "-3"
                    aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now())
                    aCookie.Values("gupta") = Functions.Encrypt(DateTime.Now())
                    aCookie.Expires = DateTime.Now.AddDays(-1)
                    Response.Cookies.Add(aCookie)
                    Session("UserID") = "-1"
                    Session("UserName") = ""
                    Session("UserLogged") = "0"
                    Session("UserLevel") = "0"
                End If
            Else
                If (Session("UserLogged") = "1") Then
                    Dim UserReader As OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Session("UserID"), 1)
                    While (UserReader.Read())
                        Session("UserID") = UserReader("MEMBER_ID").ToString()
                        Session("UserName") = UserReader("MEMBER_USERNAME").ToString()
                        Session("UserLevel") = UserReader("MEMBER_LEVEL").ToString()
                        Session("UserLogged") = "1"
                    End While
                    UserReader.Close()

                    If ((Session("UserLevel") = 0) Or (Session("UserLevel") = -1)) Then
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
                    End If
                Else
                    Session("UserID") = "-1"
                    Session("UserName") = ""
                    Session("UserLogged") = "0"
                    Session("UserLevel") = "0"
                End If
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' NewPage - Codebehind For newpage.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class NewPage
        Inherits System.Web.UI.Page

        Public txtPageName As System.Web.UI.WebControls.TextBox
        Public txtPageParent As System.Web.UI.WebControls.DropDownList
        Public txtPageTitle As System.Web.UI.WebControls.TextBox
        Public txtPageContent As System.Web.UI.WebControls.TextBox
        Public txtSortBy As System.Web.UI.WebControls.TextBox
        Public txtAddToMainMenu As System.Web.UI.WebControls.DropDownList
        Public txtShowHeaders As System.Web.UI.WebControls.DropDownList
        Public txtShowLogin As System.Web.UI.WebControls.DropDownList
        Public txtShowTitle As System.Web.UI.WebControls.DropDownList
        Public txtAutoFormat As System.Web.UI.WebControls.DropDownList
        Public txtStatus As System.Web.UI.WebControls.DropDownList
        Public txtPassword As System.Web.UI.WebControls.TextBox
        Public AllowedUsersPanel As System.Web.UI.WebControls.PlaceHolder
        Public PasswordPanel As System.Web.UI.WebControls.PlaceHolder
        Public txtSecurity As System.Web.UI.WebControls.DropDownList
        Public txtMembers As System.Web.UI.WebControls.ListBox
        Public txtAllowedMembers As System.Web.UI.WebControls.ListBox
        Public txtSubTitle As System.Web.UI.WebControls.TextBox
        Public txtSubShowTitle As System.Web.UI.WebControls.DropDownList
        Public txtSubColumns As System.Web.UI.WebControls.TextBox
        Public txtSubAlign As System.Web.UI.WebControls.DropDownList
        Public txtSubStatus As System.Web.UI.WebControls.DropDownList
        Public PagePanel As System.Web.UI.WebControls.Panel
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If (Session("UserLevel") <> "3") Then
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "Access Denied<br /><br />"
                Else
                    Dim LItem As New ListItem("No Parent", "0")
                    txtPageParent.Items.Add(LItem)
                    LItem = New ListItem("---------------", "0")
                    txtPageParent.Items.Add(LItem)

                    Dim Parent As Integer = 0

                    Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_ID, PAGE_NAME, PAGE_PARENT FROM " & Database.DBPrefix & "_PAGES ORDER BY PAGE_PARENT, PAGE_SORT ASC, PAGE_NAME")
                    While Reader.Read()
                        If (Reader("PAGE_PARENT") <> Parent) Then
                            Parent = Reader("PAGE_PARENT")
                            LItem = New ListItem("---------------", Parent)
                            txtPageParent.Items.Add(LItem)
                        End If
                        LItem = New ListItem(Reader("PAGE_NAME").ToString(), Reader("PAGE_ID"))
                        txtPageParent.Items.Add(LItem)
                    End While
                    Reader.Close()

                    txtMembers.DataSource = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> 0")
                    txtMembers.DataBind()
                    txtMembers.DataSource.Close()

                    If (Settings.HideLogin = 1) Then
                        txtShowLogin.SelectedValue = 0
                    Else
                        txtShowLogin.SelectedValue = 1
                    End If
                End If
            End If
        End Sub

        Sub SecurityChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Select Case (CType(sender.SelectedIndex, Integer))
                Case 1
                    AllowedUsersPanel.Visible = "true"
                    PasswordPanel.Visible = "false"
                Case 2
                    PasswordPanel.Visible = "true"
                    AllowedUsersPanel.Visible = "false"
                Case Else
                    AllowedUsersPanel.Visible = "false"
                    PasswordPanel.Visible = "false"
            End Select
        End Sub

        Sub AddMember(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Functions.IsInteger(txtMembers.SelectedValue) Then
                Dim LItem As New ListItem(txtMembers.SelectedItem.Text, txtMembers.SelectedValue)
                txtAllowedMembers.Items.Add(LItem)
                txtMembers.Items.Remove(LItem)
            Else
                Functions.MessageBox("No Item Selected")
            End If
        End Sub

        Sub RemoveMember(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Functions.IsInteger(txtAllowedMembers.SelectedValue) Then
                Dim LItem As New ListItem(txtAllowedMembers.SelectedItem.Text, txtAllowedMembers.SelectedValue)
                txtAllowedMembers.Items.Remove(LItem)
                txtMembers.Items.Add(LItem)
            Else
                Functions.MessageBox("No Item Selected")
            End If
        End Sub

        Sub SubmitPage(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim Failure As Integer = 0

            If (txtPageName.Text = "") Or (txtPageName.Text = " ") Then
                Failure = 1
                Functions.MessageBox("No Name Entered!")
            End If

            If Failure = 0 Then
                PagePanel.Visible = "false"

                Dim PageName As String = Functions.RepairString(txtPageName.Text, 0)
                Dim PageParent As String = CLng(txtPageParent.SelectedValue)
                Dim PageTitle As String = Functions.RepairString(txtPageTitle.Text, 0)
                Dim PageContent As String = Functions.RepairString(txtPageContent.Text, 0)
                Dim PageShowHeaders As String = CLng(txtShowHeaders.SelectedValue)
                Dim PageShowLogin As String = CLng(txtShowLogin.SelectedValue)
                Dim PageShowTitle As String = CLng(txtShowTitle.SelectedValue)
                Dim PageAutoFormat As String = CLng(txtAutoFormat.SelectedValue)
                Dim PageStatus As String = CLng(txtStatus.SelectedValue)
                Dim PageSortBy As String = "1"
                Dim PageSecurity As String = CLng(txtSecurity.SelectedValue)
                Dim PagePassword As String = ""
                Dim PageSubTitle As String = Functions.RepairString(txtSubTitle.Text, 0)
                Dim PageSubShowTitle As String = CLng(txtSubShowTitle.SelectedValue)
                Dim PageSubColumns As String = "1"
                Dim PageSubAlign As String = CLng(txtSubAlign.SelectedValue)
                Dim PageSubStatus As String = CLng(txtSubStatus.SelectedValue)

                If (Functions.IsInteger(txtSortBy.Text)) Then
                    PageSortBy = CLng(txtSortBy.Text)
                End If

                If (Functions.IsInteger(txtSubColumns.Text)) Then
                    PageSubColumns = CLng(txtSubColumns.Text)
                End If

                If (PageSecurity = "2") Then
                    PagePassword = Functions.Encrypt(txtPassword.Text)
                End If

                Dim PageThumbnail As String = ""
                If (Not Application("PageThumbnail") Is Nothing) And (Application("PageThumbnail") <> "") Then
                    PageThumbnail = Application("PageThumbnail")
                End If

                Dim PagePhoto As String = ""
                If (Not Application("PagePhoto") Is Nothing) And (Application("PagePhoto") <> "") Then
                    PagePhoto = Application("PagePhoto")
                End If

                Database.Write("INSERT INTO " & Database.DBPrefix & "_PAGES (PAGE_NAME, PAGE_PARENT, PAGE_TITLE, PAGE_CONTENT, PAGE_SHOWTITLE, PAGE_STATUS, PAGE_SORT, PAGE_SHOWHEADERS, PAGE_SHOWLOGIN, PAGE_AUTOFORMAT, PAGE_SECURITY, PAGE_PASSWORD, PAGE_SUB_TITLE, PAGE_SUB_SHOWTITLE, PAGE_SUB_COLUMNS, PAGE_SUB_ALIGN, PAGE_SUB_STATUS, PAGE_THUMBNAIL, PAGE_PHOTO) VALUES ('" & PageName & "', " & PageParent & ", '" & PageTitle & "', '" & PageContent & "', " & PageShowTitle & ", " & PageStatus & ", " & PageSortBy & ", " & PageShowHeaders & ", " & PageShowLogin & ", " & PageAutoFormat & ", " & PageSecurity & ", '" & PagePassword & "', '" & PageSubTitle & "', " & PageSubShowTitle & ", " & PageSubColumns & ", " & PageSubAlign & ", " & PageSubStatus & ", '" & PageThumbnail & "', '" & PagePhoto & "')")

                Dim NewPageID As Integer = 0
                Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_ID FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_NAME = '" & PageName & "' ORDER BY PAGE_ID DESC", 1)
                While Reader.Read()
                    NewPageID = Reader("PAGE_ID")
                End While
                Reader.Close()

                If (PageSecurity = 1) Then
                    Dim Count As Integer
                    For Count = 0 To (txtAllowedMembers.Items.Count - 1)
                        Database.Write("INSERT INTO " & Database.DBPrefix & "_PAGES_PRIVILEGED (MEMBER_ID, PAGE_ID, PRIVILEGED_ACCESS) VALUES (" & txtAllowedMembers.Items.Item(Count).Value.ToString() & ", " & NewPageID & ", 1)")
                    Next
                End If

                If (txtAddToMainMenu.SelectedValue = "1") Then
                    Dim NewLinkOrder As Integer = 1
                    Dim Reader2 As OdbcDataReader = Database.Read("SELECT LINK_ID, LINK_ORDER, LINK_TYPE FROM " & Database.DBPrefix & "_MAIN_MENU ORDER BY LINK_ORDER DESC", 1)
                    While Reader2.Read()
                        If (Reader2("LINK_TYPE") = 13) Then
                            NewLinkOrder = Reader2("LINK_ORDER")
                            Database.Write("UPDATE " & Database.DBPrefix & "_MAIN_MENU SET LINK_ORDER = " & Reader2("LINK_ORDER") + 1 & " WHERE LINK_ID = " & Reader2("LINK_ID"))
                        Else
                            NewLinkOrder = Reader2("LINK_ORDER") + 1
                        End If
                    End While
                    Reader2.Close()

                    Database.Write("INSERT INTO " & Database.DBPrefix & "_MAIN_MENU (LINK_ORDER, LINK_TEXT, LINK_TYPE, LINK_PARAMETER, LINK_WINDOW) VALUES (" & NewLinkOrder & ", '" & PageName & "', 2, '" & NewPageID & "', 0)")

                    NoItemsDiv.InnerHtml = "Página creada con éxito (Page ID = " & NewPageID & ")<br /><br />From The Admin Screen, Click ""Main Menu Configuration"" To Change The Menu Order<br /><br /><a href=""admin.aspx"">Click Aquí</a> To Return To The Admin Screen<br /><br />"
                Else
                    NoItemsDiv.InnerHtml = "Página creada con éxito (Page ID = " & NewPageID & ")<br /><br /><a href=""admin.aspx"">Click Aquí</a> To Return To The Admin Screen<br /><br />"
                End If
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' EditPages - Codebehind For editpages.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class EditPages
        Inherits System.Web.UI.Page

        Public CategoryList As System.Web.UI.WebControls.Repeater
        Public EditCatButton As System.Web.UI.WebControls.Button
        Public DeleteCatButton As System.Web.UI.WebControls.Button
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If (Session("UserLogged") = "1") And (Session("UserLevel") = "3") Then
                    Dim WhereString As String = ""
                    If (Request.QueryString("ID") = 0) Then
                        WhereString = "WHERE (PAGE_PARENT = 0) OR (PAGE_PARENT = -1)"
                    Else
                        WhereString = "WHERE PAGE_PARENT = " & Request.QueryString("ID")
                    End If
                    CategoryList.DataSource = Database.Read("SELECT PAGE_ID, PAGE_NAME, PAGE_STATUS FROM " & Database.DBPrefix & "_PAGES " & WhereString & " ORDER BY PAGE_SORT, PAGE_NAME")
                    CategoryList.DataBind()
                    If (CategoryList.Items.Count = 0) Then
                        CategoryList.Visible = "false"
                        NoItemsDiv.InnerHtml = "<br /><br />There Are No Sub-Categories<br /><br /><a href=""javascript:history.back();"">Click Aquí</a> To Go Back<br /><br />"
                    End If
                    CategoryList.DataSource.Close()
                Else
                    Response.Redirect("admin.aspx")
                End If
            End If
        End Sub

        Public Sub EditCategory(ByVal sender As Object, ByVal e As EventArgs)
            Response.Redirect("editpageform.aspx?ID=" & sender.CommandArgument)
        End Sub

        Public Sub DeleteCategory(ByVal sender As Object, ByVal e As EventArgs)
            Response.Redirect("deletepage.aspx?ID=" & sender.CommandArgument)
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' EditPageForm - Codebehind For editpageform.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class EditPageForm
        Inherits System.Web.UI.Page

        Public txtPageID As System.Web.UI.WebControls.TextBox
        Public txtName As System.Web.UI.WebControls.TextBox
        Public txtParent As System.Web.UI.WebControls.DropDownList
        Public txtTitle As System.Web.UI.WebControls.TextBox
        Public txtContent As System.Web.UI.WebControls.TextBox
        Public txtSortBy As System.Web.UI.WebControls.TextBox
        Public txtShowTitle As System.Web.UI.WebControls.DropDownList
        Public txtShowHeaders As System.Web.UI.WebControls.DropDownList
        Public txtShowLogin As System.Web.UI.WebControls.DropDownList
        Public txtAutoFormat As System.Web.UI.WebControls.DropDownList
        Public txtStatus As System.Web.UI.WebControls.DropDownList
        Public txtPassword As System.Web.UI.WebControls.TextBox
        Public AllowedUsersPanel As System.Web.UI.WebControls.PlaceHolder
        Public PasswordPanel As System.Web.UI.WebControls.PlaceHolder
        Public txtSecurity As System.Web.UI.WebControls.DropDownList
        Public txtMembers As System.Web.UI.WebControls.ListBox
        Public txtAllowedMembers As System.Web.UI.WebControls.ListBox
        Public txtSubTitle As System.Web.UI.WebControls.TextBox
        Public txtSubShowTitle As System.Web.UI.WebControls.DropDownList
        Public txtSubColumns As System.Web.UI.WebControls.TextBox
        Public txtSubAlign As System.Web.UI.WebControls.DropDownList
        Public txtSubStatus As System.Web.UI.WebControls.DropDownList
        Public PagePanel As System.Web.UI.WebControls.Panel
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If (Session("UserLevel") <> "3") Or (Not Functions.IsInteger(Request.QueryString("ID"))) Then
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "Access Denied<br /><br />"
                Else
                    Dim LItem As New ListItem("No Parent", "0")
                    txtParent.Items.Add(LItem)
                    LItem = New ListItem("---------------", "0")
                    txtParent.Items.Add(LItem)

                    Dim Parent As Integer = 0

                    Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_ID, PAGE_NAME, PAGE_PARENT FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID <> " & Request.QueryString("ID") & " ORDER BY PAGE_PARENT, PAGE_SORT ASC, PAGE_NAME")
                    While Reader.Read()
                        If (Reader("PAGE_PARENT") <> Parent) Then
                            Parent = Reader("PAGE_PARENT")
                            LItem = New ListItem("---------------", Parent)
                            txtParent.Items.Add(LItem)
                        End If
                        LItem = New ListItem(Reader("PAGE_NAME").ToString(), Reader("PAGE_ID"))
                        txtParent.Items.Add(LItem)
                    End While
                    Reader.Close()

                    Dim PageReader As OdbcDataReader = Database.Read("SELECT * FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & Request.QueryString("ID"))
                    While (PageReader.Read())
                        txtPageID.Text = PageReader("PAGE_ID").ToString()
                        txtName.Text = PageReader("PAGE_NAME").ToString()
                        txtTitle.Text = PageReader("PAGE_TITLE").ToString()
                        txtContent.Text = PageReader("PAGE_CONTENT").ToString()
                        txtSortBy.Text = PageReader("PAGE_SORT")
                        txtParent.Items.FindByValue(PageReader("PAGE_PARENT").ToString()).Selected = "True"
                        txtStatus.Items.FindByValue(PageReader("PAGE_STATUS").ToString()).Selected = "True"
                        txtAutoFormat.Items.FindByValue(PageReader("PAGE_AUTOFORMAT").ToString()).Selected = "True"
                        txtShowTitle.Items.FindByValue(PageReader("PAGE_SHOWTITLE").ToString()).Selected = "True"
                        txtShowHeaders.Items.FindByValue(PageReader("PAGE_SHOWHEADERS").ToString()).Selected = "True"
                        txtShowLogin.Items.FindByValue(PageReader("PAGE_SHOWLOGIN").ToString()).Selected = "True"
                        txtSecurity.Items.FindByValue(PageReader("PAGE_SECURITY").ToString()).Selected = "True"
                        If PageReader("PAGE_SECURITY") = 1 Then
                            AllowedUsersPanel.Visible = "true"
                            PasswordPanel.Visible = "false"
                        ElseIf PageReader("PAGE_SECURITY") = 2 Then
                            AllowedUsersPanel.Visible = "false"
                            PasswordPanel.Visible = "true"
                        End If
                        txtSubTitle.Text = PageReader("PAGE_SUB_TITLE").ToString()
                        txtSubShowTitle.Items.FindByValue(PageReader("PAGE_SUB_SHOWTITLE").ToString()).Selected = "True"
                        txtSubColumns.Text = PageReader("PAGE_SUB_COLUMNS")
                        txtSubAlign.Items.FindByValue(PageReader("PAGE_SUB_ALIGN").ToString()).Selected = "True"
                        txtSubStatus.Items.FindByValue(PageReader("PAGE_SUB_STATUS").ToString()).Selected = "True"
                    End While
                    PageReader.Close()

                    txtPageID.Enabled = "false"

                    If (Request.QueryString("ID") = 1) Then
                        txtStatus.Enabled = "false"
                        txtName.Enabled = "false"
                        txtParent.Enabled = "false"
                    End If

                    Dim PrivilegedReader As OdbcDataReader = Database.Read("SELECT MEMBER_ID FROM " & Database.DBPrefix & "_PAGES_PRIVILEGED WHERE PAGE_ID = " & Request.QueryString("ID") & " AND PRIVILEGED_ACCESS = 1")
                    Dim SelectedMembers As String = ""
                    While PrivilegedReader.Read()
                        If SelectedMembers = "" Then
                            SelectedMembers &= PrivilegedReader("MEMBER_ID")
                        Else
                            SelectedMembers &= "', '" & PrivilegedReader("MEMBER_ID")
                        End If
                    End While
                    PrivilegedReader.Close()
                    txtMembers.DataSource = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> 0 AND MEMBER_ID NOT IN ('" & SelectedMembers & "')")
                    txtMembers.DataBind()
                    txtMembers.DataSource.Close()
                    txtAllowedMembers.DataSource = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> 0 AND MEMBER_ID IN ('" & SelectedMembers & "')")
                    txtAllowedMembers.DataBind()
                    txtAllowedMembers.DataSource.Close()
                End If
            End If
        End Sub

        Sub SecurityChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Select Case (CType(sender.SelectedIndex, Integer))
                Case 1

                    AllowedUsersPanel.Visible = "true"
                    PasswordPanel.Visible = "false"
                Case 2
                    PasswordPanel.Visible = "true"
                    AllowedUsersPanel.Visible = "false"
                Case Else
                    AllowedUsersPanel.Visible = "false"
                    PasswordPanel.Visible = "false"
            End Select
        End Sub

        Sub AddMember(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Functions.IsInteger(txtMembers.SelectedValue) Then
                Dim LItem As New ListItem(txtMembers.SelectedItem.Text, txtMembers.SelectedValue)
                txtAllowedMembers.Items.Add(LItem)
                txtMembers.Items.Remove(LItem)
            Else
                Functions.MessageBox("No Item Selected")
            End If
        End Sub

        Sub RemoveMember(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Functions.IsInteger(txtAllowedMembers.SelectedValue) Then
                Dim LItem As New ListItem(txtAllowedMembers.SelectedItem.Text, txtAllowedMembers.SelectedValue)
                txtAllowedMembers.Items.Remove(LItem)
                txtMembers.Items.Add(LItem)
            Else
                Functions.MessageBox("No Item Selected")
            End If
        End Sub

        Sub EditPage(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim Failure As Integer = 0

            If (txtName.Text = "") Or (txtName.Text = " ") Then
                Failure = 1
                Functions.MessageBox("No Name Entered!")
            End If

            If Failure = 0 Then
                PagePanel.Visible = "false"

                Dim PageName, PageParent, PageTitle, PageContent, PageShowTitle, PageAutoFormat, PageStatus, PageSortBy, PageShowHeaders, PageShowLogin, PageSubTitle, PageSubShowTitle, PageSubColumns, PageSubAlign, PageSubStatus As String
                Dim PageSecurity As String = CLng(txtSecurity.SelectedValue)
                Dim PagePassword As String = ""

                If (PageSecurity = "2") Then
                    PagePassword = Functions.Encrypt(txtPassword.Text)
                End If

                If (Request.QueryString("ID") = 1) Then
                    PageName = "Main Page"
                    PageParent = "0"
                    PageStatus = "1"
                Else
                    PageName = Functions.RepairString(txtName.Text, 0)
                    PageParent = CLng(txtParent.SelectedValue)
                    PageStatus = CLng(txtStatus.SelectedValue)
                End If

                PageTitle = Functions.RepairString(txtTitle.Text, 0)
                PageContent = Functions.RepairString(txtContent.Text, 0)
                PageShowTitle = CLng(txtShowTitle.SelectedValue)
                PageAutoFormat = CLng(txtAutoFormat.SelectedValue)
                PageShowHeaders = CLng(txtShowHeaders.SelectedValue)
                PageShowLogin = CLng(txtShowLogin.SelectedValue)
                If (Functions.IsInteger(txtSortBy.Text)) Then
                    PageSortBy = CLng(txtSortBy.Text)
                Else
                    PageSortBy = "1"
                End If

                PageSubTitle = Functions.RepairString(txtSubTitle.Text, 0)
                PageSubShowTitle = CLng(txtSubShowTitle.SelectedValue)
                If (Functions.IsInteger(txtSubColumns.Text)) Then
                    PageSubColumns = CLng(txtSubColumns.Text)
                Else
                    PageSubColumns = "1"
                End If
                PageSubAlign = CLng(txtSubAlign.SelectedValue)
                PageSubStatus = CLng(txtSubStatus.SelectedValue)

                Database.Write("UPDATE " & Database.DBPrefix & "_PAGES SET PAGE_NAME = '" & PageName & "', PAGE_PARENT = " & PageParent & ", PAGE_TITLE = '" & PageTitle & "', PAGE_CONTENT = '" & PageContent & "', PAGE_SHOWTITLE = " & PageShowTitle & ", PAGE_STATUS = " & PageStatus & ", PAGE_SORT = " & PageSortBy & ", PAGE_SHOWHEADERS = " & PageShowHeaders & ", PAGE_SHOWLOGIN = " & PageShowLogin & ", PAGE_AUTOFORMAT = " & PageAutoFormat & ", PAGE_SECURITY = " & PageSecurity & ", PAGE_PASSWORD = '" & PagePassword & "', PAGE_SUB_TITLE = '" & PageSubTitle & "', PAGE_SUB_SHOWTITLE = " & PageSubShowTitle & ", PAGE_SUB_COLUMNS = " & PageSubColumns & ", PAGE_SUB_ALIGN = " & PageSubAlign & ", PAGE_SUB_STATUS = " & PageSubStatus & " WHERE PAGE_ID = " & Request.QueryString("ID"))

                Database.Write("DELETE FROM " & Database.DBPrefix & "_PAGES_PRIVILEGED WHERE PAGE_ID = " & Request.QueryString("ID"))

                If (PageSecurity = 1) Then
                    Dim Count As Integer
                    For Count = 0 To (txtAllowedMembers.Items.Count - 1)
                        Database.Write("INSERT INTO " & Database.DBPrefix & "_PAGES_PRIVILEGED (MEMBER_ID, PAGE_ID, PRIVILEGED_ACCESS) VALUES (" & txtAllowedMembers.Items.Item(Count).Value.ToString() & ", " & Request.QueryString("ID") & ", 1)")
                    Next
                End If

                NoItemsDiv.InnerHtml = "Página actualizada con éxito<br /><br /><a href=""admin.aspx"">Click Aquí</a> To Return To The Admin Screen<br /><br />"
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' PageImages - Codebehind For pageimages.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class PageImages
        Inherits System.Web.UI.Page

        Public ThumbnailFile As System.Web.UI.HtmlControls.HtmlInputFile
        Public PhotoFile As System.Web.UI.HtmlControls.HtmlInputFile
        Public DeleteThumbnailButton As System.Web.UI.WebControls.Button
        Public DeletePhotoButton As System.Web.UI.WebControls.Button
        Public ProductImagesMain As System.Web.UI.WebControls.PlaceHolder
        Public ThumbnailForm As System.Web.UI.WebControls.PlaceHolder
        Public PhotoForm As System.Web.UI.WebControls.PlaceHolder
        Public Message As System.Web.UI.WebControls.Label
        Public PagePanel As System.Web.UI.WebControls.PlaceHolder
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If ((Session("UserLevel") <> "3") And (Functions.IsInteger(Request.QueryString("ID")))) Then
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "Access Denied<br /><br />"
                Else
                    ProductImagesMain.Visible = "true"
                    Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_THUMBNAIL, PAGE_PHOTO FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & Request.QueryString("ID"))
                    While Reader.Read()
                        If ((Reader("PAGE_THUMBNAIL").ToString()).Length > 3) Then
                            DeleteThumbnailButton.Visible = "true"
                        End If
                        If ((Reader("PAGE_PHOTO").ToString()).Length > 3) Then
                            DeletePhotoButton.Visible = "true"
                        End If
                    End While
                    Reader.Close()
                End If
            Else

            End If
        End Sub

        Sub OpenThumbnailForm(ByVal sender As System.Object, ByVal e As System.EventArgs)
            ProductImagesMain.Visible = "false"
            ThumbnailForm.Visible = "true"
        End Sub

        Sub UploadThumbnail(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim thefile As HttpPostedFile = ThumbnailFile.PostedFile
            Dim FileName As String = System.IO.Path.GetFileName(thefile.FileName)
            FileName = "s_" & FileName

            If Session("UserLevel") = "3" Then
                If (IsImage(thefile)) Then
                    Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_THUMBNAIL FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & Request.QueryString("ID"))
                    While Reader.Read()
                        If Reader("PAGE_THUMBNAIL").ToString() <> "" Then
                            Database.Write("DELETE " & Database.DBPrefix & "_FILES FROM " & Database.DBPrefix & "_FILES, " & Database.DBPrefix & "_FOLDERS WHERE " & Database.DBPrefix & "_FILES.FILE_FOLDER = " & Database.DBPrefix & "_FOLDERS.FOLDER_ID AND " & Database.DBPrefix & "_FILES.FILE_NAME = '" & Reader("PAGE_THUMBNAIL") & "' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_NAME = 'pageimages' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_PARENT = 0")
                            File.Delete(MapPath("pageimages/" & Reader("PAGE_THUMBNAIL")))
                        End If
                    End While
                    Reader.Close()

                    If (Request.QueryString("ID") = 0) Then
                        Application("PageThumbnail") = FileName
                    Else
                        Database.Write("UPDATE " & Database.DBPrefix & "_PAGES SET PAGE_THUMBNAIL = '" & FileName & "' WHERE PAGE_ID = " & Request.QueryString("ID"))
                    End If

                    Dim FolderID As Integer = 0
                    Reader = Database.Read("SELECT FOLDER_ID FROM " & Database.DBPrefix & "_FOLDERS WHERE FOLDER_NAME = 'pageimages' AND FOLDER_PARENT = 0")
                    While Reader.Read()
                        FolderID = Reader("FOLDER_ID")
                    End While
                    Reader.Close()

                    Reader = Database.Read("SELECT FILE_ID FROM " & Database.DBPrefix & "_FILES WHERE FILE_NAME = '" & FileName & "' AND FILE_FOLDER = " & FolderID, 1)
                    If (Not Reader.HasRows) Then
                        Database.Write("INSERT INTO " & Database.DBPrefix & "_FILES (FILE_FOLDER, FILE_NAME, FILE_CORE) VALUES (" & FolderID & ", '" & FileName & "', 0)")
                    End If
                    Reader.Close()

                    Upload(thefile, 1)
                Else
                    Message.Text = "Error: Must be .jpg or .gif file."
                End If
            Else
                Message.Text = "Error: Access Denied"
            End If
        End Sub

        Sub DeleteThumbnail(ByVal sender As System.Object, ByVal e As System.EventArgs)
            PagePanel.Visible = "false"
            If Session("UserLevel") = "3" Then
                Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_THUMBNAIL FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & Request.QueryString("ID"))
                While Reader.Read()
                    If Reader("PAGE_THUMBNAIL").ToString() <> "" Then
                        Database.Write("DELETE " & Database.DBPrefix & "_FILES FROM " & Database.DBPrefix & "_FILES, " & Database.DBPrefix & "_FOLDERS WHERE " & Database.DBPrefix & "_FILES.FILE_FOLDER = " & Database.DBPrefix & "_FOLDERS.FOLDER_ID AND " & Database.DBPrefix & "_FILES.FILE_NAME = '" & Reader("PAGE_THUMBNAIL") & "' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_NAME = 'pageimages' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_PARENT = 0")
                        File.Delete(MapPath("pageimages/" & Reader("PAGE_THUMBNAIL")))
                    End If
                End While
                Reader.Close()

                Database.Write("UPDATE " & Database.DBPrefix & "_PAGES SET PAGE_THUMBNAIL = '' WHERE PAGE_ID = " & Request.QueryString("ID"))
                NoItemsDiv.InnerHtml = "Thumbnail Deleted Successfully<br /><br /><a href=""pageimages.aspx?ID=" & Request.QueryString("ID") & """>Upload More Images</a><br /><br /><a href=""JavaScript:onClick=window.close()"">Close Window</a>"
            Else
                NoItemsDiv.InnerHtml = "Error: Access Denied"
            End If
        End Sub

        Sub OpenPhotoForm(ByVal sender As System.Object, ByVal e As System.EventArgs)
            ProductImagesMain.Visible = "false"
            PhotoForm.Visible = "true"
        End Sub

        Sub UploadPhoto(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim thefile As HttpPostedFile = PhotoFile.PostedFile
            Dim FileName As String = System.IO.Path.GetFileName(thefile.FileName)

            If Session("UserLevel") = "3" Then
                If (IsImage(thefile)) Then
                    Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_PHOTO FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & Request.QueryString("ID"))
                    While Reader.Read()
                        If Reader("PAGE_PHOTO").ToString() <> "" Then
                            Database.Write("DELETE " & Database.DBPrefix & "_FILES FROM " & Database.DBPrefix & "_FILES, " & Database.DBPrefix & "_FOLDERS WHERE " & Database.DBPrefix & "_FILES.FILE_FOLDER = " & Database.DBPrefix & "_FOLDERS.FOLDER_ID AND " & Database.DBPrefix & "_FILES.FILE_NAME = '" & Reader("PAGE_PHOTO") & "' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_NAME = 'pageimages' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_PARENT = 0")
                            File.Delete(MapPath("pageimages/" & Reader("PAGE_PHOTO")))
                        End If
                    End While
                    Reader.Close()

                    If (Request.QueryString("ID") = 0) Then
                        Application("PagePhoto") = FileName
                    Else
                        Database.Write("UPDATE " & Database.DBPrefix & "_PAGES SET PAGE_PHOTO = '" & FileName & "' WHERE PAGE_ID = " & Request.QueryString("ID"))
                    End If

                    Dim FolderID As Integer = 0
                    Reader = Database.Read("SELECT FOLDER_ID FROM " & Database.DBPrefix & "_FOLDERS WHERE FOLDER_NAME = 'pageimages' AND FOLDER_PARENT = 0")
                    While Reader.Read()
                        FolderID = Reader("FOLDER_ID")
                    End While
                    Reader.Close()

                    Reader = Database.Read("SELECT FILE_ID FROM " & Database.DBPrefix & "_FILES WHERE FILE_NAME = '" & FileName & "' AND FILE_FOLDER = " & FolderID, 1)
                    If (Not Reader.HasRows) Then
                        Database.Write("INSERT INTO " & Database.DBPrefix & "_FILES (FILE_FOLDER, FILE_NAME, FILE_CORE) VALUES (" & FolderID & ", '" & FileName & "', 0)")
                    End If
                    Reader.Close()

                    Upload(thefile, 2)
                Else
                    Message.Text = "Error: Must be .jpg or .gif file."
                End If
            Else
                Message.Text = "Error: Access Denied"
            End If
        End Sub

        Sub DeletePhoto(ByVal sender As System.Object, ByVal e As System.EventArgs)
            PagePanel.Visible = "false"
            If Session("UserLevel") = "3" Then
                Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_PHOTO FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & Request.QueryString("ID"))
                While Reader.Read()
                    If Reader("PAGE_PHOTO").ToString() <> "" Then
                        Database.Write("DELETE " & Database.DBPrefix & "_FILES FROM " & Database.DBPrefix & "_FILES, " & Database.DBPrefix & "_FOLDERS WHERE " & Database.DBPrefix & "_FILES.FILE_FOLDER = " & Database.DBPrefix & "_FOLDERS.FOLDER_ID AND " & Database.DBPrefix & "_FILES.FILE_NAME = '" & Reader("PAGE_PHOTO") & "' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_NAME = 'pageimages' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_PARENT = 0")
                        File.Delete(MapPath("pageimages/" & Reader("PAGE_PHOTO")))
                    End If
                End While
                Reader.Close()

                Database.Write("UPDATE " & Database.DBPrefix & "_PAGES SET PAGE_PHOTO = '' WHERE PAGE_ID = " & Request.QueryString("ID"))
                NoItemsDiv.InnerHtml = "Photo Deleted Successfully<br /><br /><a href=""pageimages.aspx?ID=" & Request.QueryString("ID") & """>Upload More Images</a><br /><br /><a href=""JavaScript:onClick=window.close()"">Close Window</a>"
            Else
                NoItemsDiv.InnerHtml = "Error: Access Denied"
            End If
        End Sub

        Sub Upload(ByVal file As HttpPostedFile, ByVal type As Integer)
            Dim FileName As String = System.IO.Path.GetFileName(file.FileName)
            If (type = 1) Then
                FileName = "s_" & FileName
            End If

            Dim FilePath As String = MapPath("pageimages/" & FileName)

            If (type = 1) Then
                ResizeImageAndSave(file, FilePath, Settings.ThumbnailSize)
            Else
                file.SaveAs(FilePath)
            End If

            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = FileName & " Subido con éxito<br /><br /><a href=""pageimages.aspx?ID=" & Request.QueryString("ID") & """>Upload More Images</a><br /><br /><a href=""JavaScript:onClick=window.close()"">Close Window</a>"
        End Sub

        Sub ResizeImageAndSave(ByVal file As HttpPostedFile, ByVal FilePath As String, ByVal MaxSize As Integer)
            Dim NewBitmap As New Bitmap(file.InputStream, False)
            If ((NewBitmap.Width > MaxSize) Or (NewBitmap.Height > MaxSize)) Then
                Dim NewRatio As Decimal
                Dim NewWidth As Integer = 0
                Dim NewHeight As Integer = 0

                If (NewBitmap.Width > NewBitmap.Height) Then
                    NewRatio = MaxSize / NewBitmap.Width
                    NewWidth = MaxSize
                    Dim TempHeight As Decimal = NewBitmap.Height * NewRatio
                    NewHeight = TempHeight
                Else
                    NewRatio = MaxSize / NewBitmap.Height
                    NewHeight = MaxSize
                    Dim TempWidth As Decimal = NewBitmap.Width * NewRatio
                    NewWidth = TempWidth
                End If

                Dim Thumbnail As Bitmap = New Bitmap(NewWidth, NewHeight)
                Dim g As Graphics = Graphics.FromImage(Thumbnail)
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                g.FillRectangle(Brushes.White, 0, 0, NewWidth, NewHeight)
                g.DrawImage(NewBitmap, 0, 0, NewWidth, NewHeight)
                NewBitmap.Dispose()

                Thumbnail.Save(FilePath)
                Thumbnail.Dispose()
            Else
                file.SaveAs(FilePath)
            End If
        End Sub

        Private Function IsImage(ByVal file As HttpPostedFile) As Boolean
            If (file.ContentLength > 0) And ((file.ContentType = "image/gif") Or (file.ContentType = "image/jpeg") Or (file.ContentType = "image/pjpeg")) Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class


    '---------------------------------------------------------------------------------------------------
    ' DeletePage - Codebehind For deletepage.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class DeletePage
        Inherits System.Web.UI.Page

        Public DeleteButton As System.Web.UI.WebControls.Button
        Public PageName As System.Web.UI.WebControls.Label
        Public DeleteForm As System.Web.UI.WebControls.Panel
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If (Session("UserLevel") <> "3") Or (Not Functions.IsInteger(Request.QueryString("ID"))) Then
                    DeleteForm.Visible = "false"
                    NoItemsDiv.InnerHtml = "Access Denied<br /><br />"
                Else
                    Dim PageReader As OdbcDataReader = Database.Read("SELECT PAGE_ID, PAGE_NAME FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & Request.QueryString("ID"))
                    If PageReader.HasRows Then
                        While (PageReader.Read())
                            DeleteButton.CommandArgument = PageReader("PAGE_ID")
                            PageName.Text = PageReader("PAGE_NAME")
                        End While
                    Else
                        DeleteForm.Visible = "false"
                        NoItemsDiv.InnerHtml = "Invalid Page ID<br /><br />"
                    End If
                    PageReader.Close()
                End If
            End If
        End Sub

        Sub DeletePage(ByVal sender As System.Object, ByVal e As System.EventArgs)
            DeleteForm.Visible = "false"

            If (sender.CommandArgument = 1) Then
                NoItemsDiv.InnerHtml = "You Can Not Delete The Default Page<br /><br /><a href=""admin.aspx"">Click Aquí</a> To Return To The Admin Screen<br /><br />"
            Else
                Dim Reader As OdbcDataReader = Database.Read("SELECT PAGE_ID FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_PARENT = " & sender.CommandArgument)
                If Reader.HasRows() Then
                    NoItemsDiv.InnerHtml = "This Page Can't Be Deleted Because It Has Sub-Categories<br /><br /><a href=""admin.aspx"">Click Aquí</a> To Return To The Admin Screen<br /><br />"
                Else
                    Dim Reader2 As OdbcDataReader = Database.Read("SELECT PAGE_THUMBNAIL, PAGE_PHOTO FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & sender.CommandArgument, 1)
                    While Reader2.Read()
                        If (Reader2("PAGE_THUMBNAIL").ToString() <> "") Then
                            Database.Write("DELETE " & Database.DBPrefix & "_FILES FROM " & Database.DBPrefix & "_FILES, " & Database.DBPrefix & "_FOLDERS WHERE " & Database.DBPrefix & "_FILES.FILE_FOLDER = " & Database.DBPrefix & "_FOLDERS.FOLDER_ID AND " & Database.DBPrefix & "_FILES.FILE_NAME = '" & Reader2("PAGE_THUMBNAIL").ToString() & "' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_NAME = 'pageimages' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_PARENT = 0")
                            File.Delete(MapPath("pageimages/" & Reader2("PAGE_THUMBNAIL").ToString()))
                        End If
                        If (Reader2("PAGE_PHOTO").ToString() <> "") Then
                            Database.Write("DELETE " & Database.DBPrefix & "_FILES FROM " & Database.DBPrefix & "_FILES, " & Database.DBPrefix & "_FOLDERS WHERE " & Database.DBPrefix & "_FILES.FILE_FOLDER = " & Database.DBPrefix & "_FOLDERS.FOLDER_ID AND " & Database.DBPrefix & "_FILES.FILE_NAME = '" & Reader2("PAGE_PHOTO").ToString() & "' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_NAME = 'pageimages' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_PARENT = 0")
                            File.Delete(MapPath("pageimages/" & Reader2("PAGE_PHOTO").ToString()))
                        End If
                    End While
                    Reader2.Close()

                    Database.Write("DELETE FROM " & Database.DBPrefix & "_PAGES WHERE PAGE_ID = " & sender.CommandArgument)
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_MAIN_MENU WHERE (LINK_TYPE = 2 AND LINK_PARAMETER = '" & sender.CommandArgument & "')")
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_PAGES_PRIVILEGED WHERE PAGE_ID = " & sender.CommandArgument)
                    NoItemsDiv.InnerHtml = "Page Deleted Successfully<br /><br /><a href=""admin.aspx"">Click Aquí</a> To Return To The Admin Screen<br /><br />"
                End If
                Reader.Close()
            End If
        End Sub

        Sub CancelDelete(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("admin.aspx")
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' PageNewGallery - Codebehind For pagenewgallery.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class PageNewGallery
        Inherits System.Web.UI.Page

        Public SelectExisting As System.Web.UI.WebControls.Button
        Public NewGalleryName As System.Web.UI.WebControls.TextBox
        Public NewGalleryColumns As System.Web.UI.WebControls.TextBox
        Public ExistingGalleryColumns As System.Web.UI.WebControls.TextBox
        Public ExistingGallerySuccess As System.Web.UI.WebControls.Label
        Public CreateGallerySuccess As System.Web.UI.WebControls.Label
        Public GalleryAddPhotos As System.Web.UI.WebControls.Button
        Public ExistingDropDown As System.Web.UI.WebControls.DropDownList
        Public InsertExisting As System.Web.UI.WebControls.Button
        Public InsertGalleryForm As System.Web.UI.WebControls.PlaceHolder
        Public ExistingGalleryForm As System.Web.UI.WebControls.PlaceHolder
        Public ExistingGalleryConfirm As System.Web.UI.WebControls.PlaceHolder
        Public NewGalleryForm As System.Web.UI.WebControls.PlaceHolder
        Public NewGalleryConfirm As System.Web.UI.WebControls.PlaceHolder
        Public PagePanel As System.Web.UI.WebControls.PlaceHolder
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If (Session("UserLevel") <> "3") Then
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "Access Denied<br /><br />"
                Else
                    InsertGalleryForm.Visible = "true"
                    Dim Reader As OdbcDataReader = Database.Read("SELECT count(*) as TheCount FROM " & Database.DBPrefix & "_GALLERY")
                    While Reader.Read()
                        If (Reader("TheCount") = 0) Then
                            SelectExisting.Visible = "false"
                        End If
                    End While
                    Reader.Close()
                End If
            End If
        End Sub

        Sub SelectExistingGallery(ByVal sender As System.Object, ByVal e As System.EventArgs)
            InsertGalleryForm.Visible = "false"
            ExistingGalleryForm.Visible = "true"

            Dim LItem As New ListItem("", "0")
            ExistingDropDown.Items.Add(LItem)

            Dim Reader As OdbcDataReader = Database.Read("SELECT GALLERY_ID, GALLERY_NAME FROM " & Database.DBPrefix & "_GALLERY ORDER BY GALLERY_NAME")
            While Reader.Read()
                LItem = New ListItem(Reader("GALLERY_NAME").ToString(), Reader("GALLERY_ID"))
                ExistingDropDown.Items.Add(LItem)
            End While
            Reader.Close()
        End Sub

        Sub SubmitExistingGallery(ByVal sender As System.Object, ByVal e As System.EventArgs)
            InsertGalleryForm.Visible = "false"
            ExistingGalleryForm.Visible = "false"
            ExistingGalleryConfirm.Visible = "true"

            Dim Reader As OdbcDataReader = Database.Read("SELECT GALLERY_ID, GALLERY_NAME FROM " & Database.DBPrefix & "_GALLERY WHERE GALLERY_ID = " & ExistingDropDown.SelectedValue & " ORDER BY GALLERY_ID DESC", 1)
            If Reader.HasRows() Then
                While Reader.Read()
                    ExistingGallerySuccess.Text = Reader("GALLERY_NAME").ToString()
                    InsertExisting.OnClientClick = "javascript:PassBackToParent(" & Reader("GALLERY_ID") & ", " & ExistingGalleryColumns.Text & ");window.close();"
                End While
            Else
                ExistingGalleryConfirm.Visible = "false"
                ExistingGalleryForm.Visible = "true"
                NoItemsDiv.InnerHtml = "<br /><br />You Must Select A Gallery"
            End If
            Reader.Close()
        End Sub

        Sub CreateNewGallery(ByVal sender As System.Object, ByVal e As System.EventArgs)
            InsertGalleryForm.Visible = "false"
            NewGalleryForm.Visible = "true"
        End Sub

        Sub SubmitNewGallery(ByVal sender As System.Object, ByVal e As System.EventArgs)
            InsertGalleryForm.Visible = "false"
            NewGalleryForm.Visible = "false"
            NewGalleryConfirm.Visible = "true"

            Dim NewGalleryID As Integer = 0

            Database.Write("INSERT INTO " & Database.DBPrefix & "_GALLERY (GALLERY_NAME) VALUES ('" & Functions.RepairString(NewGalleryName.Text, 0) & "')")
            Dim Reader As OdbcDataReader = Database.Read("SELECT GALLERY_ID FROM " & Database.DBPrefix & "_GALLERY WHERE GALLERY_NAME = '" & Functions.RepairString(NewGalleryName.Text, 0) & "' ORDER BY GALLERY_ID DESC", 1)
            While Reader.Read()
                NewGalleryID = Reader("GALLERY_ID")
            End While
            Reader.Close()

            CreateGallerySuccess.Text = "Gallery Created Successfully (ID = " & NewGalleryID & ")"
            GalleryAddPhotos.CommandArgument = NewGalleryID
            GalleryAddPhotos.OnClientClick = "javascript:PassBackToParent(" & NewGalleryID & ", " & NewGalleryColumns.Text & ")"
        End Sub

        Sub AddPhotos(ByVal sender As System.Object, ByVal e As System.EventArgs)
            PagePanel.Visible = "false"
            Response.Redirect("upload.aspx?TYPE=photogallery&GALLERY=" & sender.CommandArgument)
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' Search - Codebehind For search.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class Search
        Inherits System.Web.UI.Page

        Public SearchLinks As System.Web.UI.WebControls.Panel
        Public TopicSearch As System.Web.UI.WebControls.Panel
        Public BlogSearch As System.Web.UI.WebControls.Panel
        Public TopicSearchPanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberSearchPanel As System.Web.UI.WebControls.PlaceHolder
        Public BlogSearchPanel As System.Web.UI.WebControls.PlaceHolder
        Public PageSearchPanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberSearch As System.Web.UI.WebControls.Panel
        Public PageSearch As System.Web.UI.WebControls.Panel
        Public PageSearchResults As System.Web.UI.WebControls.Repeater
        Public ForumDropList As System.Web.UI.WebControls.DropDownList
        Public Forum As System.Web.UI.WebControls.Repeater
        Public MemberList As System.Web.UI.WebControls.Repeater
        Public MemberSearchString As System.Web.UI.WebControls.TextBox
        Public txtBlogSearchString As System.Web.UI.WebControls.TextBox
        Public BlogSearchInList As System.Web.UI.WebControls.DropDownList
        Public txtTopicString As System.Web.UI.WebControls.TextBox
        Public DateList As System.Web.UI.WebControls.DropDownList
        Public SearchInList As System.Web.UI.WebControls.DropDownList
        Public txtPageSearchString As System.Web.UI.WebControls.TextBox
        Public PageSearchInList As System.Web.UI.WebControls.DropDownList
        Public BlogDateList As System.Web.UI.WebControls.DropDownList
        Public BlogTopics As System.Web.UI.WebControls.Repeater
        Public SearchResults As System.Web.UI.WebControls.Label
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                SearchLinks.Visible = "true"

                Dim Count As Integer = 0
                If (Settings.SearchTopics = 1) Then
                    TopicSearchPanel.Visible = "true"
                    Count += 1
                End If
                If (Settings.SearchMembers = 1) Then
                    MemberSearchPanel.Visible = "true"
                    Count += 1
                End If
                If (Settings.SearchBlogs = 1) Then
                    BlogSearchPanel.Visible = "true"
                    Count += 1
                End If
                If (Settings.SearchPages = 1) Then
                    PageSearchPanel.Visible = "true"
                    Count += 1
                End If

                If (Count = 1) Then
                    SearchLinks.Visible = "false"
                    If (Settings.SearchTopics = 1) Then
                        TopicSearch.Visible = "true"
                        Dim LItem As New ListItem("All Forums", "-1")
                        ForumDropList.Items.Add(LItem)
                        Dim ForumReader As OdbcDataReader = Database.Read("SELECT F.FORUM_ID, F.FORUM_NAME FROM " & Database.DBPrefix & "_FORUMS F Left Outer Join " & Database.DBPrefix & "_CATEGORIES C On F.CATEGORY_ID = C.CATEGORY_ID WHERE F.FORUM_STATUS <> 0 AND F.FORUM_TYPE = 0 AND C.CATEGORY_STATUS <> 0 ORDER BY F.FORUM_NAME")
                        While ForumReader.Read()
                            LItem = New ListItem(ForumReader("FORUM_NAME").ToString(), ForumReader("FORUM_ID").ToString())
                            ForumDropList.Items.Add(LItem)
                        End While
                        ForumReader.Close()
                    End If
                    If (Settings.SearchMembers = 1) Then
                        MemberSearch.Visible = "true"
                    End If
                    If (Settings.SearchBlogs = 1) Then
                        BlogSearch.Visible = "true"
                    End If
                    If (Settings.SearchPages = 1) Then
                        PageSearch.Visible = "true"
                    End If
                End If
            End If
        End Sub

        Sub OpenConfig(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If sender.CommandArgument = 1 Then
                SearchLinks.Visible = "false"
                TopicSearch.Visible = "true"
                Dim LItem As New ListItem("All Forums", "-1")
                ForumDropList.Items.Add(LItem)
                Dim ForumReader As OdbcDataReader = Database.Read("SELECT F.FORUM_ID, F.FORUM_NAME FROM " & Database.DBPrefix & "_FORUMS F Left Outer Join " & Database.DBPrefix & "_CATEGORIES C On F.CATEGORY_ID = C.CATEGORY_ID WHERE F.FORUM_STATUS <> 0 AND F.FORUM_TYPE = 0 AND C.CATEGORY_STATUS <> 0 ORDER BY F.FORUM_NAME")
                While ForumReader.Read()
                    LItem = New ListItem(ForumReader("FORUM_NAME").ToString(), ForumReader("FORUM_ID").ToString())
                    ForumDropList.Items.Add(LItem)
                End While
                ForumReader.Close()
            ElseIf sender.CommandArgument = 2 Then
                SearchLinks.Visible = "false"
                MemberSearch.Visible = "true"
            ElseIf sender.CommandArgument = 3 Then
                SearchLinks.Visible = "false"
                BlogSearch.Visible = "true"
            ElseIf sender.CommandArgument = 4 Then
                SearchLinks.Visible = "false"
                PageSearch.Visible = "true"
            End If
        End Sub

        Sub SubmitTopicSearch(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Len(txtTopicString.Text) >= 3 Then
                Forum.Visible = "true"
                SearchLinks.Visible = "false"

                Dim SearchString As String = Functions.RepairString(txtTopicString.Text)

                Dim DataSet1 As New DataSet()
                Dim strSql As New OdbcCommand("SELECT F.FORUM_ID, F.FORUM_NAME, C.CATEGORY_ID, C.CATEGORY_NAME FROM " & Database.DBPrefix & "_FORUMS F LEFT OUTER JOIN " & Database.DBPrefix & "_CATEGORIES C ON F.CATEGORY_ID = C.CATEGORY_ID WHERE F.FORUM_TOPICS > 0 AND F.FORUM_STATUS <> 0 AND F.FORUM_TYPE = 0 AND C.CATEGORY_STATUS <> 0 ORDER BY C.CATEGORY_SORTBY, F.FORUM_SORTBY, F.FORUM_NAME", Database.DatabaseConnection())

                Dim DataAdapter1 As New OdbcDataAdapter()
                DataAdapter1.SelectCommand = strSql
                DataAdapter1.Fill(DataSet1, "FORUMS")

                Dim TimeFrame As String
                If (DateList.SelectedValue = 999) Then
                    TimeFrame = ""
                Else
                    TimeFrame = " AND " & Database.GetDateDiff("dd", "T.TOPIC_LASTPOST_DATE", Database.GetTimeStamp(DateList.SelectedValue)) & " <= 0"
                End If

                Dim SearchIn As String
                If SearchInList.SelectedValue = 0 Then
                    SearchIn = " OR T.TOPIC_MESSAGE LIKE '%" & SearchString & "%'"
                Else
                    SearchIn = ""
                End If

                Dim ForumSearch As String
                If (ForumDropList.SelectedValue) = -1 Then
                    ForumSearch = ""
                Else
                    ForumSearch = " AND T.FORUM_ID = " & ForumDropList.SelectedValue
                End If

                strSql = New OdbcCommand("SELECT T.FORUM_ID, T.TOPIC_ID, T.TOPIC_SUBJECT, T.TOPIC_AUTHOR, M.MEMBER_USERNAME as TOPIC_AUTHOR_NAME, T.TOPIC_REPLIES, T.TOPIC_VIEWS, T.TOPIC_STICKY, T.TOPIC_STATUS, T.TOPIC_LASTPOST_AUTHOR, MEMBERS_1.MEMBER_USERNAME as TOPIC_LASTPOST_NAME, T.TOPIC_LASTPOST_DATE, F.FORUM_TOPICS, F.FORUM_STATUS FROM " & Database.DBPrefix & "_MEMBERS M, " & Database.DBPrefix & "_TOPICS T, " & Database.DBPrefix & "_FORUMS F, " & Database.DBPrefix & "_CATEGORIES C, " & Database.DBPrefix & "_MEMBERS as MEMBERS_1 WHERE M.MEMBER_ID = T.TOPIC_AUTHOR and T.TOPIC_LASTPOST_AUTHOR = MEMBERS_1.MEMBER_ID and F.FORUM_ID = T.FORUM_ID and C.CATEGORY_ID = F.CATEGORY_ID and (F.FORUM_STATUS <> 0 and F.FORUM_TYPE = 0 and C.CATEGORY_STATUS <> 0 and F.FORUM_TOPICS > 0 and T.TOPIC_CONFIRMED = 1 and T.TOPIC_STATUS <> 0" & TimeFrame & ForumSearch & ") and (T.TOPIC_SUBJECT LIKE '%" & SearchString & "%'" & SearchIn & ") ORDER BY T.TOPIC_STICKY DESC, T.TOPIC_LASTPOST_DATE DESC", Database.DatabaseConnection())

                DataAdapter1.SelectCommand = strSql
                DataAdapter1.Fill(DataSet1, "TOPICS")

                DataSet1.Relations.Add("TopicRelation", DataSet1.Tables("FORUMS").Columns("FORUM_ID"), DataSet1.Tables("TOPICS").Columns("FORUM_ID"))

                Dim ForumCount As Integer = DataSet1.Tables("FORUMS").Rows.Count - 1
                Dim x As Integer
                For x = 0 To ForumCount
                    If (DataSet1.Tables("FORUMS").Rows(x).GetChildRows("TopicRelation").Length = 0) Then
                        DataSet1.Tables("FORUMS").Rows(x).Delete()
                    End If
                Next

                Forum.DataSource = DataSet1
                Forum.DataBind()

                If (Forum.Items.Count = 0) Then
                    Forum.Visible = "false"
                    SearchResults.Visible = "true"
                    SearchResults.Text = "<center><br />There Are No Items To Display<br /><br /></center>"
                Else
                    SearchResults.Visible = "false"
                End If
            Else
                Forum.Visible = "false"
                SearchResults.Visible = "true"
                SearchResults.Text = "<center><br />You Must Type At Least 3 Characters<br /><br /></center>"
            End If
        End Sub

        Sub SubmitMemberSearch(ByVal sender As System.Object, ByVal e As System.EventArgs)
            SearchLinks.Visible = "false"
            MemberSearch.Visible = "true"
            Dim SearchString As String = Functions.RepairString(MemberSearchString.Text)
            MemberList.DataSource = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_USERNAME LIKE '%" & SearchString & "%' ORDER BY MEMBER_USERNAME")
            MemberList.DataBind()
            MemberList.DataSource.Close()
        End Sub

        Sub SubmitBlogSearch(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If (((txtBlogSearchString.Text).ToString()).Length >= 3) Then
                BlogTopics.Visible = "true"

                Dim SearchString As String = Functions.RepairString(txtBlogSearchString.Text)

                Dim TimeFrame As String
                If (BlogDateList.SelectedValue = 999) Then
                    TimeFrame = ""
                Else
                    TimeFrame = " AND " & Database.GetDateDiff("dd", "B.BLOG_DATE", Database.GetTimeStamp(BlogDateList.SelectedValue)) & " <= 0"
                End If

                Dim SearchIn As String
                If BlogSearchInList.SelectedValue = 0 Then
                    SearchIn = " OR B.BLOG_TEXT LIKE '%" & SearchString & "%'"
                Else
                    SearchIn = ""
                End If

                BlogTopics.DataSource = Database.Read("SELECT B.BLOG_ID, B.BLOG_TITLE, B.BLOG_DATE, B.BLOG_REPLIES, B.BLOG_AUTHOR, M.MEMBER_USERNAME FROM " & Database.DBPrefix & "_BLOG_TOPICS B Left Outer Join " & Database.DBPrefix & "_MEMBERS M On B.BLOG_AUTHOR = M.MEMBER_ID WHERE (B.BLOG_TITLE LIKE '%" & SearchString & "%'" & SearchIn & ")" & TimeFrame & " AND M.MEMBER_LEVEL <> -1 ORDER BY BLOG_DATE DESC")
                BlogTopics.DataBind()
                If (BlogTopics.Items.Count = 0) Then
                    BlogTopics.Visible = "false"
                    SearchResults.Visible = "true"
                    SearchResults.Text = "<center><br />There Are No Items To Display<br /><br /></center>"
                Else
                    SearchResults.Visible = "false"
                End If
                BlogTopics.DataSource.Close()
            Else
                BlogTopics.Visible = "false"
                SearchResults.Visible = "true"
                SearchResults.Text = "<center><br />You Must Type At Least 3 Characters<br /><br /></center>"
            End If
        End Sub

        Sub SubmitPageSearch(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If (((txtPageSearchString.Text).ToString()).Length >= 3) Then
                PageSearchResults.Visible = "true"

                Dim SearchString As String = Functions.RepairString(txtPageSearchString.Text)

                Dim SearchIn As String
                If PageSearchInList.SelectedValue = 0 Then
                    SearchIn = " OR PAGE_CONTENT LIKE '%" & SearchString & "%'"
                Else
                    SearchIn = ""
                End If

                PageSearchResults.DataSource = Database.Read("SELECT PAGE_ID, PAGE_NAME, PAGE_CONTENT FROM " & Database.DBPrefix & "_PAGES WHERE (PAGE_TITLE LIKE '%" & SearchString & "%' OR PAGE_NAME LIKE '%" & SearchString & "%'" & SearchIn & ") AND PAGE_SECURITY = 0 ORDER BY PAGE_NAME")
                PageSearchResults.DataBind()
                If (PageSearchResults.Items.Count = 0) Then
                    PageSearchResults.Visible = "false"
                    SearchResults.Visible = "true"
                    SearchResults.Text = "<center><br />There Are No Items To Display<br /><br /></center>"
                Else
                    SearchResults.Visible = "false"
                End If
                PageSearchResults.DataSource.Close()
            Else
                PageSearchResults.Visible = "false"
                SearchResults.Visible = "true"
                SearchResults.Text = "<center><br />You Must Type At Least 3 Characters<br /><br /></center>"
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' HtmlForm - Codebehind For htmlform.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class HtmlForm
        Inherits System.Web.UI.Page

        Public FormText As String = ""

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                FormText = Request.QueryString("TEXT")
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' HtmlFormResults - Codebehind For htmlformresults.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class HtmlFormResults
        Inherits System.Web.UI.Page

        Public PagePanel As System.Web.UI.WebControls.Panel
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                Dim EmailSent As Integer = 0
                Dim EmailTo As String = ""
                Dim EmailFrom As String = Settings.EmailAddress
                Dim EmailSubject As String = Settings.PageTitle & ": Form Submitted"
                Dim EmailMessage As String = ""
                Dim EmailShowResults As Integer = 1
                Dim FormName As String = "HTML Form"
                Dim FormText As String = ""
                Dim PostToDatabase As Integer = 1
                Dim Failure As Integer = 0
                Dim FailureText As String = ""

                NoItemsDiv.InnerHtml = "Form Submitted Successfully.<br /><br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page.<br /><br />"

                Dim count As Integer = 0
                Dim x As String
                For Each x In Request.Form
                    If (x = "EmailTo") Then
                        EmailTo = Request.Form(x)

                    ElseIf (x = "EmailFrom") Then
                        EmailFrom = Request.Form(x)
                    ElseIf (x = "EmailSubject") Then
                        EmailSubject = Request.Form(x)
                    ElseIf (x = "EmailMessage") Then
                        EmailMessage = Request.Form(x)
                    ElseIf (x = "EmailShowResults") Then
                        EmailShowResults = Request.Form(x)
                    ElseIf (x = "FormName") Then
                        FormName = Request.Form(x)
                    ElseIf (x = "FormText") Then
                        FormText &= Request.Form(x)
                        count = count + 1
                    ElseIf (x = "SubmitMessage") Then
                        NoItemsDiv.InnerHtml = Request.Form(x) & "<br /><br />"
                    ElseIf (x = "PostToDatabase") Then
                        PostToDatabase = Request.Form(x)
                    Else
                        If ((x.ToLower() <> "submit") And (Left(x.ToLower(), 9) <> "required-")) Then
                            If (count <> 0) Then
                                FormText &= "<br /><br />"
                            End If
                            FormText &= "<b>" & x & ":</b> " & Request.Form(x)
                            count = count + 1
                        End If
                    End If

                    If ((Request.Form("Required-" & x) = "1") And (Request.Form(x) = "")) Then
                        Failure = 1
                        FailureText &= "<br />" & x
                    End If
                Next

                If (Failure = 0) Then
                    If (EmailTo <> "") Then
                        If (EmailShowResults = 1) Then
                            EmailMessage &= "<br /><br />" & FormText
                        End If
                        EmailSent = 1
                        Dim result As Integer = Functions.SendEmail(EmailTo, EmailFrom, EmailSubject, EmailMessage)
                    End If

                    If (PostToDatabase = 1) Then
                        Database.Write("INSERT INTO " & Database.DBPrefix & "_HTML_FORMS (FORM_DATE, FORM_NAME, FORM_TEXT, FORM_NEW, FORM_EMAIL) VALUES (" & Database.GetTimeStamp() & ", '" & Functions.RepairString(FormName) & "', '" & Functions.RepairString(AutoSpaces(FormText), 0) & "', 1, " & EmailSent & ")")
                    End If
                Else
                    NoItemsDiv.InnerHtml = "The following fields are required:<br />" & FailureText & "<br /><br />Please press your browser's back button to complete the form.<br /><br />"
                End If
            End If
        End Sub

        Private Function AutoSpaces(ByVal TheString As String) As String
            Dim ReturnString As String = TheString
            ReturnString = ReturnString.Replace(Chr(13), "")
            ReturnString = ReturnString.Replace(Chr(10), "<br />")
            ReturnString = ReturnString.Replace(Chr(10) & Chr(10), "<br /><br />")
            Return ReturnString
        End Function
    End Class


End Namespace
