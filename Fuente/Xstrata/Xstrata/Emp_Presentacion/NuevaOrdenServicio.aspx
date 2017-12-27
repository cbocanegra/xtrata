<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NuevaOrdenServicio.aspx.vb" Inherits="NuevaOrdenServicio" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
     
    
    
    <style type="text/css">
        .style4
        {
            height: 25px;
        }
        .style5
        {
            width: 205px;
            height: 25px;
        }
        .style6
        {
            width: 225px;
            height: 23px;
        }
        .style7
        {
            height: 23px;
            width: 141px;
        }
        .style8
        {
            height: 23px;
        }
        .style9
        {
            height: 23px;
        }
        #form1
        {
            width: 930px;
        }
        .style10
        {
            width: 122px;
            height: 23px;
        }
        .style11
        {
            width: 225px;
        }
        .style12
        {
            color: #000000;
            font-weight: bold;
        }
        .style13
        {
            color: #000000;
        }
        .style15
        {
            height: 25px;
            width: 141px;
            color: #000000;
            font-weight: bold;
        }
        .style16
        {
            height: 23px;
            font-weight: bold;
            color: #FF3300;
        }
        .style17
        {
            color: #FF3300;
            font-weight: bold;
        }
        .style18
        {
            font-weight: bold;
        }
        .style19
        {
            font-size: 10.5pt;
        }
    </style>
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
    
    
    <script type="text/javascript">
    $(document).ready(function () {
    SexyLightbox.initialize({ color: 'black', dir: 'sexyimages' });
              
      //  $("input[id$=txtAforo]").mask("99/99/9999");
      // $("input[id$=txtRetiro]").mask("99/99/9999");
      //  $("input[id$=Numeracion]").mask("99/99/9999");
      //  $("input[id$=dtregistro]").mask("99/99/9999");
    $("input[id$=dtVenc]").mask("99/99/9999");
    $("input[id$=txtcantidad]").mask("99999999.99");
                
     });
     
   
//     $(document).ready(function () {                                                                                  
//        $("div[id$=Panel1]").draggable();                                
//     });
   
    </script>
    
    
</head>
<body style ="background-color:#F0F2FC">
      
    <form id="form1" runat="server">
         <table style="left: 10px; width: 848px; position: relative; top: 0px;">
             <tr>
                 <td colspan="5" style="height: 21px; text-align:left">
                     <span style="color: #000000"><strong style="text-align: left">
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style19">Generacion Nueva Orden Servicio</span></strong><span 
                         class="style19"> </span>
                     </span>
                 </td>
             </tr>
             <tr>
                 <td class="style7">
                     <span class="style12">Orden de Servicio</span><span style="font-weight: normal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     </span>
                 </td>
                 <td class="style6">
                     <asp:TextBox ID="txtCodOS" runat="server" Width="128px" ReadOnly="True"></asp:TextBox>
                 </td>
                 <td style="color: #000000;" class="style10">
                     </td>
                 <td class="style8">
                     </td>
                 <td class="style9">
                     </td>
             </tr>
             <tr>
                 <td class="style15">
                     Zona</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtzona" runat="server" Width="40px"></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="cmbZona" 
                         runat="server" Height="23px" 
                         Width="211px" AppendDataBoundItems="True">
                         <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td class="style5">
                     </td>
                 <td class="style4">
                     </td>
             </tr>
             <tr>
                 <td class="style15">
                     Cliente</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtCodCli" runat="server" Width="40px"></asp:TextBox>
                     <asp:DropDownList ID="lkcliente" runat="server" Height="19px" Width="305px" 
                         AutoPostBack="True" AppendDataBoundItems="True">
                         <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td >
                     Ascinsa&nbsp;
                     <asp:TextBox ID="txtAscinsa" runat="server" Width="40px" ReadOnly="True"></asp:TextBox>
                 </td>
                 <td class="style4">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td class="style12" >
                     Ref. Cliente</td>
                 <td colspan="4" >
                     <asp:TextBox ID="txtRef" runat="server" Height="44px" TextMode="MultiLine" 
                         Width="502px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="style12">
                     Contacto</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txtcontacto" runat="server" Width="253px"></asp:TextBox>
                 </td>
                 <td class="style5">
                     </td>
                 <td class="style4">
                     </td>
             </tr>
             <tr>
                 <td colspan="5" class="style16">
                     ------------------------------------------------------------------------------------------------------------------------------------------------------------</td>
             </tr>
              <tr>
                 <td >
                     <span style="color: #000000" class="style18">Aduana</span><span style="font-weight: normal">
                     </span>
                 </td>
                 <td >
                     &nbsp;
                     <asp:TextBox ID="txtaduana" runat="server" Width="40px"></asp:TextBox>
                 
                     &nbsp;&nbsp;&nbsp;
                 
                     <asp:DropDownList ID="cmbAduana" runat="server" Height="21px" Width="145px" 
                         AppendDataBoundItems="True">
                         <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                     </asp:DropDownList>
                 
                     </td>
                 <td style="color: #000000;" >
                     <span style="color: #000000">Regimen</span></td>
                 <td  colspan="2">
                     <asp:TextBox ID="txtregimen" runat="server" Width="40px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;
                     <asp:DropDownList ID="cmbRegimen" runat="server" Height="21px" Width="186px" 
                         AutoPostBack="True" AppendDataBoundItems="True">
                         <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                     </asp:DropDownList>
                     </td>
             </tr>
              <tr>
                 <td>
                     <span style="color: #000000">Tipo Operacion</span></td>
                 <td class="style11">
                     &nbsp;
                     <asp:TextBox ID="txttipo" runat="server" Width="40px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;
                     <asp:DropDownList ID="cmbTipoOper" runat="server" Height="21px" Width="144px">
                     </asp:DropDownList>
                  </td>
                 <td style="color: #000000;" class="style10">
                     Prioridad Despacho</td>
                 <td  colspan="2">
                     <asp:TextBox ID="txtprioridad" runat="server" Width="40px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;
                     <asp:DropDownList ID="cmbPrioridad" runat="server" Height="21px" Width="182px" 
                         AppendDataBoundItems="True">
                         <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                     </asp:DropDownList>
                     </td>
             </tr>
              <tr>
                 <td>
                     Medio</td>
                 <td class="style11">
                     &nbsp;
                     <asp:TextBox ID="txtmedio" runat="server" Width="40px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;
                     <asp:DropDownList ID="cmbMedio" runat="server" AppendDataBoundItems="True" 
                         Height="21px" Width="138px">
                         <asp:ListItem Value="-1">Seleccionar..</asp:ListItem>
                     </asp:DropDownList>
                  </td>
                 <td style="color: #000000;" class="style10">
                     Fec.Venc Deposito</td>
                 <td  colspan="2">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="dtVenc" runat="server" Width="72px"></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     </td>
             </tr>
              <tr>
                 <td>
                     <asp:RadioButton ID="rbPrecedentte" runat="server" GroupName="rbTipo" 
                         Text="Precedente" />
                  </td>
                 <td colspan="4">
                     <asp:RadioButton ID="RbVigencia" runat="server" GroupName="rbTipo" 
                         Text="Vigencia" />
                  &nbsp;&nbsp;
                     <asp:RadioButton ID="RbRegularizacion" runat="server" GroupName="rbTipo" 
                         Text="Regularizacion" />
                  &nbsp;&nbsp;&nbsp;
                     <asp:RadioButton ID="RbNinguno" runat="server" GroupName="rbTipo" 
                         Text="Ninguno" Checked="True" />
                     <span class="style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BL</span>&nbsp;<asp:TextBox 
                         ID="txtBL" runat="server" Width="153px" MaxLength="60"></asp:TextBox>
                  &nbsp;O/S Precedente                      <asp:TextBox ID="txtOSPrec" 
                         runat="server" Width="51px" 
                         ReadOnly="True"></asp:TextBox>
                  </td>
             </tr>
             <tr>
                 <td colspan="5" class="style17">
                     -----------------------------------------------------------------------------------------------------------------------------------------------------------</td>
             </tr>
             <tr>
                 <td colspan="5" class="style12">
                     Descripcion Mercaderia&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="txtDescripM" runat="server" Width="560px" MaxLength="59"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="style13">
                     Tipo Carga</td>
                 <td colspan="2" >
                     <asp:TextBox ID="txttipocarga" runat="server" Width="32px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:DropDownList ID="cbotipocarga" runat="server" Height="21px" Width="182px" 
                         AppendDataBoundItems="True">
                         <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td >
                     <span class="style13">Cantidad</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="txtcantidad" runat="server" Width="101px"></asp:TextBox>
                     </td>
                 <td class="style4">
                     </td>
             </tr>
             <tr>
                 <td class="style13" >
                     Inspec. Sanitaria<asp:CheckBox ID="chkInspeccion" runat="server" />
                 </td>
                 <td colspan="2" >
                     <span class="style13">Tipo Pago Aduana</span>
                     <asp:TextBox ID="txttipopago" runat="server" Width="32px"></asp:TextBox>
                 &nbsp;
                     <asp:DropDownList ID="cmbTipoPago" runat="server" Height="21px" Width="130px" 
                         AutoPostBack="True" AppendDataBoundItems="True">
                         <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                     </asp:DropDownList>
                  </td>
                 <td >
                     <span class="style13">Atencion SIL</span>&nbsp;
                     <asp:TextBox ID="txtSIL" runat="server" Width="103px"></asp:TextBox>
                     </td>
                 <td class="style4">
                     &nbsp;</td>
             </tr>
             <tr>
             <td></td>
             <td></td>
             <td></td>
             <td></td>
             </tr>
             <tr>
                 <td >
                     &nbsp;</td>
                 <td colspan="2" >
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Width="77px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCargaDatos" runat="server" 
                         Text="Cargar Datos" Visible="False" Width="81px" />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="69px" />
                 </td>
                 <td >
                     &nbsp;</td>
                 <td >
                     &nbsp;</td>
             </tr>
             <tr>
                 <td >
                     &nbsp;</td>
                 <td colspan="3" style="text-align: center" >
                     <asp:Label ID="Label1" runat="server" 
                         style="color: #FF3300; font-weight: 700; font-size: 10pt" Text="Label"></asp:Label>
                 </td>
                 <td >
                     <asp:Label ID="lblpndctr" runat="server" Visible="False"></asp:Label>
                 </td>
             </tr>
         </table>
       
         </cc1:MaskedEditExtender>
                        
    </form>
</body>
</html>
