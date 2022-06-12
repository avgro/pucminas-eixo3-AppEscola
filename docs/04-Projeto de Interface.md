
# Projeto de Interface

<p align="justify"> Para o desenvolvimento do sistema em questão, foram projetadas telas buscando-se uma identidade visual intuitiva e padronizada entre as diferentes telas do sistema. Com a navegação entre as diferentes funcionalidades ocorrendo através dos itens do cabeçalho e do menu lateral, que se encontram presentes em todas as telas após o login do usuário. Também foi levado em consideração a responsividade do sistema para funcionamento tanto em desktop quanto em dispositivos móveis.</p>

## Diagrama de Fluxo

![Diagrama de Fluxo do Usuario ADS 2022_1_versao2](https://user-images.githubusercontent.com/74699119/161865551-187fd8c1-57fa-46f2-89b4-0887ca632947.png)
<p align="center"><b>Figura 4</b> - Diagrama de fluxo do usuário do projeto</p>
<br>

## Wireframe Interativo

<p align="justify"> Conforme o diagrama de fluxo do projeto apresentado no item anterior, as telas do sistema são apresentados em detalhes nos itens que se seguem. 
O wireframe interativo do projeto encontra-se disponível em: https://lucid.app/documents/embeddedchart/660ffadd-238f-49f7-9ed3-5b89b8208a25?invitationId=inv_d8efbf44-b38b-48bc-9c44-65305935decf#</p> 

A estrutura de interface será comum em todas as telas do sistema após a realização do login. A figura abaixo ilustra a divisão dos conteúdos nestas telas. Observamos que a estrutura está dividida em seções:
* Cabeçalho - Onde são dispostos os elementos fixos da navegação principal do site, cujo será apresentado em todas as telas para todos os usuários do sistema.
* Menu lateral - Apresenta os menus de navegação do sistema e é associado ao conteúdo da tela. A tabela de Menu será diferente e de acordo com o nível de acesso de cada usuário. 
* Conteúdo - Onde é apresentado o conteúdo das telas.
* Rodapé - Nesta tabela é apresentado as informações de contato e copyright.

![Estrutura de interface](https://user-images.githubusercontent.com/89323922/162098121-d093dcc0-0448-4161-bc2f-da9640ca54fb.png)

<p align="justify"> Para as telas de homepage, soluções e login, que são apresentadas quando não há nenhum usuário logado no sistema, uma estrutura similar, porém sem a presença do menu lateral à esquerda é utilizada.</p>

 ![Estrutura de interface (2)](https://user-images.githubusercontent.com/89323922/162333677-47a725a1-fb14-410f-aa98-f01dcf57b345.png)


 Listadas abaixo estão as telas individuais do wireframe com suas descrições:
 
 ### Tela - Homepage
 
 <p align="justify"> A tela de homepage apresenta uma breve explicação sobre o produto, com as informações básicas do que o sistema tem a oferecer. Através dessa página, é possivel que os usuários visualizem os contatos da instituição de ensino, como também possibilita o acesso das telas: Soluções e Login.</p>
 
![Homepage](https://user-images.githubusercontent.com/74699119/162334329-5fb9f5c3-4905-401a-957d-6eca9e8b04bb.png)

 ### Tela - Soluções
 
 <p align="justify"> A tela de Soluções apresenta através de imagens ilustrativas e textos explicativos, as funcionalidades do sistema. Está tela proporciona ao usuário o acesso à tela de Login e homepage, como também as informações de contato.</p>
 
![Solucoes](https://user-images.githubusercontent.com/74699119/168452622-178dd5e4-321f-4558-b5d5-a8a65bca94b2.png)

 ### Tela - Fale conosco
 
 ![faleconosco](https://user-images.githubusercontent.com/74699119/173220760-e80b03cb-38a1-4f69-8fee-b9318375bf1a.png)
 <p align="justify"> A tela de "Fale conosco" apresenta um formulário que o usuário poderá preencher para entrar fazer contato com a plataforma.</p>
 
 ### Tela - Login
 
<p align="justify">  Na tela de login, mostra os elementos padrões do cabeçalho, rodapé e temos o bloco principal de login:
 
> - **Área para login de usuários:** são solicitadas as informações de e-mail e senha para que o login seja efetuado. O usuário possui disponível também a opção de recuperação de senha.</p>

![Login](https://user-images.githubusercontent.com/74699119/168448419-e40fef96-69b0-483f-91eb-ba978def3879.png)

 ### Tela - Tela inicial (pós login do usuário)
 
<p align="justify"> Tela inicial mostrada após realização do login pelo usuário, contém links de navegação para as demais telas/funcionalidades no menu lateral e no cabeçalho:</p>

<p align="justify"> No bloco de barra lateral à esquerda, as opções mostradas serão diferentes para cada tipo de usuário:

> - **Administrador:** Apresentará os menus de acesso para as telas de todos os usuário, agenda, mensagens, cadastrar usuários, alunos, turmas e disciplinas.
> - **Professor:** Apresentará os menus de acesso para as telas de minhas turmas, linha do tempo, agenda e mensagens.
> - **Responsável do aluno:** Apresentará os menus de acesso para as telas de linha do tempo, agenda, mensagens e assinaturas de autorização.
> - **Outros:** Apresentará os menus de agenda e mensagens.</p>

<p align="justify"> Além disso, todos os usuários poderão acessar as notificações e o menu de opções da conta a partir das opções "Notificações" e "Perfil" presentes no cabeçalho</p> 

<b>Tipo de usuário - Responsável do Aluno</b><br>
![painelResp](https://user-images.githubusercontent.com/74699119/173224633-4cdf8223-d491-487f-84ad-b36781f141cf.png)

<b>Tipo de usuário - Professor</b><br>
![painelProf](https://user-images.githubusercontent.com/74699119/173224636-2c4fa161-73d4-4ddd-86e2-1a750e65a938.png)

<b>Tipo de usuário - Administrador</b><br>
![painelAdmin](https://user-images.githubusercontent.com/74699119/173224665-839d496b-4f4d-46cd-bfca-bf348bbe7fb4.png)

<b>Tipo de usuário - Outros</b><br>
![paineloutro](https://user-images.githubusercontent.com/74699119/173224630-06fc5cc7-fd8b-44b3-ba3c-abf5720dfd20.png)
 
### Janela - Mostrar notificações 

<p align="justify"> Na tela de notificações, são mostrados avisos para os usuários, sejam notificações do sistema ou notificações lançadas diretamente pelo administrador. Será mostrado aos usuários um resumo das notificações no botão "Notificação" na parte superior da tela, bem como em um painel centralizado na página. Usuários do tipo "Administrador" poderão criar novas notificações que serão enviadas para os demais usuários clicando na opção "Criar notificação". </p>

<b>Tipo de usuário: Professor, Responsável do Aluno e "Outros"</b>
![notificacoes](https://user-images.githubusercontent.com/74699119/168452539-8329bc84-c45b-43c8-8ff6-99242bb39125.png)

 <b>Tipo de usuário: Administrador</b>
![notificacoesadministrador](https://user-images.githubusercontent.com/74699119/168452548-82457fa5-1078-4773-8517-f9de4c75578b.png)

### Janela - Criar notificação

 <p align="justify"> Tela acessada pelo Administrador ao clicar em "Criar notificação" no menu de notificações. Permite criar uma nova notificação e lança-la no sistema.</p>
 
![telacriarnotificacao](https://user-images.githubusercontent.com/74699119/168452664-7d2eede5-8d7e-4ba9-9cf6-794f807c1c60.png)

### Janela - Opções da conta

 <p align="justify">  Será permitido aos usuários acessarem o submenu de opções da conta, que possui as funcionalidades de "Alterar dados", que direciona o usuário para a tela de "Alterar informações da conta" e "Sair", que finaliza a sessão do usuário realiznado logoff.</p>

![perfil](https://user-images.githubusercontent.com/74699119/168452702-d73fecb4-a437-4e2d-a029-6c10332b010c.png)
 
### Tela - Alterar informações da conta

 <p align="justify">  Será permitido aos usuários modificarem suas informações básicas, como email, telefone, senha e endereço ao preencher o formulário solicitando as novas informações e clicando em "Salvar".</p>
 
![alterardados](https://user-images.githubusercontent.com/74699119/168448436-f64c0ff3-2a6e-4f1c-917d-0c2ff52eb7b9.png)

### Tela - Agenda escolar
 
 <p align="justify">  Será permitido aos usuários visualizar um calendário contendo os eventos da escola de acordo com a data em que estão marcados. Os usuários do tipo "Professor" e Administrador" poderão não só visualizar, como também cadastrar eventos na agenda.</p>
 
<b> Tipo de usuário: Responsável do aluno ou "Outros"</b>
![agenda](https://user-images.githubusercontent.com/74699119/168447225-0cca8ea1-0d70-413f-afdc-cc302d02953f.png)

<b> Tipo de usuário: Administrador ou Professor</b>
![agendaprof](https://user-images.githubusercontent.com/74699119/162601923-507c7a98-f458-466a-b34b-82866fd46886.png)

### Tela - Caixa de mensagens

 <p align="justify">  Será permitido aos usuários receber e enviar mensagens contendo texto, imagens e video. Esta tela mostra a caixa de entrada de mensagens.</p>
  
![mensagens](https://user-images.githubusercontent.com/74699119/168452690-b59c8604-7961-48ca-98bb-fdd18f830eee.png)

### Tela - Criar nova mensagem

 <p align="justify">  Será permitido aos usuários receber e enviar mensagens contendo texto, imagens e video. Esta tela mostra a tela de criação de nova mensagem, onde o usuário pode enviar uma mensagem para uma lista de destinatários, iniciando assim uma nova conversa.</p>

![criarmensagens](https://user-images.githubusercontent.com/74699119/168448423-a37bd641-cc16-492d-a743-3e0103932680.png)

### Tela - Visualizar mensagens da conversa

 <p align="justify">  Será permitido aos usuários receber e enviar mensagens contendo texto, imagens e video. Esta tela é acessada ao clicar na opção "Visualizar" em uma conversa presente na caixa de mensagens, nesta tela, o usuário pode visualizar todas as mensagens da conversa (isto é, a mensagem original e as respostas à mensagem original e a outras respostas da conversa). O usuário pode também criar uma resposta a uma das mensagens clicando na opção "Responder" ou "Responder a todos" no corpo da mensagem desejada.</p>
  
![visualizarconversa](https://user-images.githubusercontent.com/74699119/168448244-bc25663d-1e0f-4a72-9e05-6e462e3d1897.png)

### Janela - Responder mensagem da conversa

 <p align="justify">  Será permitido aos usuários receber e enviar mensagens contendo texto, imagens e video. Esta tela é acessada ao clicar na opção "Responder" ou "Responder a todos" em uma mensagem presente na conversa. Nesta tela, o usuário pode compor sua resposta de forma similar ao que é realizado na tela de "Criar nova mensagem" e envia-la clicando em "Responder" dentro da janela de responder mensagem da conversa.</p>

![respondermensagem](https://user-images.githubusercontent.com/74699119/168452692-0b506039-4110-4cc5-9109-84ece879dc7a.png)

### Tela - Linha do tempo
 <b>Tipo de usuário - Responsável do Aluno</b><br>
  
  > - **Responsável do aluno:** Será permitido ao usuário visualizar imagens adicionadas de seus filhos. Este usuário poderá ver todas as fotos adicionadas e interagir através de comentários.
  
![linhadotemporesp](https://user-images.githubusercontent.com/74699119/168451933-ab9e096e-ed23-4d5d-b8d7-9859f5c04808.png)
 
 <b>Tipo de usuário - Professor</b><br>
  
  > - **Professor:** Este usuário poderá criar postagens adicionando texto e imagens de um determinado aluno, bem como interagir com a publicação por meio de comentários.
  
![linhadotempoprofessor](https://user-images.githubusercontent.com/74699119/168460330-b12c2a91-c2d6-4456-814a-e83005af452b.png)
 
### Tela - Assinar autorização

<p align="justify">  Será permitido aos usuários do tipo "Responsável do aluno" visualizarem notificações de eventos que necessitam de sua autorização, assinalando se autorizam ou não que seu filho participe. Ao usuário será apresentada uma mensagem informando o conteúdo necessário de autorização, que pode ser um evento, excursão etc.</p>
 
![assinarautorizacao](https://user-images.githubusercontent.com/74699119/168451938-43cf4e6d-2bb8-49b1-a1e6-f8f58f775d58.png)
 
### Tela - Visualizar turmas do professor
 
<p align="justify">  Será permitido aos usuários do tipo "Professor" visualizar todas as turmas que estão sob sua responsabilidade e os alunos atrelados a elas. Ele poderá realizar pesquisas para filtragem das turmas por nome do aluno ou disciplina lecionada.</p>
 
![minhasturmas](https://user-images.githubusercontent.com/74699119/168452574-42efd1c0-a600-462a-bfb9-a76a11b2b398.png)
 
### Tela - Visualizar todos os usuários do sistema

<p align="justify">  Será permitido aos usuários do tipo Administrador visualizar todos os usuários cadastrados no sistema, vendo suas informações básicas de nome completo, nome de usuário e tipo de usuário. Poderão também editar ou deletar contas de usuários.</p>
 
![listausuarios](https://user-images.githubusercontent.com/74699119/168459995-aae046ca-1564-4099-b53c-2ad2018aea68.png)

### Tela - Cadastrar usuário

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar um novo usuário ao sistema, adicionando informações previamente apresentadas, bem como selecionar o tipo de usuário atrelado aquele novo usuário.</p>
 
![cadastrousuarios](https://user-images.githubusercontent.com/74699119/168460002-493807f9-69b9-44d5-8dcd-d45a755758b8.png)

### Tela - Visualizar disciplinas cadastradas

<p align="justify">  Será permitido aos usuários do tipo Administrador visualizar a lista de disciplinas cadastradas no sistema, bem como apagar disciplinas cadastradas ou editar suas informações, incluindo horário das aulas e turma da qual faz parte.</p>

![listadisciplinas](https://user-images.githubusercontent.com/74699119/168460037-80f0a27c-032b-4534-9585-7c8502b64704.png)

### Tela - Cadastrar disciplina

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar novas disciplinas no sistema, definindo seus horários na semana e podendo escolher a turma da qual faz parte. O usuário deverá clicar nas opções desejadas e seguir o fluxo de preenchimento apresentado pelo sistema.</p>
 
![cadastrodisciplinas](https://user-images.githubusercontent.com/74699119/168460080-5be5da2b-2f81-417a-942f-e10690faaf0f.png)

### Tela - Visualizar turmas cadastradas

<p align="justify">  Será permitido aos usuários do tipo Administrador visualizar a lista de turmas cadastradas no sistema, bem como apagar ou editar informações das turmas cadastradas e visualizar/editar o quadro de horários contendo as disciplinas associadas a turma.</p>

![listaturmas](https://user-images.githubusercontent.com/74699119/168460342-a666b616-4e4b-41d4-b861-5ed29595a560.png)

### Tela - Cadastrar turma

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar uma nova turma, em que lhe será apresentada uma opção de inserir o nome e código de uma nova turma e salvar no sistema. Após o cadastro da turma, o Administrador será direcionado para o quadro de disciplinas da turma, aonde poderá selecionar as disciplinas que compõe o quadro de horários semanal da turma.</p>
 
![cadastrarturma](https://user-images.githubusercontent.com/74699119/162493089-dc857d3e-56e8-42b4-a22e-e4d160b2c45e.png)

### Tela - Visualizar alunos cadastrados
<p align="justify">  Será permitido aos usuários do tipo Administrador visualizar a lista de alunos cadastrados no sistema, bem como remover alunos cadastrados ou editar suas informações para situações nas quais seja necessário trocar sua turma ou adicionar mais responsáveis.</p>

![listaalunos](https://user-images.githubusercontent.com/74699119/168460362-ddc54bab-3ae8-4a3a-8e02-cdc071dcc407.png)

### Tela - Cadastrar aluno

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar um novo aluno ao sistema, atrelando este ele a seus responsáveis (previamente cadastrados como usuários do tipo "Responsável de aluno") e também a uma turma.</p>

![cadastroalunos](https://user-images.githubusercontent.com/74699119/168460378-18ca681d-54d8-44c4-bd86-d7f16dddb3ec.png)

### Tela - Ver quadro de horários/Associar disciplinas à turma
 
<p align="justify">  Será permitido aos usuários do tipo Administrador associar disciplinas cadastrada à uma turma cadastrada, vinculando essas informações. Nesta tela também é possível visualizar o quadro de horários correspondente às disciplinas atualmente associadas àquela turma.</p>

![quadrodisciplinasturma](https://user-images.githubusercontent.com/74699119/168460199-f8ce9e56-5d1d-4c6d-9b21-0099c9240ec7.png)
