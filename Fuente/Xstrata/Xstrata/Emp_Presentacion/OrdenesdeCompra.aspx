<%@ Page Title="" Language="VB" MasterPageFile="~/MstEmpleado.master" AutoEventWireup="false" CodeFile="OrdenesdeCompra.aspx.vb" Inherits="OrdenesdeCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="left: 281px; width: 655px; position: relative; top: 2px;">
            <tr>
                <td colspan="4" style="height: 21px; text-align:left">
                    <span style="color: #000000">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seguimiento de Ordenes de Compra</strong></span></td>
            </tr>
            <tr>
                <td style="color: #000000; width: 120px;" rowspan="2">
                    <asp:RadioButton ID="opcCIF" runat="server" GroupName="OpcOrdCompra" 
                        Text="CIF" />
                    <br />
                    <asp:RadioButton ID="OpcPeso" runat="server" GroupName="OpcOrdCompra" 
                        Text="PESO" />
                </td>
                <td style="height: 18px; color: #000000; width: 240px;">
                    <B>Ingesar Ordenes de Compra</B></td>
                <%--<td style="width: 205px; height: 18px; color: #000000;">
                    <B>Referencia</B></td>--%>
                <%--<td style="width: 205px; height: 18px">
                    <span style="color: #000000">
                    <B>Mercaderia</B></span>
                </td>--%>
                <td style="width: 205px; height: 18px">
                    Busqueda </td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 35px; width: 240px;">
                    <asp:TextBox ID="txtOrdenesCompra" runat="server"></asp:TextBox></td>
                <td style="width: 205px; height: 35px">
                    <asp:ImageButton ID="btnBusqueda" runat="server" Height="31px" ImageUrl="~/Imagenes/search.png"
                        Width="28px" ToolTip="Busqueda Online" /></td>
                <td style="width: 205px; height: 35px">
                    &nbsp;</td>                                           
            </tr>
            <TR><td></td> <td colspan="3">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Black" 
                    Text="Label" Visible="False"></asp:Label>
                </td>
            </TR>
      </table>
      <BR />
      <BR />
      <TABLE>
      <TR><td colspan = 2>
          <asp:GridView ID="gdvOrdenCompra" runat="server" 
              AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
              BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
              EmptyDataText="No Existen Registros..." Font-Size="X-Small" ForeColor="#293B15" 
              GridLines="Vertical" Height="16px" PageSize="25" Width="939px">
              <FooterStyle BackColor="#CCCCCC" />
              <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" />
              <SelectedRowStyle BackColor="#70822C" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#009B3A" Font-Bold="True" ForeColor="White" 
                  Wrap="False" />
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
                 
                 
                  <asp:BoundField DataField="NMRODC" HeaderText="Nro Orden Compra">
                  <HeaderStyle Wrap="False" />
                  <ItemStyle Wrap="False" />
                  </asp:BoundField>
                  <asp:BoundField DataField="NOMVAR" HeaderText="Concepto">
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
                  <asp:BoundField DataField="VALMRC" HeaderText="Valor">
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
          </TR>
          <TR>
          <td style="text-align: right"></td><td style="text-align: right; color: #000000;">&nbsp;<asp:Label 
                  ID="lblTotal" runat="server" Text="Total :" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtSuma" runat="server" ReadOnly="True" Visible="False" 
                  Width="102px"></asp:TextBox>
              </td>
          </TR>
         <%-- <td></td>--%>
      </TABLE>
      
</asp:Content>

