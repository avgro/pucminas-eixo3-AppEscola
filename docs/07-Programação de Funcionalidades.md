# Programação de Funcionalidades

Nesta seção são demonstradas as telas correspondentes a cada funcionalidade implementada do sistema. As instruções de acesso são apresentados em seguida.

## Login e autenticação (RF-01)
A funcionalidade de login é acessada ao clicar no botão "Login" do cabeçalho enquanto não se está logado em nenhuma conta. As contas de usuário são criadas exclusivamente pelo administrador do sistema, podendo ser do perfil "Responsável do aluno", "Professor" e "Outros". Há ainda a conta com perfil "Administrador", que é exclusiva para o administrador do sistema. Ao entrar na tela de login, o usuário informa seu nome de usuário e senha, e, caso o sistema reconheça as informações como corretas, inicia-se a sessão daquele usuário. No caso de informações incorretas, o sistema retorna uma mensagem de erro informando que o usuário ou senha informados são inválidos. Após a realização bem sucedida do login, o usuário é direcionado para a tela inicial do usuário, aonde terá acesso a um menu lateral cujas opções variam de acordo com o perfil de usuário (opções de gerenciar informações do sistema aparecem apenas para o administrador, etc).

![Login](https://user-images.githubusercontent.com/74699119/166829687-7895e04a-aa4d-41cb-b720-b3441fc25e85.png)

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
1. Faça o download do arquivo do projeto (ZIP) ou clone do projeto no GitHub;
2. Abra o arquivo "App-comunicacao-escolar.sln" no Visual Studio;
3. Execute o comando "update-database" no console do Package Manager para criar as tabelas do banco de dados localmente através dos arquivos "migrations" do Entity Framework Core;
5. Rode o projeto no Visual Studio, que abrirá uma janela do browser no endereço localhost:7060;
5. Visualize a tela inicial/homepage do projeto;
6. Clique no botão "Login" presente no canto direito do cabeçalho;
7. Informe suas credenciais de login (caso nenhum usuário tenha sido cadastrado, utilizar nome de usuário "admin" e senha "admin" para acessar a conta do administrador);
8. Caso as credenciais tenham sido validadas, a sessão será iniciada e o usuário redirecionado para a página inicial do usuário.

## Cadastro de novos usuários e envio de email com credenciais de acesso pelo administrador (RF-02 e RF-03)
A funcionalidade de cadastrar novos usuários no sistema é exclusiva para a conta do administrador, uma vez que o cadastro na plataforma deve ser exclusiva para responsaveis de alunos e funcionários da escola. Após acessar sua conta, o administrador pode visualizar e editar as informações de todos os usuários cadastrados, bem como escolher cadastrar um novo usuário do tipo "Responsável de aluno", "Professor" ou "Outros" (tipo de conta genérica utilizada por funcionários que não sejam professores). Após a criação da conta, o administrador poderá enviar um email para o e-mail do novo usuário contendo suas credenciais de acesso para a plataforma. Na versão local do projeto (executada via localhost), esse e-mail é enviado para uma pasta no diretório C: com o nome "AppEscolaMail". Na versão que será hospedade online, o email será de fato enviado para a conta de email informada durante o cadastro. Essa funcionalidade também atende parcialmente o RF-03, uma vez que o cadastro de responsáveis e professores ocorre nela junto a criação de suas respectivas contas de usuário.

### Visualizar usuários cadastrados
![CadastrarUsuarioA](https://user-images.githubusercontent.com/74699119/166859983-735ab572-6baf-4614-a482-7e26d034a4a0.png)
### Formulário de cadastro de novo usuário
![CadastrarUsuarioB](https://user-images.githubusercontent.com/74699119/166859988-452b62a7-21f6-439f-b3d5-80981e8daa81.png)
#### (Informações adicionais solicitadas para cadastro de professor)
![CadastrarUsuarioBextra](https://user-images.githubusercontent.com/74699119/166859992-a1794085-458b-4b65-8189-7e805a26d36b.png)
### Tela de envio de email de confirmação
![CadastrarUsuarioC](https://user-images.githubusercontent.com/74699119/166859994-14d03792-69d4-4c15-9468-aa043df9fad1.png)
### Tela de visualizar usuários com novo usuário cadastrado
![CadastrarUsuarioD](https://user-images.githubusercontent.com/74699119/166859998-59bdb63f-071f-40d2-96a3-84eb8c4bc441.png)

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
1. Faça o download do arquivo do projeto (ZIP) ou clone do projeto no GitHub;
2. Abra o arquivo "App-comunicacao-escolar.sln" no Visual Studio;
3. Execute o comando "update-database" no console do Package Manager para criar as tabelas do banco de dados localmente através dos arquivos "migrations" do Entity Framework Core;
4. Criar uma pasta no diretório C: do seu computador chamada "AppEscolaMail" para recebimento local dos emails;
5. Rode o projeto no Visual Studio, que abrirá uma janela do browser no endereço localhost:7060;
6. Visualize a tela inicial/homepage do projeto;
7. Realizar login na conta de administrador (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
8. Clicar na opção "Gerenciar usuários" do menu lateral;
9. Clicar em "Cadastrar usuário";
10. Preencher as informações do formulário de cadastro de usuário, selecionado o tipo de usuário a ser criado no primeiro campo do formulário e então clicar em "Cadastrar novo usuário";
11. Na tela seguinte, clicar na opção "Enviar email" para enviar o email contendo as credenciais de acesso para o usuário;
12. Após o envio do email, o usuário será redirecionado para a tela de visualizar usuários cadastrados, aonde o novo usuário deverá aparecer;
13. Abrir o arquivo .eml gerado na pasta C:/AppEscolaMail para visualizar o email enviado;

## Cadastro de novas disciplinas (RF-03 e RF-04)
A funcionalidade de cadastrar novas disciplinas no sistema é exclusiva para a conta do administrador. Após acessar sua conta, o administrador pode visualizar e editar as informações de todas as disciplinas cadastradas, bem como escolher cadastrar novas disciplinas. Durante o cadastro da disciplina, o administrador deve selecionar um ou mais professores e uma turma para a disciplina, além de informar os horários em que a disciplina será ministrada durante a semana. Caso o administrador deseje trocar os professores, horário ou turmas da disciplina mais tarde, essa troca pode ser feita clicando em "Editar" na tela de visualização de disciplinas.

### Visualizar disciplinas cadastradas
![CadastrarDisciplinaA](https://user-images.githubusercontent.com/74699119/166860547-498bf430-692d-452d-b820-3b865d2b0bf1.png)
### Formulário de cadastro de nova disciplina
![CadastrarDisciplinaB](https://user-images.githubusercontent.com/74699119/166860548-d0f9138e-5f28-4c8a-b51c-8aeb02ba56bf.png)

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
1. Faça o download do arquivo do projeto (ZIP) ou clone do projeto no GitHub;
2. Abra o arquivo "App-comunicacao-escolar.sln" no Visual Studio;
3. Execute o comando "update-database" no console do Package Manager para criar as tabelas do banco de dados localmente através dos arquivos "migrations" do Entity Framework Core;
4. Criar uma pasta no diretório C: do seu computador chamada "AppEscolaMail" para recebimento local dos emails;
5. Rode o projeto no Visual Studio, que abrirá uma janela do browser no endereço localhost:7060;
6. Visualize a tela inicial/homepage do projeto;
7. Realizar login na conta de administrador (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
8. Clicar na opção "Gerenciar disciplinas" do menu lateral;
9. Clicar em "Cadastrar disciplina";
10. Preencher as informações do formulário de cadastro de disciplina e então clicar em "Cadastrar nova disciplina";
11. Após o cadastro da disciplina, caso uma turma tenha sido selecionada, o usuário será redirecionado para o quadro de disciplinas daquela turma (descrita na funcionalidade "Cadastro de novas turmas"), aonde a disciplina aparecerá cadastrada ou uma mensagem de erro aparecerá em caso de conflito de horário com outra disciplina. Não tendo sido selecionada uma turma, o usuário será redirecionado para a tela de visualizar disciplinas, aonde a nova disciplina deverá aparecer;

## Cadastro de novas turmas (RF-03, RF-04 e RF-05)
A funcionalidade de cadastrar novas turmas no sistema é exclusiva para a conta do administrador. Após acessar sua conta, o administrador pode visualizar e editar as informações de todas as turmas cadastradas, incluindo as disciplinas associadas a aquela turma clicando em "Editar" na tela de visualizar turmas ou indo diretamente para o quadro de disciplinas da turma clicando em "Ver quadro de disciplinas". O usuário pode também visualizar quais alunos estão associados a turma ao clicar em "Mais informações" na lista de turmas, embora a associação ou remoção de um aluno a uma turma não seja feita nesta tela, mas sim no próprio cadastro/edição de alunos.

### Visualizar turmas cadastradas
![CadastrarTurmaA](https://user-images.githubusercontent.com/74699119/167016782-1a7f3ee6-6d6f-4f62-b46e-80a905a1cda3.png)
### Formulário de cadastro de nova turma
![CadastrarTurmaB](https://user-images.githubusercontent.com/74699119/167016788-d6568cee-6de0-4438-8b52-1d8a8ba1cc52.png)
### Quadro de disciplinas associadas à turma
![CadastrarTurmaC](https://user-images.githubusercontent.com/74699119/167016798-e2982340-4d44-494d-80f0-a26a2e7329ba.png)
### Quadro de disciplinas associadas à turma (turma com disciplinas associadas)
![CadastrarTurmaD](https://user-images.githubusercontent.com/74699119/167017345-301a6c0a-47cf-4758-a765-2029f633c17c.png)

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
- Turmas/GerenciarDisciplinas.cshtml
#### Outros
- site.css
- site.js
- selecionar-disciplinas.js
- posicionar-disciplinas-calendario.js

### Instruções de acesso
1. Faça o download do arquivo do projeto (ZIP) ou clone do projeto no GitHub;
2. Abra o arquivo "App-comunicacao-escolar.sln" no Visual Studio;
3. Execute o comando "update-database" no console do Package Manager para criar as tabelas do banco de dados localmente através dos arquivos "migrations" do Entity Framework Core;
4. Criar uma pasta no diretório C: do seu computador chamada "AppEscolaMail" para recebimento local dos emails;
5. Rode o projeto no Visual Studio, que abrirá uma janela do browser no endereço localhost:7060;
6. Visualize a tela inicial/homepage do projeto;
7. Realizar login na conta de administrador (conforme as instruções da funcionalidade "Login e autenticação" contida nesta seção);
8. Clicar na opção "Gerenciar turmas" do menu lateral;
9. Clicar em "Cadastrar turmas";
10. Preencher as informações do formulário de cadastro de turmas e então clicar em "Cadastrar nova turma";
11. Após o cadastro da turma, o usuário será redirecionado para a tela de gerenciamento de disciplinas da turma, aonde poderá adicionar disciplinas previamente cadastradas que não estejam associadas a nenhuma turma ao quadro de disciplinas da turma. Caso o usuário tente adicionar uma disciplina que entre em conflito de horário com uma disciplina já associada, uma mensagem de erro será exibida e a disciplina não será cadastrada.
12. Após o cadastro da turma, a nova turma cadastrada deverá aparecer na lista de turmas.
