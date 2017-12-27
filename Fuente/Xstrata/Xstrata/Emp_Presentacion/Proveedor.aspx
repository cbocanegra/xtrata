<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Proveedor.aspx.vb" Inherits="Proveedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Lista de Proveedores</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" BorderColor="#C00000" Font-Bold="True" Font-Size="Large"
            ForeColor="Maroon" Text="Proveedores"></asp:Label><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
        <br />
        <br />
        <asp:GridView ID="GdvProveedor" runat="server" BackColor="White" BorderColor="#CC9966"
            BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" AutoGenerateColumns="False" 
            Font-Size="Small">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" Font-Size="Small" />
            <EmptyDataRowStyle Font-Size="Small" />
            <Columns>
                <asp:BoundField DataField="IdProveedor" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="representante" HeaderText="Representante" />
                <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
            </Columns>
            <EditRowStyle Font-Size="X-Small" />
        </asp:GridView>
        &nbsp;</div>
    </form>
</body>
</html>
