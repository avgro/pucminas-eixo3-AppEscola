# Arquitetura da Solução

São apresentados nesta seção os detalhes técnicos da solução desenvolvida, tratando dos componentes que a integram e do ambiente de hospedagem utilizado para hospeda-la.

## Diagrama de Classes

![Diagrama de Classes ADS 2022_1](https://user-images.githubusercontent.com/74699119/162635543-7bc38991-6b57-41e4-a14d-8c24d2e5b7c2.png)
<p align="center"><b>Figura 5</b> - Diagrama de classes do projeto</p>
<br>


## Modelo ER

![Diagrama ER ADS 2022_1](https://user-images.githubusercontent.com/74699119/162635473-51679df0-6ec5-401a-9022-0262ee26aa39.png)
<p align="center"><b>Figura 6</b> - Modelo de entidade/relacionamento do projeto</p>
<br>

## Esquema Relacional

![Esquema Relacional ADS 2022_1](https://user-images.githubusercontent.com/74699119/161871528-dd3a133a-2ded-4955-ada7-43c69ddfb13e.png)
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

APIs utilizadas:
- ASP.NET Core Identity: API que dá suporte a funcionalidade de login da interface do usuário. Será utilizado para implementar a função de login e autenticação do usuário, além da separação das contas por tipos de usuários.

IDE utilizada: Visual Studio Community 2022, escolhido pela integração com o Framework ASP.NET e outras ferramentas utilizadas no projeto como o SQL Server.

Sistema gerenciador de banco de dados: SQL Server, escolhido por sua boa integração com o editor de código e para facilitar a migração do banco de dados para o serviço de hospedagem nas fases mais avançadas do projeto.

Outras tecnologias:
- HTML: Linguagem de marcação utilizada para a construção das páginas web.
- CSS: Linguagem de folhas de estilos utilizada para aplicar estilos nos elementos HTML.
- Razor: Sintaxe de marcação que permite inserir código baseado em .NET em páginas web junto ao HTML.

A figura abaixo demonstra como as tecnologias empregadas se relacionam dentro do sistema e como ocorre a interação do usuário com o sistema até que ele retorne uma resposta ao usuário.

![Figura Tecnologias e Resposta ADS 2022_1](https://user-images.githubusercontent.com/74699119/162551814-41649e37-208d-4efc-a24b-4fbc8d2e1cce.png)
<p align="center"><b>Figura 8</b> - Tecnologias empregadas no sistema e retorno de resposta do sistema mediante requisição feita pelo usuário</p>
<br>

## Hospedagem

A hospedagem da solução será feita no serviço de hospedagem da SmarterASP.NET. Após o desenvolvimento local da aplicação, os dados da base de dados local do projeto serão migrados para uma nova base de dados MSSQL criada dentro do serviço de hospedagem e a publicação da aplicação na plataforma será realizada com auxílio da funcionalidade "Publicar" do Visual Studio Community.
