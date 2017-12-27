<%@ Page Title="" Language="VB" MasterPageFile="~/MstEmpleado.master" AutoEventWireup="false" CodeFile="SeguimientoOrdenes.aspx.vb" Inherits="SeguimientoOrdenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="left: 253px; width: 679px; position: relative; top: 0px;">
            <tr>
                <td colspan="6" style="height: 21px; text-align:center ">
                    <span style="color: #000000">
                <strong>Seguimiento de Ordenes</strong> </span></td>
            </tr>
            <tr>
                <td style="height: 35px; width: 59px;">
                    <span style="color: #000000">Orden</span><span style="font-weight: normal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></td>
                <td style="height: 35px; width: 90px;">
                    <asp:TextBox ID="txtanio" runat="server" Width="86px">2013</asp:TextBox></td>
                <td style="width: 138px; height: 35px">
                    <asp:TextBox ID="txtOrden" runat="server" Width="128px"></asp:TextBox>
                </td>
                <td style="width: 105px; height: 35px; color: #000000;">
                    Fecha Registro</td>
                <td style="width: 205px; height: 35px">
                    <asp:TextBox ID="dtregistro" runat="server" Width="109px" ></asp:TextBox></td>
                <td style="height: 35px">
                    <asp:ImageButton ID="btnBusqueda" runat="server" Height="31px" ImageUrl="~/Imagenes/search.png"
                        Width="28px" ToolTip="Busqueda Online" /></td>
            </tr>
                                                                     
            <tr>
                <td style="height: 18px; width: 59px;">
                    </td>
                <td style="height: 18px; width: 90px;">
                    </td>
                <td style="height: 18px" colspan="3">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Size="Small" ForeColor="#B83E2D" Text="Label" Visible="False"></asp:Label>
                </td>
                <td style="height: 18px">
                    </td>
            </tr>
                                                                     
      </table>
     
      
    <table style="width: 100%;" align="center">
        <tr>
        <td style="border-style: groove; width: 307px">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" 
                Font-Size="Small" ForeColor="Black" Text="Leyenda : "></asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" 
                Font-Size="Small" ForeColor="Black" Text="Flag Envio : "></asp:Label>
&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/FlagGreen1-2.png" />
&nbsp
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" 
                Font-Size="Small" ForeColor="Black" Text="Flag No Envio : "></asp:Label>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/FlagRed1-1.png" />
            </td> <td></td><td></td>
        </tr>
        <tr>
            <td style="width: 307px">
                &nbsp;
                <span style="color: #000000">Envio Asinsa</span>&nbsp;
                
                <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" 
                    ImageUrl="~/Imagenes/Envio_Ascinsa.png" Width="48px" />
                </a>&nbsp;</td>
            <td style="width: 157px">
                &nbsp;
                </td>
            <td>
                &nbsp;
                <a href="NuevaOrdenServicio.aspx?TB_iframe=true&amp;height=515&amp;width=900" 
                    rel="sexylightbox">GENERAR NUEVA ORDEN DE SERVICIO...</a></td>
        </tr>
        <tr>
            <td colspan="3">
      
      <asp:GridView ID="gridOServ" runat="server" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
               CellPadding="3" Width="1041px" AutoGenerateColumns="False" 
               Font-Size="X-Small" ForeColor="#293B15" GridLines="Vertical" 
               EmptyDataText="No Existen Registros..." Height="16px" 
                PageSize="25" 
                    DataKeyNames="DCASCI,FNCDAD,PNCDRG,FNCDPR,DCDSME,DCCONT,PNCDOP,DNTRAN,DDVNDE,DNTPCA,DNCAM,DNFPAG,PNCDTR" >
                <PagerSettings Visible=false />
               <FooterStyle BackColor="#CCCCCC" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="center" />
               <SelectedRowStyle BackColor="#009B3A"  ForeColor="White" />
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
                 <asp:CommandField HeaderText="SELECCIONAR" ShowSelectButton="True">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle ForeColor="#0066FF" HorizontalAlign="Center" />
                        </asp:CommandField>
                 <asp:BoundField DataField="PNNMOS" HeaderText="ORDEN" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <%--<asp:BoundField DataField="TCMPCL" HeaderText="CLIENTE" >
                   <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False" />
                 </asp:BoundField>--%>
                 <asp:TemplateField HeaderText="CLIENTE">
                  <ItemTemplate>
                     <a href="NuevaOrdenServicio.aspx?CodOser=<%#DataBinder.Eval(Container.DataItem, "PNNMOS")%>&idRefer=<%#DataBinder.Eval(Container.DataItem, "DCREFE")%>&IdCli=<%#DataBinder.Eval(Container.DataItem, "DCASCI")%>&Contacto=<%#DataBinder.Eval(Container.DataItem, "DCCONT")%>&Aduana=<%#DataBinder.Eval(Container.DataItem, "FNCDAD")%>&Tipo=<%#DataBinder.Eval(Container.DataItem, "PNCDOP")%>&Medio=<%#DataBinder.Eval(Container.DataItem, "DNTRAN")%>&Regimen=<%#DataBinder.Eval(Container.DataItem, "PNCDRG")%>&Prioridad=<%#DataBinder.Eval(Container.DataItem, "FNCDPR")%>&FVenc=<%#DataBinder.Eval(Container.DataItem, "DDVNDE")%>&DescripM=<%#DataBinder.Eval(Container.DataItem, "DCDSME")%>&Tipocarga=<%#DataBinder.Eval(Container.DataItem, "DNTPCA")%>&Cantidad=<%#DataBinder.Eval(Container.DataItem, "DNCAM")%>&Tipopago=<%#DataBinder.Eval(Container.DataItem, "DNFPAG")%>&lblpndctr=<%#DataBinder.Eval(Container.DataItem, "PNCDTR")%>TB_iframe=true&amp;height=515&amp;width=900" rel='sexylightbox'>
                     <%#DataBinder.Eval(Container.DataItem, "TCMPCL")%></a></td> 
                  </ItemTemplate>                               
                   <ItemStyle Wrap="False" />
               </asp:TemplateField>
                 <asp:BoundField DataField="DCASCI" HeaderText="CodCli" Visible="False" />
               <asp:BoundField DataField="DCTPOS" HeaderText="TIPO" >
                   <FooterStyle HorizontalAlign="Center" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DCREFE" 
                     HeaderText="REFERENCIA" >
                   <FooterStyle HorizontalAlign="Center" />
                   <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="DDREGI" HeaderText="FECHA REGISTRO" >
                   <FooterStyle HorizontalAlign="Center" />
                   <HeaderStyle Width="0px" HorizontalAlign="Center" Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="PNCDRG" HeaderText="Regimen" Visible="False" />
                 <asp:BoundField DataField="FNCDAD" HeaderText="Aduana" Visible="False" />
                 <asp:BoundField DataField="FNCDPR" HeaderText="Prioridad" Visible="False" />
                 <asp:BoundField DataField="DCDSME" HeaderText="Descrip Mercaderia" 
                     Visible="False" />
               <%--<asp:BoundField DataField="SENVAS" HeaderText="FLAG ENVIO" >                   
                   <HeaderStyle Wrap="False" HorizontalAlign="Center" />
                   <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                 </asp:BoundField>--%>
                 <asp:TemplateField HeaderText="FLAG ENVIO">
                     <ItemTemplate>
                            <%#IIf(DataBinder.Eval(Container.DataItem, "SENVAS") = "S", "<img src='Imagenes/FlagGreen1-2.png' alt=" & DataBinder.Eval(Container.DataItem, "SENVAS").ToString() & " >", "<img src='Imagenes/FlagRed1-1.png' alt=" & DataBinder.Eval(Container.DataItem, "SENVAS").ToString() & "")%>
                     </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
                 
                 <asp:BoundField DataField="PNCDTR" Visible="False" />
             </Columns>
             <AlternatingRowStyle BackColor="Gainsboro" Wrap="False" />
            </asp:GridView>
      
            </td>
        </tr>
        <tr>
        <td style="height: 20px; width: 307px;"></td>
        <td style="height: 20px; " colspan="2">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                Font-Size="Small" ForeColor="#B83E2D" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        </table>
      
      </asp:Content>

