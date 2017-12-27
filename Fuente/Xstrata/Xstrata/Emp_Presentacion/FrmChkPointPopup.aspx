<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmChkPointPopup.aspx.vb" Inherits="FrmChkPointPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
    <title></title>
      <link href="App_Themes/Standard/css-content.css" rel="stylesheet" 
        type="text/css" />
    <link href="App_Themes/css-print.css" rel="stylesheet" type="text/css" />
    
    <link href="mbTooltip.css" rel="stylesheet" type="text/css" /> 
    
     <%--<link href="Libreria/css/le-frog/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />--%>
     <script type="text/javascript" src="Jquey/jquery-1.4.2.js"></script>
     <script type="text/javascript" src="Jquey/sexylightbox.v2.3.jquery.min.js"></script>       
     <script type="text/javascript" src="Jquey/jquery.maskedinput-1.2.2.js"></script>
    <script type="text/javascript" src="PanelUI/jquery-ui.min.js"></script>
    
    <link href="PanelUI/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <%--<script type="text/javascript" src="PanelUI/jquery.min.js"></script>--%>
    
    <link rel="stylesheet" href="Jquey/sexylightbox.css"  type="text/css" media="all" />
    <link href="StilosPanel/PanelStilos.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            color: #000000;
        }
        .style2
        {
            color: #FF0000;
        }
        .style3
        {
            color: #FFFFFF;
        }
        .style4
        {
            width: 98px;
        }
        .style5
        {
            font-weight: bold;
            color: #000000;
            width: 98px;
        }
    </style>
    
    <script type="text/javascript">
    $(document).ready(function () {
    SexyLightbox.initialize({ color: 'black', dir: 'sexyimages' });
              
      //  $("input[id$=txtAforo]").mask("99/99/9999");
      // $("input[id$=txtRetiro]").mask("99/99/9999");
      //  $("input[id$=Numeracion]").mask("99/99/9999");
      //  $("input[id$=dtregistro]").mask("99/99/9999");
    $("input[id$=txtFecha]").mask("99/99/9999");
    
     
     });
     
   
//     $(document).ready(function () {                                                                                  
//        $("div[id$=Panel1]").draggable();                                
//     });
   
    </script>
    
</head>
<body style ="background-color:#F0F2FC">
    <form id="form1" runat="server">
    <table style="left: 10px; width: 658px; position: relative; top: 0px;">
             <tr>
                 <td colspan="3" 
                     style="height: 21px; text-align:left; color: #000000; background-color: #000000;">
                     <strong style="text-align: left">
                     <span style="color: #000000">
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span 
                         class="style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Codigo :</span></strong><span 
                         class="style19"><span class="style3">&nbsp;
                     </span>
                     <asp:Label ID="lblOrdenServicio" runat="server" 
                         style="font-weight: 700; " CssClass="style3"></asp:Label>
                     </span>
                     <span class="style3">
                     </span>
                     </span>
                 </td>
             </tr>
             <tr>
                 <td class="style4">
                     <span class="style1">Codigo</span><span style="font-weight: normal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     </span>
                 </td>
                 <td class="style6">
                     <asp:TextBox ID="txtCodigo" runat="server" Width="95px" ReadOnly="True"></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style1">Descripcion</span>&nbsp;
                     <asp:TextBox ID="txtDescripcion" runat="server" Width="325px" ReadOnly="True"></asp:TextBox>
                 </td>
               
               
             </tr>
             <%--<tr>
                 <td class="style5">
                     Mercaderia</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtMerc" runat="server" Width="240px" ReadOnly="True"></asp:TextBox>
                     &nbsp;&nbsp;<span class="style1">Tipo</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTipos" runat="server" Width="57px" ReadOnly="True"></asp:TextBox>
                     </td>                                 
             </tr>--%>
             <%--<tr>
                 <td class="style5">
                     BL</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtBL" runat="server" Width="239px" ReadOnly="True"></asp:TextBox>
                 </td>
                 
                
             </tr>--%>
             <tr>
                 <td class="style2" colspan="3" >
---------------------------------------------------------------------------------------------------------------------------------------------------------------</td>
             </tr>
             <tr>
                 <td class="style5" >
                     Fecha </td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtFecha" runat="server" Width="91px"></asp:TextBox>
                 &nbsp;&nbsp; <span class="style1">&nbsp;</span></td>
                 
             </tr>
             <tr>
                 <td class="style4" >
                     &nbsp;</td>
                 <td colspan="2" >
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnGuardar" runat="server" Text="Actualizar Fechas" 
                         Width="124px" Font-Bold="True" />
                 </td>
                 
             </tr>
             <tr>
                 <td class="style4" >
                     &nbsp;</td>
                 <td colspan="3" style="text-align: left" >
                     <asp:Label ID="Label1" runat="server" 
                         style="color: #FF3300; font-weight: 700; font-size: 10pt" Text="Label" 
                         Visible="False"></asp:Label>
                 </td>
                
             </tr>
         </table>
    </div>
    </form>
</body>
</html>
