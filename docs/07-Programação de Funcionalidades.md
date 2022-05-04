# Programação de Funcionalidades

Nesta seção são demonstradas as telas correspondentes a cada funcionalidade implementada do sistema. As instruções de acesso são apresentados em seguida.

## Login e autenticação (RF-01)
A funcionalidade de login é acessada ao clicar no botão "Login" do cabeçalho enquanto não se está logado em nenhuma conta. As contas de usuário são criadas exclusivamente pelo administrador do sistema, podendo ser do perfil "Responsável do aluno", "Professor" e "Outros". Há ainda a conta com perfil "Administrador", que é exclusiva para o administrador do sistema. Ao entrar na tela de login, o usuário informa seu nome de usuário e senha, e, caso o sistema reconheça as informações como corretas, inicia-se a sessão daquele usuário. No caso de informações incorretas, o sistema retorna uma mensagem de erro informando que o usuário ou senha informados são inválidos. Após a realização bem sucedida do login, o usuário é direcionado para a tela inicial do usuário, aonde terá acesso a um menu lateral cujas opções variam de acordo com o perfil de usuário (opções de gerenciar informações do sistema aparecem apenas para o administrador, etc).

![Login](https://user-images.githubusercontent.com/74699119/166829687-7895e04a-aa4d-41cb-b720-b3441fc25e85.png)

### Requisitos atendidos
- RF-01

### Artefatos da funcionalidade
- Usuario.cs
- UsuariosController.cs
- Usuarios/Login.cshtml
- Usuarios/AccessDenied.cshtml

### Instruções de acesso
1. Faça o download do arquivo do projeto (ZIP) ou clone do projeto no GitHub;
2. Abra o arquivo "App-comunicacao-escolar.sln" no Visual Studio;
3. Execute o comando "update-database" no console do Package Manager para criar as tabelas do banco de dados localmente através dos arquivos "migrations" do Entity Framework Core;
4. Rode o projeto no localhost:7060 utilizando o Visual Studio;
5. Visualize a tela inicial/homepage do projeto;
6. Clique no botão "Login" presente no canto direito do cabeçalho;
7. Informe suas credenciais de login (caso nenhum usuário tenha sido cadastrado, utilizar nome de usuário "admin" e senha "admin" para acessar a conta do administrador);
8. Caso as credenciais tenham sido validadas, a sessão será iniciada e o usuário redirecionado para a página inicial do usuário.
