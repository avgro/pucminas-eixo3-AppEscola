# Programação de Funcionalidades

Nesta seção são demonstradas as telas correspondentes a cada funcionalidade implementada do sistema. As instruções de acesso são apresentadas em seguida. Para acessar o projeto publicado online na plataforma smarterasp.net, o usuário deve clicar no seguinte link:

http://smensga-001-site1.itempurl.com/

Que o redirecionará para a homepage do projeto (ou para a área do usuário caso já tenha realizado login na plataforma).

Caso deseje clonar este repositório do Github e rodar o projeto de forma local no próprio computador, o usuário deve seguir os seguintes passos:

1. Fazer o download do arquivo do projeto (ZIP) ou clone do projeto no GitHub;
2. Abrir o arquivo "App-comunicacao-escolar.sln" no Visual Studio;
3. Executar o comando "update-database" no console do Package Manager para criar as tabelas do banco de dados localmente através dos arquivos "migrations" do Entity Framework Core;
5. Rodar o projeto no Visual Studio, que deverá abrir uma janela do browser no endereço localhost:7060, exibindo a homepage do projeto (ou a área do usuário caso o usuário já esteja logado);

O passo a passo de como acessar cada uma das funcionalidades do projeto a partir deste ponto é descrito nas seções abaixo.

## Login e autenticação (RF-01)
A funcionalidade de login é acessada ao clicar no botão "Login" do cabeçalho enquanto não se está logado em nenhuma conta. As contas de usuário são criadas exclusivamente pelo administrador do sistema, podendo ser do perfil "Responsável do aluno", "Professor" e "Outros". Há ainda a conta com perfil "Administrador", que é exclusiva para o administrador do sistema. Ao entrar na tela de login, o usuário informa seu nome de usuário e senha, e, caso o sistema reconheça as informações como corretas, inicia-se a sessão daquele usuário. No caso de informações incorretas, o sistema retorna uma mensagem de erro informando que o usuário ou senha informados são inválidos. Após a realização bem sucedida do login, o usuário é direcionado para a tela inicial do usuário, aonde terá acesso a um menu lateral cujas opções variam de acordo com o perfil de usuário (opções de gerenciar informações do sistema aparecem apenas para o administrador, etc). Uma vez logado no sistema, o usuário pode realizar logout abrindo o menu do usuário presente no canto superior direito do cabeçalho e selecionado a opção "Sair".

### Tela de login
![login](https://user-images.githubusercontent.com/74699119/172967193-47c0937d-9d0c-4a33-97d0-f0c5ac84885b.jpg)
### Opção de logout/sair do menu do usuário
![menusuario](https://user-images.githubusercontent.com/74699119/172967203-06ec9575-c021-46ed-9284-e7ec6ffef52c.jpg)

### Requisitos atendidos
- RF-01

### Artefatos da funcionalidade
#### Models
- Usuario.cs
- ErrorViewModel.cs

#### Controllers
- UsuariosController.cs
#### Views
- Usuarios/Login.cshtml
- Usuarios/AccessDenied.cshtml
#### Outros
- site.css
- site.js
- updateMsg-check.js

### Instruções de acesso

1. Visualize a tela inicial/homepage do projeto;
2. Clique no botão "Login" presente no canto direito do cabeçalho;
3. Informe suas credenciais de login (caso nenhum usuário tenha sido cadastrado, utilizar nome de usuário "admin" e senha "admin" para acessar a conta do administrador);
4. Caso as credenciais tenham sido validadas, a sessão será iniciada e o usuário redirecionado para a página inicial do usuário.

## Cadastro/Edição de usuários e envio de email com credenciais de acesso pelo administrador (RF-02 e RF-03)
A funcionalidade de cadastrar novos usuários no sistema é exclusiva para a conta do administrador, uma vez que o cadastro na plataforma deve ser exclusiva para responsaveis de alunos e funcionários da escola. Após acessar sua conta, o administrador pode visualizar e editar as informações de todos os usuários cadastrados, bem como escolher cadastrar um novo usuário do tipo "Responsável de aluno", "Professor" ou "Outros" (tipo de conta genérica utilizada por funcionários que não sejam professores). Após a criação da conta, o administrador poderá enviar um email para o e-mail do novo usuário contendo suas credenciais de acesso para a plataforma. Na versão local do projeto (executada via localhost), esse e-mail é enviado para uma pasta no diretório C: com o nome "AppEscolaMail". Na versão que hospedada online, o email originalmente seria de fato enviado para a conta de email informada durante o cadastro através da API FluentEmail, esta opção precisou ser desabilitada devido a uma mudança na política de acesso por "aplicativos menos seguros" do Google, que impossibilitou a utilização da API pela aplicação para esta finalidade. O administrador pode ainda apagar um usuário do sistema clicando na opção "Apagar" na tela de lista de usuários e confirmando a ação na tela seguinte, excetuando-se a própria conta de administrador, que não pode ser apagada do sistema. Essa funcionalidade também atende parcialmente o RF-03, uma vez que o cadastro de responsáveis e professores ocorre nela junto a criação de suas respectivas contas de usuário. 

### Visualizar usuários cadastrados
![cadastrarusuarioA](https://user-images.githubusercontent.com/74699119/172967241-779b71d6-25a4-4ec1-b009-64d69a38f6ec.jpg)
### Formulário de cadastro de novo usuário
![cadastrarusuarioB](https://user-images.githubusercontent.com/74699119/172967246-1252679a-d4ba-4130-9b20-8b9ee6111945.jpg)
#### (Informações adicionais solicitadas para cadastro de professor)
![cadastrarusuarioC](https://user-images.githubusercontent.com/74699119/172967249-75b3cae5-cc76-42a9-896e-bdb39e561010.jpg)
### Tela de envio de email de confirmação
![cadastrarusuarioD](https://user-images.githubusercontent.com/74699119/172967258-c6703e4c-bd06-44a2-be87-562a2fa068bb.jpg)
### Tela de visualizar usuários com novo usuário cadastrado
![cadastrarusuarioE](https://user-images.githubusercontent.com/74699119/172967266-ae2a2687-92d8-4778-92d3-fa08ad0ac6be.jpg)

### Requisitos atendidos
- RF-02
- RF-03

### Artefatos da funcionalidade
#### Models
- Usuario.cs
- Professor.cs
- Responsavel.cs
#### Controllers
- UsuariosController.cs
#### Views
- Usuarios/Index.cshtml
- Usuarios/Create.cshtml
- Usuarios/EnviarCredenciais.cshtml
#### Outros
- site.css
- site.js
- updateMsg-check.js
- usuario-create.js
- list-usuarios.js
- formatar-telefone.js
- formatar-cep.js

### Instruções de acesso
1. Caso esteja rodando o projeto localmente, criar uma pasta no diretório C: do seu computador chamada "AppEscolaMail" para recebimento local dos emails;
2. Visualize a tela inicial/homepage do projeto;
3. Realizar login na conta de administrador (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
4. Clicar na opção "Gerenciar usuários" do menu lateral;
5. Clicar em "Cadastrar usuário";
6. Preencher as informações do formulário de cadastro de usuário, selecionado o tipo de usuário a ser criado no primeiro campo do formulário e então clicar em "Cadastrar novo usuário";
7. Na tela seguinte, clicar na opção "Enviar email" para enviar o email contendo as credenciais de acesso para o usuário (desabilitado na versão online);
8. Após o envio do email, o usuário será redirecionado para a tela de visualizar usuários cadastrados, aonde o novo usuário deverá aparecer;
9. Caso esteja rodando o projeto localmente, abrir o arquivo .eml gerado na pasta C:/AppEscolaMail para visualizar o email enviado;
10. Caso esteja acessando o projeto online, o envio de emails está desabilitado na versão atual devido a uma mudança na política de acesso por "aplicações menos seguras" do google, que não permite que nossa aplicação possa acessar uma conta de e-mail para realizar o envio.

## Cadastro/Edição de disciplinas (RF-03 e RF-04)
A funcionalidade de cadastrar novas disciplinas no sistema é exclusiva para a conta do administrador. Após acessar sua conta, o administrador pode visualizar e editar as informações de todas as disciplinas cadastradas, bem como escolher cadastrar novas disciplinas. Durante o cadastro da disciplina, o administrador deve selecionar um ou mais professores e uma turma para a disciplina, além de informar os horários em que a disciplina será ministrada durante a semana. Caso o administrador deseje trocar os professores, horário ou turmas da disciplina mais tarde, essa troca pode ser feita clicando em "Editar" na tela de visualização de disciplinas. 

### Visualizar disciplinas cadastradas
![disciplinasA](https://user-images.githubusercontent.com/74699119/172967303-b4d14e40-b990-4f93-9edf-10078b5bf569.jpg)
### Formulário de cadastro de nova disciplina
![disciplinasB](https://user-images.githubusercontent.com/74699119/172967295-e210921f-d4a6-4643-b99b-c22389cb6db7.jpg)

### Requisitos atendidos
- RF-03
- RF-04

### Artefatos da funcionalidade
#### Models
- Disciplina.cs
- Professor.cs
#### Controllers
- DisciplinasController.cs
#### Views
- Disciplinas/Index.cshtml
- Disciplinas/Create.cshtml
#### Outros
- site.css
- site.js
- selecionar-pessoas.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login na conta de administrador (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
3. Clicar na opção "Gerenciar disciplinas" do menu lateral;
4. Clicar em "Cadastrar disciplina";
5. Preencher as informações do formulário de cadastro de disciplina e então clicar em "Cadastrar nova disciplina";
6. Após o cadastro da disciplina, caso uma turma tenha sido selecionada, o usuário será redirecionado para o quadro de disciplinas daquela turma (descrita na funcionalidade "Cadastro de novas turmas"), aonde a disciplina aparecerá cadastrada ou uma mensagem de erro aparecerá em caso de conflito de horário com outra disciplina. Não tendo sido selecionada uma turma, o usuário será redirecionado para a tela de visualizar disciplinas, aonde a nova disciplina deverá aparecer;

## Cadastro/Edição de turmas (RF-03, RF-04 e RF-05)
A funcionalidade de cadastrar novas turmas no sistema é exclusiva para a conta do administrador. Após acessar sua conta, o administrador pode visualizar e editar as informações de todas as turmas cadastradas, incluindo as disciplinas associadas a aquela turma clicando em "Editar" na tela de visualizar turmas ou indo diretamente para o quadro de disciplinas da turma clicando em "Ver quadro de disciplinas". O usuário pode também visualizar quais alunos estão associados a turma ao clicar em "Mais informações" na lista de turmas, embora a associação ou remoção de um aluno a uma turma não seja feita nesta tela, mas sim no próprio cadastro/edição de alunos.

### Visualizar turmas cadastradas
![turmasA](https://user-images.githubusercontent.com/74699119/172967329-433dc39c-9712-4bbe-81ac-a6f8497b4f54.jpg)
### Formulário de cadastro de nova turma
![turmasB](https://user-images.githubusercontent.com/74699119/172967334-63792990-c416-41b5-9cee-851ca62ee457.jpg)
### Quadro de disciplinas associadas à turma
![turmasC](https://user-images.githubusercontent.com/74699119/172967338-80ec0abd-4cb7-4a9e-9769-0fad47875942.jpg)
### Quadro de disciplinas associadas à turma (turma com disciplinas associadas)
![turmasD](https://user-images.githubusercontent.com/74699119/172967342-2ffdc618-e860-4579-8f69-5e92e392ba38.jpg)

### Requisitos atendidos
- RF-03
- RF-04
- RF-05

### Artefatos da funcionalidade
#### Models
- Turma.cs
#### Controllers
- TurmasController.cs
#### Views
- Turmas/Index.cshtml
- Turmas/Create.cshtml
- Turmas/Edit.cshtml
- Turmas/Delete.cshtml
- Turmas/GerenciarDisciplinas.cshtml
#### Outros
- site.css
- site.js
- selecionar-disciplinas.js
- posicionar-disciplinas-calendario.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login na conta de administrador (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
3. Clicar na opção "Gerenciar turmas" do menu lateral;
4. Clicar em "Cadastrar turma";
5. Preencher as informações do formulário de cadastro de turmas e então clicar em "Cadastrar nova turma";
6. Após o cadastro da turma, o usuário será redirecionado para a tela de gerenciamento de disciplinas da turma, aonde poderá adicionar disciplinas previamente cadastradas que não estejam associadas a nenhuma turma ao quadro de disciplinas da turma. Caso o usuário tente adicionar uma disciplina que entre em conflito de horário com uma disciplina já associada, uma mensagem de erro será exibida e a disciplina não será cadastrada.
7. Após o cadastro da turma, a nova turma cadastrada deverá aparecer na lista de turmas.

## Cadastro de novos alunos (RF-03, RF-05)
A funcionalidade de cadastrar novos alunos no sistema é exclusiva para a conta do administrador. Após acessar sua conta, o administrador pode visualizar e editar as informações de todos os alunos cadastrados, associando cada aluno a um ou mais responsáveis e a uma única turma durante o cadastro. O administrador pode futuramente trocar a turma do aluno ou mesmo a lista de responsáveis clicando na opção "Editar" na lista de alunos.

### Visualizar alunos cadastrados
![alunosA](https://user-images.githubusercontent.com/74699119/172967375-ae7d9f3b-11c7-47ad-b17f-611667c36220.jpg)
### Formulário de cadastro de novo aluno
![alunosB](https://user-images.githubusercontent.com/74699119/172967379-eface7ae-8ad4-4f4d-9e94-7d6125891281.jpg)
### Visualizar alunos cadastrados (após cadastro de aluno)
![alunosC](https://user-images.githubusercontent.com/74699119/172967383-0966bc15-c2dd-4764-8d18-06fcdb10bf02.jpg)

### Requisitos atendidos
- RF-03
- RF-05

### Artefatos da funcionalidade
#### Models
- Aluno.cs
#### Controllers
- AlunosController.cs
#### Views
- Alunos/Index.cshtml
- Alunos/Create.cshtml
- Alunos/Edit.cshtml
- Alunos/Delete.cshtml
#### Outros
- site.css
- site.js
- selecionar-pessoas.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login na conta de administrador (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
3. Clicar na opção "Gerenciar alunos" do menu lateral;
4. Clicar em "Cadastrar aluno";
5. Preencher as informações do formulário de cadastro de aluno e então clicar em "Cadastrar novo aluno", selecionando um ou mais responsáveis e uma turma para o aluno;
6. Após o cadastro do aluno, o novo aluno cadastrado deverá aparecer na lista de alunos.

## Cadastro de novas agendas (RF-10, RF-11)
A funcionalidade de cadastrar novas agendas no sistema é exclusiva para a conta do administrador. Após acessar sua conta, o administrador pode cadastrar novas agendas, além de visualizar e editar as informações de todas as agendas cadastradas. Ao cadastrar uma nova agenda, o administrador deve escolher qual tipo de usuário (responsável do aluno, professor ou todos) e quais turmas (que um dependente faça parte, no caso do pai, ou na qual o usuário ministre pelo menos uma disciplina, no caso do professor) poderão visualizar seu conteúdo. Há também por padrão a opção "todas as agendas", que abrange todos os eventos cadastrados sem uma agenda específica, e que portanto serão visíveis para todos os usuários do sistema.

### Visualizar agendas cadastrados
![cadastraragendaA](https://user-images.githubusercontent.com/74699119/172973529-d8d0f85c-d032-4808-bf54-57838e77c24c.jpg)

### Formulário de cadastro de nova agenda
![cadastraragendaB](https://user-images.githubusercontent.com/74699119/172973531-af569129-a17c-4984-942c-e1bcd8152413.jpg)

### Visualizar agendas cadastradas (após cadastro de nova agenda)
![cadastraragendaC](https://user-images.githubusercontent.com/74699119/172973538-0c88e1b3-de41-4c62-9adf-7a5f76c778e1.jpg)

### Requisitos atendidos
- RF-10
- RF-11

### Artefatos da funcionalidade
#### Models
- Agenda.cs
#### Controllers
- AgendaController.cs
#### Views
- Agendas/Index.cshtml
- Agendas/Create.cshtml
- Agendas/Edit.cshtml
- Agendas/Delete.cshtml

#### Outros
- site.css
- site.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login na conta de administrador (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
3. Clicar na opção "Gerenciar agendas" do menu lateral;
4. Clicar em "Cadastrar agenda";
5. Preencher as informações do formulário de cadastro de agenda, selecionando a turma e o tipo de usuário, e então clicar em "Cadastrar";
6. Após o cadastro da agenda, a nova agenda cadastrada deverá aparecer na lista de agendas.

## Cadastro de novos eventos em agenda (RF-10, RF-11)
A funcionalidade de cadastrar novos eventos em agendas é exclusiva para as contas de administrador e professor. Após acessar sua conta, o administrador/professor poderá cadastrar novos eventos nas agendas disponíveis, sendo que o administrador poderá cadastrar um evento em qualquer agenda existente ou na opção "todas as agendas" (que deixará o evento visível para todos os usuários), enquanto o professor poderá cadastrar eventos somente em agendas da qual faz parte (agendas de turmas em que dá aula ou agendas gerais para professores). O usuário que cadastrou um evento poderá também editar informações ou excluir o evento, mas não poderá editar ou excluir eventos cadastrados por outros usuários. Ao cadastrar um novo evento em uma agenda, o usuário deverá informar o nome, descrição, início e fim do evento, além de informar se a participação de alunos neste evento requer a autorização dos responsáveis, sendo que um pedido de autorização de participação será enviado para os responsáveis dos alunos solicitados caso essa ultima opção seja marcada.

### Visualizar eventos da agenda
![eventoAgendaA](https://user-images.githubusercontent.com/74699119/172974699-c93307b4-1a9f-4e1b-9436-ea9c36965a8c.jpg)

### Formulário de cadastro de novo evento na agenda
![eventoAgendaB](https://user-images.githubusercontent.com/74699119/172974702-bd21aa23-272c-4dbd-bb38-161fb87acc4e.jpg)

### Visualizar eventos da agenda (após cadastro de novo evento)
![eventoAgendaC](https://user-images.githubusercontent.com/74699119/172974706-118330da-11a5-421a-9c27-2cb0f5b4ce3b.jpg)

### Visualizar eventos da agenda em forma de lista (disponível apenas para administrador e professor)
![even![eventoAgendaE](https://user-images.githubusercontent.com/74699119/172974762-4e389f5a-027f-4395-adce-09d9503d99a5.jpg)
toAgendaD](https://user-images.githubusercontent.com/74699119/172974760-b433c13a-580a-4c14-add2-eb945b2edf23.jpg)
![eventoAgendaE](https://user-images.githubusercontent.com/74699119/172989472-3c414357-f835-48df-b359-d5964b1d3383.jpg)

### Requisitos atendidos
- RF-10
- RF-11

### Artefatos da funcionalidade
#### Models
- Agenda.cs
- EventoDaAgenda.cs
- AutorizacaoEvento.cs
#### Controllers
- AgendaController.cs
- EventosDaAgendaController.cs
- AutorizacoesEventosController.cs
#### Views
- Agendas/Visualizar.cshtml
- EventosDaAgenda/Index.cshtml
- EventosDaAgenda/Create.cshtml
- EventosDaAgenda/Edit.cshtml
- EventosDaAgenda/Details.cshtml
- EventosDaAgenda/Delete.cshtml

#### Outros
- site.css
- site.js
- agenda-escolar.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login na conta de administrador ou em uma conta do tipo "Professor" (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
3. Caso esteja logado como administrador, clicar na opção "Gerenciar agendas" do menu lateral e em "Visualizar" ao lado da agenda que deseja cadastrar o evento;
4. Caso esteja logado como professor, clicar na opção "Agenda escolar" do menu lateral;
5. Clicar em "Cadastrar evento";
5. Preencher as informações do formulário de cadastro de evento, selecionando a agenda em que deseja cadastra-lo e clique em "Cadastrar";
6. Após o cadastro do evento, ele deverá aparecer no dia em que foi cadastrado na agenda escolar escolhida.
7. Os usuários do tipo "Administrador" ou "Professor" podem também visualizar os eventos cadastrados em forma de lista ao clicar na opção "Lista de eventos";
8. Uma vez dentro da opção "Lista de eventos", o usuário poderá escolher editar ou apagar os eventos que cadastrou.

## Alterar informações pessoais (RF-06)
A funcionalidade de alterar dados pessoais é disponibilizada para todos os usuários do sistema através do menu do usuário. Esta funcionalidade permite que o usuário logado no sistema altere seu email, telefones, endereço e senha, não podendo alterar seu nome ou nome de usuário. Para alterar suas informações pessoais, incluindo a senha o usuário deve informar sua senha atual, com a troca de informações sendo bem sucedida apenas mediante a senha correta.

### Opção no menu do usuário
![alterardadosA](https://user-images.githubusercontent.com/74699119/172967399-dee9faf8-b5cd-4f7e-9a28-ba6117c60f3a.jpg)
### Tela de alterar informações
![alterardadosB](https://user-images.githubusercontent.com/74699119/172967402-7c348930-90cf-4483-96c9-85144c3716c1.jpg)
### Tela de alterar informações (após selecionar campo para alterar)
![alterardadosC](https://user-images.githubusercontent.com/74699119/172967405-4df89080-897b-41f3-9a86-c008668251c5.jpg)
### Tela de alterar informações (após alteração)
![alterardadosD](https://user-images.githubusercontent.com/74699119/172967408-105fdbce-6b73-49b4-a825-136b3f330c3e.jpg)

### Requisitos atendidos
- RF-06

### Artefatos da funcionalidade
#### Models
- Usuario.cs
#### Controllers
- UsuariosController.cs
#### Views
- Usuarios/AlterarDados.cshtml
#### Outros
- site.css
- site.js
- alterar-dados.js
- formatar-telefonejs
- formatar-cep.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login em qualquer conta de usuário;
3. Clicar sobre o nome do usuário no canto direito do cabeçalho para abrir o menu do usuário;
4. Selecionar a opção "Alterar dados";
5. Selecionar a informação que deseja alterar;
6. Preencher o formulário com as novas informações e informar a senha atual;
7. Clicar em "Alterar dados";
8. Caso a alteração seja bem sucedida, uma mensagem de sucesso será mostrada, caso alguma informação solicitada não seja aceita, uma mensagem de erro será mostrada.

## Troca de mensagens entre usuários (RF-07)
A funcionalidade de troca de mensagens é disponibilizada para todos os usuários do sistema através do menu do usuário. Esta funcionalidade permite que o usuário logado no sistema envie mensagens para um ou mais usuários destinatários, além de poder responder mensagens que sejam enviadas para ele. O usuário pode visualizar as mensagens que recebeu em sua caixa de entrada, tela inicial da seção "mensagens" do menu do usuário, e visualizar o conteúdo da conversa clicando no botão "Visualizar" da conversa, podendo ainda dentro dessa tela selecionar as opções "responder" ou "responder a todos" em uma mensagem individual da conversa para responde-la. O número total de mensagens não lidas presente em sua caixa de entrada é exibido em um contador presente ao lado da opção "mensagens" do menu. O usuário também pode visualizar as mensagens que enviou selecionando a seção "Enviados" na caixa de seleção presente no canto superior direito da caixa de entrada. 

### Caixa de entrada
![mensagensA](https://user-images.githubusercontent.com/74699119/172967477-671aba29-143c-4112-8c41-150c12f8ad94.jpg)
### Criar nova conversa
![mensagensB](https://user-images.githubusercontent.com/74699119/172967479-0907b393-1532-4a78-96b1-7b9cd1f5a98f.jpg)
### Caixa de entrada de um dos destinatários da mensagem (Observar que o usuário logado mudou de "Usuário" para "Mariana", a destinatária da mensagem anterior)
![mensagensC](https://user-images.githubusercontent.com/74699119/172967484-7b66eeff-7ce3-48be-8a1b-3744c0740329.jpg)
### Tela de visualizar mensagens da conversa/Caixa de responder mensagem (Usuário "Mariana")
![mensagensD](https://user-images.githubusercontent.com/74699119/172967485-cef3cbd9-e875-45a2-9a3c-2618c6627d10.jpg)
### Caixa de entrada do usuário respondido (Logado como usuário que foi respondido na imagem anterior)
![mensagensE](https://user-images.githubusercontent.com/74699119/172967486-d7fd915a-8efe-4485-9050-2791051fad5d.jpg)
### Tela de visualizar mensagens da conversa/Caixa de responder mensagem (Usuário "Usuário")
![mensagensF](https://user-images.githubusercontent.com/74699119/172967490-60827ec0-07c6-4642-9fc2-bfceea7a6875.jpg)

### Requisitos atendidos
- RF-07

### Artefatos da funcionalidade
#### Models
- Conversa.cs
- Mensagem.cs
- NumeroDeNovasMensagensNaConversa.cs

#### Controllers
- ConversasController.cs
#### Views
- Conversas/Index.cshtml
- Conversas/Create.cshtml
- Conversas/Visualizar.cshtml
#### Outros
- site.css
- site.js
- caixa-de-mensagens.js
- selecionar-pessoas.js
- visualizar-conversas.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login em qualquer conta de usuário;
3. Clicar na opção "Mensagens" do menu lateral;
4. Selecionar a opção "Nova mensagem";
5. Preencher o Assunto e conteúdo da mensagem e selecionar os destinatários;
6. Clicar em "Enviar";
7. Fazer logout da conta atual e fazer login na conta de um dos destinatários da mensagem.
8. Clicar na opção "Mensagens" do menu lateral para acessar a caixa de entrada, a conversa deve constar na lista de conversas e o número de mensagens não lidas mostrada no contador ao lado da opção "Mensagens" deve ser pelo menos 1;
9. Clicar no botão "Visualizar" ao lado direito da conversa listada para ir para a tela de visualizar mensagens da conversa;
10. Clicar em "Responder" ou "Responder a todos" na mensagem para criar uma resposta.
11. Clicar no botão "Responder" da janela de escrever resposta.
12. Fazer logout da conta atual e fazer login na conta de um dos destinatários da resposta.
13. Clicar na opção "Mensagens" do menu lateral para acessar a caixa de entrada e clicar em "Visualizar";
14. Visualizar resposta enviada.

## Arquivar mensagens (RF-07)
A funcionalidade de arquivar mensagens é disponibilizada para todos os usuários do sistema através do menu do usuário. Esta funcionalidade permite que o usuário logado no sistema selecione as mensagens que deseja arquivar clicando no botão "Arquivar" da mensagem presente na caixa de entrada ou na seção "enviados". A mensagem será movida para a seção "Arquivados" e as mensagens não lidas daquela conversa não serão mais contabilizadas no número total de mensagens não lidas mostrada pra o usuário. Para mover uma mensagem de volta para a caixa de entrada/seção de "enviados" o usuário deve ir na seção de de mensagens arquivadas e clicar no botão "Desarquivar" ao lado da mensagem.
 
### Caixa de mensagens
![arquivarA](https://user-images.githubusercontent.com/74699119/172967583-e52318fa-ae90-4fdf-a558-075259a64136.jpg)
![arquivarB](https://user-images.githubusercontent.com/74699119/172967587-87ffe4ce-05c1-4e61-a9fa-a81ee48f9287.jpg)
### Seção de mensagens arquivadas
![arquivarC](https://user-images.githubusercontent.com/74699119/172967595-2f8b1ff9-b31b-44ae-9520-0d7780b23486.jpg)

### Requisitos atendidos
- RF-07

### Artefatos da funcionalidade
#### Models
- Conversa.cs
- Mensagem.cs
- NumeroDeNovasMensagensNaConversa.cs
- UsuariosQueArquivaramAConversa.cs
#### Controllers
- ConversasController.cs
#### Views
- Conversas/Index.cshtml
- Conversas/Visualizar.cshtml
#### Outros
- site.css
- site.js
- caixa-de-mensagens.js
- visualizar-conversas.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login em qualquer conta de usuário;
3. Clicar na opção "Mensagens" do menu lateral;
4. Clicar no botão "Arquivar" ao lado da mensagem que deseja arquivar;
5. Trocar a seção de "Caixa de entrada" para "Arquivados" selecionado a opção na caixa de seleção presente no canto superior direito da caixa de entrada.
6. Visualizar mensagem arquivada na seção "Arquivados";
7. Clicar no botão "Desarquivar";
8. Voltar para a seção original da mensagem e verificar que a mensagem se encontra novamente nela;

## Envio e download de arquivos via mensagem (RF-08)
A funcionalidade de envio e download de arquivos é disponibilizada para todos os usuários do sistema através do menu do usuário. Esta funcionalidade permite que o usuário logado no sistema anexe arquivos junto as mensagens enviadas para os destinatários, que podem realizar o download dos arquivos ao clicar na opção "Fazer download" ao lado do nome de arquivo na lista de anexos da mensagem.

### Janela de seleção de arquivos na tela de criar mensagem
![arquivoA](https://user-images.githubusercontent.com/74699119/172967624-ede63dc4-4e46-4dbf-9367-de1c86b8d55e.jpg)
### Mensagem enviada contendo lista de anexos com opção de download do arquivo
![arquivoB](https://user-images.githubusercontent.com/74699119/172967629-b1e4d409-5aca-40e8-b61a-7bb26525cdcc.jpg)

### Requisitos atendidos
- RF-08

### Artefatos da funcionalidade
#### Models
- Conversa.cs
- Mensagem.cs
#### Controllers
- ConversasController.cs
#### Views
- Conversas/Index.cshtml
- Conversas/Visualizar.cshtml
#### Outros
- site.css
- site.js
- caixa-de-mensagens.js
- visualizar-conversas.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login em qualquer conta de usuário;
3. Clicar na opção "Mensagens" do menu lateral;
4. Selecionar a opção "Nova mensagem";
5. Preencher o Assunto e conteúdo da mensagem e selecionar os destinatários;
6. Clicar no botão "Escolher arquivos" e escolher os arquivos que deseja anexar a mensagem.
7. Clicar em "Enviar";
8. Fazer logout da conta atual e fazer login na conta de um dos destinatários da mensagem.
9. Clicar na opção "Mensagens" do menu lateral para acessar a caixa de entrada, a conversa deve constar na lista de conversas e o número de mensagens não lidas mostrada no contador ao lado da opção "Mensagens" deve ser pelo menos 1;
10. Clicar no botão "Visualizar" ao lado direito da conversa listada para ir para a tela de visualizar mensagens da conversa;
11. Clicar em "Fazer download" ao lado do nome do arquivo presente na lista de anexos.
12. O download do arquivo em questão será iniciado pelo browser para o computador do usuário.

## Busca de conversas e mensagens por assunto ou conteúdo (RF-09)
A funcionalidade de busca de conversas e mensagens por assunto o conteúdo é disponibilizada para todos os usuários do sistema através do menu do usuário. Esta funcionalidade permite que o usuário logado no sistema busque conversas e mensagens presentes em sua caixa de mensagens em qualquer uma de suas seções (Caixa de entrada, Enviados e Arquivados). Para realizar a busca, basta digitar os termos que deseja buscar no campo "Buscar conversa por assunto o conteúdo das mensagens" e clicar em "Buscar". A página deverá ser atualizada e mostrar apenas os resultados da busca.

### Caixa de mensagens
![buscarmensagemA](https://user-images.githubusercontent.com/74699119/172967659-1363c011-fa6c-405d-bc67-81ea4ce0a7d8.jpg)
### Caixa de mensagens (Após realização da busca)
![buscarmensagemB](https://user-images.githubusercontent.com/74699119/172967661-91fdfd1e-19c4-493d-8d91-8ce8e49373e6.jpg)

### Requisitos atendidos
- RF-09

### Artefatos da funcionalidade
#### Models
- Conversa.cs
- Mensagem.cs
- MensagemArquivosAnexados.cs

#### Controllers
- ConversasController.cs
- CommonController.cs
#### Views
- Conversas/Index.cshtml
- Conversas/Create.cshtml
- Conversas/Visualizar.cshtml
#### Outros
- site.css
- site.js
- caixa-de-mensagens.js

### Instruções de acesso
1. Visualize a tela inicial/homepage do projeto;
2. Realizar login em qualquer conta de usuário;
3. Clicar na opção "Mensagens" do menu lateral;
4. Preencher o campo "Buscar conversa por assunto o conteúdo das mensagens" com os termos que deseja utilizar na busca, sendo que os termos serão buscados no assunto da conversa e no conteúdo de todas as mensagens da mesma;
5. Clicar em "Buscar";
6. Visualizar as mensagens filtradas pela busca;
