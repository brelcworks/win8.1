'
' Created by SharpDevelop.
' User: pathllk
' Date: 12/15/2015
' Time: 9:23 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'Imports System.Collections
IMports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

''' <summary>
''' Description of Default.
''' </summary>
Public Class [Default]
	Inherits Page
	'<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	#Region "Data"

	Protected _Button_Ok As HtmlInputButton
	Protected _Input_Name As HtmlInputText

	#End Region
	'<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	#Region "Page Init & Exit (Open/Close DB connections here...)"

	Protected Sub PageInit(sender As Object, e As EventArgs)
	End Sub
	'----------------------------------------------------------------------
	Protected Sub PageExit(sender As Object, e As EventArgs)
	End Sub

	#End Region
	'<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	#Region "Page Load"
	Private Sub Page_Load(sender As Object, e As EventArgs)
		Response.Write("Hello #Develop<br>")
		'------------------------------------------------------------------
		If IsPostBack Then
		End If
		'------------------------------------------------------------------
	End Sub
	#End Region
	'<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	#Region "Click_Button_OK"

	'----------------------------------------------------------------------
	Protected Sub Click_Button_Ok(sender As Object, e As EventArgs)
		Response.Write(_Button_Ok.Value & " was cklicked!<br>")
	End Sub

	#End Region
	'<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	#Region "Changed_Input_Name"

	'----------------------------------------------------------------------
	Protected Sub Changed_Input_Name(sender As Object, e As EventArgs)
		Response.Write(_Input_Name.Value & " has changed!<br>")
	End Sub

	#End Region
	'<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	#Region "More..."
	#End Region
	'<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	#Region "Initialize Component"

	Protected Overrides Sub OnInit(e As EventArgs)
		InitializeComponent()
		MyBase.OnInit(e)
	End Sub
	'----------------------------------------------------------------------
	Private Sub InitializeComponent()
		AddHandler Me.Load, New System.EventHandler(AddressOf Page_Load)
		AddHandler Me.Init, New System.EventHandler(AddressOf PageInit)
		AddHandler Me.Unload, New System.EventHandler(AddressOf PageExit)

		AddHandler _Button_Ok.ServerClick, New EventHandler(AddressOf Click_Button_Ok)
		AddHandler _Input_Name.ServerChange, New EventHandler(AddressOf Changed_Input_Name)
	End Sub
	#End Region
	'<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
End Class
