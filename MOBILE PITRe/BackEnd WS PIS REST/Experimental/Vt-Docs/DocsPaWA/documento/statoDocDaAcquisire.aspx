<%@ Page language="c#" Codebehind="statoDocDaAcquisire.aspx.cs" AutoEventWireup="false" Inherits="DocsPAWA.documento.statoDocDaAcquisire" %>
<%@ Register src="../UserControls/AppTitleProvider.ascx" tagname="AppTitleProvider" tagprefix="uct" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../CSS/docspa_30.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="statoDocDaAcquisire" method="post" runat="server">
		<uct:AppTitleProvider ID="appTitleProvider" runat="server" PageName = "Stato Documento Da Acquisire" />
			<table border="0" width="100%" height="100%">
				<tr height="10%">
					<td align="left" valign="top"><br>
						&nbsp;</td>
				</tr>
				<tr>
					<td valign="center" align="middle" class="testo_msg_grigio_grande">
						<!--font face="Comic Sans Ms" size="8">Documento<br>
							non<br>
							acquisito</font-->
						Documento non acquisito
					</td>
				</tr>
				<tr height="10%">
					<td align="left" valign="top"><br>
						&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
