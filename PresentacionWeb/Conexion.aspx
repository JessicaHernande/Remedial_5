<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Conexion.aspx.cs" Inherits="PresentacionWeb.Conexion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:GridView ID="GridView1" CssClass="table" runat="server"></asp:GridView>
    </div>

    <br />
    <br />
    <div>
        Cliente<asp:DropDownList ID="DropDownList1" CssClass="form-select" runat="server"></asp:DropDownList><br />
        Auto<asp:DropDownList ID="DropDownList2" CssClass="form-select" runat="server"></asp:DropDownList><br />
        Marca<asp:DropDownList ID="DropDownList3" CssClass="form-select" runat="server"></asp:DropDownList><br />
        Mecanico<asp:DropDownList ID="DropDownList4" CssClass="form-select" runat="server"></asp:DropDownList><br />
        Fecha Entrada<asp:TextBox ID="TextBox1" CssClass="form-control" type="date" runat="server"></asp:TextBox><br />
        Descripcion<asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox><br />

        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Agregar" OnClick="Button1_Click" /><br />
    </div>
</asp:Content>
