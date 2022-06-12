# Arquitetura da Solução

São apresentados nesta seção os detalhes técnicos da solução desenvolvida, tratando dos componentes que a integram e do ambiente de hospedagem utilizado para hospeda-la.

## Diagrama de Classes
![UML class - UML Class (2)](https://user-images.githubusercontent.com/74699119/173211970-b360a122-3f17-4c96-b575-6916f1df7b95.png)
<p align="center"><b>Figura 5</b> - Diagrama de classes do projeto</p>
<br>


## Modelo ER
![Uploading Diagrama ER.png…]()
<p align="center"><b>Figura 6</b> - Modelo de entidade/relacionamento do projeto</p>
<br>

## Esquema Relacional
![Esquema Relacional](https://user-images.githubusercontent.com/74699119/173211700-554f8d36-d74d-4454-9d16-ab64e35c07e4.png)
<p align="center"><b>Figura 7</b> - Esquema relacional do projeto</p>
<br>

## Tecnologias Utilizadas

Linguagens de progamação utilizadas:
- C#: Linguagem de progamação utilizada para desenvolvimento do backend da solução.
- Javascript: Linguagem de progamação utilizada no frontend para a implementação de certas funcionalidades.

Frameworks utilizados:
- ASP.NET Core MVC: Framework implementando o padrão Model-View-Controller, será utilizado como base para desenvolvimento da solução.
- Entity Framework Core: Framework de mapeamento objeto-relacional (técnica utilizada para resolver o problema da impedância entre o modelo orientado a objetos e o modelo relacional) para a plataforma .NET, será utilizado para facilitar a manipulação e consulta do banco de dados relacional utilizado aplicação.

Bibliotecas utilizadas:
- bcrypt.net-next: Biblioteca que permite criptografar senhas utilizando o método "bcrypt". Será utilizada para criptografar as senhas de usuário do sistema.
- X.PagedList: Biblioteca que adiciona suporte a paginação. Permite converter IQueryables/IEnumerables para "PagedLists" nos controllers, que podem ser passadas para as views de forma a mostrar apenas o conteúdo presente na página atualmente selecionada;
- jquery-ajax-unobtrusive: Biblioteca que permite adicionar atributos "data-" customizados ao HTML que permitem adicionar funções AJAX do JQuery a eles. É utilizada neste projeto para a realização de updates parciais nas páginas, sem necessitar recarregar a página inteira para alterar um único elemento (por exemplo, para atualizar o número presente no contador de novas mensagens sem precisar recarregar a página inteira).

APIs utilizadas:
- ASP.NET Core Identity: API que dá suporte a funcionalidade de login da interface do usuário. Será utilizado para implementar a função de login e autenticação do usuário, além da separação das contas por tipos de usuários.
- FluentEmail: API do .NET Core que permite o envio de emails dentro da aplicação;

IDE utilizada: Visual Studio Community 2022, escolhido pela integração com o Framework ASP.NET e outras ferramentas utilizadas no projeto como o SQL Server.

Sistema gerenciador de banco de dados: SQL Server, escolhido por sua boa integração com o editor de código e para facilitar a migração do banco de dados para o serviço de hospedagem nas fases mais avançadas do projeto.

Outras tecnologias:
- HTML: Linguagem de marcação utilizada para a construção das páginas web.
- CSS: Linguagem de folhas de estilos utilizada para aplicar estilos nos elementos HTML.
- Razor: Sintaxe de marcação que permite inserir código baseado em .NET em páginas web junto ao HTML.

A figura abaixo demonstra como as tecnologias empregadas se relacionam dentro do sistema e como ocorre a interação do usuário com o sistema até que ele retorne uma resposta ao usuário.

![Tecnologias Diagrama](https://user-images.githubusercontent.com/74699119/167978528-71abe26b-4789-4c34-b83b-36ee749b3ed8.png)
<p align="center"><b>Figura 8</b> - Tecnologias empregadas no sistema e retorno de resposta do sistema mediante requisição feita pelo usuário</p>
<br>

## Hospedagem

A hospedagem da solução foi realizada no serviço de hospedagem da SmarterASP.NET. Após o desenvolvimento local da aplicação, o projeto foi conectado a uma base de dados MSSQL remota criada no próprio SmarterASP.NET, onde as tabelas do projeto foram criadas utilizando-se o comando update-database do Entity Framework Core (utilizando o AppllicationDbContext.cs e as migrations desenvolvidas na criação do projeto). Após a migração da base de dados, o projeto foi publicado através da função Publish do Visual Studio Community 2022 utilizando as configurações do arquivo .XML fornecido pela própria SmarterASP.net para a página da aplicação.
