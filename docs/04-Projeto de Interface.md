
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
 
 <p>A tela de Soluções apresenta através de imagens ilustrativas e textos explicativos, as funcionalidades do sistema.</p>
 <p>Está tela proporciona ao usuário o acesso à tela de Login e homepage, como também as informações de contato.</p>
 
![Solucoes](https://user-images.githubusercontent.com/74699119/162334174-b2def755-07c6-43ef-9b74-ad1275951866.png)

 ### Tela - Login
 
<p align="justify">  Na tela de login, mostra os elementos padrões do cabeçalho, rodapé e temos o bloco principal de login:
 
> - **Área para login de usuários:** são solicitadas as informações de e-mail e senha para que o login seja efetuado. O usuário possui disponível também a opção de recuperação de senha.</p>

![Login](https://user-images.githubusercontent.com/74699119/162334186-8bc32fd8-8a8e-413e-959e-324fbcd9b6e5.png)

 ### Tela - Tela inicial (pós login do usuário)
 
Nesta tela, todos os usuários poderão acessar o seu perfil para a alteração dos dados cadastrais, bem como visualizar a caixa de mensagens através do ícone do lado direito no cabeçalho. 
Os blocos de conteúdo serão diferentes de acordo com o tipo de usuário:
> - **Administrador:** - Apresentará em destaque a agenda e as notificações.
> - **Professor/Resp. do aluno/Outros:** Apresentará em destaque as turmas, as notificações e a agenda.

<p align="justify"> No bloco de barra lateral à esquerda, também será diferente para cada tipo de usuário:

> - **Administrador:** Apresentará os menus de acesso para as telas de todos os usuário, agenda, mensagens, cadastrar usuários, alunos, turmas e disciplinas.
> - **Professor:** Apresentará os menus de acesso para as telas de minhas turmas, linha do tempo, agenda e mensagens.
> - **Responsável do aluno:** Apresentará os menus de acesso para as telas de linha do tempo, agenda, mensagens e assinaturas de autorização.
> - **Outros:** Apresentará os menus de agenda e mensagens.</p>

<p align="justify"> A elaboração das Telas iniciais (pós login do usuário) atende ao seguinte requisito funcional:

> - **Requisito Funcional-01:** A aplicação deve possuir um sistema de autenticação e login com quatro tipos de usuário: administrador do sistema, responsáveis pelo aluno, professor e funcionário (tipo genérico que abrange membros da secretaria, setor financeiro, etc)</p>

<b>Tipo de usuário - Responsável do Aluno</b><br>

![InicialProfessor](https://user-images.githubusercontent.com/74699119/162334270-59eb5755-c46a-4fd5-8d24-cbc4a4b826c1.png)

<b>Tipo de usuário - Professor</b><br>

![InicialProfessor](https://user-images.githubusercontent.com/74699119/162332931-935dd871-c045-4242-a640-d5c940eb541b.png)
 
<b>Tipo de usuário - Administrador</b><br>

 ![InicialAdmin](https://user-images.githubusercontent.com/74699119/162332939-cfbc70e6-2803-46b9-afe0-334ea8afcb76.png)

<b>Tipo de usuário - Outros</b><br>

![InicialOutros](https://user-images.githubusercontent.com/74699119/162333489-bfc29083-5e9c-4f47-bbf6-9f65edf7ea93.png)
 
### Tela - Mostrar notificações 

<p align="justify">  Na tela de notificações, mostra os elementos que os usuários estão recebendo de atualização da ferramenta, sejam novas mensagens ou eventos.
 
 <p align="justify">  Será mostrado aos usuários um resumo das notificações no botão Notificação na parte superior da tela, bem como em um painel centralizado na página.
 
![notificacoes](https://user-images.githubusercontent.com/74699119/162345763-f1844ad3-58aa-4192-afb1-ca4bfca99739.png)
  
### Tela - Opções da conta

 <p align="justify">  Será permitido aos usuários acessarem o submenu de Alterar dados, sendo direcionado para a página específica e permitindo ao usuário a alteração de seus dados. O usuário também terá a funcionalidade de logout.</p>
  
![perfil](https://user-images.githubusercontent.com/74699119/162345487-94dad779-b01c-487f-b845-f3022f3ce7ce.png)
 
### Tela - Alterar informações da conta

 <p align="justify">  Será permitido aos usuários modificarem suas informações básicas, como senha, endereço e outros dados.
  
![alterardados](https://user-images.githubusercontent.com/74699119/162345769-fe3d5b97-29cf-481a-879c-7396f0df221a.png)
 
### Tela - Agenda escolar
 
 <p align="justify">  Será permitido aos usuários, visualizarem fotos de momentos dos alunos durante algum evento ou ao longo da rotina escolar.
  
 ![agenda](https://user-images.githubusercontent.com/74699119/162344162-f914e94e-aa09-43d2-8717-b30a745d7454.png)
 
### Tela - Caixa de mensagens

 <p align="justify">  Será permitido aos usuários visualizarem os eventos marcados na agenda escolar, sendo permitido incluir eventos e visualizar detalhes.
  
 ![mensagens](https://user-images.githubusercontent.com/74699119/162344187-13992039-2465-4d99-b2b5-81a3ab36b7b6.png)
 

### Tela - Linha do tempo
 <b>Tipo de usuário - Responsável do Aluno</b><br>
  
  > - **Responsável do aluno:** Será permitido ao usuário visualizar imagens adicionadas de seus filhos. Este usuáriio poderá ver todas as fotos adicionadas e interagir através de comentários.
  
![linhadotemporesp](https://user-images.githubusercontent.com/74699119/162346282-026937c4-fddc-4018-8c32-d38322e4333d.png)
 
 <b>Tipo de usuário - Professor</b><br>
  
  > - **Professor:** Este usuário poderá adicionar imagens de um determinado aluno, bem como interagir com a publicação por meio de comentários.
  
![linhadotempoprofessor](https://user-images.githubusercontent.com/74699119/162346136-6c188ec0-d05c-4f8f-87d2-e54a6b6340ed.png)
 
### Tela - Assinar autorização

<p align="justify">  Será permitido aos usuários do tipo Responsável visualizarem notificações de eventos que necessitam de sua autorização, assinalando se autorizam ou não que seu filho participe. Ao usuário será apresentada uma mensagem informando o conteúdo necessário de autorização, que pode ser um evento, excursão etc.
 
![assinarautorizacao](https://user-images.githubusercontent.com/74699119/162346531-1ce86e36-7f85-4efe-b65e-e858b299e290.png)
 
### Tela - Visualizar turmas do professor
 
<p align="justify">  Será permitido aos usuários do tipo Professor visualizarem as turmas que estão sob sua responsabilidade e os alunos atrelados. Ele poderá realizar pesquisas para filtragem das turmas, bem como verá a disciplina da matéria que leciona para cada uma.
 
![minhasturmas](https://user-images.githubusercontent.com/74699119/162491880-52bf44c1-04e5-441c-8cf9-d477e3da42b0.png)
 
### Tela - Visualizar todos os usuários do sistema

<p align="justify">  Será permitido aos usuários do tipo Administrador visualizarem todos os usuários cadastrados ao sistema, vendo suas informações básicas de ID, nome, e-mail e tipo de usuário. Será permitido a este usuário manejar os demais, como deletando ou pesquisando.
 
![visualizarusuarios](https://user-images.githubusercontent.com/74699119/162491957-8cdcb7aa-5f20-4c35-acd8-f3a7d04e76b1.png)
 
### Tela - Cadastrar usuário

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar um novo usuário ao sistema, adicionando informações previamente apresentadas, bem como selecionando o tipo de usuário atrelado aquele novo usuário.
 
![cadastrarusuario](https://user-images.githubusercontent.com/74699119/162492785-8c1b148e-a2d1-4b9d-aafd-734d9cfacbde.png)
 
### Tela - Cadastrar aluno

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar um novo aluno ao sistema, adicionando informações previamente apresentadas, bem como atrelando ele ao seu usuário do tipo Responsável, previamente cadastrado.
 
 ![cadastraraluno](https://user-images.githubusercontent.com/74699119/162492772-0fbc75b3-7c3e-4b36-9b3d-1a9e5e1d246f.png)
 
### Tela - Cadastrar turmas e disciplinas

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar uma nova turma e disciplina ao sistema, bem como gerenciar os detalhes de tais dados, como associação de alunos. O usuário deverá clicar nas opções desejadas e seguir o fluxo de preenchimento apresentado pelo sistema.
 
![cadastrarturmadisciplina](https://user-images.githubusercontent.com/74699119/162493055-f54e6516-c464-4d10-b0d8-00e15df2fe13.png)
 
### Tela - Cadastrar turma

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar uma nova turma, em que lhe será apresentada uma opção de inserir o código de uma nova turma e salvar no sistema.
 
![cadastrarturma](https://user-images.githubusercontent.com/74699119/162493089-dc857d3e-56e8-42b4-a22e-e4d160b2c45e.png)

### Tela - Associar aluno à turma

<p align="justify">  Será permitido aos usuários do tipo Administrador associar uma turma cadastrada a alunos cadastrados, vinculando essas informações.
 
![associaralunoturma](https://user-images.githubusercontent.com/74699119/162499619-a4e93ba0-ed13-487f-986f-efe454ee843c.png)

### Tela - Associar disciplina à turma
 
<p align="justify">  Será permitido aos usuários do tipo Administrador associar uma disciplina cadastrada a uma turma cadastrada, vinculando essas informações.
 
![associaralunodisciplina](https://user-images.githubusercontent.com/74699119/162499613-0b0bd1a4-70a8-4916-9183-5ffe1ff8682c.png)

### Tela - Gerenciar alunos e disciplinas associados à turma
 
<p align="justify">  Será permitido aos usuários do tipo Administrador visualizar todas as associações de alunos e disciplinas, podendo editar as informações cadastradas.
 
![gerenciarassociacao](https://user-images.githubusercontent.com/74699119/162499638-d8a68a01-e834-499d-8cc2-70bced69f119.png)

### Tela - Apagar turma

<p> Está tela possui uma funcionalidade que tem como objetivo apagar uma turma cadastrada no sistema.</p>
<p> O usuário administrador irá selecionar uma turma para poder exclui-la.</p>

![apagarturma](https://user-images.githubusercontent.com/74699119/162499604-f287a930-760d-4e38-a973-2fb2a408d537.png)

### Tela - Cadastrar disciplina

<p> Nesta tela, o usuário administrador irá cadastrar a disciplina vinculando os professores e as turmas envolvidas.<p>

![cadastrardisciplina](https://user-images.githubusercontent.com/74699119/162499995-782aea1b-eee0-45ba-b755-d375d78728fe.png)

### Tela - Editar disciplina

<p> Está tela irá possuir uma funcionalidade, cujo o objetivo será a edição de uma disciplina já cadastrada no sistema.</p>
<p> O usuário administrador irá selecionar uma disciplina existente no sistema e, assim, poder alterar o nome da disciplina, o vínculo da turma e professor.
    Podendo salvar ou cancelar o processo de edição.</p>

![editardisciplina](https://user-images.githubusercontent.com/74699119/162500005-62896a90-f8fe-40b7-85ae-150b733a3be2.png)

### Tela - Apagar disciplina

<p> Está funcionalidade tem como objetivo apagar uma disciplina cadastrada no sistema.</p>
<p> O usuário administrador irá selecionar uma disciplina para poder exclui-la.</p>

![apagardisciplina](https://user-images.githubusercontent.com/74699119/162500017-ce9d88a1-d107-47dd-97a2-301506aeb982.png)
