<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmPopupXstrata.aspx.vb" Inherits="FrmPopupXstrata" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    </style>
    
    <script type="text/javascript">
    $(document).ready(function () {
    SexyLightbox.initialize({ color: 'black', dir: 'sexyimages' });
              
      //  $("input[id$=txtAforo]").mask("99/99/9999");
      // $("input[id$=txtRetiro]").mask("99/99/9999");
      //  $("input[id$=Numeracion]").mask("99/99/9999");
      //  $("input[id$=dtregistro]").mask("99/99/9999");
    $("input[id$=txtFecEstimada]").mask("99/99/9999");
    $("input[id$=txtFechaLlegada]").mask("99/99/9999");
    $("input[id$=txtFechaEmbarque]").mask("99/99/9999");
     
     });
     
   
//     $(document).ready(function () {                                                                                  
//        $("div[id$=Panel1]").draggable();                                
//     });
   
    </script>
    
</head>
<body style ="background-color:#F0F2FC">
    <form id="form1" runat="server">
    <table style="left: 10px; width: 700px; position: relative; top: 0px;">
             <tr>
                 <td colspan="3" 
                     style="height: 21px; text-align:left; color: #000000; background-color: #000000;">
                     <strong style="text-align: left">
                     <span style="color: #000000">
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span 
                         class="style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Orden Servicio :</span></strong><span 
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
                 <td class="style7">
                     <span class="style1">TI</span><span style="font-weight: normal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     </span>
                 </td>
                 <td class="style6">
                     <asp:TextBox ID="txtTI" runat="server" Width="95px" ReadOnly="True"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <span class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                     Cliente</span>&nbsp;
                     <asp:TextBox ID="txtCliente" runat="server" Width="185px" ReadOnly="True"></asp:TextBox>
                 </td>
               
               
             </tr>
             <tr>
                 <td class="style1">
                     Mercaderia</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtMercaderia" runat="server" Width="240px" ReadOnly="True"></asp:TextBox>
                     &nbsp;&nbsp;<span class="style1">Tipo</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTipos" runat="server" Width="57px" ReadOnly="True"></asp:TextBox>
                     </td>                                 
             </tr>
             <tr>
                 <td class="style1">
                     BL</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtBL" runat="server" Width="239px" ReadOnly="True"></asp:TextBox>
                 </td>
                 
                
             </tr>
             <tr>
                 <td class="style2" colspan="3" >
---------------------------------------------------------------------------------------------------------------------------------------------------------------</td>
             </tr>
             <tr>
                 <td class="style1" >
                     Fecha Estimada</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtFecEstimada" runat="server" Width="91px"></asp:TextBox>
                 &nbsp;&nbsp; <span class="style1">Fecha Llegada</span>&nbsp;&nbsp;
                     <asp:TextBox ID="txtFechaLlegada" runat="server" Width="91px"></asp:TextBox>
                 &nbsp;<span class="style1">Fecha Embarque&nbsp;
                     <asp:TextBox ID="txtFechaEmbarque" runat="server" Width="91px"></asp:TextBox>
                     </span>
                 </td>
                 
             </tr>
             <tr>
                 <td >
                     &nbsp;</td>
                 <td colspan="2" >
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnGuardar" runat="server" Text="Modificar" Width="69px" 
                         style="height: 26px" />
                 </td>
                 
             </tr>
             <tr>
                 <td >
                     &nbsp;</td>
                 <td colspan="3" style="text-align: left" >
                     <asp:Label ID="Label1" runat="server" 
                         style="color: #FF3300; font-weight: 700; font-size: 10pt" Text="Label" 
                         Visible="False"></asp:Label>
                 </td>
                
             </tr>
         </table>
    </form>
</body>
</html>
