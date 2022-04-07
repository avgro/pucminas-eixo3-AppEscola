
# Projeto de Interface

Para o desenvolvimento do sistema em questão, foram projetadas telas buscando-se uma identidade visual intuitiva e padronizada entre as diferentes telas do sistema. Com a navegação entre as diferentes funcionalidades ocorrendo através dos itens do cabeçalho e do menu lateral, que se encontram presentes em todas as telas após o login do usuário. Também foi levado em consideração a responsividade do sistema para funcionamento tanto em desktop quanto em dispositivos móveis.

## Diagrama de Fluxo

![Diagrama de Fluxo do Usuario ADS 2022_1_versao2](https://user-images.githubusercontent.com/74699119/161865551-187fd8c1-57fa-46f2-89b4-0887ca632947.png)
<p align="center"><b>Figura 4</b> - Diagrama de fluxo do usuário do projeto</p>
<br>

## Wireframe Interativo

Conforme o diagrama de fluxo do projeto apresentado no item anterior, as telas do sistema são apresentados em detalhes nos itens que se seguem. 
O wireframe interativo do projeto encontra-se disponível em: https://lucid.app/documents/embeddedchart/660ffadd-238f-49f7-9ed3-5b89b8208a25?invitationId=inv_d8efbf44-b38b-48bc-9c44-65305935decf# 

A estrutura de interface será comum em todas as telas do sistema após a realização do login. A figura abaixo ilustra a divisão dos conteúdos nestas telas. 
Observamos que a estrutura está dividida em seções:
* Cabeçalho - Onde são dispostos os elementos fixos da navegação principal do site, cujo será apresentado em todas as telas para todos os usuários do sistema.
* Menu lateral - Apresenta os menus de navegação do sistema e é associado ao conteúdo da tela. A tabela de Menu será diferente e de acordo com o nível de acesso de cada usuário. 
* Conteúdo - Onde é apresentado o conteúdo das telas.
* Rodapé - Nesta tabela é apresentado as informações de contato e copyright.

![Estrutura de interface](https://user-images.githubusercontent.com/89323922/162098121-d093dcc0-0448-4161-bc2f-da9640ca54fb.png)

Para as telas de homepage, soluções e login, que são apresentadas quando não há nenhum usuário logado no sistema, uma estrutura similar, porém sem a presença do menu lateral à esquerda é utilizada.

 ![Estrutura de interface (2)](https://user-images.githubusercontent.com/89323922/162333677-47a725a1-fb14-410f-aa98-f01dcf57b345.png)


 Listadas abaixo estão as telas individuais do wireframe com suas descrições:
 
 ### Tela - Homepage
 
 <p>A tela de homepage apresenta uma breve explicação sobre o produto, com as informações básicas do que o sistema tem a oferecer.</p>
 <p>Através dessa página, é possivel que os usuários visualizem os contatos da instituição de ensino, como também possibilita o acesso das telas: Soluções e Login.</p>
 
![Homepage](https://user-images.githubusercontent.com/74699119/162334329-5fb9f5c3-4905-401a-957d-6eca9e8b04bb.png)

 ### Tela - Soluções
![Solucoes](https://user-images.githubusercontent.com/74699119/162334174-b2def755-07c6-43ef-9b74-ad1275951866.png)

 ### Tela - Login
 
<p align="justify">  Na tela de login, mostra os elementos padrões do cabeçalho, rodapé e temos o bloco principal de login:
 
> - **Área para login de usuários:** são solicitadas as informações de e-mail e senha para que o login seja efetuado. O usuário possui disponível também a opção de recuperação de senha.</p>

 
![Login](https://user-images.githubusercontent.com/74699119/162334186-8bc32fd8-8a8e-413e-959e-324fbcd9b6e5.png)

<p align="justify"> A elaboração da Tela Login atende ao seguinte requisito funcional:
 
- **Requisito Funcional-01:** A aplicação deve possuir um sistema de autenticação e login financeiro com quatro tipos de usuário: administrador do sistema, responsável pelo aluno, professor e funcionário (tipo genérico que abrange membros da secretaria, setor etc.)</p>

 ### Tela - Tela inicial (pós login do usuário)
 
<b>Tipo de usuário - Administrador</b><br>
 ![InicialAdmin](https://user-images.githubusercontent.com/74699119/162332939-cfbc70e6-2803-46b9-afe0-334ea8afcb76.png)

<b>Tipo de usuário - Professor</b><br>
 ![InicialProfessor](https://user-images.githubusercontent.com/74699119/162332931-935dd871-c045-4242-a640-d5c940eb541b.png)

<b>Tipo de usuário - Responsável do Aluno</b><br>
![InicialProfessor](https://user-images.githubusercontent.com/74699119/162334270-59eb5755-c46a-4fd5-8d24-cbc4a4b826c1.png)

<b>Tipo de usuário - Outros</b><br>
![InicialOutros](https://user-images.githubusercontent.com/74699119/162333489-bfc29083-5e9c-4f47-bbf6-9f65edf7ea93.png)



