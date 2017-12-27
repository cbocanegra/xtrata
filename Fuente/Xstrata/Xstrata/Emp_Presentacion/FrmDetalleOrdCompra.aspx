<%@ Page Title="" Language="VB" MasterPageFile="~/MstEmpleado.master" AutoEventWireup="false" CodeFile="FrmDetalleOrdCompra.aspx.vb" Inherits="FrmDetalleOrdCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="left: 138px; width: 743px; position: relative; top: 12px;">
            <tr>
                <td style="height: 21px; text-align:center ">
                    <span style="color: #000000">
                    <strong><span style="font-size: small">Relación de ordenes de compra por O/Serv. </span></strong><span 
                        style="font-size: small"> &nbsp;<b> :</b></span></span><B><span style="color: #000000"><span 
                        style="font-size: small">&nbsp;
                    <asp:Label ID="lblOs" runat="server" Text="Label"></asp:Label>
                    </span></span>&nbsp;</B></td>
            </tr>
            <tr>
                <td style="height: 18px; color: #000000;">
                    &nbsp;</td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 35px">
                    <asp:TextBox ID="Bl" runat="server" Height="53px" 
                        TextMode="MultiLine" Width="598px" ReadOnly="True">Este módulo le permitirá identificar las distintas ordenes de compra para una orden de servicio. Si desea generar esta información en excel dar click en el icono situado a la derecha. </asp:TextBox></td>
                <td style="height: 35px">
                    Generar Reporte
                    <asp:ImageButton ID="btnBusqueda" runat="server" Height="31px" ImageUrl="~/Imagenes/excel1.gif"
                        Width="28px" ToolTip="Exportar a Excel...." /></td>
            </tr>
           </table>
           <br />           
           <table width: 400px;>
           <tr><td style="color: #000000"><b>
               <asp:Label ID="lblAduana" runat="server" Text="ADUANAS"></asp:Label>
               </b></td></tr>
           <tr>           
           <td valign="top">
               <asp:GridView ID="GdvCabAduanas" runat="server" BackColor="White" 
               BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
               CellPadding="3" Width="927px" AutoGenerateColumns="False" 
               Font-Size="X-Small" ForeColor="#293B15" GridLines="Vertical" 
               EmptyDataText="No Existen Registros..." Height="16px" 
                PageSize="25" >
               <FooterStyle BackColor="#CCCCCC" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" />
               <SelectedRowStyle BackColor="#70822C" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#009B3A" Font-Bold="True" ForeColor="White" Wrap="False" />
             <Columns>                                    
                 <asp:BoundField DataField="TPSRVA" HeaderText="...T/S..." />
               <asp:BoundField DataField="TCMTSR" HeaderText="Regimen" />
               <asp:BoundField DataField="NORDSR" HeaderText="Nro Orden Serv." />
               <asp:BoundField DataField="REFRNC" HeaderText="Ref. Orden" />
               <asp:BoundField DataField="VALMRC" HeaderText="Valor Mercaderia" />
               <asp:BoundField DataField="VALFLT" HeaderText="Valor Flete" />
               <asp:BoundField DataField="VALSEG" HeaderText="Valor Seguro"/>                                   
               <asp:BoundField DataField="IMPCIF" HeaderText="Valor CIF" />
               
               <asp:BoundField DataField="VALADV" HeaderText="Valor Advalorem" />
               <asp:BoundField DataField="VALSBT" HeaderText="Valor Sobretasa" />
               <asp:BoundField DataField="VALIGV" HeaderText="Valor IGV" />
               <asp:BoundField DataField="VALIPM" HeaderText="Valor IPM" />
             </Columns>
             <AlternatingRowStyle BackColor="Gainsboro" Wrap="False" />
            </asp:GridView>
            </td>
            </tr>
           </table>
           
           <br />
           <br />                                         
           <table width: 400px;>
           <tr><td style="color: #000000">
               <asp:Label ID="lblDetalle" 
                   runat="server" Text="DETALLE ADUANAS"></asp:Label>
               </b></td></tr>
           <tr>           
           <td >
                <div class="DivDetalleDua">
               <asp:GridView ID="GdvDetalleDua" runat="server" BackColor="White" 
               BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
               CellPadding="3" Width="927px" AutoGenerateColumns="False" 
               Font-Size="X-Small" ForeColor="#293B15" GridLines="Vertical" 
               EmptyDataText="No Existen Registros..." Height="16px" 
                PageSize="25" >
               <FooterStyle BackColor="#CCCCCC" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" />
               <SelectedRowStyle BackColor="#70822C" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#009B3A" Font-Bold="True" ForeColor="White" Wrap="False" />
             <Columns>                                    
                 <asp:BoundField DataField="TPSRVA" HeaderText="...T/S..." >
                 <HeaderStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="NORDSR" HeaderText="Nro Orden Serv." >
                 <HeaderStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="NSERIE" HeaderText="Nro. Serie" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="PARTID" HeaderText="Partida" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="NMRFCT" HeaderText="...Nro Fac. Comercial..." >
                 <FooterStyle HorizontalAlign="Center" />
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
               <asp:BoundField DataField="NMITFC" HeaderText="Nro Item Fact.">                                   
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               
               <asp:BoundField DataField="NMRODC" HeaderText="Nro Ord Compra" >
               
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                                  
                <asp:TemplateField HeaderText="Nro Ord Compra">
                  <ItemTemplate>
                     <a href="FrmDetalleOrdenCompra.aspx?NroOrden=<%#DataBinder.Eval(Container.DataItem, "NMRODC")%>TB_iframe=true&height=400&width=1000" rel='sexylightbox'>
                     <%#DataBinder.Eval(Container.DataItem, "NMRODC")%></a></td>         
                  </ItemTemplate>                               
                     <HeaderStyle Wrap="False" />
                     <ItemStyle Wrap="False" />
               </asp:TemplateField>
               
               <asp:BoundField DataField="NMITOC" HeaderText="Nro Item O/Compra" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALMRC" HeaderText="Mercaderia" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALFLT" HeaderText="....Flete...." >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALSEG" HeaderText="....Seguro...." >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALFOB" HeaderText="....FOB...." >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="IMPCIF" HeaderText="....CIF...." > 
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALADP" HeaderText="....Antidump...." >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALMOR" HeaderText="....Mora...." > 
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALADV" HeaderText="....ADV...." > 
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALSBT" HeaderText="....SBT...." > 
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALDES" HeaderText="....DES...." > 
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALISC" HeaderText="....ISC...." > 
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALIGV"  HeaderText="....IGV...." >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALIPM" HeaderText="....IPM...." > 
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALICP" HeaderText="....ICP...." > 
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
               <asp:BoundField DataField="VALRNP" HeaderText="....RNP...." > 
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
           <br />
           <br />
     
</asp:Content>

