<%@ Page Title="Portfolio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Porfolio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <section id="home" class="home">
        <div class="contenedor-img">
            <img class="img-desing" src="src/images/CV-HD-img.jpg" alt="profile image">
        </div> 
        <h2>Luciano Tito Cedrón</h2>
        <h1 data-section="homes" data-value="profesion">Desarrollador Backend | .NET</h1>
        <div class="redes">
            <a title="linkedin__link" href="https://www.linkedin.com/in/luciano-facundo-tito-cedr%C3%B3n-093041261/" target="_blank"><i class='bx bxl-linkedin' ></i></a>
            <a title="cv__link" href="https://drive.google.com/file/d/1xFue1NPQ-sB7N1SBVQtz8FpPEgzigW7X/view?usp=sharing" target="_blank"><i class='bx bxs-file-pdf'></i></a>
            <a title="gitHub__link" href="https://github.com/LucianoTito" target="_blank"><i class='bx bxl-github'></i></a>
        </div>
    </section>

    <section id="acerca-de-mi" class="acerca-de-mi">
        <div class="contenido-seccion">
            <h2 data-section="acerca-de-mi" data-value="acerca-de-mi__title">Acerca de mí</h2>
            <p data-section="acerca-de-mi" data-value="description" class="description">
                Soy un desarrollador con formación en C++ y bases sólidas en algoritmos y estructuras de datos gracias a mis estudios en la Tecnicatura Universitaria en Programación (UTN). Actualmente me especializo en el ecosistema .NET (C#, Windows Forms, ASP.NET) con foco en desarrollo Backend, arquitectura en capas y bases de datos SQL Server. 
                Además, cuento con experiencia previa desarrollando aplicaciones web Full Stack con React y Node.js, lo que me permite tener una visión integral del ciclo de vida del software. Busco mi primera oportunidad profesional para aportar valor creando soluciones robustas y escalables.
            </p>
        </div>
    </section>

    <section id="mis-habilidades" class="mis-habilidades">
        <h2 class="titulo-seccion" data-section="mis-habilidades" data-value="titulo__seccion">Mis habilidades</h2>
        <div class="fila">
            <div class="habilidades"><i class='bx bx-code-curly icon'></i><h5>C# & .NET</h5></div>
            <div class="habilidades"><i class='bx bxl-c-plus-plus icon'></i><h5>C++</h5></div>
            <div class="habilidades"><i class='bx bx-data icon'></i><h5>SQL Server</h5></div>
            <div class="habilidades"><i class='bx bxl-postgresql icon'></i><h5>PostgreSQL</h5></div>
            <div class="habilidades"><i class='bx bxl-nodejs icon'></i><h5>Node.js</h5></div>
            <div class="habilidades"><i class='bx bxl-javascript icon'></i><h5>JavaScript</h5></div>
            <div class="habilidades"><i class='bx bxl-react icon'></i><h5>React.js</h5></div>
            <div class="habilidades"><i class='bx bxl-html5 icon'></i><h5>HTML5 & CSS3</h5></div>
            <div class="habilidades"><i class='bx bxl-github icon'></i><h5>Git & GitHub</h5></div>  
        </div>
    </section>

    <section id="portfolio" class="portfolio">
        <div class="contenido-seccion">
            <h2 class="portfolio-title" data-section="portafolio" data-value="portfolio-title">Portafolio</h2>
            <div class="galeria">
                
                <a href="https://github.com/LucianoTito/Curso-C-sharp-SQL-Nivel-2/tree/master/Unidad%209%20-%20Presentaci%C3%B3n%20Final/TPFinalNivel2_TitoCedron" target="_blank" class="proyecto">
                    <img src="src/images/catalogo-csharp.png" alt="Sistema de Gestión de Catálogo">
                    <div class="overlay">
                        <h3>Sistema de Gestión (ABM)</h3>
                        <p>C# .NET, Windows Forms, SQL Server</p>
                    </div>
                </a>

                <a href="https://github.com/LucianoTito/Sistema-Gestion-Cafeteria" target="_blank" class="proyecto">
                    <img src="src/images/basti-cafe.png" alt="Basti Café ERP">
                    <div class="overlay">
                        <h3>Basti Café ERP</h3>
                        <p>C++, POO, Archivos Binarios</p>
                    </div>
                </a>

                <a href="https://crossfitconverter.netlify.app/" target="_blank" class="proyecto">
                    <img src="src/images/cf_converter.png" alt="Conversor de Crossfit">
                    <div class="overlay">
                        <h3>Conversor de Crossfit</h3>
                        <p>React Vite</p>
                    </div>
                </a>

                <a href="https://tiendapowergripsalta.netlify.app/" target="_blank" class="proyecto">
                    <img src="src/images/pwr_grip.png" alt="Página de Ventas">
                    <div class="overlay">
                        <h3 class="random_phrases" data-section="portafolio" data-value="random_phrases">Tienda PowerGrip</h3>
                        <p>React Vite</p>
                    </div>
                </a>

                 <a href="https://pokedex-luciano-tito.netlify.app/" target="_blank" class="proyecto">
          <img src="/src/images/pokedex.png" alt="pokedex image">
          <div class="overlay">
            <h3>Pokedex</h3>
            <p>React Vite</p>
          </div>
        </a>

            </div>
        </div>
    </section>

</asp:Content>