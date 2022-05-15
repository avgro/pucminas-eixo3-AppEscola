
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
 
![Solucoes](https://user-images.githubusercontent.com/74699119/168446518-3e93ab29-8785-48ee-9c85-e093cb949d16.png)

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

![InicialResp](https://user-images.githubusercontent.com/74699119/168451920-2409456b-f2c5-4d78-9fe3-091d320f758c.png)

<b>Tipo de usuário - Professor</b><br>

![InicialProfessor](https://user-images.githubusercontent.com/74699119/162332931-935dd871-c045-4242-a640-d5c940eb541b.png)
 
<b>Tipo de usuário - Administrador</b><br>

 ![InicialAdmin](https://user-images.githubusercontent.com/74699119/162332939-cfbc70e6-2803-46b9-afe0-334ea8afcb76.png)

<b>Tipo de usuário - Outros</b><br>

![InicialOutros](https://user-images.githubusercontent.com/74699119/168446693-b6b322af-55f3-40ce-95bf-e7e9dfa8da4e.png)
 
### Tela - Mostrar notificações 

<p align="justify"> Na tela de notificações, são mostrados avisos para os usuários, sejam notificações do sistema ou notificações lançadas diretamente pelo administrador. Será mostrado aos usuários um resumo das notificações no botão "Notificação" na parte superior da tela, bem como em um painel centralizado na página. Usuários do tipo "Administrador" poderão criar novas notificações que serão enviadas para os demais usuários clicando na opção "Criar notificação". </p>

<b>Tipo de usuário: Professor, Responsável do Aluno e "Outros"</b>
![notificacoes](https://user-images.githubusercontent.com/74699119/162345763-f1844ad3-58aa-4192-afb1-ca4bfca99739.png)
 
 <b>Tipo de usuário: Administrador</b>
![notificacoesadministrador](https://user-images.githubusercontent.com/74699119/162607878-76ee7c49-42f7-4828-8e87-ce566b7dedf5.png)

### Tela - Criar notificação

 <p align="justify"> Tela acessada pelo Administrador ao clicar em "Criar notificação" no menu de notificações. Permite criar uma nova notificação e lança-la no sistema.</p>
 
![telacriarnotificacao](https://user-images.githubusercontent.com/74699119/162607969-b59b5d7c-eb61-4129-8e98-90050d820d51.png)

### Tela - Opções da conta

 <p align="justify">  Será permitido aos usuários acessarem o submenu de opções da conta, que possui as funcionalidades de "Alterar dados", que direciona o usuário para a tela de "Alterar informações da conta" e "Sair", que finaliza a sessão do usuário realiznado logoff.</p>

![perfil](https://user-images.githubusercontent.com/74699119/162345487-94dad779-b01c-487f-b845-f3022f3ce7ce.png)
 
### Tela - Alterar informações da conta

 <p align="justify">  Será permitido aos usuários modificarem suas informações básicas, como email, telefone, senha e endereço ao preencher o formulário solicitando as novas informações e clicando em "Salvar".</p>
 
![alterardados](https://user-images.githubusercontent.com/74699119/168448436-f64c0ff3-2a6e-4f1c-917d-0c2ff52eb7b9.png)

### Tela - Agenda escolar
 
 <p align="justify">  Será permitido aos usuários visualizar um calendário contendo os eventos da escola de acordo com a data em que estão marcados. Os usuários do tipo "Professor" e Administrador" poderão não só visualizar, como também cadastrar eventos na agenda.</p>
 
<b> Tipo de usuário: Responsável do aluno ou "Outro"</b>
![agenda](https://user-images.githubusercontent.com/74699119/168447225-0cca8ea1-0d70-413f-afdc-cc302d02953f.png)

<b> Tipo de usuário: Administrador ou Professor</b>
![agendaprof](https://user-images.githubusercontent.com/74699119/162601923-507c7a98-f458-466a-b34b-82866fd46886.png)

### Tela - Caixa de mensagens

 <p align="justify">  Será permitido aos usuários receber e enviar mensagens contendo texto, imagens e video. Esta tela mostra a caixa de entrada de mensagens.</p>
  
![mensagens](https://user-images.githubusercontent.com/74699119/168448174-a6d76a8f-4fbc-4c96-b771-6be6791b0b04.png)

### Tela - Criar nova mensagem

 <p align="justify">  Será permitido aos usuários receber e enviar mensagens contendo texto, imagens e video. Esta tela mostra a tela de criação de nova mensagem, onde o usuário pode enviar uma mensagem para uma lista de destinatários, iniciando assim uma nova conversa.</p>

![criarmensagens](https://user-images.githubusercontent.com/74699119/168448423-a37bd641-cc16-492d-a743-3e0103932680.png)

### Tela - Visualizar mensagens da conversa

 <p align="justify">  Será permitido aos usuários receber e enviar mensagens contendo texto, imagens e video. Esta tela é acessada ao clicar na opção "Visualizar" em uma conversa presente na caixa de mensagens, nesta tela, o usuário pode visualizar todas as mensagens da conversa (isto é, a mensagem original e as respostas à mensagem original e a outras respostas da conversa). O usuário pode também criar uma resposta a uma das mensagens clicando na opção "Responder" ou "Responder a todos" no corpo da mensagem desejada.</p>
  
![visualizarconversa](https://user-images.githubusercontent.com/74699119/168448244-bc25663d-1e0f-4a72-9e05-6e462e3d1897.png)

### Janela - Responder mensagem da conversa

 <p align="justify">  Será permitido aos usuários receber e enviar mensagens contendo texto, imagens e video. Esta tela é acessada ao clicar na opção "Responder" ou "Responder a todos" em uma mensagem presente na conversa. Nesta tela, o usuário pode compor sua resposta de forma similar ao que é realizado na tela de "Criar nova mensagem" e envia-la clicando em "Responder" dentro da janela de responder mensagem da conversa.</p>

![respondermensagem](https://user-images.githubusercontent.com/74699119/168448308-e0bf71cb-38b0-4af5-af8a-5a814fd21101.png)

### Tela - Linha do tempo
 <b>Tipo de usuário - Responsável do Aluno</b><br>
  
  > - **Responsável do aluno:** Será permitido ao usuário visualizar imagens adicionadas de seus filhos. Este usuário poderá ver todas as fotos adicionadas e interagir através de comentários.
  
![linhadotemporesp](https://user-images.githubusercontent.com/74699119/168451933-ab9e096e-ed23-4d5d-b8d7-9859f5c04808.png)
 
 <b>Tipo de usuário - Professor</b><br>
  
  > - **Professor:** Este usuário poderá criar postagens adicionando texto e imagens de um determinado aluno, bem como interagir com a publicação por meio de comentários.
  
![linhadotempoprofessor](https://user-images.githubusercontent.com/74699119/162608349-7fa1c508-1324-4314-947f-7521ec0db4ef.png)

 
### Tela - Assinar autorização

<p align="justify">  Será permitido aos usuários do tipo "Responsável do aluno" visualizarem notificações de eventos que necessitam de sua autorização, assinalando se autorizam ou não que seu filho participe. Ao usuário será apresentada uma mensagem informando o conteúdo necessário de autorização, que pode ser um evento, excursão etc.</p>
 
![assinarautorizacao](https://user-images.githubusercontent.com/74699119/168451938-43cf4e6d-2bb8-49b1-a1e6-f8f58f775d58.png)
 
### Tela - Visualizar turmas do professor
 
<p align="justify">  Será permitido aos usuários do tipo "Professor" visualizar todas as turmas que estão sob sua responsabilidade e os alunos atrelados a elas. Ele poderá realizar pesquisas para filtragem das turmas por nome do aluno ou disciplina lecionada.</p>
 
![minhasturmas](https://user-images.githubusercontent.com/74699119/162491880-52bf44c1-04e5-441c-8cf9-d477e3da42b0.png)
 
### Tela - Visualizar todos os usuários do sistema

<p align="justify">  Será permitido aos usuários do tipo Administrador visualizar todos os usuários cadastrados no sistema, vendo suas informações básicas de ID, nome, e-mail e tipo de usuário. Poderão também deletar contas de usuários a partir desta tela.</p>
 
![usuariosadmin](https://user-images.githubusercontent.com/74699119/162587514-d7a4bd72-41fe-4163-8dd3-b7303ee4146c.png)

### Tela - Cadastrar usuário

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar um novo usuário ao sistema, adicionando informações previamente apresentadas, bem como selecionar o tipo de usuário atrelado aquele novo usuário.</p>
 
![cadastrarusuario](https://user-images.githubusercontent.com/74699119/162492785-8c1b148e-a2d1-4b9d-aafd-734d9cfacbde.png)

### Tela - Visualizar alunos cadastrados
<p align="justify">  Será permitido aos usuários do tipo Administrador visualizar a lista de alunos cadastrados no sistema, bem como remover alunos cadastrados ou editar suas informações para situações nas quais seja necessário trocar sua turma ou adicionar mais responsáveis.</p>

![listaalunos](https://user-images.githubusercontent.com/74699119/162586613-1a1db82f-c39c-4a58-b735-2a37356a886c.png)

### Tela - Cadastrar aluno

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar um novo aluno ao sistema, adicionando informações previamente apresentadas, bem como atrelar ele ao seu usuário do tipo Responsável, previamente cadastrado.</p>
 
 ![cadastraraluno](https://user-images.githubusercontent.com/74699119/162492772-0fbc75b3-7c3e-4b36-9b3d-1a9e5e1d246f.png)
 
### Tela - Cadastrar turmas e disciplinas

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar uma nova turma e disciplina ao sistema, bem como gerenciar os detalhes de tais dados, como associação de alunos. O usuário deverá clicar nas opções desejadas e seguir o fluxo de preenchimento apresentado pelo sistema.</p>
 
![cadastrarturmadisciplina](https://user-images.githubusercontent.com/74699119/162493055-f54e6516-c464-4d10-b0d8-00e15df2fe13.png)
 
### Tela - Cadastrar turma

<p align="justify">  Será permitido aos usuários do tipo Administrador cadastrar uma nova turma, em que lhe será apresentada uma opção de inserir o nome de uma nova turma e salvar no sistema.</p>
 
![cadastrarturma](https://user-images.githubusercontent.com/74699119/162493089-dc857d3e-56e8-42b4-a22e-e4d160b2c45e.png)

### Tela - Associar aluno à turma

<p align="justify">  Será permitido aos usuários do tipo Administrador associar uma turma cadastrada a alunos cadastrados, vinculando essas informações.</p>
 
![associaralunoturma](https://user-images.githubusercontent.com/74699119/162499619-a4e93ba0-ed13-487f-986f-efe454ee843c.png)

### Tela - Associar disciplina à turma
 
<p align="justify">  Será permitido aos usuários do tipo Administrador associar uma disciplina cadastrada a uma turma cadastrada, vinculando essas informações.</p>
 
![associaralunodisciplina](https://user-images.githubusercontent.com/74699119/162499613-0b0bd1a4-70a8-4916-9183-5ffe1ff8682c.png)

### Tela - Gerenciar alunos e disciplinas associados à turma
 
<p align="justify">  Será permitido aos usuários do tipo Administrador visualizar todas as associações de alunos e disciplinas, podendo editar as informações cadastradas.</p>
 
![gerenciarassociacao](https://user-images.githubusercontent.com/74699119/162499638-d8a68a01-e834-499d-8cc2-70bced69f119.png)

### Tela - Apagar turma

<p align="justify"> Está tela possui uma funcionalidade que tem como objetivo apagar uma turma cadastrada no sistema. O usuário administrador irá selecionar uma turma para poder exclui-la.</p>

![apagarturma](https://user-images.githubusercontent.com/74699119/162499604-f287a930-760d-4e38-a973-2fb2a408d537.png)

### Tela - Cadastrar disciplina

<p align="justify"> Nesta tela, o usuário administrador poderá cadastrar a disciplina e vincular os professores e as turmas da mesma.<p>

![cadastrardisciplina](https://user-images.githubusercontent.com/74699119/162499995-782aea1b-eee0-45ba-b755-d375d78728fe.png)

### Tela - Editar disciplina

<p align="justify"> A funcionalidade presente nesta tela possui o objetivo de possibilitar a edição de uma disciplina já cadastrada no sistema. O usuário administrador irá selecionar uma disciplina existente no sistema e, assim, poder alterar o nome da disciplina, o vínculo da turma e professor. Podendo salvar ou cancelar o processo de edição.</p>

![editardisciplina](https://user-images.githubusercontent.com/74699119/162500005-62896a90-f8fe-40b7-85ae-150b733a3be2.png)

### Tela - Apagar disciplina

<p align="justify"> A funcionalidade presente nesta tela tem como objetivo apagar uma disciplina cadastrada no sistema. O usuário administrador irá selecionar uma disciplina para poder exclui-la.</p>

![apagardisciplina](https://user-images.githubusercontent.com/74699119/162500017-ce9d88a1-d107-47dd-97a2-301506aeb982.png)
