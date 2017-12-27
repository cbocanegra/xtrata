<%@ Page Title="" Language="VB" MasterPageFile="~/MstEmpleado.master" AutoEventWireup="false" CodeFile="Empleado.aspx.vb" Inherits="Ejeplo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="left: 99px; width: 384px; position: relative; top: 0px;">
            <tr>
                <td colspan="6" style="height: 21px; text-align:center ">
                    <span style="color: #000000">
                <strong>Seguimiento de Importacion</strong> :</span><B><span style="color: #000000"> 
                    </span>
                    <asp:Label ID="lblNombCliente" runat="server" Text="Label" Font-Bold="True" 
                        BorderColor="Black" ForeColor="Black"></asp:Label>
                          </B></td>
            </tr>
            <tr>
                <td style="height: 18px; color: #000000;">
                    <B>BL</B></td>
                <td style="height: 18px; color: #000000;">
                    <B>Ord.Servicio</B></td>
                <td style="width: 205px; height: 18px; color: #000000;">
                    <B>Referencia</B></td>
                <td style="width: 205px; height: 18px">
                    <span style="color: #000000">
                    <B>Mercaderia</B></span>
                </td>
                <td style="width: 205px; height: 18px">
                    <span style="color: #000000">
                    <B>Carga</B></span>
                </td>
                <td style="height: 18px; color: #000000;">
                    Buscar</td>
            </tr>
            <tr>
                <td style="height: 35px">
                    <asp:TextBox ID="Bl" runat="server"></asp:TextBox></td>
                <td style="height: 35px">
                    <asp:TextBox ID="txtNombEmp" runat="server"></asp:TextBox></td>
                <td style="width: 205px; height: 35px">
                    <asp:TextBox ID="txtNombRepres" runat="server"></asp:TextBox></td>
                <td style="width: 205px; height: 35px">
                    <asp:TextBox ID="txtAutoriz" runat="server" Width="126px"></asp:TextBox></td>
                <td style="width: 205px; height: 35px">
                    <asp:TextBox ID="txtCorreo" runat="server" Width="87px" ></asp:TextBox></td>
                <td style="height: 35px">
                    <asp:ImageButton ID="btnBusqueda" runat="server" Height="31px" ImageUrl="~/Imagenes/search.png"
                        Width="28px" ToolTip="Busqueda Online" /></td>
            </tr>
            <tr>
                <td style="height: 18px; color: #000000;"> <B>Fecha Aforo</B></td>
                <td style="height: 18px; color: #000000;"> <B>Fecha Retiro</B></td>
                <td style="width: 205px; height: 18px; color: #000000;"> <B>Fecha Numeracion</B></td>
                <td style="width: 205px; height: 18px; color: #000000;">  <b>Canal</b></td>
                <td style="width: 205px; height: 18px; color: #000000; font-weight: 700;">  Tipo</td>
                <td style="height: 18px; color: #000000;">Estado </td>
            </tr>
            <tr>
                <%--<td style="height: 35px"> <asp:TextBox ID="txtAforo" runat="server" title="Formato Fecha Mes /dia /año"></asp:TextBox></td>--%>
                <td style="height: 35px"> <asp:TextBox ID="txtAforo" runat="server" ></asp:TextBox></td>
                <td style="height: 35px"> <asp:TextBox ID="txtRetiro" runat="server"></asp:TextBox></td>
                <td style="height: 35px"> <asp:TextBox ID="txtNumeracion" runat="server"></asp:TextBox></td>
                <td style="height: 35px"> 
                    <asp:DropDownList ID="DDLCanal" runat="server" AppendDataBoundItems="True" 
                        Height="18px" Width="125px" Font-Size="X-Small" ForeColor="#C8301A">
                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                        <asp:ListItem Value="V">Verde</asp:ListItem>
                        <asp:ListItem Value="N">Naranja</asp:ListItem>
                        <asp:ListItem Value="R">Rojo</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 35px"> 
                    <asp:DropDownList ID="DDLTipo" runat="server" Height="18px" Width="114px" 
                        Font-Size="X-Small" ForeColor="#C8301A">
                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                        <asp:ListItem Value="IM">Importacion Maritima</asp:ListItem>
                        <asp:ListItem Value="IA">Importacion Aerea</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td> 
                    <asp:DropDownList ID="DDLEstado" runat="server" Height="18px" Width="114px" 
                        Font-Size="X-Small" ForeColor="#C8301A">
                        <asp:ListItem Selected="True" Value="A">ACTIVO</asp:ListItem>
                        <asp:ListItem Value="C">CERRADO</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
                                   
      </table>
        <asp:Panel ID="Panel1" runat="server" CssClass="DragPanel" 
            Visible="False" Font-Size="Small" ForeColor="#006600" BackColor="#FEF8E8" 
                BorderColor="#FFFFCC" GroupingText="Selecione Campos a Ocultar">
          <table style="width: 100%;">
        <tr>
        <td style="text-align: left; background-color: #B83E2D;">
        <asp:ImageButton ID="ImageButton1" runat="server" 
ImageUrl="~/Imagenes/delete.png" style="text-align: left" Height="21px" 
        Width="23px" />
&nbsp;<span class="style1" style="color: #FFFFFF">Cerrar Panel</span>&nbsp;</td>
</tr>
<tr>
<td><asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="226px" 
RepeatColumns="4" Width="737px">
</asp:CheckBoxList>
&nbsp;</td>
</tr>
<tr>
<td style="text-align: center"><asp:ImageButton ID="ImageButton3" runat="server" Height="19px" 
                    ImageUrl="~/Imagenes/btn_aceptarINT.gif" Width="81px" />
&nbsp;</td>
</tr>
</table>
</asp:Panel>
    
        <table width="100%">               
        <tr>            
            <td style="text-align: right"><asp:ImageButton ID="ImageButton2" runat="server" Height="19px" 
                    ImageUrl="~/Imagenes/TaskReport.gif" Width="32px" /><asp:Label ID="lblMensaje" runat="server" 
                    Text="Label" BorderColor="#CC3300" 
                    ForeColor="Red" Visible="False"></asp:Label><asp:Label ID="Label1" runat="server" 
                    Text="Label" BorderColor="#CC3300" 
                    ForeColor="Red" Visible="False"></asp:Label></td>
            <td style="text-align: right"> <asp:Label ID="lblReporte" runat="server" Text="Generar Reporte" Visible="False"></asp:Label>
               <asp:ImageButton ID="btnReporte" runat="server" Height="29px" ImageUrl="~/Imagenes/excel.gif"
               ToolTip="Exportar a Excel" Visible="False" Width="33px" />
             </td>
        </tr>      
        <tr>                 
        <td valign="top">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
               BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
               CellPadding="3" Width="131px" AutoGenerateColumns="False" 
               Font-Size="X-Small" ForeColor="#293B15" GridLines="Vertical" 
               EmptyDataText="No Existen Registros..." Height="16px" AllowPaging="True" 
                PageSize="25" >
               <FooterStyle BackColor="#CCCCCC" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" />
               <SelectedRowStyle BackColor="#70822C" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#009B3A" Font-Bold="True" ForeColor="White" Wrap="False" />
             <Columns>
            <%--<asp:TemplateField HeaderText="Nombre. Repres">
                    <ItemTemplate>
                     <a href="Proveedor.aspx?prov=<%#DataBinder.Eval(Container.DataItem, "IdProveedor")%>TB_iframe=true&height=280&width=750" rel='sexylightbox'>
                     <%#DataBinder.Eval(Container.DataItem, "IdProveedor")%></a></td>         
                    </ItemTemplate>                               
            </asp:TemplateField>--%>
               <%--<asp:BoundField DataField="PNNMOS" HeaderText="Orden" />--%>            
               
               <%--<asp:BoundField DataField="PCNMDC" HeaderText="BL" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>--%>
                 <%--<asp:TemplateField HeaderText="BL" Visible="Blue" >
                        <ItemTemplate>
                            <a href="FrmDetalleOrdCompra.aspx?NroOrden=<%#DataBinder.Eval(Container.DataItem, "PNNMOS")%>">
                            <%#DataBinder.Eval(Container.DataItem, "PNNMOS")%></a></td>         
                        </ItemTemplate>                               
                        <ControlStyle BackColor="#004E0C"></ControlStyle>
                            <HeaderStyle BackColor="#009B3A" ForeColor="White" />
                   <ItemStyle Wrap="False" />
               </asp:TemplateField>--%>
                 
                 
                 <asp:TemplateField HeaderText="BL">
                    <ItemTemplate>
                            <a href="FrmDetalleOrdCompra.aspx?NroOrden=<%#DataBinder.Eval(Container.DataItem, "PNNMOS")%>&NroBL=<%#DataBinder.Eval(Container.DataItem, "PCNMDC")%>">
                            <%#DataBinder.Eval(Container.DataItem, "PCNMDC")%></a></td>         
                        </ItemTemplate>
                        <ControlStyle BackColor="#004E0C"></ControlStyle>
                            <HeaderStyle BackColor="#009B3A" ForeColor="White" />
                   <ItemStyle Wrap="False" /> 
                 </asp:TemplateField>
                 
                 
               <asp:BoundField DataField="DCTPOS" HeaderText="Tipo" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DESPACHO" HeaderText="Stuacion" >
               
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               
               <%--<asp:TemplateField HeaderText="Orden" Visible="False" >
                        <ItemTemplate>
                            <a href="FrmDetalleOrdCompra.aspx?NroOrden=<%#DataBinder.Eval(Container.DataItem, "PNNMOS")%>">
                            <%#DataBinder.Eval(Container.DataItem, "PNNMOS")%></a></td>         
                        </ItemTemplate>                               
                        <ControlStyle BackColor="#004E0C"></ControlStyle>
                            <HeaderStyle BackColor="#009B3A" ForeColor="White" />
                   <ItemStyle Wrap="False" />
               
               </asp:TemplateField>--%>
                <asp:BoundField DataField="PNNMOS" HeaderText="--ORDEN---" Visible="False"  >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 
                 <asp:BoundField DataField="DCDSME" HeaderText="Mercaderia" Visible="False" />
                 <asp:BoundField DataField="Fecha" HeaderText="Fecha" Visible="False" />
                 <asp:BoundField DataField="DCDSRG" HeaderText="Regimen" Visible="False" />
                 <asp:BoundField DataField="DCDSOP" HeaderText="Operacion" Visible="False" />
                 <asp:BoundField DataField="DCNAVE" HeaderText="Vapor" Visible="False" />
                 <asp:BoundField DataField="FECHA_ESTIMADA" HeaderText="Fecha Estimada" 
                     Visible="False" />
                 <asp:BoundField DataField="FECHA_LLEGADA" HeaderText="Fecha LLegada" 
                     Visible="False" />
                 <asp:BoundField DataField="TERMINO_DESCARGA" HeaderText="Termino Descarga" 
                     Visible="False" />
                 <asp:BoundField DataField="Almacenes" HeaderText="Almacenes" Visible="False" />
                 <asp:BoundField DataField="FECHA_UBICACION" HeaderText="fecha Ubicacion" 
                     Visible="False" />
                 <asp:BoundField DataField="FECHA_VISTOBUENO" HeaderText="Fecha Visto Bueno" 
                     Visible="False" />
                 <asp:BoundField DataField="FECHA_NUMERACION" HeaderText="Fecha Numeracion" 
                     Visible="False" />
                 <asp:BoundField DataField="FECHA_PAGO" HeaderText="Fecha Pago" 
                     Visible="False" />
                 <asp:BoundField DataField="DCBLTO" HeaderText="Tipo Bulto" Visible="False" />
                 <asp:TemplateField HeaderText="Canal" Visible="False">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="DDAFOR" HeaderText="Fecha Aforo" Visible="False" />
                 <asp:BoundField DataField="DDPRES" HeaderText="Fecha Presentacion" 
                     Visible="False" />
                 <asp:BoundField DataField="DDLEVA" HeaderText="Fecha Levante." 
                     Visible="False" />
                 <asp:BoundField DataField="DDRETI" HeaderText="Fecha Retiro" Visible="False" />
                 <asp:BoundField DataField="NRUC" HeaderText="NIT" Visible="False" />
                 <asp:BoundField DataField="DCDUIDUE" HeaderText="DAM" Visible="False" />
                 <asp:BoundField DataField="DCOBSE" HeaderText="Obervaciones" Visible="False" />
                 <asp:BoundField DataField="DCNMMN" HeaderText="Nro Manifiesto" 
                     Visible="False" />
                 <asp:BoundField DataField="DCREFE" HeaderText="Referencia" Visible="False" />
                 <asp:BoundField DataField="B_L" HeaderText="Fecha BL" Visible="False" />
                 <asp:BoundField DataField="TCMPCL" HeaderText="NombCli" Visible="False" />
                 <asp:BoundField DataField="DCDSCD" HeaderText="Carga" Visible="False" />
                 <asp:BoundField DataField="LIQUIDADOR" HeaderText="Liquidador" 
                     Visible="False" />
                 
             </Columns>
             <AlternatingRowStyle BackColor="Gainsboro" Wrap="False" />
            </asp:GridView></td>
        <td align ="left">
               <div class="DivScroll">                   
               <asp:GridView ID="DtgRepresentante" runat="server" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
               CellPadding="3" Width="1010px" AutoGenerateColumns="False" 
               Font-Size="X-Small" ForeColor="#293B15" GridLines="Vertical" 
               EmptyDataText="No Existen Registros..." Height="16px" AllowPaging="True" 
                PageSize="25" >
                <PagerSettings Visible=false />
               <FooterStyle BackColor="#CCCCCC" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="center" />
               <SelectedRowStyle BackColor="#70822C"  ForeColor="White" />
               <HeaderStyle BackColor="#009B3A" Font-Bold="True" ForeColor="White" Wrap="False" 
                       HorizontalAlign="Center" VerticalAlign="Middle" />
             <Columns>
            <%--<asp:TemplateField HeaderText="Nombre. Repres">
                    <ItemTemplate>
                     <a href="Proveedor.aspx?prov=<%#DataBinder.Eval(Container.DataItem, "IdProveedor")%>TB_iframe=true&height=280&width=750" rel='sexylightbox'>
                     <%#DataBinder.Eval(Container.DataItem, "IdProveedor")%></a></td>         
                    </ItemTemplate>                               
            </asp:TemplateField>--%>
               <%--<asp:BoundField DataField="DCDSCD1" HeaderText="....Canal...." >
                   <HeaderStyle HorizontalAlign="Center" />
                   <ItemStyle Wrap="False" />
                 </asp:BoundField>--%>                 
                 <asp:BoundField DataField="PNNMOS" HeaderText="--ORDEN---" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCDSME" HeaderText="...Mercaderia..." >
                   <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DDREGI" HeaderText="...Fecha..." >
                   <FooterStyle HorizontalAlign="Center" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCDSRG" 
                     HeaderText="....Regimen...." >
                   <FooterStyle HorizontalAlign="Center" />
                   <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCDSOP" HeaderText="...Operacion...." >
                   <FooterStyle HorizontalAlign="Center" />
                   <HeaderStyle Width="0px" HorizontalAlign="Center" Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCNAVE" HeaderText="...Vapor..." >                   
                   <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False"/>
                 </asp:BoundField>
               <asp:BoundField DataField="FECHA_ESTIMADA" HeaderText="...Fecha Estimada..." >
                   <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="FECHA_LLEGADA" HeaderText="...Fecha LLegada..." >
                   <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="TERMINO_DESCARGA" HeaderText="Termino Descarga">
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCDSAB" HeaderText="Almacenes" >                   
                   <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="FECHA_UBICACION" HeaderText="...fecha Ubicacion...">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="FECHA_VISTOBUENO" HeaderText="Fecha Visto Bueno">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="FECHA_NUMERACION" 
                     HeaderText="...Fecha Numeracion..">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="FECHA_PAGO" 
                     HeaderText="...Fecha Pago...">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCBLTO" HeaderText="Tipo Bulto" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:TemplateField HeaderText="....Canal...." >
                            <ItemTemplate >                                                                
                                <%#IIf(DataBinder.Eval(Container.DataItem, "DCCANA").ToString().Equals("V"), "<img src='Imagenes/FlagGreen1.png' alt= 'CANAL VERDE' width='14' height='15' > ", IIf(DataBinder.Eval(Container.DataItem, "DCCANA").ToString().Equals("R"), "<img src='Imagenes/Flagred1.png' alt= 'CANAL ROJO' width='14' height='15'>", IIf(DataBinder.Eval(Container.DataItem, "DCCANA").ToString().Equals("N"), "<img src='Imagenes/FlagNaranja1.png' alt= 'CANAL NARANJA' width='14' height='15'>", "")))%> 
                            </ItemTemplate>
                            <FooterStyle Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                 <asp:BoundField DataField="DDAFOR" HeaderText="...Fecha Aforo...">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDPRES" DataFormatString="{0:dd/MM/yyyy}" 
                     HeaderText="... Fecha Presentacion...">
                     <ItemStyle Wrap="False" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDLEVA" 
                     HeaderText="...Fecha Levante..." DataFormatString="{0:dd/MM/yyyy}">
                     <ItemStyle Wrap="False" Width="0px" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDRETI" DataFormatString="{0:dd/MM/yyyy}" 
                     HeaderText="...Fecha Retiro...">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="NRUC" HeaderText="....NIT....">
                     <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCDUIDUE" HeaderText="...DAM...">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCOBSE" HeaderText="...Obervaciones...">
                     <HeaderStyle Wrap="False" HorizontalAlign="Center" />
                     <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCNMMN" HeaderText="...Nro Manifiesto...">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCREFE" HeaderText="...Referencia..." >
                   <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="B_L" 
                     HeaderText="...Fecha BL...">
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="TCMPCL" HeaderText="....NombCli...." >
                   <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCDSCD" HeaderText="....Carga....">                                   
                   <FooterStyle HorizontalAlign="Center" />
                   <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="LIQUIDADOR" HeaderText="Liquidador">
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
             </Columns>
             <AlternatingRowStyle BackColor="Gainsboro" Wrap="False" />
            </asp:GridView>
            </div>
            </td>                       
        </tr>                    
   </table>   
<br />

</asp:Content>

