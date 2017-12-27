<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmLogin.aspx.vb" Inherits="FrmLogin" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <title>Bienvenidos al Seguimiento de ordenes de Servicio</title>
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">    
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" style="position: relative; top: 152px; height: 24px; left: 0px;" border="0">
             <tr><td colspan="3" class="style1" style="color: #C8301A; text-align: center;">
                 Seguimiento de Ordenes de Servicio</td></tr>
            <tr><td colspan="3"> 
                </td></tr>
            <tr><td colspan="3"></td></tr>
            <tr><td colspan="3"></td></tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            
            <tr>
                <td style="width: 250px; height: 146px" >
                </td>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 624px">
                     <tbody>
                        <tr>
                            <td style="width: 143px;" rowspan="2">
                                <asp:Image ID="Imglogo" runat="server" ImageUrl="~/Imagenes/Agencias555.png" 
                                    Height="152px" Width="207px" />&nbsp;&nbsp; </td>
                            <td style="height: 8px; width: 237px;">
                            </td>
                        </tr>
                        <tr>
                           <td>
                           <LayoutTemplate>
                <table border="0" cellpadding="4" cellspacing="0" 
                    style="">
                    <tr>
                        <td>
                            <table border="2" cellpadding="0" 
                                style="border-style: ridge; height:166px; width:304px;">
                                <tr>
                                    <td align="center" colspan="2" 
                                        
                                        style="color:White;background-color:#C8301A; font-size:0.9em;font-weight:bold;">
                                        Iniciar sesión</td>
                                </tr>
                                <tr>
                                    <td align="right" style="border-style: none">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario :&nbsp;&nbsp</asp:Label>
                                    </td>
                                    <td style="border-style: none">
                                        <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em" Width="110px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" 
                                            ErrorMessage="El nombre de usuario es obligatorio." 
                                            ToolTip="El nombre de usuario es obligatorio." ValidationGroup="LgnRansa">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="border-style: none">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña  :&nbsp;&nbsp</asp:Label>
                                    </td>
                                    <td style="border-style: none">
                                        <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" Width="110px" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." 
                                            ToolTip="La contraseña es obligatoria." ValidationGroup="LgnRansa">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="border-style: none; color:Red;" 
                                        rowspan="0">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-style: none; text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        <asp:Label ID="lblZona" runat="server" Text="Zona" Visible="False"></asp:Label>
                                        &nbsp; :&nbsp;
                                        <asp:DropDownList ID="CbZona" runat="server" Width="120px" Visible="False" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="border-style: none">
                                        <asp:Button ID="LoginButton" runat="server" BackColor="White" 
                                            BorderColor="#008431" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#C8301A" 
                                            Text="Inicio de sesión" ValidationGroup="LgnRansa" />
                                    </td>                                    
                                </tr>
                                <TR><td colspan="2" style="text-align: center">
                                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" 
                                        style="color: #CC3300; font-weight: 700"></asp:Label>
                                    </td></TR>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
                           </td>
                        </tr>
                         </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    
</body>
</html>
