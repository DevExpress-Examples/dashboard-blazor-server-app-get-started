Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.RazorPages
Imports Microsoft.Extensions.Logging
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Threading.Tasks

Namespace BlazorDashboardApp.Pages
	<ResponseCache(Duration := 0, Location := ResponseCacheLocation.None, NoStore := True)>
	<IgnoreAntiforgeryToken>
	Public Class ErrorModel
		Inherits PageModel

		Public Property RequestId() As String

		Public ReadOnly Property ShowRequestId() As Boolean
			Get
				Return Not String.IsNullOrEmpty(RequestId)
			End Get
		End Property

		Private ReadOnly _logger As ILogger(Of ErrorModel)

		Public Sub New(ByVal logger As ILogger(Of ErrorModel))
			_logger = logger
		End Sub

		Public Sub OnGet()
			RequestId = If(Activity.Current?.Id, HttpContext.TraceIdentifier)
		End Sub
	End Class
End Namespace
