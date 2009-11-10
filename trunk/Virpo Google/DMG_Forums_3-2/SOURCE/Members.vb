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
Imports System.IO
Imports System.Math
Imports System.Collections
Imports System.Web
Imports System.Web.UI.WebControls
Imports Microsoft.VisualBasic
Imports DMGForums.Global

Namespace DMGForums.Members

	'---------------------------------------------------------------------------------------------------
	' MembersPage - Codebehind For members.aspx
	'---------------------------------------------------------------------------------------------------
	Public Class MembersPage
		Inherits System.Web.UI.Page

		Public SearchLetter as System.Web.UI.WebControls.Label
		Public SortLabel As System.Web.UI.WebControls.Label
		Public PagingPanel As System.Web.UI.WebControls.Panel
		Public JumpPage As System.Web.UI.WebControls.DropDownList
		Public FirstLink As System.Web.UI.WebControls.LinkButton
		Public PreviousLink As System.Web.UI.WebControls.LinkButton
		Public NextLink As System.Web.UI.WebControls.LinkButton
		Public LastLink As System.Web.UI.WebControls.LinkButton
		Public PageCountLabel As System.Web.UI.WebControls.Label
		Public MemberNameLink As System.Web.UI.WebControls.LinkButton
		Public PostsLink As System.Web.UI.WebControls.LinkButton
		Public LastPostLink As System.Web.UI.WebControls.LinkButton
		Public DateJoinedLink As System.Web.UI.WebControls.LinkButton
		Public LastVisitLink As System.Web.UI.WebControls.LinkButton
		Public MembersList As System.Web.UI.WebControls.Repeater
		Public StatsPanel As System.Web.UI.WebControls.PlaceHolder
		Public MembersText As System.Web.UI.WebControls.Label
		Public NewMemberText As System.Web.UI.WebControls.Label
		Public TopicsText As System.Web.UI.WebControls.Label
		Public PagePanel As System.Web.UI.WebControls.Panel
		Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
			if Not Page.IsPostBack() then
				if ((Settings.HideMembers = 0) or (Session("UserLogged") = "1")) then
					SortLabel.text = "None"
					SearchLetter.text = "All"
					if (Functions.IsInteger(Request.Querystring("PAGE"))) then
						ListMembers(Request.Querystring("PAGE"), Settings.ItemsPerPage, SortLabel.text)
					else
						ListMembers(1, Settings.ItemsPerPage, SortLabel.text)
					end if
					if (Settings.ShowStatistics = 1) then
						DisplayStatistics()
					end if
				else
					PagePanel.visible = "false"
                    NoItemsDiv.InnerHtml = "Only Members Can View This Page.<br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page.<br /><br />"
                End If
            End If
        End Sub

        Sub ListMembers(Optional ByVal CurrentPage As Integer = 1, Optional ByVal ItemsPerPage As Integer = 15, Optional ByVal SortString As String = "None", Optional ByVal SearchLetter As String = "All")
            Dim NumPages, NumItems, NumWholePages, Leftover As Integer
            Dim IDList As New ArrayList
            Dim SortBy As String
            Dim SearchBy As String

            If SortString = "None" Then
                SortBy = " ORDER BY MEMBER_LEVEL DESC, MEMBER_POSTS DESC, MEMBER_USERNAME"
            Else
                SortBy = SortString
            End If

            If SearchLetter = "All" Then
                SearchBy = ""
            Else
                SearchBy = " AND MEMBER_USERNAME LIKE '" & SearchLetter & "%'"
            End If

            Dim MembersReader As OdbcDataReader = Database.Read("SELECT MEMBER_ID FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1" & SearchBy & SortBy)
            While (MembersReader.Read())
                IDList.Add(MembersReader("MEMBER_ID"))
            End While
            MembersReader.Close()

            NumItems = IDList.Count

            If (NumItems > 0) Then
                NumPages = NumItems \ ItemsPerPage
                NumWholePages = NumItems \ ItemsPerPage
                Leftover = NumItems Mod ItemsPerPage

                If Leftover > 0 Then
                    NumPages += 1
                End If

                If (CurrentPage < 0) Or (CurrentPage > NumPages) Then
                    ListMembers(1, ItemsPerPage)
                Else
                    If CurrentPage = NumPages Then
                        NextLink.Visible = False
                        LastLink.Visible = False
                    Else
                        NextLink.Visible = True
                        LastLink.Visible = True
                        NextLink.CommandArgument = CurrentPage + 1
                        LastLink.CommandArgument = NumPages
                    End If

                    If CurrentPage = 1 Then
                        PreviousLink.Visible = False
                        FirstLink.Visible = False
                    Else
                        PreviousLink.Visible = True
                        FirstLink.Visible = True
                        PreviousLink.CommandArgument = CurrentPage - 1
                        FirstLink.CommandArgument = 1
                    End If

                    If NumPages = 1 Then
                        PagingPanel.Visible = "false"
                    Else
                        PagingPanel.Visible = "true"
                    End If

                    Dim JumpPageList As ArrayList = New ArrayList
                    Dim x As Integer
                    For x = 1 To NumPages
                        JumpPageList.Add(x)
                    Next

                    JumpPage.DataSource = JumpPageList
                    JumpPage.DataBind()
                    JumpPage.SelectedIndex = CurrentPage - 1

                    PageCountLabel.Text = NumPages

                    Dim StartOfPage As Integer = ItemsPerPage * (CurrentPage - 1)
                    Dim EndOfPage As Integer = Min((ItemsPerPage * (CurrentPage - 1)) + (ItemsPerPage - 1), ((NumWholePages * ItemsPerPage) + Leftover - 1))

                    Dim CurrentSubset As String = Join(IDList.GetRange(StartOfPage, (EndOfPage - StartOfPage + 1)).ToArray, ",")

                    MembersList.DataSource = Database.Read("SELECT * FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID IN (" & CurrentSubset & ")" & SortBy)
                    MembersList.DataBind()

                    If (MembersList.Items.Count = 0) Then
                        NoItemsDiv.InnerHtml = "There Are No Items To Display<br /><br />"
                    End If

                    MembersList.DataSource.Close()
                End If
            Else
                MembersList.Visible = "False"
                NoItemsDiv.InnerHtml = "There Are No Items To Display<br /><br />"
            End If
        End Sub

        Sub ChangePage(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If sender.ToString() = "System.Web.UI.WebControls.LinkButton" Then
                ListMembers(CType(sender.CommandArgument, Integer), Settings.ItemsPerPage, SortLabel.Text, SearchLetter.Text)
            Else
                ListMembers(CType(sender.SelectedIndex + 1, Integer), Settings.ItemsPerPage, SortLabel.Text, SearchLetter.Text)
            End If
        End Sub

        Sub ChangeSearchLetter(ByVal sender As System.Object, ByVal e As System.EventArgs)
            SearchLetter.Text = sender.CommandArgument.ToString()
            SortLabel.Text = "None"
            MembersList.Visible = "True"
            NoItemsDiv.InnerHtml = ""
            ListMembers(1, Settings.ItemsPerPage, SortLabel.Text, SearchLetter.Text)
        End Sub

        Sub ChangeSort(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If (sender.ID = "MemberNameLink") Then
                If SortLabel.Text = " ORDER BY MEMBER_USERNAME ASC" Then
                    SortLabel.Text = " ORDER BY MEMBER_USERNAME DESC"
                Else
                    SortLabel.Text = " ORDER BY MEMBER_USERNAME ASC"
                End If
            ElseIf (sender.ID = "PostsLink") Then
                If SortLabel.Text = " ORDER BY MEMBER_POSTS DESC, MEMBER_USERNAME" Then
                    SortLabel.Text = " ORDER BY MEMBER_POSTS ASC, MEMBER_USERNAME"
                Else
                    SortLabel.Text = " ORDER BY MEMBER_POSTS DESC, MEMBER_USERNAME"
                End If
            ElseIf (sender.ID = "LastPostLink") Then
                If SortLabel.Text = " ORDER BY MEMBER_DATE_LASTPOST DESC, MEMBER_USERNAME" Then
                    SortLabel.Text = " ORDER BY MEMBER_DATE_LASTPOST ASC, MEMBER_USERNAME"
                Else
                    SortLabel.Text = " ORDER BY MEMBER_DATE_LASTPOST DESC, MEMBER_USERNAME"
                End If
            ElseIf (sender.ID = "DateJoinedLink") Then
                If SortLabel.Text = " ORDER BY MEMBER_DATE_JOINED DESC, MEMBER_USERNAME" Then
                    SortLabel.Text = " ORDER BY MEMBER_DATE_JOINED ASC, MEMBER_USERNAME"
                Else
                    SortLabel.Text = " ORDER BY MEMBER_DATE_JOINED DESC, MEMBER_USERNAME"
                End If
            ElseIf (sender.ID = "LastVisitLink") Then
                If SortLabel.Text = " ORDER BY MEMBER_DATE_LASTVISIT DESC, MEMBER_USERNAME" Then
                    SortLabel.Text = " ORDER BY MEMBER_DATE_LASTVISIT ASC, MEMBER_USERNAME"
                Else
                    SortLabel.Text = " ORDER BY MEMBER_DATE_LASTVISIT DESC, MEMBER_USERNAME"
                End If
            Else
                SortLabel.Text = " ORDER BY MEMBER_LEVEL DESC, MEMBER_POSTS DESC, MEMBER_USERNAME"
            End If

            ListMembers(1, Settings.ItemsPerPage, SortLabel.Text, SearchLetter.Text)
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
            MembersText.Text = MembersString

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
            TopicsText.Text = TopicsString
        End Sub

        Sub EditMember(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("usercp.aspx?ID=" & sender.CommandArgument)
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' Register - Codebehind For register.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class Register
        Inherits System.Web.UI.Page

        Public txtUsername As System.Web.UI.WebControls.TextBox
        Public txtPassword1 As System.Web.UI.WebControls.TextBox
        Public txtPassword2 As System.Web.UI.WebControls.TextBox
        Public txtEmail1 As System.Web.UI.WebControls.TextBox
        Public txtEmail2 As System.Web.UI.WebControls.TextBox
        Public txtShowEmail As System.Web.UI.WebControls.DropDownList
        Public txtTitle As System.Web.UI.WebControls.TextBox
        Public txtUseTitle As System.Web.UI.WebControls.DropDownList
        Public txtAOL As System.Web.UI.WebControls.TextBox
        Public txtICQ As System.Web.UI.WebControls.TextBox
        Public txtYahoo As System.Web.UI.WebControls.TextBox
        Public txtMSN As System.Web.UI.WebControls.TextBox
        Public txtAvatarName As System.Web.UI.WebControls.TextBox
        Public txtShowAvatar As System.Web.UI.WebControls.DropDownList
        Public txtSignature As System.Web.UI.WebControls.TextBox
        Public txtShowSignature As System.Web.UI.WebControls.DropDownList
        Public txtRealName As System.Web.UI.WebControls.TextBox
        Public txtLocation As System.Web.UI.WebControls.TextBox
        Public txtHomePage As System.Web.UI.WebControls.TextBox
        Public txtFavoriteSite As System.Web.UI.WebControls.TextBox
        Public txtOccupation As System.Web.UI.WebControls.TextBox
        Public txtSex As System.Web.UI.WebControls.DropDownList
        Public txtAge As System.Web.UI.WebControls.TextBox
        Public txtBirthday As System.Web.UI.WebControls.TextBox
        Public txtPhoto As System.Web.UI.WebControls.TextBox
        Public txtNotes As System.Web.UI.WebControls.TextBox
        Public RegistrationTitle As System.Web.UI.WebControls.Label
        Public Complete As System.Web.UI.WebControls.Label
        Public PrivacyNoticePanel As System.Web.UI.WebControls.PlaceHolder
        Public RegistrationPanel As System.Web.UI.WebControls.PlaceHolder
        Public CustomTitlePanel As System.Web.UI.WebControls.PlaceHolder
        Public AvatarPanel As System.Web.UI.WebControls.PlaceHolder
        Public ConfirmationPanel As System.Web.UI.WebControls.PlaceHolder
        Public FullRegPanel As System.Web.UI.WebControls.PlaceHolder
        Public RequireEmailLabel As System.Web.UI.WebControls.Label
        Public PagePanel As System.Web.UI.WebControls.Panel
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If (Settings.AllowRegistration = 1) Then
                    Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_ID FROM " & Database.DBPrefix & "_BANNED_IP WHERE IP_ADDRESS = '" & Request.UserHostAddress() & "'", 1)
                    If Reader.HasRows() Then
                        PagePanel.Visible = "false"
                        NoItemsDiv.InnerHtml = "Registration Access Denied<br /><br />"
                    Else
                        If Session("UserLogged") = "1" Then
                            PagePanel.Visible = "false"
                            NoItemsDiv.InnerHtml = "You Are Registered<br /><br />"
                        Else
                            PrivacyNoticePanel.Visible = "true"
                            RegistrationTitle.Text = "Privacy Notice"
                        End If
                    End If
                    Reader.Close()
                Else
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "Registration Is Currently Turned Off<br /><br />"
                End If
            End If
        End Sub

        Sub UserRegistration(ByVal sender As System.Object, ByVal e As System.EventArgs)
            PrivacyNoticePanel.Visible = "false"
            RegistrationPanel.Visible = "true"
            RegistrationTitle.Text = "User Registration"
            If (Functions.AllowCustom(0, 0, 0, "CustomTitle")) Then
                CustomTitlePanel.Visible = "true"
            End If
            If (Functions.AllowCustom(0, 0, 0, "Avatar")) Then
                AvatarPanel.Visible = "true"
            End If
            If (Settings.QuickRegistration = 1) Then
                FullRegPanel.Visible = "false"
            End If
            If (Settings.MemberValidation = 1) Then
                RequireEmailLabel.Visible = "true"
                RequireEmailLabel.Text = "<center><font size=""2"" color=""" & Settings.TopicsFontColor & """><b>Note: A verification e-mail will be sent to the address you enter below.</b><br /><br /></font></center>"
            End If
        End Sub

        Sub CancelRegistration(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("default.aspx")
        End Sub

        Sub SubmitRegistration(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim Retry As Integer = 0

            Dim TheUsername As String = txtUsername.Text
            TheUsername = TheUsername.TrimStart(" ")
            TheUsername = TheUsername.TrimEnd(" ")

            If (Len(TheUsername) = 0) Then
                Functions.MessageBox("NO BLANK USERNAMES!")
                Retry = 1
                RegistrationTitle.Text = "User Registration"
                RegistrationPanel.Visible = "true"
            End If

            Dim UsernameReader As OdbcDataReader = Database.Read("SELECT MEMBER_USERNAME FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_USERNAME = '" & Functions.RepairString(TheUsername) & "'")
            If (UsernameReader.HasRows) Then
                Functions.MessageBox("USERNAME ALREADY EXISTS!")
                Retry = 1
                RegistrationTitle.Text = "User Registration"
                RegistrationPanel.Visible = "true"
            End If
            UsernameReader.Close()

            Dim EmailReader As OdbcDataReader = Database.Read("SELECT MEMBER_EMAIL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_EMAIL = '" & Functions.RepairString(txtEmail1.Text) & "'")
            If (EmailReader.HasRows) Then
                Functions.MessageBox("ACCOUNT ALREADY OPEN FOR THIS E-MAIL!")
                Retry = 1
                RegistrationTitle.Text = "User Registration"
                RegistrationPanel.Visible = "true"
            End If
            EmailReader.Close()

            If (Retry = 0) Then
                RegistrationTitle.Text = "Registration Complete"
                RegistrationPanel.Visible = "false"
                ConfirmationPanel.Visible = "true"

                Dim Username As String = Functions.RepairString(TheUsername)
                Dim Password As String = Functions.RepairString(txtPassword1.Text)
                Password = Functions.Encrypt(Password)
                Dim Email As String = Functions.RepairString(txtEmail1.Text)
                Dim ShowEmail As String = CLng(txtShowEmail.SelectedValue)
                Dim AOL As String = Functions.RepairString(txtAOL.Text)
                Dim ICQ As String = Functions.RepairString(txtICQ.Text)
                Dim Yahoo As String = Functions.RepairString(txtYahoo.Text)
                Dim MSN As String = Functions.RepairString(txtMSN.Text)
                Dim Signature As String = Functions.RepairString(txtSignature.Text)
                Dim ShowSignature As String = CLng(txtShowSignature.SelectedValue)
                Dim RealName As String = Functions.RepairString(txtRealName.Text)
                Dim Location As String = Functions.RepairString(txtLocation.Text)
                Dim HomePage As String = Functions.RepairString(txtHomePage.Text)
                Dim FavoriteSite As String = Functions.RepairString(txtFavoriteSite.Text)
                Dim Occupation As String = Functions.RepairString(txtOccupation.Text)
                Dim Sex As String = Functions.RepairString(txtSex.SelectedValue)
                Dim Age As String = Functions.RepairString(txtAge.Text)
                Dim Birthday As String = Functions.RepairString(txtBirthday.Text)
                Dim Photo As String = Functions.RepairString(txtPhoto.Text)
                Dim Notes As String = Functions.RepairString(txtNotes.Text)
                Dim Avatar As String = CLng(Request.Form("txtAvatar"))
                Dim Title As String = Functions.RepairString(txtTitle.Text)
                Dim UseTitle As String = CLng(txtUseTitle.SelectedValue)
                Dim ShowAvatar As String = CLng(txtShowAvatar.SelectedValue)
                Dim Validated As Integer = 1
                Dim UniqueKey As String = "none"
                Dim MemberLevel As Integer = 1

                If (Settings.MemberValidation = 1) Then
                    Validated = 0
                    UniqueKey = Functions.GetUniqueKey()
                    MemberLevel = -1
                    Dim err As Integer = Functions.SendEmail(Email, Settings.EmailAddress, "Thank you for registering at " & Settings.PageTitle, Functions.CustomMessage("EMAIL_SENDKEY") & "<br /><br />" & UniqueKey)
                    If (err = 0) Then
                        Complete.Text = Functions.CustomMessage("MESSAGE_SENDKEY")
                    Else
                        Complete.Text = "The SMTP server for this site is not configured properly.  Please contact the administrator to have your account verified."
                    End If
                ElseIf (Settings.MemberValidation = 2) Then
                    Validated = 0
                    MemberLevel = -1
                    Complete.Text = Functions.CustomMessage("MESSAGE_ADMINAPPROVAL")
                Else
                    Complete.Text = Functions.CustomMessage("MESSAGE_REGISTRATION")

                    If (Settings.EmailWelcomeMessage = 1) Then
                        Dim err2 As Integer = Functions.SendEmail(Email, Settings.EmailAddress, "Thank you for registering at " & Settings.PageTitle, Functions.CustomMessage("EMAIL_WELCOMEMESSAGE"))
                    End If
                End If

                Database.Write("INSERT INTO " & Database.DBPrefix & "_MEMBERS (MEMBER_USERNAME, MEMBER_PASSWORD, MEMBER_LEVEL, MEMBER_EMAIL, MEMBER_LOCATION, MEMBER_HOMEPAGE, MEMBER_SIGNATURE, MEMBER_SIGNATURE_SHOW, MEMBER_IM_AOL, MEMBER_IM_ICQ, MEMBER_IM_MSN, MEMBER_IM_YAHOO, MEMBER_POSTS, MEMBER_DATE_JOINED, MEMBER_DATE_LASTVISIT, MEMBER_TITLE, MEMBER_TITLE_ALLOWCUSTOM, MEMBER_TITLE_USECUSTOM, MEMBER_EMAIL_SHOW, MEMBER_IP_LAST, MEMBER_IP_ORIGINAL, MEMBER_REALNAME, MEMBER_OCCUPATION, MEMBER_SEX, MEMBER_AGE, MEMBER_BIRTHDAY, MEMBER_NOTES, MEMBER_FAVORITESITE, MEMBER_PHOTO, MEMBER_AVATAR, MEMBER_AVATAR_SHOW, MEMBER_AVATAR_ALLOWCUSTOM, MEMBER_AVATAR_USECUSTOM, MEMBER_AVATAR_CUSTOMLOADED, MEMBER_AVATAR_CUSTOMTYPE, MEMBER_VALIDATED, MEMBER_VALIDATION_STRING, MEMBER_RANKING) VALUES ('" & Username & "','" & Password & "', " & MemberLevel & ", '" & Email & "', '" & Location & "', '" & HomePage & "', '" & Signature & "', " & ShowSignature & ", '" & AOL & "', '" & ICQ & "', '" & MSN & "', '" & Yahoo & "', 0, " & Database.GetTimeStamp() & ", " & Database.GetTimeStamp() & ", '', 0, 0, " & ShowEmail & ", '" & Request.UserHostAddress() & "', '" & Request.UserHostAddress() & "', '" & RealName & "', '" & Occupation & "', '" & Sex & "', '" & Age & "', '" & Birthday & "', '" & Notes & "', '" & FavoriteSite & "', '" & Photo & "', " & Avatar & ", " & ShowAvatar & ", 0, 0, 0, 'jpg', " & Validated & ", '" & UniqueKey & "', 0)")

                If (Validated = 1) Then
                    Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_USERNAME = '" & Username & "'", 1)
                    While Reader.Read()
                        Dim aCookie As New System.Web.HttpCookie("dmgforums")
                        aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
                        aCookie.Values("mukul") = Reader("MEMBER_ID").ToString()
                        aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now())
                        aCookie.Values("gupta") = Reader("MEMBER_PASSWORD").ToString()
                        Session("UserName") = Reader("MEMBER_USERNAME").ToString()
                        Session("UserLogged") = "1"
                        Session("UserID") = Reader("MEMBER_ID").ToString()
                        Session("UserLevel") = "1"
                        Session("ActiveLevel") = 1
                        Session("ActiveTime") = Database.DatabaseTimestamp()
                        aCookie.Expires = DateTime.Now.AddDays(30)
                        Response.Cookies.Add(aCookie)
                    End While
                    Reader.Close()
                End If
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' EditProfile - Codebehind For editprofile.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class EditProfile
        Inherits System.Web.UI.Page

        Public txtLevel As System.Web.UI.WebControls.DropDownList
        Public txtPostCount As System.Web.UI.WebControls.TextBox
        Public txtTitle As System.Web.UI.WebControls.TextBox
        Public txtUseTitle As System.Web.UI.WebControls.DropDownList
        Public txtAllowTitle As System.Web.UI.WebControls.DropDownList
        Public txtEmail As System.Web.UI.WebControls.TextBox
        Public txtRanking As System.Web.UI.WebControls.DropDownList
        Public txtShowEmail As System.Web.UI.WebControls.DropDownList
        Public txtAOL As System.Web.UI.WebControls.TextBox
        Public txtICQ As System.Web.UI.WebControls.TextBox
        Public txtYahoo As System.Web.UI.WebControls.TextBox
        Public txtMSN As System.Web.UI.WebControls.TextBox
        Public txtAvatarName As System.Web.UI.WebControls.TextBox
        Public txtShowAvatar As System.Web.UI.WebControls.DropDownList
        Public mAvatar As Integer
        Public txtUseCustomAvatar As System.Web.UI.WebControls.DropDownList
        Public txtAllowCustomAvatar As System.Web.UI.WebControls.DropDownList
        Public txtSignature As System.Web.UI.WebControls.TextBox
        Public txtShowSignature As System.Web.UI.WebControls.DropDownList
        Public txtRealName As System.Web.UI.WebControls.TextBox
        Public txtLocation As System.Web.UI.WebControls.TextBox
        Public txtHomePage As System.Web.UI.WebControls.TextBox
        Public txtFavoriteSite As System.Web.UI.WebControls.TextBox
        Public txtOccupation As System.Web.UI.WebControls.TextBox
        Public txtSex As System.Web.UI.WebControls.DropDownList
        Public txtAge As System.Web.UI.WebControls.TextBox
        Public txtBirthday As System.Web.UI.WebControls.TextBox
        Public txtPhoto As System.Web.UI.WebControls.TextBox
        Public txtNotes As System.Web.UI.WebControls.TextBox
        Public UsernameLabel As System.Web.UI.WebControls.Label
        Public EditProfilePanel As System.Web.UI.WebControls.Panel
        Public MemberTypePanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberTitlePanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberRankingPanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberTitleEditPanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberAvatarPanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberCustomAvatarPanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberCustomAvatarEditPanel As System.Web.UI.WebControls.PlaceHolder
        Public MemberNotesEditPanel As System.Web.UI.WebControls.PlaceHolder
        Public ConfirmationPanel As System.Web.UI.WebControls.Panel
        Public PagePanel As System.Web.UI.WebControls.Panel
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If ((Session("UserLogged") = "1") And (Session("UserID") = Request.QueryString("ID"))) Or (Session("UserLevel") = "3") Then
                    Dim LItem As New ListItem("Based On Post Count", "0")
                    txtRanking.Items.Add(LItem)
                    LItem = New ListItem("-------------------", "0")
                    txtRanking.Items.Add(LItem)
                    Dim Reader As OdbcDataReader = Database.Read("SELECT RANK_ID, RANK_NAME FROM " & Database.DBPrefix & "_RANKINGS ORDER BY RANK_POSTS")
                    While Reader.Read()
                        LItem = New ListItem(Reader("RANK_NAME").ToString(), Reader("RANK_ID"))
                        txtRanking.Items.Add(LItem)
                    End While
                    Reader.Close()

                    EditProfilePanel.Visible = "true"
                    Dim ProfileReader As OdbcDataReader = Database.Read("SELECT M.*, A.AVATAR_NAME FROM " & Database.DBPrefix & "_MEMBERS M LEFT OUTER JOIN " & Database.DBPrefix & "_AVATARS A ON M.MEMBER_AVATAR = A.AVATAR_ID WHERE M.MEMBER_ID = " & Request.QueryString("ID"))
                    While (ProfileReader.Read())
                        If (ProfileReader("MEMBER_LEVEL") = -1) Then
                            Response.Redirect("default.aspx")
                        End If

                        UsernameLabel.Text = "Edit Profile: " & ProfileReader("MEMBER_USERNAME").ToString()

                        If (Session("UserLevel") = "3") Then
                            MemberTypePanel.Visible = "true"
                            MemberRankingPanel.Visible = "true"
                            MemberNotesEditPanel.Visible = "true"
                        End If

                        Dim AllowTheCustomTitle As Boolean = Functions.AllowCustom(ProfileReader("MEMBER_RANKING"), ProfileReader("MEMBER_POSTS"), ProfileReader("MEMBER_TITLE_ALLOWCUSTOM"), "CustomTitle")
                        If ((Session("UserLevel") = "3") Or (AllowTheCustomTitle)) Then
                            MemberTitlePanel.Visible = "true"
                        End If

                        If (Session("UserLevel") = "3") Then
                            MemberTitleEditPanel.Visible = "true"
                            MemberCustomAvatarEditPanel.Visible = "true"
                        End If

                        Dim AllowTheAvatar As Boolean = Functions.AllowCustom(ProfileReader("MEMBER_RANKING"), ProfileReader("MEMBER_POSTS"), 0, "Avatar")
                        If ((Session("UserLevel") = "3") Or (AllowTheAvatar)) Then
                            MemberAvatarPanel.Visible = "true"
                        End If

                        Dim AllowTheCustomAvatar As Boolean = Functions.AllowCustom(ProfileReader("MEMBER_RANKING"), ProfileReader("MEMBER_POSTS"), ProfileReader("MEMBER_AVATAR_ALLOWCUSTOM"), "CustomAvatar")
                        If ((Session("UserLevel") = "3") Or (AllowTheCustomAvatar)) Then
                            MemberCustomAvatarPanel.Visible = "true"
                        End If

                        txtRanking.SelectedValue = ProfileReader("MEMBER_RANKING")
                        txtLevel.SelectedValue = ProfileReader("MEMBER_LEVEL")
                        txtPostCount.Text = ProfileReader("MEMBER_POSTS")
                        txtTitle.Text = ProfileReader("MEMBER_TITLE").ToString()
                        txtUseTitle.SelectedValue = ProfileReader("MEMBER_TITLE_USECUSTOM")
                        txtAllowTitle.SelectedValue = ProfileReader("MEMBER_TITLE_ALLOWCUSTOM")
                        txtEmail.Text = ProfileReader("MEMBER_EMAIL").ToString()
                        txtShowEmail.SelectedValue = ProfileReader("MEMBER_EMAIL_SHOW")
                        txtAOL.Text = ProfileReader("MEMBER_IM_AOL").ToString()
                        txtICQ.Text = ProfileReader("MEMBER_IM_ICQ").ToString()
                        txtYahoo.Text = ProfileReader("MEMBER_IM_YAHOO").ToString()
                        txtMSN.Text = ProfileReader("MEMBER_IM_MSN").ToString()
                        If (ProfileReader("MEMBER_AVATAR_USECUSTOM") = 1) And (ProfileReader("MEMBER_AVATAR_CUSTOMLOADED") = 1) Then
                            txtAvatarName.Text = "USING CUSTOM AVATAR"
                        Else
                            txtAvatarName.Text = ProfileReader("AVATAR_NAME").ToString()
                        End If
                        txtShowAvatar.SelectedValue = ProfileReader("MEMBER_AVATAR_SHOW")
                        mAvatar = ProfileReader("MEMBER_AVATAR")
                        txtUseCustomAvatar.SelectedValue = ProfileReader("MEMBER_AVATAR_USECUSTOM")
                        txtAllowCustomAvatar.SelectedValue = ProfileReader("MEMBER_AVATAR_ALLOWCUSTOM")
                        txtSignature.Text = Server.HtmlDecode(ProfileReader("MEMBER_SIGNATURE").ToString())
                        txtShowSignature.SelectedValue = ProfileReader("MEMBER_SIGNATURE_SHOW")
                        txtRealName.Text = ProfileReader("MEMBER_REALNAME").ToString()
                        txtLocation.Text = ProfileReader("MEMBER_LOCATION").ToString()
                        txtHomePage.Text = ProfileReader("MEMBER_HOMEPAGE").ToString()
                        txtFavoriteSite.Text = ProfileReader("MEMBER_FAVORITESITE").ToString()
                        txtOccupation.Text = ProfileReader("MEMBER_OCCUPATION").ToString()
                        txtSex.SelectedValue = ProfileReader("MEMBER_SEX").ToString()
                        txtAge.Text = ProfileReader("MEMBER_AGE").ToString()
                        txtBirthday.Text = ProfileReader("MEMBER_BIRTHDAY").ToString()
                        txtPhoto.Text = ProfileReader("MEMBER_PHOTO").ToString()
                        txtNotes.Text = Server.HtmlDecode(ProfileReader("MEMBER_NOTES").ToString())

                        If (ProfileReader("MEMBER_ID") = 1) Then
                            txtLevel.Enabled = "false"
                        End If
                    End While
                    ProfileReader.Close()
                Else
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "You Must Be Logged In To Edit Your Profile<br /><br />"
                End If
            End If
        End Sub

        Sub SubmitChanges(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim Level As String = CLng(txtLevel.SelectedValue)
            Dim Posts As String = CLng(txtPostCount.Text)
            Dim Title As String = Functions.RepairString(txtTitle.Text)
            Dim Ranking As String = Functions.RepairString(txtRanking.SelectedValue)
            Dim AllowTitle As String = CLng(txtAllowTitle.SelectedValue)
            Dim UseTitle As String = CLng(txtUseTitle.SelectedValue)
            Dim Email As String = Functions.RepairString(txtEmail.Text)
            Dim ShowEmail As String = CLng(txtShowEmail.SelectedValue)
            Dim AOL As String = Functions.RepairString(txtAOL.Text)
            Dim ICQ As String = Functions.RepairString(txtICQ.Text)
            Dim Yahoo As String = Functions.RepairString(txtYahoo.Text)
            Dim MSN As String = Functions.RepairString(txtMSN.Text)
            Dim Signature As String = Functions.RepairString(txtSignature.Text)
            Dim ShowSignature As String = CLng(txtShowSignature.SelectedValue)
            Dim RealName As String = Functions.RepairString(txtRealName.Text)
            Dim Location As String = Functions.RepairString(txtLocation.Text)
            Dim HomePage As String = Functions.RepairString(txtHomePage.Text)
            Dim FavoriteSite As String = Functions.RepairString(txtFavoriteSite.Text)
            Dim Occupation As String = Functions.RepairString(txtOccupation.Text)
            Dim Sex As String = Functions.RepairString(txtSex.SelectedValue)
            Dim Age As String = Functions.RepairString(txtAge.Text)
            Dim Birthday As String = Functions.RepairString(txtBirthday.Text)
            Dim Photo As String = Functions.RepairString(txtPhoto.Text)
            Dim Notes As String = Functions.RepairString(txtNotes.Text)
            Dim Avatar As String = CLng(Request.Form("txtAvatar"))
            Dim ShowAvatar As String = CLng(txtShowAvatar.SelectedValue)
            Dim AllowCustomAvatar As String = CLng(txtAllowCustomAvatar.SelectedValue)
            Dim UseCustomAvatar As String = CLng(txtUseCustomAvatar.SelectedValue)

            UsernameLabel.Text = "Profile Updated"
            EditProfilePanel.Visible = "false"
            ConfirmationPanel.Visible = "true"

            Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_POSTS = " & Posts & ", MEMBER_LEVEL = " & Level & ", MEMBER_TITLE = '" & Title & "', MEMBER_RANKING = " & Ranking & ", MEMBER_TITLE_ALLOWCUSTOM = " & AllowTitle & ", MEMBER_TITLE_USECUSTOM = " & UseTitle & ", MEMBER_EMAIL = '" & Email & "', MEMBER_EMAIL_SHOW = " & ShowEmail & ", MEMBER_IM_AOL = '" & AOL & "', MEMBER_IM_ICQ = '" & ICQ & "', MEMBER_IM_YAHOO = '" & Yahoo & "', MEMBER_IM_MSN = '" & MSN & "', MEMBER_SIGNATURE = '" & Signature & "', MEMBER_SIGNATURE_SHOW = " & ShowSignature & ", MEMBER_REALNAME = '" & RealName & "', MEMBER_LOCATION = '" & Location & "', MEMBER_HOMEPAGE = '" & HomePage & "', MEMBER_FAVORITESITE = '" & FavoriteSite & "', MEMBER_OCCUPATION = '" & Occupation & "', MEMBER_SEX = '" & Sex & "', MEMBER_AGE = '" & Age & "', MEMBER_BIRTHDAY = '" & Birthday & "', MEMBER_PHOTO = '" & Photo & "', MEMBER_NOTES = '" & Notes & "', MEMBER_AVATAR = " & Avatar & ", MEMBER_AVATAR_SHOW = " & ShowAvatar & ", MEMBER_AVATAR_ALLOWCUSTOM = " & AllowCustomAvatar & ", MEMBER_AVATAR_USECUSTOM = " & UseCustomAvatar & " WHERE MEMBER_ID = " & Request.QueryString("ID"))

            If ((Level <> "2") And (Level <> "3")) Then
                Database.Write("DELETE FROM " & Database.DBPrefix & "_PRIVILEGED WHERE MEMBER_ID = " & Request.QueryString("ID"))
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' Profile - Codebehind For profile.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class Profile
        Inherits System.Web.UI.Page

        Public ProfileTop As System.Web.UI.WebControls.Repeater
        Public ProfilePhotos As System.Web.UI.WebControls.DataList
        Public ProfilePhotosPanel As System.Web.UI.WebControls.PlaceHolder
        Public ProfileBottom As System.Web.UI.WebControls.Repeater
        Public BlogsListing As System.Web.UI.WebControls.Repeater
        Public RecentPosts As System.Web.UI.WebControls.DataGrid
        Public TopicsPanel As System.Web.UI.WebControls.Panel
        Public BlogsNotesPanel As System.Web.UI.WebControls.PlaceHolder
        Public PagePanel As System.Web.UI.WebControls.Panel
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Public MemberNotesText As String = ""

        Public DMGSettings As DMGForums.Global.Settings

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If (Not Functions.IsInteger(Request.QueryString("ID"))) Then
                    Response.Redirect("default.aspx")
                Else
                    If ((Settings.HideMembers = 0) Or (Session("UserLogged") = "1")) Then
                        Dim ProfileReader As OdbcDataReader = Database.Read("SELECT MEMBER_USERNAME, MEMBER_NOTES FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL <> -1 and MEMBER_ID = " & Request.QueryString("ID"), 1)
                        If (ProfileReader.HasRows()) Then
                            While ProfileReader.Read()
                                DMGSettings.CustomTitle = ProfileReader("MEMBER_USERNAME").ToString()
                                MemberNotesText = ProfileReader("MEMBER_NOTES").ToString()
                            End While
                        Else
                            Response.Redirect("default.aspx")
                        End If
                        ProfileReader.Close()

                        ProfileTop.DataSource = Database.Read("SELECT M.MEMBER_ID, M.MEMBER_USERNAME, M.MEMBER_LOCATION, M.MEMBER_POSTS, M.MEMBER_DATE_JOINED, M.MEMBER_AVATAR_USECUSTOM, M.MEMBER_AVATAR_ALLOWCUSTOM, M.MEMBER_AVATAR_CUSTOMLOADED, M.MEMBER_TITLE_USECUSTOM, M.MEMBER_TITLE_ALLOWCUSTOM, M.MEMBER_TITLE, A.AVATAR_IMAGE, M.MEMBER_AVATAR_CUSTOMTYPE, M.MEMBER_AVATAR_SHOW, M.MEMBER_PHOTO, M.MEMBER_LEVEL, M.MEMBER_RANKING FROM " & Database.DBPrefix & "_MEMBERS M Left Outer Join " & Database.DBPrefix & "_AVATARS A on M.MEMBER_AVATAR = A.AVATAR_ID WHERE M.MEMBER_ID = " & Request.QueryString("ID"), 1)
                        ProfileTop.DataBind()
                        ProfileTop.DataSource.Close()

                        ProfilePhotos.DataSource = Database.Read("SELECT PHOTO_ID, PHOTO_EXTENSION, PHOTO_DESCRIPTION FROM " & Database.DBPrefix & "_MEMBER_PHOTOS WHERE MEMBER_ID = " & Request.QueryString("ID") & " ORDER BY PHOTO_ID")
                        ProfilePhotos.DataBind()
                        If ((ProfilePhotos.Items.Count = 0) Or (Settings.MemberPhotoSize = 0)) Then
                            ProfilePhotos.Visible = "false"
                            ProfilePhotosPanel.Visible = "false"
                        End If
                        ProfilePhotos.DataSource.Close()

                        ProfileBottom.DataSource = Database.Read("SELECT MEMBER_EMAIL, MEMBER_EMAIL_SHOW, MEMBER_HOMEPAGE, MEMBER_DATE_JOINED, MEMBER_DATE_LASTVISIT, MEMBER_POSTS, MEMBER_IM_AOL, MEMBER_IM_ICQ, MEMBER_IM_MSN, MEMBER_IM_YAHOO, MEMBER_REALNAME, MEMBER_LOCATION, MEMBER_AGE, MEMBER_BIRTHDAY, MEMBER_SEX, MEMBER_OCCUPATION, MEMBER_FAVORITESITE FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Request.QueryString("ID"), 1)
                        ProfileBottom.DataBind()
                        ProfileBottom.DataSource.Close()

                        Dim HasBlogs As Boolean = True
                        BlogsListing.DataSource = Database.Read("SELECT BLOG_ID, BLOG_TITLE, BLOG_DATE, BLOG_REPLIES FROM " & Database.DBPrefix & "_BLOG_TOPICS WHERE BLOG_AUTHOR = " & Request.QueryString("ID") & " ORDER BY BLOG_DATE DESC", 10)
                        BlogsListing.DataBind()
                        If (BlogsListing.Items.Count = 0) Then
                            BlogsListing.Visible = "false"
                            HasBlogs = False
                        End If
                        BlogsListing.DataSource.Close()

                        If ((Not HasBlogs) And (MemberNotesText.Length() = 0)) Then
                            BlogsNotesPanel.Visible = "false"
                        End If

                        Dim IDList As String
                        IDList = "-1"
                        Dim TopicReader As OdbcDataReader = Database.Read("SELECT TOPIC_ID FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_CONFIRMED = 1 AND TOPIC_AUTHOR = " & Request.QueryString("ID"))
                        While (TopicReader.Read())
                            IDList &= ", "
                            IDList &= TopicReader("TOPIC_ID")
                        End While
                        TopicReader.Close()

                        Dim ReplyReader As OdbcDataReader = Database.Read("SELECT TOPIC_ID FROM " & Database.DBPrefix & "_REPLIES WHERE REPLY_AUTHOR = " & Request.QueryString("ID"))
                        While (ReplyReader.Read())
                            IDList &= ", "
                            IDList &= ReplyReader("TOPIC_ID")
                        End While
                        ReplyReader.Close()

                        RecentPosts.DataSource = Database.Read("SELECT T.TOPIC_ID, T.TOPIC_SUBJECT, T.TOPIC_AUTHOR, F.FORUM_ID, F.FORUM_NAME FROM (" & Database.DBPrefix & "_FORUMS F LEFT OUTER JOIN " & Database.DBPrefix & "_TOPICS T ON F.FORUM_ID = T.FORUM_ID) WHERE (T.TOPIC_ID IN (" & IDList & ")) ORDER BY T.TOPIC_LASTPOST_DATE DESC", 5)
                        RecentPosts.DataBind()
                        If (RecentPosts.Items.Count = 0) Then
                            TopicsPanel.Visible = "false"
                        End If
                        RecentPosts.DataSource.Close()
                    Else
                        PagePanel.Visible = "false"
                        NoItemsDiv.InnerHtml = "Only Members Can View This Page.<br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page.<br /><br />"
                    End If
                End If
            End If
        End Sub

        Sub SendPM(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("pm_send.aspx?SendTo=" & sender.CommandArgument)
        End Sub

        Sub SendEmail(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("sendmail.aspx?ID=" & sender.CommandArgument)
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' Avatars - Codebehind For avatars.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class Avatars
        Inherits System.Web.UI.Page

        Public Avatars As System.Web.UI.WebControls.DataList
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                Avatars.DataSource = Database.Read("SELECT * FROM " & Database.DBPrefix & "_AVATARS ORDER BY AVATAR_NAME")
                Avatars.DataBind()
                If (Avatars.Items.Count = 0) Then
                    NoItemsDiv.InnerHtml = "There Are No Items To Display<br /><br />"
                    Avatars.Visible = "false"
                End If
                Avatars.DataSource.Close()
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' Validate - Codebehind For validate.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class Validate
        Inherits System.Web.UI.Page

        Public txtValidationString As System.Web.UI.WebControls.TextBox
        Public PagePanel As System.Web.UI.WebControls.Panel
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If (Session("ValidateUserID") Is Nothing) Or (Session("ValidateUserID") = -1) Then
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "You must log in to validate an account.<br /><br />"
                End If
            End If
        End Sub

        Sub SubmitValidation(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_PASSWORD FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Session("ValidateUserID") & " and MEMBER_VALIDATION_STRING = '" & txtValidationString.Text.ToString() & "'", 1)
            If Reader.HasRows Then
                While (Reader.Read())
                    Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_LEVEL = 1, MEMBER_VALIDATED = 1, MEMBER_DATE_LASTVISIT = " & Database.GetTimeStamp() & ", MEMBER_IP_LAST = '" & Request.UserHostAddress() & "' WHERE MEMBER_ID = " & Session("ValidateUserID"))

                    Session("ValidateUserID") = "-1"

                    Dim aCookie As New System.Web.HttpCookie("dmgforums")
                    aCookie.Values("fighter") = Functions.Encrypt(DateTime.Now())
                    aCookie.Values("mukul") = Reader("MEMBER_ID").ToString()
                    aCookie.Values("dooder") = Functions.Encrypt(DateTime.Now())
                    aCookie.Values("gupta") = Reader("MEMBER_PASSWORD").ToString()
                    Session("UserName") = Reader("MEMBER_USERNAME").ToString()
                    Session("UserLogged") = "1"
                    Session("UserID") = Reader("MEMBER_ID").ToString()
                    Session("UserLevel") = "1"
                    Session("ActiveLevel") = 1
                    Session("ActiveTime") = Database.DatabaseTimestamp()
                    aCookie.Expires = DateTime.Now.AddDays(30)
                    Response.Cookies.Add(aCookie)
                End While
                PagePanel.Visible = "false"
                NoItemsDiv.InnerHtml = Functions.CustomMessage("MESSAGE_VALIDATION") & "<br /><br />"
            Else
                Session("ValidateUserID") = "-1"
                PagePanel.Visible = "false"
                NoItemsDiv.InnerHtml = "The validation key was not entered correctly.  Please check your key and try to log in again.<br /><br />"
            End If
            Reader.Close()
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' SendEmail - Codebehind For sendmail.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class SendEmail
        Inherits System.Web.UI.Page

        Public txtTo As System.Web.UI.WebControls.Label
        Public txtSubject As System.Web.UI.WebControls.TextBox
        Public txtMessage As System.Web.UI.WebControls.TextBox
        Public UserEmail As String = ""
        Public PagePanel As System.Web.UI.WebControls.PlaceHolder
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If ((Functions.IsInteger(Request.QueryString("ID"))) And (Session("UserLogged") = "1")) Then
                If ((Settings.EmailAllowSend = 1) Or (Session("UserLevel") = "3")) Then
                    Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_USERNAME, MEMBER_EMAIL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Request.QueryString("ID"), 1)
                    If Reader.HasRows Then
                        While (Reader.Read())
                            txtTo.Text = Reader("MEMBER_USERNAME").ToString()
                            UserEmail = Reader("MEMBER_EMAIL").ToString()
                        End While
                    Else
                        Response.Redirect("default.aspx")
                    End If
                    Reader.Close()
                Else
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "E-Mail Functionality Is Disabled On This Site.<br /><br />"
                End If
            Else
                Response.Redirect("default.aspx")
            End If
        End Sub

        Sub SubmitEmail(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If (txtSubject.Text <> "") And (txtMessage.Text <> "") And (txtSubject.Text <> " ") And (txtMessage.Text <> " ") Then
                Dim err As Integer = Functions.SendEmail(UserEmail, Settings.EmailAddress, Settings.PageTitle & " - A User Has Sent You A Message", "SENT FROM: " & Settings.PageTitle & "<br />AUTHOR: " & Session("UserName") & "<br />SUBJECT: " & txtSubject.Text & "<br /><br />--------------<br /><br />" & Functions.FormatString(txtMessage.Text))
                PagePanel.Visible = "false"

                If (err = 0) Then
                    NoItemsDiv.InnerHtml = "E-Mail Message Sent Successfully<br /><br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page<br /><br />"
                Else
                    NoItemsDiv.InnerHtml = "ERROR: The SMTP Server For This Site Is Not Configured Correctly Or Does Not Allow Mail Forwarding<br /><br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page<br /><br />"
                End If
            Else
                NoItemsDiv.InnerHtml = "All form fields must contain data.<br /><br />"
            End If
        End Sub
    End Class


    '---------------------------------------------------------------------------------------------------
    ' UserCP - Codebehind For usercp.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class UserCP
        Inherits System.Web.UI.Page

        Public ViewProfileLink As System.Web.UI.WebControls.LinkButton
        Public EditProfileLink As System.Web.UI.WebControls.LinkButton
        Public AddBlogLink As System.Web.UI.WebControls.LinkButton
        Public EditBlogsLink As System.Web.UI.WebControls.LinkButton
        Public EditNotesLink As System.Web.UI.WebControls.LinkButton
        Public EditPhotosLink As System.Web.UI.WebControls.LinkButton
        Public ResetPasswordLink As System.Web.UI.WebControls.LinkButton
        Public DeleteMemberLink As System.Web.UI.WebControls.LinkButton
        Public BanMemberLink As System.Web.UI.WebControls.LinkButton
        Public CalculatePostsLink As System.Web.UI.WebControls.LinkButton
        Public UserCPLinks As System.Web.UI.WebControls.PlaceHolder
        Public NewBlogForm As System.Web.UI.WebControls.PlaceHolder
        Public EditBlogLinks As System.Web.UI.WebControls.PlaceHolder
        Public EditBlogForm As System.Web.UI.WebControls.PlaceHolder
        Public EditNotesForm As System.Web.UI.WebControls.PlaceHolder
        Public EditPhotosForm As System.Web.UI.WebControls.PlaceHolder
        Public BanMemberPanel As System.Web.UI.WebControls.PlaceHolder
        Public DeleteMemberPanel As System.Web.UI.WebControls.PlaceHolder
        Public ResetPasswordPanel As System.Web.UI.WebControls.PlaceHolder
        Public ProfilePhotos As System.Web.UI.WebControls.DataList
        Public PhotosPanel As System.Web.UI.WebControls.PlaceHolder
        Public PMPanel As System.Web.UI.WebControls.PlaceHolder
        Public AdminPanel As System.Web.UI.WebControls.PlaceHolder
        Public CPTitle As System.Web.UI.WebControls.Label
        Public txtNotes As System.Web.UI.WebControls.TextBox
        Public txtBlogTopic As System.Web.UI.WebControls.TextBox
        Public txtBlogText As System.Web.UI.WebControls.TextBox
        Public SubscribedThreads As System.Web.UI.WebControls.Repeater
        Public PasswordSubmitButton As System.Web.UI.WebControls.Button
        Public BanSubmitButton As System.Web.UI.WebControls.Button
        Public DeleteSubmitButton As System.Web.UI.WebControls.Button
        Public txtNewPassword As System.Web.UI.WebControls.TextBox
        Public txtDeletePosts As System.Web.UI.WebControls.DropDownList
        Public txtFreeUsername As System.Web.UI.WebControls.DropDownList
        Public txtBanIP As System.Web.UI.WebControls.DropDownList
        Public PagePanel As System.Web.UI.WebControls.PlaceHolder
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If ((Functions.IsInteger(Request.QueryString("ID"))) And ((Session("UserLogged") = "1") And (Session("UserID") = Request.QueryString("ID"))) Or (Session("UserLevel") = "3")) Then
                    UserCPLinks.Visible = "true"
                    ViewProfileLink.CommandArgument = Request.QueryString("ID")
                    EditProfileLink.CommandArgument = Request.QueryString("ID")
                    AddBlogLink.CommandArgument = Request.QueryString("ID")
                    EditBlogsLink.CommandArgument = Request.QueryString("ID")
                    EditNotesLink.CommandArgument = Request.QueryString("ID")
                    EditPhotosLink.CommandArgument = Request.QueryString("ID")
                    ResetPasswordLink.CommandArgument = Request.QueryString("ID")
                    DeleteMemberLink.CommandArgument = Request.QueryString("ID")
                    CalculatePostsLink.CommandArgument = Request.QueryString("ID")
                    BanMemberLink.CommandArgument = Request.QueryString("ID")

                    Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_USERNAME FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Request.QueryString("ID"))
                    If Reader.HasRows() Then
                        While Reader.Read()
                            CPTitle.Text = Reader("MEMBER_USERNAME").ToString() & "'s Control Panel"
                        End While
                    Else
                        Response.Redirect("default.aspx")
                    End If
                    Reader.Close()

                    If (Session("UserLevel") = "3") Then
                        AdminPanel.Visible = "true"
                    End If

                    If (Settings.MemberPhotoSize = 0) Then
                        PhotosPanel.Visible = "false"
                    End If

                    If (Session("UserID") <> Request.QueryString("ID")) Then
                        PMPanel.Visible = "false"
                        SubscribedThreads.Visible = "false"
                    End If

                    SubscribedThreads.DataSource = Database.Read("SELECT T.TOPIC_ID, T.TOPIC_SUBJECT, T.TOPIC_AUTHOR, T.TOPIC_STATUS, M.MEMBER_USERNAME as TOPIC_AUTHOR_NAME, T.TOPIC_REPLIES, T.TOPIC_VIEWS, T.TOPIC_STICKY, T.TOPIC_LASTPOST_AUTHOR, MEMBERS_1.MEMBER_USERNAME as TOPIC_LASTPOST_NAME, T.TOPIC_LASTPOST_DATE FROM " & Database.DBPrefix & "_MEMBERS M, " & Database.DBPrefix & "_TOPICS T, " & Database.DBPrefix & "_MEMBERS as MEMBERS_1, " & Database.DBPrefix & "_SUBSCRIPTIONS S WHERE M.MEMBER_ID = T.TOPIC_AUTHOR and T.TOPIC_LASTPOST_AUTHOR = MEMBERS_1.MEMBER_ID and S.SUB_MEMBER = " & Session("UserID") & " and T.TOPIC_STATUS <> 0 and T.TOPIC_CONFIRMED <> 0 and S.SUB_TOPIC = T.TOPIC_ID ORDER BY T.TOPIC_STICKY DESC, T.TOPIC_LASTPOST_DATE DESC")
                    SubscribedThreads.DataBind()
                    If (SubscribedThreads.Items.Count = 0) Then
                        SubscribedThreads.Visible = "false"
                    End If
                    SubscribedThreads.DataSource.Close()
                Else
                    Response.Redirect("default.aspx")
                End If
            End If
        End Sub

        Sub ViewProfile(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("profile.aspx?ID=" & sender.CommandArgument)
        End Sub

        Sub ViewPM(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("pm_inbox.aspx")
        End Sub

        Sub CreatePM(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("pm_send.aspx")
        End Sub

        Sub EditProfile(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("editprofile.aspx?ID=" & sender.CommandArgument)
        End Sub

        Sub EditNotes(ByVal sender As System.Object, ByVal e As System.EventArgs)
            UserCPLinks.Visible = "false"
            SubscribedThreads.Visible = "false"
            EditNotesForm.Visible = "true"

            Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_NOTES FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & sender.CommandArgument)
            While Reader.Read()
                txtNotes.Text = Server.HtmlDecode(Reader("MEMBER_NOTES").ToString())
            End While
            Reader.Close()
        End Sub

        Sub EditMemberPhotos(ByVal sender As System.Object, ByVal e As System.EventArgs)
            UserCPLinks.Visible = "false"
            SubscribedThreads.Visible = "false"
            EditPhotosForm.Visible = "true"

            ProfilePhotos.DataSource = Database.Read("SELECT PHOTO_ID, PHOTO_EXTENSION FROM " & Database.DBPrefix & "_MEMBER_PHOTOS WHERE MEMBER_ID = " & sender.CommandArgument & " ORDER BY PHOTO_ID")
            ProfilePhotos.DataBind()
            If (ProfilePhotos.Items.Count = 0) Then
                ProfilePhotos.Visible = "false"
            End If
            ProfilePhotos.DataSource.Close()
        End Sub

        Sub DeleteMemberPhoto(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim Reader As OdbcDataReader = Database.Read("SELECT PHOTO_ID, PHOTO_EXTENSION FROM " & Database.DBPrefix & "_MEMBER_PHOTOS WHERE PHOTO_ID = " & sender.CommandArgument)
            While Reader.Read()
                Database.Write("DELETE " & Database.DBPrefix & "_FILES FROM " & Database.DBPrefix & "_FILES, " & Database.DBPrefix & "_FOLDERS WHERE " & Database.DBPrefix & "_FILES.FILE_FOLDER = " & Database.DBPrefix & "_FOLDERS.FOLDER_ID AND " & Database.DBPrefix & "_FILES.FILE_NAME = '" & Reader("PHOTO_ID").ToString() & "." & Reader("PHOTO_EXTENSION").ToString() & "' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_NAME = 'memberphotos' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_PARENT = 0")
                Database.Write("DELETE " & Database.DBPrefix & "_FILES FROM " & Database.DBPrefix & "_FILES, " & Database.DBPrefix & "_FOLDERS WHERE " & Database.DBPrefix & "_FILES.FILE_FOLDER = " & Database.DBPrefix & "_FOLDERS.FOLDER_ID AND " & Database.DBPrefix & "_FILES.FILE_NAME = '" & Reader("PHOTO_ID").ToString() & "_s." & Reader("PHOTO_EXTENSION").ToString() & "' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_NAME = 'memberphotos' AND " & Database.DBPrefix & "_FOLDERS.FOLDER_PARENT = 0")
                File.Delete(MapPath("memberphotos/" & Reader("PHOTO_ID").ToString() & "." & Reader("PHOTO_EXTENSION").ToString()))
                File.Delete(MapPath("memberphotos/" & Reader("PHOTO_ID").ToString() & "_s." & Reader("PHOTO_EXTENSION").ToString()))
            End While
            Reader.Close()
            Database.Write("DELETE FROM " & Database.DBPrefix & "_MEMBER_PHOTOS WHERE PHOTO_ID = " & sender.CommandArgument)

            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Photo Deleted Successfully<br /><br /><a href=""usercp.aspx?ID=" & Request.QueryString("ID") & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
        End Sub

        Sub SubmitNotes(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim NotesText As String = Functions.RepairString(txtNotes.Text)
            Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_NOTES = '" & NotesText & "' WHERE MEMBER_ID = " & Request.QueryString("ID"))

            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Profile Text Edited Successfully<br /><br /><a href=""usercp.aspx?ID=" & Request.QueryString("ID") & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
        End Sub

        Sub AddBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            UserCPLinks.Visible = "false"
            SubscribedThreads.Visible = "false"
            NewBlogForm.Visible = "true"
        End Sub

        Sub SubmitBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If (txtBlogTopic.Text = "") Or (txtBlogText.Text = "") Or (txtBlogTopic.Text = " ") Or (txtBlogText.Text = " ") Then
                Functions.MessageBox("You must enter a subject and text")
            Else
                Dim theTopic As String = Functions.RepairString(txtBlogTopic.Text)
                Dim theText As String = Functions.RepairString(txtBlogText.Text)

                Database.Write("INSERT INTO " & Database.DBPrefix & "_BLOG_TOPICS (BLOG_AUTHOR, BLOG_DATE, BLOG_REPLIES, BLOG_TITLE, BLOG_TEXT) VALUES (" & Request.QueryString("ID") & ", " & Database.GetTimeStamp() & ", 0, '" & theTopic & "', '" & theText & "')")

                Dim PhysicalUrl As String = System.Web.HttpContext.Current.Request.PhysicalPath
                Dim PhysicalPath As String = Left(PhysicalUrl, Len(PhysicalUrl) - InStr(1, StrReverse(PhysicalUrl), "\"))

                Try
                    If Not (System.IO.Directory.Exists(PhysicalPath & "\blogs\" & Session("UserName"))) Then
                        System.IO.Directory.CreateDirectory(PhysicalPath & "\blogs\" & Session("UserName"))
                        System.IO.File.Copy(PhysicalPath & "\blogs\Default.aspx", PhysicalPath & "\blogs\" & Session("UserName") & "\Default.aspx", True)
                    End If
                Catch e1 As System.Security.SecurityException
                Catch e2 As Exception
                End Try

                PagePanel.Visible = "false"
                NoItemsDiv.InnerHtml = "New Blog Entry Added Successfully<br /><br /><a href=""usercp.aspx?ID=" & Request.QueryString("ID") & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
            End If
        End Sub

        Sub EditBlogs(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("blogslist.aspx?ID=" & sender.CommandArgument)
        End Sub

        Sub ResetPasswordConfirm(ByVal sender As System.Object, ByVal e As System.EventArgs)
            UserCPLinks.Visible = "false"
            SubscribedThreads.Visible = "false"
            ResetPasswordPanel.Visible = "true"
            PasswordSubmitButton.CommandArgument = Request.QueryString("ID")
        End Sub

        Sub ResetPassword(ByVal sender As System.Object, ByVal e As System.EventArgs)
            PagePanel.Visible = "false"
            Dim Password As String = Functions.Encrypt(txtNewPassword.Text)
            Dim MemberLevel As Integer = 0
            Dim MemberReader As OdbcDataReader = Database.Read("SELECT MEMBER_LEVEL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & sender.CommandArgument)
            While MemberReader.Read()
                MemberLevel = MemberReader("MEMBER_LEVEL")
            End While
            MemberReader.Close()
            If ((Session("UserLevel") > MemberLevel) Or (Session("UserID") = Request.QueryString("ID"))) Then
                Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_PASSWORD = '" & Password & "' WHERE MEMBER_ID = " & sender.CommandArgument)
                NoItemsDiv.InnerHtml = "Password Reset Successfully.<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
            Else
                NoItemsDiv.InnerHtml = "You Do Not Have Rights To Change This Member's Password.<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
            End If
        End Sub

        Sub BanMemberConfirm(ByVal sender As System.Object, ByVal e As System.EventArgs)
            UserCPLinks.Visible = "false"
            SubscribedThreads.Visible = "false"
            BanMemberPanel.Visible = "true"
            BanSubmitButton.CommandArgument = Request.QueryString("ID")
        End Sub

        Sub BanMember(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim MemberID As Integer = sender.CommandArgument
            Dim MemberUsername As String = ""
            Dim MemberLevel As Integer = 0
            Dim MemberIP As String = ""
            Dim MemberReader As OdbcDataReader = Database.Read("SELECT MEMBER_USERNAME, MEMBER_LEVEL, MEMBER_IP_LAST FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & MemberID)
            While MemberReader.Read()
                MemberLevel = MemberReader("MEMBER_LEVEL")
                MemberUsername = MemberReader("MEMBER_USERNAME").ToString()
                MemberIP = MemberReader("MEMBER_IP_LAST").ToString()
            End While
            MemberReader.Close()

            If (Session("UserLevel") > MemberLevel) Then
                If (txtBanIP.SelectedValue = 0) Then
                    Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_LEVEL = 0 WHERE MEMBER_ID = " & MemberID)
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_PRIVILEGED WHERE MEMBER_ID = " & MemberID)
                    NoItemsDiv.InnerHtml = MemberUsername & " Has Been Successfully Banned.<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
                Else
                    Dim Message As String = "The Following Users With IP " & MemberIP & " Were Banned<br /><br />"
                    Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_LEVEL < " & Session("UserLevel") & " AND ((MEMBER_IP_ORIGINAL = '" & MemberIP & "') or (MEMBER_IP_LAST = '" & MemberIP & "'))")
                    While Reader.Read()
                        Message &= Reader("MEMBER_USERNAME").ToString() & "<br />"
                        Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_LEVEL = 0 WHERE MEMBER_ID = " & Reader("MEMBER_ID"))
                        Database.Write("DELETE FROM " & Database.DBPrefix & "_PRIVILEGED WHERE MEMBER_ID = " & Reader("MEMBER_ID"))
                        Database.Write("INSERT INTO " & Database.DBPrefix & "_BANNED_IP (MEMBER_ID, IP_ADDRESS) VALUES (" & Reader("MEMBER_ID") & ", '" & MemberIP & "')")
                    End While
                    Reader.Close()
                    NoItemsDiv.InnerHtml = Message & "<br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
                End If
            Else
                NoItemsDiv.InnerHtml = "You Do Not Have Rights To Ban This Member.<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
            End If

            PagePanel.Visible = "false"
            BanMemberPanel.Visible = "false"
        End Sub

        Sub DeleteMemberConfirm(ByVal sender As System.Object, ByVal e As System.EventArgs)
            UserCPLinks.Visible = "false"
            SubscribedThreads.Visible = "false"
            DeleteMemberPanel.Visible = "true"
            DeleteSubmitButton.CommandArgument = Request.QueryString("ID")
        End Sub

        Sub DeleteMember(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If ((Session("UserID") <> sender.CommandArgument) And (sender.CommandArgument <> 1)) Then
                If ((txtDeletePosts.SelectedValue = 0) And (txtFreeUsername.SelectedValue = 0)) Then
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_PRIVILEGED WHERE MEMBER_ID = " & sender.CommandArgument)
                    Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_LEVEL = -1 WHERE MEMBER_ID = " & sender.CommandArgument)
                    NoItemsDiv.InnerHtml = "Member Deleted Successfully<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
                ElseIf ((txtDeletePosts.SelectedValue = 0) And (txtFreeUsername.SelectedValue = 1)) Then
                    NoItemsDiv.InnerHtml = "Error: You must delete a member's posts to free the username.<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
                ElseIf ((txtDeletePosts.SelectedValue = 1) And (txtFreeUsername.SelectedValue = 0)) Then
                    Dim Reader As OdbcDataReader = Database.Read("SELECT TOPIC_ID FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_AUTHOR = " & sender.CommandArgument)
                    While Reader.Read()
                        Database.Write("DELETE FROM " & Database.DBPrefix & "_REPLIES WHERE TOPIC_ID = " & Reader("TOPIC_ID"))
                    End While
                    Reader.Close()
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_AUTHOR = " & sender.CommandArgument)
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_REPLIES WHERE REPLY_AUTHOR = " & sender.CommandArgument)
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_PRIVILEGED WHERE MEMBER_ID = " & sender.CommandArgument)
                    Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_LEVEL = -1 WHERE MEMBER_ID = " & sender.CommandArgument)
                    NoItemsDiv.InnerHtml = "Member Deleted Successfully<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
                Else
                    Dim Reader As OdbcDataReader = Database.Read("SELECT TOPIC_ID FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_AUTHOR = " & sender.CommandArgument)
                    While Reader.Read()
                        Database.Write("DELETE FROM " & Database.DBPrefix & "_REPLIES WHERE TOPIC_ID = " & Reader("TOPIC_ID"))
                    End While
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_AUTHOR = " & sender.CommandArgument)
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_REPLIES WHERE REPLY_AUTHOR = " & sender.CommandArgument)
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_PRIVILEGED WHERE MEMBER_ID = " & sender.CommandArgument)
                    Database.Write("DELETE FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & sender.CommandArgument)
                    NoItemsDiv.InnerHtml = "Member Deleted Successfully<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
                End If
            Else
                NoItemsDiv.InnerHtml = "You Can Not Delete Yourself Or The Original Admin<br /><br /><a href=""usercp.aspx?ID=" & sender.CommandArgument & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
            End If

            Functions.UpdateCounts(1, 0, 0, 0)

            PagePanel.Visible = "false"
            DeleteMemberPanel.Visible = "false"
        End Sub

        Sub CalculatePosts(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Database.Write("UPDATE " & Database.DBPrefix & "_MEMBERS SET MEMBER_POSTS = ((SELECT COUNT(*) as TheCount FROM " & Database.DBPrefix & "_TOPICS WHERE TOPIC_AUTHOR = " & sender.CommandArgument & ")+(SELECT COUNT(*) as TheCount2 FROM " & Database.DBPrefix & "_REPLIES WHERE REPLY_AUTHOR = " & sender.CommandArgument & ")) WHERE MEMBER_ID = " & sender.CommandArgument)
            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Post Count Calculated Successfully<br /><br /><a href=""usercp.aspx?ID=" & Request.QueryString("ID") & """>Click Aquí</a> To Return To The Control Panel<br /><br />"
        End Sub

        Sub CancelDeleteMember(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Response.Redirect("usercp.aspx?ID=" & Request.QueryString("ID"))
        End Sub

    End Class


    '---------------------------------------------------------------------------------------------------
    ' BlogForward - Codebehind For /blogs/MEMBERNAME/default.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class BlogForward
        Inherits System.Web.UI.Page

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim MemberID As Integer = 0
            Dim MemberName As String = GetText(System.Web.HttpContext.Current.Request.RawUrl, "/blogs/", "/Default.aspx")
            Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_ID FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_USERNAME = '" & MemberName & "'")
            If Reader.HasRows() Then
                While Reader.Read()
                    MemberID = Reader("MEMBER_ID")
                End While
                Response.Redirect("../../blogslist.aspx?ID=" & MemberID)
            Else
                Response.Redirect("../../default.aspx")
            End If
            Reader.Close()
        End Sub

        Function GetText(ByVal TheString As String, ByVal StartTag As String, ByVal EndTag As String) As String
            Dim FirstChar As Integer = TheString.IndexOf(StartTag)
            Dim StartNumber As Integer = FirstChar + StartTag.Length()
            TheString = TheString.Substring(StartNumber)
            Dim EndNumber As Integer = TheString.IndexOf(EndTag)
            If (EndNumber >= 0) And (FirstChar >= 0) Then
                Return TheString.Substring(0, EndNumber)
            Else
                Return ""
            End If
        End Function
    End Class


    '---------------------------------------------------------------------------------------------------
    ' Blogs - Codebehind For blogs.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class Blogs
        Inherits System.Web.UI.Page

        Public BlogUser As System.Web.UI.WebControls.Label
        Public BlogCategory As System.Web.UI.WebControls.Label
        Public BlogTitle As System.Web.UI.WebControls.Label
        Public BlogTopic As System.Web.UI.WebControls.Repeater
        Public BlogReplies As System.Web.UI.WebControls.Repeater
        Public txtCommentText As System.Web.UI.WebControls.TextBox
        Public AuthorLevel As Integer = 0
        Public txtBlogTopic As System.Web.UI.WebControls.TextBox
        Public txtBlogText As System.Web.UI.WebControls.TextBox
        Public BlogSubmitButton As System.Web.UI.WebControls.Button
        Public FinalDeleteButton As System.Web.UI.WebControls.Button
        Public EditBlogForm As System.Web.UI.WebControls.PlaceHolder
        Public DeleteBlogForm As System.Web.UI.WebControls.PlaceHolder
        Public txtBlogReplyText As System.Web.UI.WebControls.TextBox
        Public BlogReplySubmitButton As System.Web.UI.WebControls.Button
        Public FinalDeleteReplyButton As System.Web.UI.WebControls.Button
        Public EditBlogReplyForm As System.Web.UI.WebControls.PlaceHolder
        Public DeleteBlogReplyForm As System.Web.UI.WebControls.PlaceHolder
        Public CommentForm As System.Web.UI.WebControls.PlaceHolder
        Public PagePanel As System.Web.UI.WebControls.PlaceHolder
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Public DMGSettings As DMGForums.Global.Settings

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If ((Settings.HideMembers = 0) Or (Session("UserLogged") = "1")) Then
                    If (Functions.IsInteger(Request.QueryString("ID"))) Then
                        Dim Reader As OdbcDataReader = Database.Read("SELECT M.MEMBER_USERNAME, M.MEMBER_LEVEL, B.BLOG_AUTHOR, B.BLOG_TITLE FROM " & Database.DBPrefix & "_BLOG_TOPICS B Left Outer Join " & Database.DBPrefix & "_MEMBERS M On B.BLOG_AUTHOR = M.MEMBER_ID WHERE B.BLOG_ID = " & Request.QueryString("ID"), 1)
                        While Reader.Read()
                            AuthorLevel = Reader("MEMBER_LEVEL")
                            BlogUser.Text = "<a href=""profile.aspx?ID=" & Reader("BLOG_AUTHOR").ToString() & """ style=""color:" & Settings.HeaderFontColor & ";"">" & Reader("MEMBER_USERNAME").ToString() & "</a>"
                            BlogCategory.Text = "<a href=""blogslist.aspx?ID=" & Reader("BLOG_AUTHOR").ToString() & """ style=""color:" & Settings.HeaderFontColor & ";"">" & Reader("MEMBER_USERNAME").ToString() & "'s Blogs</a>"
                            BlogTitle.Text = Functions.CurseFilter(Reader("BLOG_TITLE").ToString())
                            DMGSettings.CustomTitle = Reader("MEMBER_USERNAME").ToString() & " - " & Reader("BLOG_TITLE").ToString()
                        End While
                        Reader.Close()

                        BlogTopic.DataSource = Database.Read("SELECT M.MEMBER_USERNAME, B.BLOG_DATE, B.BLOG_TEXT, B.BLOG_AUTHOR, B.BLOG_ID FROM " & Database.DBPrefix & "_BLOG_TOPICS B Left Outer Join " & Database.DBPrefix & "_MEMBERS M On B.BLOG_AUTHOR = M.MEMBER_ID WHERE B.BLOG_ID = " & Request.QueryString("ID"), 1)
                        BlogTopic.DataBind()
                        If (BlogTopic.Items.Count = 0) Then
                            Response.Redirect("default.aspx")
                        End If
                        BlogTopic.DataSource.Close()

                        BlogReplies.DataSource = Database.Read("SELECT M.MEMBER_USERNAME, M.MEMBER_LEVEL, B.BLOG_REPLY_DATE, B.BLOG_REPLY_TEXT, B.BLOG_REPLY_AUTHOR, B.BLOG_REPLY_ID FROM " & Database.DBPrefix & "_BLOG_REPLIES B Left Outer Join " & Database.DBPrefix & "_MEMBERS M On B.BLOG_REPLY_AUTHOR = M.MEMBER_ID WHERE BLOG_ID = " & Request.QueryString("ID") & " ORDER BY BLOG_REPLY_DATE ASC")
                        BlogReplies.DataBind()
                        If (BlogReplies.Items.Count = 0) Then
                            BlogReplies.Visible = "false"
                        End If
                        BlogReplies.DataSource.Close()

                        If (Session("UserLogged") = "1") Then
                            CommentForm.Visible = "true"
                        Else
                            CommentForm.Visible = "false"
                        End If
                    Else
                        Response.Redirect("default.aspx")
                    End If
                Else
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "Only Members Can View This Page.<br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page.<br /><br />"
                End If
            End If
        End Sub

        Sub SubmitComments(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If (txtCommentText.Text <> "") And (txtCommentText.Text <> " ") Then
                Dim Reader As OdbcDataReader = Database.Read("SELECT BLOG_REPLY_ID FROM " & Database.DBPrefix & "_BLOG_REPLIES WHERE (" & Database.GetDateDiff("ss", "BLOG_REPLY_DATE", Database.GetTimeStamp()) & " < " & Settings.SpamFilter & ") AND (BLOG_REPLY_AUTHOR = " & Session("UserID") & ")")
                If Reader.HasRows() Then
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "You Can Not Post More Than Once In " & Settings.SpamFilter & " Seconds.<br /><br /><a href=""blogs.aspx?ID=" & Request.QueryString("ID") & """>Click Aquí</a> To Return To The Blog Entry<br /><br />"
                Else
                    Dim Comments As String = Functions.RepairString(txtCommentText.Text)
                    Database.Write("INSERT INTO " & Database.DBPrefix & "_BLOG_REPLIES (BLOG_ID, BLOG_REPLY_AUTHOR, BLOG_REPLY_DATE, BLOG_REPLY_TEXT) VALUES (" & Request.QueryString("ID") & ", " & Session("UserID") & ", " & Database.GetTimeStamp() & ", '" & Comments & "')")
                    Database.Write("UPDATE " & Database.DBPrefix & "_BLOG_TOPICS SET BLOG_REPLIES = BLOG_REPLIES + 1 WHERE BLOG_ID = " & Request.QueryString("ID"))
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "Comments Added Successfully<br /><br /><a href=""blogs.aspx?ID=" & Request.QueryString("ID") & """>Click Aquí</a> To Return To The Blog Entry<br /><br />"
                End If
                Reader.Close()
            Else
                Functions.MessageBox("You must enter text to post comments.")
            End If
        End Sub

        Sub EditBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            BlogTopic.Visible = "false"
            BlogReplies.Visible = "false"
            CommentForm.Visible = "false"
            EditBlogForm.Visible = "true"
            Dim BlogID As Integer = sender.CommandArgument
            BlogSubmitButton.CommandArgument = BlogID
            Dim Reader As OdbcDataReader = Database.Read("SELECT BLOG_TITLE, BLOG_TEXT FROM " & Database.DBPrefix & "_BLOG_TOPICS WHERE BLOG_ID = " & BlogID, 1)
            While Reader.Read()
                txtBlogTopic.Text = Reader("BLOG_TITLE").ToString()
                txtBlogText.Text = Server.HtmlDecode(Reader("BLOG_TEXT").ToString())
            End While
            Reader.Close()
        End Sub

        Sub SubmitBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim BlogID As Integer = sender.CommandArgument
            Dim theTopic As String = Functions.RepairString(txtBlogTopic.Text)
            Dim theText As String = Functions.RepairString(txtBlogText.Text)
            Database.Write("UPDATE " & Database.DBPrefix & "_BLOG_TOPICS SET BLOG_TITLE = '" & theTopic & "', BLOG_TEXT = '" & theText & "' WHERE BLOG_ID = " & BlogID)
            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Blog Entry Edited Successfully<br /><br /><a href=""blogs.aspx?ID=" & BlogID & """>Click Aquí</a> To Return To The Blog<br /><br />"
        End Sub

        Sub DeleteBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            BlogTopic.Visible = "false"
            BlogReplies.Visible = "false"
            CommentForm.Visible = "false"
            DeleteBlogForm.Visible = "true"
            FinalDeleteButton.CommandArgument = sender.CommandArgument
        End Sub

        Sub ConfirmDeleteBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Database.Write("DELETE FROM " & Database.DBPrefix & "_BLOG_TOPICS WHERE BLOG_ID = " & sender.CommandArgument)
            Database.Write("DELETE FROM " & Database.DBPrefix & "_BLOG_REPLIES WHERE BLOG_ID = " & sender.CommandArgument)
            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Blog Entry Deleted Successfully<br /><br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page<br /><br />"
        End Sub

        Sub EditBlogReply(ByVal sender As System.Object, ByVal e As System.EventArgs)
            BlogTopic.Visible = "false"
            BlogReplies.Visible = "false"
            CommentForm.Visible = "false"
            EditBlogReplyForm.Visible = "true"
            Dim BlogReplyID As Integer = sender.CommandArgument
            BlogReplySubmitButton.CommandArgument = BlogReplyID
            Dim Reader As OdbcDataReader = Database.Read("SELECT BLOG_REPLY_TEXT FROM " & Database.DBPrefix & "_BLOG_REPLIES WHERE BLOG_REPLY_ID = " & BlogReplyID, 1)
            While Reader.Read()
                txtBlogReplyText.Text = Server.HtmlDecode(Reader("BLOG_REPLY_TEXT").ToString())
            End While
            Reader.Close()
        End Sub

        Sub SubmitBlogReply(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim BlogID As Integer = 0
            Dim BlogReplyID As Integer = sender.CommandArgument
            Dim theText As String = Functions.RepairString(txtBlogReplyText.Text)
            Database.Write("UPDATE " & Database.DBPrefix & "_BLOG_REPLIES SET BLOG_REPLY_TEXT = '" & theText & "' WHERE BLOG_REPLY_ID = " & BlogReplyID)
            Dim Reader As OdbcDataReader = Database.Read("SELECT BLOG_ID FROM " & Database.DBPrefix & "_BLOG_REPLIES WHERE BLOG_REPLY_ID = " & BlogReplyID)
            While Reader.Read()
                BlogID = Reader("BLOG_ID")
            End While
            Reader.Close()
            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Comment Submitted Successfully<br /><br /><a href=""blogs.aspx?ID=" & BlogID & """>Click Aquí</a> To Return To The Blog<br /><br />"
        End Sub

        Sub DeleteBlogReply(ByVal sender As System.Object, ByVal e As System.EventArgs)
            BlogTopic.Visible = "false"
            BlogReplies.Visible = "false"
            CommentForm.Visible = "false"
            DeleteBlogReplyForm.Visible = "true"
            FinalDeleteReplyButton.CommandArgument = sender.CommandArgument
        End Sub

        Sub ConfirmDeleteBlogReply(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim BlogID As Integer = 0
            Dim Reader As OdbcDataReader = Database.Read("SELECT BLOG_ID FROM " & Database.DBPrefix & "_BLOG_REPLIES WHERE BLOG_REPLY_ID = " & sender.CommandArgument)
            While Reader.Read()
                BlogID = Reader("BLOG_ID")
            End While
            Reader.Close()
            Database.Write("DELETE FROM " & Database.DBPrefix & "_BLOG_REPLIES WHERE BLOG_REPLY_ID = " & sender.CommandArgument)
            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Blog Comment Deleted Successfully<br /><br /><a href=""blogs.aspx?ID=" & BlogID & """>Click Aquí</a> To Return To The Blog<br /><br />"
        End Sub

    End Class


    '---------------------------------------------------------------------------------------------------
    ' BlogsList - Codebehind For blogslist.aspx
    '---------------------------------------------------------------------------------------------------
    Public Class BlogsList
        Inherits System.Web.UI.Page

        Public BlogUser As System.Web.UI.WebControls.Label
        Public BlogCategory As System.Web.UI.WebControls.Label
        Public BlogTopics As System.Web.UI.WebControls.Repeater
        Public AuthorLevel As Integer = 0
        Public txtBlogTopic As System.Web.UI.WebControls.TextBox
        Public txtBlogText As System.Web.UI.WebControls.TextBox
        Public BlogSubmitButton As System.Web.UI.WebControls.Button
        Public FinalDeleteButton As System.Web.UI.WebControls.Button
        Public EditBlogForm As System.Web.UI.WebControls.PlaceHolder
        Public DeleteBlogForm As System.Web.UI.WebControls.PlaceHolder
        Public PagePanel As System.Web.UI.WebControls.PlaceHolder
        Public NoItemsDiv As System.Web.UI.HtmlControls.HtmlGenericControl

        Public DMGSettings As DMGForums.Global.Settings

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not Page.IsPostBack() Then
                If ((Settings.HideMembers = 0) Or (Session("UserLogged") = "1")) Then
                    If (Functions.IsInteger(Request.QueryString("ID"))) Then
                        Dim Reader As OdbcDataReader = Database.Read("SELECT MEMBER_ID, MEMBER_USERNAME, MEMBER_LEVEL FROM " & Database.DBPrefix & "_MEMBERS WHERE MEMBER_ID = " & Request.QueryString("ID"), 1)
                        If Reader.HasRows() Then
                            While Reader.Read()
                                AuthorLevel = Reader("MEMBER_LEVEL")
                                BlogUser.Text = "<a href=""profile.aspx?ID=" & Reader("MEMBER_ID").ToString() & """ style=""color:" & Settings.HeaderFontColor & ";"">" & Reader("MEMBER_USERNAME").ToString() & "</a>"
                                BlogCategory.Text = Reader("MEMBER_USERNAME").ToString() & "'s Blogs"
                                DMGSettings.CustomTitle = Reader("MEMBER_USERNAME").ToString() & "'s Blogs"
                            End While
                        Else
                            Response.Redirect("default.aspx")
                        End If
                        Reader.Close()

                        BlogTopics.DataSource = Database.Read("SELECT BLOG_ID, BLOG_TITLE, BLOG_DATE, BLOG_REPLIES, BLOG_AUTHOR FROM " & Database.DBPrefix & "_BLOG_TOPICS WHERE BLOG_AUTHOR = " & Request.QueryString("ID") & " ORDER BY BLOG_DATE DESC")
                        BlogTopics.DataBind()
                        BlogTopics.DataSource.Close()
                    Else
                        Response.Redirect("default.aspx")
                    End If
                Else
                    PagePanel.Visible = "false"
                    NoItemsDiv.InnerHtml = "Only Members Can View This Page.<br /><a href=""default.aspx"">Click Aquí</a> To Return To The Main Page.<br /><br />"
                End If
            End If
        End Sub

        Sub EditBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            BlogTopics.Visible = "false"
            EditBlogForm.Visible = "true"
            Dim BlogID As Integer = sender.CommandArgument
            BlogSubmitButton.CommandArgument = BlogID
            Dim Reader As OdbcDataReader = Database.Read("SELECT BLOG_TITLE, BLOG_TEXT FROM " & Database.DBPrefix & "_BLOG_TOPICS WHERE BLOG_ID = " & BlogID, 1)
            While Reader.Read()
                txtBlogTopic.Text = Reader("BLOG_TITLE").ToString()
                txtBlogText.Text = Server.HtmlDecode(Reader("BLOG_TEXT").ToString())
            End While
            Reader.Close()
        End Sub

        Sub SubmitBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim BlogID As Integer = sender.CommandArgument
            Dim theTopic As String = Functions.RepairString(txtBlogTopic.Text)
            Dim theText As String = Functions.RepairString(txtBlogText.Text)
            Database.Write("UPDATE " & Database.DBPrefix & "_BLOG_TOPICS SET BLOG_TITLE = '" & theTopic & "', BLOG_TEXT = '" & theText & "' WHERE BLOG_ID = " & BlogID)
            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Blog Entry Edited Successfully<br /><br /><a href=""blogslist.aspx?ID=" & Request.QueryString("ID") & """>Click Aquí</a> To Return To The Blogs Page<br /><br />"
        End Sub

        Sub DeleteBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            BlogTopics.Visible = "false"
            DeleteBlogForm.Visible = "true"
            FinalDeleteButton.CommandArgument = sender.CommandArgument
        End Sub

        Sub ConfirmDeleteBlog(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Database.Write("DELETE FROM " & Database.DBPrefix & "_BLOG_TOPICS WHERE BLOG_ID = " & sender.CommandArgument)
            Database.Write("DELETE FROM " & Database.DBPrefix & "_BLOG_REPLIES WHERE BLOG_ID = " & sender.CommandArgument)
            PagePanel.Visible = "false"
            NoItemsDiv.InnerHtml = "Blog Entry Deleted Successfully<br /><br /><a href=""blogslist.aspx?ID=" & Request.QueryString("ID") & """>Click Aquí</a> To Return To The Blogs Page<br /><br />"
        End Sub

    End Class

End Namespace
