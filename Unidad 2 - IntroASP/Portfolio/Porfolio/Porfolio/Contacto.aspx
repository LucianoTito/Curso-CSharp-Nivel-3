<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Porfolio.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <section id="contacto" class="contacto" style="padding-top: 100px; min-height: 100vh;">
        <h2 class="titulo-seccion" data-section="contacto" data-value="titulo-seccion">Contacto</h2>
        
        <div class="fila__contact">
            <div class="contacto-data" onclick="redirectToWhatsapp()">
                <span class="icono"><img src="/src/icons/phone.svg" alt="phone_img"></span>
                <h4 class="contact-number" data-section="contacto" data-value="contact-number">Número celular</h4>
                <a href="https://wa.me/543874527977" target="_blank">+54 387 4527977</a>
            </div>
            <div class="contacto-data" onclick="redirectToEmail()">
                <span class="icono"><img src="/src/icons/mail 1.svg" alt=""></span>
                <h4>Email</h4>
                <a href="mailto:lucianotitocedron@gmail.com" target="_blank">lucianotitocedron@gmail.com</a>
            </div>
        </div>
        
        <div class="contact__container">
            <h2 class="contact__title" data-section="contacto" data-value="form-seccion">Si quieres dejarme algún mensaje...</h2>
            
            <label class="contact__name" for="nombre" data-section="contacto" data-value="name">Nombre:</label>
            <input type="text" id="nombre" name="nombre" required>
        
            <label class="contact__phone" for="telefono" data-section="contacto" data-value="contact-number">Número celular:</label>
            <input type="tel" id="telefono" name="telefono" data-section="contacto" data-value="phone" placeholder="Ingresa tu teléfono" required>
        
            <label class="contact__email" for="email">Email:</label>
            <input type="email" id="email" name="email" data-section="contacto" data-value="email" placeholder="Ingresa tu email" required>
        
            <label class="contact__msg" for="mensaje" data-section="contacto" data-value="message">Mensaje:</label>
            <textarea data-section="contacto" data-value="contact-description" placeholder="Escribe aquí..." id="mensaje" name="mensaje" required></textarea>
        
            <input class="send__input" type="submit" data-section="contacto" data-value="button" value="Enviar"> 
        </div>

    </section>
</asp:Content>