<%@ Page Title="" Language="VB" MasterPageFile="~/MstEmpleado.master" AutoEventWireup="false" CodeFile="FrmXstrata.aspx.vb" Inherits="FrmXstrata" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="left: 253px; width: 679px; position: relative; top: 0px;">
            <tr>
                <td colspan="6" style="height: 21px; text-align:left">
                    <span style="color: #000000">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    CONSULTAS&nbsp;&nbsp; XSTRATA</strong></span></td>
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
                <td style="width: 105px; height: 35px; color: #000000; text-align: right;">
                    <asp:ImageButton ID="btnBusqueda" runat="server" Height="31px" ImageUrl="~/Imagenes/search.png"
                        Width="28px" ToolTip="Busqueda Online" /></td>
                <td style="width: 205px; height: 35px">
                    &nbsp;</td>
                <td style="height: 35px">
                    &nbsp;</td>
            </tr>
                                                                     
           <%-- <tr>
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
            </tr>--%>
                                                                     
      </table>
      <br />
      <table style="width: 100%;" align="center">
       <%-- <tr>        
            <td></td>
            <td></td>
            <td></td>
        </tr>--%>
        <%--<tr>
            <td >
                
                </td>
            <td style="width: 157px">
                &nbsp;
                </td>
            <td>                                   
             </td>
        </tr>--%>
        <tr><td>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Refrescar1.png" />
&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Font-Bold="True" Height="22px" 
                Text="Refrescar" Width="184px" Visible="False" />
            </td><td>&nbsp;
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/WebService2.png" />
&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Height="22px" Text="Consumir Nuevo" 
                Width="138px" Font-Bold="True" Visible="False" />
            </td><td>&nbsp;</td></tr>
        <tr>
            <td colspan="3" valign="top">
             <div class="DivScrollTecnica" >
      <asp:GridView ID="gridOServ" runat="server" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
               CellPadding="3" Width="1232px" AutoGenerateColumns="False" 
               Font-Size="X-Small" ForeColor="#293B15" GridLines="Vertical" 
               EmptyDataText="No Existen Registros..." Height="16px" 
                    DataKeyNames="PNNMOS" AllowPaging="True" >
                <PagerSettings PageButtonCount="20" />
               <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Left" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" 
                    VerticalAlign="Middle" />
               <SelectedRowStyle BackColor="#009B3A" />
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
                 <%--<asp:CommandField HeaderText="SELECCIONAR" ShowSelectButton="True">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle ForeColor="#0066FF" HorizontalAlign="Center" />
                        </asp:CommandField>--%>
                 <%--<asp:BoundField DataField="TCMPCL" HeaderText="CLIENTE" >
                   <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False" />
                 </asp:BoundField>--%>
                 <%--<asp:TemplateField HeaderText="CLIENTE">
                  <ItemTemplate>
                     <a href="NuevaOrdenServicio.aspx?CodOser=<%#DataBinder.Eval(Container.DataItem, "PNNMOS")%>&idRefer=<%#DataBinder.Eval(Container.DataItem, "DCREFE")%>&IdCli=<%#DataBinder.Eval(Container.DataItem, "DCASCI")%>&Contacto=<%#DataBinder.Eval(Container.DataItem, "DCCONT")%>&Aduana=<%#DataBinder.Eval(Container.DataItem, "FNCDAD")%>&Tipo=<%#DataBinder.Eval(Container.DataItem, "PNCDOP")%>&Medio=<%#DataBinder.Eval(Container.DataItem, "DNTRAN")%>&Regimen=<%#DataBinder.Eval(Container.DataItem, "PNCDRG")%>&Prioridad=<%#DataBinder.Eval(Container.DataItem, "FNCDPR")%>&FVenc=<%#DataBinder.Eval(Container.DataItem, "DDVNDE")%>&DescripM=<%#DataBinder.Eval(Container.DataItem, "DCDSME")%>&Tipocarga=<%#DataBinder.Eval(Container.DataItem, "DNTPCA")%>&Cantidad=<%#DataBinder.Eval(Container.DataItem, "DNCAM")%>&Tipopago=<%#DataBinder.Eval(Container.DataItem, "DNFPAG")%>&lblpndctr=<%#DataBinder.Eval(Container.DataItem, "PNCDTR")%>TB_iframe=true&amp;height=515&amp;width=900" rel='sexylightbox'>
                     <%#DataBinder.Eval(Container.DataItem, "TCMPCL")%></a></td> 
                  </ItemTemplate>                               
                   <ItemStyle Wrap="False" />
               </asp:TemplateField>--%>
                 <%--<asp:BoundField DataField="SENVAS" HeaderText="FLAG ENVIO" >                   
                   <HeaderStyle Wrap="False" HorizontalAlign="Center" />
                   <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                 </asp:BoundField>--%>
                                  
                 <asp:BoundField DataField="PNDCTR" Visible="False" HeaderText="PNDCTR1" />
                 <asp:BoundField DataField="PNCDNG" HeaderText="PNCDNG1" Visible="False" />
                 <asp:BoundField DataField="PNCDZO" HeaderText="PNCDZO1" Visible="False" />
                 <asp:BoundField DataField="PNDCPL" HeaderText="PNDCPL1" Visible="False" />
                 <asp:BoundField DataField="PNCDOP" HeaderText="PNCDOP1" Visible="False" />
                 <asp:BoundField DataField="DCDSOP" HeaderText="DESCRIPCION" Visible="False" />
                 <asp:BoundField DataField="DCASCI" HeaderText="CODIGO" Visible="False" />
                 <asp:BoundField DataField="DCREFE" HeaderText="REFERENCIA" Visible="False" />
                 <asp:TemplateField HeaderText="Modif.">
                      <ItemTemplate>
                        <asp:ImageButton ID="ibt1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PNNMOS") & "," & DataBinder.Eval(Container.DataItem, "PNCDZO").ToString() & "," & DataBinder.Eval(Container.DataItem, "DCTPOS").ToString() & "," & DataBinder.Eval(Container.DataItem, "PNDCTR").ToString() & "," & DataBinder.Eval(Container.DataItem, "PCNMDC").ToString() & "," & DataBinder.Eval(Container.DataItem, "DDREGI").ToString()%> '
                              ImageUrl="~/Imagenes/Modifica13.png" onclick="ibt_Click2"                                                 
                              onclientclick="" />    
                       </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                 
                 <asp:BoundField DataField="DESPAC" HeaderText="----TI----" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="PNNMOS" HeaderText="-----N° Orden-----" 
                     Visible="False" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                  
                 <asp:TemplateField HeaderText="-----N° Orden-----">
                  <ItemTemplate>
                     <a href="FrmPopupXstrata.aspx?CodOser=<%#DataBinder.Eval(Container.DataItem, "PNNMOS")%>&BL=<%#DataBinder.Eval(Container.DataItem, "PCNMDC")%>&FecEstimad=<%#DataBinder.Eval(Container.DataItem, "DDETLG")%>&FecLlegada=<%#DataBinder.Eval(Container.DataItem, "DDNAVE")%>&Cli=<%#DataBinder.Eval(Container.DataItem, "TCMPCL")%>&DTI=<%#DataBinder.Eval(Container.DataItem, "DESPAC")%>&Mercancia=<%#DataBinder.Eval(Container.DataItem, "DCDSME")%>&Tipo=<%#DataBinder.Eval(Container.DataItem, "DCTPOS")%>&V_PNDCTR=<%#DataBinder.Eval(Container.DataItem, "PNDCTR")%>&V_DDRDDC=<%#DataBinder.Eval(Container.DataItem, "DDRDDC")%>&V_DDCRDP=<%#DataBinder.Eval(Container.DataItem, "DDCRDP")%>&V_DDOEMB=<%#DataBinder.Eval(Container.DataItem, "DDOEMB")%>&V_DNSBRE=<%#DataBinder.Eval(Container.DataItem, "DNSBRE")%>&V_DNDSLB=<%#DataBinder.Eval(Container.DataItem, "DNDSLB")%>&V_DDTDES=<%#DataBinder.Eval(Container.DataItem, "DDTDES")%>&V_DDTREC=<%#DataBinder.Eval(Container.DataItem, "DDTDES")%>&V_DDOBVL=<%#DataBinder.Eval(Container.DataItem, "DDOBVL")%>&V_DDAFPR=<%#DataBinder.Eval(Container.DataItem, "DDAFPR")%>&V_VDDFINA=<%#DataBinder.Eval(Container.DataItem, "VDDFINA")%>&V_DDANUM=<%#DataBinder.Eval(Container.DataItem, "DDANUM")%>&V_DDNUME=<%#DataBinder.Eval(Container.DataItem, "DDNUME")%>&V_DDPGDR=<%#DataBinder.Eval(Container.DataItem, "DDPGDR")%>&V_DDAFOR=<%#DataBinder.Eval(Container.DataItem, "DDAFOR")%>&V_DDPRES=<%#DataBinder.Eval(Container.DataItem, "DDPRES")%>&V_DDLEVA=<%#DataBinder.Eval(Container.DataItem, "DDLEVA")%>&V_DDRETI=<%#DataBinder.Eval(Container.DataItem, "DDRETI")%>TB_iframe=true&amp;height=250&amp;width=720" rel='sexylightbox'>
                     <%#DataBinder.Eval(Container.DataItem, "PNNMOS")%></a></td> 
                  </ItemTemplate>                               
                     <HeaderStyle Wrap="False" />
                   <ItemStyle Wrap="False" HorizontalAlign="Center" />
               </asp:TemplateField>
                 
                 <asp:BoundField DataField="TCMPCL" HeaderText="Cliente" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCDSME" HeaderText="Mercancia" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCTPOS" HeaderText="---Tipo---" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDREGI" HeaderText="Fecha" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="PNCDRG" HeaderText="----Reg----" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCDSRG" HeaderText="Operacion" Visible="False" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="TCMPRO" HeaderText="Operacion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCNAVE" HeaderText="Vapor" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="FECHABL" HeaderText="Fecha B/L" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCMOTI" HeaderText="----BL----">
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="PCNMDC" HeaderText="N° Embarque" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDETLG" HeaderText="Fecha Estimada" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDNAVE" HeaderText="Fecha Llegada" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDTDES" HeaderText="Termino Descarga" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCDSAB" HeaderText="Deposito" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDOBVL" HeaderText="Fecha Ubicacion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDAFPR" HeaderText="Previo" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="VDDFINA" HeaderText="Visto Bueno" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDANUM" HeaderText="Autorizacion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDNUME" HeaderText="Numeracion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDPGDR" HeaderText="Fecha Pago" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCCANA" HeaderText="Canal" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCCANA" HeaderText="CANAL" Visible="False" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCOBSE" HeaderText="Tipo de Bulto" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDOBDT" HeaderText="Libre Estadia" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCINDD" HeaderText="Devolucion de Contenedor" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDRETI1" HeaderText="Devolucion Contenedor" 
                     Visible="False" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDSENA" HeaderText="Senasa Insripcion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDINSP" HeaderText="Senasa Inspeccion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DOSENA" HeaderText="Senasa Obtencion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDAFOR" HeaderText="Fecha Aforo" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDPRES" HeaderText="Fecha Presentacion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDLEVA" HeaderText="Fecha Levante" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDRETI" HeaderText="Fecha Retiro" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="LIQUIDADOR" HeaderText="Liquidador" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCNMRM" HeaderText="N° Expediente" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDCREC" HeaderText="F. Prest Expediente" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDTREC" HeaderText="F.Termino Expediente" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="NRUC" HeaderText="NIT" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCOBSE1" HeaderText="Observacion" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCCTRL" HeaderText="Flag" Visible="False" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DCDUIDUE" HeaderText="DAM" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDRDDC" HeaderText="F.Recepcion Doc" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDCRDP" HeaderText="F.Carga" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DDOEMB" HeaderText="F.Embarque" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DNSBRE" HeaderText="Dias Sobreestadia" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
                 <asp:BoundField DataField="DNDSLB" HeaderText="Dias Libres" >
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
                 </asp:BoundField>
             </Columns>
             <AlternatingRowStyle BackColor="Gainsboro" Wrap="False" />
            </asp:GridView>
               </div> 
            </td>
        </tr>
        <%--<tr>
        <td style="height: 20px; width: 307px;"></td>
        <td style="height: 20px; " colspan="2">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                Font-Size="Small" ForeColor="#B83E2D" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>--%>
        </table>
        <br />
        <table>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Detalle" Font-Bold="True" 
                Font-Size="Medium" ForeColor="Black" Visible="False"></asp:Label></td>
        <td>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                ForeColor="Black" Text="ChekPoint" Visible="False"></asp:Label>
            </td>
        <td>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                ForeColor="Black" Text="Costos" Visible="False"></asp:Label>
            &nbsp;<asp:Button ID="btnDistribucion" runat="server" Height="20px" Text="Dist. Costos" 
                Width="93px" Font-Bold="True" Visible="False" />
            </td></tr>
        <tr>
        <td valign="top"> 
         <div class="DivScrollTecnicaChkPoint" >                  
         <asp:GridView ID="GdvDetalle" runat="server" AutoGenerateColumns="False" Width="658px"
                                    Font-Size="X-Small" ForeColor="#293B15" 
                EmptyDataText="No Existen Registros..." Visible="False" >
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#70822C" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#009B3A" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="NSERIE" HeaderText="Serie" />
                                            <asp:BoundField HeaderText="Nro Orden Compra" DataField="NMRODC" >
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Nro Item" DataField="NMITOC" />
                                            <asp:BoundField HeaderText="Val. AdValorem" DataField="VALADV" >
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Valor IPM" DataField="VALIPM" />
                                          <%--  <asp:TemplateField HeaderText="Selec.">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibt1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CZNAIN") & "," & DataBinder.Eval(Container.DataItem, "CINSPC").ToString() & "," & DataBinder.Eval(Container.DataItem, "TCMZNI").ToString() & "," & DataBinder.Eval(Container.DataItem, "CINSPC").ToString() & "," & DataBinder.Eval(Container.DataItem, "TINSP").ToString() %> '
                                                ImageUrl="~/Imagenes/Modifica1.png" onclick="ibt_Click1"                                                 
                                                onclientclick="" />    
                                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                   </asp:TemplateField>--%><asp:BoundField HeaderText="Valor IGV" DataField="VALIGV" />
                                            <asp:BoundField HeaderText="Valor Comision" DataField="VALCOM" />
                                            <asp:BoundField HeaderText="Valor Gastos" DataField="VALGAS" />
                                            <asp:BoundField DataField="VALTRA" HeaderText="Valor Traccion" />
                                        </Columns>
                                    </asp:GridView>
                                    </div> 
                                  
        </td>
        
        <td valign ="top">
        
<asp:GridView ID="GdvChkPoint" runat="server" AutoGenerateColumns="False" Width="361px"
                                    Font-Size="X-Small" ForeColor="#293B15" 
                EmptyDataText="No Existen Registros..." Visible="False" >
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#70822C" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#009B3A" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <%--<asp:BoundField DataField="CODIGO" HeaderText="Codigo" />--%>
                                            <asp:TemplateField HeaderText="Codigo">
                                                <ItemTemplate>
                                                    <a href="FrmChkPointPopup.aspx?VCodigo=<%#DataBinder.Eval(Container.DataItem, "CODIGO")%>&VDescripcion=<%#DataBinder.Eval(Container.DataItem, "DESCRIPCION")%>&DFecha=<%#DataBinder.Eval(Container.DataItem, "FECHA")%>TB_iframe=true&amp;height=170&amp;width=720" rel='sexylightbox'>
                                                    <%#DataBinder.Eval(Container.DataItem, "CODIGO")%></a></td> 
                                                </ItemTemplate>                               
                                                <HeaderStyle Wrap="False" />
                                                <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="ChkPoint" DataField="DESCRIPCION" >
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha" DataField="FECHA" />
                                         <%--   <asp:TemplateField HeaderText="Selec.">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibt1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CZNAIN") & "," & DataBinder.Eval(Container.DataItem, "CINSPC").ToString() & "," & DataBinder.Eval(Container.DataItem, "TCMZNI").ToString() & "," & DataBinder.Eval(Container.DataItem, "CINSPC").ToString() & "," & DataBinder.Eval(Container.DataItem, "TINSP").ToString() %> '
                                                ImageUrl="~/Imagenes/Modifica1.png" onclick="ibt_Click1"                                                 
                                                onclientclick="" />    
                                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                   </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>        
        </td>
        
        <td valign="top">
        <asp:GridView ID="GdvCostos" runat="server" AutoGenerateColumns="False" Width="168px"
                                    Font-Size="X-Small" ForeColor="#293B15" 
                EmptyDataText="No Existen Registros..." Visible="False" >
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#70822C" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#009B3A" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="CDESCOS" HeaderText="Descripcion" />
                                            <asp:BoundField HeaderText="Costo" DataField="NVALORI" >
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CCODCOS" HeaderText="Codigo" Visible="False" />
                                        </Columns>
                                    </asp:GridView>
        </td>
        
        </tr>
        </table>

</asp:Content>

