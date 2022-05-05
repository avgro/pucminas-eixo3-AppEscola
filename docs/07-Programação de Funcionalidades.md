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


